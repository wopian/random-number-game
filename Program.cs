using System;
using System.Collections.Generic;

namespace randomNumberGame
{
    // Create a class to store results in a list
    public class Score
    {
        // Only need to quickly set & get these attributes,
        // so can just use the shorthand syntax.
        public int Count { get; set; }

        public int Attempt { get; set; }
    }

    internal class Program
    {
        private static Random rand = new Random();
        private static int numberGuess;
        private static int playCount;
        private static int playAttempt = 0;
        private static List<Score> playScore = new List<Score>();

        private static void Main()
        {
            Setup(30, 4);
            Game();
        }

        // Set the console window dimensions and buffer size
        private static void Setup(int width, int height)
        {
            Console.SetWindowSize(width, height);
            Console.BufferWidth = width;
            Console.BufferHeight = height;
        }

        // Ask user if they want to play again
        // Returns true if 'Yes'
        // Else it returns false
        private static bool PlayAgain()
        {
            Console.SetCursorPosition(0, 3);
            Console.Write("Play again? [y] ");
            // Convert input to lower case and get the first character
            char input = Console.ReadLine().ToLower()[0];
            if (input == 'y')
            {
                return true;
            }
            return false;
        }

        // Shows Plays & Attempts counter at top of console
        private static void ShowStats()
        {
            // Clear the top 2 lines before writing
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("                              ");
            Console.SetCursorPosition(0, 1);
            Console.WriteLine("                              ");
            Console.SetCursorPosition(0, 0);

            Console.Write("Plays: {0}", playCount);

            // Writes Attempts on right side
            Console.SetCursorPosition(Console.WindowWidth - 10 - Convert.ToString(playAttempt).Length, 0);
            Console.Write("Attempts: {0}", playAttempt);
        }

        private static void ShowResults()
        {
            // Clear screen and hide cursor
            Console.Clear();
            Console.CursorVisible = false;

            // Center align text
            Console.SetCursorPosition((Console.WindowWidth / 2) - (12 / 2), 0);
            Console.Write("Your Results");

            // Resize the window to fit scores
            Setup(30, (playScore.Count + 4));

            foreach (var data in playScore)
            {
                // Center align the results
                Console.SetCursorPosition(((Console.WindowWidth / 2) - ((11 + Convert.ToString(data.Count).Length + Convert.ToString(data.Attempt).Length) / 2)), (data.Count + 1));
                Console.Write("#{0}-{1} attempts", data.Count, data.Attempt);
            }

            // Center align exit message
            Console.SetCursorPosition((Console.WindowWidth / 2) - (21 / 2), playScore.Count + 3);
            Console.Write("Press any key to quit");
            Console.ReadKey();
        }

        private static void Game()
        {
            do
            {
                // Create a random number from 1-100
                int numberRandom = rand.Next(1, 100);

                // Increment play count
                playCount++;

                // Reset attempts back to 0
                playAttempt = 0;
                do
                {
                    ShowStats();

                    // Ask user for a number
                    Console.SetCursorPosition(0, 3);
                    Console.Write("Enter a number: ");
                    numberGuess = Int16.Parse(Console.ReadLine());
                    Console.SetCursorPosition(0, 2);
                    Console.WriteLine("                              ");

                    // Tell the user if their guess is too high or low
                    if (numberGuess > numberRandom)
                    {
                        Console.SetCursorPosition(0, 2);
                        Console.Write("{0} is too high", numberGuess);
                    }
                    else if (numberGuess < numberRandom)
                    {
                        Console.SetCursorPosition(0, 2);
                        Console.Write("{0} is too low", numberGuess);
                    }

                    // Increment attempt counter
                    playAttempt++;
                } while (numberGuess != numberRandom);

                // Create score for the round
                Score playRound = new Score()
                {
                    Count = playCount,
                    Attempt = playAttempt
                };

                // Add score to the Score list
                playScore.Add(playRound);

                // Update the stats info
                ShowStats();

                // Tell user they guessed correctly
                Console.SetCursorPosition(0, 2);
                Console.Write("Congratulations! It was {0}", numberRandom);
            } while (PlayAgain()); // Loop until returns false

            // Show user all their scores
            ShowResults();
        }
    }
}
