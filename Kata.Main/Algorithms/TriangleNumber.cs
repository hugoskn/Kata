namespace Kata.Main.Algorithms
{
    class TriangleNumber
    {
        public static bool IsTriangleNumber(long number)
        {
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

        private static bool IsTriangleNumber2(long number)
        {
            var r = 0;
            var counter = 1;
            while (r < number)
            {
                r += counter;
                counter++;
            }
            return r == number;
        }

        private static bool IsTriangleNumberFast(long number)
        {
            var max = number < 15 ? 4 : number / 3;
            long min = max / 3;
            var result = TriangleSustraction(max, number);
            if (result == number)
                return true;
            while (max != min)
            {
                var mid = ((max - min) / 2) + min;
                result = TriangleSustraction(mid, number);
                if (result < number)
                    min = mid;
                else
                    max = mid;

                if (result == number)
                    return true;
            }
            return false;
        }

        private static long TriangleSustraction(long number, long limit)
        {
            var result = number * 3 - 3;
            number -= 3;
            while (number > 1)
            {
                result += number * 3 - 3;
                number -= 3;
            }

            if (number == 1)
                result++;

            return result;
        }
    }
}
