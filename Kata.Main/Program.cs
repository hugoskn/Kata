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
            //var testData = FileReaderHelper.ReadFileAsSingleLineInt(@"C:\EtoroFiles\whatflavors.txt", " ");

            //var pushesPops = new[] { "push", "push", "pop", "pop", "push", "push", "pop", "push", "push", "push", "push", "pop" };
            //var numbers = new[] {6, 3, 6, 5, 7, 12, 5, 10, 2, 4, 3, 2 };
            var list = new[] { 8979, 4570, 6436, 5083, 7780, 3269, 5400, 7579, 2324, 2116 };

            var stop = new Stopwatch();
            stop.Start();
            var pow = saveThePrisoner(3, 7, 3);
            //var pow = migratoryBirds(new List<int> { 1, 2, 3, 4, 5, 4, 3, 2, 1, 3, 4 });
            stop.Stop();
            Console.WriteLine("elapsed ms: " + stop.ElapsedMilliseconds + ". Elapsed s: " + stop.ElapsedMilliseconds / 1000);
            var expected = 6;
            Console.WriteLine($"Expected: {expected} Result: {pow}");
        }

        private static object saveThePrisoner(int v1, int v2, int v3)
        {
            throw new NotImplementedException();
        }
    }
    
}
