using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var stackWithChanges = new Stack<string>();

            stackWithChanges.Push("");

            for (int i = 0; i < n; i++)
            {
                var inputArgs = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var type = inputArgs[0];

                if (type == "1")
                {
                    var toAppend = inputArgs[1];
                    var newText = stackWithChanges.Peek() + toAppend;

                    stackWithChanges.Push(newText);
                }
                else if (type == "2")
                {
                    var toDelete = int.Parse(inputArgs[1]);
                    var currentText = stackWithChanges.Peek();

                    //if (toDelete > currentText.Length)
                    //{
                    //    toDelete = currentText.Length - 1;
                    //}

                    string newText = DeletingFromText(currentText, toDelete);

                    stackWithChanges.Push(newText);
                }
                else if (type == "3")
                {
                    var index = int.Parse(inputArgs[1]) - 1;

                    var currentText = stackWithChanges.Peek();

                    var toShow = currentText[index];

                    Console.WriteLine(toShow);
                }
                else if (type == "4")
                {
                    stackWithChanges.Pop();
                }
            }
        }

        private static string DeletingFromText(string currentText, int toDelete)
        {
            var newText = currentText.Remove(currentText.Length - toDelete, toDelete);

            return newText;
        }
    }
}
