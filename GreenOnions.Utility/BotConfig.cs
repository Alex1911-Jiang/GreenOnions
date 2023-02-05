using System.Collections.Generic;
using GreenOnions.Interface;
using GreenOnions.Interface.Configs;
using GreenOnions.Interface.Configs.Enums;
using GreenOnions.Interface.Items;

namespace GreenOnions.Utility
{
    public class BotConfig : IBotConfig
    {
        public void CreateDefaultValue()
        {
            EnabledHPictureSource.Add(PictureSource.Lolicon);
            EnabledHPictureSource.Add(PictureSource.Lolisuki);
            HPictureUserCmd.Add("--setu");
        }

        #region -- 核心配置项 --

        [PropertyChineseName("代理地址", "核心")]
        public string ProxyUrl { get; set; } = "";

        [PropertyChineseName("日志级别", "核心")]
        public int LogLevel { get; set; } = 2;

        [PropertyChineseName("机器人QQ", "核心")]
        public long QQId { get; set; } = 0;

        [PropertyChineseName("IP", "核心", "连接的机器人平台IP地址")]
        public string IP { get; set; } = "127.0.0.1";

        [PropertyChineseName("Port", "核心", "连接的机器人平台端口号")]
        public ushort Port { get; set; } = 33111;

        [PropertyChineseName("VerifyKey/Access-Token", "核心", "连接的机器人平台令牌")]
        public string VerifyKey { get; set; } = "Alex1911";

        /// <summary>
        /// 机器人名称
        /// </summary>
        [PropertyChineseName("机器人名称", "核心")]
        public string BotName { get; set; } = "葱葱";

        /// <summary>
        /// 机器人管理员QQ
        /// </summary>
        [PropertyChineseName("机器人管理员QQ", "核心")]
        public HashSet<long> AdminQQ { get; set; } = new HashSet<long>();

        /// <summary>
        /// 黑名单组
        /// </summary>
        [PropertyChineseName("群黑名单", "核心")]
        public HashSet<long> BannedGroup { get; set; } = new HashSet<long>();

        /// <summary>
        /// 黑名单用户
        /// </summary>
        [PropertyChineseName("用户黑名单", "核心")]
        public HashSet<long> BannedUser { get; set; } = new HashSet<long>();

        /// <summary>
        /// 是否自动退出被禁言的群
        /// </summary>
        [PropertyChineseName("自动退出被禁言的群", "核心")]
        public bool LeaveGroupAfterBeMushin { get; set; } = false;

        /// <summary>
        /// 是否启用消息中转功能
        /// </summary>
        [PropertyChineseName("启用消息中转", "核心", "收到私聊消息且没命中任何命令时转发给机器人管理员")]
        public bool MessageTransferEnabled { get; set; } = true;

        /// <summary>
        /// 是否启用调试模式
        /// </summary>
        [PropertyChineseName("调试模式", "核心")]
        public bool DebugMode { get; set; } = false;

        /// <summary>
        /// 调试群组
        /// </summary>
        [PropertyChineseName("调试群组", "核心")]
        public HashSet<long> DebugGroups { get; set; } = new HashSet<long>();

        /// <summary>
        /// 调试模式下是否只响应指定群组的消息
        /// </summary>
        [PropertyChineseName("只响应调试群组的消息", "核心", "调试模式下机器人是否只响应调试群组的消息")]
        public bool OnlyReplyDebugGroup { get; set; } = false;

        /// <summary>
        /// 调试模式下是否只响应机器人管理员的消息
        /// </summary>
        [PropertyChineseName("只响应来自机器人管理员的消息", "核心", "调试模式下机器人是否只响应来自机器人管理员的消息")]
        public bool DebugReplyAdminOnly { get; set; } = false;

        /// <summary>
        /// 允许Windows系统使用浏览器执行Http请求
        /// </summary>
        [PropertyChineseName("允许调用浏览器执行Http请求", "核心", "是否允许Windows系统下使用Chrome浏览器执行Http请求")]
        public bool HttpRequestByWebBrowser { get; set; } = false;

        /// <summary>
        /// 图片外链路由替换 0:不替换  1:替换为c2cpicdw.qpic.cn/offpic_new  2:替换为gchat.qpic.cn/gchatpic_new
        /// </summary>
        [PropertyChineseName("图片外链路由替换", "核心", "腾讯QQ群图片外链路由地址替换")]
        public int ReplaceImgRoute { get; set; } = 2;

        /// <summary>
        /// Pixiv代理地址
        /// </summary>
        [PropertyChineseName("Pixiv代理地址", "核心")]
        public string PixivProxy { get; set; } = "pixiv.re";

        /// <summary>
        /// Pixiv使用Id路由替代日期路由
        /// </summary>
        [PropertyChineseName("Pixiv使用Id路由替代日期路由", "核心", "加载速度比较快，但有API速率限制")]
        public bool ReplacePixivDateToIdRoute { get; set; } = false;

        /// <summary>
        /// 所有图片下载到本地再发送文件
        /// </summary>
        [PropertyChineseName("所有图片下载到本地再发送文件", "核心")]
        public bool SendImageByFile { get; set; } = false;

        #region -- 腾讯云相关属性 --
        /// <summary>
        /// 是否接入腾讯云AI鉴黄
        /// </summary>
        [PropertyChineseName("接入腾讯云鉴黄", "核心")]
        public bool CheckPornEnabled { get; set; } = false;

        /// <summary>
        /// 腾讯云APPID
        /// </summary>
        [PropertyChineseName("腾讯云APPID", "核心")]
        public string TencentCloudAPPID { get; set; } = string.Empty;

        /// <summary>
        /// 腾讯云CloudRegion
        /// </summary>
        [PropertyChineseName("腾讯云Region", "核心")]
        public string TencentCloudRegion { get; set; } = string.Empty;

        /// <summary>
        /// 腾讯云SecretId
        /// </summary>
        [PropertyChineseName("腾讯云SecretId", "核心")]
        public string TencentCloudSecretId { get; set; } = string.Empty;

        /// <summary>
        /// 腾讯云SecretKey
        /// </summary>
        [PropertyChineseName("腾讯云SecretKey", "核心")]
        public string TencentCloudSecretKey { get; set; } = string.Empty;

        /// <summary>
        /// 腾讯云桶名称
        /// </summary>
        [PropertyChineseName("腾讯云Bucket", "核心")]
        public string TencentCloudBucket { get; set; } = string.Empty;

        #endregion -- 腾讯云相关属性 --

        /// <summary>
        /// 是否启用自动连接到机器人平台
        /// </summary>
        [PropertyChineseName("自动连接到机器人平台", "核心", "是否在启用机器人后自动连接到机器人平台")]
        public bool AutoConnectEnabled { get; set; } = false;

        /// <summary>
        /// 自动连接的平台
        /// </summary>
        [PropertyChineseName("自动连接平台", "核心", "选择自动连接到的平台, 0 = Mirai-Api-Http, 1 = CqHttp")]
        public int AutoConnectProtocol { get; set; } = 0;

        /// <summary>
        /// 连接前延时
        /// </summary>
        [PropertyChineseName("连接前延时", "核心", "机器人启动后等待多少秒后连接机器人平台(用于等待机器人平台启动)")]
        public int AutoConnectDelay { get; set; } = 5;

        [PropertyChineseName("仅在指定时段工作", "核心")]
        public bool WorkingTimeEnabled { get; set; } = false;

        [PropertyChineseName("工作时间 从", "核心", "时")]
        public int WorkingTimeFromHour { get; set; } = 0;

        [PropertyChineseName("工作时间 从", "核心", "分")]
        public int WorkingTimeFromMinute { get; set; } = 0;

        [PropertyChineseName("工作时间 到", "核心", "时")]
        public int WorkingTimeToHour { get; set; } = 0;

        [PropertyChineseName("工作时间 到", "核心", "分")]
        public int WorkingTimeToMinute { get; set; } = 0;

        /// <summary>
        /// 搜图和色图把文字消息和图片消息拆分开（对于私聊含有pixiv发不出去的问题）
        /// </summary>
        [PropertyChineseName("搜图和色图把文字消息和图片消息拆分开", "核心")]
        public bool SplitTextAndImageMessage { get; set; } = true;

        #endregion -- 核心配置项 --

        #region -- 搜图配置项 --

        /// <summary>
        /// 是否启用搜图功能
        /// </summary>
        [PropertyChineseName("启用搜图功能", "搜图")]
        public bool SearchEnabled { get; set; } = true;

        /// <summary>
        /// 私聊时是否自动搜图
        /// </summary>
        [PropertyChineseName("私聊时自动搜图", "搜图")]
        public bool PmAutoSearch { get; set; } = true;

        /// <summary>
        /// 搜图是否使用代理
        /// </summary>
        [PropertyChineseName("搜图 使用代理", "搜图")]
        public bool SearchUseProxy { get; set; } = false;

        /// <summary>
        /// 是否发送缩略图
        /// </summary>
        [PropertyChineseName("发送缩略图", "搜图")]
        public bool SearchSendThuImage { get; set; } = true;

        #region -- TraceMoe --

        /// <summary>
        /// 是否启用TraceMoe搜番
        /// </summary>
        [PropertyChineseName("启用 TraceMoe 搜番", "搜图")]
        public bool SearchEnabledTraceMoe { get; set; } = true;

        /// <summary>
        /// TraceMoe搜图相似度大于此数值时发送搜番结果
        /// </summary>
        [PropertyChineseName("TraceMoe 发送阈值", "搜图")]
        public int TraceMoeSendThreshold { get; set; } = 87;

        /// <summary>
        /// TraceMoe搜番结果为里番时是否发送缩略图
        /// </summary>
        [PropertyChineseName("TraceMoe 发送里番缩略图", "搜图", "TraceMoe搜番结果为里番时是否发送缩略图")]
        public bool TraceMoeSendAdultThuImg { get; set; } = false;

        #endregion -- TraceMoe --

        #region -- SauceNAO --

        /// <summary>
        /// 是否启用SauceNAO搜图
        /// </summary>
        [PropertyChineseName("启用 SauceNAO 搜图", "搜图")]
        public bool SearchEnabledSauceNAO { get; set; } = true;

        /// <summary>
        /// SauceNAO在Windows系统下时SauceNAO优先以浏览器进行请求(腾讯云轻量403问题)
        /// </summary>
        [PropertyChineseName("SauceNAO 使用爬虫而非API", "搜图")]
        public bool SauceNAORequestByWebBrowser { get; set; } = false;

        /// <summary>
        /// SauceNAO Api-Key
        /// </summary>
        [PropertyChineseName("SauceNAO Api-Key", "搜图")]
        public HashSet<string> SauceNAOApiKey { get; set; } = new HashSet<string>();

        /// <summary>
        /// 是否SauceNAO搜图按相似度倒序排序
        /// </summary>
        [PropertyChineseName("按相似度排序", "搜图")]
        public bool SearchSauceNAOSortByDesc { get; set; } = false;

        /// <summary>
        /// SauceNAO 低相似度阈值
        /// </summary>
        [PropertyChineseName("SauceNAO 低相似度阈值", "搜图", "低于此相似度时不会发送缩略图")]
        public int SearchSauceNAOLowSimilarity { get; set; } = 60;

        /// <summary>
        /// 是否SauceNAO搜图发送Pixiv原图
        /// </summary>
        [PropertyChineseName("SauceNAO 搜图结果为 Pixiv 地址时发送原图", "搜图")]
        public bool SearchSauceNAOSendPixivOriginalPicture { get; set; } = true;

        /// <summary>
        /// SauceNAO 高相似度阈值
        /// </summary>
        [PropertyChineseName("SauceNAO 高相似度阈值", "搜图", "高于此相似度时不会使用ASCII2D搜索")]
        public int SearchSauceNAOHighSimilarity { get; set; } = 90;

        /// <summary>
        /// SauceNAO 相似度低于阈值返回消息
        /// </summary>
        [PropertyChineseName("SauceNAO 低于相似度阈值回复语", "搜图")]
        public string SearchSauceNAOLowSimilarityReply { get; set; } = "相似度低于<SauceNAO 低相似度阈值>%，缩略图不予显示。";

        #endregion -- SauceNAO --

        #region -- ASCII2D --

        /// <summary>
        /// 是否启用ASCII2D搜图
        /// </summary>
        [PropertyChineseName("启用 ASCII2D 搜索", "搜图")]
        public bool SearchEnabledASCII2D { get; set; } = true;

        /// <summary>
        /// 在Windows系统下时ASCII2D优先以浏览器进行请求(以应对近期403问题)
        /// </summary>
        [PropertyChineseName("ASCII2D 优先使用浏览器进行 Http 请求", "搜图")]
        public bool ASCII2DRequestByWebBrowser { get; set; } = true;

        /// <summary>
        /// ASCII2D显示结果数量
        /// </summary>
        [PropertyChineseName("ASCII2D 显示结果数量", "搜图")]
        public int SearchShowASCII2DCount { get; set; } = 1;

        #endregion -- ASCII2D --

        #region -- Iqdb --

        #region -- Iqdb anime --

        /// <summary>
        /// 是否启用Iqdb搜图
        /// </summary>
        [PropertyChineseName("启用 Iqdb 搜索", "搜图")]
        public bool SearchEnabledIqdb { get; set; } = true;

        #endregion -- Iqdb anime --

        #region -- 3dIqdb --

        /// <summary>
        /// 是否启用3dIqdb搜车
        /// </summary>
        [PropertyChineseName("启用 3d Iqdb 搜索", "搜图")]
        public bool SearchEnabled3dIqdb { get; set; } = true;

        #endregion -- 3dIqdb --

        /// <summary>
        /// Iqdb 是否发送标签
        /// </summary>
        [PropertyChineseName("Iqdb 是否发送标签", "搜图")]
        public bool SearchIqdbSendTags { get; set; } = false;

        /// <summary>
        /// Iqdb 只发送分级为安全的缩略图
        /// </summary>
        [PropertyChineseName("Iqdb 只发送分级为安全的缩略图", "搜图")]
        public bool SearchIqdbMustSafe { get; set; } = true;

        /// <summary>
        /// Iqdb 相似度阈值
        /// </summary>
        [PropertyChineseName("Iqdb 相似度阈值", "搜图")]
        public int SearchIqdbSimilarity { get; set; } = 60;

        /// <summary>
        /// Iqdb 相似度低于阈值返回消息
        /// </summary>
        [PropertyChineseName("Iqdb 低于相似度阈值回复语", "搜图")]
        public string SearchIqdbSimilarityReply { get; set; } = "相似度低于<Iqdb 相似度阈值>%，缩略图不予显示。";

        #endregion -- Iqdb --

        /// <summary>
        /// 开启连续搜图命令(正则表达式)
        /// </summary>
        [PropertyChineseName("开启连续搜图模式命令", "搜图")]
        public string SearchModeOnCmd { get; set; } = "<机器人名称>搜[图圖図]";

        /// <summary>
        /// 开启连续搜番命令(正则表达式)
        /// </summary>
        [PropertyChineseName("开启连续搜番模式命令", "搜图")]
        public string SearchAnimeModeOnCmd { get; set; } = "<机器人名称>搜[图圖図]";

        /// <summary>
        /// 开启连续搜车命令(正则表达式)
        /// </summary>
        [PropertyChineseName("开启连续搜车模式命令", "搜图")]
        public string Search3DModeOnCmd { get; set; } = "<机器人名称>搜[车車]?";

        /// <summary>
        /// 开启连续搜图功能返回消息
        /// </summary>
        [PropertyChineseName("进入连续搜图模式回复语", "搜图")]
        public string SearchModeOnReply { get; set; } = "了解～请发送图片吧！支持批量噢！\r\n如想退出搜索模式请发送“谢谢<机器人名称>”";

        /// <summary>
        /// 已在连续搜图模式下返回消息
        /// </summary>
        [PropertyChineseName("已进入连续搜图模式回复语", "搜图")]
        public string SearchModeAlreadyOnReply { get; set; } = "您已经在搜图模式下啦！\r\n如想退出搜索模式请发送“谢谢<机器人名称>”";

        /// <summary>
        /// 发起搜索时的回复语(正在搜索但未搜索完毕)
        /// </summary>
        [PropertyChineseName("正在搜索回复语", "搜图")]
        public string SearchingReply { get; set; } = string.Empty;

        /// <summary>
        /// 关闭连续搜图命令(正则表达式)
        /// </summary>
        [PropertyChineseName("退出连续搜图模式命令", "搜图")]
        public string SearchModeOffCmd { get; set; } = "[谢謝][谢謝]<机器人名称>";

        /// <summary>
        /// 连续搜图超时返回消息
        /// </summary>
        [PropertyChineseName("连续搜图模式超时回复语", "搜图")]
        public string SearchModeTimeOutReply { get; set; } = "由于超时，已为您自动退出搜图模式，以后要记得说“谢谢<机器人名称>”来退出搜图模式噢";

        /// <summary>
        /// 退出连续搜图功能返回消息
        /// </summary>
        [PropertyChineseName("退出连续搜图模式回复语", "搜图")]
        public string SearchModeOffReply { get; set; } = "不用谢!(<ゝω・)☆";

        /// <summary>
        /// 已经退出连续搜图功能返回消息
        /// </summary>
        [PropertyChineseName("已退出连续搜图模式回复语", "搜图")]
        public string SearchModeAlreadyOffReply { get; set; } = "虽然不知道为什么谢我, 但是还请注意补充营养呢(｀・ω・´)";

        /// <summary>
        /// 没有搜索到结果返回消息
        /// </summary>
        [PropertyChineseName("没有搜索到地址回复语", "搜图")]
        public string SearchNoResultReply { get; set; } = "<搜索类型>没有搜到该图片的地址o(╥﹏╥)o";

        /// <summary>
        /// 搜索过程中发生异常返回消息
        /// </summary>
        [PropertyChineseName("搜索错误回复语", "搜图")]
        public string SearchErrorReply { get; set; } = "<搜索类型>搜索失败_(:3」∠)_";

        /// <summary>
        /// 下载缩略图失败时追加回复
        /// </summary>
        [PropertyChineseName("下载缩略图失败时追加回复", "搜图")]
        public string SearchDownloadThuImageFailReply { get; set; } = "缩略图下载失败。";

        /// <summary>
        /// 搜图结果以合并转发的方式发送
        /// </summary>
        [PropertyChineseName("搜图结果以合并转发的方式发送", "搜图")]
        public bool SearchSendByForward { get; set; } = false;

        /// <summary>
        /// 是否在搜图功能上启用鉴黄
        /// </summary>
        [PropertyChineseName("搜图 启用鉴黄", "搜图")]
        public bool SearchCheckPornEnabled { get; set; } = false;

        /// <summary>
        /// 搜图功能鉴黄不通过返回消息
        /// </summary>
        [PropertyChineseName("搜图 鉴黄不通过回复语", "搜图")]
        public string SearchCheckPornIllegalReply { get; set; } = "AI鉴黄不通过，缩略图不予显示。";

        /// <summary>
        /// 搜图功能鉴黄发生异常返回消息
        /// </summary>
        [PropertyChineseName("搜图 鉴黄错误回复语", "搜图")]
        public string SearchCheckPornErrorReply { get; set; } = "AI鉴黄发生错误，缩略图不予显示。<错误信息>";

        #endregion -- 搜图配置项 --

        #region -- 下载原图配置项 --

        /// <summary>
        /// 是否启用下载原图
        /// </summary>
        [PropertyChineseName("启用按ID下载Pixiv原图功能", "搜图")]
        public bool OriginalPictureEnabled { get; set; } = true;

        /// <summary>
        /// 下载原图命令
        /// </summary>
        [PropertyChineseName("下载原图 命令", "搜图")]
        public string OriginalPictureCommand { get; set; } = "<机器人名称>下[載载][Pp]([Ii][Xx][Ii][Vv]|站)原[圖图][:：]";

        /// <summary>
        /// 下载原图是否使用代理
        /// </summary>
        [PropertyChineseName("下载原图 使用代理", "搜图")]
        public bool OriginalPictureUseProxy { get; set; } = false;

        /// <summary>
        /// 开始下载原图回复语
        /// </summary>
        [PropertyChineseName("下载原图 开始下载回复语", "搜图")]
        public string OriginalPictureDownloadingReply { get; set; } = "正在下载，请稍候...";

        /// <summary>
        /// 是否在下载原图功能上启用鉴黄
        /// </summary>
        [PropertyChineseName("下载原图 启用鉴黄", "搜图")]
        public bool OriginalPictureCheckPornEnabled { get; set; } = false;

        /// <summary>
        /// 下载原图功能上鉴黄不通过时做以下动作: 0.以合并转发的方式发送原图 1.不做任何事 2.回复设置的语句
        /// </summary>
        [PropertyChineseName("下载原图 鉴黄不通过时", "搜图", "0 = 以合并转发的方式发送原图 1 = 不做任何事 2 = 回复设置的语句")]
        public int OriginalPictureCheckPornEvent { get; set; } = 2;

        /// <summary>
        /// 下载原图功能鉴黄不通过返回消息
        /// </summary>
        [PropertyChineseName("下载原图 鉴黄不通过回复语", "搜图")]
        public string OriginalPictureCheckPornIllegalReply { get; set; } = "AI鉴黄不通过。";
        /// <summary>
        /// 下载原图功能鉴黄错误返回消息
        /// </summary>
        [PropertyChineseName("下载原图 鉴黄错误回复语", "搜图")]
        public string OriginalPictureCheckPornErrorReply { get; set; } = "AI鉴黄发生错误。<错误信息>";

        #endregion -- 下载原图配置项 --

        #region -- 翻译配置项 --

        /// <summary>
        /// 是否启用翻译功能
        /// </summary>
        [PropertyChineseName("启用翻译功能", "翻译")]
        public bool TranslateEnabled { get; set; } = true;

        /// <summary>
        /// 翻译引擎
        /// </summary>
        [PropertyChineseName("翻译引擎", "翻译", "YouDao = 有道(爬虫方式), YouDaoApi = 有道Api, BaiduApi = 百度Api, TencentApi = 腾讯云Api, Google3rdPartyApi = 第三方谷歌Api")]
        public TranslateEngine TranslateEngineType { get; set; } = TranslateEngine.YouDao;

        /// <summary>
        /// 翻译是否使用代理
        /// </summary>
        [PropertyChineseName("翻译 使用代理", "翻译")]
        public bool TranslateUseProxy { get; set; } = false;

        /// <summary>
        /// 云翻译接口的APP ID
        /// </summary>
        [PropertyChineseName("翻译接口APPID", "翻译")]
        public string? TranslateAPPID { get; set; } = string.Empty;

        /// <summary>
        /// 云翻译接口的密钥
        /// </summary>
        [PropertyChineseName("翻译接口密钥", "翻译")]
        public string? TranslateAPPKey { get; set; } = string.Empty;

        /// <summary>
        /// 翻译为中文命令(正则表达式)
        /// </summary>
        [PropertyChineseName("翻译为中文命令", "翻译", "支持正则表达式")]
        public string TranslateToChineseCMD { get; set; } = "<机器人名称>翻[译譯][:：]";

        /// <summary>
        /// 翻译为指定语言命令(正则表达式)
        /// </summary>
        [PropertyChineseName("翻译为指定语言命令", "翻译", "支持正则表达式")]
        public string TranslateToCMD { get; set; } = "<机器人名称>翻[译譯][成为為到至](?<to>.+[语語文])[:：]";

        /// <summary>
        /// 从指定语言翻译为指定语言命令(正则表达式)
        /// </summary>
        [PropertyChineseName("翻译为指定语言命令", "翻译", "支持正则表达式, 使用有道翻译时该属性没有作用")]
        public string TranslateFromToCMD { get; set; } = "<机器人名称>[把从從自从](?<from>.+[语語文])翻[译譯][成为為到至](?<to>.+[语語文])[:：]";

        /// <summary>
        /// 自动翻译群友QQ
        /// </summary>
        [PropertyChineseName("自动翻译群友QQ号", "翻译", "自动翻译指定群友的全部消息")]
        public HashSet<long> AutoTranslateGroupMembersQQ { get; set; } = new HashSet<long>();

        #endregion -- 翻译配置项 --

        #region -- 色图配置项 --

        /// <summary>
        /// 色图完整命令(正则表达式)
        /// </summary>
        [PropertyChineseName("色图命令", "色图", "支持正则表达式")]
        public string HPictureCmd { get; set; } = IBotConfig.DefaultHPictureCmd;

        /// <summary>
        /// 色图是否使用代理
        /// </summary>
        [PropertyChineseName("色图 使用代理", "色图")]
        public bool HPictureUseProxy { get; set; } = false;

        /// <summary>
        /// 启用的色图图库
        /// </summary>
        [PropertyChineseName("色图图库", "色图", "启用的色图图库")]
        public HashSet<PictureSource> EnabledHPictureSource { get; set; } = new HashSet<PictureSource>();

        /// <summary>
        /// 使用浏览器请求Lolicon Api
        /// </summary>
        [PropertyChineseName("使用浏览器请求Lolicon", "色图", "解决 Windows Server 2012 R2 不支持 TLS 1.3 协议导致 SSL 错误问题")]
        public bool HPictureLoliconRequestByWebBrowser { get; set; } = false;

        /// <summary>
        /// 使用插件请求Lolicon（取决于安装的插件）
        /// </summary>
        [PropertyChineseName("使用插件请求Lolicon", "色图", "解决 Windows Server 2012 R2 不支持 TLS 1.3 协议导致 SSL 错误问题")]
        public bool HPictureLoliconRequestByPlugin { get; set; }

        /// <summary>
        /// 反和谐（仅限Windows，且需要先开启 所有图片下载到本地发送文件 功能）
        /// </summary>
        [PropertyChineseName("反和谐", "色图", "仅限Windows，且需要先开启 所有图片下载到本地发送文件 功能")]
        public bool HPictureAntiShielding { get; set; } = false;

        /// <summary>
        /// 自定义色图命令
        /// </summary>
        [PropertyChineseName("自定义色图命令", "色图")]
        public HashSet<string> HPictureUserCmd { get; set; } = new HashSet<string>();

        /// <summary>
        /// 白名单群
        /// </summary>
        [PropertyChineseName("色图 屏蔽关键词", "色图")]
        public HashSet<string> HPictureShieldingWords { get; set; } = new HashSet<string>();

        /// <summary>
        /// 白名单群
        /// </summary>
        [PropertyChineseName("色图 白名单群", "色图")]
        public HashSet<long> HPictureWhiteGroup { get; set; } = new HashSet<long>();

        /// <summary>
        /// 是否仅限白名单使用色图
        /// </summary>
        [PropertyChineseName("色图 仅限白名单", "色图")]
        public bool HPictureWhiteOnly { get; set; } = false;

        /// <summary>
        /// 是否启用R-18
        /// </summary>
        [PropertyChineseName("色图 允许R-18", "色图")]
        public bool HPictureAllowR18 { get; set; } = true;

        /// <summary>
        /// 是否仅限白名单使用R-18
        /// </summary>
        [PropertyChineseName("色图 R-18仅限白名单", "色图")]
        public bool HPictureR18WhiteOnly { get; set; } = true;

        /// <summary>
        /// 允许私聊
        /// </summary>
        [PropertyChineseName("色图 允许私聊", "色图")]
        public bool HPictureAllowPM { get; set; } = true;

        /// <summary>
        /// 冷却时间
        /// </summary>
        [PropertyChineseName("色图 群冷却时间", "色图", "s")]
        public int HPictureCD { get; set; } = 0;

        /// <summary>
        /// 次数限制
        /// </summary>
        [PropertyChineseName("色图 群次数限制", "色图")]
        public int HPictureLimit { get; set; } = 0;

        /// <summary>
        /// 撤回时间
        /// </summary>
        [PropertyChineseName("色图 群撤回时间", "色图", "s")]
        public int HPictureRevoke { get; set; } = 0;

        /// <summary>
        /// 白名单群冷却时间
        /// </summary>
        [PropertyChineseName("色图 白名单群冷却时间", "色图", "s")]
        public int HPictureWhiteCD { get; set; } = 0;

        /// <summary>
        /// 白名单群撤回时间
        /// </summary>
        [PropertyChineseName("色图 白名单群撤回时间", "色图", "s")]
        public int HPictureWhiteRevoke { get; set; } = 0;

        /// <summary>
        /// 私聊冷却时间
        /// </summary>
        [PropertyChineseName("色图 私聊冷却时间", "色图", "s")]
        public int HPicturePMCD { get; set; } = 0;

        /// <summary>
        /// 私聊撤回时间
        /// </summary>
        [PropertyChineseName("色图 私聊撤回时间", "色图", "s")]
        public int HPicturePMRevoke { get; set; } = 0;

        /// <summary>
        /// 机器人管理员无冷却时间/次数限制
        /// </summary>
        [PropertyChineseName("色图 机器人管理员无限制", "色图")]
        public bool HPictureAdminNoLimit { get; set; } = true;

        /// <summary>
        /// 私聊无冷却时间/次数限制
        /// </summary>
        [PropertyChineseName("色图 私聊无限制", "色图")]
        public bool HPicturePMNoLimit { get; set; } = false;

        /// <summary>
        /// 白名单群无冷却时间/次数限制
        /// </summary>
        [PropertyChineseName("色图 白名单群无限制", "色图")]
        public bool HPictureWhiteNoLimit { get; set; } = true;

        /// <summary>
        /// 色图是否发送作品地址
        /// </summary>
        [PropertyChineseName("色图 发送作品地址", "色图")]
        public bool HPictureSendUrl { get; set; } = true;

        /// <summary>
        /// 色图是否发送图片代理地址
        /// </summary>
        [PropertyChineseName("色图 发送图片代理地址", "色图")]
         public bool HPictureSendProxyUrl { get; set; } = false;

        /// <summary>
        /// 色图是否发送标题和作者
        /// </summary>
        [PropertyChineseName("色图 发送标题和作者", "色图")]
        public bool HPictureSendTitle { get; set; } = true;

        /// <summary>
        /// 色图是否发送标签
        /// </summary>
        [PropertyChineseName("色图 发送标签", "色图")]
        public bool HPictureSendTags { get; set; } = false;

        /// <summary>
        /// 是否以合并转发的方式发送色图
        /// </summary>
        [PropertyChineseName("色图 以合并转发的方式发送", "色图")]
        public bool HPictureSendByForward { get; set; } = false;

        /// <summary>
        /// 开始下载色图时回复
        /// </summary>
        [PropertyChineseName("色图 开始下载色图回复语", "色图")]
        public string HPictureDownloadingReply { get; set; } = "正在查找色图...";

        /// <summary>
        /// 冷却中回复
        /// </summary>
        [PropertyChineseName("色图 冷却时间内回复语", "色图")]
        public string HPictureCDUnreadyReply { get; set; } = "乖，要懂得节制哦，休息一会再冲吧 →_→";

        /// <summary>
        /// 次数用尽回复
        /// </summary>
        [PropertyChineseName("色图 超过次数回复语", "色图")]
        public string HPictureOutOfLimitReply { get; set; } = "今天不要再冲了啦(>_<)";

        /// <summary>
        /// 发生错误回复
        /// </summary>
        [PropertyChineseName("色图 发生错误回复语", "色图")]
        public string HPictureErrorReply { get; set; } = "色图服务器爆炸惹_(:3」∠)_ <错误信息>";

        /// <summary>
        /// 没有结果回复
        /// </summary>
        [PropertyChineseName("色图 没有结果回复语", "色图")]
        public string HPictureNoResultReply { get; set; } = "没有找到符合条件的图ㄟ( ▔, ▔ )ㄏ";

        /// <summary>
        /// 下载失败回复
        /// </summary>
        [PropertyChineseName("色图 图片下载失败回复语", "色图")]
        public string HPictureDownloadFailReply { get; set; } = "图片下载失败o(╥﹏╥)o  <错误信息>";

        /// <summary>
        /// 色图次数限制记录类型
        /// </summary>
        [PropertyChineseName("色图 次数限制记录类型", "色图", "Frequency = 记次, Count = 记张")]
        public LimitType HPictureLimitType { get; set; } = LimitType.Frequency;

        /// <summary>
        /// 一条色图命令最多允许返回多少张色图
        /// </summary>
        [PropertyChineseName("色图 单次请求最大图片数量", "色图", "支持1-20, 不建议超过10, 容易导致无法撤回")]
        public int HPictureOnceMessageMaxImageCount { get; set; } = 10;

        /// <summary>
        /// 是否启用色图功能
        /// </summary>
        [PropertyChineseName("启用色图功能", "色图")]
        public bool HPictureEnabled { get; set; } = true;

        #endregion -- 色图配置项 --

        #region -- 复读配置项 --

        /// <summary>
        /// 是否启用随机复读
        /// </summary>
        [PropertyChineseName("随机复读", "复读")]
        public bool RandomRepeatEnabled { get; set; } = false;

        /// <summary>
        /// 随机复读概率
        /// </summary>
        [PropertyChineseName("随机复读 概率为", "复读", "%")]
        public int RandomRepeatProbability { get; set; } = 1;

        /// <summary>
        /// 是否启用连续复读
        /// </summary>
        [PropertyChineseName("连续复读", "复读")]
        public bool SuccessiveRepeatEnabled { get; set; } = false;

        /// <summary>
        /// 参与连续复读所需的复读次数
        /// </summary>
        [PropertyChineseName("连续复读 次数为", "复读")]
        public int SuccessiveRepeatCount { get; set; } = 3;

        /// <summary>
        /// 是否倒放复读Gif
        /// </summary>
        [PropertyChineseName("倒放Gif", "复读")]
        public bool RewindGifEnabled { get; set; } = true;

        /// <summary>
        /// 倒放复读Gif概率
        /// </summary>
        [PropertyChineseName("倒放Gif 概率为", "复读", "%")]
        public int RewindGifProbability { get; set; } = 50;

        /// <summary>
        /// 是否水平反转复读图片
        /// </summary>
        [PropertyChineseName("水平镜像复读图片", "复读")]
        public bool HorizontalMirrorImageEnabled { get; set; } = true;

        /// <summary>
        /// 水平反转复读图片概率
        /// </summary>
        [PropertyChineseName("水平镜像复读图片 概率为", "复读", "%")]
        public int HorizontalMirrorImageProbability { get; set; } = 50;

        /// <summary>
        /// 是否垂直翻转复读图片
        /// </summary>
        [PropertyChineseName("垂直镜像复读图片", "复读")]
        public bool VerticalMirrorImageEnabled { get; set; } = true;

        /// <summary>
        /// 垂直翻转复读图片概率
        /// </summary>
        [PropertyChineseName("垂直镜像复读图片 概率为", "复读", "%")]
        public int VerticalMirrorImageProbability { get; set; } = 50;

        /// <summary>
        /// 将"我"替换为"你"
        /// </summary>
        [PropertyChineseName("复读时把\"我\"替换为\"你\"", "复读")]
        public bool ReplaceMeToYou { get; set; } = false;

        #endregion -- 复读配置项 --

        #region -- 进退群提醒配置项 --

        /// <summary>
        /// 是否启用新人入群消息
        /// </summary>
        [PropertyChineseName("发送新人入群消息", "进/退群提醒")]
        public bool SendMemberJoinedMessage { get; set; } = true;

        /// <summary>
        /// 是否启用成员退群消息
        /// </summary>
        [PropertyChineseName("发送群员退群消息", "进/退群提醒")]
        public bool SendMemberPositiveLeaveMessage { get; set; } = true;

        /// <summary>
        /// 是否启用成员被踢消息
        /// </summary>
        [PropertyChineseName("发送群员被踢消息", "进/退群提醒")]
        public bool SendMemberBeKickedMessage { get; set; } = true;

        /// <summary>
        /// 新人入群消息
        /// </summary>
        [PropertyChineseName("新人入群消息", "进/退群提醒")]
        public string MemberJoinedMessage { get; set; } = "<@成员QQ> 欢迎新大佬，群地位-1 (ΩДΩ)";

        /// <summary>
        /// 成员退群消息
        /// </summary>
        [PropertyChineseName("群员退群消息", "进/退群提醒")]
        public string MemberPositiveLeaveMessage { get; set; } = "QQ号：<成员QQ> 退出了群，群地位+1 o(╥﹏╥)o";

        /// <summary>
        /// 成员被踢消息
        /// </summary>
        [PropertyChineseName("群员被踢消息", "进/退群提醒")]
        public string MemberBeKickedMessage { get; set; } = " <成员昵称> ( <成员QQ> ) 被 <操作者昵称> 踢了出群，群地位+1 (*^▽^*)";

        #endregion -- 进退群提醒配置项 --

        #region -- 伪造消息配置项 --

        /// <summary>
        /// 是否启用伪造消息功能
        /// </summary>
        [PropertyChineseName("启用伪造消息功能", "伪造消息")]
        public bool ForgeMessageEnabled { get; set; } = true;

        /// <summary>
        /// 伪造消息前缀
        /// </summary>
        [PropertyChineseName("伪造消息命令前缀", "伪造消息")]
        public string ForgeMessageCmdBegin { get; set; } = "<机器人名称>伪造(消息|聊天[记記][录錄])";

        /// <summary>
        /// 伪造消息分行符(分行符前后的内容会分成两条消息)
        /// </summary>
        [PropertyChineseName("伪造消息分行符", "伪造消息")]
        public string ForgeMessageCmdNewLine { get; set; } = @"\r\n";

        /// <summary>
        /// 是否在伪造消息末端追加消息
        /// </summary>
        [PropertyChineseName("伪造消息 在消息末尾追加机器人消息", "伪造消息")]
        public bool ForgeMessageAppendBotMessageEnabled { get; set; } = true;

        /// <summary>
        /// 是否只允许机器人管理员使用伪造消息功能
        /// </summary>
        [PropertyChineseName("伪造消息 仅限机器人管理员可用", "伪造消息")]
        public bool ForgeMessageAdminOnly { get; set; } = false;

        /// <summary>
        /// 机器人管理员使用伪造消息功能时是否不在末端追加消息
        /// </summary>
        [PropertyChineseName("伪造消息 机器人管理员使用时不追加消息", "伪造消息")]
        public bool ForgeMessageAdminDontAppend { get; set; } = true;

        /// <summary>
        /// 追加消息内容
        /// </summary>
        [PropertyChineseName("伪造消息 追加消息内容", "伪造消息")]
        public string ForgeMessageAppendMessage { get; set; } = "此消息为<机器人名称>伪造，仅作娱乐，请勿用于非法用途。";

        /// <summary>
        /// 是否拒绝伪造机器人管理员的消息
        /// </summary>
        [PropertyChineseName("伪造消息 拒绝伪造机器人管理员的消息", "伪造消息")]
        public bool RefuseForgeAdmin { get; set; } = true;

        /// <summary>
        /// 试图伪造机器人管理员消息时的回复语
        /// </summary>
        [PropertyChineseName("伪造消息 试图伪造机器人管理员消息时的回复语", "伪造消息")]
        public string RefuseForgeAdminReply { get; set; } = "你不能让我伪造我主人的消息。";

        /// <summary>
        /// 是否拒绝伪造机器人的消息(如果由机器人管理员发起则不会校验此项目)
        /// </summary>
        [PropertyChineseName("伪造消息 拒绝伪造机器人的消息", "伪造消息", "如果由机器人管理员发起则不会校验此项目")]
        public bool RefuseForgeBot { get; set; } = true;

        /// <summary>
        /// 试图伪造机器人消息时的回复语
        /// </summary>
        [PropertyChineseName("伪造消息 试图伪造机器人消息时的回复语", "伪造消息")]
        public string RefuseForgeBotReply { get; set; } = "你不会以为我会伪造自己的消息吧，不会吧不会吧？";

        #endregion -- 伪造消息配置项 --

        #region -- RSS 配置项 --

        /// <summary>
        /// 是否启用Rss订阅转发
        /// </summary>
        [PropertyChineseName("启用RSS订阅转发", "RSS订阅转发")]
        public bool RssEnabled { get; set; } = false;

        /// <summary>
        /// 多线程并行抓取多个RSS订阅
        /// </summary>
        [PropertyChineseName("并行订阅", "RSS订阅转发")]
        public bool RssParallel { get; set; } = false;

        /// <summary>
        /// RSS是否使用代理
        /// </summary>
        [PropertyChineseName("RSS订阅转发 使用代理", "RSS订阅转发")]
        public bool RssUseProxy { get; set; } = false;

        /// <summary>
        /// 抓取RSS间隔时间(分钟)
        /// </summary>
        [PropertyChineseName("获取内容时间间隔", "RSS订阅转发", "分钟")]
        public double ReadRssInterval { get; set; } = 10.0;

        /// <summary>
        /// 订阅的地址和需要转发到的QQ或群列表
        /// </summary>
        [PropertyChineseName("RSS订阅项", "RSS订阅转发")]
        public HashSet<RssSubscriptionItem>? RssSubscription { get; set; } = null;

        /// <summary>
        /// 获取B站直播封面
        /// </summary>
        [PropertyChineseName("获取B站直播间封面", "RSS订阅转发")]
        public bool RssSendLiveCover { get; set; } = true;

        #endregion -- RSS 配置项 --
    }
}