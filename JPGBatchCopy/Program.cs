using ImageLib;
using System;
using System.IO;

namespace JPGBatchCopy
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceDir = Environment.CurrentDirectory;
            string destDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "temp");
            bool justList = false;
            int minWidth = 640;
            int minHeight = 480;

            int idx = 0;
            while (idx < args.Length)
            {
                if (args[idx].Equals("-list", StringComparison.OrdinalIgnoreCase) ||
                    args[idx].Equals("-l", StringComparison.OrdinalIgnoreCase))
                {
                    justList = true;
                }
                else if (args[idx].Equals("-source", StringComparison.OrdinalIgnoreCase) ||
                    args[idx].Equals("-s", StringComparison.OrdinalIgnoreCase))
                {
                    idx++;
                    if (idx == args.Length) break;

                    sourceDir = args[idx];
                }
                else if (args[idx].Equals("-dest", StringComparison.OrdinalIgnoreCase) ||
                    args[idx].Equals("-d", StringComparison.OrdinalIgnoreCase))
                {
                    idx++;
                    if (idx == args.Length) break;

                    destDir = args[idx];
                }
                else if (args[idx].Equals("-width", StringComparison.OrdinalIgnoreCase) ||
                    args[idx].Equals("-w", StringComparison.OrdinalIgnoreCase))
                {
                    idx++;
                    if (idx == args.Length) break;

                    minWidth = int.Parse(args[idx]);
                }
                else if (args[idx].Equals("-height", StringComparison.OrdinalIgnoreCase) ||
                    args[idx].Equals("-h", StringComparison.OrdinalIgnoreCase))
                {
                    idx++;
                    if (idx == args.Length) break;

                    minHeight = int.Parse(args[idx]);
                }

                idx++;
            }

            var batchCopy = new BatchCopy(sourceDir, destDir, justList, minWidth, minHeight);
            batchCopy.Process(Console.WriteLine);
        }
    }
}
