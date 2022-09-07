using GreenOnions.Interface;
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

        public static int LogLevel
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameOther, nameof(LogLevel));
                if (int.TryParse(strValue, out int iValue)) return iValue;
                return 2;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameOther, nameof(LogLevel), value.ToString());
        }

        #region -- 公共属性 --
        [PropertyChineseName("机器人QQ", "核心")]
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

        [PropertyChineseName("IP", "核心", "连接的机器人平台IP地址")]
        public static string IP
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(IP)) ?? "127.0.0.1";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(IP), value);
        }

        [PropertyChineseName("Port", "核心", "连接的机器人平台端口号")]
        public static ushort Port
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(Port));
                if (ushort.TryParse(strValue, out ushort usValue)) return usValue;
                return 0;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(Port), value.ToString());
        }

        [PropertyChineseName("VerifyKey/Access-Token", "核心", "连接的机器人平台令牌")]
        public static string VerifyKey
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(VerifyKey));
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(VerifyKey), value);
        }

        /// <summary>
        /// 机器人名称
        /// </summary>
        [PropertyChineseName("机器人名称", "核心")]
        public static string BotName
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(BotName)) ?? "葱葱";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(BotName), value);
        }

        /// <summary>
        /// 机器人管理员QQ
        /// </summary>
        [PropertyChineseName("机器人管理员QQ", "核心")]
        public static List<long> AdminQQ
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(AdminQQ));
                if (string.IsNullOrEmpty(strValue))
                    return new List<long>();
                return strValue.Split(';').Select(long.Parse).ToList();
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(AdminQQ), string.Join(";", value));
        }

        /// <summary>
        /// 黑名单组
        /// </summary>
        [PropertyChineseName("群黑名单", "核心")]
        public static List<long> BannedGroup
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(BannedGroup));
                if (string.IsNullOrEmpty(strValue))
                    return new List<long>();
                return strValue.Split(';').Select(long.Parse).ToList();

            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(BannedGroup), string.Join(";", value));
        }

        /// <summary>
        /// 黑名单用户
        /// </summary>
        [PropertyChineseName("用户黑名单", "核心")]
        public static List<long> BannedUser
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(BannedUser));
                if (string.IsNullOrEmpty(strValue))
                    return new List<long>();
                return strValue.Split(';').Select(long.Parse).ToList();
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(BannedUser), string.Join(";", value));
        }

        /// <summary>
        /// 是否启用调试模式
        /// </summary>
        [PropertyChineseName("调试模式", "核心")]
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
        /// 调试群组
        /// </summary>
        [PropertyChineseName("调试群组", "核心")]
        public static List<long> DebugGroups
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(DebugGroups));
                if (string.IsNullOrEmpty(strValue))
                    return new List<long>();
                return strValue.Split(';').Select(long.Parse).ToList();

            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(DebugGroups), string.Join(";", value));
        }

        /// <summary>
        /// 调试模式下是否只响应指定群组的消息
        /// </summary>
        [PropertyChineseName("只响应调试群组的消息", "核心", "调试模式下机器人是否只响应调试群组的消息")]
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
        [PropertyChineseName("只响应来自机器人管理员的消息", "核心", "调试模式下机器人是否只响应来自机器人管理员的消息")]
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
        [PropertyChineseName("允许调用浏览器执行Http请求", "核心", "是否允许Windows系统下使用Chrome浏览器执行Http请求")]
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

        /// <summary>
        /// 图片外链路由替换 0:不替换  1:替换为c2cpicdw.qpic.cn/offpic_new  2:替换为gchat.qpic.cn/gchatpic_new
        /// </summary>
        [PropertyChineseName("图片外链路由替换", "核心", "腾讯QQ群图片外链路由地址替换")]
        public static int ReplaceImgRoute
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(ReplaceImgRoute));
                if (int.TryParse(strValue, out int iValue)) return iValue;
                return 2;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(ReplaceImgRoute), value.ToString());
        }

        /// <summary>
        /// Pixiv代理地址
        /// </summary>
        [PropertyChineseName("Pixiv代理地址", "核心")]
        public static string PixivProxy
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(PixivProxy)) ?? "pixiv.re";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(PixivProxy), value);
        }

        /// <summary>
        /// 保留所有下载的图片用于缓存
        /// </summary>
        [PropertyChineseName("保留所有下载的图片用于缓存", "核心")]
        public static bool DownloadImage4Caching
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(DownloadImage4Caching));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(DownloadImage4Caching), value.ToString());
        }

        /// <summary>
        /// 所有图片下载到本地再发送文件
        /// </summary>
        [PropertyChineseName("所有图片下载到本地再发送文件", "核心")]
        public static bool SendImageByFile
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(SendImageByFile));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(SendImageByFile), value.ToString());
        }

        #region -- 腾讯云相关属性 --
        /// <summary>
        /// 是否接入腾讯云AI鉴黄
        /// </summary>
        [PropertyChineseName("接入腾讯云鉴黄", "核心")]
        public static bool CheckPornEnabled
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(CheckPornEnabled));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(CheckPornEnabled), value.ToString());
        }

        /// <summary>
        /// 腾讯云APPID
        /// </summary>
        [PropertyChineseName("腾讯云APPID", "核心")]
        public static string TencentCloudAPPID
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(TencentCloudAPPID));
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(TencentCloudAPPID), value);
        }

        /// <summary>
        /// 腾讯云CloudRegion
        /// </summary>
        [PropertyChineseName("腾讯云Region", "核心")]
        public static string TencentCloudRegion
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(TencentCloudRegion));
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(TencentCloudRegion), value);
        }

        /// <summary>
        /// 腾讯云SecretId
        /// </summary>
        [PropertyChineseName("腾讯云SecretId", "核心")]
        public static string TencentCloudSecretId
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(TencentCloudSecretId));
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(TencentCloudSecretId), value);
        }

        /// <summary>
        /// 腾讯云SecretKey
        /// </summary>
        [PropertyChineseName("腾讯云SecretKey", "核心")]
        public static string TencentCloudSecretKey
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(TencentCloudSecretKey));
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(TencentCloudSecretKey), value);
        }

        /// <summary>
        /// 腾讯云桶名称
        /// </summary>
        [PropertyChineseName("腾讯云Bucket", "核心")]
        public static string TencentCloudBucket
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(TencentCloudBucket));
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(TencentCloudBucket), value);
        }

        #endregion -- 腾讯云相关属性 --

        /// <summary>
        /// 是否启用自动连接到机器人平台
        /// </summary>
        [PropertyChineseName("自动连接到机器人平台", "核心", "是否在启用机器人后自动连接到机器人平台")]
        public static bool AutoConnectEnabled
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(AutoConnectEnabled));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(AutoConnectEnabled), value.ToString());
        }

        /// <summary>
        /// 自动连接的平台
        /// </summary>
        [PropertyChineseName("自动连接平台", "核心", "选择自动连接到的平台, 0 = Mirai-Api-Http, 1 = OneBot(Cqhttp)")]
        public static int AutoConnectProtocol
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(AutoConnectProtocol));
                if (int.TryParse(strValue, out int iValue)) return iValue;
                return 0;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(AutoConnectProtocol), value.ToString());
        }

        /// <summary>
        /// 连接前延时
        /// </summary>
        [PropertyChineseName("连接前延时", "核心", "机器人启动后等待多少秒后连接机器人平台(用于等待机器人平台启动)")]
        public static int AutoConnectDelay
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(AutoConnectDelay));
                if (int.TryParse(strValue, out int iValue)) return iValue;
                return 5;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(AutoConnectDelay), value.ToString());
        }

        [PropertyChineseName("仅在指定时段工作", "核心")]
        public static bool WorkingTimeEnabled
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(WorkingTimeEnabled));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(WorkingTimeEnabled), value.ToString());
        }

        [PropertyChineseName("工作时间 从", "核心", "时")]
        public static int WorkingTimeFromHour
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(WorkingTimeFromHour));
                if (int.TryParse(strValue, out int iValue)) return iValue;
                return 0;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(WorkingTimeFromHour), value.ToString());
        }

        [PropertyChineseName("工作时间 从", "核心", "分")]
        public static int WorkingTimeFromMinute
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(WorkingTimeFromMinute));
                if (int.TryParse(strValue, out int iValue)) return iValue;
                return 0;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(WorkingTimeFromMinute), value.ToString());
        }

        [PropertyChineseName("工作时间 到", "核心", "时")]
        public static int WorkingTimeToHour
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(WorkingTimeToHour));
                if (int.TryParse(strValue, out int iValue)) return iValue;
                return 0;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(WorkingTimeToHour), value.ToString());
        }

        [PropertyChineseName("工作时间 到", "核心", "分")]
        public static int WorkingTimeToMinute
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(WorkingTimeToMinute));
                if (int.TryParse(strValue, out int iValue)) return iValue;
                return 0;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameBot, nameof(WorkingTimeToMinute), value.ToString());
        }

        #endregion -- 公共属性 --

        #region -- 搜图属性 --
        /// <summary>
        /// 是否启用搜图功能
        /// </summary>
        [PropertyChineseName("启用搜图功能", "搜图")]
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
        /// 私聊时是否自动搜图
        /// </summary>
        [PropertyChineseName("私聊时自动搜图", "搜图")]
        public static bool PmAutoSearch
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(PmAutoSearch));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(PmAutoSearch), value.ToString());
        }

        #region -- TraceMoe --

        /// <summary>
        /// 是否启用TraceMoe搜番
        /// </summary>
        [PropertyChineseName("启用 TraceMoe 搜番", "搜图")]
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
        /// TraceMoe搜图相似度大于此数值时发送搜番结果
        /// </summary>
        [PropertyChineseName("TraceMoe 发送阈值", "搜图")]
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

        #endregion -- TraceMoe --

        #region -- SauceNAO --

        /// <summary>
        /// 是否启用SauceNAO搜图
        [PropertyChineseName("启用 SauceNAO 搜图", "搜图")]
        /// </summary>
        public static bool SearchEnabledSauceNAO
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchEnabledSauceNAO));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchEnabledSauceNAO), value.ToString());
        }

        /// <summary>
        /// SauceNAO在Windows系统下时SauceNAO优先以浏览器进行请求(腾讯云轻量403问题)
        /// </summary>
        [PropertyChineseName("SauceNAO 使用爬虫而非API", "搜图")]
        public static bool SauceNAORequestByWebBrowser
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SauceNAORequestByWebBrowser));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SauceNAORequestByWebBrowser), value.ToString());
        }

        /// <summary>
        /// SauceNAO Api-Key
        /// </summary>
        [PropertyChineseName("SauceNAO Api-Key", "搜图")]
        public static List<string> SauceNAOApiKey
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SauceNAOApiKey));
                if (string.IsNullOrEmpty(strValue))
                    return new List<string>();
                return strValue.Split(';').ToList();
            }
            set
            {
                foreach (var key in value)
                {
                    if (!Cache.SauceNAOKeysAndLongRemaining.ContainsKey(key))  //如果添加了新Key, 装进缓存
                        Cache.SauceNAOKeysAndLongRemaining.TryAdd(key, 200);
                    if (!Cache.SauceNAOKeysAndShortRemaining.ContainsKey(key))  //如果添加了新Key, 装进缓存
                        Cache.SauceNAOKeysAndShortRemaining.TryAdd(key, 6);
                }
                var removeLong = Cache.SauceNAOKeysAndLongRemaining.Keys.ToList().Except(value);
                foreach (var item in removeLong)
                    Cache.SauceNAOKeysAndLongRemaining.TryRemove(item, out _);
                var removeShort = Cache.SauceNAOKeysAndShortRemaining.Keys.ToList().Except(value);
                foreach (var item in removeShort)
                    Cache.SauceNAOKeysAndShortRemaining.TryRemove(item, out _);
                JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SauceNAOApiKey), string.Join(";", value));
            }
        }

        /// <summary>
        /// 是否SauceNAO搜图按相似度倒序排序
        /// </summary>
        [PropertyChineseName("按相似度排序", "搜图")]
        public static bool SearchSauceNAOSortByDesc
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchSauceNAOSortByDesc));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchSauceNAOSortByDesc), value.ToString());
        }

        /// <summary>
        /// SauceNAO 低相似度阈值
        /// </summary>
        [PropertyChineseName("SauceNAO 低相似度阈值", "搜图", "低于此相似度时不会发送缩略图")]
        public static int SearchSauceNAOLowSimilarity
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchSauceNAOLowSimilarity));
                if (int.TryParse(strValue, out int iValue)) return iValue;
                return 60;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchSauceNAOLowSimilarity), value.ToString());
        }

        /// <summary>
        /// 是否SauceNAO搜图发送Pixiv原图
        /// </summary>
        [PropertyChineseName("SauceNAO 搜图结果为 Pixiv 地址时发送原图", "搜图")]
        public static bool SearchSauceNAOSendPixivOriginalPicture
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchSauceNAOSendPixivOriginalPicture));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchSauceNAOSendPixivOriginalPicture), value.ToString());
        }

        /// <summary>
        /// SauceNAO 高相似度阈值
        /// </summary>
        [PropertyChineseName("SauceNAO 高相似度阈值", "搜图", "高于此相似度时不会使用ASCII2D搜索")]
        public static int SearchSauceNAOHighSimilarity
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchSauceNAOHighSimilarity));
                if (int.TryParse(strValue, out int iValue)) return iValue;
                return 90;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchSauceNAOHighSimilarity), value.ToString());
        }

        /// <summary>
        /// SauceNAO 相似度低于阈值返回消息
        /// </summary>
        [PropertyChineseName("SauceNAO 低于相似度阈值回复语", "搜图")]
        public static string SearchSauceNAOLowSimilarityReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchSauceNAOLowSimilarityReply)) ?? "相似度低于<SauceNAO 低相似度阈值>%，缩略图不予显示。";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchSauceNAOLowSimilarityReply), value);
        }

        #endregion -- SauceNAO --

        #region -- ASCII2D --

        /// <summary>
        /// 是否启用ASCII2D搜图
        /// </summary>
        [PropertyChineseName("启用 ASCII2D 搜索", "搜图")]
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
        /// 在Windows系统下时ASCII2D优先以浏览器进行请求(以应对近期403问题)
        /// </summary>
        [PropertyChineseName("ASCII2D 优先使用浏览器进行 Http 请求", "搜图")]
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
        /// ASCII2D显示结果数量
        /// </summary>
        [PropertyChineseName("ASCII2D 显示结果数量", "搜图")]
        public static int SearchShowASCII2DCount
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchShowASCII2DCount));
                if (int.TryParse(strValue, out int iValue)) return iValue;
                return 1;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchShowASCII2DCount), value.ToString());
        }

        #endregion -- ASCII2D --

        #region -- Iqdb --

        #region -- Iqdb anime--

        /// <summary>
        /// 是否启用Iqdb搜图
        /// </summary>
        [PropertyChineseName("启用 Iqdb 搜索", "搜图")]
        public static bool SearchEnabledIqdb
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchEnabledIqdb));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchEnabledIqdb), value.ToString());
        }

        #endregion -- Iqdb anime --

        #region -- 3dIqdb --

        /// <summary>
        /// 是否启用3dIqdb搜车
        /// </summary>
        [PropertyChineseName("启用 3d Iqdb 搜索", "搜图")]
        public static bool SearchEnabled3dIqdb
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchEnabled3dIqdb));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchEnabled3dIqdb), value.ToString());
        }

        #endregion -- 3dIqdb --

        /// <summary>
        /// Iqdb 是否发送标签
        /// </summary>
        [PropertyChineseName("Iqdb 是否发送标签", "搜图")]
        public static bool SearchIqdbSendTags
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchIqdbSendTags));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchIqdbSendTags), value.ToString());
        }

        /// <summary>
        /// Iqdb 只发送分级为安全的缩略图
        /// </summary>
        [PropertyChineseName("Iqdb 只发送分级为安全的缩略图", "搜图")]
        public static bool SearchIqdbMustSafe
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchIqdbMustSafe));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchIqdbMustSafe), value.ToString());
        }

        /// <summary>
        /// Iqdb 相似度阈值
        /// </summary>
        [PropertyChineseName("Iqdb 相似度阈值", "搜图")]
        public static int SearchIqdbSimilarity
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchIqdbSimilarity));
                if (int.TryParse(strValue, out int iValue)) return iValue;
                return 60;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchIqdbSimilarity), value.ToString());
        }

        /// <summary>
        /// Iqdb 相似度低于阈值返回消息
        /// </summary>
        [PropertyChineseName("Iqdb 低于相似度阈值回复语", "搜图")]
        public static string SearchIqdbSimilarityReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchIqdbSimilarityReply)) ?? "相似度低于<Iqdb 相似度阈值>%，缩略图不予显示。";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchIqdbSimilarityReply), value);
        }

        #endregion -- Iqdb --

        /// <summary>
        /// 开启连续搜图命令(正则表达式)
        /// </summary>
        [PropertyChineseName("开启连续搜图模式命令", "搜图")]
        public static string SearchModeOnCmd
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchModeOnCmd)) ?? "<机器人名称>搜[图圖図]";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchModeOnCmd), value);
        }
        
        /// <summary>
        /// 开启连续搜番命令(正则表达式)
        /// </summary>
        [PropertyChineseName("开启连续搜番模式命令", "搜图")]
        public static string SearchAnimeModeOnCmd
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchAnimeModeOnCmd)) ?? "<机器人名称>搜[图圖図]";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchAnimeModeOnCmd), value);
        }

        /// <summary>
        /// 开启连续搜车命令(正则表达式)
        /// </summary>
        [PropertyChineseName("开启连续搜车模式命令", "搜图")]
        public static string Search3DModeOnCmd
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(Search3DModeOnCmd)) ?? "<机器人名称>搜[车車]牌?";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(Search3DModeOnCmd), value);
        }

        /// <summary>
        /// 开启连续搜图功能返回消息
        /// </summary>
        [PropertyChineseName("进入连续搜图模式回复语", "搜图")]
        public static string SearchModeOnReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchModeOnReply)) ?? "了解～请发送图片吧！支持批量噢！\r\n如想退出搜索模式请发送“谢谢<机器人名称>”";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchModeOnReply), value);
        }

        /// <summary>
        /// 已在连续搜图模式下返回消息
        /// </summary>
        [PropertyChineseName("已进入连续搜图模式回复语", "搜图")]
        public static string SearchModeAlreadyOnReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchModeAlreadyOnReply)) ?? "您已经在搜图模式下啦！\r\n如想退出搜索模式请发送“谢谢<机器人名称>”";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchModeAlreadyOnReply), value);
        }

        /// <summary>
        /// 发起搜索时的回复语(正在搜索但未搜索完毕)
        /// </summary>
        [PropertyChineseName("正在搜索回复语", "搜图")]
        public static string SearchingReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchingReply)) ?? "";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchingReply), value);
        }

        /// <summary>
        /// 关闭连续搜图命令(正则表达式)
        /// </summary>
        [PropertyChineseName("退出连续搜图模式命令", "搜图")]
        public static string SearchModeOffCmd
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchModeOffCmd)) ?? "[谢謝][谢謝]<机器人名称>";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchModeOffCmd), value);
        }

        /// <summary>
        /// 连续搜图超时返回消息
        /// </summary>
        [PropertyChineseName("连续搜图模式超时回复语", "搜图")]
        public static string SearchModeTimeOutReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchModeTimeOutReply)) ?? "由于超时，已为您自动退出搜图模式，以后要记得说“谢谢<机器人名称>”来退出搜图模式噢";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchModeTimeOutReply), value);
        }

        /// <summary>
        /// 退出连续搜图功能返回消息
        /// </summary>
        [PropertyChineseName("退出连续搜图模式回复语", "搜图")]
        public static string SearchModeOffReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchModeOffReply)) ?? "不用谢!(<ゝω・)☆";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchModeOffReply), value);
        }

        /// <summary>
        /// 已经退出连续搜图功能返回消息
        /// </summary>
        [PropertyChineseName("已退出连续搜图模式回复语", "搜图")]
        public static string SearchModeAlreadyOffReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchModeAlreadyOffReply)) ?? "虽然不知道为什么谢我, 但是还请注意补充营养呢(｀・ω・´)";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchModeAlreadyOffReply), value);
        }

        /// <summary>
        /// 没有搜索到结果返回消息
        /// </summary>
        [PropertyChineseName("没有搜索到地址回复语", "搜图")]
        public static string SearchNoResultReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchNoResultReply)) ?? "<搜索类型>没有搜到该图片的地址o(╥﹏╥)o";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchNoResultReply), value);
        }

        /// <summary>
        /// 搜索过程中发生异常返回消息
        /// </summary>
        [PropertyChineseName("搜索错误回复语", "搜图")]
        public static string SearchErrorReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchErrorReply)) ?? "<搜索类型>搜索失败_(:3」∠)_";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchErrorReply), value);
        }

        /// <summary>
        /// 下载缩略图失败时追加回复
        /// </summary>
        [PropertyChineseName("下载缩略图失败时追加回复", "搜图")]
        public static string SearchDownloadThuImageFailReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchDownloadThuImageFailReply)) ?? "缩略图下载失败。";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchDownloadThuImageFailReply), value);
        }

        /// <summary>
        /// 搜图结果以合并转发的方式发送
        /// </summary>
        [PropertyChineseName("搜图结果以合并转发的方式发送", "搜图")]
        public static bool SearchSendByForward
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchSendByForward));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchSendByForward), value.ToString());
        }

        /// <summary>
        /// 是否在搜图功能上启用鉴黄
        /// </summary>
        [PropertyChineseName("搜图 启用鉴黄", "搜图")]
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
        /// 搜图功能鉴黄不通过返回消息
        /// </summary>
        [PropertyChineseName("搜图 鉴黄不通过回复语", "搜图")]
        public static string SearchCheckPornIllegalReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchCheckPornIllegalReply)) ?? "AI鉴黄不通过，缩略图不予显示。";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchCheckPornIllegalReply), value);
        }

        /// <summary>
        /// 搜图功能鉴黄发生异常返回消息
        /// </summary>
        [PropertyChineseName("搜图 鉴黄错误回复语", "搜图")]
        public static string SearchCheckPornErrorReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchCheckPornErrorReply)) ?? "AI鉴黄发生错误，缩略图不予显示。<错误信息>";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(SearchCheckPornErrorReply), value);
        }

        #endregion -- 搜图属性 --

        #region -- 下载原图属性 --
        /// <summary>
        /// 是否启用下载原图
        /// </summary>
        [PropertyChineseName("启用按ID下载Pixiv原图功能", "搜图")]
        public static bool OriginalPictureEnabled
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(OriginalPictureEnabled));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(OriginalPictureEnabled), value.ToString());
        }

        /// <summary>
        /// 是否在下载原图功能上启用鉴黄
        /// </summary>
        [PropertyChineseName("下载原图 启用鉴黄", "搜图")]
        public static bool OriginalPictureCheckPornEnabled
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(OriginalPictureCheckPornEnabled));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(OriginalPictureCheckPornEnabled), value.ToString());
        }

        /// <summary>
        /// 下载原图功能上鉴黄不通过时做以下动作: 0.以合并转发的方式发送原图 1.不做任何事 2.回复设置的语句
        /// </summary>
        [PropertyChineseName("下载原图 鉴黄不通过时", "搜图", "0 = 以合并转发的方式发送原图 1 = 不做任何事 2 = 回复设置的语句")]
        public static int OriginalPictureCheckPornEvent
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(OriginalPictureCheckPornEvent));
                if (int.TryParse(strValue, out int iValue)) return iValue;
                return 87;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(OriginalPictureCheckPornEvent), value.ToString());
        }

        /// <summary>
        /// 下载原图功能鉴黄不通过返回消息
        /// </summary>
        [PropertyChineseName("下载原图 鉴黄不通过回复语", "搜图")]
        public static string OriginalPictureCheckPornIllegalReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(OriginalPictureCheckPornIllegalReply)) ?? "AI鉴黄不通过。";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(OriginalPictureCheckPornIllegalReply), value);
        }

        /// <summary>
        /// 下载原图功能鉴黄错误返回消息
        /// </summary>
        [PropertyChineseName("下载原图 鉴黄错误回复语", "搜图")]
        public static string OriginalPictureCheckPornErrorReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(OriginalPictureCheckPornErrorReply)) ?? "AI鉴黄发生错误。<错误信息>";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePictureSearcher, nameof(OriginalPictureCheckPornErrorReply), value);
        }
        #endregion  -- 下载原图属性 --

        #region -- 翻译属性 --

        /// <summary>
        /// 是否启用翻译功能
        /// </summary>
        [PropertyChineseName("启用翻译功能", "翻译")]
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

        /// <summary>
        /// 翻译引擎
        /// </summary>
        [PropertyChineseName("翻译引擎", "翻译", "0 = 谷歌, 1 = 有道")]
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
        [PropertyChineseName("翻译引擎", "翻译", "0 = 谷歌, 1 = 有道")]
        public static string TranslateToChineseCMD
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTranslate, nameof(TranslateToChineseCMD)) ?? "<机器人名称>翻[译譯][:：]";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTranslate, nameof(TranslateToChineseCMD), value);
        }

        /// <summary>
        /// 翻译为指定语言命令(正则表达式)
        /// </summary>
        [PropertyChineseName("翻译为指定语言命令", "翻译", "支持正则表达式")]
        public static string TranslateToCMD
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTranslate, nameof(TranslateToCMD)) ?? "<机器人名称>翻[译譯][成为為到至](.+[语語文])[:：]";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTranslate, nameof(TranslateToCMD), value);
        }

        /// <summary>
        /// 从指定语言翻译为指定语言命令(正则表达式)
        /// </summary>
        [PropertyChineseName("翻译为指定语言命令", "翻译", "支持正则表达式, 使用有道翻译时该属性没有作用")]
        public static string TranslateFromToCMD
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTranslate, nameof(TranslateFromToCMD)) ?? "<机器人名称>[把从從自从](?<from>.+[语語文])翻[译譯][成为為到至](?<to>.+[语語文])[:：]";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTranslate, nameof(TranslateFromToCMD), value);
        }

        /// <summary>
        /// 从指定语言翻译为指定语言命令(从指定语言翻译为指定语言命令)
        /// </summary>
        [PropertyChineseName("从指定语言翻译为指定语言命令", "翻译", "支持正则表达式")]
        public static List<long> AutoTranslateGroupMemoriesQQ
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTranslate, nameof(AutoTranslateGroupMemoriesQQ));
                if (string.IsNullOrEmpty(strValue))
                    return new List<long>();
                return strValue.Split(';').Select(long.Parse).ToList();

            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTranslate, nameof(AutoTranslateGroupMemoriesQQ), string.Join(";", value));
        }

        #endregion -- 翻译属性 --

        #region -- 色图属性 --

        public const string DefaultHPictureCmd = "(?<前缀><机器人名称>[我再]?[要来來发發给給])(?<数量>[0-9零一壹二两贰兩三叁四肆五伍六陆陸七柒八捌九玖十拾百佰千仟万萬亿億]+)?(?<单位>[张張个個幅份])(?<r18>[Rr]-?18)?的?(?<关键词>.+)?的?((?<色图后缀>[色瑟涩铯啬渋][图圖図])|(?<美图后缀>[美][图圖図]))";

        /// <summary>
        /// 色图/美图完整命令(正则表达式)
        /// </summary>
        [PropertyChineseName("色图/美图命令", "色图", "支持正则表达式")]
        public static string HPictureCmd
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureCmd)) ?? DefaultHPictureCmd;
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureCmd), value);
        }

        /// <summary>
        /// 是否撤回美图(撤回时间跟随色图撤回时间设置)
        /// </summary>
        [PropertyChineseName("撤回美图", "色图")]
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
        /// 启用的美图图库
        /// </summary>
        [PropertyChineseName("美图图库", "色图", "启用的美图图库, 1 = ELF图库")]
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
        /// 启用的色图图库
        /// </summary>
        [PropertyChineseName("色图图库", "色图", "启用的色图图库, 0 = Lolicon图库, 3 = yande.re")]
        public static List<PictureSource> EnabledHPictureSource
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(EnabledHPictureSource));
                if (string.IsNullOrEmpty(strValue))
                    return new List<PictureSource>() { 0 };
                return strValue.Split(';').Select(s => (PictureSource)Enum.Parse(typeof(PictureSource), s)).ToList();
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(EnabledHPictureSource), string.Join(";", value));
        }

        /// <summary>
        /// 自定义色图命令
        /// </summary>
        [PropertyChineseName("自定义色图命令", "色图")]
        public static List<string> HPictureUserCmd
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureUserCmd));
                if (string.IsNullOrEmpty(strValue))
                    return new List<string>() { "--setu" };
                return strValue.Split(';').ToList();
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureUserCmd), string.Join(";", value));
        }

        /// <summary>
        /// 白名单群
        /// </summary>
        [PropertyChineseName("色图 白名单群", "色图")]
        public static List<long> HPictureWhiteGroup
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureWhiteGroup));
                if (string.IsNullOrEmpty(strValue))
                    return new List<long>();
                return strValue.Split(';').Select(long.Parse).ToList();
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureWhiteGroup), string.Join(";", value));
        }

        /// <summary>
        /// 是否仅限白名单使用色图
        /// </summary>
        [PropertyChineseName("色图 仅限白名单", "色图")]
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
        [PropertyChineseName("色图 允许R-18", "色图")]
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
        [PropertyChineseName("色图 R-18仅限白名单", "色图")]
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
        [PropertyChineseName("色图 允许私聊", "色图")]
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
        /// 1200像素模式
        /// </summary>
        [PropertyChineseName("色图 1200像素模式", "色图")]
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
        [PropertyChineseName("色图 群冷却时间", "色图", "s")]
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
        [PropertyChineseName("色图 群次数限制", "色图")]
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
        [PropertyChineseName("色图 群撤回时间", "色图", "s")]
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
        [PropertyChineseName("色图 白名单群冷却时间", "色图", "s")]
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
        [PropertyChineseName("色图 白名单群撤回时间", "色图", "s")]
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
        [PropertyChineseName("色图 私聊冷却时间", "色图", "s")]
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
        [PropertyChineseName("色图 私聊撤回时间", "色图", "s")]
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
        [PropertyChineseName("色图 机器人管理员无限制", "色图")]
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
        /// 私聊无冷却时间/次数限制
        /// </summary>
        [PropertyChineseName("色图 私聊无限制", "色图")]
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
        [PropertyChineseName("色图 白名单群无限制", "色图")]
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
        /// 色图是否发送地址
        /// </summary>
        [PropertyChineseName("色图 发送地址", "色图")]
        public static bool HPictureSendUrl
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureSendUrl));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureSendUrl), value.ToString());
        }

        /// <summary>
        /// 色图是否发送标签
        /// </summary>
        [PropertyChineseName("色图 发送标签", "色图")]
        public static bool HPictureSendTags
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureSendTags));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureSendTags), value.ToString());
        }

        /// <summary>
        /// 是否以合并转发的方式发送色图
        /// </summary>
        [PropertyChineseName("色图 以合并转发的方式发送", "色图")]
        public static bool HPictureSendByForward
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureSendByForward));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureSendByForward), value.ToString());
        }

        /// <summary>
        /// 冷却中回复
        /// </summary>
        [PropertyChineseName("色图 冷却时间内回复语", "色图")]
        public static string HPictureCDUnreadyReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureCDUnreadyReply)) ?? "乖，要懂得节制哦，休息一会再冲吧 →_→";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureCDUnreadyReply), value);
        }

        /// <summary>
        /// 次数用尽回复
        /// </summary>
        [PropertyChineseName("色图 超过次数回复语", "色图")]
        public static string HPictureOutOfLimitReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureOutOfLimitReply)) ?? "今天不要再冲了啦(>_<)";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureOutOfLimitReply), value);
        }

        /// <summary>
        /// 发生错误回复
        /// </summary>
        [PropertyChineseName("色图 发生错误回复语", "色图")]
        public static string HPictureErrorReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureErrorReply)) ?? "色图服务器爆炸惹_(:3」∠)_";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureErrorReply), value);
        }

        /// <summary>
        /// 没有结果回复
        /// </summary>
        [PropertyChineseName("色图 没有结果回复语", "色图")]
        public static string HPictureNoResultReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureNoResultReply)) ?? "没有找到符合条件的图ㄟ( ▔, ▔ )ㄏ";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureNoResultReply), value);
        }

        /// <summary>
        /// 下载失败回复
        /// </summary>
        [PropertyChineseName("色图 图片下载失败回复语", "色图")]
        public static string HPictureDownloadFailReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureDownloadFailReply)) ?? "地址为:<URL>的色图不见了，可能是色图服务器下载失败或图真的没了o(╥﹏╥)o (如连续出现时请检查<机器人名称>网络/代理/墙问题。)";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameHPicture, nameof(HPictureDownloadFailReply), value);
        }

        /// <summary>
        /// 色图次数限制记录类型
        /// </summary>
        [PropertyChineseName("色图 次数限制记录类型", "色图", "0 = 记次, 1 = 记张")]
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
        /// 一条色图命令最多允许返回多少张色图
        /// </summary>
        [PropertyChineseName("色图 单次请求最大图片数量", "色图", "支持1-100, 不建议超过10, 容易导致无法撤回")]
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
        [PropertyChineseName("启用色图功能", "色图")]
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
        [PropertyChineseName("随机复读", "复读")]
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
        [PropertyChineseName("随机复读 概率为", "复读", "%")]
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
        [PropertyChineseName("连续复读", "复读")]
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
        [PropertyChineseName("连续复读 次数为", "复读")]
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
        [PropertyChineseName("倒放Gif", "复读")]
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
        [PropertyChineseName("倒放Gif 概率为", "复读", "%")]
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
        /// 
        /// <summary>
        /// 是否水平反转复读图片
        /// </summary>
        [PropertyChineseName("水平镜像复读图片", "复读")]
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
        [PropertyChineseName("水平镜像复读图片 概率为", "复读", "%")]
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
        [PropertyChineseName("垂直镜像复读图片", "复读")]
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
        [PropertyChineseName("垂直镜像复读图片 概率为", "复读", "%")]
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
        [PropertyChineseName("复读时把\"我\"替换为\"你\"", "复读")]
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
        [PropertyChineseName("发送新人入群消息", "进/退群提醒")]
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
        [PropertyChineseName("发送群员退群消息", "进/退群提醒")]
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
        [PropertyChineseName("发送群员被踢消息", "进/退群提醒")]
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
        [PropertyChineseName("新人入群消息", "进/退群提醒")]
        public static string MemberJoinedMessage
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameGroupMemberEvent, nameof(MemberJoinedMessage)) ?? "<@成员QQ> 欢迎新大佬，群地位-1 (ΩДΩ)";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameGroupMemberEvent, nameof(MemberJoinedMessage), value);
        }

        /// <summary>
        /// 成员退群消息
        /// </summary>
        [PropertyChineseName("群员退群消息", "进/退群提醒")]
        public static string MemberPositiveLeaveMessage
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameGroupMemberEvent, nameof(MemberPositiveLeaveMessage)) ?? "QQ号：<成员QQ> 退出了群，群地位+1 o(╥﹏╥)o";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameGroupMemberEvent, nameof(MemberPositiveLeaveMessage), value);
        }

        /// <summary>
        /// 成员被踢消息
        /// </summary>
        [PropertyChineseName("群员被踢消息", "进/退群提醒")]
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
        [PropertyChineseName("启用伪造消息功能", "伪造消息")]
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
        [PropertyChineseName("伪造消息命令前缀", "伪造消息")]
        public static string ForgeMessageCmdBegin
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameForgeMessage, nameof(ForgeMessageCmdBegin)) ?? "<机器人名称>伪造(消息|聊天[记記][录錄])";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameForgeMessage, nameof(ForgeMessageCmdBegin), value);
        }

        /// <summary>
        /// 伪造消息分行符(分行符前后的内容会分成两条消息)
        /// </summary>
        [PropertyChineseName("伪造消息分行符", "伪造消息")]
        public static string ForgeMessageCmdNewLine
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameForgeMessage, nameof(ForgeMessageCmdNewLine)) ?? @"\r\n";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameForgeMessage, nameof(ForgeMessageCmdNewLine), value);
        }

        /// <summary>
        /// 是否在伪造消息末端追加消息
        /// </summary>
        [PropertyChineseName("伪造消息 在消息末尾追加机器人消息", "伪造消息")]
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
        [PropertyChineseName("伪造消息 仅限机器人管理员可用", "伪造消息")]
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
        [PropertyChineseName("伪造消息 机器人管理员使用时不追加消息", "伪造消息")]
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
        [PropertyChineseName("伪造消息 追加消息内容", "伪造消息")]
        public static string ForgeMessageAppendMessage
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameForgeMessage, nameof(ForgeMessageAppendMessage)) ?? "此消息为<机器人名称>伪造，仅作娱乐，请勿用于非法用途。";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameForgeMessage, nameof(ForgeMessageAppendMessage), value);
        }

        /// <summary>
        /// 是否拒绝伪造机器人管理员的消息
        /// </summary>
        [PropertyChineseName("伪造消息 拒绝伪造机器人管理员的消息", "伪造消息")]
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
        [PropertyChineseName("伪造消息 试图伪造机器人管理员消息时的回复语", "伪造消息")]
        public static string RefuseForgeAdminReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameForgeMessage, nameof(RefuseForgeAdminReply)) ?? "你不能让我伪造我主人的消息。";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameForgeMessage, nameof(RefuseForgeAdminReply), value);
        }

        /// <summary>
        /// 是否拒绝伪造机器人的消息(如果由机器人管理员发起则不会校验此项目)
        /// </summary>
        [PropertyChineseName("伪造消息 拒绝伪造机器人的消息", "伪造消息")]
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
        [PropertyChineseName("伪造消息 试图伪造机器人消息时的回复语", "伪造消息")]
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
        [PropertyChineseName("启用RSS订阅转发", "RSS订阅转发")]
        public static bool RssEnabled
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameRss, nameof(RssEnabled));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameRss, nameof(RssEnabled), value.ToString());
        }

        /// <summary>
        /// 抓取RSS间隔时间(分钟)
        /// </summary>
        [PropertyChineseName("获取内容时间间隔", "RSS订阅转发", "分钟")]
        public static double ReadRssInterval
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameRss, nameof(ReadRssInterval));
                if (double.TryParse(strValue, out double iValue)) return iValue;
                return 10.0;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameRss, nameof(ReadRssInterval), value.ToString());
        }

        /// <summary>
        /// 多线程并行抓取多个RSS订阅
        /// </summary>
        [PropertyChineseName("每条订阅各占用一个线程", "RSS订阅转发")]
        public static bool RssParallel
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameRss, nameof(RssParallel));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameRss, nameof(RssParallel), value.ToString());
        }

        /// <summary>
        /// 订阅的地址和需要转发到的QQ或群列表
        /// </summary>
        [PropertyChineseName("RSS订阅项", "RSS订阅转发")]
        public static List<RssSubscriptionItem> RssSubscription
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameRss, nameof(RssSubscription));
                if (strValue == null) return null;
                return JsonConvert.DeserializeObject<List<RssSubscriptionItem>>(strValue);
            }
            set
            {
                JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameRss, nameof(RssSubscription), JsonConvert.SerializeObject(value));
            }
        }

        /// <summary>
        /// 获取B站直播封面
        /// </summary>
        [PropertyChineseName("获取B站直播间封面", "RSS订阅转发")]
        public static bool RssSendLiveCover
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameRss, nameof(RssSendLiveCover));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameRss, nameof(RssSendLiveCover), value.ToString());
        }

        #endregion -- RSS属性 --

        #region -- 井字棋属性 --
        /// <summary>
        /// 是否启用井字棋功能
        /// </summary>
        public static bool TicTacToeEnabled
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTicTacToe, nameof(TicTacToeEnabled));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTicTacToe, nameof(TicTacToeEnabled), value.ToString());
        }

        /// <summary>
        /// 开启一局新的井字棋对局命令
        /// </summary>
        public static string StartTicTacToeCmd
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTicTacToe, nameof(StartTicTacToeCmd)) ?? "<机器人名称>井字棋";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTicTacToe, nameof(StartTicTacToeCmd), value);
        }

        /// <summary>
        /// 开启井字棋对局成功回复语
        /// </summary>
        public static string TicTacToeStartedReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTicTacToe, nameof(TicTacToeStartedReply)) ?? "成功开启棋局，玩家为×，<机器人名称>为○，请对棋盘图片用QQ表情涂鸦或输入格号进行下子，您先下。";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTicTacToe, nameof(TicTacToeStartedReply), value);
        }

        /// <summary>
        /// 已经开始后再次尝试开启对局的回复语
        /// </summary>
        public static string TicTacToeAlreadyStartReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTicTacToe, nameof(TicTacToeAlreadyStartReply)) ?? "您已经在棋局中啦，请不要重复开启棋局。";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTicTacToe, nameof(TicTacToeAlreadyStartReply), value);
        }

        /// <summary>
        /// 中止一场对局命令
        /// </summary>
        public static string StopTicTacToeCmd
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTicTacToe, nameof(StopTicTacToeCmd)) ?? "<机器人名称>不玩啦";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTicTacToe, nameof(StopTicTacToeCmd), value);
        }

        /// <summary>
        /// 中止对局成功回复语
        /// </summary>
        public static string TicTacToeStoppedReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTicTacToe, nameof(TicTacToeStoppedReply)) ?? "下次再玩哦~";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTicTacToe, nameof(TicTacToeStoppedReply), value);
        }

        /// <summary>
        /// 未在对局中时尝试中止对局回复语
        /// </summary>
        public static string TicTacToeAlreadStopReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTicTacToe, nameof(TicTacToeAlreadStopReply)) ?? "您现在什么也没有和我玩耶QAQ";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTicTacToe, nameof(TicTacToeAlreadStopReply), value);
        }

        /// <summary>
        /// 对局超时回复语
        /// </summary>
        public static string TicTacToeTimeoutReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTicTacToe, nameof(TicTacToeTimeoutReply)) ?? "由于超时，已为您自动退出棋局，下次请说：\"<机器人名称>不玩啦\"来临阵脱逃哦。";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTicTacToe, nameof(TicTacToeTimeoutReply), value);
        }

        /// <summary>
        /// 玩家获胜回复语
        /// </summary>
        public static string TicTacToePlayerWinReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTicTacToe, nameof(TicTacToePlayerWinReply)) ?? "您赢了，这个<机器人名称>就是逊啦";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTicTacToe, nameof(TicTacToePlayerWinReply), value);
        }

        /// <summary>
        /// 机器人获胜回复语
        /// </summary>
        public static string TicTacToeBotWinReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTicTacToe, nameof(TicTacToeBotWinReply)) ?? "<机器人名称>赢了，现在知道谁是老大了ho~";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTicTacToe, nameof(TicTacToeBotWinReply), value);
        }

        /// <summary>
        /// 平局回复语
        /// </summary>
        public static string TicTacToeDrawReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTicTacToe, nameof(TicTacToeDrawReply)) ?? "平局了，再来一局吧~";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTicTacToe, nameof(TicTacToeDrawReply), value);
        }

        /// <summary>
        /// 没有识别到玩家下子回复语
        /// </summary>
        public static string TicTacToeNoMoveReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTicTacToe, nameof(TicTacToeNoMoveReply)) ?? "<机器人名称>没看到您下子，请把想要下子的格子涂黑下子。";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTicTacToe, nameof(TicTacToeNoMoveReply), value);
        }

        /// <summary>
        /// 玩家下子在已有棋子的格子上回复语
        /// </summary>
        public static string TicTacToeMoveFailReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTicTacToe, nameof(TicTacToeMoveFailReply)) ?? "您不能在已经有棋子的地方下子啦，重新下一次吧。";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTicTacToe, nameof(TicTacToeMoveFailReply), value);
        }

        /// <summary>
        /// 玩家下子不止一格回复语
        /// </summary>
        public static string TicTacToeIllegalMoveReply
        {
            get => JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTicTacToe, nameof(TicTacToeIllegalMoveReply)) ?? "您把整个棋盘都下满了这让<机器人名称>也很难办啊，重新下一次吧。";
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTicTacToe, nameof(TicTacToeIllegalMoveReply), value);
        }

        /// <summary>
        /// 启用的下子模式
        /// </summary>
        public static int TicTacToeMoveMode
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTicTacToe, nameof(TicTacToeMoveMode));
                if (int.TryParse(strValue, out int iValue)) return iValue;
                return 6;
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNameTicTacToe, nameof(TicTacToeMoveMode), value.ToString());
        }

        #endregion -- 井字棋属性 --

        #region -- 插件属性 --
        public static List<string> PluginOrder
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePlugin, nameof(PluginOrder));
                if (string.IsNullOrEmpty(strValue))
                    return new List<string>();
                return strValue.Split(';').ToList();
            }
            set => JsonHelper.SetSerializationValue(JsonHelper.JsonConfigFileName, JsonHelper.JsonNodeNamePlugin, nameof(PluginOrder), string.Join(";", value));
        }

        #endregion -- 插件属性 --
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
        Yande_re = 1,
    }

    public enum TranslateEngine
    {
        Google = 0,
        YouDao = 1,
    }

    public enum TicTacToeMoveMode : int
    {
        OpenCV = 2,
        Nomenclature = 4,
    }

    public enum SearchMode : int
    {
        Picture = 1,
        Anime = 2,
        ThreeD = 4,
    }
}