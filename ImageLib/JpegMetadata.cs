using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace ImageLib
{
    public static class JpegMetadata
    {
        public static JpegInfo GetInfo(string filepath)
        {
            string ext = Path.GetExtension(filepath);
            if (!ext.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) &&
                !ext.EndsWith("jpeg", StringComparison.OrdinalIgnoreCase))
            {
                return JpegInfo.Empty;
            }

            using (var imageStream = File.OpenRead(filepath))
            {
                var decoder = BitmapDecoder.Create(imageStream, BitmapCreateOptions.IgnoreColorProfile,
                    BitmapCacheOption.Default);
                var height = decoder.Frames[0].PixelHeight;
                var width = decoder.Frames[0].PixelWidth;

                return new JpegInfo(filepath, DateTime.Now, width, height);
            }
        }
    }
}
