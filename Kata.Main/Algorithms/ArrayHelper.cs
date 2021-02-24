using System;
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

        static int[] rotLeft(int[] a, int d)
        {
            var r = new int[a.Length];
            for (int x = 0; x < a.Length; x++)
            {
                var rot = x + d;
                while (rot >= a.Length)
                    rot -= a.Length;
                r[x] = a[rot];
            }
            return r;
        }

        public static int Peaks(int[] A)
        {
            var peaks = new List<int>();
            for (int i = 0; i < A.Length; i++)
            {
                if ((i - 1 < 0 || A[i] >= A[i - 1]) &&
                    (i + 1 > A.Length || A[i] > A[i + 1]))
                    peaks.Add(i);
            }

            for (int i = 1; i < peaks.Count; i++)
            {
                if (peaks[i] - peaks[i - 1] < peaks.Count)
                    peaks.RemoveAt(i--);
            }
            return peaks.Count;
        }

        static int minimumSwaps(int[] arr)
        {
            var swaps = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == i + 1)
                    continue;

                var index = Array.IndexOf(arr, i + 1);
                var aux = arr[i];
                arr[i] = arr[index];
                arr[index] = aux;
                swaps++;
            }
            return swaps;
        }

        private static int[] minimalReplaces(string[] s)
        {
            var result = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i].ToCharArray();
                var replaces = 0;
                for (int j = 0; j < c.Length - 1; j++)
                {
                    if (c[j] == c[j + 1])
                    {
                        replaces++;
                        j++;
                    }
                }
                result[i] = replaces;
            }
            return result;
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

        static int jumpingOnClouds(int[] c)
        {
            var jumps = 0;
            for (int i = 0; i < c.Length - 1; i++)
            {
                if (i + 2 >= c.Length)
                    return ++jumps;

                if (c[i + 2] != 1)
                    i++;

                jumps++;
            }
            return jumps;
        }

        public static int FindPairs(int n, int[] ar)
        {
            var sar = ar.OrderBy(a => a).ToArray();
            var pairs = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                var lastIndex = Array.LastIndexOf(sar, sar[i]);
                pairs += (lastIndex + 1 - i) / 2;
                i = lastIndex;
            }
            return pairs;
        }

        public static int countingValleys(int steps, string path)
        {
            var valleys = 0;
            var currentPos = 0;
            var cPath = path.ToCharArray();
            for (int i = 0; i < cPath.Length; i++)
            {
                if (currentPos == 0 && cPath[i] == 'D')
                    valleys++;
                currentPos += cPath[i] == 'D' ? -1 : 1;
            }
            return valleys;
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
