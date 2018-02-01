using System;
using System.IO;

namespace _01.OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("../Resources/text.txt"))
            {
                var counter = 0;

                while (true)
                {
                    var currentLine = reader.ReadLine();

                    if (currentLine == null)
                    {
                        break;
                    }

                    if (counter % 2 != 0)
                    {
                        Console.WriteLine(currentLine);
                    }

                    counter++;
                }
            }
        }
    }
}
