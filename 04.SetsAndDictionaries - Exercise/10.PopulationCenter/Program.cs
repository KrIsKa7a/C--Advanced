using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.PopulationCenter
{
    class Program
    {
        static void Main(string[] args)
        {
            var reports = new Dictionary<string, Dictionary<string, long>>();

            var input = Console.ReadLine();

            while (input != "report")
            {
                var inputArgs = input
                    .Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var town = inputArgs[0];
                var country = inputArgs[1];
                var pop = long.Parse(inputArgs[2]);

                if (!reports.ContainsKey(country))
                {
                    reports[country] = new Dictionary<string, long>();
                }

                if (!reports[country].ContainsKey(town))
                {
                    reports[country][town] = pop;
                }
                else
                {
                    reports[country][town] += pop;
                }

                input = Console.ReadLine();
            }

            reports = reports
                .OrderByDescending(e => e.Value.Values.Sum())
                .ToDictionary(a => a.Key, b => b.Value);

            PrintAndSortResult(reports);
        }

        private static void PrintAndSortResult(Dictionary<string, Dictionary<string, long>> reports)
        {
            foreach (var kvp in reports)
            {
                var country = kvp.Key;
                var cities = kvp.Value
                    .OrderByDescending(c => c.Value)
                    .ToDictionary(a => a.Key, b => b.Value);
                var totalPopulation = cities.Values.Sum();

                Console.WriteLine("{0} (total population: {1})",
                    country, totalPopulation);

                foreach (var kvp2 in cities)
                {
                    Console.WriteLine("=>{0}: {1}",
                        kvp2.Key, kvp2.Value);
                }
            }
        }
    }
}
