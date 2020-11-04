using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata.Main.Algorithms.PrefixSums
{
    public class ShortestSubArrayLengthWitSumGte
    {
        public static int ShortestSubarray(int[] A)
        {
            var K = 3;//5837033;
            int N = A.Length;
            var P = new long[N + 1];

            //Prefix Sums
            for (int i = 1; i <= N; i++)
                P[i] = P[i - 1] + A[i - 1];

            // Want smallest y-x with P[y] - P[x] >= K
            int ans = N + 1; // N+1 is impossible
            var monoq = new List<int>(); //opt(y) candidates, as indices of P

            // [ 10, -2, 8, 7, -9, 5, 2, 3, 5, 6, -2, 3, 14, 4, -1, 2, 8, 1, -20, 5, 5 };
            //[0,10,  8, 16,23, 14,19,21,24,29,35,33, 36, 50,54,53,55,63, 64, 44, 39,34 };
            for (int y = 0; y < P.Length; ++y)
            {
                // Want opt(y) = largest x with P[x] <= P[y] - K;                
                while (monoq.Count > 0 && P[y] <= P[monoq.Last()])
                    monoq.RemoveAt(monoq.Count - 1);

                while (monoq.Count > 0 && P[y] >= P[monoq.First()] + K)
                {
                    ans = Math.Min(ans, y - monoq.First());
                    monoq.RemoveAt(0);
                }
                monoq.Add(y);
            }

            return ans < N + 1 ? ans : -1;

        }
    }
}
