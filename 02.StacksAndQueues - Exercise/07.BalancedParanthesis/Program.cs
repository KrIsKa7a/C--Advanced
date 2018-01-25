using System;
using System.Collections.Generic;

namespace _07.BalancedParanthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            var paranthesisLine = Console.ReadLine();

            var stackForOpeningIndexes = new Stack<int>();

            var areBalanced = true;

            if (paranthesisLine.Length == 1)
            {
                Console.WriteLine("NO");
                return;
            }

            for (int i = 0; i < paranthesisLine.Length; i++)
            {
                var currentChar = paranthesisLine[i];

                if (currentChar == '{' || currentChar == '(' || currentChar == '[')
                {
                    stackForOpeningIndexes.Push(i);
                }
                else
                {
                    if (stackForOpeningIndexes.Count == 0)
                    {
                        Console.WriteLine("NO");
                        return;
                    }

                    if (currentChar == '}' && paranthesisLine[stackForOpeningIndexes.Peek()] == '{')
                    {
                        stackForOpeningIndexes.Pop();
                    }
                    else if (currentChar == ']' && paranthesisLine[stackForOpeningIndexes.Peek()] == '[')
                    {
                        stackForOpeningIndexes.Pop();
                    }
                    else if (currentChar == ')' && paranthesisLine[stackForOpeningIndexes.Peek()] == '(')
                    {
                        stackForOpeningIndexes.Pop();
                    }
                    else
                    {
                        areBalanced = false;
                        break;
                    }
                }
            }

            if (areBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
