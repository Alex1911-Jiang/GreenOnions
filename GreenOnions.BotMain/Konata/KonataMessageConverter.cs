using GreenOnions.Interface;
using GreenOnions.Utility.Helper;
using Konata.Core.Common;
using Konata.Core.Message;
using Konata.Core.Message.Model;
using Newtonsoft.Json;

namespace GreenOnions.BotMain.Konata
{
    public static class KonataMessageConverter
    {
        internal struct KQMessageWithTime
        {
            public KQMessageWithTime(MessageStruct message, DateTime time)
            {
                Message = message;
                Time = time;
            }
            public MessageStruct Message { get; private set; }
            public DateTime Time { get; private set; }
        }

        internal static Dictionary<long, KQMessageWithTime> Messages = new Dictionary<long, KQMessageWithTime>();

        static KonataMessageConverter()
        {
            Task.Run(async () => 
            {
                while (true)
                {
                IL_Recheck:;
                    foreach (KeyValuePair<long, KQMessageWithTime> item in Messages)
                    {
                        if (DateTime.Now.AddSeconds(120) > item.Value.Time)
                        {
                            Messages.Remove(item.Key);
                            goto IL_Recheck;
                        }
                    }
                    await Task.Delay(1000);
                }
            });
        }

        public static GreenOnionsMessages ToGreenOnionsMessages(this MessageStruct kqMessage, long senderId, string senderName)
        {
            Messages.Add(kqMessage.Uuid, new KQMessageWithTime(kqMessage, DateTime.Now));

            GreenOnionsMessages greenOnionsMessages = new GreenOnionsMessages();
            for (int i = 0; i < kqMessage.Chain.Count; i++)
            {
                if (kqMessage.Chain[i] is null)
                    continue;
                try
                {
                    if (kqMessage.Chain[i] is TextChain textMsg)
                        greenOnionsMessages.Add(textMsg.ToString());
                    else if (kqMessage.Chain[i] is ImageChain imageMsg)
                        greenOnionsMessages.Add(new GreenOnionsImageMessage(ImageHelper.ReplaceGroupUrl(imageMsg.ImageUrl)));
                    else if (kqMessage.Chain[i] is QFaceChain qfaceMsg)
                        greenOnionsMessages.Add(new GreenOnionsFaceMessage(qfaceMsg.FaceId, qfaceMsg.FaceName));
                    else if (kqMessage.Chain[i] is BFaceChain bfaceMsg)
                        greenOnionsMessages.Add(new GreenOnionsFaceMessage((int)bfaceMsg.FaceId, bfaceMsg.Name));
                    else if (kqMessage.Chain[i] is AtChain atMsg)
                        greenOnionsMessages.Add(new GreenOnionsAtMessage(atMsg.AtUin, null));
                }
                catch (Exception ex)
                {
                    LogHelper.WriteErrorLog($"转换为GreenOnions消息失败, 原消息类型为:{kqMessage.Chain[i].GetType()}", ex);
                }
            }
            greenOnionsMessages.Id = kqMessage.Uuid;
            greenOnionsMessages.SenderId = senderId;
            greenOnionsMessages.SenderName = senderName;
            return greenOnionsMessages;
        }

        public static BaseChain[] ToKonataMessages(this GreenOnionsMessages greenOnionsMessage, int? coverReplyId = null)
        {
            if (!greenOnionsMessage.IsGreenOnionsCommand)
                greenOnionsMessage.ReplaceGreenOnionsStringTags();

            if (coverReplyId is not null)
                greenOnionsMessage.ReplyId = coverReplyId;

            List<BaseChain> kqMessages = new List<BaseChain>();
            if (greenOnionsMessage.Reply && greenOnionsMessage.ReplyId is not null && Messages.ContainsKey(greenOnionsMessage.ReplyId.Value))
                kqMessages.Add(ReplyChain.Create(Messages[greenOnionsMessage.ReplyId.Value].Message));

            //Konata暂时不知道怎么构造合并转发，先转成普通消息
            if (greenOnionsMessage.FirstOrDefault() is GreenOnionsForwardMessage forwardMsg)
            {
                GreenOnionsMessages defMessage = new GreenOnionsMessages();
                for (int j = 0; j < forwardMsg.ItemMessages.Count; j++)
                    defMessage.AddRange(forwardMsg.ItemMessages[j].itemMessage);
                greenOnionsMessage = defMessage;
            }

            for (int i = 0; i < greenOnionsMessage.Count; i++)
            {
                try
                {
                    if (greenOnionsMessage[i] is GreenOnionsTextMessage txtMsg)
                    {
                        if (!string.IsNullOrEmpty(txtMsg.Text))
                            kqMessages.Add(TextChain.Create(txtMsg.Text));
                    }
                    else if (greenOnionsMessage[i] is GreenOnionsImageMessage imgMsg)
                    {
                        if (string.IsNullOrEmpty(imgMsg.Url))
                            kqMessages.Add(ImageChain.CreateFromBase64(imgMsg.Base64Str));
                        else if (File.Exists(imgMsg.Url))
                            kqMessages.Add(ImageChain.CreateFromFile(imgMsg.Url));
                        else
                            kqMessages.Add(ImageChain.CreateFromUrl(imgMsg.Url));
                    }
                    else if (greenOnionsMessage[i] is GreenOnionsAtMessage atMsg)
                    {
                        if (atMsg.AtId == -1)
                            kqMessages.Add(AtChain.Create(0));
                        else
                            kqMessages.Add(AtChain.Create((uint)atMsg.AtId));
                    }
                    else if (greenOnionsMessage[i] is GreenOnionsVoiceMessage voiceMsg)
                    {
                        if (string.IsNullOrEmpty(voiceMsg.Url))
                            kqMessages.Add(RecordChain.CreateFromBase64(voiceMsg.Base64Str));
                        else if (File.Exists(voiceMsg.Url))
                            kqMessages.Add(RecordChain.CreateFromFile(voiceMsg.Url));
                        else
                            kqMessages.Add(RecordChain.CreateFromUrl(voiceMsg.Url));
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteErrorLog($"转换为Konata消息失败!!! 消息类型为：{greenOnionsMessage[i]?.GetType()}", ex);
                    continue;
                }
            }
            return kqMessages.ToArray();
        }
    }
}
