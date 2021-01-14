using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Main.Algorithms
{
    class PrimeHelper
    {
        public static bool IsPrime(long number)
        {
            if (number <= 1)
                return false;
            else if (number % 2 == 0)
                return number == 2;

            long N = (long)(Math.Sqrt(number) + 0.5);

            for (int i = 3; i <= N; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }
    }
}
