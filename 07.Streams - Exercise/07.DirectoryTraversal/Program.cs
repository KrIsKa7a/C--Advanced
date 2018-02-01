using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace _07.DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();

            var fileInfo = new Dictionary<string, List<FileInfo>>();

            foreach (var file in Directory.GetFiles(path))
            {
                var currentFileInfo = new FileInfo(file);
                var fileExtension = currentFileInfo.Extension;

                if (!fileInfo.ContainsKey(fileExtension))
                {
                    fileInfo[fileExtension] = new List<FileInfo>();
                }

                fileInfo[fileExtension].Add(currentFileInfo);
            }

            fileInfo = fileInfo
                .OrderByDescending(f => f.Value.Count)
                .ThenBy(s => s.Key)
                .ToDictionary(a => a.Key, b => b.Value);

            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                + "\\report.txt";

            WriteResult(fileInfo, desktopPath);
        }

        private static void WriteResult(Dictionary<string, List<FileInfo>> fileInfo, string path)
        {
            using (var writer = new StreamWriter(path))
            {
                foreach (var efip in fileInfo)
                {
                    var fileExtension = efip.Key;
                    var filesInfo = efip.Value
                        .OrderBy(f => f.Length)
                        .ToList();

                    writer.WriteLine(fileExtension);

                    foreach (var info in filesInfo)
                    {
                        var fileNameWithExtension = info.Name;
                        var fileSizeInKb = (double)(info.Length) / 1024;
                        writer.WriteLine("--{0} - {1}kb",
                            fileNameWithExtension, fileSizeInKb);
                    }
                }
            }
        }
    }
}
