using System;
using System.Linq;
using System.Collections.Generic;

namespace _10.PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var command = Console.ReadLine();

            while (command != "Party!")
            {
                var commandArgs = command
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var cmdType = commandArgs[0];
                var criteria = commandArgs[1];
                var toFound = commandArgs[2];

                Func<string, string, string, bool> filter = GetFilter(criteria, toFound);

                if (cmdType == "Double")
                {
                    names = DoubleElements(names, criteria, toFound, filter);
                }
                else if (cmdType == "Remove")
                {
                    names = RemoveElements(names, criteria, toFound, filter);
                }


                command = Console.ReadLine();
            }

            if (names.Count != 0)
            {
                Console.WriteLine("{0} are going to the party!",
                    String.Join(", ", names));
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static Func<string, string, string, bool> GetFilter(string criteria, string toFound)
        {
            Func<string, string, string, bool> filter =
               (localName, localCriteria, localToFound) =>
               {
                   if (localCriteria == "StartsWith")
                   {
                       return localName.StartsWith(localToFound);
                   }
                   else if (localCriteria == "EndsWith")
                   {
                       return localName.EndsWith(localToFound);
                   }
                   else if (localCriteria == "Length")
                   {
                       return localName.Length == int.Parse(localToFound);
                   }
                   else
                   {
                       throw new NotImplementedException();
                   }
               };

            return filter;
        }

        private static List<string> DoubleElements(List<string> names, 
            string criteria, string toFound, Func<string, string, string, bool> filter)
        {
            var namesToDouble = names
                .Where(n => filter(n, criteria, toFound))
                .ToList();

            var namesDoubled = names;

            foreach (var name in namesToDouble)
            {
                var index = namesDoubled.IndexOf(name);
                namesDoubled.Insert(index, name);
            }

            return namesDoubled;
        }

        private static List<string> RemoveElements(List<string> names, 
            string criteria, string toFound, Func<string, string, string, bool> filter)
        {
            names = names
                .Where(n => !filter(n, criteria, toFound))
                .ToList();

            return names;
        }
    }
}
