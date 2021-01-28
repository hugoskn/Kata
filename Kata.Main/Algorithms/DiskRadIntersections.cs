using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Main.Algorithms
{
    class DiskRadIntersections
    {
        public static int DiscIntersections(int[] A)
        {
            var tuple = new List<Tuple<int, int>>();
            for (int i = 0; i < A.Length; i++)
                tuple.Add(new Tuple<int, int>(i - A[i], i + A[i]));

            tuple = tuple.OrderBy(t => t.Item1).ToList();
            var intersections = 0;
            for (int i = 0; i < tuple.Count - 1; i++)
            {
                for (int j = i + 1; j < tuple.Count; j++)
                {
                    if ((tuple[j].Item1 >= tuple[i].Item1 && tuple[j].Item1 <= tuple[i].Item2) ||
                        (tuple[j].Item2 >= tuple[i].Item1 && tuple[j].Item2 <= tuple[i].Item2))
                        intersections++;
                }
            }
            return intersections;
        }
    }
}
