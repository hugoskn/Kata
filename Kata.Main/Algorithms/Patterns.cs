using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Main.Algorithms
{
    public class Patterns
    {
        public static string FindPatterns(string value)
        {
            var result = new Dictionary<int, Dictionary<string, int>>();
            for (int i = 1; i <= 4; i++)
            {
                result.Add(i, new Dictionary<string, int>());
                for (int j = 0; j <= value.Length - i; j++)
                {
                    var pat = value.Substring(j, i);
                    if (result[i].ContainsKey(pat))
                        result[i][pat]++;
                    else
                        result[i].Add(pat, 1);
                }
            }

            var values = result.Values.Select(v => v.Values.Max(va => va));
            var resultMax = result.Values.FirstOrDefault(v => v.Values.Contains(values.ElementAt(0))).FirstOrDefault(v => v.Value == values.ElementAt(0));
            var resultMax2 = result.Values.FirstOrDefault(v => v.Values.Contains(values.ElementAt(1))).FirstOrDefault(v => v.Value == values.ElementAt(1));
            var resultMax3 = result.Values.FirstOrDefault(v => v.Values.Contains(values.ElementAt(2))).FirstOrDefault(v => v.Value == values.ElementAt(2));
            var resultMax4 = result.Values.FirstOrDefault(v => v.Values.Contains(values.ElementAt(3))).FirstOrDefault(v => v.Value == values.ElementAt(3));
            return $"\n {resultMax.Key}={resultMax.Value} \n {resultMax2.Key}={resultMax2.Value} \n {resultMax3.Key}={resultMax3.Value} \n {resultMax4.Key}={resultMax4.Value}";
        }
    }
}
