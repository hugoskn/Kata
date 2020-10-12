namespace Kata.Main.Algorithms
{
    class TriangleNumber
    {
        public static bool IsTriangleNumber(long number)
        {
            //    return Math.Sqrt(1 + 8 * number) % 1 == 0;
            if (number <= 1)
            {
                return true;
            }
            var triangle = 1;

            for (int i = 2; triangle <= number; i++)
            {
                triangle += i;
                if (triangle == number)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
