using System;
using System.Linq;
using System.Collections.Generic;

namespace _05.FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            var peopleCount = int.Parse(Console.ReadLine());

            var peopleDict = new Dictionary<string, int>();

            for (int i = 0; i < peopleCount; i++)
            {
                var peopleInfo = Console.ReadLine()
                    .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var name = peopleInfo[0];
                var age = int.Parse(peopleInfo[1]);

                peopleDict[name] = age;
            }

            var condition = Console.ReadLine();
            var filterAge = int.Parse(Console.ReadLine());
            var printType = Console.ReadLine();

            //Get the filter action and filter the dictionary
            var filter = Filter(condition, filterAge);

            var peopleThatMatchTheFilter = peopleDict
                .Where(kvp => filter(kvp.Value))
                .ToDictionary(a => a.Key, b => b.Value);

            //Get the printing action and print
            var printing = PrintFilter(printType);

            foreach (var kvp in peopleThatMatchTheFilter)
            {
                printing(kvp);
            }
            
        }

        static Action<KeyValuePair<string, int>> PrintFilter(string printType)
        {
            if (printType == "name")
            {
                return x => Console.WriteLine(x.Key);
            }
            else if (printType == "age")
            {
                return x => Console.WriteLine(x.Value);
            }
            else
            {
                return x => Console.WriteLine($"{x.Key} - {x.Value}");
            }
        }

        static Predicate<int> Filter(string condition, int age)
        {
            if (condition == "younger")
            {
                return x => x < age;
            }
            else
            {
                return x => x >= age;
            }
        }
    }
}
