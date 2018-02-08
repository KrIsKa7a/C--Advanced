using System;
using System.Text.RegularExpressions;
using System.Text;

namespace _01.Regeh
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var pattern = @"\[[A-Za-z]+<(\d+)REGEH(\d+)>[A-Za-z]+\]";

            var matches = Regex.Matches(input, pattern);

            var indexTotal = 0;

            var result = new StringBuilder();

            for (int i = 0; i < matches.Count; i++)
            {
                var currentMatch = matches[i];
                var currentFirstIndex = int.Parse(currentMatch.Groups[1].Value);
                var currentSecondIndex = int.Parse(currentMatch.Groups[2].Value);
                indexTotal += currentFirstIndex;

                result.Append(input[indexTotal % input.Length]);

                indexTotal += currentSecondIndex;

                result.Append(input[indexTotal % input.Length]);
            }

            Console.WriteLine(result.ToString());
        }
    }
}
