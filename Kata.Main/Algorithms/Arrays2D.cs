using System.Linq;

namespace Kata.Main.Algorithms
{
    public class Arrays2D
    {
        static int hourglassSum(int[][] arr)
        {
            var result = new int[16];
            var r = 0;
            for (int i = 1; i < arr.Length - 1; i++)
            {
                for (int j = 1; j < arr.Length - 1; j++)
                {
                    result[r] = arr[i - 1][j - 1] + arr[i - 1][j] + arr[i - 1][j + 1];
                    result[r] += arr[i][j];
                    result[r++] += arr[i + 1][j - 1] + arr[i + 1][j] + arr[i + 1][j + 1];
                }
            }
            return result.Max();
        }
    }
}
