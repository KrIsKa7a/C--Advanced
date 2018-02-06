using System;
using System.Linq;
using System.Collections.Generic;

namespace _07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            var nameLenght = int.Parse(Console.ReadLine());

            var names = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<string, bool> filter = name => name.Length <= nameLenght;
            Action<string> print = name => Console.WriteLine(name);

            names.Where(filter).ToList().ForEach(print);
        }
    }
}
