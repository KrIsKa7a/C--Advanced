using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _03.SoftUniNumerals
{
    class Program
    {
        static void Main(string[] args)
        {
            var numeralString = Console.ReadLine();

            var dictWithNumbers = new Dictionary<string, int>()
            {
                {"aa", 0},
                {"aba", 1},
                {"bcc", 2},
                {"cc", 3},
                {"cdc", 4}
            };
            var result = GetNumberIn5th(ref numeralString, dictWithNumbers);
            BigInteger numberIn10 = GetNumberIn10(result);

            Console.WriteLine(numberIn10);
        }

        private static BigInteger GetNumberIn10(string result)
        {
            BigInteger numberIn10 = 0;
            var power = 0;

            for (int i = result.Length - 1; i >= 0; i--)
            {
                var num = result[i];
                numberIn10 += (int.Parse(num.ToString()) * BigInteger.Pow(5, power));
                power++;
            }

            return numberIn10;
        }

        private static string GetNumberIn5th(ref string numeralString, Dictionary<string, int> dictWithNumbers)
        {
            var result = string.Empty;

            while (numeralString.Length > 0)
            {
                var firstTwoLetters = numeralString.Substring(0, 2);
                string firstThreeLetters = string.Empty;

                if (numeralString.Length >= 3)
                {
                    firstThreeLetters = numeralString.Substring(0, 3);
                }

                if (dictWithNumbers.ContainsKey(firstTwoLetters))
                {
                    result += dictWithNumbers[firstTwoLetters];
                    numeralString = numeralString.Remove(0, 2);
                }
                else if (dictWithNumbers.ContainsKey(firstThreeLetters))
                {
                    result += dictWithNumbers[firstThreeLetters];
                    numeralString = numeralString.Remove(0, 3);
                }
            }

            return result;
        }
    }
}
