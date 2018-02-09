using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace DangerousFloor
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new char[8][];

            for (int i = 0; i < 8; i++)
            {
                var inputRow = Console.ReadLine()
                    .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                board[i] = inputRow;
            }

            var input = Console.ReadLine();

            var pattern = @"([A-Za-z]{1})([0-9]+)-([0-9]+)";

            while (input != "END")
            {
                var match = Regex.Match(input, pattern);
                var figureToMove = char.Parse(match.Groups[1].ToString());
                var rowNow = int.Parse(match.Groups[2].ToString()[0].ToString());
                var colNow = int.Parse(match.Groups[2].ToString()[1].ToString());
                var rowToMoveOn = int.Parse(match.Groups[3].ToString()[0].ToString());
                var colToMoveOn = int.Parse(match.Groups[3].ToString()[1].ToString());

                var figureOnPosition = board[rowNow][colNow];

                if (figureToMove == 'K')
                {
                    bool canOnThatCol = colNow == colToMoveOn && (rowToMoveOn == rowNow - 1 || rowToMoveOn == rowNow + 1);
                    bool canOnThatRow = rowNow == rowToMoveOn && (colToMoveOn == colNow - 1 || colToMoveOn == colNow + 1);
                    bool leftTop = rowNow - 1 == rowToMoveOn && colNow - 1 == colToMoveOn;
                    bool rightTop = rowNow - 1 == rowToMoveOn && colNow + 1 == colToMoveOn;
                    bool leftBot = rowNow + 1 == rowToMoveOn && colNow - 1 == colToMoveOn;
                    bool rightBot = rowNow + 1 == rowToMoveOn && colNow + 1 == colToMoveOn;

                    if (figureToMove != figureOnPosition)
                    {
                        Console.WriteLine("There is no such a piece!");
                        input = Console.ReadLine();
                        continue;
                    }
                    else if (!(canOnThatCol || canOnThatRow || leftBot || leftTop ||
                            rightBot || rightTop))
                    {
                        Console.WriteLine("Invalid move!");
                        input = Console.ReadLine();
                        continue;
                    }
                    else if (rowToMoveOn >= board.Length || colToMoveOn >= board[rowToMoveOn].Length)
                    {
                        Console.WriteLine("Move go out of board!");
                        input = Console.ReadLine();
                        continue;
                    }

                    board[rowNow][colNow] = 'x';
                    board[rowToMoveOn][colToMoveOn] = 'K';
                }
                else if (figureToMove == 'R')
                {
                    bool onSameCol = colNow == colToMoveOn;
                    bool onSameRow = rowNow == rowToMoveOn;
                    if (figureToMove != figureOnPosition)
                    {
                        Console.WriteLine("There is no such a piece!");
                        input = Console.ReadLine();
                        continue;
                    }
                    else if (!(onSameCol || onSameRow))
                    {
                        Console.WriteLine("Invalid move!");
                        input = Console.ReadLine();
                        continue;
                    }
                    else if (rowToMoveOn >= board.Length || colToMoveOn >= board[rowToMoveOn].Length)
                    {
                        Console.WriteLine("Move go out of board!");
                        input = Console.ReadLine();
                        continue;
                    }

                    board[rowNow][colNow] = 'X';
                    board[rowToMoveOn][colToMoveOn] = 'R';
                }
                else if (figureToMove == 'B')
                {
                    bool diagonal = Math.Abs(rowToMoveOn - rowNow) ==
                        Math.Abs(colToMoveOn - colNow);

                    if (figureToMove != figureOnPosition)
                    {
                        Console.WriteLine("There is no such a piece!");
                        input = Console.ReadLine();
                        continue;
                    }
                    else if (!diagonal)
                    {
                        Console.WriteLine("Invalid move!");
                        input = Console.ReadLine();
                        continue;
                    }
                    else if (rowToMoveOn >= board.Length || colToMoveOn >= board[rowToMoveOn].Length)
                    {
                        Console.WriteLine("Move go out of board!");
                        input = Console.ReadLine();
                        continue;
                    }

                    board[rowNow][colNow] = 'x';
                    board[rowToMoveOn][colToMoveOn] = 'B';
                }
                else if (figureToMove == 'Q')
                {
                    bool diagonal = Math.Abs(rowToMoveOn - rowNow) ==
                        Math.Abs(colToMoveOn - colNow);
                    bool onSameCol = colNow == colToMoveOn;
                    bool onSameRow = rowNow == rowToMoveOn;

                    if (figureToMove != figureOnPosition)
                    {
                        Console.WriteLine("There is no such a piece!");
                        input = Console.ReadLine();
                        continue;
                    }
                    else if (!(diagonal || onSameCol || onSameRow))
                    {
                        Console.WriteLine("Invalid move!");
                        input = Console.ReadLine();
                        continue;
                    }
                    else if (rowToMoveOn >= board.Length || colToMoveOn >= board[rowToMoveOn].Length)
                    {
                        Console.WriteLine("Move go out of board!");
                        input = Console.ReadLine();
                        continue;
                    }

                    board[rowNow][colNow] = 'x';
                    board[rowToMoveOn][colToMoveOn] = 'Q';
                }
                else if (figureToMove == 'P')
                {
                    bool canMoveOn = colNow == colToMoveOn &&
                        rowNow - 1 == rowToMoveOn;

                    if (figureToMove != figureOnPosition)
                    {
                        Console.WriteLine("There is no such a piece!");
                        input = Console.ReadLine();
                        continue;
                    }
                    else if (!canMoveOn)
                    {
                        Console.WriteLine("Invalid move!");
                        input = Console.ReadLine();
                        continue;
                    }
                    else if (rowToMoveOn >= board.Length || colToMoveOn >= board[rowToMoveOn].Length)
                    {
                        Console.WriteLine("Move go out of board!");
                        input = Console.ReadLine();
                        continue;
                    }

                    board[rowNow][colNow] = 'x';
                    board[rowToMoveOn][colToMoveOn] = 'P';
                }
                else if (figureToMove == 'x')
                {
                    Console.WriteLine("There is no such a piece!");
                    input = Console.ReadLine();
                    continue;
                }

                input = Console.ReadLine();
            }
        }
    }
}
