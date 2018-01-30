using System;
using System.Linq;
using System.Text;

namespace _11.ParkingSystem
{
    class Program
    {
        public static int[][] parking;
        static void Main(string[] args)
        {
            var matrixSizes = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rowsCount = matrixSizes[0];
            var colsCount = matrixSizes[1];

            parking = new int[rowsCount][];

            var input = Console.ReadLine();

            while (input != "stop")
            {
                var inputArgs = input
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var startRow = inputArgs[0];
                var rowToGo = inputArgs[1];
                var colToGo = inputArgs[2];

                var travelledDistance = 0;

                if (parking[rowToGo] == null)
                {
                    parking[rowToGo] = new int[colsCount];
                    parking[rowToGo][0] = -1;
                }

                if (!parking[rowToGo].Contains(0))
                {
                    Console.WriteLine("Row {0} full",
                        rowToGo);
                    input = Console.ReadLine();
                    continue;
                }

                var toGoToTheWantedRow = Math.Abs(rowToGo - startRow) + 1;

                //Here we assume we are at the wanted row

                var wantedRow = parking[rowToGo];
                var wantedCell = parking[rowToGo][colToGo];

                if (wantedCell == 0)
                {
                    parking[rowToGo][colToGo] = 1;
                    travelledDistance += toGoToTheWantedRow;
                    travelledDistance += colToGo;
                    Console.WriteLine(travelledDistance);
                }
                else
                {
                    var indexOfClosestLeftCell = FindingIndexOfClosestLeftCell(rowToGo, colToGo);
                    var indexOfClosestRightCell = FindingIndexOfClosestRightCell(rowToGo, colToGo);

                    var distanceBetweenLeftCellAndMyCell = colToGo - indexOfClosestLeftCell;
                    var distanceBetweenRightCellAndMyCell = indexOfClosestRightCell - colToGo;

                    if (indexOfClosestRightCell == 0)
                    {
                        parking[rowToGo][indexOfClosestLeftCell] = 1;
                        travelledDistance += toGoToTheWantedRow;
                        travelledDistance += indexOfClosestLeftCell;
                    }
                    else if (indexOfClosestLeftCell == 0)
                    {
                        parking[rowToGo][indexOfClosestRightCell] = 1;
                        travelledDistance += toGoToTheWantedRow;
                        travelledDistance += indexOfClosestRightCell;
                    }
                    else
                    {
                        if (distanceBetweenLeftCellAndMyCell < distanceBetweenRightCellAndMyCell)
                        {
                            parking[rowToGo][indexOfClosestLeftCell] = 1;
                            travelledDistance += toGoToTheWantedRow;
                            travelledDistance += indexOfClosestLeftCell;
                        }
                        else if (distanceBetweenRightCellAndMyCell < distanceBetweenLeftCellAndMyCell)
                        {
                            parking[rowToGo][indexOfClosestRightCell] = 1;
                            travelledDistance += toGoToTheWantedRow;
                            travelledDistance += indexOfClosestRightCell;
                        }
                        else
                        {
                            parking[rowToGo][indexOfClosestLeftCell] = 1;
                            travelledDistance += toGoToTheWantedRow;
                            travelledDistance += indexOfClosestLeftCell;
                        }
                    }

                    Console.WriteLine(travelledDistance);
                }

                input = Console.ReadLine();
            }
        }

        private static int FindingIndexOfClosestRightCell(int rowToGo, int colToGo)
        {
            var indexOfClosestRightCell = 0;

            for (int col = colToGo; col < parking[rowToGo].Length; col++)
            {
                if (parking[rowToGo][col] == 0)
                {
                    indexOfClosestRightCell = col;
                    break;
                }
            }

            return indexOfClosestRightCell;
        }

        private static int FindingIndexOfClosestLeftCell(int rowToGo, int colToGo)
        {
            var indexOfClosestLeftCell = 0;

            for (int col = colToGo; col >= 1; col--)
            {
                if (parking[rowToGo][col] == 0)
                {
                    indexOfClosestLeftCell = col;
                    break;
                }
            }

            return indexOfClosestLeftCell;
        }
    }
}
