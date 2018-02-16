using System;
using System.IO;
using System.Linq;

namespace ImageLib
{
    public sealed class BatchCopy
    {
        private readonly string _sourceDir;
        private readonly string _destDir;
        private readonly bool _justList;
        private readonly int _minHeight;
        private readonly int _minWidth;

        private Action<string> _output;

        public BatchCopy(string sourceDir, string destDir, bool justList, int minWidth = 640, int minHeight = 460)
        {
            _sourceDir = sourceDir;
            _destDir = destDir;
            _justList = justList;
            _minWidth = minWidth;
            _minHeight = minHeight;
        }

        public void Process(Action<string> output)
        {
            Action<string> processFile = _justList ? output : CopyFile;
            _output = output == null ? (_) => { } : output;

            string[] files = Directory.GetFiles(_sourceDir, "*.jpg", SearchOption.AllDirectories);
            var size = new Dimensions() { Width = _minWidth, Height = _minHeight };

            files.Select(file => JpegMetadata.GetInfo(file))
                 .Where(file => file != null && file.Dimensions >= size)
                 .Select(file => file.Path)
                 .Do(processFile);
        }

        private void CopyFile(string filePath)
        {
            string filename = Path.GetFileName(filePath);
            string dest = Path.Combine(_destDir, filename);

            if (File.Exists(dest))
            {
                string tmp = GenerateNewFilename(dest);
                if (tmp == string.Empty)
                {
                    _output?.Invoke("File Exists: " + dest);
                    return;
                }

                dest = tmp;
            }

            File.Copy(filePath, dest);
        }

        private string GenerateNewFilename(string usedFile)
        {
            string ext = Path.GetExtension(usedFile);
            string file = usedFile.Substring(0, usedFile.Length - ext.Length);

            for (int i = 'a'; i <= 'z'; i++)
            {
                string tmp = file + "-" + (char)i + ext;
                if (!File.Exists(tmp))
                {
                    return tmp;
                }
            }

            return string.Empty;
        }
    }
}
