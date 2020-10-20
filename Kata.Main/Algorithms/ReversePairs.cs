using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata.Main.Algorithms
{
    class ReversePairs
    {

        public static int GetReversePairs(int[] nums)
        {
            var res = 0;
            var numsList = nums.ToList();
            for (int i = 0; i < numsList.Count - 1; i++)
            {
                var dict = new Dictionary<int, int> { { 1, 0 } };
                var di = 1;
                for (int x = i + 1; x < numsList.Count; x++)
                {
                    if (IsReversePair(numsList[i], numsList[x]))
                    {
                        dict[di] = dict[di] + (1 * di);
                    }
                    if (numsList[i] == numsList[x])
                    {
                        numsList.RemoveAt(x);
                        dict.Add(++di, 0);
                    }
                }
                res += dict.Values.Sum();
            }
            return res;
        }

        public static int ReversePairs1Dict(int[] nums)
        {
            var res = 0;
            var passed = new List<int>();
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (passed.Contains(nums[i]))
                    continue;

                var dict = new Dictionary<int, int> { { 1, 0 } };
                var di = 1;
                for (int x = i + 1; x < nums.Length; x++)
                {
                    if (IsReversePair(nums[i], nums[x]))
                    {
                        dict[di] = dict[di] + (1 * di);
                    }
                    if (nums[i] == nums[x])
                    {
                        passed.Add(nums[i]);
                        dict.Add(++di, 0);
                    }
                }
                res += dict.Values.Sum();
            }
            return res;
        }

        private static bool IsReversePair(int? a, int? b) =>
            a >= b && a > (2 * (long)b);
    }
}
