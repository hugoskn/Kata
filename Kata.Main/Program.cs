using Kata.Main.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Kata.Main
{
    static class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Started! ");
            var stop = new Stopwatch();
            stop.Start();            
            //var pow = ConvertFileToStingOfBytes(@"C:\EtoroFiles\BytesStringTests\Elon Musk ( PDFDrive ).pdf");
            //File.WriteAllText(@"C:\EtoroFiles\BytesStringTests\hugeElonmuskpddBytes", pow);
            var pdfBytes = ConvertFileToBytes(@"C:\EtoroFiles\BytesStringTests\Elon Musk ( PDFDrive ).pdf");
            //File.WriteAllBytes(@"C:\EtoroFiles\BytesStringTests\hugeElonmuskpddBytes.pdf", pdfBytes);
            stop.Stop();
            Console.WriteLine("elapsed ms: " + stop.ElapsedMilliseconds + ". Elapsed s: " + stop.ElapsedMilliseconds / 1000);
            var expected = 6;
            //Console.WriteLine($"Expected: {expected} Result: {pow}");
        }

        private static string ConvertFileToStingOfBytes(string path)
        {
            var bytes = File.ReadAllBytes(path);
            var stringResult = Convert.ToBase64String(bytes);
            return stringResult;
        }

        private static byte[] ConvertFileToBytes(string path)
        {
            var byteString = File.ReadAllText(path);
            var stringResult = Convert.FromBase64String(byteString);
            return stringResult;
        }

        static long strangeCounter(long t)
        {
            var value = 3;
            var mult = 1;
            while (value <= t)
            {
                value *= 2;
                mult++;
            }
            value = value <= 3 ? 3 : value / 2;
            var seconds = value - 2;
            
            while(seconds < t)
            {
                seconds++;
                if(--value == 0)
                {
                    value = 3 * mult++;
                }
            }
            if (seconds == t)
                return value;
            throw new Exception("Value not found");
        }

        public static string fairRations(List<int> B)
        {
            var loafs = 0;
            int i;
            for (i = 0; i < B.Count - 1; i++)
            {
                if (B[i] % 2 == 0)
                    continue;
                loafs += 2;
                B[i]++;                
                if (i == B.Count - 1)
                    return B[i] % 2 == 0 ? loafs.ToString() : "NO";
                B[i + 1]++;
            }
            return B[i] % 2 == 0 ? loafs.ToString() : "NO";
        }

        public static long taumBday(int b, int w, int bc, int wc, int z)
        {
            long blackPrice = bc <= wc + z ? bc : wc + z;
            long whitePrice = wc <= bc + z ? wc : bc + z;
            long res = (blackPrice * b) + (whitePrice * w);
            return res;
        }

        static int jumpingOnClouds(int[] c, int k)
        {
            var e = 100;
            var nextIndex = 0;
            while (e >= 0)
            {
                nextIndex = (nextIndex + k) % c.Length;
                e -= c[nextIndex] == 0 ? 1 : 3;
                if (nextIndex == 0)
                    return e;
            }

            throw new Exception("Run out of energy!");
        }

        static int minimumDistances(int[] a)
        {
            var minDist = int.MinValue;
            var dict = new Dictionary<int, bool>();
            for (int i = 0; i < a.Length; i++)
            {
                if (dict.ContainsKey(a[i]))
                    continue;

                dict.Add(a[i], true);
                var nexttIndex = i;
                while (nexttIndex != 1)
                {
                    var prevIndex = nexttIndex;
                    nexttIndex = Array.IndexOf(a.ToList().GetRange(nexttIndex + 1, a.Length - nexttIndex - 1).ToArray(), a[i]);
                    if(nexttIndex != -1)
                        minDist = Math.Min(minDist, nexttIndex - prevIndex);
                }                
            }
            return minDist;
        }

        static int equalizeArray(int[] arr)
        {
            arr = arr.OrderBy(a => a).ToArray();
            var i = 0;
            var mostRepeateadTimes = int.MinValue;
            while (i < arr.Length)
            {
                var nextIndex = Array.LastIndexOf(arr, arr[i]);
                if (nextIndex > -1)                
                    mostRepeateadTimes = Math.Max(mostRepeateadTimes, nextIndex - i + 1);
                
                i++;
            }
            return arr.Length - mostRepeateadTimes;
        }

        static string appendAndDelete(string s, string t, int k)
        {
            //Console.WriteLine(appendAndDelete("qwerasdf", "qwerbsdf", 6));
            if (k / s.Length >= 2)
                return "Yes";

            var i = 0;
            while (i < s.Length && i < t.Length && s[i] == t[i])
                i++;
            i--;
            if (i == -1)
                return k >= s.Length + t.Length ? "Yes" : "No";

            var dif = t.Length > s.Length ? t.Length - i - 1 : s.Length - i - 1;
            return k >= dif && dif % 2 == k % 2 ? "Yes" : "No";
        }

        static int findDigits(int n)
        {
            var result = 0;
            foreach (var s in n.ToString().Select(s => s.ToString()))
                if (s != "0" && n % Convert.ToInt32(s) == 0)
                    result++;
            return result;
        }

        static int viralAdvertising(int n)
        {
            var day = 0;
            var shared = 5;
            var cumLiked = 0;
            while (day < n)
            {
                day++;
                var liked = shared / 2;
                cumLiked += liked;
                shared = liked * 3;
            }

            return cumLiked;
        }
    }

}
