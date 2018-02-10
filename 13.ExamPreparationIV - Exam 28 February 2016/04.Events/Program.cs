using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace _04.Events
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var pattern = @"^\#(?<person>[A-Za-z]+):\s*\@(?<city>[A-Za-z]+)\s*(?<hour>\d+:\d+)$";

            var dict = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();

                if (Regex.IsMatch(input, pattern))
                {
                    var match = Regex.Match(input, pattern);
                    var person = match.Groups["person"].Value;
                    var city = match.Groups["city"].Value;
                    var hour = match.Groups["hour"].Value;

                    var hourTokens = hour
                        .Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                    bool isHourValid = hourTokens[0] >= 0 && hourTokens[0] < 24;
                    bool areMinutesValid = hourTokens[1] >= 0 && hourTokens[1] <= 59;

                    if (isHourValid && areMinutesValid)
                    {
                        if (!dict.ContainsKey(city))
                        {
                            dict[city] = new Dictionary<string, List<string>>();
                        }

                        if (!dict[city].ContainsKey(person))
                        {
                            dict[city][person] = new List<string>();
                        }

                        dict[city][person].Add(hour);
                    }
                }
            }

            var towns = Console.ReadLine()
                .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            dict = dict
                .Where(kvp => towns.Contains(kvp.Key))
                .OrderBy(kvp => kvp.Key)
                .ToDictionary(a => a.Key, b => b.Value);

            foreach (var kvp in dict)
            {
                var town = kvp.Key;
                var personsInfo = kvp.Value
                    .OrderBy(p => p.Key)
                    .ToDictionary(a => a.Key, b => b.Value);

                Console.WriteLine($"{town}:");

                var counter = 0;

                foreach (var personInfo in personsInfo)
                {
                    var personName = personInfo.Key;
                    var personTimes = String.Join(", ", personInfo.Value
                        .OrderBy(t => t)
                        .ToList());

                    counter++;
                    Console.WriteLine($"{counter}. {personName} -> {personTimes}");
                }
            }
        }
    }
}
