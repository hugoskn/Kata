using System.Collections.Generic;
using System.Linq;

namespace Kata.Main.Algorithms
{
    class TeamScoresBestMatch
    {
        public static int BestMatch(int[] goals1, int[] goals2)
        {
            var results = new Dictionary<int, dynamic>();
            int i;
            for (i = 0; i < goals1.Length; i++)
            {
                results.Add(i, new { Diff = goals1[i] - goals2[i], Score2 = goals2[i] });
            }

            var min = results.Values.Min(r => r.Diff);
            var res = results.Where(r => r.Value.Diff == min);

            if (res.Count() == 1)
                return res.First().Key;

            var max = res.Max(r => r.Value.Score2);
            return res.First(r => r.Value.Score2 == max).Key;
        }
    }
}
