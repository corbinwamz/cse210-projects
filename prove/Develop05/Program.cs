using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

class Program
{
    static void Main(string[] args)
    {
        int totalPoints = 0;
        Menu(totalPoints);
        static void Menu(int totalPoints)
        {
            List<SimpleGoal> simpleGoals = [];
            string input = "";
            while (input != "6")
            {
                Console.Write(
                    $"You have {totalPoints} points.\n\n"+
                    "Menu Options:\n"+
                    "   1. Create New Goal\n"+
                    "   2. List Goals\n"+
                    "   3. Save Goals\n"+
                    "   4. Load Goals\n"+
                    "   5. Record Event\n"+
                    "   6. Quit\n"+
                    "Select a choice from the menu: "
                );
                input = Console.ReadLine();
                if (input == "1")
                {
                    Console.Write(
                        "The types of Goals are:\n"+
                        "   1. Simple Goal\n"+
                        "   2. Eternal Goal\n"+
                        "   3. Checklist Goal\n"+
                        "   4. Negative Goal\n"+
                        "Which type of goal would you like to create? "
                    );
                    input = Console.ReadLine();
                    SimpleGoal goal = new();
                    SimpleGoal goal2 = new Eternal();
                    SimpleGoal goal1 = new Checklist();
                    SimpleGoal goal3 = new NegativeGoal();
                    if (input == "1")
                    { 
                        goal.CreateGoal(simpleGoals);
                    }
                    else if (input == "2")
                    {
                        goal2.CreateGoal(simpleGoals);
                    }
                    else if (input == "3")
                    {
                        goal1.CreateGoal(simpleGoals);
                    }
                    else
                    {
                        goal3.CreateGoal(simpleGoals);
                    }
                }
                else if (input == "2")
                {
                    Display(simpleGoals);
                }
                else if (input == "3")
                {
                    Console.Write("What is the filename for the goal file? ");
                    string file = Console.ReadLine();
                    Console.WriteLine("");
                    Save(file, simpleGoals, totalPoints);
                }
                else if (input == "4")
                {
                    Console.Write("What is the filename for the goal file? ");
                    string file = Console.ReadLine();
                    Console.WriteLine("");
                    simpleGoals = Load(file);
                    totalPoints = LoadTotalPoints(file);
                }
                else if (input == "5")
                {
                    Console.WriteLine("The goals are:");
                    int num = 1;
                    foreach (SimpleGoal goal in simpleGoals)
                    {
                        string name = goal.GetTitle();
                        Console.WriteLine($"{num}. {name}");
                        num += 1;
                    }
                    Console.Write("Which goal did you accomplish? ");
                    string i = Console.ReadLine();
                    int a = int.Parse(i);
                    SimpleGoal goalAccomplished = simpleGoals[a-1];
                    totalPoints = goalAccomplished.Complete(totalPoints);
                    simpleGoals[a-1] = goalAccomplished;
                }
            }
        }

        static void Save(string file, List<SimpleGoal> goals, int totalPoints)
        { 
            using (StreamWriter outputFile = new StreamWriter(file))
            { 
                outputFile.WriteLine($"{totalPoints}");
                foreach (SimpleGoal goal in goals)
                {      
                    bool complete = goal.Getcomplete();
                    string name = goal.GetTitle();
                    string desc = goal.GetDesc();
                    int points = goal.Getpoints();
                    string goalType = goal.GetGoalType();
                    if (goalType == "simple_goal" || goalType == "eternal") 
                    {                        
                        outputFile.WriteLine($"{complete},{name},{desc},{points},{goalType}");
                    }
                    else if (goalType == "checklist")
                    {
                        int timesCompleted = goal.GetTimesC();
                        int timesRequired = goal.GetTimesR();
                        int bonus = goal.GetBonus();
                        outputFile.WriteLine($"{complete},{name},{desc},{points},{goalType},{timesCompleted},{timesRequired},{bonus}");
                    }
                    else
                    {
                        int timesAllowed = goal.GetTimesAllowed();
                        int timesDone = goal.GetTimesDone();
                        outputFile.WriteLine($"{complete},{name},{desc},{points},{goalType},{timesAllowed},{timesDone}");
                    }
                }
            }
        }

        static int LoadTotalPoints(string file)
        {
            string[] linesArray = System.IO.File.ReadAllLines(file);
            string l = linesArray[0];
            int totalPoints = int.Parse(l);
            return totalPoints;
        }

        static List<SimpleGoal> Load(string file)
        {
            List<SimpleGoal> goals = [];
            string[] linesArray = System.IO.File.ReadAllLines(file);
            List<string> lines = linesArray.ToList();
            lines.RemoveAt(0);
            foreach (string line in lines)
            {
                string[] items = line.Split(",");
                string c = items[0];
                bool complete = bool.Parse(c);
                string name = items[1];
                string desc = items[2];
                string n = items[3];
                int points = int.Parse(n);
                string goalType = items[4];
                if (goalType == "simple_goal")
                {
                    SimpleGoal goal = new(name, desc, points, complete, goalType);
                    goals.Add(goal);
                }
                else if (goalType == "eternal")
                {
                    SimpleGoal goal = new Eternal(name, desc, points, complete, goalType);
                    goals.Add(goal);
                }
                else if (goalType == "checklist")
                {
                    string t = items[5];
                    int timesCompleted = int.Parse(t);
                    string r = items[6];
                    int timesReq = int.Parse(r);
                    string b = items[7];
                    int bonus = int.Parse(b);
                    SimpleGoal goal = new Checklist(timesCompleted, timesReq, bonus, name, desc, points, complete, goalType);
                    goals.Add(goal);
                }
                else
                {
                    string q = items[5];
                    int timesAllowed = int.Parse(q);
                    string p = items[6];
                    int timesDone = int.Parse(p);
                    SimpleGoal goal = new NegativeGoal(timesAllowed, timesDone, name, desc, points, complete, goalType);
                    goals.Add(goal);
                }
            }
            return goals;
        }

        static void Display(List<SimpleGoal> goals)
        {
            Console.WriteLine("The goals are:");
            int number = 1;
            foreach (SimpleGoal goal in goals)
            {
                goal.Display(number);
                number += 1;
            }
            Console.WriteLine("");
        }
    }
}