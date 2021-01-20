using System;
using System.Linq;

namespace Kata.Main.Algorithms
{
    class CakeSlices
    {
        public static decimal MaximumCakeSlice(int[] rads, int guests)
        {
            var areas = new decimal[rads.Length];
            for (int i = 0; i < rads.Length; i++)
            {
                areas[i] = (decimal)3.14159265359 * (rads[i] * rads[i]);
            }

            var guestsWoCake = guests;
            decimal sliceSize = 0;
            decimal nextSliceSize = 0;
            var addGuest = 0;
            while (guestsWoCake > 0)
            {
                guestsWoCake = guests;
                sliceSize = areas.Sum() / (guests + addGuest++);
                sliceSize = Math.Max(nextSliceSize, sliceSize);
                decimal prevLeftOver = 0;
                for (int i = 0; i < areas.Length; i++)
                {
                    var slices = (int)(areas[i] / sliceSize);
                    var leftOver = areas[i] % sliceSize;
                    guestsWoCake -= slices;
                    if (leftOver > prevLeftOver)
                    {
                        prevLeftOver = leftOver;
                        nextSliceSize = areas[i] / (slices + 1);
                    }
                }
            }
            return sliceSize;
        }
    }
}
