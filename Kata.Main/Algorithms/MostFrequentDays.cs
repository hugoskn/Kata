using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Main.Algorithms
{
    class MostFrequentDays
    {
        public static string[] GetMostFrequentDays(int year)
        {
            var arr = new Dictionary<int, int> { { 0, 0 }, { 1, 0 }, { 2, 0 }, { 3, 0 }, { 4, 0 }, { 5, 0 }, { 6, 0 } };
            var dt = new DateTime(year, 1, 1);
            while (dt.Year == year)
            {
                arr[(int)dt.DayOfWeek]++;
                dt = dt.AddDays(1);
            }

            var max = arr.Values.Max();
            var indexes = arr.Where(a => a.Value == max).OrderBy(a => a.Key);
            var days = indexes.Select(i => Enum.GetName(typeof(DayOfWeek), i.Key)).ToArray();

            return days;
        }
    }
}
