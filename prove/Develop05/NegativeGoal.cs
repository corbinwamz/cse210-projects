class NegativeGoal : SimpleGoal
{
    private int _timesAllowed;
    private int _timesDone;

    public NegativeGoal() : base()
    {
        _timesAllowed = 0;
        _timesDone = 0;
    }

    public NegativeGoal(int timesAllowed, string title, string desc, int points, string goalType) : base(title, desc, points, goalType)
    {
        _timesAllowed = timesAllowed;
        _timesDone = timesAllowed;
    }
    public NegativeGoal(int timesAllowed, int timesDone, string title, string desc, int points, bool complete, string goalType) : base(title, desc, points, goalType)
    {
        _timesAllowed = timesAllowed;
        _timesDone = 0;
    }

    public override int GetTimesDone()
    {
        return _timesDone;
    }
    public override int GetTimesAllowed()
    {
        return _timesAllowed;
    }

    public void SetTimesDone(int timesDone)
    {
        _timesDone = timesDone;
    }

    public override List<SimpleGoal> CreateGoal(List<SimpleGoal> simpleGoals)
    {
        Console.Write("What is the name of the habit you want to break? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string desc = Console.ReadLine();
        Console.Write("What is the amount of points you want to lose for doing it? ");
        string amount = Console.ReadLine();
        Console.Write("How many times will you allow yourself to do it before losing points? ");
        string f = Console.ReadLine();
        int timesAllowed = int.Parse(f);
        Console.WriteLine("");
        int points = int.Parse(amount);
        string goalType = "negative_goal";
        SimpleGoal goal = new NegativeGoal(timesAllowed, name, desc, points, goalType);
        simpleGoals.Add(goal);
        return simpleGoals;
    }

    public override int Complete(int totalPoints)
    {
        int timesA = this.GetTimesAllowed();
        int timesD = this.GetTimesDone();
        int points = this.Getpoints();
        timesD -= 1;
        SetTimesDone(timesD);
        if (timesD == 0)
        {           
            this.SetComplete();
            totalPoints -= points;
            Console.WriteLine("Bummer! You failed. You got it though I belive in you!");
            Console.WriteLine($"You lost {points} points.\n");
        }
        else
        {    
            Console.WriteLine($"Bummer! {timesD} more times and you'll lost {points} points!");
            Console.WriteLine($"You still have {totalPoints} points.\n");
        }
        return totalPoints;
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
        int timesAllowed = this.GetTimesAllowed();
        int timesDone = this.GetTimesDone();
        if (complete == "X")
        {
            Console.WriteLine($"{number}. [{complete}] {name} ({desc}) -- worth {points} points --  Times left: [Failed]");
        }
        else
        {   
            Console.WriteLine($"{number}. [{complete}] {name} ({desc}) -- worth {points} points --  Times left: [{timesDone}/{timesAllowed}]");
        }
    }
}