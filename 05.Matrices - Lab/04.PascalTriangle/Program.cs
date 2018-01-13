using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var height = int.Parse(Console.ReadLine());

            long[][] triangle = new long[height][];

            for (int row = 0; row < height; row++)
            {
                triangle[row] = new long[row + 1];
            }

            triangle[0][0] = 1;
            for (int row = 0; row < height - 1; row++)
            {
                for (int col = 0; col <= row; col++)
                {
                    triangle[row + 1][col] += triangle[row][col];
                    triangle[row + 1][col + 1] += triangle[row][col];
                }
            }

            for (int i = 0; i < height; i++)
            {
                Console.Write("".PadLeft((height - i) * 2));
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("{0,3} ", triangle[i][j]);
                }
                Console.WriteLine();
            }
        }
    }
}
