﻿using Accord.MachineLearning.DecisionTrees;
using Kata.MachineLearning;
using Kata.Main.Algorithms;
using Kata.Main.Tools;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Kata.Main
{
    static class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Started! ");
            var stop = new Stopwatch();
            stop.Start();
            await MelateService.FindOcurrencesOfTickets();
            //BasicNeuralNetworkService.RunNeuralNetworkLotteryNumbers();
            //var values = File.ReadAllLines(@"C:\Shared\arrayManip.txt");
            //Console.WriteLine(ArrayHelper.arrayManipulation(10, new List<List<int>> { new(){ 1, 5, 3 }, new() { 4, 8, 7 }, new() { 6, 9, 1 } }));
            //var valuesinputs = values.Select(s => s.Split(" ").Select(s => Convert.ToInt32(s)).ToImmutableArray()).ToImmutableArray();
            //var startN = valuesinputs[0][0];

            //var allLines = File.ReadAllLines(@"C:\Shared\AppsForFun\Melate predictor\Melate Results.csv");
            //var dataValues = allLines.Select(l => l.Split(',').Select(s => Convert.ToInt32(s)).ToArray()).ToArray();

            //var (permutedInputs, permutedOutputs) = RandomForestKataHelper.PermutToGenerateOutputs(dataValues);
            //var forestPredictor = RandomForestKataHelper.TrainRandomForest(permutedInputs, permutedOutputs, 100);
            //PermutFrom1to56AndPredict(forestPredictor);
            //valuesinputs.RemoveAt(0);
            //Console.WriteLine("\n elapsed ms: " + stop.ElapsedMilliseconds + ". Elapsed s: " + stop.ElapsedMilliseconds / 1000);
            //Console.WriteLine(ArrayHelper.arrayManipulation(startN, valuesinputs));
            //var result = FindMaxNUmberAfterRemoveFive(-5859);
            //DisticntsOrders();
            //TextFilesParser.JiraExtractor();
            //await TextFilesParser.TransformToTextMarketplacesJsonVaris();
            //BettingCalculator.CalcualteOptimalBetAmounts();
            //var pow = ConvertFileToStingOfBytes(@"C:\EtoroFiles\BytesStringTests\Elon Musk ( PDFDrive ).pdf");
            //File.WriteAllText(@"C:\EtoroFiles\BytesStringTests\hugeElonmuskpddBytes", pow);
            //var pdfBytes = ConvertFileToBytes(@"C:\EtoroFiles\BytesStringTests\Elon Musk ( PDFDrive ).pdf");
            //File.WriteAllBytes(@"C:\EtoroFiles\BytesStringTests\hugeElonmuskpddBytes.pdf", pdfBytes);
            stop.Stop();
            Console.WriteLine("\n elapsed ms: " + stop.ElapsedMilliseconds + ". Elapsed s: " + stop.ElapsedMilliseconds / 1000);
            //var expected = -589;
            //Console.WriteLine($"Expected: leetcode Result");
            Console.ReadLine();
        }

        public static void PermutFrom1to56AndPredict(RandomForest forest)
        {
            int[] numbers = new int[56];
            var predictionsResults = new int[57];

            for (int i = 0; i < 56; i++)
            {
                numbers[i] = i + 1;
            }


            List<int[]> combinations = Permutator.GenerateCombinations(numbers, 5);

            // Print or process the combinations as needed
            Console.WriteLine($"Predicting combinations: {combinations.Count} ...");
            for (int i = 0;i < combinations.Count;i++)
            {
                predictionsResults[forest.Decide(combinations[i])]++;
                //Console.WriteLine($"Comb: {string.Join(", ", combination)} - Prediction: {prediction}");                
            }
            Console.WriteLine($"Finish predicting combinations: {combinations.Count}!");
            File.WriteAllText(@"C:\Shared\AppsForFun\Melate predictor\Melate Predictions.json", JsonSerializer.Serialize(predictionsResults));
            var predictionsResultsString = "";
            for (int i = 0; i < predictionsResults.Length; i++)
                predictionsResultsString += i + "," + predictionsResults[i] + "\n";
            File.WriteAllText(@"C:\Shared\AppsForFun\Melate predictor\Melate Predictions.txt", predictionsResultsString);
        }

        public static void PrintSpiral(List<List<int>> values)
        {
            var startIndex = 0;
            var leftRightStart = 0;
            var leftRightEnd = values[0].Count;
            var topBottomEnd = values.Count;
            var rightLeft = 0;
            var bottomTop = 1;
            var i = 0;
            var j = 0;

            for (startIndex = 0; startIndex < topBottomEnd; startIndex++)
            {
                for (i = leftRightStart; i < leftRightEnd; i++)
                    Console.WriteLine(values[startIndex][i]);
                
                leftRightStart++;
                leftRightEnd--;
                for (j = startIndex + 1; j < topBottomEnd; j++)
                    Console.WriteLine(values[j][i]);

                for (int k = j; k < j; k++)
                    Console.WriteLine(values[j][i]);

            }
        }

        public static string ExerciseChris(string valueString)
        {
            var result = ExerciseChris("(ed(et(oc))el)");
            Console.WriteLine($"Expected: leetcode Result: {result}");
            var result2 = ExerciseChris("(u(love)i)");
            Console.WriteLine($"Expected: iloveu Result: {result2}");
            var result3 = ExerciseChris("(abcd)");
            var value = valueString.ToCharArray().ToList();
            while (value.Contains('('))
            {
                var lastOpenPar = value.LastIndexOf('(');
                var firstClosePar = value.IndexOf(')');
                if (lastOpenPar == -1 || firstClosePar == -1)
                    break;
                for (int j = 0; j < (firstClosePar - lastOpenPar) / 2; j++)
                {
                    var aux = value[lastOpenPar + j + 1];
                    value[lastOpenPar + j + 1] = value[firstClosePar - 1 - j];
                    value[firstClosePar - 1 - j] = aux;
                }
                value.RemoveAt(lastOpenPar);
                value.RemoveAt(firstClosePar - 1);
            }

            return new string(value.ToArray());
        }

        public static string ExerciseChrisBruteForce(string value)
        {
            var lastIndexParenthesis = -1;
            var valueChars = value.ToList();
            var initialCharsCount = value.Length;
            for (int i = 0; i < initialCharsCount; i++)
            {
                if (value[i] == '(')
                {
                    lastIndexParenthesis = i;
                    continue;
                }
                if (value[i] == ')')
                {
                    var substring = value.Substring(lastIndexParenthesis + 1, i - lastIndexParenthesis - 1).Reverse();
                    for (int j = 0; j < substring.Count(); j++)
                    {
                        value = value.Insert(lastIndexParenthesis + 1 + j, substring.ElementAt(j).ToString());
                    }
                    value = value.Remove(i, substring.Count() + 1);
                    value = value.Remove(lastIndexParenthesis, 1);
                    i = -1;
                    initialCharsCount = value.Length;
                }
            }
            return value;
        }

        private class CostModel { public string MeterCategory { get; set; } public decimal Cost { get; set; } }

        private static void CostCalculator()
        {
            Console.WriteLine("Type Company name to calculate cost:");
            var companyName = Console.ReadLine();
            var filePath = @"C:\Users\hugos\Downloads\prod costs - Reduced More.csv";
            Console.WriteLine("Reading file in: " + filePath);
            var fileTextLines = File.ReadAllLines(filePath);
            if (fileTextLines?.Length <= 0)
            {
                Console.WriteLine("No data found");
                return;
            }
            Console.WriteLine("Read file successfully");
            Console.WriteLine("EXtracting values from rows containing " + companyName + " ...");
            decimal totalCost = 0;
            var result = new List<CostModel>();
            for (int i = 0; i < fileTextLines.Length; i++)
            {
                if (!fileTextLines[i].Contains(companyName, StringComparison.InvariantCultureIgnoreCase))
                    continue;
                var lineTexts = fileTextLines[i].Split(",");
                if (lineTexts.Length <= 0)
                    continue;

                var meterCategory = lineTexts[2];
                var cost = Convert.ToDecimal(lineTexts[7]);
                totalCost += cost;
                result.Add(new CostModel { MeterCategory = meterCategory, Cost = cost });
            }

            Console.WriteLine("Finish extracting values! \n");
            var groupedByMeter = result.GroupBy(r => r.MeterCategory);
            foreach (var meter in groupedByMeter)
                Console.WriteLine($"{meter.Key}, {meter.Sum(m => m.Cost)}");

            Console.WriteLine("________________");
            Console.WriteLine("TOTAL COST: " + totalCost);
            File.WriteAllLines(filePath.Replace("More.csv", "More Result.csv"), result.Select(r => $"{r.MeterCategory}, {r.Cost}"));
            File.WriteAllLines(filePath.Replace("More.csv", "More Result Grouped.csv"), groupedByMeter.Select(r => $"{r.Key}, {r.Sum(g => g.Cost)}"));
        }

        private static int FindMaxNUmberAfterRemoveFive(int number)
        {
            var maxResult = int.MinValue;
            var posNeg = number < 0 ? -1 : 1;
            var charsNumbers = number.ToString().ToList();
            for (var i = 0; i < charsNumbers.Count; i++)
            {
                if (charsNumbers[i] != '5')
                    continue;

                charsNumbers.RemoveAt(i);
                var wo5 = posNeg * int.Parse(new String(charsNumbers.ToArray()));
                charsNumbers.Insert(i, '5');
                maxResult = Math.Max(maxResult, wo5 * posNeg);
            }
            return maxResult == int.MinValue ? 0 : maxResult;
        }

        private static void TextParser()
        {
            Console.WriteLine("Text Parser. Reading file...");
            var fileTextLines = File.ReadAllLines(@"C:/Shared/TodaysPicks-StockTradingHackers.txt");
            var startIndexText = "ticker: \"";
            var endIndexText = "\", exchange";
            var result = new List<string>();
            for (int i = 0; i < fileTextLines.Length; i++)
            {
                if (!fileTextLines[i].Contains(startIndexText))
                    continue;

                var startIndex = fileTextLines[i].IndexOf(startIndexText) + startIndexText.Length;
                var endIndex = fileTextLines[i].IndexOf(endIndexText);
                var stringResult = fileTextLines[i].Substring(startIndex, endIndex - startIndex);
                result.Add(stringResult);
            }
            File.WriteAllLines(@"C:/Shared/TodaysPicks-StockTradingHackers-Results.txt", result);
        }

        private static string ParseBasicInputLine(string propertyNameLine, string questionTextLine)
        {
            var fieldText = "basicVal={this.state.medicalHistory.";
            var propertyName = ParseSubstringLine(propertyNameLine, fieldText, "}");

            var questionValue = ParseSubstringLine(questionTextLine, ">", "<");

            return $"public const string {propertyName.FirstCharToUpper()} = \"{questionValue}\";";
        }

        private static string ParseMedicalQuestionLine(string fileLine)
        {
            var fieldText = "field={'";
            var labelText = "label='";
            var propertyName = ParseSubstringLine(fileLine, fieldText, "'}");
            var questionValue = ParseSubstringLine(fileLine, labelText, "'");
            return $"public const string {propertyName.FirstCharToUpper()} = \"{questionValue}\";";
        }

        private static string ParseSubstringLine(string textLineToParse, string startText, string endText)
        {
            var startIndex = textLineToParse.IndexOf(startText);
            if (startIndex == -1)
                return null;
            var endIndex = textLineToParse.Substring(startIndex + startText.Length).IndexOf(endText);
            var textResult = textLineToParse.Substring(startIndex + startText.Length, endIndex);
            return textResult;
        }

        private static string ConvertFileToStingOfBytes(string path)
        {
            var bytes = File.ReadAllBytes(path);
            var stringResult = Convert.ToBase64String(bytes);
            return stringResult;
        }

        private static byte[] ConvertFileToBytes(string path)
        {
            var byteString = File.ReadAllText(path);
            var stringResult = Convert.FromBase64String(byteString);
            return stringResult;
        }

        static long strangeCounter(long t)
        {
            var value = 3;
            var mult = 1;
            while (value <= t)
            {
                value *= 2;
                mult++;
            }
            value = value <= 3 ? 3 : value / 2;
            var seconds = value - 2;

            while (seconds < t)
            {
                seconds++;
                if (--value == 0)
                {
                    value = 3 * mult++;
                }
            }
            if (seconds == t)
                return value;
            throw new Exception("Value not found");
        }

        public static string fairRations(List<int> B)
        {
            var loafs = 0;
            int i;
            for (i = 0; i < B.Count - 1; i++)
            {
                if (B[i] % 2 == 0)
                    continue;
                loafs += 2;
                B[i]++;
                if (i == B.Count - 1)
                    return B[i] % 2 == 0 ? loafs.ToString() : "NO";
                B[i + 1]++;
            }
            return B[i] % 2 == 0 ? loafs.ToString() : "NO";
        }

        public static long taumBday(int b, int w, int bc, int wc, int z)
        {
            long blackPrice = bc <= wc + z ? bc : wc + z;
            long whitePrice = wc <= bc + z ? wc : bc + z;
            long res = (blackPrice * b) + (whitePrice * w);
            return res;
        }

        static int jumpingOnClouds(int[] c, int k)
        {
            var e = 100;
            var nextIndex = 0;
            while (e >= 0)
            {
                nextIndex = (nextIndex + k) % c.Length;
                e -= c[nextIndex] == 0 ? 1 : 3;
                if (nextIndex == 0)
                    return e;
            }

            throw new Exception("Run out of energy!");
        }

        static int minimumDistances(int[] a)
        {
            var minDist = int.MinValue;
            var dict = new Dictionary<int, bool>();
            for (int i = 0; i < a.Length; i++)
            {
                if (dict.ContainsKey(a[i]))
                    continue;

                dict.Add(a[i], true);
                var nexttIndex = i;
                while (nexttIndex != 1)
                {
                    var prevIndex = nexttIndex;
                    nexttIndex = Array.IndexOf(a.ToList().GetRange(nexttIndex + 1, a.Length - nexttIndex - 1).ToArray(), a[i]);
                    if (nexttIndex != -1)
                        minDist = Math.Min(minDist, nexttIndex - prevIndex);
                }
            }
            return minDist;
        }

        static int equalizeArray(int[] arr)
        {
            arr = arr.OrderBy(a => a).ToArray();
            var i = 0;
            var mostRepeateadTimes = int.MinValue;
            while (i < arr.Length)
            {
                var nextIndex = Array.LastIndexOf(arr, arr[i]);
                if (nextIndex > -1)
                    mostRepeateadTimes = Math.Max(mostRepeateadTimes, nextIndex - i + 1);

                i++;
            }
            return arr.Length - mostRepeateadTimes;
        }

        static string appendAndDelete(string s, string t, int k)
        {
            //Console.WriteLine(appendAndDelete("qwerasdf", "qwerbsdf", 6));
            if (k / s.Length >= 2)
                return "Yes";

            var i = 0;
            while (i < s.Length && i < t.Length && s[i] == t[i])
                i++;
            i--;
            if (i == -1)
                return k >= s.Length + t.Length ? "Yes" : "No";

            var dif = t.Length > s.Length ? t.Length - i - 1 : s.Length - i - 1;
            return k >= dif && dif % 2 == k % 2 ? "Yes" : "No";
        }

        static int findDigits(int n)
        {
            var result = 0;
            foreach (var s in n.ToString().Select(s => s.ToString()))
                if (s != "0" && n % Convert.ToInt32(s) == 0)
                    result++;
            return result;
        }

        static int viralAdvertising(int n)
        {
            var day = 0;
            var shared = 5;
            var cumLiked = 0;
            while (day < n)
            {
                day++;
                var liked = shared / 2;
                cumLiked += liked;
                shared = liked * 3;
            }

            return cumLiked;
        }
    }

}
