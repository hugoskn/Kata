using System;

namespace Kata.Main.Algorithms
{
    class PerfectSquare
    {
        public static long solve(long n)
        {
            for (long i = 1; i <= n * n; i++)
            {
                var r = n + (i * i);
                var raiz = Math.Sqrt(r);

                if (raiz % 1 == 0)
                {
                    return i * i;
                }
            }
            return -1;
        }
    }
}
