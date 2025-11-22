class Eternal : SimpleGoal
{
    public Eternal()
    {
        
    }
    public Eternal(string title, string desc, int points, string goalType) : base(title, desc, points, goalType)
    {
        
    }
    public Eternal(string title, string desc, int points, bool complete, string goalType) : base(title, desc, points, complete, goalType)
    {
        
    }
    public override int Complete(int totalPoints)
    {
        int points = this.Getpoints();
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
        Console.WriteLine("");
        int points = int.Parse(amount);
        string goalType = "eternal";
        SimpleGoal goal = new(name, desc, points, goalType);
        simpleGoals.Add(goal);
        return simpleGoals;
    }
}