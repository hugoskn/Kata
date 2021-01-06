namespace Kata.Main.Algorithms
{
    public class Power
    {
        public static (int, int)? IsPerfectPower(int n)
        {
            for (int i = 2; i <= n / 2; i++)
            {
                var res = n;
                var pow = 0;
                while (res % i == 0)
                {
                    res /= i;
                    if (res == 1)
                        return (i, pow);
                    pow++;
                }
            }
            return null;
        }
    }
}
