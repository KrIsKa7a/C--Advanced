using System;
using System.Collections.Generic;

namespace _04.MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var stackForOpeningIndexes = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                var currentChar = input[i];

                if (currentChar == '(')
                {
                    stackForOpeningIndexes.Push(i);
                }
                else if (currentChar == ')')
                {
                    var start = stackForOpeningIndexes.Pop();
                    var lenght = i - start + 1;
                    Console.WriteLine(input.Substring(start, lenght));
                }
            }
        }
    }
}
