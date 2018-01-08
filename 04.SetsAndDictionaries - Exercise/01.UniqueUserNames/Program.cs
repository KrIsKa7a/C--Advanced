using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.UniqueUserNames
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var userNames = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                var currentUserName = Console.ReadLine();

                userNames.Add(currentUserName);
            }

            Console.WriteLine(String.Join(Environment.NewLine, userNames));
        }
    }
}
