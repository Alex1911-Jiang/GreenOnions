using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

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
                {
                    Directory.CreateDirectory(_imagePath);
                }
                return _imagePath;
            }
        }

        static ImageHelper()
        {
            _imagePath = Path.Combine(Environment.CurrentDirectory, "Image");
        }

        public static Stream StreamAntiShielding(this Stream ms)
        {
            Bitmap bmp = new Bitmap(Image.FromStream(ms));
            bmp.AntiShielding();
            ms.Close();
            ms = new MemoryStream();
            bmp.Save(ms, ImageFormat.Png);
            return ms;
        }

        public static MemoryStream RewindGifStream(this MemoryStream ms)
        {
            return ms.MirrorImageStream(MirrorImageDirection.Time);
        }

        public static MemoryStream HorizontalMirrorImageStream(this MemoryStream ms)
        {
            return ms.MirrorImageStream(MirrorImageDirection.Horizontal);
        }

        public static MemoryStream VerticalMirrorImageStream(this MemoryStream ms)
        {
            return ms.MirrorImageStream(MirrorImageDirection.Vertical);
        }

        private static MemoryStream MirrorImageStream(this MemoryStream ms, MirrorImageDirection mirrorImageDirection )
        {
            Image img = Image.FromStream(ms);
            if (img.RawFormat == ImageFormat.Gif || String.Equals(img.RawFormat.ToString(), "Gif", StringComparison.CurrentCultureIgnoreCase))
            {
                string tempGifFileName = ImagePath + "翻转.gif";
                Bitmap gif = new Bitmap(img.Width, img.Height);
                Bitmap frame = new Bitmap(img.Width, img.Height);
                Graphics g = Graphics.FromImage(gif);
                Rectangle rg = new Rectangle(0, 0, img.Width, img.Height);
                Graphics gFrame = Graphics.FromImage(frame);

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
                        {
                            SetFrameToGif(i);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < count; i++)
                        {
                            SetFrameToGif(i);
                        }
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
                ms.Close();
                ms = new MemoryStream(File.ReadAllBytes(tempGifFileName));
            }
            else
            {
                switch (mirrorImageDirection)
                {
                    case MirrorImageDirection.Horizontal:
                        img.HorizontalFlip();
                        break;
                    case MirrorImageDirection.Vertical:
                        img.VerticalFlip();
                        break;
                }
                ms.Close();
                ms = new MemoryStream();
                img.Save(ms, ImageFormat.Png);
            }
            return ms;
        }

        private static void BindProperty(Image originImage, Image copyImage)
        {
            for (int i = 0; i < originImage.PropertyItems.Length; i++)
            {
                copyImage.SetPropertyItem(originImage.PropertyItems[i]);
            }
        }

        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        public static Image HorizontalFlip(this Image img)
        {
            try
            {
                var width = img.Width;
                var height = img.Height;
                Graphics g = Graphics.FromImage(img);
                Rectangle rect = new Rectangle(0, 0, width, height);
                img.RotateFlip(RotateFlipType.RotateNoneFlipX);
                g.DrawImage(img, rect);
                return img;
            }
            catch (Exception ex)
            {
                ErrorHelper.WriteErrorLogWithUserMessage("水平镜像图片错误", ex.Message);
                return img;
            }
        }

        public static Image VerticalFlip(this Image img)
        {
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
                ErrorHelper.WriteErrorLogWithUserMessage("垂直镜像图片错误", ex.Message);
                return img;
            }
        }

        public static void AntiShielding(this Bitmap bmp)
        {
            Random r = new Random();
            int x = r.Next(0, bmp.Width);
            int y = r.Next(0, bmp.Height);

            Color c = bmp.GetPixel(x, y);
            if (c.A > 128)
            {
                bmp.SetPixel(x, y, Color.FromArgb(c.A - 1, c.R, c.G, c.B));
            }
            else
            {
                bmp.SetPixel(x, y, Color.FromArgb(c.A + 1, c.R, c.G, c.B));
            }
        }

        private enum MirrorImageDirection
        {
            Horizontal,
            Vertical,
            Time,
        }
    }

    public class TencentJianHuangResponse
    {
        public List<ImgInfo> result_list = new List<ImgInfo>();
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
