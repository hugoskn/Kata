using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Main
{
    class Program
    {
        private static List<int> Results;
        static void Main(string[] args)
        {
            var ls = new[] { "21:14", "15:34", "14:51", "06:25", "15:30" };
            var result = isTriangleNumber(125250);//3126250
            Console.WriteLine("isTriangleNumber: " + result);
            //1, 3, 6, 10, 15, 21, 28, 36, 45, 55, 66, 78, 
            //1, 2, 3, 4,  5,  6,   7, 8,  9,  10, 11, 12, 
        }

        public static bool isTriangleNumber(long number)
        {
            var triangle = 1;

            for (int i = 2; triangle <= number; i++)
            {
                triangle += 1;
                if (triangle == number)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
