using System;
using System.Data;
using System.IO;
using COSXML;
using COSXML.Auth;
using COSXML.Model.Object;
using COSXML.Model.Tag;

namespace GreenOnions.Utility.Helper
{
    public class TencentCloudClient
    {
        private CosXmlServer _cosXml;
        private string _appid;
        private string _region;
        private string _bucket;

        /// <summary>
        /// 创建腾讯云服务器SDK访问对象
        /// </summary>
        /// <param name="appid">appid</param>
        /// <param name="region">地区</param>
        /// <param name="secretId">secretId</param>
        /// <param name="secretKey">secretKey</param>
        /// <param name="bucket">存储桶名称</param>
        /// <param name="durationSecond">有效时长,单位为 秒</param>
        public TencentCloudClient(string appid, string region, string secretId, string secretKey, string bucket, long durationSecond = 600)
        {
            _appid = appid;
            _region = region;
            _bucket = bucket;

            //初始化 CosXmlConfig 
            CosXmlConfig config = new CosXmlConfig.Builder()
                .SetConnectionTimeoutMs(60000)
                .SetReadWriteTimeoutMs(40000)
                .IsHttps(true)
                .SetAppid(appid)
                .SetRegion(region)
                .SetDebugLog(true)
                .Build();
            QCloudCredentialProvider cosCredentialProvider = new DefaultQCloudCredentialProvider(secretId, secretKey, durationSecond);

            //初始化 CosXmlServer
            _cosXml = new CosXmlServer(config, cosCredentialProvider);
        }

        /// <summary>
        /// 请求腾讯云COS的API
        /// </summary>
        /// <param name="appid">腾讯云账号 APPID</param>
        /// <param name="region">存储桶地域</param>
        /// <param name="bucket">存储桶</param>
        /// <param name="key">对象键</param>
        /// <param name="param">额外参数</param>
        /// <returns>返回XML</returns>
        public Stream TencentCOSGetHttpResponse(string appid, string region, string bucket, string key, string param = "")
        {
            if (!param.StartsWith("&")) param = "&" + param;

            PreSignatureStruct preSignatureStruct = new PreSignatureStruct();
            preSignatureStruct.appid = appid;//腾讯云账号 APPID
            preSignatureStruct.region = region; //存储桶地域
            preSignatureStruct.bucket = bucket; //存储桶
            preSignatureStruct.key = key; //对象键
            preSignatureStruct.httpMethod = "GET"; //HTTP 请求方法
            preSignatureStruct.isHttps = true; //生成 HTTPS 请求 URL
            preSignatureStruct.signDurationSecond = 600; //请求签名时间为 600s
            preSignatureStruct.headers = null;//签名中需要校验的 header
            preSignatureStruct.queryParameters = null; //签名中需要校验的 URL 中请求参数
            string requestSignURL = _cosXml.GenerateSignURL(preSignatureStruct) + param;

            return HttpHelper.GetHttpResponseStream(requestSignURL, out _);
        }

        public enum CheckedPornStatus
        {
            Healthed = 0,
            NotHealth = 1,
            Error = 2,
        }

        public CheckedPornStatus CheckImageHealth(string localFileName, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                string strScore = CheckImagePornScore(localFileName, null, null);
                return CheckHealthed(strScore);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return CheckedPornStatus.Error;
            }
        }

        public CheckedPornStatus CheckImageHealth(byte[] file, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                string strScore = CheckImagePornScore(null,file,null);
                return CheckHealthed(strScore);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return CheckedPornStatus.Error;
            }
        }

        public CheckedPornStatus CheckImageHealth(Stream stream, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                string strScore = CheckImagePornScore(null, null, stream);
                return CheckHealthed(strScore);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return CheckedPornStatus.Error;
            }
        }

        private CheckedPornStatus CheckHealthed(string strScore)
        {
            if (int.TryParse(strScore, out int Score))
            {
                if (Score > 90)
                {
                    //鉴黄不通过删除图片(腾讯云竟然会因为留存色图而封号...)
                    DeleteObjectRequest request = new DeleteObjectRequest(_bucket, "CheckPorn.png");
                    _cosXml.DeleteObject(request);
                    return CheckedPornStatus.NotHealth;  //非法
                }
                return CheckedPornStatus.Healthed;  //合法
            }
            else
            {
                LogHelper.WriteErrorLog($"鉴黄分值非数字");
                return CheckedPornStatus.Error;  //失败
            }
        }

        private string CheckImagePornScore(string localFileName, byte[] file, Stream stream)
        {
            if (SaveFileToTencentCOS(localFileName, file, stream, _bucket, "CheckPorn.png"))
            {
                return CheckPornScoreInner();
            }
            throw new Exception("鉴黄失败，未能成功上传图片到云端。");
        }

        private string CheckPornScoreInner()
        {
            using (Stream stream = TencentCOSGetHttpResponse(_appid, _region, _bucket, "CheckPorn.png", "&ci-process=sensitive-content-recognition&detect-type=porn"))
            {
                DataSet ds = new DataSet();
                ds.ReadXml(stream);
                if (ds.Tables.Contains("PornInfo") && ds.Tables["PornInfo"].Rows.Count > 0)
                {
                    if (ds.Tables["PornInfo"].Rows[0]["Code"].ToString() == "0")
                    {
                        return ds.Tables["PornInfo"].Rows[0]["Score"].ToString();
                    }
                    else
                    {
                        string msg = ds.Tables["PornInfo"].Rows[0]["Msg"].ToString();
                        LogHelper.WriteWarningLog($"调用腾讯云Api成功, 但没有返回正确的结果:{msg}");
                        return msg;
                    }
                }
                throw new Exception("鉴黄失败，没有获取到鉴黄结果。");
            }
        }

        /// <summary>
        /// 上传到腾讯云COS
        /// </summary>
        /// <param name="srcPath">本地文件绝对路径</param>
        /// <param name="src">文件二进制内容</param>
        /// <param name="srcStream">文件流</param>
        /// <param name="bucket">存储桶，格式：BucketName-APPID</param>
        /// <param name="key">对象键</param>
        /// <returns>是否上传成功</returns>
        public bool SaveFileToTencentCOS(string srcPath, byte[] src, Stream srcStream, string bucket, string key)
        {
            try
            {
                PutObjectRequest request;
                if (!string.IsNullOrWhiteSpace(srcPath))
                    request = new PutObjectRequest(bucket, key, srcPath);
                else if (src is not null && src.Length > 0)
                    request = new PutObjectRequest(bucket, key, src);
                else if (srcStream is not null)
                    request = new PutObjectRequest(bucket, key, srcStream);
                else
                    return false;

                //设置进度回调
                request.SetCosProgressCallback(delegate (long completed, long total)
                {
                    //Console.WriteLine(String.Format("progress = {0:##.##}%", completed * 100.0 / total));
                });
                //执行请求
                PutObjectResult result = _cosXml.PutObject(request);
                //对象的 eTag
                string eTag = result.eTag;
                return true;
            }
            catch (COSXML.CosException.CosClientException clientEx)
            {
                //请求失败
                //Console.WriteLine("CosClientException: " + clientEx);
            }
            catch (COSXML.CosException.CosServerException serverEx)
            {
                //请求失败
                //Console.WriteLine("CosServerException: " + serverEx.GetInfo());
            }
            return false;
        }
    }
}
