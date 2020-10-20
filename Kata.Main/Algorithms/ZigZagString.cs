using System;

namespace Kata.Main.Algorithms
{
    class ZigZagString
    {
        public static string Convert(string s, int numRows)
        {
            var result = Convert("PAYPALISHIRING", 3);

            Console.WriteLine($"{result} == PAHNAPLSIIGYIR = {result == "PAHNAPLSIIGYIR"}");

            if (s.Length <= 2)
            {
                return s;
            }

            var cs = s.ToCharArray();
            var auxc = new char[cs.Length];
            var auxCounter = 0;
            var rowsMult = (numRows - 1) * 2;

            for (int i = 0; i < numRows; i++)
            {
                auxc[auxCounter++] = cs[i];

                var x = i * 2;
                var y = rowsMult - x;
                var z = y + i;
                while (z < auxc.Length && auxCounter < auxc.Length)
                {
                    if (y != 0)
                    {
                        auxc[auxCounter++] = cs[z];
                    }

                    z += x;
                    if (x != 0 && z < auxc.Length && auxCounter < auxc.Length)
                    {
                        auxc[auxCounter++] = cs[z];
                    }
                    z += y;

                }
            }

            return new string(auxc);
        }
    }
}
