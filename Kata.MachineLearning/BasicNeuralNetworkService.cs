using Accord.Neuro;
using Accord.Neuro.Learning;

namespace Kata.MachineLearning
{
    public class BasicNeuralNetworkService
    {
        public static void RunNeuralNetworkLotteryNumbers()
        {
            // Define the neural network architecture
            int inputSize = 49; // Assuming 49 numbers in the lottery
            int hiddenSize = 20; // You can adjust this based on experimentation
            int outputSize = 49; // Predicting from 49 numbers

            ActivationNetwork network = new ActivationNetwork(
                new SigmoidFunction(), inputSize, hiddenSize, outputSize);

            // Training data - You'd need historical data for actual training
            // Here, we're just using random data for demonstration purposes
            double[][] inputs = new double[100][]; // 100 random sets of "previous" lottery numbers
            double[][] outputs = new double[100][]; // 100 sets of "next" predicted lottery numbers

            Random rand = new Random();
            for (int i = 0; i < 100; i++)
            {
                inputs[i] = new double[inputSize];
                outputs[i] = new double[outputSize];

                // Assuming each input and output contains binary flags for 49 numbers
                // Generating random input and output (for demonstration purposes)
                for (int j = 0; j < inputSize; j++)
                {
                    inputs[i][j] = rand.Next(2); // Random binary values
                }

                for (int j = 0; j < outputSize; j++)
                {
                    outputs[i][j] = rand.Next(2); // Random binary values
                }
            }

            // Define the learning algorithm (e.g., BackPropagation)
            var teacher = new BackPropagationLearning(network);

            // Train the network - This is where you'd use your real training data
            double error = 1.0;
            int epoch = 0;
            while (error > 0.001 && epoch < 10000)
            {
                error = teacher.RunEpoch(inputs, outputs);
                epoch++;
            }

            // Predicting next lottery numbers
            double[] predictedNumbers = network.Compute(inputs[0]); // Using first "previous" set for prediction

            Console.WriteLine("Predicted Lottery Numbers:");
            for (int i = 0; i < predictedNumbers.Length; i++)
            {
                if (predictedNumbers[i] > 0.5) // Assuming a threshold for prediction
                {
                    Console.Write((i + 1) + " "); // Displaying the predicted numbers (index + 1)
                }
            }
        }

        public static void RunNeuralNetwork()
        {
            // Define the network architecture
            ActivationNetwork network = new ActivationNetwork(
                new SigmoidFunction(), // Activation function
                inputsCount: 5,         // Number of inputs
                4, 1//neuronsCount: 4        // Number of neurons in the hidden layer
                //outputCount: 1         // Number of outputs
            );
            
            // Define the learning algorithm (e.g., BackPropagation)
            var teacher = new BackPropagationLearning(network);

            // Training data (XOR example)
            double[][] inputs =
            {
            new double[] { 7,20,21,40,48 },
            new double[] { 9,10,11,26,44, },
            new double[] { 2,32,33,37,39 },
            new double[] { 25,27,36,39,43 }
        };

            double[][] outputs =
            {
            new double[] { 31 },
            new double[] { 36 },
            new double[] { 25 },
            new double[] { 12 }
        };

            // Train the network
            double error = 1.0;
            int epoch = 0;
            while (error > 0.001 && epoch < 10000)
            {
                error = teacher.RunEpoch(inputs, outputs);
                epoch++;
            }

            Console.WriteLine("Error: " + error + " . Epoch: " + epoch);

            // Test the trained network
            foreach (var input in inputs)
            {
                double[] output = network.Compute(input);
                Console.WriteLine($"Input: {input[0]}, {input[1]} - Output: {output[0]}");
            }

            Console.ReadLine();
        }
    }
}
