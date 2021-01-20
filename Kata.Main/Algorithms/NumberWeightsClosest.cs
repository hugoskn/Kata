using System;
using System.Linq;

namespace Kata.Main.Algorithms
{
    class NumberWeightsClosest
    {
        public static int[][] Closest(string strng)
        {
            if (string.IsNullOrWhiteSpace(strng))
                return Array.Empty<int[]>();
            var nums = strng.Split(" ").Select(s => Convert.ToInt32(s));
            var values = new WeightsClose[nums.Count()];
            for (int i = 0; i < nums.Count(); i++)
            {
                values[i] = new WeightsClose { Weight = nums.ElementAt(i).ToString().ToCharArray().Sum(c => Convert.ToInt32(c.ToString())) };
            }

            for (int i = 0; i < values.Length; i++)
            {
                values[i].Index = i;
                values[i].MinCloseWeight = int.MaxValue;
                for (int j = 0; j < values.Length; j++)
                {
                    if (i == j)
                        continue;
                    var newMin = Math.Abs(values[i].Weight - values[j].Weight);
                    if (newMin < values[i].MinCloseWeight)
                    {
                        values[i].MinIndex = j;
                        values[i].MinCloseWeight = newMin;
                    }
                }
            }

            var minCloseWeight = values.Min(v => v.MinCloseWeight);
            var closests = values.OrderBy(o => o.Weight).First(v => v.MinCloseWeight == minCloseWeight);

            var result = new int[2][]
                {
                    new[] { closests.Weight, closests.Index, nums.ElementAt(closests.Index) },
                    new[] { values[closests.MinIndex].Weight, closests.MinIndex, nums.ElementAt(closests.MinIndex) }
                };
            return result;
        }

        public struct WeightsClose
        {
            public int Weight { get; set; }
            public int MinIndex { get; set; }
            public int MinCloseWeight { get; set; }
            public int Index { get; internal set; }
        }
    }
}
