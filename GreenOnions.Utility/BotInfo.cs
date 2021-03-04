using GreenOnions.Utility.Helper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GreenOnions.Utility
{
    public static class BotInfo
    {
        public const string JsonNodeNameBot = "Bot";
        public const string JsonNodeNamePictureSearcher = "PictureSearcher";
        public const string JsonNodeNameHPicture = "HPicture";
        public const string JsonNodeNameTranslate = "Translate";

        #region -- 公共属性 --
        [PropertyChineseName("机器人QQ号")]
        public static long QQId
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameBot, nameof(QQId));
                if (long.TryParse(strValue, out long iValue)) return iValue;
                return iValue;
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameBot, nameof(QQId), value.ToString());
        }

        public static string IP
        {
            get => JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameBot, nameof(IP)) ?? "127.0.0.1";
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameBot, nameof(IP), value);
        }

        public static string Port
        {
            get => JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameBot, nameof(Port)) ?? "33111";
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameBot, nameof(Port), value);
        }

        public static string AutoKey
        {
            get => JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameBot, nameof(AutoKey));
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameBot, nameof(AutoKey), value);
        }

        /// <summary>
        /// 机器人名称
        /// </summary>
        [PropertyChineseName("机器人名称")]
        public static string BotName
        {
            get => JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameBot, nameof(BotName)) ?? "葱葱";
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameBot, nameof(BotName), value);
        }

        /// <summary>
        /// 机器人管理员QQ
        /// </summary>
        public static IEnumerable<long> AdminQQ
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameBot, nameof(AdminQQ));
                if (string.IsNullOrEmpty(strValue))
                {
                    return new List<long>();
                }
                return strValue.Split(';').Select(long.Parse);
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameBot, nameof(AdminQQ), string.Join(";", value));
        }

        /// <summary>
        /// 是否启用图片缓存
        /// </summary>
        public static bool ImageCache
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameBot, nameof(ImageCache));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameBot, nameof(ImageCache), value.ToString());
        }

        /// <summary>
        /// 黑名单组
        /// </summary>
        public static IEnumerable<long> BannedGroup
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameBot, nameof(BannedGroup));
                if (string.IsNullOrEmpty(strValue))
                {
                    return new List<long>();
                }
                return strValue.Split(';').Select(long.Parse);

            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameBot, nameof(BannedGroup), string.Join(";", value));
        }

        /// <summary>
        /// 黑名单用户
        /// </summary>
        public static IEnumerable<long> BannedUser
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameBot, nameof(BannedUser));
                if (string.IsNullOrEmpty(strValue))
                {
                    return new List<long>();
                }
                return strValue.Split(';').Select(long.Parse);
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameBot, nameof(BannedUser), string.Join(";", value));
        }

        /// <summary>
        /// 是否启用加速链
        /// </summary>
        public static bool EnabledAccelerate
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameBot, nameof(EnabledAccelerate));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameBot, nameof(EnabledAccelerate), value.ToString());
        }

        /// <summary>
        /// 加速链地址
        /// </summary>
        public static string AccelerateUrl
        {
            get => JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameBot, nameof(AccelerateUrl));
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameBot, nameof(AccelerateUrl), value);
        }

        /// <summary>
        /// 是否启用调试模式
        /// </summary>
        public static bool DebugMode
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameBot, nameof(DebugMode));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameBot, nameof(DebugMode), value.ToString());
        }

        /// <summary>
        /// 调试组
        /// </summary>
        public static IEnumerable<long> DebugGroups
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameBot, nameof(DebugGroups));
                if (string.IsNullOrEmpty(strValue))
                {
                    return new List<long>();
                }
                return strValue.Split(';').Select(long.Parse);

            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameBot, nameof(DebugGroups), string.Join(";", value));
        }

        /// <summary>
        /// 是否启用调试模式
        /// </summary>
        public static bool OnlyReplyDebugGroup
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameBot, nameof(OnlyReplyDebugGroup));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameBot, nameof(OnlyReplyDebugGroup), value.ToString());
        }

        /// <summary>
        /// 是否启用调试模式
        /// </summary>
        public static bool DebugReplyAdminOnly
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameBot, nameof(DebugReplyAdminOnly));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameBot, nameof(DebugReplyAdminOnly), value.ToString());
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
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(SearchEnabled));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(SearchEnabled), value.ToString());
        }

        /// <summary>
        /// 是否启用SauceNao搜图
        /// </summary>
        public static bool SearchEnabledSauceNao
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(SearchEnabledSauceNao));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(SearchEnabledSauceNao), value.ToString());
        }

        /// <summary>
        /// SauceNao Api-Key
        /// </summary>
        public static string SauceNAOApiKey
        {
            get => JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(SauceNAOApiKey));
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(SauceNAOApiKey), value);
        }

        /// <summary>
        /// 是否启用ASCII2D搜图
        /// </summary>
        public static bool SearchEnabledASCII2D
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(SearchEnabledASCII2D));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(SearchEnabledASCII2D), value.ToString());
        }

        /// <summary>
        /// 开启连续搜图命令(正则表达式)
        /// </summary>
        public static string SearchModeOnCmd
        {
            get => JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(SearchModeOnCmd)) ?? "<机器人名称>搜[图圖]";
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(SearchModeOnCmd), value);
        }

        /// <summary>
        /// 关闭连续搜图命令(正则表达式)
        /// </summary>
        public static string SearchModeOffCmd
        {
            get => JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(SearchModeOffCmd)) ?? "[谢謝][谢謝]<机器人名称>";
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(SearchModeOffCmd), value);
        }

        /// <summary>
        /// 连续搜图超时返回消息
        /// </summary>
        public static string SearchModeTimeOutReply
        {
            get => JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(SearchModeTimeOutReply)) ?? "由于超时，已为您自动退出搜图模式，以后要记得说“谢谢<机器人名称>”来退出搜图模式噢";
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(SearchModeTimeOutReply), value);
        }

        /// <summary>
        /// 开启连续搜图功能返回消息
        /// </summary>
        public static string SearchModeOnReply
        {
            get => JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(SearchModeOnReply)) ?? "了解～请发送图片吧！支持批量噢！\r\n如想退出搜索模式请发送“谢谢<机器人名称>”";
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(SearchModeOnReply), value);
        }

        /// <summary>
        /// 已在连续搜图模式下返回消息
        /// </summary>
        public static string SearchModeAlreadyOnReply
        {
            get => JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(SearchModeAlreadyOnReply)) ?? "您已经在搜图模式下啦！\r\n如想退出搜索模式请发送“谢谢<机器人名称>”";
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(SearchModeAlreadyOnReply), value);
        }

        /// <summary>
        /// 关闭连续搜图功能返回消息
        /// </summary>
        public static string SearchModeOffReply
        {
            get => JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(SearchModeOffReply)) ?? "不用谢!(<ゝω・)☆";
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(SearchModeOffReply), value);
        }

        /// <summary>
        /// 已经关闭连续搜图功能返回消息
        /// </summary>
        public static string SearchModeAlreadyOffReply
        {
            get => JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(SearchModeAlreadyOffReply)) ?? "虽然不知道为什么谢我, 但是还请注意补充营养呢(｀・ω・´)";
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(SearchModeAlreadyOffReply), value);
        }

        /// <summary>
        /// 没有搜索到结果返回消息
        /// </summary>
        public static string SearchNoResultReply
        {
            get => JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(SearchNoResultReply)) ?? "<搜索类型>没有搜到该图片o(╥﹏╥)o";
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(SearchNoResultReply), value);
        }

        /// <summary>
        /// 搜索过程中发生异常返回消息
        /// </summary>
        public static string SearchErrorReply
        {
            get => JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(SearchErrorReply)) ?? "搜图服务器爆炸惹_(:3」∠)_";
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(SearchErrorReply), value);
        }

        /// <summary>
        /// 相似度阈值
        /// </summary>
        [PropertyChineseName("相似度阈值")]
        public static int SearchLowSimilarity
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(SearchLowSimilarity));
                if (int.TryParse(strValue, out int iValue)) return iValue;
                return 50;
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(SearchLowSimilarity), value.ToString());
        }

        /// <summary>
        /// 相似度低于阈值返回消息
        /// </summary>
        public static string SearchLowSimilarityReply
        {
            get => JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(SearchLowSimilarityReply)) ?? "相似度低于<相似度阈值>%，缩略图不予显示。";
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(SearchLowSimilarityReply), value);
        }

        /// <summary>
        /// 是否启用腾讯云AI鉴黄
        /// </summary>
        public static bool SearchCheckPornEnabled
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(SearchCheckPornEnabled));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(SearchCheckPornEnabled), value.ToString());
        }

        /// <summary>
        /// 鉴黄不通过返回消息
        /// </summary>
        public static string SearchCheckPornIllegalReply
        {
            get => JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(SearchCheckPornIllegalReply)) ?? "AI鉴黄不通过，缩略图不予显示。";
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(SearchCheckPornIllegalReply), value);
        }

        /// <summary>
        /// 鉴黄发生异常返回消息
        /// </summary>
        public static string SearchCheckPornErrorReply
        {
            get => JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(SearchCheckPornErrorReply)) ?? "AI鉴黄发生错误，缩略图不予显示。<错误信息>";
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(SearchCheckPornErrorReply), value);
        }

        #region -- 腾讯云相关属性 --
        /// <summary>
        /// 腾讯云APPID
        /// </summary>
        public static string TencentCloudAPPID
        {
            get => JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(TencentCloudAPPID));
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(TencentCloudAPPID), value);
        }

        /// <summary>
        /// 腾讯云CloudRegion
        /// </summary>
        public static string TencentCloudRegion
        {
            get => JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(TencentCloudRegion));
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(TencentCloudRegion), value);
        }

        /// <summary>
        /// 腾讯云SecretId
        /// </summary>
        public static string TencentCloudSecretId
        {
            get => JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(TencentCloudSecretId));
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(TencentCloudSecretId), value);
        }

        /// <summary>
        /// 腾讯云SecretKey
        /// </summary>
        public static string TencentCloudSecretKey
        {
            get => JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(TencentCloudSecretKey));
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(TencentCloudSecretKey), value);
        }

        /// <summary>
        /// 腾讯云桶名称
        /// </summary>
        public static string TencentCloudBucket
        {
            get => JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(TencentCloudBucket));
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNamePictureSearcher, nameof(TencentCloudBucket), value);
        }
        #endregion -- 腾讯云相关属性 --

        #endregion -- 搜图属性 --

        #region -- 翻译属性 --

        /// <summary>
        /// 是否启用翻译功能
        /// </summary>
        public static bool TranslateEnabled
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameTranslate, nameof(TranslateEnabled));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameTranslate, nameof(TranslateEnabled), value.ToString());
        }

        /// <summary>
        /// 翻译为中文命令(正则表达式)
        /// </summary>
        public static string TranslateToChineseCMD
        {
            get => JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameTranslate, nameof(TranslateToChineseCMD)) ?? "<机器人名称>翻译[:：]";
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameTranslate, nameof(TranslateToChineseCMD), value);
        }

        /// <summary>
        /// 翻译为指定语言命令(正则表达式)
        /// </summary>
        public static string TranslateToCMD
        {
            get => JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameTranslate, nameof(TranslateToCMD)) ?? "<机器人名称>翻译[成为到](.+[语文])[:：]";
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameTranslate, nameof(TranslateToCMD), value);
        }

        #endregion -- 翻译属性 --

        #region -- 色图属性 --
        public static string HPictureApiKey
        {
            get => JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureApiKey));
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureApiKey), value);
        }

        /// <summary>
        /// Lolicon图库色图完整命令(正则表达式)
        /// </summary>
        public static string HPictureCmd
        {
            get => GetLoliconHPictureCmd();
        }
        
        /// <summary>
        /// Shab图库色图完整命令(正则表达式)
        /// </summary>
        public static string ShabHPictureCmd
        {
            get => GetShabHPictureCmd();
        }

        private static string GetLoliconHPictureCmd()
        {
            string LoliconEnd = HPictureEndCmd;
            if (HPictureEndCmdNull)
            {
                LoliconEnd = $"({LoliconEnd})?";
            }

            return $"^<机器人名称>{GetHPictureCmdInner()}{LoliconEnd}$";
        }

        private static string GetShabHPictureCmd()
        {
            string ShabEnd = ShabHPictureEndCmd;
            if (ShabHPictureEndCmdNull)
            {
                ShabEnd = $"({ShabEnd})?";
            }

            return $"^<机器人名称>{GetHPictureCmdInner()}{ShabEnd}$";
        }

        private static string GetHPictureCmdInner() 
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
            get => JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureBeginCmd)) ?? "[我再]?[要来來发發给給]";
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureBeginCmd), value);
        }

        /// <summary>
        /// 色图数量命令(正则表达式)
        /// </summary>
        public static string HPictureCountCmd
        {
            get => JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureCountCmd)) ?? "[0-9零一壹二两贰兩三叁四肆五伍六陆陸七柒八捌九玖十拾百佰千仟万萬亿]+?";
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureCountCmd), value);
        }

        /// <summary>
        /// 色图单位命令(正则表达式)
        /// </summary>
        public static string HPictureUnitCmd
        {
            get => JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureUnitCmd)) ?? "[张張个個幅份]";
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureUnitCmd), value);
        }

        /// <summary>
        /// 色图R-18命令(正则表达式)
        /// </summary>
        public static string HPictureR18Cmd
        {
            get => JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureR18Cmd)) ?? "[Rr]-?18的?";
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureR18Cmd), value);
        }

        /// <summary>
        /// 色图关键词命令(正则表达式)
        /// </summary>
        public static string HPictureKeywordCmd
        {
            get => JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureKeywordCmd)) ?? ".+?";
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureKeywordCmd), value);
        }

        /// <summary>
        /// Lolicon图库色图结束命令后缀(正则表达式)
        /// </summary>
        public static string HPictureEndCmd
        {
            get => JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureEndCmd)) ?? "的?[色瑟][图圖]";
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureEndCmd), value);
        }
        
        /// <summary>
        /// Lolicon图库色图结束命令后缀(正则表达式)
        /// </summary>
        public static string ShabHPictureEndCmd
        {
            get => JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(ShabHPictureEndCmd)) ?? "的?美[图圖]";
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(ShabHPictureEndCmd), value);
        }

        /// <summary>
        /// 是否允许色图命令前缀为空
        /// </summary>
        public static bool HPictureBeginCmdNull
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureBeginCmdNull));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureBeginCmdNull), value.ToString());
        }

        /// <summary>
        /// 是否允许色图数量命令为空
        /// </summary>
        public static bool HPictureCountCmdNull
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureCountCmdNull));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureCountCmdNull), value.ToString());
        }

        /// <summary>
        /// 是否允许色图单位命令为空
        /// </summary>
        public static bool HPictureUnitCmdNull
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureUnitCmdNull));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureUnitCmdNull), value.ToString());
        }

        /// <summary>
        /// 是否允许R-18命令为空
        /// </summary>
        public static bool HPictureR18CmdNull
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureR18CmdNull));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureR18CmdNull), value.ToString());

        }

        /// <summary>
        /// 是否允许关键词命令为空
        /// </summary>
        public static bool HPictureKeywordCmdNull
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureKeywordCmdNull));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureKeywordCmdNull), value.ToString());
        }

        /// <summary>
        /// 是否允许Lolicon图库色图命令后缀为空
        /// </summary>
        public static bool HPictureEndCmdNull
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureEndCmdNull));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureEndCmdNull), value.ToString());
        }
        
        /// <summary>
        /// 是否允许shab图库色图命令后缀为空
        /// </summary>
        public static bool ShabHPictureEndCmdNull
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(ShabHPictureEndCmdNull));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(ShabHPictureEndCmdNull), value.ToString());
        } 
        
        /// <summary>
        /// Shab图库非R-18是否不撤回
        /// </summary>
        public static bool ShabDontRevokeWithOutR18
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(ShabDontRevokeWithOutR18));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(ShabDontRevokeWithOutR18), value.ToString());
        }

        /// <summary>
        /// 是否启用Lolicon图库色图
        /// </summary>
        public static bool EnabledLoliconDataBase
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(EnabledLoliconDataBase));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(EnabledLoliconDataBase), value.ToString());
        }

        /// <summary>
        /// 是否启用Shab图库色图
        /// </summary>
        public static bool EnabledShabDataBase
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(EnabledShabDataBase));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(EnabledShabDataBase), value.ToString());
        }

        /// <summary>
        /// 自定义色图命令
        /// </summary>
        public static IEnumerable<string> HPictureUserCmd
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureUserCmd));
                if (string.IsNullOrEmpty(strValue))
                {
                    return new List<string>();
                }
                return strValue.Split(';');
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureUserCmd), string.Join(";", value));
        }

        /// <summary>
        /// 白名单群
        /// </summary>
        public static IEnumerable<long> HPictureWhiteGroup
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureWhiteGroup));
                if (string.IsNullOrEmpty(strValue))
                {
                    return new List<long>();
                }
                return strValue.Split(';').Select(long.Parse);
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureWhiteGroup), string.Join(";", value));
        }

        /// <summary>
        /// 是否仅限白名单使用色图
        /// </summary>
        public static bool HPictureWhiteOnly
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureWhiteOnly));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureWhiteOnly), value.ToString());
        }

        /// <summary>
        /// 是否启用R-18
        /// </summary>
        public static bool HPictureAllowR18
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureAllowR18));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureAllowR18), value.ToString());
        }

        /// <summary>
        /// 是否仅限白名单使用R-18
        /// </summary>
        public static bool HPictureR18WhiteOnly
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureR18WhiteOnly));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureR18WhiteOnly), value.ToString());
        }

        /// <summary>
        /// 允许私聊
        /// </summary>
        public static bool HPictureAllowPM
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureAllowPM));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureAllowPM), value.ToString());
        }

        /// <summary>
        /// 反和谐
        /// </summary>
        public static bool HPictureAntiShielding
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureAntiShielding));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureAntiShielding), value.ToString());
        }


        /// <summary>
        /// 1200像素模式
        /// </summary>
        public static bool HPictureSize1200
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureSize1200));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return false;
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureSize1200), value.ToString());
        }

        /// <summary>
        /// 冷却时间
        /// </summary>
        public static int HPictureCD
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureCD));
                if (int.TryParse(strValue, out int iValue)) return iValue;
                return 0;
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureCD), value.ToString());
        }

        /// <summary>
        /// 次数限制
        /// </summary>
        public static int HPictureLimit
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureLimit));
                if (int.TryParse(strValue, out int iValue)) return iValue;
                return 0;
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureLimit), value.ToString());
        }

        /// <summary>
        /// 撤回时间
        /// </summary>
        public static int HPictureRevoke
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureRevoke));
                if (int.TryParse(strValue, out int iValue)) return iValue;
                return 0;
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureRevoke), value.ToString());
        }

        /// <summary>
        /// 白名单群冷却时间
        /// </summary>
        public static int HPictureWhiteCD
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureWhiteCD));
                if (int.TryParse(strValue, out int iValue)) return iValue;
                return 0;
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureWhiteCD), value.ToString());
        }

        /// <summary>
        /// 白名单群撤回时间
        /// </summary>
        public static int HPictureWhiteRevoke
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureWhiteRevoke));
                if (int.TryParse(strValue, out int iValue)) return iValue;
                return 0;
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureWhiteRevoke), value.ToString());
        }

        /// <summary>
        /// 私聊冷却时间
        /// </summary>
        public static int HPicturePMCD
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPicturePMCD));
                if (int.TryParse(strValue, out int iValue)) return iValue;
                return 0;
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPicturePMCD), value.ToString());
        }

        /// <summary>
        /// 私聊撤回时间
        /// </summary>
        public static int HPicturePMRevoke
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPicturePMRevoke));
                if (int.TryParse(strValue, out int iValue)) return iValue;
                return 0;
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPicturePMRevoke), value.ToString());
        }

        /// <summary>
        /// 机器人管理员无冷却时间/次数限制
        /// </summary>
        public static bool HPictureAdminNoLimit
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureAdminNoLimit));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureAdminNoLimit), value.ToString());
        }

        /// <summary>
        /// 群主和群管理无冷却时间/次数限制
        /// </summary>
        public static bool HPictureManageNoLimit
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureManageNoLimit));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureManageNoLimit), value.ToString());
        }

        /// <summary>
        /// 私聊无冷却时间/次数限制
        /// </summary>
        public static bool HPicturePMNoLimit
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPicturePMNoLimit));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPicturePMNoLimit), value.ToString());
        }

        /// <summary>
        /// 白名单群无冷却时间/次数限制
        /// </summary>
        public static bool HPictureWhiteNoLimit
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureWhiteNoLimit));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureWhiteNoLimit), value.ToString());
        }

        /// <summary>
        /// 冷却中回复
        /// </summary>
        public static string HPictureCDUnreadyReply
        {
            get => JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureCDUnreadyReply)) ?? "乖，要懂得节制哦，休息一会再冲吧 →_→";
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureCDUnreadyReply), value);
        }

        /// <summary>
        /// 次数用尽回复
        /// </summary>
        public static string HPictureOutOfLimitReply
        {
            get => JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureOutOfLimitReply)) ?? "今天不要再冲了啦(>_<)";
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureOutOfLimitReply), value);
        }

        /// <summary>
        /// 发生错误回复
        /// </summary>
        public static string HPictureErrorReply
        {
            get => JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureErrorReply)) ?? "色图服务器爆炸惹_(:3」∠)_";
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureErrorReply), value);
        }

        /// <summary>
        /// 没有结果回复
        /// </summary>
        public static string HPictureNoResultReply
        {
            get => JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureNoResultReply)) ?? "没有找到符合条件的图ㄟ( ▔, ▔ )ㄏ";
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureNoResultReply), value);
        }

        /// <summary>
        /// 下载失败回复
        /// </summary>
        public static string HPictureDownloadFailReply
        {
            get => JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureDownloadFailReply)) ?? "地址为:<URL>的图不见了，画师可能被送温暖了o(╥﹏╥)o (如连续出现时请检查<机器人名称>网络/代理/加速链/墙问题。)";
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureDownloadFailReply), value);
        }

        /// <summary>
        /// 色图次数限制记录类型
        /// </summary>
        public static LimitType HPictureLimitType
        {
            get
            {

                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureLimitType));
                if (!string.IsNullOrEmpty(strValue))
                    return (LimitType)Enum.Parse(typeof(LimitType), strValue);
                return LimitType.Frequency;
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureLimitType), value.ToString());
        }

        /// <summary>
        /// 是否启用多线程下载色图
        /// </summary>
        public static bool HPictureMultithreading
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureMultithreading));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureMultithreading), value.ToString());
        }

        /// <summary>
        /// 是否启用色图功能
        /// </summary>
        public static bool HPictureEnabled
        {
            get
            {
                string strValue = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureEnabled));
                if (bool.TryParse(strValue, out bool bValue)) return bValue;
                return true;
            }
            set => JsonHelper.SetSerializationValue(Cache.JsonConfigFileName, JsonNodeNameHPicture, nameof(HPictureEnabled), value.ToString());
        }
        #endregion -- 色图属性 --
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
}