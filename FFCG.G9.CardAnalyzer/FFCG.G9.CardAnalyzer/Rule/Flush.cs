using System.Collections.Generic;
using System.Linq;

namespace FFCG.G9.CardAnalyzer.Rule
{
    public class Flush : IRule
    {
        public string Description => "Flush";

        public bool Matches(List<Card> cards)
        {
            return cards.Select(x => x.Suit).Distinct().Count() == 1;
        }
    }
}