using System.Linq;
using System.Text;

namespace Kata.Main.Algorithms
{
    class StringHelpers
    {
        private static string NumberFormater(string number)
        {
            var sb = new StringBuilder();
            int i;
            for (i = 1; i <= (number.Length - 1) / 3; i++)
            {
                sb.Insert(0, "," + number.Substring(number.Length - (i * 3), 3));
            }
            var firstChars = number.Length - ((i - 1) * 3);
            if (firstChars > 0)
                sb.Insert(0, number.Substring(0, firstChars));
            else
                sb.Remove(0, 1);
            return sb.ToString();
        }

        private static int SubstringCounter(string longS, string sub)
        {
            var subs = new string[longS.Length - sub.Length + 1];
            for (int i = 0; i <= longS.Length - sub.Length; i++)
            {
                subs[i] = longS.Substring(i, sub.Length);
            }
            return subs.Count(s => s == sub);
        }

        private static int SubStringCounter(string longString, string subString)
        {
            var l = longString.ToCharArray();
            var s = subString.ToCharArray();
            var x = 0;
            var result = 0;
            for (int i = 0; i <= longString.Length - subString.Length; i++)
            {
                if (l[i] == s[x])
                {
                    x++;
                    if (subString.Length >= x)
                    {
                        x = 0;
                        result++;
                    }
                }
            }
            return result;
        }

        private static int SubstringCounterN2(string longS, string sub)
        {
            var longc = longS.ToCharArray();
            var subc = sub.ToCharArray();
            var counter = 0;
            for (int i = 0; i <= longc.Length - subc.Length; i++)
            {
                var x = 0;
                var y = i;
                while (x < subc.Length && longc[y++] == subc[x++])
                {
                    if (x == subc.Length)
                    {
                        counter++;
                        break;
                    }
                }
            }
            return counter;
        }
    }
}
