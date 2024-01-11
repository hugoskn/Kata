using Accord.MachineLearning.DecisionTrees;
using System.Diagnostics;

namespace Kata.MachineLearning
{
    public class RandomForestKataHelper
    {
        public static RandomForest TrainRandomForest(int[][] inputs, int[] outputs, int numberOfTrees)
        {
            // Create the teacher
            var teacher = new RandomForestLearning { NumberOfTrees = numberOfTrees };

            // teach
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            Console.WriteLine($"Teaching with inputs: {inputs.Length}, outputs: {outputs.Length} ...learning...");
            var forest = teacher.Learn(inputs, outputs);         
            stopWatch.Stop();
            Console.WriteLine($"Time taken to learn: {stopWatch.ElapsedMilliseconds}ms - {stopWatch.ElapsedMilliseconds/1000} seconds");
            // Generate predictions for a new set of input data
            double[] newInput = { 10, 23, 27, 33, 48 };
            int predictedNumber = forest.Decide(newInput);

            Console.WriteLine($"Predicted Number: {predictedNumber}");
            return forest;
        }

        public static (int[][] inputs, int[] outputs) PermutToGenerateOutputs(int[][] inputs)
        {
            var inputsResults = new List<int[]>();
            var outputResults = new List<int>();
            for ( int i = 0; i < inputs.Length; i++)
            {
                Console.WriteLine($"Permutting: {i + 1}/{inputs.Length}");
                for (int j = 0; j < inputs[i].Length; j++)
                {
                    outputResults.Add(inputs[i][j]);
                    var permutation = new List<int>();
                    for (int k = 0; k < inputs[i].Length; k++)
                    {
                        if (j == k)
                            continue;
                        permutation.Add(inputs[i][k]);
                    }
                    inputsResults.Add(permutation.ToArray());
                }
            }

            return (inputsResults.ToArray(), outputResults.ToArray());
        }

    }
}