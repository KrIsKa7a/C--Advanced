using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var equation = Console.ReadLine();

            var splitted = new Stack<int>();

            for (int i = 0; i < equation.Length; i++)
            {
                if (equation[i] == '(')
                {
                    splitted.Push(i);
                }
                else if (equation[i] == ')')
                {
                    var startIndex = splitted.Pop();
                    string toPrint = equation.Substring(startIndex, i - startIndex + 1);
                    Console.WriteLine(toPrint);
                }
            }    
        }
    }
}
