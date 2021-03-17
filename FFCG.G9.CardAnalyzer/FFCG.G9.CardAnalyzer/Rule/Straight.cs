using System.Collections.Generic;
using System.Linq;

namespace FFCG.G9.CardAnalyzer.Rule
{
    public class Straight : IRule
    {
        public string Description => "Straight";

        public bool Matches(List<Card> cards)
        {
            var numbers = cards.Select(x => x.Number).OrderBy(x => x).ToArray();
            for (int i = 1; i < cards.Count; i++)
            {
                if (numbers[i - 1] != numbers[i] - 1)
                    return false;
            }
            return true;
        }
    }
}