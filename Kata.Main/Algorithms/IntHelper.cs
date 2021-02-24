namespace Kata.Main.Algorithms
{
    class IntHelper
    {
        public static int CountDivisors(int n)
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
