using System.Linq;

namespace Kata.Main.Algorithms
{
    class SubstringForm
    {
        public static bool CanSubstringBeFormedFromString(string shortString, string s1)
        {
            var s = "abcdefabcdefabcdefaa";
            s1 = "ofosdfnsdfbgnekamndvóanbfvadfovgadnfvaoíasdfclkjclkjcbbeee"; 

            var sDistincts = shortString.Distinct();
            var sDic = sDistincts.ToDictionary(s => s, s => shortString.Count(d => d == s));

            var sDistincts1 = s1.Distinct();
            var sDic1 = sDistincts1.ToDictionary(s => s, s => s1.Count(d => d == s));

            foreach (var letter in sDic)
            {
                if (!sDic1.ContainsKey(letter.Key) || sDic1[letter.Key] < letter.Value)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
