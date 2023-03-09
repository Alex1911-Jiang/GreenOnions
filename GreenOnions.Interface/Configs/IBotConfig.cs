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

        /// <summary>
        /// 代理地址
        /// </summary>
        public string ProxyUrl { get; }

        /// <summary>
        /// 日志等级 0 = 信息， 1 = 警告， 2 = 错误
        /// </summary>
        public int LogLevel { get; }

        /// <summary>
        /// QQ号(该属性不该被主动设置，由GreenOnions连接平台时自动赋值)
        /// </summary>
        public long QQId { get; }

        /// <summary>
        /// 连接的机器人平台IP(该属性不该被主动设置，由GreenOnions连接平台时自动赋值)
        /// </summary>
        public string IP { get; }

        /// <summary>
        /// 连接的机器人平台端口号(该属性不该被主动设置，由GreenOnions连接平台时自动赋值)
        /// </summary>
        public ushort Port { get; }

        /// <summary>
        /// 连接的机器人平台令牌(该属性不该被主动设置，由GreenOnions连接平台时自动赋值)
        /// </summary>
        public string VerifyKey { get; }

        /// <summary>
        /// 机器人名称
        /// </summary>
        public string BotName { get; }

        /// <summary>
        /// 机器人管理员QQ
        /// </summary>
        public HashSet<long> AdminQQ { get; }

        /// <summary>
        /// 黑名单组
        /// </summary>
        public HashSet<long> BannedGroup { get; }

        /// <summary>
        /// 黑名单用户
        /// </summary>
        public HashSet<long> BannedUser { get; }

        /// <summary>
        /// 是否自动退出被禁言的群
        /// </summary>
        public bool LeaveGroupAfterBeMushin { get; }

        /// <summary>
        /// 是否启用消息中转功能
        /// </summary>
        public bool MessageTransferEnabled { get; }

        /// <summary>
        /// 是否启用调试模式
        /// </summary>
        public bool DebugMode { get; }

        /// <summary>
        /// 调试群组
        /// </summary>
        public HashSet<long> DebugGroups { get; }

        /// <summary>
        /// 调试模式下是否只响应指定群组的消息
        /// </summary>
        public bool OnlyReplyDebugGroup { get; }

        /// <summary>
        /// 调试模式下是否只响应机器人管理员的消息
        /// </summary>
        public bool DebugReplyAdminOnly { get; }

        /// <summary>
        /// 允许Windows系统使用浏览器执行Http请求
        /// </summary>
        public bool HttpRequestByWebBrowser { get; }

        /// <summary>
        /// 图片外链路由替换 0:不替换  1:替换为c2cpicdw.qpic.cn/offpic_new  2:替换为gchat.qpic.cn/gchatpic_new
        /// </summary>
        public int ReplaceImgRoute { get; }

        /// <summary>
        /// Pixiv代理地址
        /// </summary>
        public string PixivProxy { get; }

        /// <summary>
        /// Pixiv使用Id路由替代日期路由
        /// </summary>
        public bool ReplacePixivDateToIdRoute { get; }

        /// <summary>
        /// 所有图片下载到本地再发送文件
        /// </summary>
        public bool SendImageByFile { get; }

        #region -- 腾讯云相关属性 --
        /// <summary>
        /// 是否接入腾讯云AI鉴黄
        /// </summary>
        public bool CheckPornEnabled { get; }

        /// <summary>
        /// 腾讯云APPID
        /// </summary>
        public string TencentCloudAPPID { get; }

        /// <summary>
        /// 腾讯云CloudRegion
        /// </summary>
        public string TencentCloudRegion { get; }

        /// <summary>
        /// 腾讯云SecretId
        /// </summary>
        public string TencentCloudSecretId { get; }

        /// <summary>
        /// 腾讯云SecretKey
        /// </summary>
       public string TencentCloudSecretKey { get; }

        /// <summary>
        /// 腾讯云桶名称
        /// </summary>
        public string TencentCloudBucket { get; }

        #endregion -- 腾讯云相关属性 --

        /// <summary>
        /// 是否启用自动连接到机器人平台
        /// </summary>
       public bool AutoConnectEnabled { get; }

        /// <summary>
        /// 自动连接的平台
        /// </summary>
        public int AutoConnectProtocol { get; }

        /// <summary>
        /// 连接前延时
        /// </summary>
        public int AutoConnectDelay { get; }

        /// <summary>
        /// 是否启用仅在指定时段工作
        /// </summary>
       public bool WorkingTimeEnabled { get; }

        /// <summary>
        /// 指定时段工作的工作时间从哪个小时开始
        /// </summary>
        public int WorkingTimeFromHour { get; }

        /// <summary>
        ///  指定时段工作的工作时间从哪分钟开始
        /// </summary>
        public int WorkingTimeFromMinute { get; }

        /// <summary>
        /// 指定时段工作的工作时间到哪个小时结束
        /// </summary>
        public int WorkingTimeToHour { get; }

        /// <summary>
        /// 指定时段工作的工作时间到哪分钟结束
        /// </summary>
        public int WorkingTimeToMinute { get; }

        /// <summary>
        /// 搜图和色图把文字消息和图片消息拆分开（对于私聊含有pixiv发不出去的问题）
        /// </summary>
        public bool SplitTextAndImageMessage { get; }
        #endregion -- 核心配置项 --

        #region -- 搜图配置项 --

        /// <summary>
        /// 是否启用搜图功能
        /// </summary>
       public bool SearchEnabled { get; }

        /// <summary>
        /// 私聊时是否自动搜图
        /// </summary>
       public bool PmAutoSearch { get; }

        /// <summary>
        /// 搜图是否使用代理
        /// </summary>
         public bool SearchUseProxy { get; }

        /// <summary>
        /// 是否发送缩略图
        /// </summary>
         public bool SearchSendThuImage { get; }

        #region -- TraceMoe --

        /// <summary>
        /// 是否启用TraceMoe搜番
        /// </summary>
        public bool SearchEnabledTraceMoe { get; }

        /// <summary>
        /// TraceMoe搜图相似度大于此数值时发送搜番结果
        /// </summary>
         public int TraceMoeSendThreshold { get; }

        /// <summary>
        /// TraceMoe搜番结果为里番时是否发送缩略图
        /// </summary>
      public bool TraceMoeSendAdultThuImg { get; }

        #endregion -- TraceMoe --

        #region -- SauceNAO --

        /// <summary>
        /// 是否启用SauceNAO搜图
        /// </summary>
         public bool SearchEnabledSauceNAO { get; }

        /// <summary>
        /// SauceNAO在Windows系统下时SauceNAO优先以浏览器进行请求(腾讯云轻量403问题)
        /// </summary>
        public bool SauceNAORequestByWebBrowser { get; }

        /// <summary>
        /// SauceNAO Api-Key
        /// </summary>
        public HashSet<string> SauceNAOApiKey { get; }

        /// <summary>
        /// 是否SauceNAO搜图按相似度倒序排序
        /// </summary>
        public bool SearchSauceNAOSortByDesc { get; }

        /// <summary>
        /// SauceNAO 低相似度阈值
        /// </summary>
         public int SearchSauceNAOLowSimilarity { get; }

        /// <summary>
        /// 是否SauceNAO搜图发送Pixiv原图
        /// </summary>
        public bool SearchSauceNAOSendPixivOriginalPicture { get; }

        /// <summary>
        /// SauceNAO 高相似度阈值
        /// </summary>
         public int SearchSauceNAOHighSimilarity { get; }

        /// <summary>
        /// SauceNAO 相似度低于阈值返回消息
        /// </summary>
       public string SearchSauceNAOLowSimilarityReply { get; }

        #endregion -- SauceNAO --

        #region -- ASCII2D --

        /// <summary>
        /// 是否启用ASCII2D搜图
        /// </summary>
        public bool SearchEnabledASCII2D { get; }

        /// <summary>
        /// 在Windows系统下时ASCII2D优先以浏览器进行请求(以应对近期403问题)
        /// </summary>
        public bool ASCII2DRequestByWebBrowser { get; }

        /// <summary>
        /// ASCII2D显示结果数量
        /// </summary>
       public int SearchShowASCII2DCount { get; }

        #endregion -- ASCII2D --

        #region -- Iqdb --

        #region -- Iqdb anime --

        /// <summary>
        /// 是否启用Iqdb搜图
        /// </summary>
       public bool SearchEnabledIqdb { get; }

        #endregion -- Iqdb anime --

        #region -- 3dIqdb --

        /// <summary>
        /// 是否启用3dIqdb搜车
        /// </summary>
       public bool SearchEnabled3dIqdb { get; }

        #endregion -- 3dIqdb --

        /// <summary>
        /// Iqdb 是否发送标签
        /// </summary>
        public bool SearchIqdbSendTags { get; }

        /// <summary>
        /// Iqdb 只发送分级为安全的缩略图
        /// </summary>
        public bool SearchIqdbMustSafe { get; }

        /// <summary>
        /// Iqdb 相似度阈值
        /// </summary>
        public int SearchIqdbSimilarity { get; }

        /// <summary>
        /// Iqdb 相似度低于阈值返回消息
        /// </summary>
        public string SearchIqdbSimilarityReply { get; }

        #endregion -- Iqdb --

        /// <summary>
        /// 开启连续搜图命令(正则表达式)
        /// </summary>
        public string SearchModeOnCmd { get; }

        /// <summary>
        /// 开启连续搜番命令(正则表达式)
        /// </summary>
        public string SearchAnimeModeOnCmd { get; }

        /// <summary>
        /// 开启连续搜车命令(正则表达式)
        /// </summary>
       public string Search3DModeOnCmd { get; }

        /// <summary>
        /// 开启连续搜图功能返回消息
        /// </summary>
         public string SearchModeOnReply { get; }

        /// <summary>
        /// 已在连续搜图模式下返回消息
        /// </summary>
        public string SearchModeAlreadyOnReply { get; }

        /// <summary>
        /// 发起搜索时的回复语(正在搜索但未搜索完毕)
        /// </summary>
        public string SearchingReply { get; }

        /// <summary>
        /// 关闭连续搜图命令(正则表达式)
        /// </summary>
        public string SearchModeOffCmd { get; }

        /// <summary>
        /// 连续搜图超时返回消息
        /// </summary>
        public string SearchModeTimeOutReply { get; }

        /// <summary>
        /// 退出连续搜图功能返回消息
        /// </summary>
        public string SearchModeOffReply { get; }

        /// <summary>
        /// 已经退出连续搜图功能返回消息
        /// </summary>
       public string SearchModeAlreadyOffReply { get; }

        /// <summary>
        /// 没有搜索到结果返回消息
        /// </summary>
       public string SearchNoResultReply { get; }

        /// <summary>
        /// 搜索过程中发生异常返回消息
        /// </summary>
        public string SearchErrorReply { get; }

        /// <summary>
        /// 下载缩略图失败时追加回复
        /// </summary>
       public string SearchDownloadThuImageFailReply { get; }

        /// <summary>
        /// 搜图结果以合并转发的方式发送
        /// </summary>
        public bool SearchSendByForward { get; }

        /// <summary>
        /// 是否在搜图功能上启用鉴黄
        /// </summary>
        public bool SearchCheckPornEnabled { get; }

        /// <summary>
        /// 搜图功能鉴黄不通过返回消息
        /// </summary>
       public string SearchCheckPornIllegalReply { get; }

        /// <summary>
        /// 搜图功能鉴黄发生异常返回消息
        /// </summary>
        public string SearchCheckPornErrorReply { get; }

        #endregion -- 搜图配置项 --

        #region -- 下载原图配置项 --

        /// <summary>
        /// 是否启用下载原图
        /// </summary>
         public bool OriginalPictureEnabled { get; }

        /// <summary>
        /// 下载原图命令
        /// </summary>
       public string OriginalPictureCommand { get; }

        /// <summary>
        /// 下载原图是否使用代理
        /// </summary>
        public bool OriginalPictureUseProxy { get; }

        /// <summary>
        /// 开始下载原图回复语
        /// </summary>
        public string OriginalPictureDownloadingReply { get; }

        /// <summary>
        /// 是否在下载原图功能上启用鉴黄
        /// </summary>
        public bool OriginalPictureCheckPornEnabled { get; }

        /// <summary>
        /// 下载原图功能上鉴黄不通过时做以下动作: 0.以合并转发的方式发送原图 1.不做任何事 2.回复设置的语句
        /// </summary>
         public int OriginalPictureCheckPornEvent { get; }

        /// <summary>
        /// 下载原图功能鉴黄不通过返回消息
        /// </summary>
        public string OriginalPictureCheckPornIllegalReply { get; }
        /// <summary>
        /// 下载原图功能鉴黄错误返回消息
        /// </summary>
        public string OriginalPictureCheckPornErrorReply { get; }

        #endregion -- 下载原图配置项 --

        #region -- 翻译配置项 --

        /// <summary>
        /// 是否启用翻译功能
        /// </summary>
        public bool TranslateEnabled { get; }

        /// <summary>
        /// 翻译引擎
        /// </summary>
        public TranslateEngine TranslateEngineType { get; }

        /// <summary>
        /// 翻译是否使用代理
        /// </summary>
        public bool TranslateUseProxy { get; }

        /// <summary>
        /// 云翻译接口的APP ID
        /// </summary>
        public string? TranslateAPPID { get; }

        /// <summary>
        /// 云翻译接口的密钥
        /// </summary>
        public string? TranslateAPPKey { get; }

        /// <summary>
        /// 翻译为中文命令(正则表达式)
        /// </summary>
        public string TranslateToChineseCMD { get; }

        /// <summary>
        /// 翻译为指定语言命令(正则表达式)
        /// </summary>
        public string TranslateToCMD { get; }

        /// <summary>
        /// 从指定语言翻译为指定语言命令(正则表达式)
        /// </summary>
        public string TranslateFromToCMD { get; }

        /// <summary>
        /// 自动翻译群友QQ号(正则表达式)
        /// </summary>
        public HashSet<long> AutoTranslateGroupMembersQQ { get; }

        #endregion -- 翻译配置项 --

        #region -- 色图配置项 --

        /// <summary>
        /// 是否启用色图功能
        /// </summary>
        public bool HPictureEnabled { get; }

        /// <summary>
        /// 默认色图命令
        /// </summary>
        public const string DefaultHPictureCmd = "(?<前缀><机器人名称>[我再]?[要来來发發给給])(?<数量>[0-9零一壹二两贰兩三叁四肆五伍六陆陸七柒八捌九玖十拾百佰千仟万萬亿億]+)?(?<单位>[张張个個幅份])(?<r18>[Rr]-?18的?)?(?<关键词>.+?)?(?<色图后缀>[的得地滴の]?[色瑟涩铯啬渋][图圖図])";

        /// <summary>
        /// 色图完整命令(正则表达式)
        /// </summary>
       public string HPictureCmd { get; }

        /// <summary>
        /// 色图是否使用代理
        /// </summary>
        public bool HPictureUseProxy { get; }

        /// <summary>
        /// 启用的色图图库
        /// </summary>
        public HashSet<PictureSource> EnabledHPictureSource { get; }

        /// <summary>
        /// 使用浏览器请求Lolicon Api
        /// </summary>
        public bool HPictureLoliconRequestByWebBrowser { get; }

        /// <summary>
        /// 使用插件替代系统请求Lolicon（取决于安装的插件）
        /// </summary>
        public bool HPictureLoliconRequestByPlugin { get; }

        /// <summary>
        /// 反和谐（仅限Windows，且需要先开启 所有图片下载到本地发送文件 功能）
        /// </summary>
        public bool HPictureAntiShielding { get; }

        /// <summary>
        /// 自定义色图命令
        /// </summary>
       public HashSet<string> HPictureUserCmd { get; }

        /// <summary>
        /// 白名单群
        /// </summary>
       public HashSet<string> HPictureShieldingWords { get; }

        /// <summary>
        /// 白名单群
        /// </summary>
       public HashSet<long> HPictureWhiteGroup { get; }

        /// <summary>
        /// 是否仅限白名单使用色图
        /// </summary>
       public bool HPictureWhiteOnly { get; }

        /// <summary>
        /// 是否启用R-18
        /// </summary>
        public bool HPictureAllowR18 { get; }

        /// <summary>
        /// 是否仅限白名单使用R-18
        /// </summary>
        public bool HPictureR18WhiteOnly { get; }

        /// <summary>
        /// 允许私聊
        /// </summary>
         public bool HPictureAllowPM { get; }

        /// <summary>
        /// 冷却时间
        /// </summary>
        public int HPictureCD { get; }

        /// <summary>
        /// 次数限制
        /// </summary>
        public int HPictureLimit { get; }

        /// <summary>
        /// 撤回时间
        /// </summary>
        public int HPictureRevoke { get; }

        /// <summary>
        /// 白名单群冷却时间
        /// </summary>
        public int HPictureWhiteCD { get; }

        /// <summary>
        /// 白名单群撤回时间
        /// </summary>
        public int HPictureWhiteRevoke { get; }

        /// <summary>
        /// 私聊冷却时间
        /// </summary>
        public int HPicturePMCD { get; }

        /// <summary>
        /// 私聊撤回时间
        /// </summary>
       public int HPicturePMRevoke { get; }

        /// <summary>
        /// 机器人管理员无冷却时间/次数限制
        /// </summary>
       public bool HPictureAdminNoLimit { get; }

        /// <summary>
        /// 私聊无冷却时间/次数限制
        /// </summary>
        public bool HPicturePMNoLimit { get; }

        /// <summary>
        /// 白名单群无冷却时间/次数限制
        /// </summary>
        public bool HPictureWhiteNoLimit { get; }

        /// <summary>
        /// 色图是否发送作品地址
        /// </summary>
        public bool HPictureSendUrl { get; }

        /// <summary>
        /// 色图是否发送图片代理地址
        /// </summary>
       public bool HPictureSendProxyUrl { get; }

        /// <summary>
        /// 色图是否发送标题和作者
        /// </summary>
         public bool HPictureSendTitle { get; }

        /// <summary>
        /// 色图是否发送标签
        /// </summary>
       public bool HPictureSendTags { get; }

        /// <summary>
        /// 是否以合并转发的方式发送色图
        /// </summary>
         public bool HPictureSendByForward { get; }

        /// <summary>
        /// 开始下载色图时回复
        /// </summary>
         public string HPictureDownloadingReply { get; }

        /// <summary>
        /// 冷却中回复
        /// </summary>
       public string HPictureCDUnreadyReply { get; }

        /// <summary>
        /// 次数用尽回复
        /// </summary>
         public string HPictureOutOfLimitReply { get; }

        /// <summary>
        /// 发生错误回复
        /// </summary>
        public string HPictureErrorReply { get; }

        /// <summary>
        /// 没有结果回复
        /// </summary>
         public string HPictureNoResultReply { get; }

        /// <summary>
        /// 下载失败回复
        /// </summary>
       public string HPictureDownloadFailReply { get; }

        /// <summary>
        /// 色图次数限制记录类型
        /// </summary>
         public LimitType HPictureLimitType { get; }

        /// <summary>
        /// 一条色图命令最多允许返回多少张色图
        /// </summary>
        public int HPictureOnceMessageMaxImageCount { get; }

        /// <summary>
        /// 用户本地图库路径
        /// </summary>
        public string LocalHPictureDirect { get; }

        #endregion -- 色图配置项 --

        #region -- 复读配置项 --

        /// <summary>
        /// 是否启用随机复读
        /// </summary>
        public bool RandomRepeatEnabled { get; }

        /// <summary>
        /// 随机复读概率
        /// </summary>
        public int RandomRepeatProbability { get; }

        /// <summary>
        /// 是否启用连续复读
        /// </summary>
        public bool SuccessiveRepeatEnabled { get; }

        /// <summary>
        /// 参与连续复读所需的复读次数
        /// </summary>
        public int SuccessiveRepeatCount { get; }

        /// <summary>
        /// 是否倒放复读Gif
        /// </summary>
       public bool RewindGifEnabled { get; }

        /// <summary>
        /// 倒放复读Gif概率
        /// </summary>
        public int RewindGifProbability { get; }

        /// <summary>
        /// 是否水平反转复读图片
        /// </summary>
        public bool HorizontalMirrorImageEnabled { get; }

        /// <summary>
        /// 水平反转复读图片概率
        /// </summary>
       public int HorizontalMirrorImageProbability { get; }

        /// <summary>
        /// 是否垂直翻转复读图片
        /// </summary>
       public bool VerticalMirrorImageEnabled { get; }

        /// <summary>
        /// 垂直翻转复读图片概率
        /// </summary>
        public int VerticalMirrorImageProbability { get; }

        /// <summary>
        /// 将"我"替换为"你"
        /// </summary>
       public bool ReplaceMeToYou { get; }

        #endregion -- 复读配置项 --

        #region -- 进退群提醒配置项 --

        /// <summary>
        /// 是否启用新人入群消息
        /// </summary>
        public bool SendMemberJoinedMessage { get; }

        /// <summary>
        /// 是否启用成员退群消息
        /// </summary>
        public bool SendMemberPositiveLeaveMessage { get; }

        /// <summary>
        /// 是否启用成员被踢消息
        /// </summary>
        public bool SendMemberBeKickedMessage { get; }

        /// <summary>
        /// 新人入群消息
        /// </summary>
        public string? MemberJoinedMessage { get; }

        /// <summary>
        /// 成员退群消息
        /// </summary>
        public string? MemberPositiveLeaveMessage { get; }

        /// <summary>
        /// 成员被踢消息
        /// </summary>
       public string? MemberBeKickedMessage { get; }

        #endregion -- 进退群提醒配置项 --

        #region -- 伪造消息配置项 --

        /// <summary>
        /// 是否启用伪造消息功能
        /// </summary>
       public bool ForgeMessageEnabled { get; }

        /// <summary>
        /// 伪造消息前缀
        /// </summary>
       public string ForgeMessageCmdBegin { get; }

        /// <summary>
        /// 伪造消息分行符(分行符前后的内容会分成两条消息)
        /// </summary>
        public string ForgeMessageCmdNewLine { get; }

        /// <summary>
        /// 是否在伪造消息末端追加消息
        /// </summary>
        public bool ForgeMessageAppendBotMessageEnabled { get; }

        /// <summary>
        /// 是否只允许机器人管理员使用伪造消息功能
        /// </summary>
         public bool ForgeMessageAdminOnly { get; }

        /// <summary>
        /// 机器人管理员使用伪造消息功能时是否不在末端追加消息
        /// </summary>
        public bool ForgeMessageAdminDontAppend { get; }

        /// <summary>
        /// 追加消息内容
        /// </summary>
       public string ForgeMessageAppendMessage { get; }

        /// <summary>
        /// 是否拒绝伪造机器人管理员的消息
        /// </summary>
        public bool RefuseForgeAdmin { get; }

        /// <summary>
        /// 试图伪造机器人管理员消息时的回复语
        /// </summary>
        public string RefuseForgeAdminReply { get; }

        /// <summary>
        /// 是否拒绝伪造机器人的消息(如果由机器人管理员发起则不会校验此项目)
        /// </summary>
        public bool RefuseForgeBot { get; }

        /// <summary>
        /// 试图伪造机器人消息时的回复语
        /// </summary>
        public string RefuseForgeBotReply { get; }

        #endregion -- 伪造消息配置项 --

        #region -- RSS 配置项 --

        /// <summary>
        /// 是否启用Rss订阅转发
        /// </summary>
       public bool RssEnabled { get; }

        /// <summary>
        /// 多线程并行抓取多个RSS订阅
        /// </summary>
      public bool RssParallel { get; }

        /// <summary>
        /// RSS是否使用代理
        /// </summary>
       public bool RssUseProxy { get; }

        /// <summary>
        /// 抓取RSS间隔时间(分钟)
        /// </summary>
        public double ReadRssInterval { get; }

        /// <summary>
        /// 订阅的地址和需要转发到的QQ或群列表
        /// </summary>
        public HashSet<RssSubscriptionItem>? RssSubscription { get; }

        #endregion -- RSS 配置项 --
    }
}