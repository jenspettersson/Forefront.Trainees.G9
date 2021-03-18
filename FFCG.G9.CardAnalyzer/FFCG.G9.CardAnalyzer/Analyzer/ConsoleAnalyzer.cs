using System;
using System.Collections.Generic;
using System.Diagnostics;
using FFCG.G9.CardAnalyzer.Rule;

namespace FFCG.G9.CardAnalyzer.Analyzer
{
    public class ConsoleAnalyzer
    {
        public AnalyzeResult Analyze(IDeck deck, IRule rule)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int tries = 0;
            var hand = new List<Card>();
            while (true)
            {
                tries++;
                deck.Shuffle();
                
                for (int i = 0; i < 5; i++)
                {
                    hand.Add(deck.Draw());
                }

                if (rule.Matches(hand))
                {
                    return new AnalyzeResult(hand, tries, stopwatch, rule);
                }
                hand.Clear();
            }
        }
        
    }
}