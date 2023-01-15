using GreenOnions.Interface.Configs.Enums;
using GreenOnions.Interface.Items;

namespace GreenOnions.Interface.Configs
{
    /// <summary>
    /// 机器人配置项
    /// </summary>
    public interface IBotConfig
    {
        #region -- 核心配置项 --

        public string ProxyUrl { get; }

        /// <summary>
        /// 日志等级 0 = 信息， 1 = 警告， 2 = 错误
        /// </summary>
        public int LogLevel { get; }

        /// <summary>
        /// QQ号(该属性不该被主动设置，由GreenOnions连接平台时自动赋值)
        /// </summary>
        [PropertyChineseName("机器人QQ", "核心")]
        public long QQId { get; }

        /// <summary>
        /// 连接的机器人平台IP(该属性不该被主动设置，由GreenOnions连接平台时自动赋值)
        /// </summary>
        [PropertyChineseName("IP", "核心", "连接的机器人平台IP地址")]
        public string IP { get; }

        /// <summary>
        /// 连接的机器人平台端口号(该属性不该被主动设置，由GreenOnions连接平台时自动赋值)
        /// </summary>
        [PropertyChineseName("Port", "核心", "连接的机器人平台端口号")]
        public ushort Port { get; }

        /// <summary>
        /// 连接的机器人平台令牌(该属性不该被主动设置，由GreenOnions连接平台时自动赋值)
        /// </summary>
        [PropertyChineseName("VerifyKey/Access-Token", "核心", "连接的机器人平台令牌")]
        public string VerifyKey { get; }

        /// <summary>
        /// 机器人名称
        /// </summary>
        [PropertyChineseName("机器人名称", "核心")]
        public string BotName { get; }

        /// <summary>
        /// 机器人管理员QQ
        /// </summary>
        [PropertyChineseName("机器人管理员QQ", "核心")]
        public HashSet<long> AdminQQ { get; }

        /// <summary>
        /// 黑名单组
        /// </summary>
        [PropertyChineseName("群黑名单", "核心")]
        public HashSet<long> BannedGroup { get; }

        /// <summary>
        /// 黑名单用户
        /// </summary>
        [PropertyChineseName("用户黑名单", "核心")]
        public HashSet<long> BannedUser { get; }

        /// <summary>
        /// 是否自动退出被禁言的群
        /// </summary>
        [PropertyChineseName("自动退出被禁言的群", "核心")]
        public bool LeaveGroupAfterBeMushin { get; }

        /// <summary>
        /// 是否启用消息中转功能
        /// </summary>
        [PropertyChineseName("启用消息中转", "核心", "收到私聊消息且没命中任何命令时转发给机器人管理员")]
        public bool MessageTransferEnabled { get; }

        /// <summary>
        /// 是否启用调试模式
        /// </summary>
        [PropertyChineseName("调试模式", "核心")]
        public bool DebugMode { get; }

        /// <summary>
        /// 调试群组
        /// </summary>
        [PropertyChineseName("调试群组", "核心")]
        public HashSet<long> DebugGroups { get; }

        /// <summary>
        /// 调试模式下是否只响应指定群组的消息
        /// </summary>
        [PropertyChineseName("只响应调试群组的消息", "核心", "调试模式下机器人是否只响应调试群组的消息")]
        public bool OnlyReplyDebugGroup { get; }

        /// <summary>
        /// 调试模式下是否只响应机器人管理员的消息
        /// </summary>
        [PropertyChineseName("只响应来自机器人管理员的消息", "核心", "调试模式下机器人是否只响应来自机器人管理员的消息")]
        public bool DebugReplyAdminOnly { get; }

        /// <summary>
        /// 允许Windows系统使用浏览器执行Http请求
        /// </summary>
        [PropertyChineseName("允许调用浏览器执行Http请求", "核心", "是否允许Windows系统下使用Chrome浏览器执行Http请求")]
        public bool HttpRequestByWebBrowser { get; }

        /// <summary>
        /// 图片外链路由替换 0:不替换  1:替换为c2cpicdw.qpic.cn/offpic_new  2:替换为gchat.qpic.cn/gchatpic_new
        /// </summary>
        [PropertyChineseName("图片外链路由替换", "核心", "腾讯QQ群图片外链路由地址替换")]
        public int ReplaceImgRoute { get; }

        /// <summary>
        /// Pixiv代理地址
        /// </summary>
        [PropertyChineseName("Pixiv代理地址", "核心")]
        public string PixivProxy { get; }

        /// <summary>
        /// 保留所有下载的图片用于缓存
        /// </summary>
        [PropertyChineseName("保留所有下载的图片用于缓存", "核心")]
        public bool DownloadImage4Caching { get; }

        /// <summary>
        /// 所有图片下载到本地再发送文件
        /// </summary>
        [PropertyChineseName("所有图片下载到本地再发送文件", "核心")]
        public bool SendImageByFile { get; }

        #region -- 腾讯云相关属性 --
        /// <summary>
        /// 是否接入腾讯云AI鉴黄
        /// </summary>
        [PropertyChineseName("接入腾讯云鉴黄", "核心")]
        public bool CheckPornEnabled { get; }

        /// <summary>
        /// 腾讯云APPID
        /// </summary>
        [PropertyChineseName("腾讯云APPID", "核心")]
        public string TencentCloudAPPID { get; }

        /// <summary>
        /// 腾讯云CloudRegion
        /// </summary>
        [PropertyChineseName("腾讯云Region", "核心")]
        public string TencentCloudRegion { get; }

        /// <summary>
        /// 腾讯云SecretId
        /// </summary>
        [PropertyChineseName("腾讯云SecretId", "核心")]
        public string TencentCloudSecretId { get; }

        /// <summary>
        /// 腾讯云SecretKey
        /// </summary>
        [PropertyChineseName("腾讯云SecretKey", "核心")]
        public string TencentCloudSecretKey { get; }

        /// <summary>
        /// 腾讯云桶名称
        /// </summary>
        [PropertyChineseName("腾讯云Bucket", "核心")]
        public string TencentCloudBucket { get; }

        #endregion -- 腾讯云相关属性 --

        /// <summary>
        /// 是否启用自动连接到机器人平台
        /// </summary>
        [PropertyChineseName("自动连接到机器人平台", "核心", "是否在启用机器人后自动连接到机器人平台")]
        public bool AutoConnectEnabled { get; }

        /// <summary>
        /// 自动连接的平台
        /// </summary>
        [PropertyChineseName("自动连接平台", "核心", "选择自动连接到的平台, 0 = Mirai-Api-Http, 1 = CqHttp")]
        public int AutoConnectProtocol { get; }

        /// <summary>
        /// 连接前延时
        /// </summary>
        [PropertyChineseName("连接前延时", "核心", "机器人启动后等待多少秒后连接机器人平台(用于等待机器人平台启动)")]
        public int AutoConnectDelay { get; }

        /// <summary>
        /// 是否启用仅在指定时段工作
        /// </summary>
        [PropertyChineseName("仅在指定时段工作", "核心")]
        public bool WorkingTimeEnabled { get; }

        /// <summary>
        /// 指定时段工作的工作时间从哪个小时开始
        /// </summary>
        [PropertyChineseName("工作时间 从", "核心", "时")]
        public int WorkingTimeFromHour { get; }

        /// <summary>
        ///  指定时段工作的工作时间从哪分钟开始
        /// </summary>
        [PropertyChineseName("工作时间 从", "核心", "分")]
        public int WorkingTimeFromMinute { get; }

        /// <summary>
        /// 指定时段工作的工作时间到哪个小时结束
        /// </summary>
        [PropertyChineseName("工作时间 到", "核心", "时")]
        public int WorkingTimeToHour { get; }

        /// <summary>
        /// 指定时段工作的工作时间到哪分钟结束
        /// </summary>
        [PropertyChineseName("工作时间 到", "核心", "分")]
        public int WorkingTimeToMinute { get; }

        /// <summary>
        /// 搜图和色图把文字消息和图片消息拆分开（对于私聊含有pixiv发不出去的问题）
        /// </summary>
        [PropertyChineseName("搜图和色图把文字消息和图片消息拆分开", "核心")]
        public bool SplitTextAndImageMessage { get; }
        #endregion -- 核心配置项 --

        #region -- 搜图配置项 --

        /// <summary>
        /// 是否启用搜图功能
        /// </summary>
        [PropertyChineseName("启用搜图功能", "搜图")]
        public bool SearchEnabled { get; }

        /// <summary>
        /// 私聊时是否自动搜图
        /// </summary>
        [PropertyChineseName("私聊时自动搜图", "搜图")]
        public bool PmAutoSearch { get; }

        /// <summary>
        /// 是否发送缩略图
        /// </summary>
        [PropertyChineseName("发送缩略图", "搜图")]
        public bool SearchSendThuImage { get; }

        #region -- TraceMoe --

        /// <summary>
        /// 是否启用TraceMoe搜番
        /// </summary>
        [PropertyChineseName("启用 TraceMoe 搜番", "搜图")]
        public bool SearchEnabledTraceMoe { get; }

        /// <summary>
        /// TraceMoe搜图相似度大于此数值时发送搜番结果
        /// </summary>
        [PropertyChineseName("TraceMoe 发送阈值", "搜图")]
        public int TraceMoeSendThreshold { get; }

        /// <summary>
        /// TraceMoe搜番结果为里番时是否发送缩略图
        /// </summary>
        [PropertyChineseName("TraceMoe 发送里番缩略图", "搜图", "TraceMoe搜番结果为里番时是否发送缩略图")]
        public bool TraceMoeSendAdultThuImg { get; }

        #endregion -- TraceMoe --

        #region -- SauceNAO --

        /// <summary>
        /// 是否启用SauceNAO搜图
        /// </summary>
        [PropertyChineseName("启用 SauceNAO 搜图", "搜图")]
        public bool SearchEnabledSauceNAO { get; }

        /// <summary>
        /// SauceNAO在Windows系统下时SauceNAO优先以浏览器进行请求(腾讯云轻量403问题)
        /// </summary>
        [PropertyChineseName("SauceNAO 使用爬虫而非API", "搜图")]
        public bool SauceNAORequestByWebBrowser { get; }

        /// <summary>
        /// SauceNAO Api-Key
        /// </summary>
        [PropertyChineseName("SauceNAO Api-Key", "搜图")]
        public HashSet<string> SauceNAOApiKey { get; }

        /// <summary>
        /// 是否SauceNAO搜图按相似度倒序排序
        /// </summary>
        [PropertyChineseName("按相似度排序", "搜图")]
        public bool SearchSauceNAOSortByDesc { get; }

        /// <summary>
        /// SauceNAO 低相似度阈值
        /// </summary>
        [PropertyChineseName("SauceNAO 低相似度阈值", "搜图", "低于此相似度时不会发送缩略图")]
        public int SearchSauceNAOLowSimilarity { get; }

        /// <summary>
        /// 是否SauceNAO搜图发送Pixiv原图
        /// </summary>
        [PropertyChineseName("SauceNAO 搜图结果为 Pixiv 地址时发送原图", "搜图")]
        public bool SearchSauceNAOSendPixivOriginalPicture { get; }

        /// <summary>
        /// SauceNAO 高相似度阈值
        /// </summary>
        [PropertyChineseName("SauceNAO 高相似度阈值", "搜图", "高于此相似度时不会使用ASCII2D搜索")]
        public int SearchSauceNAOHighSimilarity { get; }

        /// <summary>
        /// SauceNAO 相似度低于阈值返回消息
        /// </summary>
        [PropertyChineseName("SauceNAO 低于相似度阈值回复语", "搜图")]
        public string SearchSauceNAOLowSimilarityReply { get; }

        #endregion -- SauceNAO --

        #region -- ASCII2D --

        /// <summary>
        /// 是否启用ASCII2D搜图
        /// </summary>
        [PropertyChineseName("启用 ASCII2D 搜索", "搜图")]
        public bool SearchEnabledASCII2D { get; }

        /// <summary>
        /// 在Windows系统下时ASCII2D优先以浏览器进行请求(以应对近期403问题)
        /// </summary>
        [PropertyChineseName("ASCII2D 优先使用浏览器进行 Http 请求", "搜图")]
        public bool ASCII2DRequestByWebBrowser { get; }

        /// <summary>
        /// ASCII2D显示结果数量
        /// </summary>
        [PropertyChineseName("ASCII2D 显示结果数量", "搜图")]
        public int SearchShowASCII2DCount { get; }

        #endregion -- ASCII2D --

        #region -- Iqdb --

        #region -- Iqdb anime --

        /// <summary>
        /// 是否启用Iqdb搜图
        /// </summary>
        [PropertyChineseName("启用 Iqdb 搜索", "搜图")]
        public bool SearchEnabledIqdb { get; }

        #endregion -- Iqdb anime --

        #region -- 3dIqdb --

        /// <summary>
        /// 是否启用3dIqdb搜车
        /// </summary>
        [PropertyChineseName("启用 3d Iqdb 搜索", "搜图")]
        public bool SearchEnabled3dIqdb { get; }

        #endregion -- 3dIqdb --

        /// <summary>
        /// Iqdb 是否发送标签
        /// </summary>
        [PropertyChineseName("Iqdb 是否发送标签", "搜图")]
        public bool SearchIqdbSendTags { get; }

        /// <summary>
        /// Iqdb 只发送分级为安全的缩略图
        /// </summary>
        [PropertyChineseName("Iqdb 只发送分级为安全的缩略图", "搜图")]
        public bool SearchIqdbMustSafe { get; }

        /// <summary>
        /// Iqdb 相似度阈值
        /// </summary>
        [PropertyChineseName("Iqdb 相似度阈值", "搜图")]
        public int SearchIqdbSimilarity { get; }

        /// <summary>
        /// Iqdb 相似度低于阈值返回消息
        /// </summary>
        [PropertyChineseName("Iqdb 低于相似度阈值回复语", "搜图")]
        public string SearchIqdbSimilarityReply { get; }

        #endregion -- Iqdb --

        /// <summary>
        /// 开启连续搜图命令(正则表达式)
        /// </summary>
        [PropertyChineseName("开启连续搜图模式命令", "搜图")]
        public string SearchModeOnCmd { get; }

        /// <summary>
        /// 开启连续搜番命令(正则表达式)
        /// </summary>
        [PropertyChineseName("开启连续搜番模式命令", "搜图")]
        public string SearchAnimeModeOnCmd { get; }

        /// <summary>
        /// 开启连续搜车命令(正则表达式)
        /// </summary>
        [PropertyChineseName("开启连续搜车模式命令", "搜图")]
        public string Search3DModeOnCmd { get; }

        /// <summary>
        /// 开启连续搜图功能返回消息
        /// </summary>
        [PropertyChineseName("进入连续搜图模式回复语", "搜图")]
        public string SearchModeOnReply { get; }

        /// <summary>
        /// 已在连续搜图模式下返回消息
        /// </summary>
        [PropertyChineseName("已进入连续搜图模式回复语", "搜图")]
        public string SearchModeAlreadyOnReply { get; }

        /// <summary>
        /// 发起搜索时的回复语(正在搜索但未搜索完毕)
        /// </summary>
        [PropertyChineseName("正在搜索回复语", "搜图")]
        public string SearchingReply { get; }

        /// <summary>
        /// 关闭连续搜图命令(正则表达式)
        /// </summary>
        [PropertyChineseName("退出连续搜图模式命令", "搜图")]
        public string SearchModeOffCmd { get; }

        /// <summary>
        /// 连续搜图超时返回消息
        /// </summary>
        [PropertyChineseName("连续搜图模式超时回复语", "搜图")]
        public string SearchModeTimeOutReply { get; }

        /// <summary>
        /// 退出连续搜图功能返回消息
        /// </summary>
        [PropertyChineseName("退出连续搜图模式回复语", "搜图")]
        public string SearchModeOffReply { get; }

        /// <summary>
        /// 已经退出连续搜图功能返回消息
        /// </summary>
        [PropertyChineseName("已退出连续搜图模式回复语", "搜图")]
        public string SearchModeAlreadyOffReply { get; }

        /// <summary>
        /// 没有搜索到结果返回消息
        /// </summary>
        [PropertyChineseName("没有搜索到地址回复语", "搜图")]
        public string SearchNoResultReply { get; }

        /// <summary>
        /// 搜索过程中发生异常返回消息
        /// </summary>
        [PropertyChineseName("搜索错误回复语", "搜图")]
        public string SearchErrorReply { get; }

        /// <summary>
        /// 下载缩略图失败时追加回复
        /// </summary>
        [PropertyChineseName("下载缩略图失败时追加回复", "搜图")]
        public string SearchDownloadThuImageFailReply { get; }

        /// <summary>
        /// 搜图结果以合并转发的方式发送
        /// </summary>
        [PropertyChineseName("搜图结果以合并转发的方式发送", "搜图")]
        public bool SearchSendByForward { get; }

        /// <summary>
        /// 是否在搜图功能上启用鉴黄
        /// </summary>
        [PropertyChineseName("搜图 启用鉴黄", "搜图")]
        public bool SearchCheckPornEnabled { get; }

        /// <summary>
        /// 搜图功能鉴黄不通过返回消息
        /// </summary>
        [PropertyChineseName("搜图 鉴黄不通过回复语", "搜图")]
        public string SearchCheckPornIllegalReply { get; }

        /// <summary>
        /// 搜图功能鉴黄发生异常返回消息
        /// </summary>
        [PropertyChineseName("搜图 鉴黄错误回复语", "搜图")]
        public string SearchCheckPornErrorReply { get; }

        #endregion -- 搜图配置项 --

        #region -- 下载原图配置项 --

        /// <summary>
        /// 是否启用下载原图
        /// </summary>
        [PropertyChineseName("启用按ID下载Pixiv原图功能", "搜图")]
        public bool OriginalPictureEnabled { get; }

        /// <summary>
        /// 下载原图命令
        /// </summary>
        [PropertyChineseName("下载原图 命令", "搜图")]
        public string OriginalPictureCommand { get; }

        /// <summary>
        /// 开始下载原图回复语
        /// </summary>
        [PropertyChineseName("下载原图 开始下载回复语", "搜图")]
        public string OriginalPictureDownloadingReply { get; }

        /// <summary>
        /// 是否在下载原图功能上启用鉴黄
        /// </summary>
        [PropertyChineseName("下载原图 启用鉴黄", "搜图")]
        public bool OriginalPictureCheckPornEnabled { get; }

        /// <summary>
        /// 下载原图功能上鉴黄不通过时做以下动作: 0.以合并转发的方式发送原图 1.不做任何事 2.回复设置的语句
        /// </summary>
        [PropertyChineseName("下载原图 鉴黄不通过时", "搜图", "0 = 以合并转发的方式发送原图 1 = 不做任何事 2 = 回复设置的语句")]
        public int OriginalPictureCheckPornEvent { get; }

        /// <summary>
        /// 下载原图功能鉴黄不通过返回消息
        /// </summary>
        [PropertyChineseName("下载原图 鉴黄不通过回复语", "搜图")]
        public string OriginalPictureCheckPornIllegalReply { get; }
        /// <summary>
        /// 下载原图功能鉴黄错误返回消息
        /// </summary>
        [PropertyChineseName("下载原图 鉴黄错误回复语", "搜图")]
        public string OriginalPictureCheckPornErrorReply { get; }

        #endregion -- 下载原图配置项 --

        #region -- 翻译配置项 --

        /// <summary>
        /// 是否启用翻译功能
        /// </summary>
        [PropertyChineseName("启用翻译功能", "翻译")]
        public bool TranslateEnabled { get; }

        /// <summary>
        /// 翻译引擎
        /// </summary>
        [PropertyChineseName("翻译引擎", "翻译", "0 = 谷歌, 1 = 有道")]
        public TranslateEngine TranslateEngineType { get; }

        /// <summary>
        /// 云翻译接口的APP ID
        /// </summary>
        [PropertyChineseName("翻译接口APPID", "翻译")]
        public string? TranslateAPPID { get; }

        /// <summary>
        /// 云翻译接口的密钥
        /// </summary>
        [PropertyChineseName("翻译接口密钥", "翻译")]
        public string? TranslateAPPKey { get; }

        /// <summary>
        /// 翻译为中文命令(正则表达式)
        /// </summary>
        [PropertyChineseName("翻译引擎", "翻译", "0 = 谷歌, 1 = 有道")]
        public string TranslateToChineseCMD { get; }

        /// <summary>
        /// 翻译为指定语言命令(正则表达式)
        /// </summary>
        [PropertyChineseName("翻译为指定语言命令", "翻译", "支持正则表达式")]
        public string TranslateToCMD { get; }

        /// <summary>
        /// 从指定语言翻译为指定语言命令(正则表达式)
        /// </summary>
        [PropertyChineseName("翻译为指定语言命令", "翻译", "支持正则表达式, 使用有道翻译时该属性没有作用")]
        public string TranslateFromToCMD { get; }

        /// <summary>
        /// 自动翻译群友QQ号(正则表达式)
        /// </summary>
        [PropertyChineseName("自动翻译群友QQ号", "翻译", "自动翻译指定群友的全部消息")]
        public HashSet<long> AutoTranslateGroupMembersQQ { get; }

        #endregion -- 翻译配置项 --

        #region -- 色图配置项 --

        /// <summary>
        /// 默认色图命令
        /// </summary>
        public const string DefaultHPictureCmd = "(?<前缀><机器人名称>[我再]?[要来來发發给給])(?<数量>[0-9零一壹二两贰兩三叁四肆五伍六陆陸七柒八捌九玖十拾百佰千仟万萬亿億]+)?(?<单位>[张張个個幅份])(?<r18>[Rr]-?18的?)?(?<关键词>.+?)?(?<色图后缀>[的得地滴の]?[色瑟涩铯啬渋][图圖図])";

        /// <summary>
        /// 色图完整命令(正则表达式)
        /// </summary>
        [PropertyChineseName("色图命令", "色图", "支持正则表达式")]
        public string HPictureCmd { get; }

        /// <summary>
        /// 启用的色图图库
        /// </summary>
        [PropertyChineseName("色图图库", "色图", "启用的色图图库, 0 = Lolicon图库, 3 = yande.re")]
        public HashSet<PictureSource> EnabledHPictureSource { get; }

        /// <summary>
        /// 自定义色图命令
        /// </summary>
        [PropertyChineseName("自定义色图命令", "色图")]
        public HashSet<string> HPictureUserCmd { get; }

        /// <summary>
        /// 白名单群
        /// </summary>
        [PropertyChineseName("色图 屏蔽关键词", "色图")]
        public HashSet<string> HPictureShieldingWords { get; }

        /// <summary>
        /// 白名单群
        /// </summary>
        [PropertyChineseName("色图 白名单群", "色图")]
        public HashSet<long> HPictureWhiteGroup { get; }

        /// <summary>
        /// 是否仅限白名单使用色图
        /// </summary>
        [PropertyChineseName("色图 仅限白名单", "色图")]
        public bool HPictureWhiteOnly { get; }

        /// <summary>
        /// 是否启用R-18
        /// </summary>
        [PropertyChineseName("色图 允许R-18", "色图")]
        public bool HPictureAllowR18 { get; }

        /// <summary>
        /// 是否仅限白名单使用R-18
        /// </summary>
        [PropertyChineseName("色图 R-18仅限白名单", "色图")]
        public bool HPictureR18WhiteOnly { get; }

        /// <summary>
        /// 允许私聊
        /// </summary>
        [PropertyChineseName("色图 允许私聊", "色图")]
        public bool HPictureAllowPM { get; }

        /// <summary>
        /// 1200像素模式
        /// </summary>
        [PropertyChineseName("色图 1200像素模式", "色图")]
        public bool HPictureSize1200 { get; }

        /// <summary>
        /// 冷却时间
        /// </summary>
        [PropertyChineseName("色图 群冷却时间", "色图", "s")]
        public int HPictureCD { get; }

        /// <summary>
        /// 次数限制
        /// </summary>
        [PropertyChineseName("色图 群次数限制", "色图")]
        public int HPictureLimit { get; }

        /// <summary>
        /// 撤回时间
        /// </summary>
        [PropertyChineseName("色图 群撤回时间", "色图", "s")]
        public int HPictureRevoke { get; }

        /// <summary>
        /// 白名单群冷却时间
        /// </summary>
        [PropertyChineseName("色图 白名单群冷却时间", "色图", "s")]
        public int HPictureWhiteCD { get; }

        /// <summary>
        /// 白名单群撤回时间
        /// </summary>
        [PropertyChineseName("色图 白名单群撤回时间", "色图", "s")]
        public int HPictureWhiteRevoke { get; }

        /// <summary>
        /// 私聊冷却时间
        /// </summary>
        [PropertyChineseName("色图 私聊冷却时间", "色图", "s")]
        public int HPicturePMCD { get; }

        /// <summary>
        /// 私聊撤回时间
        /// </summary>
        [PropertyChineseName("色图 私聊撤回时间", "色图", "s")]
        public int HPicturePMRevoke { get; }

        /// <summary>
        /// 机器人管理员无冷却时间/次数限制
        /// </summary>
        [PropertyChineseName("色图 机器人管理员无限制", "色图")]
        public bool HPictureAdminNoLimit { get; }

        /// <summary>
        /// 私聊无冷却时间/次数限制
        /// </summary>
        [PropertyChineseName("色图 私聊无限制", "色图")]
        public bool HPicturePMNoLimit { get; }

        /// <summary>
        /// 白名单群无冷却时间/次数限制
        /// </summary>
        [PropertyChineseName("色图 白名单群无限制", "色图")]
        public bool HPictureWhiteNoLimit { get; }

        /// <summary>
        /// 色图是否发送作品地址
        /// </summary>
        [PropertyChineseName("色图 发送作品地址", "色图")]
        public bool HPictureSendUrl { get; }

        /// <summary>
        /// 色图是否发送图片代理地址
        /// </summary>
        [PropertyChineseName("色图 发送图片代理地址", "色图")]
        public bool HPictureSendProxyUrl { get; }

        /// <summary>
        /// 色图是否发送标题和作者
        /// </summary>
        [PropertyChineseName("色图 发送标题和作者", "色图")]
        public bool HPictureSendTitle { get; }

        /// <summary>
        /// 色图是否发送标签
        /// </summary>
        [PropertyChineseName("色图 发送标签", "色图")]
        public bool HPictureSendTags { get; }

        /// <summary>
        /// 是否以合并转发的方式发送色图
        /// </summary>
        [PropertyChineseName("色图 以合并转发的方式发送", "色图")]
        public bool HPictureSendByForward { get; }

        /// <summary>
        /// 开始下载色图时回复
        /// </summary>
        [PropertyChineseName("色图 开始下载色图回复语", "色图")]
        public string HPictureDownloadingReply { get; }

        /// <summary>
        /// 冷却中回复
        /// </summary>
        [PropertyChineseName("色图 冷却时间内回复语", "色图")]
        public string HPictureCDUnreadyReply { get; }

        /// <summary>
        /// 次数用尽回复
        /// </summary>
        [PropertyChineseName("色图 超过次数回复语", "色图")]
        public string HPictureOutOfLimitReply { get; }

        /// <summary>
        /// 发生错误回复
        /// </summary>
        [PropertyChineseName("色图 发生错误回复语", "色图")]
        public string HPictureErrorReply { get; }

        /// <summary>
        /// 没有结果回复
        /// </summary>
        [PropertyChineseName("色图 没有结果回复语", "色图")]
        public string HPictureNoResultReply { get; }

        /// <summary>
        /// 下载失败回复
        /// </summary>
        [PropertyChineseName("色图 图片下载失败回复语", "色图")]
        public string HPictureDownloadFailReply { get; }

        /// <summary>
        /// 色图次数限制记录类型
        /// </summary>
        [PropertyChineseName("色图 次数限制记录类型", "色图", "0 = 记次, 1 = 记张")]
        public LimitType HPictureLimitType { get; }

        /// <summary>
        /// 一条色图命令最多允许返回多少张色图
        /// </summary>
        [PropertyChineseName("色图 单次请求最大图片数量", "色图", "支持1-100, 不建议超过10, 容易导致无法撤回")]
        public int HPictureOnceMessageMaxImageCount { get; }

        /// <summary>
        /// 是否启用色图功能
        /// </summary>
        [PropertyChineseName("启用色图功能", "色图")]
        public bool HPictureEnabled { get; }

        #endregion -- 色图配置项 --

        #region -- 复读配置项 --

        /// <summary>
        /// 是否启用随机复读
        /// </summary>
        [PropertyChineseName("随机复读", "复读")]
        public bool RandomRepeatEnabled { get; }

        /// <summary>
        /// 随机复读概率
        /// </summary>
        [PropertyChineseName("随机复读 概率为", "复读", "%")]
        public int RandomRepeatProbability { get; }

        /// <summary>
        /// 是否启用连续复读
        /// </summary>
        [PropertyChineseName("连续复读", "复读")]
        public bool SuccessiveRepeatEnabled { get; }

        /// <summary>
        /// 参与连续复读所需的复读次数
        /// </summary>
        [PropertyChineseName("连续复读 次数为", "复读")]
        public int SuccessiveRepeatCount { get; }

        /// <summary>
        /// 是否倒放复读Gif
        /// </summary>
        [PropertyChineseName("倒放Gif", "复读")]
        public bool RewindGifEnabled { get; }

        /// <summary>
        /// 倒放复读Gif概率
        /// </summary>
        [PropertyChineseName("倒放Gif 概率为", "复读", "%")]
        public int RewindGifProbability { get; }

        /// 
        /// <summary>
        /// 是否水平反转复读图片
        /// </summary>
        [PropertyChineseName("水平镜像复读图片", "复读")]
        public bool HorizontalMirrorImageEnabled { get; }

        /// <summary>
        /// 水平反转复读图片概率
        /// </summary>
        [PropertyChineseName("水平镜像复读图片 概率为", "复读", "%")]
        public int HorizontalMirrorImageProbability { get; }

        /// <summary>
        /// 是否垂直翻转复读图片
        /// </summary>
        [PropertyChineseName("垂直镜像复读图片", "复读")]
        public bool VerticalMirrorImageEnabled { get; }

        /// <summary>
        /// 垂直翻转复读图片概率
        /// </summary>
        [PropertyChineseName("垂直镜像复读图片 概率为", "复读", "%")]
        public int VerticalMirrorImageProbability { get; }

        /// <summary>
        /// 将"我"替换为"你"
        /// </summary>
        [PropertyChineseName("复读时把\"我\"替换为\"你\"", "复读")]
        public bool ReplaceMeToYou { get; }

        #endregion -- 复读配置项 --

        #region -- 进退群提醒配置项 --

        /// <summary>
        /// 是否启用新人入群消息
        /// </summary>
        [PropertyChineseName("发送新人入群消息", "进/退群提醒")]
        public bool SendMemberJoinedMessage { get; }

        /// <summary>
        /// 是否启用成员退群消息
        /// </summary>
        [PropertyChineseName("发送群员退群消息", "进/退群提醒")]
        public bool SendMemberPositiveLeaveMessage { get; }

        /// <summary>
        /// 是否启用成员被踢消息
        /// </summary>
        [PropertyChineseName("发送群员被踢消息", "进/退群提醒")]
        public bool SendMemberBeKickedMessage { get; }

        /// <summary>
        /// 新人入群消息
        /// </summary>
        [PropertyChineseName("新人入群消息", "进/退群提醒")]
        public string? MemberJoinedMessage { get; }

        /// <summary>
        /// 成员退群消息
        /// </summary>
        [PropertyChineseName("群员退群消息", "进/退群提醒")]
        public string? MemberPositiveLeaveMessage { get; }

        /// <summary>
        /// 成员被踢消息
        /// </summary>
        [PropertyChineseName("群员被踢消息", "进/退群提醒")]
        public string? MemberBeKickedMessage { get; }

        #endregion -- 进退群提醒配置项 --

        #region -- 伪造消息配置项 --

        /// <summary>
        /// 是否启用伪造消息功能
        /// </summary>
        [PropertyChineseName("启用伪造消息功能", "伪造消息")]
        public bool ForgeMessageEnabled { get; }

        /// <summary>
        /// 伪造消息前缀
        /// </summary>
        [PropertyChineseName("伪造消息命令前缀", "伪造消息")]
        public string ForgeMessageCmdBegin { get; }

        /// <summary>
        /// 伪造消息分行符(分行符前后的内容会分成两条消息)
        /// </summary>
        [PropertyChineseName("伪造消息分行符", "伪造消息")]
        public string ForgeMessageCmdNewLine { get; }

        /// <summary>
        /// 是否在伪造消息末端追加消息
        /// </summary>
        [PropertyChineseName("伪造消息 在消息末尾追加机器人消息", "伪造消息")]
        public bool ForgeMessageAppendBotMessageEnabled { get; }

        /// <summary>
        /// 是否只允许机器人管理员使用伪造消息功能
        /// </summary>
        [PropertyChineseName("伪造消息 仅限机器人管理员可用", "伪造消息")]
        public bool ForgeMessageAdminOnly { get; }

        /// <summary>
        /// 机器人管理员使用伪造消息功能时是否不在末端追加消息
        /// </summary>
        [PropertyChineseName("伪造消息 机器人管理员使用时不追加消息", "伪造消息")]
        public bool ForgeMessageAdminDontAppend { get; }

        /// <summary>
        /// 追加消息内容
        /// </summary>
        [PropertyChineseName("伪造消息 追加消息内容", "伪造消息")]
        public string ForgeMessageAppendMessage { get; }

        /// <summary>
        /// 是否拒绝伪造机器人管理员的消息
        /// </summary>
        [PropertyChineseName("伪造消息 拒绝伪造机器人管理员的消息", "伪造消息")]
        public bool RefuseForgeAdmin { get; }

        /// <summary>
        /// 试图伪造机器人管理员消息时的回复语
        /// </summary>
        [PropertyChineseName("伪造消息 试图伪造机器人管理员消息时的回复语", "伪造消息")]
        public string RefuseForgeAdminReply { get; }

        /// <summary>
        /// 是否拒绝伪造机器人的消息(如果由机器人管理员发起则不会校验此项目)
        /// </summary>
        [PropertyChineseName("伪造消息 拒绝伪造机器人的消息", "伪造消息")]
        public bool RefuseForgeBot { get; }

        /// <summary>
        /// 试图伪造机器人消息时的回复语
        /// </summary>
        [PropertyChineseName("伪造消息 试图伪造机器人消息时的回复语", "伪造消息")]
        public string RefuseForgeBotReply { get; }

        #endregion -- 伪造消息配置项 --

        #region -- RSS 配置项 --

        /// <summary>
        /// 是否启用Rss订阅转发
        /// </summary>
        [PropertyChineseName("启用RSS订阅转发", "RSS订阅转发")]
        public bool RssEnabled { get; }

        /// <summary>
        /// 抓取RSS间隔时间(分钟)
        /// </summary>
        [PropertyChineseName("获取内容时间间隔", "RSS订阅转发", "分钟")]
        public double ReadRssInterval { get; }

        /// <summary>
        /// 订阅的地址和需要转发到的QQ或群列表
        /// </summary>
        [PropertyChineseName("RSS订阅项", "RSS订阅转发")]
        public HashSet<RssSubscriptionItem> RssSubscription { get; }

        /// <summary>
        /// 获取B站直播封面
        /// </summary>
        [PropertyChineseName("获取B站直播间封面", "RSS订阅转发")]
        public bool RssSendLiveCover { get; }

        #endregion -- RSS 配置项 --
    }
}