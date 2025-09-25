using System;
using System.Configuration.Assemblies;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the program!");
        }
        static string PromptUserName()
        {
            Console.Write("What is your name? ");
            string UserName = Console.ReadLine();
            return UserName;
        }
        static int PromptUserNumber()
        {
            Console.Write("What is your favorite number: ");
            string input = Console.ReadLine();
            int favoriteNumber = int.Parse(input);
            return favoriteNumber;

        }
        static void PromptUserBirthyear(out int birthYear)
        {
            Console.Write("What is your birthyear? ");
            string input = Console.ReadLine();
            birthYear = int.Parse(input);
        }
        static int SquareNumber(int favoriteNumber)
        {
            int squareNumber = favoriteNumber * favoriteNumber;
            return squareNumber;
        }
        static void DisplayResult(string UserName, int birthYear, int favoriteNumber, double squareNumber)
        {
            int age = 2025 - birthYear;
            Console.WriteLine($"{UserName}, the square of your number is {squareNumber}");
            Console.Write($"{UserName}, you will turn {age} this year.");
        }
        DisplayWelcome();
        int birthYear;
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        PromptUserBirthyear(out birthYear);
        int squareNumber = SquareNumber(userNumber);
        DisplayResult(userName, birthYear, userNumber, squareNumber);

    }
}