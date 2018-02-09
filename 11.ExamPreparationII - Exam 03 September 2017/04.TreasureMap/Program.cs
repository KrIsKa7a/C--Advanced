using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace _04.TreasureMap
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var lines = new List<string>();

            FillInputLinesIntoDataStructure(n, lines);

            var pattern = @"(?<start>#|!)[^!#]*?(?<![A-Za-z0-9])(?<streetName>[A-Za-z]{4})(?![A-Za-z0-9])[^!#]*(?<![0-9])(?<streetNumber>[\d]{3})-(?<password>[\d]{4}|[\d]{6})(?![0-9])[^!#]*?(?<end>!|#)";

            for (int i = 0; i < lines.Count; i++)
            {
                var currentLine = lines[i];

                var matches = Regex.Matches(currentLine, pattern)
                    .Where(m => m.Groups["start"].Value != m.Groups["end"].Value)
                    .ToList();

                var perfectMatch = matches[matches.Count / 2];

                var streetName = perfectMatch.Groups["streetName"].Value;
                var streetNumber = perfectMatch.Groups["streetNumber"].Value;
                var password = perfectMatch.Groups["password"].Value;

                Console.WriteLine($"Go to str. {streetName} {streetNumber}. Secret pass: {password}.");
            }
        }

        private static void FillInputLinesIntoDataStructure(int n, List<string> lines)
        {
            for (int i = 0; i < n; i++)
            {
                lines.Add(Console.ReadLine());
            }
        }
    }
}
