using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using Mirai.CSharp.Models;
using Mirai.CSharp.Models.ChatMessages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace GreenOnions.Repeater
{
    public static class Repeat
    {
        private static Dictionary<long, MessageItem> MessageItems = new Dictionary<long, MessageItem>();

        public async static Task<IChatMessage> Repeating(IChatMessage message, long groupId, Func<Stream, Task<IImageMessage>> UploadPicture)
        {
            MessageItem tempMessageItem = new MessageItem(message.GetType(), message.ToString(), null, null);
            if (MessageItems.ContainsKey(groupId))
            {
                if (tempMessageItem == MessageItems[groupId])
                {
                    MessageItems[groupId].RepeatedCount++;
                    tempMessageItem = MessageItems[groupId];
                }
                else
                {
                    MessageItems[groupId] = tempMessageItem;
                }
            }
            else
            {
                MessageItems.Add(groupId, tempMessageItem);
            }

            if (!tempMessageItem.IsRepeated)  //已经参与过复读的消息不再参与随机复读
            {
                if (BotInfo.SuccessiveRepeatEnabled)
                {
                    IChatMessage resultMessage = await SuccessiveRepeat(message, tempMessageItem, UploadPicture);
                    if (resultMessage != null)
                    {
                        return resultMessage;
                    }
                }
                if (BotInfo.RandomRepeatEnabled)
                {
                    IChatMessage resultMessage = await RandomRepeat(message, tempMessageItem, UploadPicture);
                    if (resultMessage != null)
                    {
                        return resultMessage;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 随机复读
        /// </summary>
        /// <param name="message">消息体</param>
        /// <param name="messageItem">消息记录</param>
        /// <param name="UploadPicture">上传图片</param>
        /// <returns></returns>
        private static async Task<IChatMessage> RandomRepeat(IChatMessage message, MessageItem messageItem, Func<Stream, Task<IImageMessage>> UploadPicture)
        {
            if (new Random(Guid.NewGuid().GetHashCode()).Next(1, 101) <= BotInfo.RandomRepeatProbability)
            {
                if (message is Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage)
                {
                    messageItem.IsRepeated = true;
                    return new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(message.ToString());
                }
                else if (message is IImageMessage)
                {
                    messageItem.IsRepeated = true;
                    IImageMessage imageMessage = message as IImageMessage;
                    MemoryStream ms = MirrorImage(imageMessage.Url, imageMessage.ImageId);
                    if (ms == null)
                        return new Mirai.CSharp.HttpApi.Models.ChatMessages.ImageMessage(imageMessage.ImageId, null, null);
                    else
                    {
                        ms = new MemoryStream(ms.ToArray());  //不重新new一次的话上传的时候解码会为空
                        return await UploadPicture(ms);
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 连续复读
        /// </summary>
        /// <param name="message">消息体</param>
        /// <param name="messageItem">消息记录</param>
        /// <param name="UploadPicture">上传图片</param>
        /// <returns></returns>
        private static async Task<IChatMessage> SuccessiveRepeat(IChatMessage message, MessageItem messageItem, Func<Stream, Task<IImageMessage>> UploadPicture)
        {
            if (message is Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage)
            {
                if (messageItem.RepeatedCount >= BotInfo.SuccessiveRepeatCount)
                {
                    messageItem.IsRepeated = true;
                    return (Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage)message;
                }
            }
            else if (message is IImageMessage)
            {
                IImageMessage imageMessage = message as IImageMessage;
                if (messageItem.RepeatedCount >= BotInfo.SuccessiveRepeatCount)
                {
                    messageItem.IsRepeated = true;
                    MemoryStream ms = MirrorImage(imageMessage.Url, imageMessage.ImageId);
                    if (ms == null)
                        return new Mirai.CSharp.HttpApi.Models.ChatMessages.ImageMessage(imageMessage.ImageId, null, null);
                    else
                    {
                        ms = new MemoryStream(ms.ToArray());  //不重新new一次的话上传的时候解码会为空
                        return await UploadPicture(ms);
                    }
                }
            }
            return null;
        }

        private static MemoryStream MirrorImage(string url, string imageId)
        {
            bool bRewind = false;
            bool bHorizontalMirror = false;
            bool bVerticalMirror = false;
            if (BotInfo.RewindGifEnabled)
            {
                bRewind = new Random(Guid.NewGuid().GetHashCode()).Next(1, 101) < BotInfo.RewindGifProbability;
            }
            if (!bRewind)
            {
                if (BotInfo.HorizontalMirrorImageEnabled)
                {
                    bHorizontalMirror = new Random(Guid.NewGuid().GetHashCode()).Next(1, 101) < BotInfo.HorizontalMirrorImageProbability;
                }
                if (BotInfo.VerticalMirrorImageEnabled)
                {
                    bVerticalMirror = new Random(Guid.NewGuid().GetHashCode()).Next(1, 101) < BotInfo.VerticalMirrorImageProbability;
                }
            }
            

            if (bRewind || bHorizontalMirror || bVerticalMirror)
            {
                string imgName = Path.Combine(ImageHelper.ImagePath, $"复读图片{imageId}");
                MemoryStream ms = HttpHelper.DownloadImageAsMemoryStream(url, imgName);

                //倒放和镜像不会同时发生且倒放优先级高于镜像, 但水平镜像和垂直镜像可能同时发生
                if (bRewind)
                {
                    ms = ms.RewindGifStream();
                }
                if (bHorizontalMirror)
                {
                    ms = ms.HorizontalMirrorImageStream();
                }
                if (bVerticalMirror)
                {
                    ms = ms.VerticalMirrorImageStream();
                }
                return ms;
            }
            return null;
        }

        private class MessageItem
        {
            public readonly Type MessageType;
            public readonly string MessageValue;
            public readonly string ImageId;
            public readonly string ImageUrl;
            public int RepeatedCount = 1;
            public bool IsRepeated = false;

            public MessageItem(Type messageType, string messageValue, string imageId, string imageUrl)
            {
                MessageType = messageType;
                MessageValue = messageValue;
                ImageId = imageId;
                ImageUrl = imageUrl;
            }

            public static bool operator ==(MessageItem left, MessageItem right)
            {
                return Equals(left, right);
            }

            public static bool operator !=(MessageItem left, MessageItem right)
            {
                return !Equals(left, right);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;

                if (ReferenceEquals(this, obj)) return true;

                if (obj.GetType() != GetType()) return false;

                MessageItem other = (MessageItem)obj;

                if (MessageValue == other.MessageValue && ImageId == other.ImageId)
                {
                    return true;
                }
                return false;
            }

            public override int GetHashCode()
            {
                if (MessageType == typeof(Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage))  //只有文字消息和图片消息才复读
                {
                    return StringComparer.InvariantCulture.GetHashCode(MessageValue);
                }
                else if (MessageType == typeof(Mirai.CSharp.HttpApi.Models.ChatMessages.ImageMessage))  //只有文字消息和图片消息才复读
                {
                    return StringComparer.InvariantCulture.GetHashCode(ImageId);
                }
                return 0;
            }
        }
    }
}
