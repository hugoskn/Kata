using Kata.Main.Tools;
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
            var a = new[] { 2, 0, -3, -1, 4, 11, -14, 4, -19, 18, 5, -23, 13 };

            var array = new[] { 10, 20, 30 };

            var number = 52864903;
            bool res = false;
            var stop = new Stopwatch();
            stop.Start();
            var pow = NumberFormater("6");
            stop.Stop();
            Console.WriteLine("elapsed ms: " + stop.ElapsedMilliseconds);
            Console.WriteLine($"Result: {pow}");
        }        

        private static string NumberFormater(string number)
        {
            var index3 = (number.Length - 1) / 3;
            var sb = new StringBuilder();
            int i;
            for (i = 0; i < index3; i++)
            {
                sb.Append(number.Substring(i * 3, 3) + ",");
            }
            sb.Append(number.Substring(i * 3));
            return sb.ToString();
        }

        private static int AnagramCounter(string value)
        {
            var result = 0;
            var v = value.ToCharArray();
            for (int i = 0; i < v.Length; i++)
            {                
                for (int l = v.Length - 1; l > i; l--)
                {
                    var x = i;
                    var lAux = l;
                    while(v[x] == v[lAux])
                    {
                        x++;
                        lAux--;
                        if (x >= lAux)
                        {
                            result++;
                            break;
                        }
                    }                    
                }
            }
            return result;
        }

        private static int SubStringCounter(string longString, string subString)
        {
            var l = longString.ToCharArray();
            var s = subString.ToCharArray();
            var x = 0;
            var result = 0;
            for (int i = 0; i <= longString.Length - subString.Length; i++)
            {
                if(l[i] == s[x])
                {
                    x++;
                    if(subString.Length >= x)
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
