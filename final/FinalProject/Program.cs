using System;

class Program
{
    static void Main(string[] args)
    {
        Menu();
        static void Menu()
        {
            Console.Write(
                "Welcome to your Productivity Manager\n\n"+
                "   1. Journal\n"+
                "   2. Task Manager\n"+
                "   3. Habit Tracker\n"+
                "Which menu would you like to open? "
            );
            string input = Console.ReadLine();

            while (input == "1" || input == "2" || input == "3")
            {
                if (input == "1")
                {
        
                }
                else if (input == "2")
                {
                    
                }
                else if (input == "3")
                {
                    
                }
                else
                {
                    Console.Write("Please type 1, 2, or 3");
                }
            }
        }
    }
}