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
            { Convert.ToInt32(s[2]),Convert.ToInt32(s[3]), Convert.ToInt32(s[4]), Convert.ToInt32(s[5]), Convert.ToInt32(s[6]), Convert.ToInt32(s[7]) }).ToImmutableArray();

            Console.WriteLine("Reading/generating combinations...");
            var combs = await File.ReadAllLinesAsync("C:\\EtoroFiles\\Melate1To56Combinations.txt");
            var tickets = combs.Select(c => c.Split("-").Select(s => Convert.ToInt32(s)).ToArray()).ToImmutableArray();
            Console.WriteLine("Done reading/generating combinations: " + tickets.Length);
            //var tickets = GenerateUniqueCombinations().ToImmutableArray();
            //await File.WriteAllLinesAsync("C:\\EtoroFiles\\Melate1To56Combinations.txt", tickets.Select(JoinWithDash));
            var melateResultsCount = melateResults.Length;
            var results = new List<string> { $"TicketTrial, R0, R1, R2, R3, R4, R5, R6" };
            for (int i = 19020196; i < tickets.Length; i++)
            {
                //Console.Write($"{JoinWithDash(tickets[i])} - ");
                var intersections = new int[7];
                for (var j = 0; j < melateResults.Length; j++)
                {
                    var intersectedCount = tickets[i].Intersect(melateResults[j]).Count();
                    intersections[intersectedCount]++;
                    //var result = new MelateIntersectedResultModel { TicketValidated = ticketString, ResultCompared = JoinWithDash(melateResults.ElementAt(i)), IntersectedCount = intersectedCount };
                    //results.MelateIntersectedResults.Add(result);
                    //results.IntersectionNCount[intersectedCount]++;
                }
                results.Add($"{JoinWithDash(tickets[i])}, {intersections[0]}, {intersections[1]}, {intersections[2]}, {intersections[3]}, {intersections[4]}, {intersections[5]}, {intersections[6]}");

                if (i % 1000000 == 0)
                {
                    Console.WriteLine("1M Records= " + i / 1000000);
                    await File.WriteAllLinesAsync("C:\\EtoroFiles\\MelateIntersectionsWithAllCombinations-part1.xlsx", results);
                }
                //Console.Write($"I0:{intersections[0]} - I1:{intersections[1]} - I2:{intersections[2]} - I3:{intersections[3]}" +
                //  $" - I4:{intersections[4]} - I5:{intersections[5]} - I6:{intersections[6]} \n");
            }
            await File.WriteAllLinesAsync("C:\\EtoroFiles\\MelateIntersectionsWithAllCombinations.csv", results);
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