using System;
using System.Linq;

namespace Kata.Main.Algorithms.PrefixSums
{
    public class SubArraySum
    {
        public static bool CheckSubarrayMultiple(int[] nums, int k)
        {
            k = Math.Abs(k);
            if (nums.Length < 2)
                return false;

            var P = new int[nums.Length + 1];
            for (int i = 1; i <= nums.Length; i++)
            {
                P[i] = P[i - 1] + nums[i - 1];
            }
            if (k == 0)
            {
                var counter = 1;
                var prev = P[0];
                for (int i = 1; i < P.Length; i++)
                {
                    if (prev == P[i])
                    {
                        counter++;
                        if (counter == 3)
                            return true;
                    }
                    else
                    {
                        prev = P[i];
                        counter = 1;
                    }
                }
                return false;
            }

            if (P.Any(p => p == k))
                return true;

            for (int x = P.Length - 1; x > 1; x--)
            {
                for (int y = 1; y + 1 < x; y++)
                {
                    if ((P[x] - P[y]) % k == 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
