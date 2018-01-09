using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.DragonArmy
{
    class Stat
    {
        public long Damage { get; set; }
        public long Armor { get; set; }
        public long Health { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var dictInfo = new Dictionary<string, Dictionary<string, Stat>>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var type = input[0];
                var name = input[1];

                long dmg = 0;
                long hp = 0;
                long armor = 0;

                dmg = FindingDamage(input);
                hp = FindingHealth(input);
                armor = FindingArmor(input);

                var currentStat = new Stat
                {
                    Damage = dmg,
                    Health = hp,
                    Armor = armor
                };

                if (!dictInfo.ContainsKey(type))
                {
                    dictInfo[type] = new Dictionary<string, Stat>();
                }

                dictInfo[type][name] = currentStat;
            }

            PrintResult(dictInfo);
        }

        private static void PrintResult(Dictionary<string, Dictionary<string, Stat>> dictInfo)
        {
            foreach (var kvp in dictInfo)
            {
                var type = kvp.Key;
                var dict = kvp.Value
                    .OrderBy(e => e.Key)
                    .ToDictionary(a => a.Key, b => b.Value);
                var allStats = dict.Values.ToList();

                var wholeDmg = 0d;
                var wholeHp = 0d;
                var wholeArmor = 0d;

                foreach (var stat in allStats)
                {
                    wholeDmg += stat.Damage;
                    wholeArmor += stat.Armor;
                    wholeHp += stat.Health;
                }

                var avgDmg = wholeDmg / allStats.Count;
                var avgHp = wholeHp / allStats.Count;
                var avgArmor = wholeArmor / allStats.Count;

                Console.WriteLine("{0}::({1:f2}/{2:f2}/{3:f2})",
                    type, avgDmg, avgHp, avgArmor);

                foreach (var kvp2 in dict)
                {
                    Console.WriteLine("-{0} -> damage: {1}, health: {2}, armor: {3}",
                        kvp2.Key, kvp2.Value.Damage, kvp2.Value.Health, kvp2.Value.Armor);
                }
            }
        }

        private static long FindingArmor(string[] input)
        {
            long armor;
            try
            {
                armor = long.Parse(input[4]);
            }
            catch (Exception)
            {
                armor = 10;
            }

            return armor;
        }

        private static long FindingHealth(string[] input)
        {
            long hp;
            try
            {
                hp = long.Parse(input[3]);
            }
            catch (Exception)
            {
                hp = 250;
            }

            return hp;
        }

        private static long FindingDamage(string[] input)
        {
            long dmg;
            try
            {
                dmg = long.Parse(input[2]);
            }
            catch (Exception)
            {
                dmg = 45;
            }

            return dmg;
        }
    }
}
