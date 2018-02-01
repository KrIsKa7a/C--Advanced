using System;
using System.IO;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("../Resources/text.txt"))
            {
                using (var writer = new StreamWriter("./output.txt"))
                {
                    var currentLineNumber = 1;

                    while (true)
                    {
                        var currentLine = reader.ReadLine();

                        if (currentLine == null)
                        {
                            break;
                        }

                        writer.WriteLine($"Line {currentLineNumber}: {currentLine}");

                        currentLineNumber++;
                    }
                }
            }
        }
    }
}
