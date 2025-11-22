using System.Reflection.Metadata.Ecma335;

class SimpleGoal
{
    private string _title;
    private int _points;
    private bool _complete;
    private string _desc;
    private string _goalType;

    public SimpleGoal()
    {
        _title = "";
        _points = 0;
        _complete = false;
        _desc = "";
        _goalType = "";
    }

    public SimpleGoal(string title, string desc, int points, string goalType)
    {
        _title = title;
        _desc = desc;
        _points = points;
        _complete = false;
        _goalType = goalType;
    }

    public SimpleGoal(string title, string desc, int points, bool complete, string goalType)
    {
        _title = title;
        _desc = desc;
        _points = points;
        _complete = complete;
        _goalType = goalType;
    }

    public string GetGoalType()
    {
        return _goalType;
    }
    public string GetTitle()
    {
        return _title;
    }
    public int Getpoints()
    {
        return _points;
    }
    public bool Getcomplete()
    {
        return _complete;
    }
    public string GetDesc()
    {
        return _desc;
    }
    public void SetComplete()
    {
        _complete = true;
    }

    public virtual int GetTimesC()
    {
        int i = 0;
        return i;
    }
    public virtual int GetTimesR()
    {
        int i = 0;
        return i;
    }
    public virtual int GetBonus()
    {
        int i = 0;
        return i;
    }

    public virtual List<SimpleGoal> CreateGoal(List<SimpleGoal> simpleGoals)
    {
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string desc = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        string amount = Console.ReadLine();
        Console.WriteLine("");
        int points = int.Parse(amount);
        string goalType = "simple_goal";
        SimpleGoal goal = new(name, desc, points, goalType);
        simpleGoals.Add(goal);
        return simpleGoals;
    }

    public virtual int Complete(int totalPoints)
    {
        this.SetComplete();
        int points = this.Getpoints();
        totalPoints += points;
        Console.WriteLine($"Congratulations! You have earned {points} points!");
        Console.WriteLine($"You now have {totalPoints} points.\n");
        return totalPoints;
    }

    public virtual void Display(int number)
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
        Console.WriteLine($"{number}. [{complete}] {name} ({desc}) -- worth {points} points --");
    }
}