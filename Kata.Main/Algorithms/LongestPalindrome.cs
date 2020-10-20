using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Main.Algorithms
{
    class LongestPalindrome
    {
        public static string GetLongestPalindrome(string s)
        {
            if (s.Length <= 1)
                return s;

            if (s.Length == 2)
                return s.Last() == s.First() ? s : s.First().ToString();

            var chars = s.ToCharArray();
            var result = string.Empty;
            for (int i = 0; i < chars.Length - 1; i++)
            {
                var y = i;
                int x;
                var z = chars.Length - 1;
                var pa = new List<char>();
                var pb = new List<char>();
                for (x = chars.Length - 1; x > y; x--)
                {
                    if (chars[y] == chars[x])
                    {
                        pa.Add(chars[y++]);
                        pb.Add(chars[x]);
                    }
                    else
                    {
                        if (pa.Count == 1)
                        {
                            result = result.Length > pa.Count ? result : pa.First().ToString();
                        }
                        pa.Clear();
                        pb.Clear();
                        y = i;
                        x = z--;
                    }
                }
                if (pa.Any())
                {
                    var middleChar = x == y ? chars[y].ToString() : string.Empty;
                    var pal = new string(pa.ToArray()) + middleChar + new string(pb.ToArray().Reverse().ToArray());
                    result = result.Length > pal.Length ? result : pal;
                }
            }
            return result;
        }
    }
}
