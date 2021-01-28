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

        public static bool IsPrime(long n)
        {
            if (n <= 1)
                return false;
            var i = 2;
            while (i * i <= n)
            {
                if (n % i++ == 0)
                    return false;
            }
            return true;
        }

    }
}
