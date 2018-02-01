using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            var wordsToFind = new List<string>();

            FindWantedWords(wordsToFind);

            var pattern = @"[A-Za-z]+";
            var wordsFrequency = new Dictionary<string, int>();

            using (var reader = new StreamReader("../Resources/text.txt"))
            {
                while (true)
                {
                    var currentLine = reader.ReadLine();

                    if (currentLine == null)
                    {
                        break;
                    }

                    var wordsInCurrentLine = Regex.Matches(currentLine, pattern);

                    SaveWordsFrequency(wordsToFind, wordsFrequency, wordsInCurrentLine);
                }
            }

            wordsFrequency = wordsFrequency
                .OrderByDescending(w => w.Value)
                .ToDictionary(a => a.Key, b => b.Value);

            PrintResult(wordsFrequency);
        }

        private static void PrintResult(Dictionary<string, int> wordsFrequency)
        {
            using (var writer = new StreamWriter("./result.txt"))
            {
                foreach (var wfp in wordsFrequency)
                {
                    var word = wfp.Key;
                    var wordOccurances = wfp.Value;

                    writer.WriteLine($"{word} - {wordOccurances}");
                }
            }
        }

        private static void SaveWordsFrequency(List<string> wordsToFind, Dictionary<string, int> wordsFrequency, MatchCollection wordsInCurrentLine)
        {
            foreach (Match word in wordsInCurrentLine)
            {
                var wordCaseInsensitive = word.ToString().ToLower();
                if (wordsToFind.Contains(wordCaseInsensitive))
                {
                    if (!wordsFrequency.ContainsKey(wordCaseInsensitive))
                    {
                        wordsFrequency[wordCaseInsensitive] = 1;
                    }
                    else
                    {
                        wordsFrequency[wordCaseInsensitive]++;
                    }
                }
            }
        }

        private static void FindWantedWords(List<string> wordsToFind)
        {
            using (var reader = new StreamReader("../Resources/words.txt"))
            {
                while (true)
                {
                    var currentWord = reader.ReadLine();

                    if (currentWord == null)
                    {
                        break;
                    }

                    wordsToFind.Add(currentWord.ToLower());
                }
            }
        }
    }
}
