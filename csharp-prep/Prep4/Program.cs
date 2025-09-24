using System;
using System.ComponentModel;
using System.Runtime;

class Program
{
    static void Main(string[] args)
    {
        int number = 1;
        List<int> numbers = new List<int>();
        int sum = 0;
        int amount = 0;
        int max = 0;
        while (number != 0)
        {
            Console.Write("Enter in a number to add to the list. Type 0 when finished: ");
            string input = Console.ReadLine();
            number = int.Parse(input);
            numbers.Add(number);
        }
        foreach (int num in numbers)
        {
            sum = sum + num;
            amount = amount + 1;
            if (num > max)
            {
                max = num;
            }
        }
        int avg = sum / amount;
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The Average is: {avg}");
        Console.WriteLine($"The Highest number is: {max}");
    }
}