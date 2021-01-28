﻿using System.Collections.Generic;
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

        static int minimumBribes(int[] q)
        {
            if (q.Length <= 1)
                return 0;

            var nums = new int[q.Length];
            for (int i = 0; i < q.Length; i++)
                nums[i] = i + 1;

            var bribes = 0;
            for (int i = 0; i < q.Length; i++)
            {
                if (nums[i] == q[i])
                    continue;

                if ((i + 1 >= q.Length || nums[i + 1] != q[i]) && (i + 2 > q.Length || nums[i + 2] != q[i]))
                {
                    Console.WriteLine("Too chaotic");
                    return 0;
                }
                var swapPlaces = nums[i + 1] == q[i] ? 1 : 2;
                for (int j = swapPlaces; j > 0; j--)
                {
                    var aux = nums[i + j];
                    nums[i + j] = nums[i + j - 1];
                    nums[i + j - 1] = aux;
                }
                bribes += swapPlaces;
            }

            Console.WriteLine(bribes);
            return bribes;
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