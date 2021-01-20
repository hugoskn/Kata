using System;
using System.Numerics;

namespace Kata.Main.Algorithms
{
    class PairsMultipliedAdnSumSquare
    {
        public static BigInteger[] CalculatePairsMultipliedAdnSumSquare(int[] arr)
        {
            BigInteger sum = 1;
            for (int i = 0; i < arr.Length; i += 2)
            {
                sum *= BigInteger.Pow(arr[i], 2) + BigInteger.Pow(arr[i + 1], 2);
            }
            var root1 = (BigInteger)Math.Sqrt((long)sum);
            for (var i = root1; i > 1; i--)
            {
                var dif = sum - BigInteger.Pow(i, 2);
                if (dif == 0)
                    return new[] { 0, i };
                var root2 = (BigInteger)Math.Sqrt((long)dif);
                var dif2 = dif - BigInteger.Pow(root2, 2);
                if (dif2 == 0)
                    return new[] { root2, i };
                while (dif2 > 0)
                {
                    dif2 = dif - BigInteger.Pow(++root2, 2);
                    if (dif2 == 0)
                        return new[] { root2, i };
                }
            }
            return new BigInteger[] { 0, 0 };
        }
    }
}
