using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var phoneBook = new Dictionary<string, string>();

            var input = Console.ReadLine();

            while (input != "search")
            {
                var inputArgs = input
                    .Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (inputArgs.Length != 2)
                {
                    continue;
                }

                var name = inputArgs[0];
                var phone = inputArgs[1];

                phoneBook[name] = phone;

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "stop")
            {
                if (!phoneBook.ContainsKey(input))
                {
                    Console.WriteLine("Contact {0} does not exist.", input);
                }
                else
                {
                    Console.WriteLine("{0} -> {1}", input, phoneBook[input]);
                }

                input = Console.ReadLine();
            }
        }
    }
}
