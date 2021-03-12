using System;

namespace FFCG.G9.GuessingGame
{
    public class Game
    {
        private readonly IDice _dice;
        public bool GameOver { get; private set; }
        public int Points { get; private set; }
        public int CurrentNumber { get; private set; }

        private int _numberOfCorrectGuesses = 0;
        
        public Game(IDice dice)
        {
            _dice = dice;
            CurrentNumber = _dice.Roll();
        }

        public void GuessHigher()
        {
            Guess(lastRoll => CurrentNumber > lastRoll);
        }

        public void GuessLower()
        {
            Guess(lastRoll => CurrentNumber < lastRoll);
        }

        private void Guess(Func<int, bool> func)
        {
            var lastRoll = CurrentNumber;

            CurrentNumber = _dice.Roll();

            if (!func(lastRoll))
            {
                GameOver = true;
                return;
            }

            _numberOfCorrectGuesses++;

            if (_numberOfCorrectGuesses % 3 == 0)
                Points += 3;
            else
            {
                Points++;    
            }
            
        }
    }
}