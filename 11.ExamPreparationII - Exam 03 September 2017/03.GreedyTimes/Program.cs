using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.GreedyTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            var bagCapacity = long.Parse(Console.ReadLine());

            var dictForGolg = new Dictionary<string, long>();
            var amountOfGold = 0L;
            var dictForGems = new Dictionary<string, long>();
            var amountOfGems = 0L;
            var dictForCash = new Dictionary<string, long>();
            var amountOfCash = 0L;

            var input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var occupiedInTheBag = 0L;

            for (int i = 0; i < input.Length; i+=2)
            {
                var item = input[i];
                var amount = long.Parse(input[i + 1]);

                string itemType = GetItemType(item);

                if (occupiedInTheBag + amount > bagCapacity)
                {
                    continue;
                }

                if (itemType == "Gold")
                {
                    InsertInDictionary(item, amount, dictForGolg);
                    occupiedInTheBag += amount;
                    amountOfGold += amount;
                }
                else if (itemType == "Gem")
                {
                    if (amountOfGems + amount > amountOfGold)
                    {
                        continue;
                    }

                    InsertInDictionary(item, amount, dictForGems);
                    occupiedInTheBag += amount;
                    amountOfGems += amount;
                }
                else if (itemType == "Cash")
                {
                    if (amountOfCash + amount > amountOfGems)
                    {
                        continue;
                    }

                    InsertInDictionary(item, amount, dictForCash);
                    occupiedInTheBag += amount;
                    amountOfCash += amount;
                }
                else
                {
                    continue;
                }
            }

            PrintResult(dictForGolg, amountOfGold, dictForGems, amountOfGems, dictForCash, amountOfCash);
        }

        private static void PrintResult(Dictionary<string, long> dictForGolg, long amountOfGold, Dictionary<string, long> dictForGems, long amountOfGems, Dictionary<string, long> dictForCash, long amountOfCash)
        {
            if (dictForGolg.Count > 0)
            {
                Console.WriteLine($"<{"Gold"}> ${amountOfGold}");
                PrintDict(dictForGolg);

                if (dictForGems.Count > 0)
                {
                    Console.WriteLine($"<{"Gem"}> ${amountOfGems}");
                    PrintDict(dictForGems);

                    if (dictForCash.Count > 0)
                    {
                        Console.WriteLine($"<{"Cash"}> ${amountOfCash}");
                        PrintDict(dictForCash);
                    }
                }
            }
        }

        private static void PrintDict(Dictionary<string, long> dict)
        {
            dict = dict
                .OrderByDescending(i => i.Key)
                .ThenBy(i => i.Value)
                .ToDictionary(a => a.Key, b => b.Value);

            foreach (var kvp in dict)
            {
                Console.WriteLine($"##{kvp.Key} - {kvp.Value}");
            }
        }

        private static void InsertInDictionary(string item, long amount, Dictionary<string, long> dict)
        {
            if (!dict.ContainsKey(item))
            {
                dict[item] = 0L;
            }

            dict[item] += amount;
        }

        private static string GetItemType(string item)
        {
            if (item.Length == 3)
            {
                return "Cash";
            }
            else if (item.ToLower().EndsWith("gem"))
            {
                return "Gem";
            }
            else if (item.ToLower() == "gold")
            {
                return "Gold";
            }
            else
            {
                return "Invalid";
            }
        }
    }
}
