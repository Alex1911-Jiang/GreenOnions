using System;
using System.IO;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;

namespace GreenOnions.HPicture.Items
{
    internal class LocalHPictureItem
    {
        public Stream ImageStream { get; }

        public LocalHPictureItem()
        {
            string[] files = Directory.GetFiles(BotInfo.Config.LocalHPictureDirect, "*", SearchOption.AllDirectories);
            Random rdm = new Random(Guid.NewGuid().GetHashCode());
            MemoryStream ms = new MemoryStream(File.ReadAllBytes(files[rdm.Next(files.Length)]));
            if (BotInfo.Config.HPictureAntiShielding)
                ms.AntiShielding();
            ImageStream = ms;
        }
    }
}
