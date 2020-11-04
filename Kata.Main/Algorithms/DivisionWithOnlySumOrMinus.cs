using System;
using System.Linq;

namespace Kata.Main.Algorithms
{
    class DivisionWithOnlySumOrMinus
    {
        public static int Divide(int dividend, int divisor)
        {
            var minus = dividend < 0 ^ divisor < 0 ? "-" : string.Empty;

            long dividendLong = Math.Abs((long)dividend);
            long divisorLong = Math.Abs((long)divisor);
            if (divisor == 0 || dividend == 0 || divisorLong > dividendLong)
            {
                return 0;
            }

            if (divisorLong == 1)
                return !string.IsNullOrWhiteSpace(minus) ?
                    dividend == int.MinValue ? int.MinValue :
                    Convert.ToInt32((minus + dividendLong).ToString()) :
                    dividend == int.MinValue ? int.MaxValue :
                    (int)dividendLong;

            if (divisorLong == dividendLong)
                return Convert.ToInt32(minus + "1");

            divisor = (int)divisorLong;
            var dividends = dividendLong.ToString().Select(s => Convert.ToInt32(s.ToString())).ToArray();
            var result = string.Empty;
            var divStringAux = string.Empty;
            long mod = 0;
            for (int i = 0; i < dividends.Length; i++)
            {
                var modPlusNext = string.Empty;
                if (mod != 0)
                {
                    modPlusNext = mod.ToString() + dividends[i].ToString();
                    mod = 0;
                }
                else
                    modPlusNext = dividends[i].ToString();

                divStringAux += modPlusNext;
                var div = Convert.ToInt64(divStringAux);
                if (div >= divisor)
                {
                    divStringAux = string.Empty;
                    long sum = divisor;
                    var multiplier = 1;
                    while (sum <= div)
                    {
                        sum += divisor;
                        multiplier++;
                    }
                    sum -= divisor;
                    mod = div - sum;
                    result += (multiplier - 1).ToString();
                }
                else
                    result += "0";
            }
            return Convert.ToInt32(minus + result.TrimStart('0'));
        }

        public static int DivideWithSum(int dividend, int divisor)
        {
            var negativeMult = dividend < 0 ^ divisor < 0 ? -1 : 1;
            divisor = Math.Abs(divisor);

            if (divisor == 1)
            {
                if (negativeMult == -1)
                    if (dividend < 0)
                        return dividend;
                    else
                        return dividend - dividend - dividend;

                if (dividend < 0)
                    return dividend == int.MinValue ? int.MaxValue : Math.Abs(dividend);
                return dividend;
            }

            var multiplier = 0;
            long sum = 0;
            var dividendAbs = dividend == int.MinValue ? int.MaxValue : Math.Abs(dividend);

            while (sum <= dividendAbs)
            {
                sum += divisor;
                multiplier = multiplier + negativeMult;
            }

            var result = multiplier - negativeMult;
            return dividend == int.MinValue ? result + 1 : result;
        }
    }
}
