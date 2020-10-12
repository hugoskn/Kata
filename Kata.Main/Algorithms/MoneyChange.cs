using System;

namespace Kata.Main.Algorithms
{
    public class MoneyChange
    {
        public void ReturnChange()
        {
            var coins = new[] { .01M, .05M, .10M, .25M, .50M, 1 };
            var change = 3.63M;
            var x = coins.Length - 1;

            while (change > 0 && x >= 0)
            {
                if (change >= coins[x])
                {
                    Console.WriteLine(coins[x]);
                    change -= coins[x];
                }
                else
                {
                    x--;
                }
            }
        }
    }
}
