using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _13.SrubskoUnleashed
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictInfo = new Dictionary<string, Dictionary<string, long>>();

            var input = Console.ReadLine();

            var pattern = @"([A-Za-z\s*]+)\s+@([A-Za-z\s*]+)\s+([0-9]+)\s+([0-9]+)";

            while (input != "End")
            {
                if (!Regex.IsMatch(input, pattern))
                {
                    goto Label;
                }

                var match = Regex.Match(input, pattern);

                var singer = match.Groups[1].ToString();
                var avenue = match.Groups[2].ToString();
                var ticketsPrice = long.Parse(match.Groups[3].ToString());
                var ticketsCount = long.Parse(match.Groups[4].ToString());

                if (!dictInfo.ContainsKey(avenue))
                {
                    dictInfo[avenue] = new Dictionary<string, long>();
                }

                if (!dictInfo[avenue].ContainsKey(singer))
                {
                    dictInfo[avenue][singer] = ticketsCount * ticketsPrice;
                }
                else
                {
                    dictInfo[avenue][singer] += ticketsCount * ticketsPrice;
                }

            Label:
                input = Console.ReadLine();
            }

            PrintResult(dictInfo);
        }

        private static void PrintResult(Dictionary<string, Dictionary<string, long>> dictInfo)
        {
            foreach (var kvp in dictInfo)
            {
                var avenue = kvp.Key;
                var dict = kvp.Value
                    .OrderByDescending(e => e.Value)
                    .ToDictionary(a => a.Key, b => b.Value);

                Console.WriteLine(avenue);

                foreach (var kvp2 in dict)
                {
                    Console.WriteLine("#  {0} -> {1}",
                        kvp2.Key, kvp2.Value);
                }
            }
        }
    }
}
