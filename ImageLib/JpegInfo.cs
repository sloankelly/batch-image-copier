using System;

namespace ImageLib
{
    public sealed class JpegInfo
    {
        public static JpegInfo Empty = new JpegInfo(string.Empty, DateTime.MinValue, 0, 0);

        public DateTime Created { get; }

        public Dimensions Dimensions { get; }

        public string Path { get; }

        public JpegInfo(string path, DateTime created, int width, int height)
        {
            Created = created;
            Dimensions = new Dimensions() { Width = width, Height = height };
            Path = path;
        }
    }
}
