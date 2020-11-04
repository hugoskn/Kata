using System;
using System.Linq;

namespace Kata.Main.Algorithms.PrefixSums
{
    class BiggestSumSlice
    {
        public static int BiggestConsecutiveSumSlice(int[] a)
        {
            var P = new int[a.Length + 1];
            for (int i = 1; i < a.Length; i++)
                P[i] = P[i - 1] + a[i - 1];

            var result = a.Max();
            var largestIndex = 0;
            for (int i = 2; i < P.Length; i++)
            {
                if (P[i] >= P[i - 1])
                {
                    result = Math.Max(result, P[i] - P[largestIndex]);
                    continue;
                }
                else
                {
                    if (Math.Abs(a[i - 1]) > P[i])
                    {
                        while (i < P.Length && P[i] < P[i - 1])
                            i++;
                        largestIndex = i - 1;
                    }
                }


            }

            return result;

        }
    }
}
