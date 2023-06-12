using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Kata.Main.Algorithms
{
    public class TextFilesParser
    {
        public static async Task TransformToTextMarketplacesJsonVaris()
        {
            var jsonMks = await File.ReadAllTextAsync(@"C:\Users\hugos\Downloads\config.marketplaces.json");
            var mks = JsonSerializer.Deserialize<MarketplacesNameIdModel>(jsonMks);
            var result = mks.marketplaces.Select(m => $"WHERE `X-MARKETPLACE-ID` = '{m.marketplace_id}' as '{m.marketplace_name}', ");
            await File.WriteAllTextAsync(@"C:\Users\hugos\Downloads\config.marketplacesResult.txt", string.Join(string.Empty, result));
            Console.WriteLine(string.Join(string.Empty, result));
        }

        public static void DisticntsOrders()
        {
            var fileName = "PO split orders.txt";
            var filePath = @"C:\Users\hugos\Downloads\";
            Console.WriteLine("Reading file in: " + filePath + fileName);
            var fileTextLines = File.ReadAllLines(filePath + fileName);
            var result = fileTextLines.Select(f => f.Split("|", StringSplitOptions.RemoveEmptyEntries)[1].Trim() + ", " + f.Split("|", StringSplitOptions.RemoveEmptyEntries)[2].Trim());
            var dist = result.Distinct().ToList();
            File.WriteAllLines(filePath + "PO split orders result.txt", dist);
        }

        public static void JiraExtractor()
        {
            Console.WriteLine("Type Jira prefix (i.e. VCORE-, VSOP-):");
            var jiraPrefixesCsv = Console.ReadLine();
            var jiraPrefixes = new List<string> { "VCORE-", "VSOP-" };
            if (!string.IsNullOrWhiteSpace(jiraPrefixesCsv))
            {
                var splittedPrefixes = jiraPrefixesCsv.Split(',');
                foreach (var prefix in splittedPrefixes)
                {
                    if (!jiraPrefixes.Contains(prefix, StringComparer.InvariantCultureIgnoreCase))
                        jiraPrefixes.Add(prefix.ToUpper());
                }
            }

            var fileName = "Jira numbers github.txt";
            var filePath = @"C:\Users\hugos\Desktop\Varis Scripts\" + fileName;
            Console.WriteLine("Reading file in: " + filePath);
            var fileTextLines = File.ReadAllLines(filePath);
            if (fileTextLines?.Length <= 0)
            {
                Console.WriteLine("No data found");
                return;
            }
            Console.WriteLine("Read file successfully");
            Console.WriteLine("EXtracting values from rows containing " + jiraPrefixes.Aggregate((x, y) => x + ", " + y) + " ...");

            var result = new List<string>();
            for (int i = 0; i < fileTextLines.Length; i++)
            {
                foreach (var jiraPrefix in jiraPrefixes)
                {
                    if (fileTextLines[i].Contains(jiraPrefix, StringComparison.InvariantCultureIgnoreCase))
                    {
                        var indexOfPrefix = fileTextLines[i].IndexOf(jiraPrefix, StringComparison.InvariantCultureIgnoreCase);
                        var lastIndexOfNumber = jiraPrefix.Length;
                        while (lastIndexOfNumber < fileTextLines[i].Length && char.IsDigit(fileTextLines[i][lastIndexOfNumber]))
                            lastIndexOfNumber++;

                        var jiraNumber = fileTextLines[i].Substring(indexOfPrefix, lastIndexOfNumber);
                        result.Add(jiraNumber);
                        break;
                    }
                }
            }

            Console.WriteLine("Finish extracting values! \n");
            var distinctOrderedResults = result.Distinct().OrderBy(s => s);
            foreach (var distinctJiraResult in distinctOrderedResults)
                Console.WriteLine(distinctJiraResult);

            File.WriteAllLines(filePath.Replace(fileName, "Jira numbers github Result.txt"), distinctOrderedResults);
        }
    }

    internal class MarketplacesNameIdModel
    {
        public IEnumerable<MarketplaceNameIdModel> marketplaces { get; set; }
    }

    internal class MarketplaceNameIdModel
    {
        public string marketplace_id { get; set; }
        public string marketplace_name { get; set; }
    }
}
