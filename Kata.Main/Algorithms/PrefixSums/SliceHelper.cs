using System;
using System.Linq;

namespace Kata.Main.Algorithms.PrefixSums
{
    public class SliceHelper
    {
        private static decimal BiggestSlice(int[] array, int v)
        {
            var biggestCake = array.Max();
            var arrAux = new decimal[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                arrAux[i] = array[i] / (decimal)biggestCake;
            }

            var totalCakeAmout = arrAux.Sum();
            var slice = totalCakeAmout / v;
            var newSliceSize = slice > arrAux.Min() ? arrAux.Min() : slice;

            var slices = 0;
            while (slices < v)
            {
                slices = 0;
                slice = newSliceSize;
                decimal biggestRes = 0;

                for (int i = 0; i < arrAux.Length; i++)
                {
                    var slicesAux = (int)(arrAux[i] / slice);
                    slices += slicesAux;
                    var res = arrAux[i] % slice;
                    if (res > biggestRes)
                    {
                        biggestRes = res;
                        newSliceSize = arrAux[i] / (slicesAux + 1);
                        newSliceSize = Math.Round(newSliceSize, newSliceSize.ToString().Length - 4);
                    }
                }
            }

            return slice;
        }

        private static int LowestSumSlice(int[] a)
        {
            var P = new int[a.Length + 1];
            for (int i = 1; i < a.Length; i++)
                P[i] = P[i - 1] + a[i - 1];

            var result = a.Min();
            var largestIndex = 0;
            for (int i = 2; i < P.Length; i++)
            {

            }

            return result;

        }
    }
}
