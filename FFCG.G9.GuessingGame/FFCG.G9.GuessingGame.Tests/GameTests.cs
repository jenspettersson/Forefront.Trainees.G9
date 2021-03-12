using NUnit.Framework;

namespace FFCG.G9.GuessingGame.Tests
{
    public class GameTests
    {
        [Test]
        public void Should_start_with_random_number()
        {
            var game = new Game(new FakeDice(5));
            Assert.AreEqual(5, game.CurrentNumber);
        }

        [Test]
        public void Same_value_as_last_should_always_be_incorrect_guess()
        {
            var game = new Game(new FakeDice(5, 5));
            game.GuessHigher();
            
            Assert.True(game.GameOver);
            
        }

        [Test]
        public void One_correct_high_guess_should_increase_points()
        {
            var game = new Game(new FakeDice(5, 6));
            
            game.GuessHigher();
            Assert.AreEqual(1, game.Points);
        }
        
        [Test]
        public void One_correct_low_guess_should_increase_points()
        {
            var game = new Game(new FakeDice(5, 4));

            game.GuessLower();
            Assert.AreEqual(1, game.Points);
        }

        [Test]
        public void Third_correct_guess_should_give_3_points()
        {
            var game = new Game(new FakeDice(5, 4, 3, 2));
            
            game.GuessLower();
            game.GuessLower();
            game.GuessLower();
            
            Assert.AreEqual(5, game.Points);
        }
        
        [Test]
        public void Every_third_correct_guess_should_give_3_points()
        {
            var game = new Game(new FakeDice(10, 9, 8, 7, 6, 5, 4, 3, 2, 1));
            
            game.GuessLower();
            game.GuessLower();
            game.GuessLower();
            
            game.GuessLower();
            game.GuessLower();
            game.GuessLower();
            
            game.GuessLower();
            game.GuessLower();
            game.GuessLower();
            
            Assert.AreEqual(15, game.Points);
        }

        [Test]
        public void Wrong_guess_should_be_game_over()
        {
            var game = new Game(new FakeDice(5, 1));
            
            game.GuessHigher();
            
            Assert.True(game.GameOver);
        }
    }
}