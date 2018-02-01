using System;
using System.IO;

namespace _04.CopyBinaryFile
{
    class Program
    {
        public const int bufferSize = 4096;
        static void Main(string[] args)
        {
            using (var reader = new FileStream("../Resources/copyMe.png", FileMode.Open))
            {
                using (var writer = new FileStream("./copied.png", FileMode.Create))
                {
                    byte[] buffer = new byte[bufferSize];

                    var lastReadBytesCount = 0;

                    while (true)
                    {
                        lastReadBytesCount = reader.Read(buffer, 0, bufferSize);

                        if (lastReadBytesCount != bufferSize)
                        {
                            break;
                        }

                        writer.Write(buffer, 0, lastReadBytesCount);
                    }

                    writer.Write(buffer, 0, lastReadBytesCount);
                }
            }
        }
    }
}
