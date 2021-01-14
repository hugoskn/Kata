using Kata.Main.Algorithms;
using Kata.Main.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Kata.Main
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Started!");
            var a = new[] { 2, 0, -3, -1, 4, 11, -14, 4, -19, 18, 5, -23, 13 };

            var number = 1;
            bool res = false;
            var stop = new Stopwatch();
            stop.Start();
            var pow = Gap(2, 1, 50);
            stop.Stop();
            Console.WriteLine("elapsed ms: " + stop.ElapsedMilliseconds);
            Console.WriteLine($"Result: {pow}");
        }

        public static long[] Gap(int g, long m, long n)
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

        private static string NumberFormater(string number)
        {
            var sb = new StringBuilder();
            int i;
            for (i = 1; i <= (number.Length - 1) / 3; i++)
            {
                sb.Insert(0, "," + number.Substring(number.Length - (i * 3), 3));
            }
            var firstChars = number.Length - ((i - 1) * 3);
            if (firstChars > 0)
                sb.Insert(0, number.Substring(0, firstChars));
            else
                sb.Remove(0, 1);
            return sb.ToString();
        }

        private static int AnagramCounter(string value)
        {
            var result = 0;
            var v = value.ToCharArray();
            for (int i = 0; i < v.Length; i++)
            {
                for (int l = v.Length - 1; l > i; l--)
                {
                    var x = i;
                    var lAux = l;
                    while (v[x] == v[lAux])
                    {
                        x++;
                        lAux--;
                        if (x >= lAux)
                        {
                            result++;
                            break;
                        }
                    }
                }
            }
            return result;
        }

        private static int SubStringCounter(string longString, string subString)
        {
            var l = longString.ToCharArray();
            var s = subString.ToCharArray();
            var x = 0;
            var result = 0;
            for (int i = 0; i <= longString.Length - subString.Length; i++)
            {
                if (l[i] == s[x])
                {
                    x++;
                    if (subString.Length >= x)
                    {
                        x = 0;
                        result++;
                    }
                }
            }
            return result;
        }
    }
}
