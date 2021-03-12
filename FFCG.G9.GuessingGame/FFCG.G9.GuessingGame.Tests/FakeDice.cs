namespace FFCG.G9.GuessingGame.Tests
{
    public class FakeDice : IDice
    {
        private readonly int[] _rolls;
        private int _rollIndex;

        public FakeDice(params int[] rolls)
        {
            _rolls = rolls;
        }
        
        public int Roll()
        {
            return _rolls[_rollIndex++];
        }
    }
}