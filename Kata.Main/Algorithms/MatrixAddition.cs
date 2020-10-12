namespace Kata.Main.Algorithms
{
    class MatrixAddition
    {
        public static int[][] TwoDimensionalMatrixAddition(int[][] a, int[][] b)
        {
            for (int x = 0; x < a.Length; x++)
            {
                for (int y = 0; y < a[0].Length; y++)
                {
                    a[x][y] += b[x][y];
                }
            }
            return a;
        }
    }
}
