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
            for (var i = 0; i < cards.Count; i++)
            {
                if (cards[i].Number < 10)
                    return false;
            }
            
            return _straightFlush.Matches(cards);
        }
    }
}