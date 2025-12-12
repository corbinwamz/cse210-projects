using System;

class Program
{
    static void Main(string[] args)
    {
        Menu();
        static void Menu()
        {
            string input = "3";
            Journal newJournal = new();
            Task newTask = new();
            Habit newHabit = new();
            while (input == "1" || input == "2" || input == "3")
            {
                Console.Clear();
                Console.Write(
                    "Welcome to your Productivity Manager\n\n"+
                    "   1. Journal\n"+
                    "   2. Task Manager\n"+
                    "   3. Habit Tracker\n"+
                    "   4. Quit\n"+
                    "\nWhich menu would you like to open? "
                );
                input = Console.ReadLine();

                if (input == "1")
                {
                    Console.Clear();
                    newJournal.Display();
                }
                else if (input == "2")
                {
                    Console.Clear();
                    newTask.Display();
                }
                else if (input == "3")
                {
                    Console.Clear();
                    newHabit.Display();
                }
            }
        }
    }
}