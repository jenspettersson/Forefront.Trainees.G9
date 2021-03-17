using System;
using System.Linq;
using FFCG.G9.CardAnalyzer.Analyzer;
using FFCG.G9.CardAnalyzer.Rule;

namespace FFCG.G9.CardAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            var deck = Deck.Default();

            var rule = new RoyalStraightFlush();
            var result = new ConsoleAnalyzer().Analyze(deck, rule);

            Console.WriteLine($"\nWe've got a match: {rule.Description}");
            
            foreach (var card in result.MatchingHand.OrderBy(x => x.Number))
            {
                Console.WriteLine($"\t{card}");
            }
            
            Console.WriteLine($"Took {result.Tries:N0} tries - {result.Elapsed}");
        }
    }
}