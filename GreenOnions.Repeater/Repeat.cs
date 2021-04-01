using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using Mirai_CSharp.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace GreenOnions.Repeater
{
    public static class Repeat
    {
        private static string lastOneMessageValue = "";
        private static int RepeatedCount = 0;
        private static readonly string imagePath = Environment.CurrentDirectory + "\\Image\\";
        public static IMessageBase Repeating(IMessageBase message, Func<Stream, ImageMessage> UploadPicture)
        {
            if (BotInfo.SuccessiveRepeatEnabled)
            {
                IMessageBase resultMessage = SuccessiveRepeat(message, UploadPicture);
                if (resultMessage != null)
                {
                    return resultMessage;
                }
            }
            if (BotInfo.RandomRepeatEnabled)
            {
                IMessageBase resultMessage = RandomRepeat(message, UploadPicture);
                if (resultMessage != null)
                {
                    return resultMessage;
                }
            }
            return null;
        }

        private static IMessageBase RandomRepeat(IMessageBase message, Func<Stream, ImageMessage> UploadPicture)
        {
            if (new Random(Guid.NewGuid().GetHashCode()).Next(1, 101) <= BotInfo.RandomRepeatProbability)
            {
                if (message is PlainMessage)
                {
                    return new PlainMessage(message.ToString());
                }
                else if (message is ImageMessage)
                {
                    ImageMessage imageMessage = message as ImageMessage;
                    MemoryStream ms = MirrorImage(imageMessage);
                    if (ms == null)
                        return new ImageMessage(imageMessage.ImageId, null, null);
                    else
                        return UploadPicture(ms);
                }
            }
            return null;
        }

        private static IMessageBase SuccessiveRepeat(IMessageBase message, Func<Stream, ImageMessage> UploadPicture)
        {
            if (message is PlainMessage)
            {
                string value = message.ToString();
                if (lastOneMessageValue == value)
                    RepeatedCount++;
                else
                    RepeatedCount = 1;
                lastOneMessageValue = value;

                if (RepeatedCount >= BotInfo.SuccessiveRepeatCount)
                {
                    RepeatedCount = 0;
                    return new PlainMessage(value);
                }
            }
            else if (message is ImageMessage)
            {
                ImageMessage imageMessage = message as ImageMessage;
                string value = imageMessage.ImageId;
                if (lastOneMessageValue == value)
                    RepeatedCount++;
                else
                    RepeatedCount = 1;
                lastOneMessageValue = value;

                if (RepeatedCount >= BotInfo.SuccessiveRepeatCount)
                {
                    RepeatedCount = 0;

                    MemoryStream ms = MirrorImage(imageMessage);
                    if (ms == null)
                        return new ImageMessage(imageMessage.ImageId, null, null);
                    else
                        return UploadPicture(ms);
                }
            }
            return null;
        }

        private static MemoryStream MirrorImage(ImageMessage imageMessage)
        {
            bool bHorizontalMirror = false;
            bool bVerticalMirror = false;
            if (BotInfo.HorizontalMirrorImageEnabled)
            {
                bHorizontalMirror = new Random(Guid.NewGuid().GetHashCode()).Next(1, 101) < BotInfo.HorizontalMirrorImageProbability;
            }
            if (BotInfo.VerticalMirrorImageEnabled)
            {
                bVerticalMirror = new Random(Guid.NewGuid().GetHashCode()).Next(1, 101) < BotInfo.VerticalMirrorImageProbability;
            }

            if (bHorizontalMirror || bVerticalMirror)
            {
                if (!Directory.Exists(imagePath))
                    Directory.CreateDirectory(imagePath);

                string imgName = $"{imagePath}复读图片{imageMessage.ImageId}.png";
                MemoryStream ms = HttpHelper.DownloadImageAsMemoryStream(imageMessage.Url, imgName);

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
    }
}
