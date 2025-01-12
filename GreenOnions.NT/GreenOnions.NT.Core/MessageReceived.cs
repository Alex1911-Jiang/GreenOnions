using GreenOnions.NT.Base;
using Lagrange.Core;
using Lagrange.Core.Event.EventArg;
using Lagrange.Core.Message.Entity;
using Newtonsoft.Json;

namespace GreenOnions.NT.Core
{
    public static class MessageReceived
    {
        public static void OnFriendMessage(BotContext context, FriendMessageEvent e)
        {
            if (e.Chain.GetEntity<FaceEntity>() is FaceEntity face)
            {
                LogHelper.LogMessage($"收到好友{e.Chain.FriendUin}表情消息：{face.FaceId}");
            }
            else if (e.Chain.GetEntity<FileEntity>() is FileEntity file)
            {
               LogHelper.LogMessage($"收到好友{e.Chain.FriendUin}文件消息：{file.FileName}，地址：{file.FileUrl}");
            }
            else if (e.Chain.GetEntity<ForwardEntity>() is ForwardEntity forwar)
            {
               LogHelper.LogMessage($"收到好友{e.Chain.FriendUin}At消息：@{forwar.TargetUin}");
            }
            else if (e.Chain.GetEntity<ImageEntity>() is ImageEntity image)
            {
                LogHelper.LogMessage($"收到好友{e.Chain.FriendUin}图片消息：{image.ImageUrl}");
            }
            else if (e.Chain.GetEntity<JsonEntity>() is JsonEntity jsonEntity)
            {
                LogHelper.LogMessage($"收到好友{e.Chain.FriendUin}Json消息：{jsonEntity.Json}");
            }
            else if (e.Chain.GetEntity<KeyboardEntity>() is KeyboardEntity keyboard)
            {
                LogHelper.LogMessage($"收到好友{e.Chain.FriendUin}键盘消息：{keyboard.Data}");
            }
            else if (e.Chain.GetEntity<LightAppEntity>() is LightAppEntity lightApp)
            {
                LogHelper.LogMessage($"收到好友{e.Chain.FriendUin}小程序分享消息：{lightApp.AppName}");
            }
            else if (e.Chain.GetEntity<LongMsgEntity>() is LongMsgEntity longMsg)
            {
                LogHelper.LogMessage($"收到好友{e.Chain.FriendUin}LongMsg消息：{longMsg}");
            }
            else if (e.Chain.GetEntity<MarkdownEntity>() is MarkdownEntity markdown)
            {
                LogHelper.LogMessage($"收到好友{e.Chain.FriendUin}Markdown消息：{markdown}");
            }
            else if (e.Chain.GetEntity<MentionEntity>() is MentionEntity mention)
            {
                LogHelper.LogMessage($"收到好友{e.Chain.FriendUin}@消息：{mention}");
            }
            else if (e.Chain.GetEntity<MultiMsgEntity>() is MultiMsgEntity multi)
            {
                LogHelper.LogMessage($"收到好友{e.Chain.FriendUin}Multi消息：{multi}");
            }
            else if (e.Chain.GetEntity<PokeEntity>() is PokeEntity poke)
            {
                LogHelper.LogMessage($"收到好友{e.Chain.FriendUin}戳一戳/窗口抖动消息：{poke}");
            }
            else if (e.Chain.GetEntity<RecordEntity>() is RecordEntity record)
            {
                LogHelper.LogMessage($"收到好友{e.Chain.FriendUin}语音消息：{record.AudioName}，地址：{record.AudioUrl}");
            }
            else if (e.Chain.GetEntity<TextEntity>() is TextEntity text)
            {
                LogHelper.LogMessage($"收到好友{e.Chain.FriendUin}文本消息：{text.Text}");
            }
            else if (e.Chain.GetEntity<VideoEntity>() is VideoEntity video)
            {
                LogHelper.LogMessage($"收到好友{e.Chain.FriendUin}视频消息：{video.VideoUrl}");
            }
            else if (e.Chain.GetEntity<XmlEntity>() is XmlEntity xmlEntity)
            {
               LogHelper.LogMessage($"收到好友{e.Chain.FriendUin}Xml消息：{xmlEntity.Xml}");
            }
        }


        public static void OnGroupMessage(BotContext context, GroupMessageEvent e)
        {
            if (e.Chain.GetEntity<FaceEntity>() is FaceEntity face)
            {
                LogHelper.LogMessage($"收到群{e.Chain.GroupUin}表情消息：{face.FaceId}");
            }
            else if (e.Chain.GetEntity<FileEntity>() is FileEntity file)
            {
                LogHelper.LogMessage($"收到群{e.Chain.GroupUin}文件消息：{file.FileName}，地址：{file.FileUrl}");
            }
            else if (e.Chain.GetEntity<ForwardEntity>() is ForwardEntity forwar)
            {
                LogHelper.LogMessage($"收到群{e.Chain.GroupUin}At消息：@{forwar.TargetUin}");
            }
            else if (e.Chain.GetEntity<ImageEntity>() is ImageEntity image)
            {
                LogHelper.LogMessage($"收到群{e.Chain.GroupUin}图片消息：{image.ImageUrl}");
            }
            else if (e.Chain.GetEntity<JsonEntity>() is JsonEntity jsonEntity)
            {
                LogHelper.LogMessage($"收到群{e.Chain.GroupUin}Json消息：{jsonEntity.Json}");
            }
            else if (e.Chain.GetEntity<KeyboardEntity>() is KeyboardEntity keyboard)
            {
                LogHelper.LogMessage($"收到群{e.Chain.GroupUin}键盘消息：{keyboard.Data}");
            }
            else if (e.Chain.GetEntity<LightAppEntity>() is LightAppEntity lightApp)
            {
                LogHelper.LogMessage($"收到群{e.Chain.GroupUin}小程序分享消息：{lightApp.AppName}");
            }
            else if (e.Chain.GetEntity<LongMsgEntity>() is LongMsgEntity longMsg)
            {
                LogHelper.LogMessage($"收到群{e.Chain.GroupUin}LongMsg消息：{longMsg}");
            }
            else if (e.Chain.GetEntity<MarkdownEntity>() is MarkdownEntity markdown)
            {
                LogHelper.LogMessage($"收到群{e.Chain.GroupUin}Markdown消息：{markdown}");
            }
            else if (e.Chain.GetEntity<MentionEntity>() is MentionEntity mention)
            {
                LogHelper.LogMessage($"收到群{e.Chain.GroupUin}@消息：{mention}");
            }
            else if (e.Chain.GetEntity<MultiMsgEntity>() is MultiMsgEntity multi)
            {
                LogHelper.LogMessage($"收到群{e.Chain.GroupUin}Multi消息：{multi}");
            }
            else if (e.Chain.GetEntity<PokeEntity>() is PokeEntity poke)
            {
                LogHelper.LogMessage($"收到群{e.Chain.GroupUin}戳一戳/窗口抖动消息：{poke}");
            }
            else if (e.Chain.GetEntity<RecordEntity>() is RecordEntity record)
            {
                LogHelper.LogMessage($"收到群{e.Chain.GroupUin}语音消息：{record.AudioName}，地址：{record.AudioUrl}");
            }
            else if (e.Chain.GetEntity<TextEntity>() is TextEntity text)
            {
                LogHelper.LogMessage($"收到群{e.Chain.GroupUin}文本消息：{text.Text}");
            }
            else if (e.Chain.GetEntity<VideoEntity>() is VideoEntity video)
            {
                LogHelper.LogMessage($"收到群{e.Chain.GroupUin}视频消息：{video.VideoUrl}");
            }
            else if (e.Chain.GetEntity<XmlEntity>() is XmlEntity xmlEntity)
            {
                LogHelper.LogMessage($"收到群{e.Chain.GroupUin}Xml消息：{xmlEntity.Xml}");
            }
        }

        public static void OnTempMessage(BotContext context, TempMessageEvent e)
        {
            if (e.Chain.GetEntity<TextEntity>() is TextEntity text)
            {
                LogHelper.LogMessage($"收到临时({JsonConvert.SerializeObject(e.Chain, Formatting.Indented)})文本消息：{text.Text}");
            }
        }
    }
}
