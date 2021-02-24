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

        static int luckBalance(int k, int[][] contests)
        {
            //contests = new int[][] { new[] { 5, 1 }, new[] { 2, 1 }, new[] { 1, 1 }, new[] { 8, 1 }, new[] { 10, 0 }, new[] { 5, 0 } };
            var importants = contests.Count(c => c[1] == 1);
            var sorted = contests.OrderBy(c => c[0]).ToArray();
            var luck = 0;

            for (int i = 0; i < contests.Length; i++)
            {
                if (sorted[i][1] == 0)
                {
                    luck += sorted[i][0];
                    continue;
                }

                if (importants > k)
                {
                    luck -= sorted[i][0];
                    importants--;
                }
                else
                {
                    luck += sorted[i][0];
                }
            }
            return luck;
        }
    }
}
