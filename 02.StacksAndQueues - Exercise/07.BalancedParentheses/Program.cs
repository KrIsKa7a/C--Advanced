using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var stackForIndexes = new Stack<int>();
            var isPerfect = true;

            for (int i = 0; i < input.Length; i++)
            {
                var currentSymbol = input[i];

                if (currentSymbol == '(' || currentSymbol == '{' || currentSymbol == '[')
                {
                    stackForIndexes.Push(i);
                }
                else
                {
                    if (stackForIndexes.Count == 0)
                    {
                        isPerfect = false;
                        break;
                    }

                    if (input[stackForIndexes.Peek()] == '(' && input[i] == ')')
                    {
                        stackForIndexes.Pop();
                        continue;
                    }
                    else if (input[stackForIndexes.Peek()] == '{' && input[i] == '}')
                    {
                        stackForIndexes.Pop();
                        continue;
                    }
                    else if (input[stackForIndexes.Peek()] == '[' && input[i] == ']')
                    {
                        stackForIndexes.Pop();
                        continue;
                    }
                    else
                    {
                        isPerfect = false;
                        break;
                    }
                }
            }

            if (isPerfect)
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
