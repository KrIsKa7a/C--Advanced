using System;
using System.Linq;
using System.Collections.Generic;

namespace _11.ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var command = Console.ReadLine();

            Dictionary<string, Func<string, bool>> dict =
                new Dictionary<string, Func<string, bool>>();

            while (command != "Print")
            {
                var commandArgs = command
                    .Split(';')
                    .ToArray();

                var cmdType = commandArgs[0];
                var criteria = commandArgs[1];
                var toFound = commandArgs[2];
                var dictKey = $"{criteria} {toFound}";

                if (cmdType == "Add filter")
                {
                    Func<string, bool> func = GetFilter(criteria, toFound);
                    dict[dictKey] = func;
                }
                else if(cmdType == "Remove filter")
                {
                    dict.Remove(dictKey);
                }

                command = Console.ReadLine();
            }

            foreach (var kvp in dict)
            {
                var func = kvp.Value;
                names = names
                    .Where(name => !func(name))
                    .ToList();
            }

            Console.WriteLine(String.Join(" ", names));
        }

        private static Func<string, bool> GetFilter(string criteria, string toFound)
        {
            if (criteria == "Starts with")
            {
                return name =>
                {
                    return name.StartsWith(toFound);
                };
            }
            else if (criteria == "Ends with")
            {
                return name =>
                {
                    return name.EndsWith(toFound);
                };
            }
            else if (criteria == "Length")
            {
                return name =>
                {
                    return name.Length == int.Parse(toFound);
                };
            }
            else if (criteria == "Contains")
            {
                return name =>
                {
                    return name.Contains(toFound);
                };
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
