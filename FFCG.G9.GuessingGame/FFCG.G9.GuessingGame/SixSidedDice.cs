using System;

namespace FFCG.G9.GuessingGame
{
    public class SixSidedDice : IDice
    {
        public int Roll()
        {
            return new Random().Next(1, 6);
        }
    }
    
    public class Dice : IDice
    {
        private readonly int _sides;

        public Dice(int sides)
        {
            _sides = sides;
        }
        public int Roll()
        {
            return new Random().Next(1, _sides);
        }
    }
}