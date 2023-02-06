using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using GreenOnions.Interface;

namespace GreenOnions.Utility.Helper
{
    public static class ImageHelper
    {
        private static readonly string _imagePath;

        public static string ImagePath
        {
            get
            {
                if (!Directory.Exists(_imagePath))
                    Directory.CreateDirectory(_imagePath);
                return _imagePath;
            }
        }

        static ImageHelper()
        {
            _imagePath = Path.Combine(Environment.CurrentDirectory, "Images");
        }

        /// <summary>
        /// 替换群图片路由
        /// </summary>
        /// <param name="imageUrl">原始图片Url</param>
        /// <returns>替换路由后的图片Url</returns>
        public static string ReplaceGroupUrl(string imageUrl)
        {
            imageUrl = BotInfo.Config.ReplaceImgRoute switch
            {
                1 => imageUrl.Replace("/gchat.qpic.cn/gchatpic_new/", "/c2cpicdw.qpic.cn/offpic_new/"),
                2 => imageUrl.Replace("/c2cpicdw.qpic.cn/offpic_new/", "/gchat.qpic.cn/gchatpic_new/"),
                _ => imageUrl
            };
            return imageUrl;
        }

        public static Stream ImageStreamAntiShielding(this Stream stream)
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return stream;
            Bitmap bmp = new Bitmap(stream);
            bmp.AntiShielding();
            stream.Dispose();
            stream = new MemoryStream();
            bmp.Save(stream, ImageFormat.Png);
            return stream;
        }

        public static Stream RewindGifStream(this Stream ms)
        {
            return ms.MirrorImageStream(MirrorImageDirection.Time);
        }

        public static Stream HorizontalMirrorImageStream(this Stream ms)
        {
            return ms.MirrorImageStream(MirrorImageDirection.Horizontal);
        }

        public static Stream VerticalMirrorImageStream(this Stream ms)
        {
            return ms.MirrorImageStream(MirrorImageDirection.Vertical);
        }

        private static Stream MirrorImageStream(this Stream stream, MirrorImageDirection mirrorImageDirection)
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return stream;
            using (Bitmap img = new Bitmap(stream))
            {
                if (img.RawFormat == ImageFormat.Gif || string.Equals(img.RawFormat.ToString(), "Gif", StringComparison.CurrentCultureIgnoreCase))
                {
                    string tempGifFileName = Path.Combine(ImagePath, "倒放.gif");
                    Bitmap gif = new Bitmap(img.Width, img.Height);
                    Bitmap frame = new Bitmap(img.Width, img.Height);
                    using Graphics g = Graphics.FromImage(gif);
                    Rectangle rg = new Rectangle(0, 0, img.Width, img.Height);
                    using Graphics gFrame = Graphics.FromImage(frame);

                    switch (mirrorImageDirection)
                    {
                        case MirrorImageDirection.Horizontal:
                            g.TranslateTransform(img.Width, 0);
                            g.ScaleTransform(-1, 1);
                            gFrame.TranslateTransform(img.Width, 0);
                            gFrame.ScaleTransform(-1, 1);
                            break;
                        case MirrorImageDirection.Vertical:
                            g.TranslateTransform(0, img.Height);
                            g.ScaleTransform(1, -1);
                            gFrame.TranslateTransform(0, img.Height);
                            gFrame.ScaleTransform(1, -1);
                            break;
                    }

                    foreach (Guid gd in img.FrameDimensionsList)
                    {
                        int count = img.GetFrameCount(new FrameDimension(gd));
                        ImageCodecInfo codecInfo = GetEncoder(ImageFormat.Gif);
                        Encoder encoder = Encoder.SaveFlag;
                        EncoderParameters eps;

                        bool firstFrame = true;

                        if (mirrorImageDirection == MirrorImageDirection.Time)
                        {
                            for (int i = count - 1; i >= 0; i--)
                                SetFrameToGif(i);
                        }
                        else
                        {
                            for (int i = 0; i < count; i++)
                                SetFrameToGif(i);
                        }

                        void SetFrameToGif(int frameId)
                        {
                            img.SelectActiveFrame(FrameDimension.Time, frameId);
                            if (firstFrame)
                            {
                                g.Clear(Color.White);

                                g.DrawImage(img, rg);
                                eps = new EncoderParameters(1);
                                eps.Param[0] = new EncoderParameter(encoder, (long)EncoderValue.MultiFrame);
                                BindProperty(img, gif);
                                gif.Save(tempGifFileName, codecInfo, eps);

                                firstFrame = false;
                            }
                            else
                            {
                                gFrame.Clear(Color.White);

                                gFrame.DrawImage(img, rg);

                                eps = new EncoderParameters(1);
                                eps.Param[0] = new EncoderParameter(encoder, (long)EncoderValue.FrameDimensionTime);
                                BindProperty(img, frame);
                                gif.SaveAdd(frame, eps);
                            }
                        }

                        eps = new EncoderParameters(1);
                        eps.Param[0] = new EncoderParameter(encoder, (long)EncoderValue.Flush);
                        gif.SaveAdd(eps);
                    }
                    MemoryStream result = new MemoryStream(File.ReadAllBytes(tempGifFileName));
                    File.Delete(tempGifFileName);
                    stream.Dispose();
                    return result;
                }
                else
                {
                    bool bHorizontalMirror = false;
                    bool bVerticalMirror = false;
                    if (BotInfo.Config.HorizontalMirrorImageEnabled)
                        bHorizontalMirror = new Random(Guid.NewGuid().GetHashCode()).Next(1, 101) < BotInfo.Config.HorizontalMirrorImageProbability;

                    if (bHorizontalMirror)
                        mirrorImageDirection = MirrorImageDirection.Horizontal;

                    if (BotInfo.Config.VerticalMirrorImageEnabled)
                        bVerticalMirror = new Random(Guid.NewGuid().GetHashCode()).Next(1, 101) < BotInfo.Config.VerticalMirrorImageProbability;

                    if (bVerticalMirror)
                        mirrorImageDirection = MirrorImageDirection.Vertical;

                    switch (mirrorImageDirection)
                    {
                        case MirrorImageDirection.Horizontal:
                            img.HorizontalFlip();
                            break;
                        case MirrorImageDirection.Vertical:
                            img.VerticalFlip();
                            break;
                    }
                    MemoryStream result = new MemoryStream();
                    img.Save(stream, ImageFormat.Png);
                    stream.Dispose();
                    return result;
                }
            }

            ImageCodecInfo GetEncoder(ImageFormat format)
            {
                ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
                foreach (ImageCodecInfo codec in codecs)
                {
                    if (codec.FormatID == format.Guid)
                        return codec;
                }
                return null;
            }

            void BindProperty(Image originalImage, Image copyImage)
            {
                for (int i = 0; i < originalImage.PropertyItems.Length; i++)
                    copyImage.SetPropertyItem(originalImage.PropertyItems[i]);
            }
        }

        public static Image HorizontalFlip(this Image img)
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return img;
            try
            {
                using Graphics g = Graphics.FromImage(img);
                Rectangle rect = new Rectangle(0, 0, img.Width, img.Height);
                img.RotateFlip(RotateFlipType.RotateNoneFlipX);
                g.DrawImage(img, rect);
                return img;
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorLog("水平镜像图片错误", ex.Message);
                return img;
            }
        }

        public static Image VerticalFlip(this Image img)
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return img;
            try
            {
                Graphics g = Graphics.FromImage(img);
                Rectangle rect = new Rectangle(0, 0, img.Width, img.Height);
                img.RotateFlip(RotateFlipType.RotateNoneFlipY);
                g.DrawImage(img, rect);
                return img;
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorLog("垂直镜像图片错误", ex.Message);
                return img;
            }
        }

        public static void AntiShielding(this Bitmap bmp)
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return;
            Random r = new Random(Guid.NewGuid().GetHashCode());
            int x = r.Next(0, bmp.Width);
            int y = r.Next(0, bmp.Height);
            int offset = r.Next(1, 6);
            Color c = bmp.GetPixel(x, y);
            bmp.SetPixel(x, y, Color.FromArgb(c.A + (c.A > 128 ? -offset : offset), c.R, c.G, c.B));
        }

        private enum MirrorImageDirection
        {
            Horizontal,
            Vertical,
            Time,
        }

        /// <summary>
        /// 根据图片URL下载图片并创建一个图片消息
        /// </summary>
        /// <param name="url"></param>
        /// <param name="cacheName"></param>
        /// <returns></returns>
        public static async Task<GreenOnionsImageMessage> CreateImageMessageByUrlAsync(string url, bool useProxy)
        {
            if (BotInfo.Config.SendImageByFile)  //下载完成后发送文件
            {
                Stream imgStream = await HttpHelper.GetStreamAsync(url, useProxy);
                if (BotInfo.Config.HPictureAntiShielding)  //反和谐
                    imgStream = ImageStreamAntiShielding(imgStream);
                return new GreenOnionsImageMessage(imgStream);
            }
            else  //直接发送地址
                return new GreenOnionsImageMessage(url);
        }
    }

    public class ImgInfo
    {
        /// <summary>
        /// 错误码，0 为成功
        /// </summary>
        public int code { set; get; }

        /// <summary>
        /// 服务器返回的信息
        /// </summary>
        public string message { set; get; }

        /// <summary>
        /// 当前图片的 url
        /// </summary>
        public string url { set; get; }

        /// <summary>
        /// 具体查询数据，具体见实体
        /// </summary>
        public Data data;
    }

    public class Data
    {
        /// <summary>
        /// 0 正常，1 黄图，2 疑似图片
        /// </summary>
        public int result { set; get; }

        /// <summary>
        /// 封禁状态，0 表示正常，1 表示图片已被封禁（只有存储在腾讯云的图片才会被封禁）
        /// </summary>
        public int forbid_status { set; get; }

        /// <summary>
        /// 识别为黄图的置信度，分值 0-100；是 normal_score , hot_score , porn_score的综合评分
        /// </summary>
        public decimal confidence { set; get; }

        /// <summary>
        /// 图片为正常图片的评分
        /// </summary>
        public decimal hot_score { set; get; }

        /// <summary>
        /// 图片为性感图片的评分
        /// </summary>
        public decimal normal_score { set; get; }

        /// <summary>
        /// 图片为色情图片的评分
        /// </summary>
        public decimal porn_score { set; get; }
    }
}
