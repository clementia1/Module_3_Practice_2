using System;
using System.Linq;

namespace Module_3_Practice_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] numbers = { -3, -2, -1, 0, 1, 2, 3 };
            var result = numbers.Skip(5).Take(10);

            foreach (int i in result)
            {
                Console.WriteLine(i);
            }
        }
    }
}
