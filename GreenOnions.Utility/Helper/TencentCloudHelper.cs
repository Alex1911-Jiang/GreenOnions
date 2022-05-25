using COSXML;
using COSXML.Auth;
using COSXML.Model.Object;
using COSXML.Model.Tag;
using System;
using System.Data;
using System.IO;
using System.Net;

namespace GreenOnions.Utility.Helper
{
    public static class TencentCloudHelper
    {
        private static CosXmlServer _cosXml = null;
        public static CosXmlServer CosXml => _cosXml ?? throw new Exception("请先调用CreateCosXmlServer方法创建COS连接实例!");
        /// <summary>
        /// 是否已经创建了CosXmlServer
        /// </summary>
        public static bool IsCreateCosXmlServer => _cosXml != null;

        /// <summary>
        /// 请求腾讯云COS的API
        /// </summary>
        /// <param name="appid">腾讯云账号 APPID</param>
        /// <param name="region">存储桶地域</param>
        /// <param name="bucket">存储桶</param>
        /// <param name="key">对象键</param>
        /// <param name="param">额外参数</param>
        /// <returns>返回XML</returns>
        public static Stream TencentCOSGetHttpResponse(string appid, string region, string bucket, string key, string param = "")
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
            string requestSignURL = CosXml.GenerateSignURL(preSignatureStruct) + param;

            return HttpHelper.GetHttpResponseStream(requestSignURL, out _);
        }

        public enum CheckedPornStatus
        {
            Healthed = 0,
            NotHealth = 1,
            Error = 2,
            OutOfLimit = 3,
        }

        public static CheckedPornStatus CheckImageHealth(byte[] file, out string errorMessage)
        {
            errorMessage = "";
            if (Cache.CheckPornCounting > BotInfo.CheckPornLimitCount)
            {
                return CheckedPornStatus.OutOfLimit;
            }
            try
            {
                string strScore = CheckImagePornScore(file);
                if (int.TryParse(strScore, out int Score))
                {
                    Cache.CheckPornCounting++;
                    if (Score > 90)
                    {
                        //鉴黄不通过删除图片(腾讯云竟然会因为留存色图而封号...)
                        DeleteObjectRequest request = new DeleteObjectRequest(BotInfo.TencentCloudBucket, "CheckPorn.png");
                        CosXml.DeleteObject(request);
                        return CheckedPornStatus.NotHealth;  //非法
                    }
                    return CheckedPornStatus.Healthed;  //合法
                }
                else
                {
                    LogHelper.WriteErrorLog("腾讯云鉴黄的分值非数字");
                    return CheckedPornStatus.Error;  //非法
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return CheckedPornStatus.Error;
            }
        }

        public static CheckedPornStatus CheckImageHealth(string localFileName, out string errorMessage)
        {
            errorMessage = "";
            if (Cache.CheckPornCounting > BotInfo.CheckPornLimitCount)
            {
                return CheckedPornStatus.OutOfLimit;
            }
            try
            {
                string strScore = CheckImagePornScore(localFileName);
                if (int.TryParse(strScore, out int Score))
                {
                    Cache.CheckPornCounting++;
                    if (Score > 90)
                    {
                        //鉴黄不通过删除图片(腾讯云竟然会因为留存色图而封号...)
                        DeleteObjectRequest request = new DeleteObjectRequest(BotInfo.TencentCloudBucket, "CheckPorn.png");
                        CosXml.DeleteObject(request);
                        return CheckedPornStatus.NotHealth;  //非法
                    }
                    else
                    {
                        LogHelper.WriteErrorLog("腾讯云鉴黄的分值非数字");
                        return CheckedPornStatus.Error;  //非法
                    }
                }
                return CheckedPornStatus.Healthed;  //合法
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return CheckedPornStatus.Error;
            }
        }

        public static string CheckImagePornScore(byte[] file)
        {
            if (!IsCreateCosXmlServer)
            {
                CreateCosXmlServer(BotInfo.TencentCloudAPPID, BotInfo.TencentCloudRegion, BotInfo.TencentCloudSecretId, BotInfo.TencentCloudSecretKey);
            }
            if (SaveFileToTencentCOS(file, BotInfo.TencentCloudBucket, "CheckPorn.png"))
            {
                return CheckPornScoreInner();
            }
            throw new Exception("鉴黄失败，未能成功上传图片到云端。");
        }

        public static string CheckImagePornScore(string localFileName)
        {
            if (!IsCreateCosXmlServer)
            {
                CreateCosXmlServer(BotInfo.TencentCloudAPPID, BotInfo.TencentCloudRegion, BotInfo.TencentCloudSecretId, BotInfo.TencentCloudSecretKey);
            }
            if (SaveFileToTencentCOS(localFileName, BotInfo.TencentCloudBucket, "CheckPorn.png"))
            {
                return CheckPornScoreInner();
            }
            throw new Exception("鉴黄失败，未能成功上传图片到云端。");
        }

        private static string CheckPornScoreInner()
        {
            using (Stream stream = TencentCOSGetHttpResponse(BotInfo.TencentCloudAPPID, BotInfo.TencentCloudRegion, BotInfo.TencentCloudBucket, "CheckPorn.png", "&ci-process=sensitive-content-recognition&detect-type=porn"))
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
                        return ds.Tables["PornInfo"].Rows[0]["Msg"].ToString();
                    }
                }
                throw new Exception("鉴黄失败，没有获取到鉴黄结果。");
            }
        }

        /// <summary>
        /// 上传到腾讯云COS
        /// </summary>
        /// <param name="srcPath">本地文件绝对路径</param>
        /// <param name="bucket">存储桶，格式：BucketName-APPID</param>
        /// <param name="key">对象键</param>
        /// <returns>是否上传成功</returns>
        public static bool SaveFileToTencentCOS(string srcPath, string bucket, string key)
        {
            try
            {
                PutObjectRequest request = new PutObjectRequest(bucket, key, srcPath);
                //设置进度回调
                request.SetCosProgressCallback(delegate (long completed, long total)
                {
                    //Console.WriteLine(String.Format("progress = {0:##.##}%", completed * 100.0 / total));
                });
                //执行请求
                PutObjectResult result = CosXml.PutObject(request);
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

        /// <summary>
        /// 上传到腾讯云COS
        /// </summary>
        /// <param name="src">文件流</param>
        /// <param name="bucket">存储桶，格式：BucketName-APPID</param>
        /// <param name="key">对象键</param>
        /// <returns>是否上传成功</returns>
        public static bool SaveFileToTencentCOS(byte[] src, string bucket, string key)
        {
            try
            {
                PutObjectRequest request = new PutObjectRequest(bucket, key, src);
                //设置进度回调
                request.SetCosProgressCallback(delegate (long completed, long total)
                {
                    //Console.WriteLine(String.Format("progress = {0:##.##}%", completed * 100.0 / total));
                });
                //执行请求
                PutObjectResult result = CosXml.PutObject(request);
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

        /// <summary>
        /// 创建腾讯云服务器SDK访问对象
        /// </summary>
        /// <param name="appid">appid</param>
        /// <param name="region">地区</param>
        /// <param name="secretId">secretId</param>
        /// <param name="secretKey">secretKey</param>
        /// <param name="durationSecond">有效时长,单位为 秒</param>
        /// <returns></returns>
        private static CosXmlServer CreateCosXmlServer(string appid, string region, string secretId, string secretKey, long durationSecond = 600)
        {
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
            return CosXml;
        }
    }
}
