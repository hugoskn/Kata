using Kata.Main.Tools;
using System;

namespace Kata.Main.Algorithms
{
    public class Power
    {
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
