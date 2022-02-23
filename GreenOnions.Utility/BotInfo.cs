using GreenOnions.Utility.Helper;
using GreenOnions.Utility.Items;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GreenOnions.Utility
{
    public static class BotInfo
    {
        public static bool IsLogin { get; set; } = false;

        #region -- 公共属性 --
        [PropertyChineseName("机器人QQ号")]
        public static long QQId
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(QQId));
                if (long.TryParse(strValue, out long iValue)) return iValue;
                return 0;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(QQId), value.ToString());
        }

        public static string IP
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(IP)) ?? "127.0.0.1";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(IP), value);
        }

        public static string Port
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(Port)) ?? "33111";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(Port), value);
        }

        public static string VerifyKey
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(VerifyKey));
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(VerifyKey), value);
        }

        /// <summary>
        /// 机器人名称
        /// </summary>
        [PropertyChineseName("机器人名称")]
        public static string BotName
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(BotName)) ?? "葱葱";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(BotName), value);
        }

        /// <summary>
        /// 机器人管理员QQ
        /// </summary>
        public static IEnumerable<long> AdminQQ
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(AdminQQ));
                if (string.IsNullOrEmpty(strValue))
                    return new List<long>();
                return strValue.Split(';').Select(long.Parse);
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(AdminQQ), string.Join(";", value));
        }

        /// <summary>
        /// 是否启用图片缓存
        /// </summary>
        public static bool ImageCache
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(ImageCache));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(ImageCache), value.ToString());
        }

        /// <summary>
        /// 黑名单组
        /// </summary>
        public static IEnumerable<long> BannedGroup
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(BannedGroup));
                if (string.IsNullOrEmpty(strValue))
                    return new List<long>();
                return strValue.Split(';').Select(long.Parse);

            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(BannedGroup), string.Join(";", value));
        }

        /// <summary>
        /// 黑名单用户
        /// </summary>
        public static IEnumerable<long> BannedUser
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(BannedUser));
                if (string.IsNullOrEmpty(strValue))
                    return new List<long>();
                return strValue.Split(';').Select(long.Parse);
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(BannedUser), string.Join(";", value));
        }

        /// <summary>
        /// 是否启用加速链
        /// </summary>
        public static bool EnabledAccelerate
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(EnabledAccelerate));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(EnabledAccelerate), value.ToString());
        }

        /// <summary>
        /// 加速链地址
        /// </summary>
        public static string AccelerateUrl
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(AccelerateUrl));
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(AccelerateUrl), value);
        }

        /// <summary>
        /// 是否启用调试模式
        /// </summary>
        public static bool DebugMode
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(DebugMode));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(DebugMode), value.ToString());
        }

        /// <summary>
        /// 调试组
        /// </summary>
        public static IEnumerable<long> DebugGroups
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(DebugGroups));
                if (string.IsNullOrEmpty(strValue))
                    return new List<long>();
                return strValue.Split(';').Select(long.Parse);

            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(DebugGroups), string.Join(";", value));
        }

        /// <summary>
        /// 调试模式下是否只响应指定群组的消息
        /// </summary>
        public static bool OnlyReplyDebugGroup
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(OnlyReplyDebugGroup));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(OnlyReplyDebugGroup), value.ToString());
        }

        /// <summary>
        /// 调试模式下是否只响应机器人管理员的消息
        /// </summary>
        public static bool DebugReplyAdminOnly
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(DebugReplyAdminOnly));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(DebugReplyAdminOnly), value.ToString());
        }
        
        /// <summary>
        /// 允许Windows系统使用浏览器执行Http请求
        /// </summary>
        public static bool HttpRequestByWebBrowser
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(HttpRequestByWebBrowser));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(HttpRequestByWebBrowser), value.ToString());
        }

        #endregion -- 公共属性 --

        #region -- 搜图属性 --
        /// <summary>
        /// 是否启用搜图功能
        /// </summary>
        public static bool SearchEnabled
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchEnabled));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchEnabled), value.ToString());
        }

        /// <summary>
        /// 是否启用SauceNao搜图
        /// </summary>
        public static bool SearchEnabledSauceNao
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchEnabledSauceNao));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchEnabledSauceNao), value.ToString());
        }

        /// <summary>
        /// SauceNao Api-Key
        /// </summary>
        public static IEnumerable<string> SauceNAOApiKey
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SauceNAOApiKey));
                if (string.IsNullOrEmpty(strValue))
                    return new List<string>();
                return strValue.Split(';');
            }
            set
            {
                foreach (var key in value)
                {
                    if (!Cache.SauceNaoKeysAndLongRemaining.ContainsKey(key))  //如果添加了新Key, 装进缓存
                        Cache.SauceNaoKeysAndLongRemaining.Add(key, 200);
                    if (!Cache.SauceNaoKeysAndShortRemaining.ContainsKey(key))  //如果添加了新Key, 装进缓存
                        Cache.SauceNaoKeysAndShortRemaining.Add(key, 6);
                }
                var removeLong = Cache.SauceNaoKeysAndLongRemaining.Keys.ToList().Except(value);
                foreach (var item in removeLong)
                    Cache.SauceNaoKeysAndLongRemaining.Remove(item);
                var removeShort = Cache.SauceNaoKeysAndShortRemaining.Keys.ToList().Except(value);
                foreach (var item in removeShort)
                    Cache.SauceNaoKeysAndShortRemaining.Remove(item);
                JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SauceNAOApiKey), string.Join(";", value));
            }
        }

        /// <summary>
        /// 是否启用ASCII2D搜图
        /// </summary>
        public static bool SearchEnabledASCII2D
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchEnabledASCII2D));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchEnabledASCII2D), value.ToString());
        }

        /// <summary>
        /// 是否启用TraceMoe搜番
        /// </summary>
        public static bool SearchEnabledTraceMoe
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchEnabledTraceMoe));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchEnabledTraceMoe), value.ToString());
        }

        /// <summary>
        /// 开启连续搜图命令(正则表达式)
        /// </summary>
        public static string SearchModeOnCmd
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchModeOnCmd)) ?? "<机器人名称>搜[图圖図]";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchModeOnCmd), value);
        }

        /// <summary>
        /// 关闭连续搜图命令(正则表达式)
        /// </summary>
        public static string SearchModeOffCmd
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchModeOffCmd)) ?? "[谢謝][谢謝]<机器人名称>";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchModeOffCmd), value);
        }

        /// <summary>
        /// 连续搜图超时返回消息
        /// </summary>
        public static string SearchModeTimeOutReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchModeTimeOutReply)) ?? "由于超时，已为您自动退出搜图模式，以后要记得说“谢谢<机器人名称>”来退出搜图模式噢";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchModeTimeOutReply), value);
        }

        /// <summary>
        /// 开启连续搜图功能返回消息
        /// </summary>
        public static string SearchModeOnReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchModeOnReply)) ?? "了解～请发送图片吧！支持批量噢！\r\n如想退出搜索模式请发送“谢谢<机器人名称>”";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchModeOnReply), value);
        }

        /// <summary>
        /// 已在连续搜图模式下返回消息
        /// </summary>
        public static string SearchModeAlreadyOnReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchModeAlreadyOnReply)) ?? "您已经在搜图模式下啦！\r\n如想退出搜索模式请发送“谢谢<机器人名称>”";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchModeAlreadyOnReply), value);
        }

        /// <summary>
        /// 关闭连续搜图功能返回消息
        /// </summary>
        public static string SearchModeOffReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchModeOffReply)) ?? "不用谢!(<ゝω・)☆";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchModeOffReply), value);
        }

        /// <summary>
        /// 已经关闭连续搜图功能返回消息
        /// </summary>
        public static string SearchModeAlreadyOffReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchModeAlreadyOffReply)) ?? "虽然不知道为什么谢我, 但是还请注意补充营养呢(｀・ω・´)";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchModeAlreadyOffReply), value);
        }

        /// <summary>
        /// 没有搜索到结果返回消息
        /// </summary>
        public static string SearchNoResultReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchNoResultReply)) ?? "<搜索类型>没有搜到该图片o(╥﹏╥)o";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchNoResultReply), value);
        }

        /// <summary>
        /// 搜索过程中发生异常返回消息
        /// </summary>
        public static string SearchErrorReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchErrorReply)) ?? "搜图服务器爆炸惹_(:3」∠)_";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchErrorReply), value);
        }

        /// <summary>
        /// 相似度阈值
        /// </summary>
        [PropertyChineseName("相似度阈值")]
        public static int SearchLowSimilarity
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchLowSimilarity));
                if (int.TryParse(strValue, out int iValue)) return iValue;
                return 60;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchLowSimilarity), value.ToString());
        }

        /// <summary>
        /// TraceMoe搜图相似度大于此数值时发送搜番结果
        /// </summary>
        [PropertyChineseName("TraceMoe发送阈值")]
        public static int TraceMoeSendThreshold
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(TraceMoeSendThreshold));
                if (int.TryParse(strValue, out int iValue)) return iValue;
                return 87;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(TraceMoeSendThreshold), value.ToString());
        }
        
        /// <summary>
        /// 相似度低于阈值返回消息
        /// </summary>
        public static string SearchLowSimilarityReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchLowSimilarityReply)) ?? "相似度低于<相似度阈值>%，缩略图不予显示。";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchLowSimilarityReply), value);
        }

        /// <summary>
        /// 是否接入腾讯云AI鉴黄
        /// </summary>
        public static bool CheckPornEnabled
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(CheckPornEnabled));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(CheckPornEnabled), value.ToString());
        }

        /// <summary>
        /// 是否在下载原图功能上启用鉴黄
        /// </summary>
        public static bool OriginPictureCheckPornEnabled
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(OriginPictureCheckPornEnabled));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(OriginPictureCheckPornEnabled), value.ToString());
        }

        /// <summary>
        /// 搜图功能鉴黄不通过返回消息
        /// </summary>
        public static string SearchCheckPornIllegalReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchCheckPornIllegalReply)) ?? "AI鉴黄不通过，缩略图不予显示。";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchCheckPornIllegalReply), value);
        }

        /// <summary>
        /// 搜图功能鉴黄发生异常返回消息
        /// </summary>
        public static string SearchCheckPornErrorReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchCheckPornErrorReply)) ?? "AI鉴黄发生错误，缩略图不予显示。<错误信息>";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchCheckPornErrorReply), value);
        }

        /// <summary>
        /// 在Windows系统下时ASCII2D优先以浏览器进行请求(以应对近期403问题)
        /// </summary>
        public static bool ASCII2DRequestByWebBrowser
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(ASCII2DRequestByWebBrowser));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(ASCII2DRequestByWebBrowser), value.ToString());
        }
        
        /// <summary>
        /// 超过鉴黄次数的行为 0:既发送地址也发图 1:只发送地址不发图 2:发送地址且追加回复
        /// </summary>
        public static int SearchCheckPornOutOfLimitEvent
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchCheckPornOutOfLimitEvent));
                if (int.TryParse(strValue, out int iValue)) return iValue;
                return 2;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchCheckPornOutOfLimitEvent), value.ToString());
        }
        
        /// <summary>
        /// 超过鉴黄次数时追加的回复语
        /// </summary>
        public static string SearchCheckPornOutOfLimitReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchCheckPornOutOfLimitReply)) ?? "今日AI鉴黄次数已耗尽，缩略图不予显示。";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchCheckPornOutOfLimitReply), value);
        }
        
        /// <summary>
        /// 未启用鉴黄时的行为 0:发图 1:不发图
        /// </summary>
        public static int SearchNoCheckPorn
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchNoCheckPorn));
                if (int.TryParse(strValue, out int iValue)) return iValue;
                return 0;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchNoCheckPorn), value.ToString());
        }

        #region -- 腾讯云相关属性 --
        /// <summary>
        /// 腾讯云APPID
        /// </summary>
        public static string TencentCloudAPPID
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(TencentCloudAPPID));
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(TencentCloudAPPID), value);
        }

        /// <summary>
        /// 腾讯云CloudRegion
        /// </summary>
        public static string TencentCloudRegion
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(TencentCloudRegion));
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(TencentCloudRegion), value);
        }

        /// <summary>
        /// 腾讯云SecretId
        /// </summary>
        public static string TencentCloudSecretId
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(TencentCloudSecretId));
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(TencentCloudSecretId), value);
        }

        /// <summary>
        /// 腾讯云SecretKey
        /// </summary>
        public static string TencentCloudSecretKey
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(TencentCloudSecretKey));
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(TencentCloudSecretKey), value);
        }

        /// <summary>
        /// 腾讯云桶名称
        /// </summary>
        public static string TencentCloudBucket
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(TencentCloudBucket));
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(TencentCloudBucket), value);
        }

        /// <summary>
        /// 每日允许的鉴黄次数
        /// </summary>
        public static int CheckPornLimitCount
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(CheckPornLimitCount));
                if (int.TryParse(strValue, out int iValue)) return iValue;
                return 2000;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(CheckPornLimitCount), value.ToString());
        }

        #endregion -- 腾讯云相关属性 --

        #endregion -- 搜图属性 --

        #region -- 下载原图属性 --
        /// <summary>
        /// 是否启用下载原图
        /// </summary>
        public static bool OriginPictureEnabled
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(OriginPictureEnabled));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(OriginPictureEnabled), value.ToString());
        }

        /// <summary>
        /// 是否在搜图功能上启用鉴黄
        /// </summary>
        public static bool SearchCheckPornEnabled
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchCheckPornEnabled));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchCheckPornEnabled), value.ToString());
        }

        /// <summary>
        /// 下载原图功能上鉴黄不通过时做以下动作: 0.以合并转发的方式发送原图 1.不做任何事 2.回复设置的语句
        /// </summary>
        public static int OriginPictureCheckPornEvent
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(OriginPictureCheckPornEvent));
                if (int.TryParse(strValue, out int iValue)) return iValue;
                return 87;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(OriginPictureCheckPornEvent), value.ToString());
        }

        /// <summary>
        /// 下载原图功能鉴黄不通过返回消息
        /// </summary>
        public static string OriginPictureCheckPornIllegalReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(OriginPictureCheckPornIllegalReply)) ?? "AI鉴黄不通过。";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(OriginPictureCheckPornIllegalReply), value);
        }

        /// <summary>
        /// 下载原图功能鉴黄错误返回消息
        /// </summary>
        public static string OriginPictureCheckPornErrorReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(OriginPictureCheckPornErrorReply)) ?? "AI鉴黄发生错误。<错误信息>";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(OriginPictureCheckPornErrorReply), value);
        }
        #endregion  -- 下载原图属性 --

        #region -- 翻译属性 --

        /// <summary>
        /// 是否启用翻译功能
        /// </summary>
        public static bool TranslateEnabled
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTranslate, nameof(TranslateEnabled));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTranslate, nameof(TranslateEnabled), value.ToString());
        }

        public static TranslateEngine TranslateEngineType
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTranslate, nameof(TranslateEngineType));
                if (!string.IsNullOrEmpty(strValue))
                    return (TranslateEngine)Enum.Parse(typeof(TranslateEngine), strValue);
                return TranslateEngine.Google;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTranslate, nameof(TranslateEngineType), value.ToString());
        }

        /// <summary>
        /// 翻译为中文命令(正则表达式)
        /// </summary>
        public static string TranslateToChineseCMD
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTranslate, nameof(TranslateToChineseCMD)) ?? "<机器人名称>翻[译譯][:：]";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTranslate, nameof(TranslateToChineseCMD), value);
        }

        /// <summary>
        /// 翻译为指定语言命令(正则表达式)
        /// </summary>
        public static string TranslateToCMD
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTranslate, nameof(TranslateToCMD)) ?? "<机器人名称>翻[译譯][成为為到至](.+[语語文])[:：]";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTranslate, nameof(TranslateToCMD), value);
        }

        public static string TranslateFromToCMD
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTranslate, nameof(TranslateFromToCMD)) ?? "<机器人名称>[把从從自从](?<from>.+[语語文])翻[译譯][成为為到至](?<to>.+[语語文])[:：]";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTranslate, nameof(TranslateFromToCMD), value);
        }

        public static IEnumerable<long> AutoTranslateGroupMemoriesQQ
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTranslate, nameof(AutoTranslateGroupMemoriesQQ));
                if (string.IsNullOrEmpty(strValue))
                    return new List<long>();
                return strValue.Split(';').Select(long.Parse);

            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTranslate, nameof(AutoTranslateGroupMemoriesQQ), string.Join(";", value));
        }

        #endregion -- 翻译属性 --

        #region -- 色图属性 --
        public static string HPictureApiKey
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureApiKey));
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureApiKey), value);
        }

        /// <summary>
        /// Lolicon图库色图完整命令(正则表达式)
        /// </summary>
        public static string HPictureCmd
        {
            get => GetLoliconHPictureCmd();
        }

        /// <summary>
        /// 美图完整命令(正则表达式)
        /// </summary>
        public static string BeautyPictureCmd
        {
            get => GetBeautyPictureCmd();
        }

        private static string GetLoliconHPictureCmd()
        {
            string HPictureEnd = HPictureEndCmd;
            if (HPictureEndCmdNull)
            {
                HPictureEnd = $"({HPictureEnd})?";
            }

            return $"^<机器人名称>{GetPictureCmdInner()}{HPictureEnd}$";
        }

        private static string GetBeautyPictureCmd()
        {
            string BeautyPictureEnd = BeautyPictureEndCmd;
            if (BeautyPictureEndCmdNull)
            {
                BeautyPictureEnd = $"({BeautyPictureEnd})?";
            }

            return $"^<机器人名称>{GetPictureCmdInner()}{BeautyPictureEnd}$";
        }

        private static string GetPictureCmdInner()
        {
            string Begin, Count, Unit, R18, Keyword;

            Begin = HPictureBeginCmd;
            if (HPictureBeginCmdNull)
            {
                Begin = $"({Begin})?";
            }
            Count = HPictureCountCmd;
            if (HPictureCountCmdNull)
            {
                Count = $"({Count})?";
            }
            Unit = HPictureUnitCmd;
            if (HPictureUnitCmdNull)
            {
                Unit = $"({Unit})?";
            }
            R18 = HPictureR18Cmd;
            if (HPictureR18CmdNull)
            {
                R18 = $"({R18})?";
            }
            Keyword = HPictureKeywordCmd;
            if (HPictureKeywordCmdNull)
            {
                Keyword = $"({Keyword})?";
            }
            return $"{Begin}{Count}{Unit}{R18}{Keyword}{R18}";
        }


        /// <summary>
        /// 色图命令前缀(正则表达式)
        /// </summary>
        public static string HPictureBeginCmd
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureBeginCmd)) ?? "<机器人名称>[我再]?[要来來发發给給]";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureBeginCmd), value);
        }

        /// <summary>
        /// 色图数量命令(正则表达式)
        /// </summary>
        public static string HPictureCountCmd
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureCountCmd)) ?? "[0-9零一壹二两贰兩三叁四肆五伍六陆陸七柒八捌九玖十拾百佰千仟万萬亿億]+?";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureCountCmd), value);
        }

        /// <summary>
        /// 色图单位命令(正则表达式)
        /// </summary>
        public static string HPictureUnitCmd
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureUnitCmd)) ?? "[张張个個幅份]";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureUnitCmd), value);
        }

        /// <summary>
        /// 色图R-18命令(正则表达式)
        /// </summary>
        public static string HPictureR18Cmd
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureR18Cmd)) ?? "[Rr]-?18的?";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureR18Cmd), value);
        }

        /// <summary>
        /// 色图关键词命令(正则表达式)
        /// </summary>
        public static string HPictureKeywordCmd
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureKeywordCmd)) ?? ".+?";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureKeywordCmd), value);
        }

        /// <summary>
        /// 色图结束命令后缀(正则表达式)
        /// </summary>
        public static string HPictureEndCmd
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureEndCmd)) ?? "的?[色瑟][图圖図]";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureEndCmd), value);
        }

        /// <summary>
        /// 美图结束命令后缀(正则表达式)
        /// </summary>
        public static string BeautyPictureEndCmd
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(BeautyPictureEndCmd)) ?? "的?美[图圖図]";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(BeautyPictureEndCmd), value);
        }

        /// <summary>
        /// 是否允许色图命令前缀为空
        /// </summary>
        public static bool HPictureBeginCmdNull
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureBeginCmdNull));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureBeginCmdNull), value.ToString());
        }

        /// <summary>
        /// 是否允许色图数量命令为空
        /// </summary>
        public static bool HPictureCountCmdNull
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureCountCmdNull));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureCountCmdNull), value.ToString());
        }

        /// <summary>
        /// 是否允许色图单位命令为空
        /// </summary>
        public static bool HPictureUnitCmdNull
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureUnitCmdNull));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureUnitCmdNull), value.ToString());
        }

        /// <summary>
        /// 是否允许R-18命令为空
        /// </summary>
        public static bool HPictureR18CmdNull
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureR18CmdNull));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureR18CmdNull), value.ToString());

        }

        /// <summary>
        /// 是否允许关键词命令为空
        /// </summary>
        public static bool HPictureKeywordCmdNull
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureKeywordCmdNull));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureKeywordCmdNull), value.ToString());
        }

        /// <summary>
        /// 是否允许色图命令后缀为空
        /// </summary>
        public static bool HPictureEndCmdNull
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureEndCmdNull));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureEndCmdNull), value.ToString());
        }

        /// <summary>
        /// 是否允许美图命令后缀为空
        /// </summary>
        public static bool BeautyPictureEndCmdNull
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(BeautyPictureEndCmdNull));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(BeautyPictureEndCmdNull), value.ToString());
        }

        /// <summary>
        /// 是否撤回美图(撤回时间跟随色图撤回时间设置)
        /// </summary>
        public static bool RevokeBeautyPicture
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(RevokeBeautyPicture));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(RevokeBeautyPicture), value.ToString());
        }

        /// <summary>
        /// 启动的美图图库
        /// </summary>
        public static List<PictureSource> EnabledBeautyPictureSource
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(EnabledBeautyPictureSource));
                if (string.IsNullOrEmpty(strValue))
                    return new List<PictureSource>();
                return strValue.Split(';').Select(s => (PictureSource)Enum.Parse(typeof(PictureSource), s)).ToList();
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(EnabledBeautyPictureSource), string.Join(";", value));
        }

        /// <summary>
        /// 启动的色图图库
        /// </summary>
        public static List<PictureSource> EnabledHPictureSource
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(EnabledHPictureSource));
                if (string.IsNullOrEmpty(strValue))
                    return new List<PictureSource>();
                return strValue.Split(';').Select(s => (PictureSource)Enum.Parse(typeof(PictureSource), s)).ToList();
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(EnabledHPictureSource), string.Join(";", value));
        }

        /// <summary>
        /// 自定义色图命令
        /// </summary>
        public static IEnumerable<string> HPictureUserCmd
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureUserCmd));
                if (string.IsNullOrEmpty(strValue))
                    return new List<string>();
                return strValue.Split(';');
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureUserCmd), string.Join(";", value));
        }

        /// <summary>
        /// 白名单群
        /// </summary>
        public static IEnumerable<long> HPictureWhiteGroup
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureWhiteGroup));
                if (string.IsNullOrEmpty(strValue))
                    return new List<long>();
                return strValue.Split(';').Select(long.Parse);
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureWhiteGroup), string.Join(";", value));
        }

        /// <summary>
        /// 是否仅限白名单使用色图
        /// </summary>
        public static bool HPictureWhiteOnly
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureWhiteOnly));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureWhiteOnly), value.ToString());
        }

        /// <summary>
        /// 是否启用R-18
        /// </summary>
        public static bool HPictureAllowR18
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureAllowR18));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureAllowR18), value.ToString());
        }

        /// <summary>
        /// 是否仅限白名单使用R-18
        /// </summary>
        public static bool HPictureR18WhiteOnly
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureR18WhiteOnly));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureR18WhiteOnly), value.ToString());
        }

        /// <summary>
        /// 允许私聊
        /// </summary>
        public static bool HPictureAllowPM
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureAllowPM));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureAllowPM), value.ToString());
        }

        /// <summary>
        /// 反和谐
        /// </summary>
        public static bool HPictureAntiShielding
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureAntiShielding));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureAntiShielding), value.ToString());
        }


        /// <summary>
        /// 1200像素模式
        /// </summary>
        public static bool HPictureSize1200
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureSize1200));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureSize1200), value.ToString());
        }

        /// <summary>
        /// 冷却时间
        /// </summary>
        public static int HPictureCD
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureCD));
                if (int.TryParse(strValue, out int iValue)) return iValue;
                return 0;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureCD), value.ToString());
        }

        /// <summary>
        /// 次数限制
        /// </summary>
        public static int HPictureLimit
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureLimit));
                if (int.TryParse(strValue, out int iValue)) return iValue;
                return 0;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureLimit), value.ToString());
        }

        /// <summary>
        /// 撤回时间
        /// </summary>
        public static int HPictureRevoke
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureRevoke));
                if (int.TryParse(strValue, out int iValue)) return iValue;
                return 0;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureRevoke), value.ToString());
        }

        /// <summary>
        /// 白名单群冷却时间
        /// </summary>
        public static int HPictureWhiteCD
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureWhiteCD));
                if (int.TryParse(strValue, out int iValue)) return iValue;
                return 0;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureWhiteCD), value.ToString());
        }

        /// <summary>
        /// 白名单群撤回时间
        /// </summary>
        public static int HPictureWhiteRevoke
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureWhiteRevoke));
                if (int.TryParse(strValue, out int iValue)) return iValue;
                return 0;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureWhiteRevoke), value.ToString());
        }

        /// <summary>
        /// 私聊冷却时间
        /// </summary>
        public static int HPicturePMCD
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPicturePMCD));
                if (int.TryParse(strValue, out int iValue)) return iValue;
                return 0;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPicturePMCD), value.ToString());
        }

        /// <summary>
        /// 私聊撤回时间
        /// </summary>
        public static int HPicturePMRevoke
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPicturePMRevoke));
                if (int.TryParse(strValue, out int iValue)) return iValue;
                return 0;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPicturePMRevoke), value.ToString());
        }

        /// <summary>
        /// 机器人管理员无冷却时间/次数限制
        /// </summary>
        public static bool HPictureAdminNoLimit
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureAdminNoLimit));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureAdminNoLimit), value.ToString());
        }

        /// <summary>
        /// 群主和群管理无冷却时间/次数限制
        /// </summary>
        public static bool HPictureManageNoLimit
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureManageNoLimit));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureManageNoLimit), value.ToString());
        }

        /// <summary>
        /// 私聊无冷却时间/次数限制
        /// </summary>
        public static bool HPicturePMNoLimit
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPicturePMNoLimit));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPicturePMNoLimit), value.ToString());
        }

        /// <summary>
        /// 白名单群无冷却时间/次数限制
        /// </summary>
        public static bool HPictureWhiteNoLimit
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureWhiteNoLimit));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureWhiteNoLimit), value.ToString());
        }

        /// <summary>
        /// 冷却中回复
        /// </summary>
        public static string HPictureCDUnreadyReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureCDUnreadyReply)) ?? "乖，要懂得节制哦，休息一会再冲吧 →_→";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureCDUnreadyReply), value);
        }

        /// <summary>
        /// 次数用尽回复
        /// </summary>
        public static string HPictureOutOfLimitReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureOutOfLimitReply)) ?? "今天不要再冲了啦(>_<)";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureOutOfLimitReply), value);
        }

        /// <summary>
        /// 发生错误回复
        /// </summary>
        public static string HPictureErrorReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureErrorReply)) ?? "色图服务器爆炸惹_(:3」∠)_";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureErrorReply), value);
        }

        /// <summary>
        /// 没有结果回复
        /// </summary>
        public static string HPictureNoResultReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureNoResultReply)) ?? "没有找到符合条件的图ㄟ( ▔, ▔ )ㄏ";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureNoResultReply), value);
        }

        /// <summary>
        /// 下载失败回复
        /// </summary>
        public static string HPictureDownloadFailReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureDownloadFailReply)) ?? "地址为:<URL>的色图不见了，可能是色图服务器下载失败或图真的没了o(╥﹏╥)o (如连续出现时请检查<机器人名称>网络/代理/加速链/墙问题。)";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureDownloadFailReply), value);
        }

        /// <summary>
        /// 色图次数限制记录类型
        /// </summary>
        public static LimitType HPictureLimitType
        {
            get
            {

                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureLimitType));
                if (!string.IsNullOrEmpty(strValue))
                    return (LimitType)Enum.Parse(typeof(LimitType), strValue);
                return LimitType.Frequency;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureLimitType), value.ToString());
        }

        /// <summary>
        /// 是否启用多线程下载色图
        /// </summary>
        public static bool HPictureMultithreading
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureMultithreading));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureMultithreading), value.ToString());
        }

        /// <summary>
        /// 一条色图命令最多允许返回多少张色图
        /// </summary>
        public static int HPictureOnceMessageMaxImageCount
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureOnceMessageMaxImageCount));
                if (int.TryParse(strValue, out int iValue)) return iValue;
                return 10;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureOnceMessageMaxImageCount), value.ToString());
        }

        /// <summary>
        /// 是否启用色图功能
        /// </summary>
        public static bool HPictureEnabled
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureEnabled));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureEnabled), value.ToString());
        }
        #endregion -- 色图属性 --

        #region -- 复读属性 --
        /// <summary>
        /// 是否启用随机复读
        /// </summary>
        public static bool RandomRepeatEnabled
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameRepeater, nameof(RandomRepeatEnabled));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameRepeater, nameof(RandomRepeatEnabled), value.ToString());
        }
        /// <summary>
        /// 随机复读概率
        /// </summary>
        public static int RandomRepeatProbability
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameRepeater, nameof(RandomRepeatProbability));
                if (int.TryParse(strValue, out int iValue)) return iValue;
                return 1;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameRepeater, nameof(RandomRepeatProbability), value.ToString());
        }
        /// <summary>
        /// 是否启用连续复读
        /// </summary>
        public static bool SuccessiveRepeatEnabled
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameRepeater, nameof(SuccessiveRepeatEnabled));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameRepeater, nameof(SuccessiveRepeatEnabled), value.ToString());
        }
        /// <summary>
        /// 参与连续复读所需的复读次数
        /// </summary>
        public static int SuccessiveRepeatCount
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameRepeater, nameof(SuccessiveRepeatCount));
                if (int.TryParse(strValue, out int iValue)) return iValue;
                return 3;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameRepeater, nameof(SuccessiveRepeatCount), value.ToString());
        }
        /// <summary>
        /// 是否倒放复读Gif
        /// </summary>
        public static bool RewindGifEnabled
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameRepeater, nameof(RewindGifEnabled));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameRepeater, nameof(RewindGifEnabled), value.ToString());
        }
        /// <summary>
        /// 倒放复读Gif概率
        /// </summary>
        public static int RewindGifProbability
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameRepeater, nameof(RewindGifProbability));
                if (int.TryParse(strValue, out int iValue)) return iValue;
                return 50;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameRepeater, nameof(RewindGifProbability), value.ToString());
        }
        /// <summary>
        /// 是否水平反转复读图片
        /// </summary>
        public static bool HorizontalMirrorImageEnabled
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameRepeater, nameof(HorizontalMirrorImageEnabled));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameRepeater, nameof(HorizontalMirrorImageEnabled), value.ToString());
        }
        /// <summary>
        /// 水平反转复读图片概率
        /// </summary>
        public static int HorizontalMirrorImageProbability
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameRepeater, nameof(HorizontalMirrorImageProbability));
                if (int.TryParse(strValue, out int iValue)) return iValue;
                return 50;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameRepeater, nameof(HorizontalMirrorImageProbability), value.ToString());
        }
        /// <summary>
        /// 是否垂直翻转复读图片
        /// </summary>
        public static bool VerticalMirrorImageEnabled
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameRepeater, nameof(VerticalMirrorImageEnabled));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameRepeater, nameof(VerticalMirrorImageEnabled), value.ToString());
        }
        /// <summary>
        /// 垂直翻转复读图片概率
        /// </summary>
        public static int VerticalMirrorImageProbability
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameRepeater, nameof(VerticalMirrorImageProbability));
                if (int.TryParse(strValue, out int iValue)) return iValue;
                return 50;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameRepeater, nameof(VerticalMirrorImageProbability), value.ToString());
        }
        /// <summary>
        /// 将"我"替换为"你"
        /// </summary>
        public static bool ReplaceMeToYou
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameRepeater, nameof(ReplaceMeToYou));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameRepeater, nameof(ReplaceMeToYou), value.ToString());
        }
        #endregion -- 复读属性 --

        #region -- 进/退群消息属性 --

        /// <summary>
        /// 是否启用新人入群消息
        /// </summary>
        public static bool SendMemberJoinedMessage
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameGroupMemberEvent, nameof(SendMemberJoinedMessage));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameGroupMemberEvent, nameof(SendMemberJoinedMessage), value.ToString());
        }

        /// <summary>
        /// 是否启用成员退群消息
        /// </summary>
        public static bool SendMemberPositiveLeaveMessage
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameGroupMemberEvent, nameof(SendMemberPositiveLeaveMessage));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameGroupMemberEvent, nameof(SendMemberPositiveLeaveMessage), value.ToString());
        }

        /// <summary>
        /// 是否启用成员被踢消息
        /// </summary>
        public static bool SendMemberBeKickedMessage
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameGroupMemberEvent, nameof(SendMemberBeKickedMessage));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameGroupMemberEvent, nameof(SendMemberBeKickedMessage), value.ToString());
        }

        /// <summary>
        /// 新人入群消息
        /// </summary>
        public static string MemberJoinedMessage
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameGroupMemberEvent, nameof(MemberJoinedMessage)) ?? "<@成员QQ> 欢迎新大佬，群地位-1 (ΩДΩ)";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameGroupMemberEvent, nameof(MemberJoinedMessage), value);
        }

        /// <summary>
        /// 成员退群消息
        /// </summary>
        public static string MemberPositiveLeaveMessage
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameGroupMemberEvent, nameof(MemberPositiveLeaveMessage)) ?? "QQ号：<成员QQ> 退出了群，群地位+1 o(╥﹏╥)o";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameGroupMemberEvent, nameof(MemberPositiveLeaveMessage), value);
        }

        /// <summary>
        /// 成员被踢消息
        /// </summary>
        public static string MemberBeKickedMessage
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameGroupMemberEvent, nameof(MemberBeKickedMessage)) ?? " <成员昵称> ( <成员QQ> ) 被 <操作者昵称> 踢了出群，群地位+1 (*^▽^*)";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameGroupMemberEvent, nameof(MemberBeKickedMessage), value);
        }

        #endregion  -- 进/退群消息属性 --

        #region -- 伪造消息属性 --
        /// <summary>
        /// 是否启用伪造消息功能
        /// </summary>
        public static bool ForgeMessageEnabled
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameForgeMessage, nameof(ForgeMessageEnabled));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameForgeMessage, nameof(ForgeMessageEnabled), value.ToString());
        }

        /// <summary>
        /// 伪造消息前缀
        /// </summary>
        public static string ForgeMessageCmdBegin
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameForgeMessage, nameof(ForgeMessageCmdBegin)) ?? "<机器人名称>伪造(消息|聊天[记記][录錄])";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameForgeMessage, nameof(ForgeMessageCmdBegin), value);
        }

        /// <summary>
        /// 伪造消息分行符(分行符前后的内容会分成两条消息)
        /// </summary>
        public static string ForgeMessageCmdNewLine
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameForgeMessage, nameof(ForgeMessageCmdNewLine)) ?? @"\r\n";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameForgeMessage, nameof(ForgeMessageCmdNewLine), value);
        }

        /// <summary>
        /// 是否在伪造消息末端追加消息
        /// </summary>
        public static bool ForgeMessageAppendBotMessageEnabled
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameForgeMessage, nameof(ForgeMessageAppendBotMessageEnabled));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameForgeMessage, nameof(ForgeMessageAppendBotMessageEnabled), value.ToString());
        }
        
        /// <summary>
        /// 是否只允许机器人管理员使用伪造消息功能
        /// </summary>
        public static bool ForgeMessageAdminOnly
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameForgeMessage, nameof(ForgeMessageAdminOnly));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameForgeMessage, nameof(ForgeMessageAdminOnly), value.ToString());
        }
        
        /// <summary>
        /// 机器人管理员使用伪造消息功能时是否不在末端追加消息
        /// </summary>
        public static bool ForgeMessageAdminDontAppend
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameForgeMessage, nameof(ForgeMessageAdminDontAppend));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameForgeMessage, nameof(ForgeMessageAdminDontAppend), value.ToString());
        }

        /// <summary>
        /// 追加消息内容
        /// </summary>
        public static string ForgeMessageAppendMessage
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameForgeMessage, nameof(ForgeMessageAppendMessage)) ?? "此消息为<机器人名称>伪造，仅作娱乐，请勿用于非法用途。";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameForgeMessage, nameof(ForgeMessageAppendMessage), value);
        }

        /// <summary>
        /// 是否拒绝伪造机器人管理员的消息
        /// </summary>
        public static bool RefuseForgeAdmin
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameForgeMessage, nameof(RefuseForgeAdmin));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameForgeMessage, nameof(RefuseForgeAdmin), value.ToString());
        }

        /// <summary>
        /// 试图伪造机器人管理员消息时的回复语
        /// </summary>
        public static string RefuseForgeAdminReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameForgeMessage, nameof(RefuseForgeAdminReply)) ?? "你不能让我伪造我主人的消息。";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameForgeMessage, nameof(RefuseForgeAdminReply), value);
        }

        /// <summary>
        /// 是否拒绝伪造机器人的消息(如果由机器人管理员发起则不会校验此项目)
        /// </summary>
        public static bool RefuseForgeBot
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameForgeMessage, nameof(RefuseForgeBot));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameForgeMessage, nameof(RefuseForgeBot), value.ToString());
        }

        /// <summary>
        /// 试图伪造机器人消息时的回复语
        /// </summary>
        public static string RefuseForgeBotReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameForgeMessage, nameof(RefuseForgeBotReply)) ?? "你不会以为我会伪造自己的消息吧，不会吧不会吧？";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameForgeMessage, nameof(RefuseForgeBotReply), value);
        }

        #endregion -- 伪造消息属性 --

        #region -- RSS属性 --

        /// <summary>
        /// 是否启用Rss订阅转发
        /// </summary>
        public static bool RssEnabled
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTranslate, nameof(RssEnabled));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTranslate, nameof(RssEnabled), value.ToString());
        }

        /// <summary>
        /// 抓取RSS间隔时间(分钟)
        /// </summary>
        public static int ReadRssInterval
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(ReadRssInterval));
                if (int.TryParse(strValue, out int iValue)) return iValue;
                return 10;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(ReadRssInterval), value.ToString());
        }

        /// <summary>
        /// 订阅的地址和需要转发到的QQ或群列表
        /// </summary>
        public static IEnumerable<RssSubscriptionItem> RssSubscription
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameRss, nameof(RssSubscription));
                if (strValue == null) return null;
                return JsonConvert.DeserializeObject<IEnumerable<RssSubscriptionItem>>(strValue);
            }
            set 
            {
                JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameRss, nameof(RssSubscription), JsonConvert.SerializeObject(value));
            }
        }

        #endregion -- RSS属性 --
    }
    public enum LimitType
    {
        /// <summary>
        /// 记次
        /// </summary>
        Frequency = 0,
        /// <summary>
        /// 记张
        /// </summary>
        Count = 1,
    }

    public enum PictureSource
    {
        Lolicon = 0,
        ELF = 1,
        GreenOnions = 2,
    }

    public enum TranslateEngine
    {
        Google = 0,
        YouDao = 1,
    }
}