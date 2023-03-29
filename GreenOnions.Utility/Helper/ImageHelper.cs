using System;
using System.IO;
using System.Threading.Tasks;
using GreenOnions.Interface;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using TencentCloud.Cls.V20201016.Models;
using TencentCloud.Mgobe.V20201014.Models;

namespace GreenOnions.Utility.Helper
{
    public static class ImageHelper
    {
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

        public static Image ToImage(this Stream stream)
        {
            Image img = Image.Load(stream);
            stream.Dispose();
            return img;
        }

        public static Stream ToStream(this Image img)
        {
            MemoryStream ms = new MemoryStream();
            if (img.Frames.Count > 1)
                img.SaveAsGif(ms);
            else
                img.SaveAsPng(ms);
            img.Dispose();
            return ms;
        }

        public static Stream HorizontalFlip(this Stream stream)
        {
            using Image img = Image.Load(stream);
            HorizontalFlip(img);
            stream.Seek(0, SeekOrigin.Begin);
            MemoryStream ms = new MemoryStream();
            if (img.Frames.Count > 1)
                img.SaveAsGif(ms);
            else
                img.SaveAsPng(ms);
            return ms;
        }

        public static Stream VerticalFlip(this Stream stream)
        {
            using Image img = Image.Load(stream);
            VerticalFlip(img);
            stream.Seek(0, SeekOrigin.Begin);
            MemoryStream ms = new MemoryStream();
            if (img.Frames.Count > 1)
                img.SaveAsGif(ms);
            else
                img.SaveAsPng(ms);
            return ms;
        }

        public static Stream RewindGif(this Stream stream)
        {
            using Image img = Image.Load(stream);
            RewindGif(img);
            stream.Seek(0, SeekOrigin.Begin);
            MemoryStream ms = new MemoryStream();
            img.SaveAsGif(ms);
            return ms;
        }

        public static void HorizontalFlip(this Image img)
        {
            img.Mutate(x => x.Flip(FlipMode.Horizontal));
        }

        public static void VerticalFlip(this Image img)
        {
            img.Mutate(x => x.Flip(FlipMode.Vertical));
        }

        public static void RewindGif(this Image gif)
        {
            if (gif.Frames.Count < 2)
                return;

            for (int i = 0; i < gif.Frames.Count / 2; i++)
            {
                int secondIndex = gif.Frames.Count - 1 - i;
                var first = gif.Frames.CloneFrame(i).Frames.RootFrame;
                var second = gif.Frames.CloneFrame(secondIndex).Frames.RootFrame;
                gif.Frames.RemoveFrame(i);
                gif.Frames.InsertFrame(i, second);
                gif.Frames.RemoveFrame(secondIndex);
                gif.Frames.InsertFrame(secondIndex, first);
            }
        }

        public static Stream AntiShielding(this Stream stream)
        {
            using Image img = Image.Load(stream);
            using Image<Rgba32> bmp = img.CloneAs<Rgba32>();
            bmp.AntiShielding();
            Stream ms = new MemoryStream();
            bmp.SaveAsPng(ms);
            stream.Dispose();
            return ms;
        }
        
        public static void AntiShielding(this Image<Rgba32> bmp)
        {
            for (int i = 0; i < 5; i++)
            {
                Random r = new Random(Guid.NewGuid().GetHashCode());
                int x = r.Next(0, bmp.Width);
                int y = r.Next(0, bmp.Height);
                int offset = r.Next(1, 6);
                var pixel = bmp[x, y];
                bmp[x, y] = new Rgba32(pixel.R, pixel.G, pixel.B, pixel.A + (pixel.A > 128 ? -offset : offset));
            }
        }

        /// <summary>
        /// 根据图片URL下载图片并创建一个图片消息
        /// </summary>
        public static async Task<GreenOnionsImageMessage> CreateImageMessageByUrlAsync(string url, bool useProxy, bool antiShielding)
        {
            if (BotInfo.Config.SendImageByFile)  //下载完成后发送文件
            {
                Stream imgStream = await HttpHelper.GetStreamAsync(url, useProxy);
                if (antiShielding)  //反和谐
                    imgStream = AntiShielding(imgStream);
                return new GreenOnionsImageMessage(imgStream);
            }
            else  //直接发送地址
                return new GreenOnionsImageMessage(url);
        }
    }
}
