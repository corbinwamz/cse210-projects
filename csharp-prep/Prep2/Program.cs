using System;

class Program
{
    static void Main(string[] args)
    {
        string letter = "";
        Console.Write("What is your grade? ");
        string input = Console.ReadLine();
        float grade = int.Parse(input);
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else if (grade < 60)
        {
            letter = "F";
        }

        float lastDigit = grade%10;
        string symbol = "";
        if (lastDigit >= 7 && grade >= 97)
        {
            symbol = "";
        }
        else if (grade < 60)
        {
            symbol = "";
        }
        else if (lastDigit < 3)
        {
            symbol = "-";
        }
        else if (lastDigit >= 7)
        {
            symbol = "+";
        }

        Console.WriteLine($"Your letter grade is {letter}{symbol}");

        if (grade >= 70)
        {
            Console.WriteLine("Hurray you passed!! Congrats!");
        }
        else if (grade < 70)
        {
            Console.WriteLine("I'm sorry you failed. Study a little more next time",
            "you got this!");
        }
    }
}