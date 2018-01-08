using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.LogsAggregattor
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var logsAggregator = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                var inputArgs = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var ip = inputArgs[0];
                var user = inputArgs[1];
                var seconds = int.Parse(inputArgs[2]);

                if (!logsAggregator.ContainsKey(user))
                {
                    logsAggregator[user] = new Dictionary<string, int>();
                }

                if (!logsAggregator[user].ContainsKey(ip))
                {
                    logsAggregator[user][ip] = seconds;
                }
                else
                {
                    logsAggregator[user][ip] += seconds;
                }
            }

            logsAggregator = logsAggregator
                .OrderBy(e => e.Key)
                .ToDictionary(a => a.Key, b => b.Value);

            PrintResult(logsAggregator);
        }

        private static void PrintResult(Dictionary<string, Dictionary<string, int>> logsAggregator)
        {
            foreach (var kvp in logsAggregator)
            {
                var user = kvp.Key;
                var ips = kvp.Value
                    .OrderBy(i => i.Key)
                    .ToDictionary(a => a.Key, b => b.Value);

                var seconds = ips.Values.Sum();

                Console.Write("{0}: {1} ", user, seconds);

                var dictCount = ips.Count;
                var count = 0;

                Console.Write("[");

                foreach (var kvp2 in ips)
                {
                    count++;

                    if (count == dictCount)
                    {
                        Console.Write("{0}", kvp2.Key);
                    }
                    else
                    {
                        Console.Write("{0}, ", kvp2.Key);
                    }
                }

                Console.WriteLine("]");
            }
        }
    }
}
