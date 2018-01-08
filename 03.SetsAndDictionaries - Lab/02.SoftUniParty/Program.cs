using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            var guestList = new SortedSet<string>();

            FillingTheGuestSet(guestList);

            var input = Console.ReadLine();

            while (input != "END")
            {
                if (guestList.Contains(input))
                {
                    guestList.Remove(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(guestList.Count);
            Console.WriteLine(String.Join(Environment.NewLine, guestList));
        }

        static void FillingTheGuestSet(SortedSet<string> guestList)
        {
            var input = Console.ReadLine();

            while (input != "PARTY")
            {
                guestList.Add(input);

                input = Console.ReadLine();
            }
        }
    }
}
