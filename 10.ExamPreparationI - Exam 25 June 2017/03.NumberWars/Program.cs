using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.NumberWars
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstPlayerCards = new Queue<string>(Console.ReadLine()
                     .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            var secondPlayerCards = new Queue<string>(Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

            var turns = 0;
            bool gameOver = false;

            while (turns < 1_000_000 && firstPlayerCards.Count > 0 && 
                secondPlayerCards.Count > 0 && !gameOver)
            {
                turns++;
                var fpCard = firstPlayerCards.Dequeue();
                var spCard = secondPlayerCards.Dequeue();

                if (GetCardNumber(fpCard) > GetCardNumber(spCard))
                {
                    firstPlayerCards.Enqueue(fpCard);
                    firstPlayerCards.Enqueue(spCard);
                }
                else if (GetCardNumber(fpCard) < GetCardNumber(spCard))
                {
                    secondPlayerCards.Enqueue(spCard);
                    secondPlayerCards.Enqueue(fpCard);
                }
                else
                {
                    var currentHand = new List<string>();
                    currentHand.Add(fpCard);
                    currentHand.Add(spCard);

                    while (firstPlayerCards.Count >= 3 && secondPlayerCards.Count >= 3)
                    {
                        if (firstPlayerCards.Count < 3 || secondPlayerCards.Count < 3)
                        {
                            gameOver = true;
                            break;
                        }

                        var firstPlayerSum = 0;
                        var secondPlayerSum = 0;

                        for (int i = 0; i < 3; i++)
                        {
                            var firstcard = firstPlayerCards.Dequeue();
                            var secondCard = secondPlayerCards.Dequeue();
                            firstPlayerSum += GetCardCharValue(firstcard);
                            secondPlayerSum += GetCardCharValue(secondCard);
                            currentHand.Add(firstcard);
                            currentHand.Add(secondCard);
                        }

                        if (firstPlayerSum > secondPlayerSum)
                        {
                            currentHand = currentHand
                                .OrderByDescending(c => GetCardNumber(c))
                                .ThenByDescending(c => GetCardCharValue(c))
                                .ToList();

                            foreach (var card in currentHand)
                            {
                                firstPlayerCards.Enqueue(card);
                            }
                        }
                        else if (firstPlayerSum < secondPlayerSum)
                        {
                            currentHand = currentHand
                                .OrderByDescending(c => GetCardNumber(c))
                                .ThenByDescending(c => GetCardCharValue(c))
                                .ToList();

                            foreach (var card in currentHand)
                            {
                                secondPlayerCards.Enqueue(card);
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }


            if (firstPlayerCards.Count > secondPlayerCards.Count)
            {
                Console.WriteLine($"First player wins after {turns} turns");
            }
            else if (firstPlayerCards.Count < secondPlayerCards.Count)
            {
                Console.WriteLine($"Second player wins after {turns} turns");
            }
            else
            {
                Console.WriteLine($"Draw after {turns} turns");
            }
        }

        static int GetCardNumber(string card)
        {
            return int.Parse(card.Substring(0, card.Length - 1));
        }

        static int GetCardCharValue(string card)
        {
            return card[card.Length - 1] - 96;
        }
    }
}
