using System.Collections.Generic;
using System.Linq;

namespace Kata.Main.Algorithms
{
    class ArrayHelper
    {
        public static int[] CyclicRotation(int[] arr, int steps)
        {
            var res = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                var newPos = i + steps;
                while (newPos >= arr.Length)
                    newPos -= arr.Length;
                res[newPos] = arr[i];
            }
            return res;
        }

        public static int OneOddNumberOccurrence(int[] arr)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (dict.ContainsKey(arr[i]))
                    dict.Remove(arr[i]);
                else
                    dict.Add(arr[i], 1);
            }
            return dict.Keys.ElementAt(0);
        }

        public static bool ExistsSwapToGetSum(int[] A, int[] B, int M)
        {
            var sumA = A.Sum();
            var sumB = B.Sum();
            var d = sumB - sumA;
            if (d % 2 != 0)
                return false;

            var count = new int[M + 1];
            for (int i = 0; i < A.Length; i++)
                count[A[i]]++;

            for (int i = 0; i < B.Length; i++)
            {
                if (B[i] - 2 > 0 && count[B[i] - 2] > 0)
                    return true;
            }
            return false;
        }
    }
}
