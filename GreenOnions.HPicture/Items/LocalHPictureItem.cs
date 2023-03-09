using System;
using System.IO;
using GreenOnions.Utility;

namespace GreenOnions.HPicture.Items
{
    internal class LocalHPictureItem
    {
        public string? FileName { get; }

        public LocalHPictureItem()
        {
            string[] files = Directory.GetFiles(BotInfo.Config.LocalHPictureDirect, "*", SearchOption.AllDirectories);
            Random rdm = new Random(Guid.NewGuid().GetHashCode());
            FileName = files[rdm.Next(files.Length)];
        }
    }
}
