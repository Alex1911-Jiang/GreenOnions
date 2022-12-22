using System.Collections.Generic;
using GreenOnions.Interface;
using GreenOnions.Interface.Configs;
using GreenOnions.Interface.Configs.Enums;
using GreenOnions.Interface.Items;

namespace GreenOnions.Utility
{
    public class BotConfig : IBotConfig
    {

        #region -- 核心配置项 --
        public int LogLevel { get; set; } = 2;

        public long QQId { get; set; } = 0;

        public string IP { get; set; } = "127.0.0.1";

        public ushort Port { get; set; } = 33111;

        public string VerifyKey { get; set; } = "Alex1911";

        /// <summary>
        /// 机器人名称
        /// </summary>
        public string BotName { get; set; } = "葱葱";

        /// <summary>
        /// 机器人管理员QQ
        /// </summary>
        public HashSet<long> AdminQQ { get; set; } = new HashSet<long>();

        /// <summary>
        /// 黑名单组
        /// </summary>
        public HashSet<long> BannedGroup { get; set; } = new HashSet<long>();

        /// <summary>
        /// 黑名单用户
        /// </summary>
        public HashSet<long> BannedUser { get; set; } = new HashSet<long>();

        /// <summary>
        /// 是否自动退出被禁言的群
        /// </summary>
        public bool LeaveGroupAfterBeMushin { get; set; } = false;

        /// <summary>
        /// 是否启用调试模式
        /// </summary>
        public bool DebugMode { get; set; } = false;

        /// <summary>
        /// 调试群组
        /// </summary>
        public HashSet<long> DebugGroups { get; set; } = new HashSet<long>();

        /// <summary>
        /// 调试模式下是否只响应指定群组的消息
        /// </summary>
        public bool OnlyReplyDebugGroup { get; set; } = false;

        /// <summary>
        /// 调试模式下是否只响应机器人管理员的消息
        /// </summary>
        public bool DebugReplyAdminOnly { get; set; } = false;

        /// <summary>
        /// 允许Windows系统使用浏览器执行Http请求
        /// </summary>
        public bool HttpRequestByWebBrowser { get; set; } = false;

        /// <summary>
        /// 图片外链路由替换 0:不替换  1:替换为c2cpicdw.qpic.cn/offpic_new  2:替换为gchat.qpic.cn/gchatpic_new
        /// </summary>
        public int ReplaceImgRoute { get; set; } = 2;

        /// <summary>
        /// Pixiv代理地址
        /// </summary>
        public string PixivProxy { get; set; } = "pixiv.re";

        /// <summary>
        /// 保留所有下载的图片用于缓存
        /// </summary>
        public bool DownloadImage4Caching { get; set; } = true;

        /// <summary>
        /// 所有图片下载到本地再发送文件
        /// </summary>
        public bool SendImageByFile { get; set; } = false;

        #region -- 腾讯云相关属性 --
        /// <summary>
        /// 是否接入腾讯云AI鉴黄
        /// </summary>
        public bool CheckPornEnabled { get; set; } = false;

        /// <summary>
        /// 腾讯云APPID
        /// </summary>
        public string TencentCloudAPPID { get; set; } = string.Empty;

        /// <summary>
        /// 腾讯云CloudRegion
        /// </summary>
        public string TencentCloudRegion { get; set; } = string.Empty;

        /// <summary>
        /// 腾讯云SecretId
        /// </summary>
        public string TencentCloudSecretId { get; set; } = string.Empty;

        /// <summary>
        /// 腾讯云SecretKey
        /// </summary>
        public string TencentCloudSecretKey { get; set; } = string.Empty;

        /// <summary>
        /// 腾讯云桶名称
        /// </summary>
        public string TencentCloudBucket { get; set; } = string.Empty;

        #endregion -- 腾讯云相关属性 --

        /// <summary>
        /// 是否启用自动连接到机器人平台
        /// </summary>
        public bool AutoConnectEnabled { get; set; } = false;

        /// <summary>
        /// 自动连接的平台
        /// </summary>
        public int AutoConnectProtocol { get; set; } = 0;

        /// <summary>
        /// 连接前延时
        /// </summary>
        public int AutoConnectDelay { get; set; } = 5;

        public bool WorkingTimeEnabled { get; set; } = false;

        public int WorkingTimeFromHour { get; set; } = 0;

        public int WorkingTimeFromMinute { get; set; } = 0;

        public int WorkingTimeToHour { get; set; } = 0;

        public int WorkingTimeToMinute { get; set; } = 0;

        /// <summary>
        /// 搜图和色图把文字消息和图片消息拆分开（对于私聊含有pixiv发不出去的问题）
        /// </summary>
        public bool SplitTextAndImageMessage { get; set; } = true;

        #endregion -- 核心配置项 --

        #region -- 搜图配置项 --

        /// <summary>
        /// 是否启用搜图功能
        /// </summary>
        public bool SearchEnabled { get; set; } = true;

        /// <summary>
        /// 私聊时是否自动搜图
        /// </summary>
        public bool PmAutoSearch { get; set; } = true;

        /// <summary>
        /// 是否发送缩略图
        /// </summary>
        public bool SearchSendThuImage { get; set; } = true;

        #region -- TraceMoe --

        /// <summary>
        /// 是否启用TraceMoe搜番
        /// </summary>
        public bool SearchEnabledTraceMoe { get; set; } = true;

        /// <summary>
        /// TraceMoe搜图相似度大于此数值时发送搜番结果
        /// </summary>
        public int TraceMoeSendThreshold { get; set; } = 87;

        /// <summary>
        /// TraceMoe搜番结果为里番时是否发送缩略图
        /// </summary>
        public bool TraceMoeSendAdultThuImg { get; set; } = false;

        #endregion -- TraceMoe --

        #region -- SauceNAO --

        /// <summary>
        /// 是否启用SauceNAO搜图
        /// </summary>
        public bool SearchEnabledSauceNAO { get; set; } = true;

        /// <summary>
        /// SauceNAO在Windows系统下时SauceNAO优先以浏览器进行请求(腾讯云轻量403问题)
        /// </summary>
        public bool SauceNAORequestByWebBrowser { get; set; } = false;

        /// <summary>
        /// SauceNAO Api-Key
        /// </summary>
        public HashSet<string> SauceNAOApiKey { get; set; } = new HashSet<string>();

        /// <summary>
        /// 是否SauceNAO搜图按相似度倒序排序
        /// </summary>
        public bool SearchSauceNAOSortByDesc { get; set; } = false;

        /// <summary>
        /// SauceNAO 低相似度阈值
        /// </summary>
        public int SearchSauceNAOLowSimilarity { get; set; } = 60;

        /// <summary>
        /// 是否SauceNAO搜图发送Pixiv原图
        /// </summary>
        public bool SearchSauceNAOSendPixivOriginalPicture { get; set; } = true;

        /// <summary>
        /// SauceNAO 高相似度阈值
        /// </summary>
        public int SearchSauceNAOHighSimilarity { get; set; } = 90;

        /// <summary>
        /// SauceNAO 相似度低于阈值返回消息
        /// </summary>
        public string SearchSauceNAOLowSimilarityReply { get; set; } = "相似度低于<SauceNAO 低相似度阈值>%，缩略图不予显示。";

        #endregion -- SauceNAO --

        #region -- ASCII2D --

        /// <summary>
        /// 是否启用ASCII2D搜图
        /// </summary>
        public bool SearchEnabledASCII2D { get; set; } = true;

        /// <summary>
        /// 在Windows系统下时ASCII2D优先以浏览器进行请求(以应对近期403问题)
        /// </summary>
        public bool ASCII2DRequestByWebBrowser { get; set; } = true;

        /// <summary>
        /// ASCII2D显示结果数量
        /// </summary>
        public int SearchShowASCII2DCount { get; set; } = 1;

        #endregion -- ASCII2D --

        #region -- Iqdb --

        #region -- Iqdb anime --

        /// <summary>
        /// 是否启用Iqdb搜图
        /// </summary>
        public bool SearchEnabledIqdb { get; set; } = true;

        #endregion -- Iqdb anime --

        #region -- 3dIqdb --

        /// <summary>
        /// 是否启用3dIqdb搜车
        /// </summary>
        public bool SearchEnabled3dIqdb { get; set; } = true;

        #endregion -- 3dIqdb --

        /// <summary>
        /// Iqdb 是否发送标签
        /// </summary>
        public bool SearchIqdbSendTags { get; set; } = false;

        /// <summary>
        /// Iqdb 只发送分级为安全的缩略图
        /// </summary>
        public bool SearchIqdbMustSafe { get; set; } = true;

        /// <summary>
        /// Iqdb 相似度阈值
        /// </summary>
        public int SearchIqdbSimilarity { get; set; } = 60;

        /// <summary>
        /// Iqdb 相似度低于阈值返回消息
        /// </summary>
        public string SearchIqdbSimilarityReply { get; set; } = "相似度低于<Iqdb 相似度阈值>%，缩略图不予显示。";

        #endregion -- Iqdb --

        /// <summary>
        /// 开启连续搜图命令(正则表达式)
        /// </summary>
        public string SearchModeOnCmd { get; set; } = "<机器人名称>搜[图圖図]";

        /// <summary>
        /// 开启连续搜番命令(正则表达式)
        /// </summary>
        public string SearchAnimeModeOnCmd { get; set; } = "<机器人名称>搜[图圖図]";

        /// <summary>
        /// 开启连续搜车命令(正则表达式)
        /// </summary>
        public string Search3DModeOnCmd { get; set; } = "<机器人名称>搜[车車]?";

        /// <summary>
        /// 开启连续搜图功能返回消息
        /// </summary>
        public string SearchModeOnReply { get; set; } = "了解～请发送图片吧！支持批量噢！\r\n如想退出搜索模式请发送“谢谢<机器人名称>”";

        /// <summary>
        /// 已在连续搜图模式下返回消息
        /// </summary>
        public string SearchModeAlreadyOnReply { get; set; } = "您已经在搜图模式下啦！\r\n如想退出搜索模式请发送“谢谢<机器人名称>”";

        /// <summary>
        /// 发起搜索时的回复语(正在搜索但未搜索完毕)
        /// </summary>
        public string SearchingReply { get; set; } = string.Empty;

        /// <summary>
        /// 关闭连续搜图命令(正则表达式)
        /// </summary>
        public string SearchModeOffCmd { get; set; } = "[谢謝][谢謝]<机器人名称>";

        /// <summary>
        /// 连续搜图超时返回消息
        /// </summary>
        public string SearchModeTimeOutReply { get; set; } = "由于超时，已为您自动退出搜图模式，以后要记得说“谢谢<机器人名称>”来退出搜图模式噢";

        /// <summary>
        /// 退出连续搜图功能返回消息
        /// </summary>
        public string SearchModeOffReply { get; set; } = "不用谢!(<ゝω・)☆";

        /// <summary>
        /// 已经退出连续搜图功能返回消息
        /// </summary>
        public string SearchModeAlreadyOffReply { get; set; } = "虽然不知道为什么谢我, 但是还请注意补充营养呢(｀・ω・´)";

        /// <summary>
        /// 没有搜索到结果返回消息
        /// </summary>
        public string SearchNoResultReply { get; set; } = "<搜索类型>没有搜到该图片的地址o(╥﹏╥)o";

        /// <summary>
        /// 搜索过程中发生异常返回消息
        /// </summary>
        public string SearchErrorReply { get; set; } = "<搜索类型>搜索失败_(:3」∠)_";

        /// <summary>
        /// 下载缩略图失败时追加回复
        /// </summary>
        public string SearchDownloadThuImageFailReply { get; set; } = "缩略图下载失败。";

        /// <summary>
        /// 搜图结果以合并转发的方式发送
        /// </summary>
        public bool SearchSendByForward { get; set; } = false;

        /// <summary>
        /// 是否在搜图功能上启用鉴黄
        /// </summary>
        public bool SearchCheckPornEnabled { get; set; } = false;

        /// <summary>
        /// 搜图功能鉴黄不通过返回消息
        /// </summary>
        public string SearchCheckPornIllegalReply { get; set; } = "AI鉴黄不通过，缩略图不予显示。";

        /// <summary>
        /// 搜图功能鉴黄发生异常返回消息
        /// </summary>
        public string SearchCheckPornErrorReply { get; set; } = "AI鉴黄发生错误，缩略图不予显示。<错误信息>";

        #endregion -- 搜图配置项 --

        #region -- 下载原图配置项 --

        /// <summary>
        /// 是否启用下载原图
        /// </summary>
        public bool OriginalPictureEnabled { get; set; } = true;

        /// <summary>
        /// 下载原图命令
        /// </summary>
        public string OriginalPictureCommand { get; set; } = "<机器人名称>下[載载][Pp]([Ii][Xx][Ii][Vv]|站)原[圖图][:：]";

        /// <summary>
        /// 开始下载原图回复语
        /// </summary>
        public string OriginalPictureDownloadingReply { get; set; } = "正在下载，请稍候...";

        /// <summary>
        /// 是否在下载原图功能上启用鉴黄
        /// </summary>
        public bool OriginalPictureCheckPornEnabled { get; set; } = false;

        /// <summary>
        /// 下载原图功能上鉴黄不通过时做以下动作: 0.以合并转发的方式发送原图 1.不做任何事 2.回复设置的语句
        /// </summary>
        public int OriginalPictureCheckPornEvent { get; set; } = 2;

        /// <summary>
        /// 下载原图功能鉴黄不通过返回消息
        /// </summary>
        public string OriginalPictureCheckPornIllegalReply { get; set; } = "AI鉴黄不通过。";
        /// <summary>
        /// 下载原图功能鉴黄错误返回消息
        /// </summary>
        public string OriginalPictureCheckPornErrorReply { get; set; } = "AI鉴黄发生错误。<错误信息>";

        #endregion -- 下载原图配置项 --

        #region -- 色图配置项 --

        /// <summary>
        /// 色图/美图完整命令(正则表达式)
        /// </summary>
        public string HPictureCmd { get; set; } = IBotConfig.DefaultHPictureCmd;

        /// <summary>
        /// 是否撤回美图(撤回时间跟随色图撤回时间设置)
        /// </summary>
        public bool RevokeBeautyPicture { get; set; } = true;

        /// <summary>
        /// 启用的美图图库
        /// </summary>
        public HashSet<PictureSource> EnabledBeautyPictureSource { get; set; } = new HashSet<PictureSource>();

        /// <summary>
        /// 启用的色图图库
        /// </summary>
        public HashSet<PictureSource> EnabledHPictureSource { get; set; } = new HashSet<PictureSource>() { PictureSource.Lolicon };

        /// <summary>
        /// 自定义色图命令
        /// </summary>
        public HashSet<string> HPictureUserCmd { get; set; } = new HashSet<string>() { "--setu" };

        /// <summary>
        /// 如果命令不含后缀，默认图库为
        /// </summary>
        public PictureSource HPictureDefaultSource { get; set; } = PictureSource.Lolicon;

        /// <summary>
        /// 白名单群
        /// </summary>
        public HashSet<string> HPictureShieldingWords { get; set; } = new HashSet<string>();

        /// <summary>
        /// 白名单群
        /// </summary>
        public HashSet<long> HPictureWhiteGroup { get; set; } = new HashSet<long>();

        /// <summary>
        /// 是否仅限白名单使用色图
        /// </summary>
        public bool HPictureWhiteOnly { get; set; } = false;

        /// <summary>
        /// 是否启用R-18
        /// </summary>
        public bool HPictureAllowR18 { get; set; } = true;

        /// <summary>
        /// 是否仅限白名单使用R-18
        /// </summary>
        public bool HPictureR18WhiteOnly { get; set; } = true;

        /// <summary>
        /// 允许私聊
        /// </summary>
        public bool HPictureAllowPM { get; set; } = true;

        /// <summary>
        /// 1200像素模式
        /// </summary>
        public bool HPictureSize1200 { get; set; } = false;

        /// <summary>
        /// 冷却时间
        /// </summary>
        public int HPictureCD { get; set; } = 0;

        /// <summary>
        /// 次数限制
        /// </summary>
        public int HPictureLimit { get; set; } = 0;

        /// <summary>
        /// 撤回时间
        /// </summary>
        public int HPictureRevoke { get; set; } = 0;

        /// <summary>
        /// 白名单群冷却时间
        /// </summary>
        public int HPictureWhiteCD { get; set; } = 0;

        /// <summary>
        /// 白名单群撤回时间
        /// </summary>
        public int HPictureWhiteRevoke { get; set; } = 0;

        /// <summary>
        /// 私聊冷却时间
        /// </summary>
        public int HPicturePMCD { get; set; } = 0;

        /// <summary>
        /// 私聊撤回时间
        /// </summary>
        public int HPicturePMRevoke { get; set; } = 0;

        /// <summary>
        /// 机器人管理员无冷却时间/次数限制
        /// </summary>
        public bool HPictureAdminNoLimit { get; set; } = true;

        /// <summary>
        /// 私聊无冷却时间/次数限制
        /// </summary>
        public bool HPicturePMNoLimit { get; set; } = false;

        /// <summary>
        /// 白名单群无冷却时间/次数限制
        /// </summary>
        public bool HPictureWhiteNoLimit { get; set; } = true;

        /// <summary>
        /// 色图是否发送作品地址
        /// </summary>
        public bool HPictureSendUrl { get; set; } = true;

        /// <summary>
        /// 色图是否发送图片代理地址
        /// </summary>
        public bool HPictureSendProxyUrl { get; set; } = false;

        /// <summary>
        /// 色图是否发送标题和作者
        /// </summary>
        public bool HPictureSendTitle { get; set; } = true;

        /// <summary>
        /// 色图是否发送标签
        /// </summary>
        public bool HPictureSendTags { get; set; } = false;

        /// <summary>
        /// 是否以合并转发的方式发送色图
        /// </summary>
        public bool HPictureSendByForward { get; set; } = false;

        /// <summary>
        /// 开始下载色图时回复
        /// </summary>
        public string HPictureDownloadingReply { get; set; } = "正在查找色图...";

        /// <summary>
        /// 冷却中回复
        /// </summary>
        public string HPictureCDUnreadyReply { get; set; } = "乖，要懂得节制哦，休息一会再冲吧 →_→";

        /// <summary>
        /// 次数用尽回复
        /// </summary>
        public string HPictureOutOfLimitReply { get; set; } = "今天不要再冲了啦(>_<)";

        /// <summary>
        /// 发生错误回复
        /// </summary>
        public string HPictureErrorReply { get; set; } = "色图服务器爆炸惹_(:3」∠)_";

        /// <summary>
        /// 没有结果回复
        /// </summary>
        public string HPictureNoResultReply { get; set; } = "没有找到符合条件的图ㄟ( ▔, ▔ )ㄏ";

        /// <summary>
        /// 下载失败回复
        /// </summary>
        public string HPictureDownloadFailReply { get; set; } = "地址为:<URL>的色图不见了，可能是色图服务器下载失败或图真的没了o(╥﹏╥)o (如连续出现时请检查<机器人名称>网络/代理/墙问题。)";

        /// <summary>
        /// 色图次数限制记录类型
        /// </summary>
        public LimitType HPictureLimitType { get; set; } = LimitType.Frequency;

        /// <summary>
        /// 一条色图命令最多允许返回多少张色图
        /// </summary>
        public int HPictureOnceMessageMaxImageCount { get; set; } = 10;

        /// <summary>
        /// 是否启用色图功能
        /// </summary>
        public bool HPictureEnabled { get; set; } = true;

        #endregion -- 色图配置项 --

        #region -- 翻译配置项 --

        /// <summary>
        /// 是否启用翻译功能
        /// </summary>
        public bool TranslateEnabled { get; set; } = true;

        /// <summary>
        /// 翻译引擎
        /// </summary>
        public TranslateEngine TranslateEngineType { get; set; } = TranslateEngine.YouDao;

        /// <summary>
        /// 翻译为中文命令(正则表达式)
        /// </summary>
        public string TranslateToChineseCMD { get; set; } = "<机器人名称>翻[译譯][:：]";

        /// <summary>
        /// 翻译为指定语言命令(正则表达式)
        /// </summary>
        public string TranslateToCMD { get; set; } = "<机器人名称>翻[译譯][成为為到至](.+[语語文])[:：]";

        /// <summary>
        /// 从指定语言翻译为指定语言命令(正则表达式)
        /// </summary>
        public string TranslateFromToCMD { get; set; } = "<机器人名称>[把从從自从](?<from>.+[语語文])翻[译譯][成为為到至](?<to>.+[语語文])[:：]";

        /// <summary>
        /// 自动翻译群友QQ
        /// </summary>
        public HashSet<long> AutoTranslateGroupMemoriesQQ { get; set; } = new HashSet<long>();

        #endregion -- 翻译配置项 --

        #region -- 复读配置项 --

        /// <summary>
        /// 是否启用随机复读
        /// </summary>
        public bool RandomRepeatEnabled { get; set; } = false;

        /// <summary>
        /// 随机复读概率
        /// </summary>
        public int RandomRepeatProbability { get; set; } = 1;

        /// <summary>
        /// 是否启用连续复读
        /// </summary>
        public bool SuccessiveRepeatEnabled { get; set; } = false;

        /// <summary>
        /// 参与连续复读所需的复读次数
        /// </summary>
        public int SuccessiveRepeatCount { get; set; } = 3;

        /// <summary>
        /// 是否倒放复读Gif
        /// </summary>
        public bool RewindGifEnabled { get; set; } = true;

        /// <summary>
        /// 倒放复读Gif概率
        /// </summary>
        public int RewindGifProbability { get; set; } = 50;

        /// 
        /// <summary>
        /// 是否水平反转复读图片
        /// </summary>
        public bool HorizontalMirrorImageEnabled { get; set; } = true;

        /// <summary>
        /// 水平反转复读图片概率
        /// </summary>
        public int HorizontalMirrorImageProbability { get; set; } = 50;

        /// <summary>
        /// 是否垂直翻转复读图片
        /// </summary>
        public bool VerticalMirrorImageEnabled { get; set; } = true;

        /// <summary>
        /// 垂直翻转复读图片概率
        /// </summary>
        public int VerticalMirrorImageProbability { get; set; } = 50;

        /// <summary>
        /// 将"我"替换为"你"
        /// </summary>
        public bool ReplaceMeToYou { get; set; } = false;

        #endregion -- 复读配置项 --

        #region -- 进退群提醒配置项 --

        /// <summary>
        /// 是否启用新人入群消息
        /// </summary>
        public bool SendMemberJoinedMessage { get; set; } = true;

        /// <summary>
        /// 是否启用成员退群消息
        /// </summary>
        public bool SendMemberPositiveLeaveMessage { get; set; } = true;

        /// <summary>
        /// 是否启用成员被踢消息
        /// </summary>
        public bool SendMemberBeKickedMessage { get; set; } = true;

        /// <summary>
        /// 新人入群消息
        /// </summary>
        public string MemberJoinedMessage { get; set; } = "<@成员QQ> 欢迎新大佬，群地位-1 (ΩДΩ)";

        /// <summary>
        /// 成员退群消息
        /// </summary>
        public string MemberPositiveLeaveMessage { get; set; } = "QQ号：<成员QQ> 退出了群，群地位+1 o(╥﹏╥)o";

        /// <summary>
        /// 成员被踢消息
        /// </summary>
        public string MemberBeKickedMessage { get; set; } = " <成员昵称> ( <成员QQ> ) 被 <操作者昵称> 踢了出群，群地位+1 (*^▽^*)";

        #endregion -- 进退群提醒配置项 --

        #region -- 伪造消息配置项 --

        /// <summary>
        /// 是否启用伪造消息功能
        /// </summary>
        public bool ForgeMessageEnabled { get; set; } = true;

        /// <summary>
        /// 伪造消息前缀
        /// </summary>
        public string ForgeMessageCmdBegin { get; set; } = "<机器人名称>伪造(消息|聊天[记記][录錄])";

        /// <summary>
        /// 伪造消息分行符(分行符前后的内容会分成两条消息)
        /// </summary>
        public string ForgeMessageCmdNewLine { get; set; } = @"\r\n";

        /// <summary>
        /// 是否在伪造消息末端追加消息
        /// </summary>
        public bool ForgeMessageAppendBotMessageEnabled { get; set; } = true;

        /// <summary>
        /// 是否只允许机器人管理员使用伪造消息功能
        /// </summary>
        public bool ForgeMessageAdminOnly { get; set; } = false;

        /// <summary>
        /// 机器人管理员使用伪造消息功能时是否不在末端追加消息
        /// </summary>
        public bool ForgeMessageAdminDontAppend { get; set; } = true;

        /// <summary>
        /// 追加消息内容
        /// </summary>
        public string ForgeMessageAppendMessage { get; set; } = "此消息为<机器人名称>伪造，仅作娱乐，请勿用于非法用途。";

        /// <summary>
        /// 是否拒绝伪造机器人管理员的消息
        /// </summary>
        public bool RefuseForgeAdmin { get; set; } = true;

        /// <summary>
        /// 试图伪造机器人管理员消息时的回复语
        /// </summary>
        public string RefuseForgeAdminReply { get; set; } = "你不能让我伪造我主人的消息。";

        /// <summary>
        /// 是否拒绝伪造机器人的消息(如果由机器人管理员发起则不会校验此项目)
        /// </summary>
        public bool RefuseForgeBot { get; set; } = true;

        /// <summary>
        /// 试图伪造机器人消息时的回复语
        /// </summary>
        public string RefuseForgeBotReply { get; set; } = "你不会以为我会伪造自己的消息吧，不会吧不会吧？";

        #endregion -- 伪造消息配置项 --

        #region -- RSS 配置项 --

        /// <summary>
        /// 是否启用Rss订阅转发
        /// </summary>
        public bool RssEnabled { get; set; } = false;

        /// <summary>
        /// 抓取RSS间隔时间(分钟)
        /// </summary>
        public double ReadRssInterval { get; set; } = 10.0;

        /// <summary>
        /// 多线程并行抓取多个RSS订阅
        /// </summary>
        public bool RssParallel { get; set; } = false;

        /// <summary>
        /// 订阅的地址和需要转发到的QQ或群列表
        /// </summary>
        public HashSet<RssSubscriptionItem> RssSubscription { get; set; } = null;

        /// <summary>
        /// 获取B站直播封面
        /// </summary>
        public bool RssSendLiveCover { get; set; } = true;
        #endregion -- RSS 配置项 --
    }
}