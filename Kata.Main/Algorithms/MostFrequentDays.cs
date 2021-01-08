using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Main.Algorithms
{
    class MostFrequentDays
    {
        public static string[] MostFrequentDaysCalculator(int year)
        {
            var date = new DateTime(year, 1, 1);
            var arr = new int[7];
            for (int i = (int)date.DayOfWeek; i <= (int)DayOfWeek.Saturday; i++)
            {
                arr[i]++;
            }
            date = new DateTime(year, 12, 31);
            for (int i = (int)date.DayOfWeek; i >= (int)DayOfWeek.Sunday; i--)
            {
                arr[i]++;
            }
            var max = arr.Max();
            var result = new List<string>();
            for (int i = 1; i <= arr.Length; i++)
            {
                i = i == 7 ? 0 : i;
                if(arr[i] == max)
                {
                    var weekDay = (DayOfWeek)(i);
                    result.Add(weekDay.ToString());
                }
                if (i == 0)
                    break;

            }
            return result.ToArray();
        }

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
