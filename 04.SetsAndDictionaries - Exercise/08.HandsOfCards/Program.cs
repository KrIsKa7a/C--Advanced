using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.HandsOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictWithPoints = new Dictionary<string, int>();
            var dictWithCardsDrawn = new Dictionary<string, HashSet<string>>();

            var input = Console.ReadLine();

            while (input != "JOKER")
            {
                var inputArgs = input
                    .Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var name = inputArgs[0];
                var cards = inputArgs[1]
                    .Trim()
                    .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (!dictWithPoints.ContainsKey(name))
                {
                    dictWithPoints[name] = 0;
                }

                if (!dictWithCardsDrawn.ContainsKey(name))
                {
                    dictWithCardsDrawn[name] = new HashSet<string>();
                }

                DoingTheCardsCalculations(dictWithPoints, dictWithCardsDrawn, name, cards);

                input = Console.ReadLine();
            }

            PrintingResult(dictWithPoints);
        }

        private static void PrintingResult(Dictionary<string, int> dictWithPoints)
        {
            foreach (var kvp in dictWithPoints)
            {
                Console.WriteLine("{0}: {1}",
                    kvp.Key, kvp.Value);
            }
        }

        private static void DoingTheCardsCalculations(Dictionary<string, int> dictWithPoints, Dictionary<string, HashSet<string>> dictWithCardsDrawn, string name, string[] cards)
        {
            for (int i = 0; i < cards.Length; i++)
            {
                var currentCard = cards[i];

                var number = 0;
                var multiplier = 0;
                var secondIndex = 0;

                if (dictWithCardsDrawn[name].Contains(currentCard))
                {
                    continue;
                }

                dictWithCardsDrawn[name].Add(currentCard);

                if (currentCard.Length > 2)
                {
                    number = FindingNumberOver10(currentCard);
                    secondIndex = 2;
                }
                else
                {
                    number = FindingTheNumber(currentCard, number);

                    secondIndex = 1;
                }

                multiplier = FindingMultiplier(currentCard, multiplier, secondIndex);

                dictWithPoints[name] += number * multiplier;
            }
        }

        private static int FindingNumberOver10(string currentCard)
        {
            int number;
            var str = currentCard[0] + "" + currentCard[1];
            number = int.Parse(str);
            return number;
        }

        private static int FindingTheNumber(string currentCard, int number)
        {
            var numberToStr = currentCard[0];

            if (numberToStr >= 47 && numberToStr <= 57)
            {
                number = int.Parse(numberToStr.ToString());
            }
            else
            {
                switch (numberToStr)
                {
                    case 'J':
                        number = 11;
                        break;
                    case 'Q':
                        number = 12;
                        break;
                    case 'K':
                        number = 13;
                        break;
                    case 'A':
                        number = 14;
                        break;
                }
            }

            return number;
        }

        private static int FindingMultiplier(string currentCard, int multiplier, int secondIndex)
        {
            switch (currentCard[secondIndex])
            {
                case 'S':
                    multiplier = 4;
                    break;
                case 'H':
                    multiplier = 3;
                    break;
                case 'D':
                    multiplier = 2;
                    break;
                case 'C':
                    multiplier = 1;
                    break;
            }

            return multiplier;
        }
    }
}
