using System;
using System.Linq;

namespace _03.CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var wordsInText = text
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Func<string, bool> filterForUpperCaseWords = w => char.IsUpper(w[0]);

            var upperCaseWords = wordsInText
                .Where(filterForUpperCaseWords)
                .ToList();

            foreach (var word in upperCaseWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
