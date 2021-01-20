using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Main.Algorithms
{
    public class Primes
    {
        public static long[] FindGapWithinNextPrime(int g, long m, long n)
        {
            for (long i = m; i < n; i++)
            {
                if (IsPrime(i))
                {
                    var j = i + 1;
                    while (!IsPrime(j) && j <= n)
                        j++;
                    if (IsPrime(j) && j - i == g)
                        return new[] { i, j };
                }
            }
            return null;
        }

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
