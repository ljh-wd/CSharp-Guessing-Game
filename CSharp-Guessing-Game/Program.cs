using System;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            NumberGenerator myGenerator = new NumberGenerator();  
            bool isOptionSelected = false;  // Flag to indicate if the difficulty option has been selected
            string optionSelected = "";  
            

            while (!isOptionSelected)
            {
                Console.WriteLine("Please select your difficulty:");
                Console.WriteLine("1. Easy: Guesses: 30, 1 - 100");
                Console.WriteLine("2. Medium: Guesses: 25, 1 - 500");
                Console.WriteLine("3. Hard: Guesses: 20, 1 - 1000");
                Console.WriteLine("4. Pro: Guesses: 15, 1 - 5000");

                optionSelected = Console.ReadLine();  // Read the user's difficulty option

                if (optionSelected == "1" || optionSelected == "2" || optionSelected == "3" || optionSelected == "4")
                {
                    isOptionSelected = true;  // Set the flag to true if a valid option is selected
                }
                else
                {
                    Console.WriteLine("Invalid Option: Please select 1, 2, 3, or 4");
                }
            }


            // Set the difficulty level based on the user's selection
            myGenerator.SetDifficulty(optionSelected);

            // Generate number based on the difficulty
            int target = myGenerator.GenerateNumber();



            // Display the range to the user
            int minValue = myGenerator.returnMin();
            int maxValue = myGenerator.returnMax();
            Console.WriteLine($"Guess the number within the range of {minValue} - {maxValue}");

            // Read the user's initial guess
            int guessedValue = int.Parse(Console.ReadLine());
            int guessesRemaining = myGenerator.returnGuesses();

            // Game loop: continue until the user runs out of guesses or guesses the correct number
            while (guessesRemaining > 0)
            {
                if (guessedValue == target)
                {
                    // The user guessed the correct number
                    Console.WriteLine($"Correct: the target was {target}. You won the game with {guessesRemaining} remaining guesses!");
                    Console.WriteLine("Exit: 1");
                    string input = Console.ReadLine();

                    if (input == "1")
                    {
                        // Exit the program if the user chooses to exit
                        Environment.Exit(0);
                    }

                    break;
                }
                else
                {
                    // The user's guess is incorrect
                    guessesRemaining--;

                    // Provide a hint to the user (higher or lower)
                    if (guessedValue < target)
                    {
                        Console.WriteLine("Higher");
                    }
                    else
                    {
                        Console.WriteLine("Lower");
                    }

                    // Read the next guess from the user
                    guessedValue = int.Parse(Console.ReadLine());
                }
            }

            if (guessesRemaining == 0)
            {
                // The user ran out of guesses
                Console.WriteLine("You ran out of guesses!");

                string input = Console.ReadLine();

                if (input == "1")
                {
                    // Exit the program if the user chooses to exit
                    Environment.Exit(0);
                }
            }

            Console.ReadLine();
        }
    }

    class NumberGenerator
    {
        int generatedNumber;
        int guessesRemaining;
        int minValue = 1;
        int maxValue;
        Random random = new Random();
        string difficulty = null;

        public void SetDifficulty(string optionSelected)
        {

            // Switch case to change the settings based on difficulty
            switch (optionSelected)
            {
                case "1":
                    difficulty = "Easy";
                    maxValue = 100;
                    guessesRemaining = 30;
                    break;

                case "2":
                    difficulty = "Medium";
                    maxValue = 500;
                    guessesRemaining = 25;
                    break;

                case "3":
                    difficulty = "Hard";
                    maxValue = 1000;
                    guessesRemaining = 20;
                    break;

                case "4":
                    difficulty = "Pro";
                    maxValue = 5000;
                    guessesRemaining = 15;
                    break;

                default:
                    Console.WriteLine("Invalid Option: Please select 1, 2, 3, or 4");
                    break;
            }
        }

        public int returnGuesses()
        {
            return guessesRemaining;
        }

        public int returnMax()
        {
            return maxValue;
        }

        public int returnMin()
        {
            return minValue;
        }

        public int GenerateNumber()
        {
            // Generate a random number within the specified range
            int randomNumber = random.Next(minValue, maxValue);
            generatedNumber = randomNumber;
            return generatedNumber;
        }
    }
}
