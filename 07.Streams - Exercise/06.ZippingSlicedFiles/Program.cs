using System;
using System.IO;
using System.Collections.Generic;
using System.IO.Compression;

namespace _05.SlicingFiles
{
    class Program
    {
        public const int bufferSize = 4096;
        static void Main(string[] args)
        {
            Slice("../Resources/sliceMe.mp4", "./", 5);

            var files = new List<string>
            {
                "./Part-0.mp4.gz",
                "./Part-1.mp4.gz",
                "./Part-2.mp4.gz",
                "./Part-3.mp4.gz",
                "./Part-4.mp4.gz"
            };

            Assemble(files, "../Resources/Assembled.mp4");
        }

        static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            sourceFile = DoingRecurentPath(sourceFile);
            destinationDirectory = DoingRecurentPath(destinationDirectory);
            destinationDirectory = destinationDirectory.Substring(0, destinationDirectory.LastIndexOf('\\'));

            CheckIfGivenPathsExist(sourceFile, destinationDirectory);

            using (var reader = new FileStream(sourceFile, FileMode.Open))
            {
                var fileSize = reader.Length;
                var partsSize = (long)Math.Ceiling((double)(fileSize) / parts);
                var fileExtension = sourceFile.Substring(sourceFile.LastIndexOf('.'));

                for (int part = 0; part < parts; part++)
                {
                    var partName = $"Part-{part}";
                    var fullpath = destinationDirectory + "\\" + partName
                        + fileExtension + ".gz";

                    var currentPieceSize = 0L;

                    WriteTheCurrentPart(reader, fullpath, currentPieceSize, partsSize);
                }
            }
        }

        private static string DoingRecurentPath(string path)
        {
            var pathToDo = path;
            var fileName = path.Substring(path.LastIndexOf('/') + 1);

            if (pathToDo.StartsWith(".."))
            {
                var currentDirectoryPath = Directory.GetCurrentDirectory();

                while (pathToDo.StartsWith(".."))
                {
                    currentDirectoryPath = currentDirectoryPath.Substring(0, currentDirectoryPath.LastIndexOf('\\'));
                    pathToDo = pathToDo.Substring(3, pathToDo.Length - 3);
                }

                for (int i = 0; i < pathToDo.Length; i++)
                {
                    if (pathToDo[i] == '/')
                    {
                        pathToDo = pathToDo.Remove(i, 1);
                        pathToDo = pathToDo.Insert(i, @"\");
                    }
                }

                pathToDo = currentDirectoryPath + @"\" + pathToDo;
            }
            else if (pathToDo.StartsWith('.'))
            {
                pathToDo = Directory.GetCurrentDirectory() + @"\" + fileName;
            }

            return pathToDo;
        }

        private static void WriteTheCurrentPart(FileStream reader, string fullpath, long currentPieceSize, long partsSize)
        {
            using (var writer = new GZipStream(new FileStream(fullpath, FileMode.Create), CompressionLevel.Optimal))
            {
                var lastReadBytesCount = 0;

                var buffer = new byte[bufferSize];

                while (true)
                {
                    lastReadBytesCount = reader.Read(buffer, 0, bufferSize);

                    currentPieceSize += lastReadBytesCount;

                    if (lastReadBytesCount != bufferSize)
                    {
                        break;
                    }

                    if (currentPieceSize >= partsSize)
                    {
                        break;
                    }

                    writer.Write(buffer, 0, lastReadBytesCount);
                }

                writer.Write(buffer, 0, lastReadBytesCount);
            }
        }

        private static void CheckIfGivenPathsExist(string sourceFile, string destinationDirectory)
        {
            if (!Directory.Exists(sourceFile.Substring(0, sourceFile.LastIndexOf('\\'))))
            {
                var exeptionMsg = "Inexisting source file path";
                DisplayException(exeptionMsg);
            }

            if (!Directory.Exists(destinationDirectory))
            {
                var exceptionMsg = "Inexisting destination path";
                DisplayException(exceptionMsg);
            }
        }

        private static void DisplayException(string exeptionMsg)
        {
            var consoleColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{exeptionMsg}");
            Console.ForegroundColor = consoleColor;
            Environment.Exit(0);
        }

        static void Assemble(List<string> files, string destinationDirectory)
        {
            var listWithPathsToFiles = new List<string>();

            destinationDirectory = DoingRecurentPath(destinationDirectory);

            foreach (var file in files)
            {
                var done = DoingRecurentPath(file);

                CheckIfGivenPathsExist(done, destinationDirectory.Substring(0, destinationDirectory.LastIndexOf('\\')));

                listWithPathsToFiles.Add(DoingRecurentPath(file));
            }

            using (var writer = new FileStream(destinationDirectory, FileMode.Create))
            {
                for (int part = 0; part < files.Count; part++)
                {
                    var currentFilePath = files[part];
                    var currentFileExt = currentFilePath.Substring(currentFilePath.LastIndexOf('.'));

                    if (currentFileExt != ".gz")
                    {
                        continue;
                    }

                    using (var reader = new GZipStream(
                        new FileStream(currentFilePath, FileMode.Open), 
                        CompressionMode.Decompress))
                    {
                        byte[] buffer = new byte[bufferSize];

                        var lastBytesReadCount = 0;

                        while (true)
                        {
                            lastBytesReadCount = reader.Read(buffer, 0, bufferSize);

                            if (lastBytesReadCount != bufferSize)
                            {
                                break;
                            }

                            writer.Write(buffer, 0, lastBytesReadCount);
                        }

                        writer.Write(buffer, 0, lastBytesReadCount);
                    }
                }
            }
        }
    }
}
