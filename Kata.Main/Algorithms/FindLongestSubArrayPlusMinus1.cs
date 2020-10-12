using System;
using System.Collections.Generic;

namespace Kata.Main.Algorithms
{
    class FindLongestSubArrayPlusMinus1
    {
        public static void Run()
        {
            var arr = new List<int> { 0, 2, 1, 1, 2, 1, 1, 1, 3, 3, 3, 1, 1, 3, 14 };
            var b = new int?[2];
            int resultLength, currentLength;
            resultLength = currentLength = 0;

            for (int i = 0; i < arr.Count; i++)
            {
                if (b[0] == null)
                {
                    b[0] = arr[i];
                    currentLength++;
                    continue;
                }
                if (b[0] == arr[i] || b[1] == arr[i])
                {
                    currentLength++;
                    continue;
                }
                if (b[1] == null)
                {
                    if (b[0] + 1 == arr[i])
                    {
                        b[1] = arr[i];
                        currentLength++;
                        continue;
                    }
                    else if (b[0] - 1 == arr[i])
                    {
                        b[1] = arr[i];
                        currentLength++;
                        continue;
                    }
                    else
                    {
                        currentLength = 0;
                        --i;
                        b[0] = b[1] = null;
                    }
                }
                else
                {
                    i--;
                    while (arr[i] == arr[i - 1])
                    {
                        i--;
                    }
                    i--;
                    resultLength = currentLength > resultLength ? currentLength : resultLength;
                    currentLength = 0;
                    b[0] = b[1] = null;
                }
            }
            resultLength = currentLength > resultLength ? currentLength : resultLength;
            Console.WriteLine(resultLength);
        }
    }
}
