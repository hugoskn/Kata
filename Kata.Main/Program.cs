using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Kata.Main
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Started!");

            var stop = new Stopwatch();
            stop.Start();
            var pow = AnagramCounter("mmmmmmmmm aaaaa nnnnn", "manm");
            stop.Stop();
            Console.WriteLine("elapsed ms: " + stop.ElapsedMilliseconds);
            Console.WriteLine($"Result: {pow}");
        }

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

        private static int[] minimalReplaces(string[] s)
        {
            var result = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i].ToCharArray();
                var replaces = 0;
                for (int j = 0; j < c.Length - 1; j++)
                {
                    if (c[j] == c[j + 1])
                    {
                        replaces++;
                        j++;
                    }
                }
                result[i] = replaces;
            }
            return result;
        }        

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

        static int jumpingOnClouds(int[] c)
        {
            var jumps = 0;
            for (int i = 0; i < c.Length - 1; i++)
            {
                if (i + 2 >= c.Length)
                    return ++jumps;

                if (c[i + 2] != 1)
                    i++;

                jumps++;
            }
            return jumps;
        }

        static long repeatedString(string s, long n)
        {
            var sCount = s.Count(c => c == 'a');
            var initial = (n / s.Length) * sCount;
            var lastCount = s.Substring(0, (int)(n % s.Length)).Count(c => c == 'a');
            return initial + lastCount;
        }

        public static int countingValleys(int steps, string path)
        {
            var valleys = 0;
            var currentPos = 0;
            var cPath = path.ToCharArray();
            for (int i = 0; i < cPath.Length; i++)
            {
                if (currentPos == 0 && cPath[i] == 'D')
                    valleys++;
                currentPos += cPath[i] == 'D' ? -1 : 1;
            }
            return valleys;
        }

        public static int FindPairs(int n, int[] ar)
        {
            var b = new int[100];
            for (int i = 0; i < ar.Length; i++)
                b[ar[i]]++;
            var pairs = 0;
            for (int i = 0; i < b.Length; i++)
                pairs += b[i] / 2;

            return pairs;
        }

        static int[] rotLeft(int[] a, int d)
        {
            var r = new int[a.Length];
            for (int x = 0; x < a.Length; x++)
            {
                var rot = x + d;
                while (rot >= a.Length)
                    rot -= a.Length;
                r[x] = a[rot];
            }
            return r;
        }

        public static int Peaks(int[] A)
        {
            var peaks = new List<int>();
            for (int i = 0; i < A.Length; i++)
            {
                if ((i - 1 < 0 || A[i] >= A[i - 1]) &&
                    (i + 1 > A.Length || A[i] > A[i + 1]))
                    peaks.Add(i);
            }

            for (int i = 1; i < peaks.Count; i++)
            {
                if (peaks[i] - peaks[i - 1] < peaks.Count)
                    peaks.RemoveAt(i--);
            }
            return peaks.Count;
        }


        private static int CountDivisors(int n)
        {
            var i = 1;
            var result = 0;
            while (i * i < n)
                if (n % i++ == 0)
                    result += 2;

            return i * i == n ? ++result : result;
        }

        //private static int CountAnagrams(string a, string b)
        //{

        //}

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

        private static int SubstringCounter(string longS, string sub)
        {
            var subs = new string[longS.Length - sub.Length + 1];
            for (int i = 0; i <= longS.Length - sub.Length; i++)
            {
                subs[i] = longS.Substring(i, sub.Length);
            }
            return subs.Count(s => s == sub);
        }

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
    }
}
