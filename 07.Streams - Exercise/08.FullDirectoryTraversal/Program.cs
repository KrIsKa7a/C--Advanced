using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace _08.FullDirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var startPath = Console.ReadLine();

            string[] filePaths = Directory.GetFiles(startPath, "*.*", 
                SearchOption.AllDirectories);

            var fileInfo = new Dictionary<string, List<FileInfo>>();

            //List<FileInfo> files = filePaths
            //    .Select(path => new FileInfo(path))
            //    .ToList();

            foreach (var path in filePaths)
            {
                var currentFileInfo = new FileInfo(path);
                var extension = currentFileInfo.Extension;

                if (!fileInfo.ContainsKey(extension))
                {
                    fileInfo[extension] = new List<FileInfo>();
                }

                fileInfo[extension].Add(currentFileInfo);
            }

            fileInfo =
                fileInfo
                .OrderByDescending(file => file.Value.Count)
                .ThenBy(file => file.Key)
                .ToDictionary(a => a.Key, b => b.Value);

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            PrintReport(fileInfo, desktopPath);
        }

        private static void PrintReport(Dictionary<string, List<FileInfo>> sorted, string desktop)
        {
            using (var writer = new StreamWriter(desktop + "/report.txt"))
            {
                foreach (var group in sorted)
                {
                    writer.WriteLine(group.Key);

                    foreach (var file in group.Value)
                    {
                        var fileName = file.Name;
                        var fileSizeInKb = (double)(file.Length) / 1024;

                        writer.WriteLine("--{0} - {1}kb",
                            fileName, fileSizeInKb);
                    }
                }
            }
        }
    }
}
