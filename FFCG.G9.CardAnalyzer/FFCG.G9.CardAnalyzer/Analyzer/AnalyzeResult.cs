using System;
using System.Collections.Generic;
using System.Diagnostics;
using FFCG.G9.CardAnalyzer.Rule;

namespace FFCG.G9.CardAnalyzer.Analyzer
{
    public class AnalyzeResult
    {
        public IEnumerable<Card> MatchingHand { get; }
        public int Tries { get; }
        public IRule Rule { get; }
        public TimeSpan Elapsed { get; }

        public double Average { get; }

        public AnalyzeResult(List<Card> matchingHand, int tries, Stopwatch stopwatch, IRule rule)
        {
            MatchingHand = matchingHand;
            Tries = tries;
            Rule = rule;
            Elapsed = stopwatch.Elapsed;
            Average = tries / Elapsed.TotalSeconds;
        }
    }
}