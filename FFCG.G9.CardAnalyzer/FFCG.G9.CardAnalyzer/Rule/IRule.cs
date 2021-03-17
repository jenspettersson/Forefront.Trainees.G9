using System.Collections.Generic;

namespace FFCG.G9.CardAnalyzer.Rule
{
    public interface IRule
    {
        string Description { get; }
        bool Matches(List<Card> cards);
    }
}