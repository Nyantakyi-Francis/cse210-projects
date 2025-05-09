using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "yes";
        Random randomGenerator = new Random();

        while (playAgain.ToLower() == "yes")
        {
            int magicNumber = randomGenerator.Next(1, 101); // Random number from 1 to 100
            int guess = -1;
            int attempts = 0;

            Console.WriteLine("I have chosen a number between 1 and 100. Try to guess it!");

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                attempts++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"It took you {attempts} guesses.");
                }
            }

            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine();
        }

        Console.WriteLine("Thanks for playing!");
    }
}