using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.AcademyGraduation
{
    class Program
    {
        static void Main(string[] args)
        {
            var grades = new SortedDictionary<string, double>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < 2 *n; i+=2)
            {
                var name = Console.ReadLine();
                var averageGrade = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray()
                    .Average();

                grades[name] = averageGrade;
            }

            foreach (var kvp in grades)
            {
                Console.WriteLine("{0} is graduated with {1}",
                    kvp.Key, kvp.Value);
            }
        }
    }
}
