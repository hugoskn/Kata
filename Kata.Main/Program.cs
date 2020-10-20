using Kata.Main.Algorithms;
using Kata.Main.Tools;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Kata.Main
{
    class Program
    {
        private static List<int> Results;
        static void Main(string[] args)
        {
            Console.WriteLine("Started!");
            //var a = new[] { 1, 3, 2, 3, 1 };
            var a = JsonFileReader.ReadJsonFile<int[]>("TestFiles/ReversePairsData.json");
            var result = StopWatcherHelper.CountSeconds<int[], int>(ReversePairs.ReversePairs1Dict, a, 5);
            
            Console.WriteLine(result);
        }

        

        

    }
}
