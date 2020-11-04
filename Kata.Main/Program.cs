using Kata.Main.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Kata.Main
{
    static class Program
    {        
        static void Main(string[] args)
        {
            Console.WriteLine("Started!");
            var a = new[] { 2, 0, -3, -1, 4, 11, 14, -9, 18, 5, -23, 13 };  
            //              0, 2, 2, -1, -2, 2, 13, 27, 18, 36, 41, 18, 31
            //var a = JsonFileReader.ReadJsonFile<int[]>("TestFiles/ShortestSubArraySumData.json");
            
            var stop = new Stopwatch();
            stop.Start();
            var res = BiggestSumSlice(a);
            stop.Stop();//2374

            Console.WriteLine("elapsed ms: " + stop.ElapsedMilliseconds);
            Console.WriteLine(res);
        }

        private static int BiggestSumSlice(int[] a)
        {
            var P = new int[a.Length + 1];
            for (int i = 1; i < a.Length; i++)
                P[i] = P[i - 1] + a[i - 1];

            var result = a.Max();
            var largestIndex = 0;
            for (int i = 2; i < P.Length; i++)
            {
                if (P[i] >= P[i - 1])
                {
                    result = Math.Max(result, P[i] - P[largestIndex]);
                    continue;
                }
                else
                {
                    if (Math.Abs(a[i - 1]) > P[i])
                    {
                        while (i < P.Length && P[i] < P[i - 1])
                            i++;
                        largestIndex = i - 1;
                    }                        
                }

                
            }

            return result;

        }
    }
}
