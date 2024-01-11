using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Kata.Main.Algorithms
{
    public static class MelateService
    {
        public static async Task FindOcurrencesOfTickets()
        {
            var melateResultsStrings = await File.ReadAllLinesAsync("C:\\EtoroFiles\\Melate.csv");
            var melateResultsSplitted = melateResultsStrings.Select(s => s.Split(",", StringSplitOptions.TrimEntries));
            var melateResults = melateResultsSplitted.Select(s => new[]
            { Convert.ToInt32(s[2]),Convert.ToInt32(s[3]), Convert.ToInt32(s[4]), Convert.ToInt32(s[5]), Convert.ToInt32(s[6]), Convert.ToInt32(s[7]) });

            var tickets = new int[][]
            {
                [1, 2, 3, 4, 5, 6], [1, 2, 3, 4, 7, 8], [1, 2, 5, 6, 7, 8],
                [9, 10, 11, 12, 13, 14], [9, 10, 11, 15, 16, 17], [12, 13, 14, 15, 16, 17],
                [18, 19, 20, 21, 26, 27], [18, 19, 22, 23, 30, 31], [18, 19, 24, 25, 28, 29], [20, 21, 22, 23, 28, 29], [20, 21, 24, 25, 30, 31], [22, 23, 24, 25, 26, 27], [26, 27, 28, 29, 30, 31],
                [32, 33, 34, 35, 40, 41], [32, 33, 36, 37, 44, 45], [32, 33, 38, 39, 42, 43], [34, 35, 36, 37, 42, 43], [34, 35, 38, 39, 44, 45], [36, 37, 38, 39, 40, 41], [40, 41, 42, 43, 44, 45],
                [46, 47, 48, 49, 54, 55], [46, 47, 50, 51, 55, 56], [46, 47, 52, 53, 54, 55], [48, 49, 50, 51, 52, 53], [48, 49, 52, 53, 55, 56], [49, 50, 51, 52, 53, 54], [51, 52, 53, 54, 55, 56]
            };

            //var ticketStrings = tickets.Select(JoinWithDash).ToImmutableArray();
            var melateResultsCount = melateResults.Count();
            var results = new MelateResultsModel { MelateIntersectedResults = new List<MelateIntersectedResultModel>() };
            for (int i = 0; i < melateResultsCount; i++)
            {
                var melateResult = melateResults.ElementAt(i);
                Console.Write($"{JoinWithDash(melateResult)} - ");
                var intersections = new int[7];
                for (var j = 0; j < tickets.Length; j++)
                {
                    var intersectedCount = tickets[j].Intersect(melateResult).Count();
                    intersections[intersectedCount]++;
                    //var result = new MelateIntersectedResultModel { TicketValidated = ticketString, ResultCompared = JoinWithDash(melateResults.ElementAt(i)), IntersectedCount = intersectedCount };
                    //results.MelateIntersectedResults.Add(result);
                    //results.IntersectionNCount[intersectedCount]++;
                }
                Console.Write($"I0:{intersections[0]} - I1:{intersections[1]} - I2:{intersections[2]} - I3:{intersections[3]}" +
                    $" - I4:{intersections[4]} - I5:{intersections[5]} - I6:{intersections[6]} \n");
            }
            await File.WriteAllTextAsync("C:\\EtoroFiles\\MelateIntersections.json", JsonSerializer.Serialize(results));
        }

        public static async Task FindTuplesIntersections()
        {
            var melateResultsStrings = await File.ReadAllLinesAsync("C:\\EtoroFiles\\Melate.csv");
            var melateResultsSplitted = melateResultsStrings.Select(s => s.Split(",", StringSplitOptions.TrimEntries));
            var melateResults = melateResultsSplitted.Select(s => new[]
            { Convert.ToInt32(s[2]),Convert.ToInt32(s[3]), Convert.ToInt32(s[4]), Convert.ToInt32(s[5]), Convert.ToInt32(s[6]), Convert.ToInt32(s[7]) });

            var tickets = new[] { 34, 35, 36, 37, 42, 43 };
            string ticketString = JoinWithDash(tickets);
            var melateResultsCount = melateResults.Count();
            var results = new MelateResultsModel { MelateIntersectedResults = new List<MelateIntersectedResultModel>() };
            for (int i = 0; i < melateResultsCount; i++)
            {
                Console.WriteLine($"{i + 1}/{melateResultsCount}");
                var intersectedCount = tickets.Intersect(melateResults.ElementAt(i)).Count();
                var result = new MelateIntersectedResultModel { TicketValidated = ticketString, ResultCompared = JoinWithDash(melateResults.ElementAt(i)), IntersectedCount = intersectedCount };
                results.MelateIntersectedResults.Add(result);
                results.IntersectionNCount[intersectedCount]++;
            }
            await File.WriteAllTextAsync("C:\\EtoroFiles\\MelateIntersections.json", JsonSerializer.Serialize(results));
        }

        private static string JoinWithDash(int[] tickets) => string.Join("-", tickets);

        static List<int[]> GenerateUniqueCombinations()
        {
            List<int[]> combinations = new List<int[]>();
            HashSet<string> uniqueHashes = new HashSet<string>();

            for (int i = 1; i <= 51; i++)
            {
                for (int j = i + 1; j <= 52; j++)
                {
                    for (int k = j + 1; k <= 53; k++)
                    {
                        for (int l = k + 1; l <= 54; l++)
                        {
                            for (int m = l + 1; m <= 55; m++)
                            {
                                for (int n = m + 1; n <= 56; n++)
                                {
                                    int[] combination = { i, j, k, l, m, n };
                                    Array.Sort(combination); // Sort the array for uniqueness

                                    string hash = string.Join(",", combination);

                                    // Check for uniqueness using HashSet
                                    if (!uniqueHashes.Contains(hash))
                                    {
                                        uniqueHashes.Add(hash);
                                        combinations.Add(combination);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return combinations;
        }

        internal class MelateResultsModel
        {
            public string TicketValidated { get; set; }
            public List<MelateIntersectedResultModel> MelateIntersectedResults { get; set; }
            public Dictionary<int, int> IntersectionNCount { get; set; } = new Dictionary<int, int> { { 0, 0 }, { 1, 0 }, { 2, 0 }, { 3, 0 }, { 4, 0 }, { 5, 0 }, { 6, 0 } };
        }

        internal class MelateIntersectedResultModel
        {
            public string TicketValidated { get; set; }
            public string ResultCompared { get; set; }
            public int IntersectedCount { get; internal set; }
        }
    }
}