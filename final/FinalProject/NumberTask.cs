class NumberTask : Task
{
    private int _timesRequired;
    private int _timesDone;

    public NumberTask()
    {
    }

    public NumberTask(int timesRequired, int timesDone, string filename, string task, string type, bool complete) : base(filename, task, type, complete)
    {
        _timesRequired = timesRequired;
        _timesDone = timesDone;
    }
    public NumberTask(int timesRequired, string filename, string task, string type) : base(filename, task, type)
    {
        _timesRequired = timesRequired;
        _timesDone = 0;
    }

    public override int GetTimesRequired()
    {
        return _timesRequired;
    }
    public override int GetTimesDone()
    {
        return _timesDone;
    }

    public override void SetTimesDone(int timesDone)
    {
        _timesDone = timesDone;
    }
    

    public override Task NewDailyTask(string filename)
    {
        Console.Clear();
        Console.Write("What is the name of the task? ");
        string task = Console.ReadLine();
        string type = "numbertask";
        Console.Write("\nHow many times do you want to require to complete this task? ");
        string times = Console.ReadLine();
        int timesRequired = int.Parse(times);
        Task newTask = new NumberTask(timesRequired, filename, task, type);
        return newTask;
    }
}