using Kata.Main.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            var pow = minimumSwaps(FileReaderHelper.ReadFileAsInt(@"C:\Users\HugoPonce\source\repos\Kata\Kata.Main\TestFiles\array sample.txt", " "));
            stop.Stop();
            Console.WriteLine("elapsed ms: " + stop.ElapsedMilliseconds);
            Console.WriteLine($"Result: {pow}");
        }

        static int minimumSwaps(int[] arr)
        {            
            var swaps = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == i + 1)
                    continue;

                var index = Array.IndexOf(arr, i + 1);
                var aux = arr[i];
                arr[i] = arr[index];
                arr[index] = aux;
                swaps++;
            }
            return swaps;
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
        
    }
}
