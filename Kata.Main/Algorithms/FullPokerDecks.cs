using System;
using System.Linq;

namespace Kata.Main.Algorithms
{
    public static class FullPokerDecks
    {
        public static int CountDecks()
        {
            var decks = new int[14];
            decks[0] = int.MaxValue;
            var cards = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13,
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13,
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13,
                1, 3, 4, 6, 7, 9, 10, 12, 13,1,3,4,6,7};

            var decksFormed = int.MaxValue;
            for (int c = 0; c < cards.Length; c++)
            {
                decks[cards[c]] = decks[cards[c]] + 1;
                decksFormed = decks[cards[c]] < decksFormed ? decks[cards[c]] : decksFormed;
            }

            Console.WriteLine("decks formed: " + decksFormed);
            Console.WriteLine("decks formed Min: " + decks.Min());
            return decks.Min();
        }
    }
}
