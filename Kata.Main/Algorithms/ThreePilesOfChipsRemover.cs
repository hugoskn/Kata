namespace Kata.Main.Algorithms
{
    class ThreePilesOfChipsRemover
    {
        public static int Remove2DifferentChipsInOneMoveFromThreePiles(int[] arr)
        {
            var days = 0;

            while ((arr[0] > 0 && (arr[1] > 0 || arr[2] > 0)) || (arr[1] > 0 && arr[2] > 0))
            {
                days++;
                if (arr[0] >= arr[1])
                {
                    arr[0]--;
                    if (arr[1] >= arr[2])
                        arr[1]--;
                    else
                        arr[2]--;
                    continue;
                }

                arr[1]--;

                if (arr[0] > arr[2])
                    arr[0]--;
                else
                    arr[2]--;
            }

            return days;
        }
    }
}
