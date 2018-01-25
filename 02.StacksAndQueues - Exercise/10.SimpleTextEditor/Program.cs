using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var stackMemory = new Stack<string>();
            stackMemory.Push("");

            for (int i = 0; i < n; i++)
            {
                var cmd = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var cmdType = cmd[0];

                if (cmdType == "1")
                {
                    var oldText = stackMemory.Peek();
                    var newText = oldText + cmd[1];
                    stackMemory.Push(newText);
                }
                else if (cmdType == "2")
                {
                    var oldText = stackMemory.Peek();
                    var lenght = oldText.Length - int.Parse(cmd[1]);
                    var newText = oldText.Substring(0, lenght);
                    stackMemory.Push(newText);
                }
                else if (cmdType == "3")
                {
                    var text = stackMemory.Peek();
                    Console.WriteLine(text[int.Parse(cmd[1]) - 1]);
                }
                else if (cmdType == "4")
                {
                    stackMemory.Pop();
                }
            }
        }
    }
}
