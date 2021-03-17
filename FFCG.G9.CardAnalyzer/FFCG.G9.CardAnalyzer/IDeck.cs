namespace FFCG.G9.CardAnalyzer
{
    public interface IDeck
    {
        Card Draw();
        void Shuffle();
    }
}