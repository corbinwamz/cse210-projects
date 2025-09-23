using System;

class Program
{
    static void Main(string[] args)
    {
        string play = "yes";
        while (play == "yes")
        {
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 100);
            Console.Write("What is your guess? ");
            string input = Console.ReadLine();
            int guess = int.Parse(input);
            int guessNumber = 1;
            while (guess != magicNumber)
            {

                if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                Console.Write("What is your guess? ");
                input = Console.ReadLine();
                guess = int.Parse(input);
                guessNumber = guessNumber + 1;
            }
            Console.WriteLine("You guessed it!");
            Console.Write($"You took {guessNumber} tries! Would you want to play again? ");
            play = Console.ReadLine();
        }
    }
}