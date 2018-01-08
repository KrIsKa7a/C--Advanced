using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ParkingSet
{
    class Program
    {
        static void Main(string[] args)
        {
            var parkingInfo = new SortedSet<string>();

            var input = Console.ReadLine();

            while (input != "END")
            {
                var inputArgs = input
                    .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var type = inputArgs[0];

                if (type == "IN")
                {
                    parkingInfo.Add(inputArgs[1]);
                }
                else
                {
                    if (parkingInfo.Contains(inputArgs[1]) && parkingInfo.Count > 0)
                    {
                        parkingInfo.Remove(inputArgs[1]);
                    }
                }

                input = Console.ReadLine();
            }

            if (parkingInfo.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                Console.WriteLine(String.Join(Environment.NewLine, parkingInfo));
            }
        }
    }
}
