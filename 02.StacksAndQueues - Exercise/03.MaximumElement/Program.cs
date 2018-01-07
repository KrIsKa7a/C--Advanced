using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.MaximumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var numbers = new Stack<int>();
            var maxValues = new Stack<int>();

            maxValues.Push(int.MinValue);

            for (int i = 0; i < n; i++)
            {
                var input = ReadingInput();

                var type = input[0];

                if (type == "1")
                {
                    var num = int.Parse(input[1]);
                    numbers.Push(num);

                    if (maxValues.Peek() <= num)
                    {
                        maxValues.Push(num);
                    }
                }
                else if (type == "2")
                {
                    if (numbers.Pop() == maxValues.Peek())
                    {
                        maxValues.Pop();
                    }
                }
                else if (type == "3")
                {
                    Console.WriteLine(maxValues.Peek());
                }
            }
        }

        static string[] ReadingInput()
        {
            var input = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

            return input;
        }
    }
}
