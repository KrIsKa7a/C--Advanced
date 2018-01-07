using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ReverseStrings
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var text = Console.ReadLine().ToCharArray();

            var stack = new Stack<char>(text);

            Console.WriteLine(String.Join("", stack));
        }
    }
}
