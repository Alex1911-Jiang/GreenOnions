using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GreenOnions.BotMain.Oicq.MessageTypes
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MessageType
    {
        /// <summary>
        /// 文字消息
        /// </summary>
        text,
        /// <summary>
        /// @消息
        /// </summary>
        at,
        /// <summary>
        /// 默认表情
        /// </summary>
        face,
        /// <summary>
        /// 图片消息
        /// </summary>
        image,
        /// <summary>
        /// 闪照消息
        /// </summary>
        flash,
        /// <summary>
        /// 视频消息
        /// </summary>
        video,
        /// <summary>
        /// 语音消息
        /// </summary>
        record,
        /// <summary>
        /// xml
        /// </summary>
        xml,
        /// <summary>
        /// json
        /// </summary>
        json,
        /// <summary>
        /// 链接分享消息
        /// </summary>
        share,
        /// <summary>
        /// 地点分享消息
        /// </summary>
        location,
        /// <summary>
        /// 戳一戳
        /// </summary>
        poke,
        /// <summary>
        /// 商城表情
        /// </summary>
        bface,
        /// <summary>
        /// 表情
        /// </summary>
        sface,
        /// <summary>
        /// 特殊
        /// </summary>
        mirai,
    }
}
