using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.MinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var goods = new Dictionary<string, int>();

            while (true)
            {
                var name = Console.ReadLine();

                if (name == "stop")
                {
                    break;
                }

                var quantity = int.Parse(Console.ReadLine());

                if (!goods.ContainsKey(name))
                {
                    goods[name] = quantity;
                }
                else
                {
                    goods[name] += quantity;
                }
            }

            PrintResult(goods);
        }

        private static void PrintResult(Dictionary<string, int> goods)
        {
            foreach (var kvp in goods)
            {
                Console.WriteLine("{0} -> {1}",
                    kvp.Key, kvp.Value);
            }
        }
    }
}
