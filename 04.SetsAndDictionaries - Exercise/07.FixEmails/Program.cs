using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.FixEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            var emails = new Dictionary<string, string>();

            while (true)
            {
                var name = Console.ReadLine();

                if (name == "stop")
                {
                    break;
                }

                var email = Console.ReadLine();

                var emailArgs = email
                    .Split(new[] { '@' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var endPart = emailArgs[1];

                var endPartArguments = endPart
                    .Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var ending = endPartArguments[endPartArguments.Length - 1];

                if (ending == "us" || ending == "uk")
                {
                    continue;
                }

                emails[name] = email;
            }

            foreach (var kvp in emails)
            {
                Console.WriteLine("{0} -> {1}",
                    kvp.Key, kvp.Value);
            }
        }
    }
}
