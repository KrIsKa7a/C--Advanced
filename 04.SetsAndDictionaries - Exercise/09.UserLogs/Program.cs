using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.UserLogs
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictInfo = new Dictionary<string, Dictionary<string, int>>();

            var input = Console.ReadLine();

            while (input != "end")
            {
                var inputArgs = input.
                    Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var ip = inputArgs[0]
                    .Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray()[1];
                var user = inputArgs[2]
                    .Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray()[1];

                if (!dictInfo.ContainsKey(user))
                {
                    dictInfo[user] = new Dictionary<string, int>();
                }

                if (!dictInfo[user].ContainsKey(ip))
                {
                    dictInfo[user][ip] = 0;
                }

                dictInfo[user][ip]++;

                input = Console.ReadLine();
            }

            dictInfo = dictInfo
                .OrderBy(s => s.Key)
                .ToDictionary(a => a.Key, b => b.Value);

            PrintingResult(dictInfo);
        }

        private static void PrintingResult(Dictionary<string, Dictionary<string, int>> dictInfo)
        {
            foreach (var kvp in dictInfo)
            {
                var user = kvp.Key;
                var dictForUser = kvp.Value;

                Console.WriteLine("{0}: ", user);

                var count = 0;
                var dictCount = dictForUser.Count;
                foreach (var kvp2 in dictForUser)
                {
                    count++;

                    if (count == dictCount)
                    {
                        Console.WriteLine("{0} => {1}.",
                            kvp2.Key, kvp2.Value);
                    }
                    else
                    {
                        Console.Write("{0} => {1}, ",
                            kvp2.Key, kvp2.Value);
                    }
                }
            }
        }
    }
}
