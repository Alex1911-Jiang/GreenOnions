using GreenOnions.NT.Base;
using Lagrange.Core;
using Lagrange.Core.Common.Interface.Api;
using Lagrange.Core.Message;
using Lagrange.Core.Message.Entity;

namespace GreenOnions.NT.Core
{
    public static class MessageReceived
    {
        public static void OnFriendMessage(BotContext context, Lagrange.Core.Event.EventArg.FriendMessageEvent e)
        {
            if (e.Chain.GetEntity<FaceEntity>() is FaceEntity face)
            {
                LogHelper.LogMessage($"收到好友表情消息：{face.FaceId}");
            }
            else if (e.Chain.GetEntity<FileEntity>() is FileEntity file)
            {
               LogHelper.LogMessage($"收到好友文件消息：{file.FileName}，地址：{file.FileUrl}");
            }
            else if (e.Chain.GetEntity<ForwardEntity>() is ForwardEntity forwar)
            {
               LogHelper.LogMessage($"收到好友At消息：@{forwar.TargetUin}");
            }
            else if (e.Chain.GetEntity<ImageEntity>() is ImageEntity image)
            {
                LogHelper.LogMessage($"收到好友图片消息：{image.ImageUrl}");
            }
            else if (e.Chain.GetEntity<JsonEntity>() is JsonEntity jsonEntity)
            {
                LogHelper.LogMessage($"收到好友Json消息：{jsonEntity.Json}");
            }
            else if (e.Chain.GetEntity<KeyboardEntity>() is KeyboardEntity keyboard)
            {
                LogHelper.LogMessage($"收到好友键盘消息：{keyboard.Data}");
            }
            else if (e.Chain.GetEntity<LightAppEntity>() is LightAppEntity lightApp)
            {
                LogHelper.LogMessage($"收到好友小程序分享消息：{lightApp.AppName}");
            }
            else if (e.Chain.GetEntity<LongMsgEntity>() is LongMsgEntity longMsg)
            {
                LogHelper.LogMessage($"收到好友LongMsg消息：{longMsg}");
            }
            else if (e.Chain.GetEntity<MarkdownEntity>() is MarkdownEntity markdown)
            {
                LogHelper.LogMessage($"收到好友Markdown消息：{markdown}");
            }
            else if (e.Chain.GetEntity<MentionEntity>() is MentionEntity mention)
            {
                LogHelper.LogMessage($"收到好友Mention消息：{mention}");
            }
            else if (e.Chain.GetEntity<MultiMsgEntity>() is MultiMsgEntity multi)
            {
                LogHelper.LogMessage($"收到好友Multi消息：{multi}");
            }
            else if (e.Chain.GetEntity<PokeEntity>() is PokeEntity poke)
            {
                LogHelper.LogMessage($"收到好友戳一戳/窗口抖动消息：{poke}");
            }
            else if (e.Chain.GetEntity<RecordEntity>() is RecordEntity record)
            {
                LogHelper.LogMessage($"收到好友语音消息：{record.AudioName}，地址：{record.AudioUrl}");
            }
            else if (e.Chain.GetEntity<TextEntity>() is TextEntity text)
            {
                LogHelper.LogMessage($"收到好友文本消息：{text.Text}");
                var privateMessageChain = MessageBuilder.Friend(e.Chain.FriendUin).Text("222").Build();
                context.SendMessage(privateMessageChain);
            }
            else if (e.Chain.GetEntity<VideoEntity>() is VideoEntity video)
            {
                LogHelper.LogMessage($"收到好友视频消息：{video.VideoUrl}");
            }
            else if (e.Chain.GetEntity<XmlEntity>() is XmlEntity xmlEntity)
            {
               LogHelper.LogMessage($"收到好友Xml消息：{xmlEntity.Xml}");
            }
            //else if (e.Chain.GetEntity<AtEntity>() is { AtQQ: { } qq } at)
            //{
            //    LogHelper.LogMessage($"收到好友@消息：{at.AtName}，@QQ：{qq}");
            //}
        }
    }
}
