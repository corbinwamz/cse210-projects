class ListTask : Task
{
    private List<Task> _tasks;

    public ListTask()
    {
    }

    public ListTask(string filename, string task, string type) : base(filename, task, type)
    {
        _tasks = [];
    }

    public ListTask(List<Task> tasks, string filename, string task, string type, bool complete) : base(filename, task, type, complete)
    {
        _tasks = tasks;
    }

    public override List<Task> GetListTasks()
    {
        return _tasks;
    }

    public override Task NewDailyTask(string filename)
    {
        string type = "listtask";
        Console.Clear();
        Console.Write("What is the name of the list of tasks? ");
        string taskList = Console.ReadLine();
        Task listTask = new ListTask(filename, taskList, type);
        Console.Write("How many task do you want to put in this list? ");
        string input = Console.ReadLine();
        int num = int.Parse(input);
        List<Task> tasks = listTask.GetListTasks();
        for (int i = 0; i < num; i++)
        {
            Console.Write($"\nWhat is the name of your task number {i+1}? ");
            string task = Console.ReadLine();
            Task newTask = new(filename, task, type);
            tasks.Add(newTask);
        }
        return listTask;
    }
}