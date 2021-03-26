using System;
using System.Linq;

namespace Module_3_Practice_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] numbers = { -3, -2, -1, 0, 1, 2, 3 };
            var result = numbers.Where(item => item == 5).ToArray();

            Console.WriteLine(result.Length);
        }
    }
}
