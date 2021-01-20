using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Main.Algorithms
{
    class DigitsSumWithDigitsGreatThanNext
    {
        public static List<long> FindNumberDigitsGreaterThanNextDigit(int sumDigits, int numDigits)
        {
            var result = new List<long>();
            var start = (long)Math.Pow(10, numDigits - 1);
            long elevens = 1111111111111111111;
            var aux = (long)(elevens / Math.Pow(10, elevens.ToString().Length - start.ToString().Length));
            for (var i = aux; i < start * 10; i++)
            {
                var digits = i.ToString().ToCharArray().Select(c => Convert.ToInt32(c.ToString())).ToArray();
                if (digits[digits.Length - 1] == 0)
                {
                    for (int j = 1; j < digits.Length; j++)
                        if (digits[j] == 0)
                            digits[j] = digits[j - 1];
                    i = Convert.ToInt64(string.Join("", digits.Select(d => d.ToString())));
                }
                if (digits.Sum() == sumDigits)
                    result.Add(i);
            }
            return result.Any() ? new List<long> { result.Count, result.First(), result.Last() } : result;
        }
    }
}
