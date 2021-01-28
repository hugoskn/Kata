using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Main.Algorithms
{
    class Anagrams
    {
        private static int AnagramCounter(string value, string anagramToFind)
        {
            var fc = anagramToFind.ToCharArray();
            var dict = new Dictionary<char, int[]>();
            for (int i = 0; i < fc.Length; i++)
            {
                if (dict.ContainsKey(fc[i]))
                    dict[fc[i]][1]++;
                else
                    dict.Add(fc[i], new[] { 0, 1 });
            }

            var vc = value.ToCharArray();
            for (int i = 0; i < vc.Length; i++)
            {
                if (dict.ContainsKey(vc[i]))
                    dict[vc[i]][0]++;
            }

            var result = int.MaxValue;
            foreach (var d in dict.Values)
            {
                result = Math.Min(result, d[0] / d[1]);
            }
            return result;
        }

        private static bool IsAnagram(string v1, string v2)
        {
            var vc1 = v1.ToCharArray();
            var vc2 = v2.ToCharArray();
            var counter = v2.Length;
            for (int i = 0; i < vc1.Length; i++)
            {
                var index = Array.IndexOf(vc2, vc1[i]);
                if (index == -1)
                    return false;
                vc2[index] = '\0';
                counter--;
            }
            return counter == 0;
        }
    }
}
