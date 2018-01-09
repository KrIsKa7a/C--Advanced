using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            var keyMaterials = new Dictionary<string, double>();
            var junk = new Dictionary<string, double>();

            keyMaterials["motes"] = 0;
            keyMaterials["shards"] = 0;
            keyMaterials["fragments"] = 0;

            var isObtained = false;
            var itemObtained = string.Empty;

            var keyMaterialsArr = new string[]
            {
                "shards",
                "motes",
                "fragments"
            };

            while (true)
            {
                var input = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                FillingTheMaterials(keyMaterials, junk, ref isObtained, ref itemObtained, keyMaterialsArr, input);

                if (isObtained)
                {
                    break;
                }
            }

            SortMaterials(ref keyMaterials, ref junk);

            PrintResult(keyMaterials, junk, itemObtained);
        }

        private static void FillingTheMaterials(Dictionary<string, double> keyMaterials, Dictionary<string, double> junk, ref bool isObtained, ref string itemObtained, string[] keyMaterialsArr, string[] input)
        {
            for (int i = 1; i < input.Length; i += 2)
            {
                var quantity = double.Parse(input[i - 1]);
                var material = input[i].ToLower();

                if (keyMaterialsArr.Contains(material))
                {
                    keyMaterials[material] += quantity;
                }
                else
                {
                    if (!junk.ContainsKey(material))
                    {
                        junk[material] = quantity;
                    }
                    else
                    {
                        junk[material] += quantity;
                    }
                }

                if (keyMaterials["shards"] >= 250)
                {
                    itemObtained = "Shadowmourne";
                    keyMaterials["shards"] -= 250;
                    isObtained = true;
                    break;
                }
                else if (keyMaterials["fragments"] >= 250)
                {
                    itemObtained = "Valanyr";
                    keyMaterials["fragments"] -= 250;
                    isObtained = true;
                    break;
                }
                else if (keyMaterials["motes"] >= 250)
                {
                    itemObtained = "Dragonwrath";
                    keyMaterials["motes"] -= 250;
                    isObtained = true;
                    break;
                }
            }
        }

        private static void SortMaterials(ref Dictionary<string, double> keyMaterials, ref Dictionary<string, double> junk)
        {
            keyMaterials = keyMaterials
                            .OrderByDescending(m => m.Value)
                            .ThenBy(m => m.Key)
                            .ToDictionary(a => a.Key, b => b.Value);
            junk = junk
                .OrderBy(j => j.Key)
                .ToDictionary(a => a.Key, b => b.Value);
        }

        private static void PrintResult(Dictionary<string, double> keyMaterials, Dictionary<string, double> junk, string itemObtained)
        {
            Console.WriteLine("{0} obtained!", itemObtained);

            foreach (var kvp in keyMaterials)
            {
                Console.WriteLine("{0}: {1}",
                    kvp.Key, kvp.Value);
            }

            foreach (var kvp in junk)
            {
                Console.WriteLine("{0}: {1}",
                    kvp.Key, kvp.Value);
            }
        }
    }
}
