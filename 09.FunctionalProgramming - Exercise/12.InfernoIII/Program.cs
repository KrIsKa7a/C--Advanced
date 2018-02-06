using System;
using System.Linq;
using System.Collections.Generic;

namespace _12.InfernoIII
{
    class Program
    {
        static void Main(string[] args)
        {
            var gems = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var dict = new Dictionary<string, Func<int, bool>>();

            var command = Console.ReadLine();

            while (command != "Forge")
            {
                var commandArgs = command
                    .Split(';')
                    .ToArray();

                var cmdType = commandArgs[0];
                var criteria = commandArgs[1];
                var power = commandArgs[2];

                var dictKey = $"{criteria} {power}";

                if (cmdType == "Exclude")
                {
                    Func<int, bool> func = GetFilter(criteria, power, gems);
                    dict[dictKey] = func;
                }
                else if (cmdType == "Reverse")
                {
                    dict.Remove(dictKey);
                }

                command = Console.ReadLine();
            }

            var numbersToExclude = new List<int>();

            foreach (var kvp in dict)
            {
                var func = kvp.Value;
                numbersToExclude.AddRange(
                    gems.Where(func));
            }

            foreach (var num in numbersToExclude)
            {
                gems.Remove(num);
            }

            Console.WriteLine(String.Join(" ", gems));
        }

        private static Func<int, bool> GetFilter(string criteria, string power,
            List<int> gems)
        {
            if (criteria == "Sum Left")
            {
                return num =>
                {
                    var indexOfNum = gems.IndexOf(num);
                    var leftSum = indexOfNum - 1 < 0 ? 0 : gems[indexOfNum - 1];
                    return gems[indexOfNum] + leftSum == int.Parse(power);
                };
            }
            else if (criteria == "Sum Right")
            {
                return num =>
                {
                    var indexOfNum = gems.IndexOf(num);
                    var rightSum = indexOfNum + 1 >= gems.Count ? 0 : gems[indexOfNum + 1];
                    return gems[indexOfNum] + rightSum == int.Parse(power);
                };
            }
            else if (criteria == "Sum Left Right")
            {
                return num =>
                {
                    var indexOfNum = gems.IndexOf(num);
                    var leftSum = indexOfNum - 1 < 0 ? 0 : gems[indexOfNum - 1];
                    var rightSum = indexOfNum + 1 >= gems.Count ? 0 : gems[indexOfNum + 1];
                    return gems[indexOfNum] + leftSum + rightSum == int.Parse(power);
                };
            }
            else
            {
                throw new NotImplementedException(); 
            }
        }
    }
}
