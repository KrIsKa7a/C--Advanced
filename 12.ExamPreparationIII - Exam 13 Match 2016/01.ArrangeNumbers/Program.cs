using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _01.ArrangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

            var numbersToString = new List<KeyValuePair<string, string>>();

            var dictWithNumbers = new Dictionary<int, string>();
            FillDictWithNumbersAndNames(dictWithNumbers);

            foreach (var number in numbers)
            {
                var nameOfNumber = new StringBuilder();

                foreach (var num in number)
                {
                    var numToInteger = int.Parse(num.ToString());
                    nameOfNumber.Append(dictWithNumbers[numToInteger] + "-");
                }

                nameOfNumber.Remove(nameOfNumber.Length - 2, 1);
                var kvp = new KeyValuePair<string, string>(number, nameOfNumber.ToString());
                numbersToString.Add(kvp);
            }

            numbersToString = numbersToString
                .OrderBy(kvp => kvp.Value)
                .ToList();

            var orderedNumbers = new List<string>();

            foreach (var kvp in numbersToString)
            {
                orderedNumbers.Add(kvp.Key);
            }

            Console.WriteLine(String.Join(", ", orderedNumbers));
        }

        private static void FillDictWithNumbersAndNames(Dictionary<int, string> dictWithNumbers)
        {
            dictWithNumbers[0] = "zero";
            dictWithNumbers[1] = "one";
            dictWithNumbers[2] = "two";
            dictWithNumbers[3] = "three";
            dictWithNumbers[4] = "four";
            dictWithNumbers[5] = "five";
            dictWithNumbers[6] = "six";
            dictWithNumbers[7] = "seven";
            dictWithNumbers[8] = "eight";
            dictWithNumbers[9] = "nine";
        }
    }
}
