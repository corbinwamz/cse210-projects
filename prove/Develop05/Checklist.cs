using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

class Checklist : SimpleGoal
{
    private int _timesCompleted;
    private int _timesReq;
    private int _bonus;

    public Checklist() : base()
    {
        _timesCompleted = 0;
        _timesReq = 0;
        _bonus = 0;
    }
    public Checklist(int timesCompleted, int timesReq, int bonus, string title, string desc, int points, bool complete, string goalType) : base(title, desc, points, complete, goalType)
    {
        _timesCompleted = timesCompleted;
        _timesReq = timesReq;
        _bonus = bonus;
    }
    public Checklist(int timesReq, int bonus, string title, string desc, int points, string goalType) : base(title, desc, points, goalType)
    {
        _timesCompleted = 0;
        _timesReq = timesReq;
        _bonus = bonus;
    }

    public void SetTimesC(int timesC)
    {
        _timesCompleted = timesC;
    }

    public override int GetTimesC()
    {
        return _timesCompleted;
    }

    public override int GetTimesR()
    {
        return _timesReq;
    }
    public override int GetBonus()
    {
        return _bonus;
    }

    public override int Complete(int totalPoints)
    {
        int timesC = this.GetTimesC();
        int timesR = this.GetTimesR();
        int points = this.Getpoints();
        timesC += 1;
        SetTimesC(timesC);
        if (timesC == timesR)
        {           
            this.SetComplete();
            int bonus = this.GetBonus();
            points += bonus;
        }
        totalPoints += points;
        Console.WriteLine($"Congratulations! You have earned {points} points!");
        Console.WriteLine($"You now have {totalPoints} points.\n");
        return totalPoints;
    }

    public override List<SimpleGoal> CreateGoal(List<SimpleGoal> simpleGoals)
    {
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string desc = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        string amount = Console.ReadLine();
        int points = int.Parse(amount);
        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
        string t = Console.ReadLine();
        int timesReq = int.Parse(t);
        Console.Write("What is the bonus for accomplishing it that many times? ");
        string b = Console.ReadLine();
        Console.WriteLine("");
        int bonus = int.Parse(b);
        string goalType = "checklist";
        SimpleGoal goal = new Checklist(timesReq, bonus, name, desc, points, goalType);
        simpleGoals.Add(goal);
        return simpleGoals;
    }

    public override void Display(int number)
    {
        bool c = this.Getcomplete();
        string complete;
        if (c == true)
        {
            complete = "X";
        }
        else
        {
            complete = " ";
        }
        string name = this.GetTitle();
        string desc = this.GetDesc();
        int points = this.Getpoints();
        int timesCompleted = this.GetTimesC();
        int timesReq = this.GetTimesR();
        Console.WriteLine($"{number}. [{complete}] {name} ({desc}) -- worth {points} points --  Currently completed: [{timesCompleted}/{timesReq}]");
    }
}