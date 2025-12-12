class DailyTask : Task
{
    private DateTime _dayComplete;

    public DailyTask()
    {
    }
    public DailyTask(string filename, string task, string type) : base(filename, task, type)
    {
        _dayComplete = DateTime.Now.AddDays(-1);
    }
    public DailyTask(DateTime dayComplete, string filename, string task, string type, bool complete) : base(filename, task, type, complete)
    {
        _dayComplete = dayComplete;
    }

    public override DateTime GetDayComplete()
    {
        return _dayComplete;
    }

    public override void SetDayComplete(DateTime today)
    {
        _dayComplete = today;
    }

    public override Task NewDailyTask(string filename)
    {
        Console.Clear();
        Console.Write("What is the name of the daily task? ");
        string task = Console.ReadLine();
        string type = "dailytask";
        Task newTask = new DailyTask(filename, task, type);
        return newTask;
    }
}