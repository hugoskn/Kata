using System;
using System.Collections.Generic;

namespace Kata.Main.Algorithms
{
    public class Permutator
    {
        //2,869,685

        public static List<int[]> GenerateCombinations(int[] numbers, int combinationsOfXnumber)
        {
            List<int[]> combinations = new List<int[]>();
            int[] currentCombination = new int[combinationsOfXnumber];

            GenerateCombinationsHelper(numbers, combinations, currentCombination, 0, 0, combinationsOfXnumber);

            return combinations;
        }

        static void GenerateCombinationsHelper(int[] numbers, List<int[]> combinations, int[] currentCombination, int currentIndex, int start, int k)
        {
            if (currentIndex == k)
            {
                int[] newCombination = new int[k];
                Array.Copy(currentCombination, newCombination, k);
                combinations.Add(newCombination);
                return;
            }

            for (int i = start; i < numbers.Length; i++)
            {
                currentCombination[currentIndex] = numbers[i];
                GenerateCombinationsHelper(numbers, combinations, currentCombination, currentIndex + 1, i + 1, k);
            }
        }
    }
}
