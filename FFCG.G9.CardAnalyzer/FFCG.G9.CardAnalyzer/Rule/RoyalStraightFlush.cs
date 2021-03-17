using System.Collections.Generic;
using System.Linq;

namespace FFCG.G9.CardAnalyzer.Rule
{
    public class RoyalStraightFlush : IRule
    {
        private readonly StraightFlush _straightFlush;
        public string Description => "Royal Straight Flush";

        public RoyalStraightFlush()
        {
            _straightFlush = new StraightFlush();
        }
        
        public bool Matches(List<Card> cards)
        {
            var min = cards.Min(x => x.Number);
            if (min != 10)
                return false;
            
            var max = cards.Max(x => x.Number);
            if (max != 14)
                return false;

            return _straightFlush.Matches(cards);
        }
    }
}