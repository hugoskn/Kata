using System;
using System.Linq;

namespace Kata.Main.Algorithms
{
    class TimeAlarmsMinus
    {
        public static string solve(string[] arr)
        {
            if (arr == null || arr.Length <= 1)
            {
                return "23:59";
            }

            var result = TimeSpan.FromSeconds(0);
            var sortedTimes = arr.OrderBy(a => a).ToArray();
            for (int i = 1; i <= arr.Length; i++)
            {
                if (i == arr.Length)
                {
                    var aux2 = TimeSpan.Parse("23:59") - TimeSpan.Parse(sortedTimes[i - 1]);
                    aux2 += TimeSpan.Parse(sortedTimes[0]);
                    result = result > aux2 ? result : aux2;
                    return (result).ToString(@"hh\:mm");
                }
                var aux = TimeSpan.Parse(sortedTimes[i]) - TimeSpan.Parse(sortedTimes[i - 1]);
                result = result > aux ? result : aux;
            }
            return (result - TimeSpan.FromMinutes(1)).ToString(@"hh\:mm");
        }
    }
}
