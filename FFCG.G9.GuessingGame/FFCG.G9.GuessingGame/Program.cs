using System;

namespace FFCG.G9.GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Oh yes, it's Guesss!");

            while (true)
            {
                var game = new Game(new Dice(1000));
                while (!game.GameOver)
                {
                    Console.Write($"\nCurrent number is: {game.CurrentNumber} - Guess higher or lower ^/v: ");
                    var key = Console.ReadKey();

                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        Console.Write("^");
                        game.GuessHigher();
                    }else if (key.Key == ConsoleKey.DownArrow)
                    {
                        Console.Write("v");
                        game.GuessLower();
                    }
                    else
                    {
                        Console.WriteLine("Wrong input, press up or down on the keyboard to guess!\n\n");
                    }
                
                    Console.Write($"\nRoll was: {game.CurrentNumber}");
                    if (!game.GameOver)
                    {
                        Console.WriteLine($" - CORRECT - Points: {game.Points}");
                    }
                }
            
            
                Console.WriteLine("\nOH NOES, IT'S GAME OVER!");
                Console.WriteLine($"Your score: {game.Points}");

                Console.ReadLine();
            }
        }
    }

}