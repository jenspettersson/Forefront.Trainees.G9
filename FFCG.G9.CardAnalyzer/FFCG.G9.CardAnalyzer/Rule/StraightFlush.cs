using System.Collections.Generic;

namespace FFCG.G9.CardAnalyzer.Rule
{
    public class StraightFlush : IRule
    {
        private readonly Straight _straight;
        private readonly Flush _flush;
        public string Description => "Straight flush";

        public StraightFlush()
        {
            _straight = new Straight();
            _flush = new Flush();
        }
        public bool Matches(List<Card> cards)
        {
            return _straight.Matches(cards) && _flush.Matches(cards);
        }
    }
}