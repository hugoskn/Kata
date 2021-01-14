using Kata.Main.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Kata.Main.Algorithms
{
    public class Power
    {
        public static long PowerSumDigTerm(int n)
        {
            var result = new SortedList<BigInteger, BigInteger>();
            for (int i = 2; i < 200; i++)
            {
                for (int j = 2; j < 200; j++)
                {
                    var pow = BigInteger.Pow(i, j);
                    if (pow / 10 < 1)
                        continue;
                    if (pow > long.MaxValue)
                        break;
                    var sum = pow.ToString().ToCharArray().Sum(c => Convert.ToInt32(c.ToString()));
                    if (sum == i)
                        result.Add(pow, pow);
                }
            }

            return (long)result.ElementAt(n - 1).Value;
        }

        public static long PowerSumDigTermBruteForce(int n)
        {
            var nth = 0;
            for (long i = 2; i < long.MaxValue; i++)
            {
                var sum = i.ToString().ToCharArray().Sum(c => Convert.ToInt32(c.ToString()));
                if (sum == 1)
                    continue;
                var pot = 2;
                double pow = 0;
                do
                {
                    pow = Math.Pow(sum, pot);
                    pot++;
                } while (pow < i);
                if (pow == i)
                {
                    if (n == ++nth)
                        return i;
                }
            }
            return 0;
        }

        public static (int, int)? IsPerfectPowerFaster(int n)
        {
            var sqr = Math.Sqrt(n);
            
            for (var i = 2; i <= sqr; i++)
            {
                var j = 1;
                while (Math.Pow(i, j) < n)
                {
                    j++;
                    if (Math.Pow(i, j) == n)
                        return (i, j);
                }
            }
            return null;
        }

        public static (int, int)? IsPerfectPowerFast(int n)
        {
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                var res = MathExtensions.NthRoot(n, i);
                if (res % 1 == 0)
                    return ((int)res, i);
            }
            return null;
        }

        public static (int, int)? IsPerfectPower(int n)
        {
            for (int i = 2; i <= n / 2; i++)
            {
                var res = n;
                var pow = 0;
                while (res % i == 0)
                {
                    res /= i;
                    if (res == 1)
                        return (i, pow);
                    pow++;
                }
            }
            return null;
        }
    }
}
