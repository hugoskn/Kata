using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

public class BettingCalculator
{
    public static object team1odds { get; private set; }

    public static decimal CalculateEarnings(decimal betAmount, decimal odds)
    {
        if (odds > 0)
            return ((odds / 100) + 1) * betAmount;
        else
            return ((100 / Math.Abs(odds)) + (decimal)1) * betAmount;
    }

    public static int CalcualteOptimalBetAmounts()
    {
        Console.WriteLine("Team 1:");
        var team1Odds = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Odds:");
        var team2Odds = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(CalculateEarnings(100, team1Odds));
        Console.WriteLine(CalculateEarnings(100, team2Odds));
        var results = new List<string>();
        var resultsObj = new List<BetOddsModel>();
        results.Add("Team1Odds, Team1Bet, Team1Earnings, TotalWin1, Team2Odds, Team2Bet, Team2Earnings, TotalWin2, WinLoseRatio");
        for (int i = 100; i <= 1000; i+=5)
        {
            var earnings1 = CalculateEarnings(i, team1Odds);

            for (int j = 100; j <= 1000; j+= 5)
            {
                var earnings2 = CalculateEarnings(j, team2Odds);
                var totalWin1 = earnings1 - i - j;
                var totalWin2 = earnings2 - i - j;
                if (totalWin1 <= 0 && totalWin2 <= 0)
                    continue;
                if (totalWin1 >= 0 && totalWin2 >= 0)
                    Console.WriteLine("Found winner: " + i + " . bet team2: " + j);
                var winLoseRatio = totalWin1 >=  0 && totalWin2 >= 0 ? 1000 : Math.Abs((totalWin1 > totalWin2 ? totalWin1 / totalWin2 : totalWin2 / totalWin1));
                //var totalEarnsLoses = totalWin1 + totalWin2;
                results.Add($"{team1Odds}, {i}, {(int)earnings1}, {(int)totalWin1}, {team2Odds}, {j}, {(int)earnings2}, {(int)totalWin2}, {winLoseRatio}");
                resultsObj.Add(new BetOddsModel { Team1odds = team1odds, Earnings1 = earnings1, TotalWin1 = totalWin1,
                    Team2Odds = team2Odds, Earnings2 = earnings2, TotalWin2 =totalWin2, WinLoseRatio = winLoseRatio });
            }
        }

        //resultsObj.Where(r => r.)
        File.WriteAllLines(@"C:\Users\hugos\Downloads\BetOddsResults.csv", results);
        return 10;
    }

    public static void CalculateBetAmountToAvoidLoses()
    {
        // Get the American odds of Team 1 and Team 2
        Console.Write("Enter the American odds of Team 1: ");
        double team1Odds = double.Parse(Console.ReadLine());

        Console.Write("Enter the American odds of Team 2: ");
        double team2Odds = double.Parse(Console.ReadLine());

        // Convert American odds to decimal odds
        double team1DecimalOdds = GetDecimalOdds(team1Odds);
        double team2DecimalOdds = GetDecimalOdds(team2Odds);

        // Calculate the implied probability of each team winning
        double team1Probability = 1 / team1DecimalOdds;
        double team2Probability = 1 / team2DecimalOdds;

        // Calculate the bet amounts on each team to avoid losses
        double totalMoneyToBet = 1000; // Set the total amount of money to bet

        double team1BetAmount = totalMoneyToBet / (1 + (team1DecimalOdds / team2DecimalOdds));
        double team2BetAmount = totalMoneyToBet - team1BetAmount;

        // Output the bet amounts on each team to avoid losses
        Console.WriteLine("Bet ${0} on Team 1", team1BetAmount.ToString("0.00"));
        Console.WriteLine("Bet ${0} on Team 2", team2BetAmount.ToString("0.00"));
    }



    public static void CalculateAmountToBetToMaximize()
    {
        // Get the American odds of Team 1 and Team 2
        Console.Write("Enter the American odds of Team 1: ");
        double team1Odds = double.Parse(Console.ReadLine());

        Console.Write("Enter the American odds of Team 2: ");
        double team2Odds = double.Parse(Console.ReadLine());

        // Convert American odds to decimal odds
        double team1DecimalOdds = GetDecimalOdds(team1Odds);
        double team2DecimalOdds = GetDecimalOdds(team2Odds);

        // Calculate the implied probability of each team winning
        double team1Probability = 1 / team1DecimalOdds;
        double team2Probability = 1 / team2DecimalOdds;

        // Calculate the optimal bet amounts on each team
        double totalMoneyToBet = 1000; // Set the total amount of money to bet

        double team1BetAmount = (team2Probability * totalMoneyToBet) / (team1Probability + team2Probability);
        double team2BetAmount = (team1Probability * totalMoneyToBet) / (team1Probability + team2Probability);

        // Output the optimal bet amounts on each team
        Console.WriteLine("Bet ${0} on Team 1", team1BetAmount.ToString("0.00"));
        Console.WriteLine("Bet ${0} on Team 2", team2BetAmount.ToString("0.00"));
    }

    // Function to convert American odds to decimal odds
    public static double GetDecimalOdds(double americanOdds)
    {
        if (americanOdds >= 100)
        {
            return (americanOdds / 100) + 1;
        }
        else
        {
            return (100 / americanOdds) + 1;
        }
    }
}

internal class BetOddsModel
{
    public object Team1odds { get; internal set; }
    public decimal Earnings1 { get; internal set; }
    public decimal TotalWin1 { get; internal set; }
    public decimal WinLoseRatio { get; internal set; }
    public decimal TotalWin2 { get; internal set; }
    public int Team2Odds { get; internal set; }
    public decimal Earnings2 { get; internal set; }
}