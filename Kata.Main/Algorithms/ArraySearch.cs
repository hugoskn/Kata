using System.Linq;

namespace Kata.Main.Algorithms
{
    public class ArraySearch
    {
        public static int FindMissingNumber(int[] array)
        {
            if (array.Length <= 1)
            {
                return array.Length == 0 || array[0] != 1 ? 1 : 2;
            }

            var sortedArray = array.OrderBy(a => a).ToArray();
            var i = 1;
            for (i = 1; i <= sortedArray.Length / 2; i++)
            {
                if (sortedArray[i - 1] != i)
                {
                    return i;
                }
                if (sortedArray[sortedArray.Length - i] != sortedArray.Length + 2 - i)
                {
                    return sortedArray.Length + 2 - i;
                }
            }
            return i;
        }

        public static int FindMissingNumberFast(int[] array)
        {
            if (array.Length <= 1)
            {
                return array.Length == 0 || array[0] != 1 ? 1 : 2;
            }
            double nSplitTwo = ((array.Length + 1) / 2d);
            var gaussSum =  nSplitTwo * (1 + array.Length + 1);
            var result = gaussSum - array.Sum();

            return (int)result;
            //1-3 6
            //4=10, 5=15, 6=21, 7=28, 8=36
            //(n / 2)(first number + last number)
        }
    }
}
