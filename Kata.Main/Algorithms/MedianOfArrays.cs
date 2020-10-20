using System.Linq;

namespace Kata.Main.Algorithms
{
    class MedianOfArrays
    {
        private static double GetMedianOfArrays(int[] nums1, int[] nums2)
        {
            var arr = MergeSorted(nums1, nums2);
            var lengthDiv2 = arr.Length / 2;
            if (arr.Count() % 2 == 1)
            {
                return arr[lengthDiv2];
            }

            var result = (double)(arr[lengthDiv2] + arr[lengthDiv2 - 1]) / 2;
            return result;
        }

        private static int[] MergeSorted(int[] nums1, int[] nums2)
        {
            var arr = new int[nums1.Length + nums2.Length];
            var n1 = 0;
            var n2 = 0;
            for (int i = 0; i < nums1.Length + nums2.Length; i++)
            {
                if (n1 < nums1.Length && nums1[n1] <= nums2[n2])
                {
                    arr[i] = nums1[n1++];
                }
                else
                {
                    arr[i] = nums2[n2++];
                }
            }

            return arr;
        }
    }
}
