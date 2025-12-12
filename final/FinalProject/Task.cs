using System.IO.Enumeration;

class Task 
{
    private string _filename;
    private string _task; //name
    private string _type;
    private List<Task> _tasks;
    private bool _complete;

    public Task()
    {
        _tasks = [];
        _filename = "";
        _task = "";
        _type = "";
        _complete = false;

    }

    public Task(string filename, string task, string type)
    {
        _filename = filename;
        _task = task;
        _type = type;
        _tasks = [];
        _complete = false;
    }

    public Task(string filename, string task, string type, bool complete)
    {
        _filename = filename;
        _task = task;
        _type = type;
        _tasks = [];
        _complete = complete;
    }

    public List<Task> GetTasks()
    {
        return _tasks;
    }
    public string GetTaskType()
    {
        return _type;
    }
    public bool GetComplete()
    {
        return _complete;
    }

    public void SetComplete()
    {
        _complete = true;
    }
    public string GetTask()
    {
        return _task;
    }

    public virtual DateTime GetDayComplete()
    {
        return DateTime.Now;
    }

    public virtual string GetTaskListName()
    {
        return "";
    }

    public virtual int GetTimesRequired()
    {
        return 0;
    }
    public virtual int GetTimesDone()
    {
        return 0;
    }

    public virtual List<Task> GetListTasks()
    {
        return [];
    }

    public virtual Task NewDailyTask(string filename)
    {
        Task task = new();
        return task;
    }

    public virtual void SetDayComplete(DateTime today)
    {

    }

    public virtual void SetTimesDone(int timesDone)
    {}

    public void Display()
    {
        Task newTask = null;
        string filename = "";
        string input = "3";
        while (input != "1" & input != "2")
        {
            Console.Write("Would you like to load an existing task sheet (1) or create a new one (2)? ");
            input = Console.ReadLine();
            if (input != "1" & input != "2")
            {             
                Console.WriteLine("Please enter in a 1 or 2 only");
            }
        }
        if (input == "1")
        {
            bool found = false;
            while (found == false)
            {               
                Console.Write("\nWhat is the file name for your task sheet? ");
                filename = Console.ReadLine();
                if (File.Exists(filename))
                {  
                    newTask = new();
                    newTask.LoadTasks(filename);
                    Console.WriteLine("\nTask sheet loaded!");
                    Thread.Sleep(1000);
                    found = true;
                }
                else
                {
                    Console.WriteLine("\nFile not found. Check your spelling and try again");
                }
            }
        }
        else
        {
            newTask = new();
            Console.Write("\nWhat would you like to name the file for your task sheet? ");
            filename = Console.ReadLine();
            Console.WriteLine("\nTask sheet created!\n");
            Thread.Sleep(1000);
        }

        input = "1";
        while (input == "1" || input == "2" || input == "3" || input == "4")
        {
            Console.Clear();
            Console.Write(
                    $"[{filename}]\n\n"+
                    "   1. New task\n"+
                    "   2. Complete task\n"+
                    "   3. Delete tasks\n"+
                    "   4. View tasks\n"+
                    "   5. Save and quit\n"+
                    "\nWhat action would you like to do? "
                );
            input = Console.ReadLine();
            if (input == "1")
            {
                newTask.NewTask(filename);
            }
            if (input == "2")
            {
                newTask.CompleteTask();
            }
            else if (input == "3")
            {
                newTask.DeleteTask();
            }
            else if (input == "4")
            {
                newTask.ViewTasks();
                Console.Write("\nType enter when done");
                Console.ReadKey(true);
            }
            else if (input == "5")
            {
                newTask.SaveTasks(filename);
                Console.Write("\nSave sucessful!");
                Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine("Please type in a 1,2,3, or 4 only");
                input = "1";
            }
        }
    }

    // type|task|complete
    public void LoadTasks(string filename)
    {
        string[] linesArray = File.ReadAllLines(filename);
        List<string> lines = linesArray.ToList();
        List<Task> entries = this.GetTasks();

        foreach (string line in lines)
        {
            string[] items = line.Split("|");
            string type = items[0].Trim();
            string task = items[1].Trim();
            string c = items[2].Trim();
            bool complete = bool.Parse(c);

            if (type == "task")
            {
                Task newTask = new(filename, task, type, complete);
                entries.Add(newTask);
            }
            else if (type == "dailytask")
            {
                string dateComplete = items[3];
                DateTime date = DateTime.Parse(dateComplete);
                Task newTask = new DailyTask(date, filename, task, type, complete);
                entries.Add(newTask);
            }
            else if (type == "listtask")
            {
                List<string> listTasks = items[3].Split(",").ToList();
                int count = listTasks.Count();
                listTasks.RemoveAt(count-1);
                List<Task> tasks = [];
                foreach (string p in listTasks)
                {
                    List<string> newItems = p.Split(" ").ToList();
                    type = newItems[0].Trim();
                    task = newItems[1].Trim();
                    c = newItems[2].Trim();
                    complete = bool.Parse(c);
                    Task newTask = new(filename, task, type, complete);
                    tasks.Add(newTask);
                }
                Task newListTask = new ListTask(tasks, filename, task, type, complete);
                entries.Add(newListTask);
            }
            else
            {
                string times = items[3];
                int timesRequired = int.Parse(times);
                times = items[4];
                int timesDone = int.Parse(times);
                Task newTask = new NumberTask(timesRequired, timesDone, filename, task, type, complete);
                entries.Add(newTask);
            }
    
        }
    }

    public void SaveTasks(string filename)
    {
        List<Task> entries = this.GetTasks();
        using (StreamWriter outputFile = new StreamWriter(filename))
        { 
            foreach (Task item in entries)
            {   
                string type = item.GetTaskType();
                string task = item.GetTask();
                bool complete = item.GetComplete();
                if (type == "task")
                {
                    outputFile.WriteLine($"{type}|{task}|{complete}");
                }
                else if(type == "dailytask")
                {
                    DateTime dateComplete = item.GetDayComplete();
                    outputFile.WriteLine($"{type}|{task}|{complete}|{dateComplete}");
                }
                else if (type == "listtask")
                {
                    List<Task> tasks = item.GetListTasks();
                    outputFile.Write($"{type}|{task}|{complete}|");
                    foreach (Task i in tasks)
                    {       
                        type = i.GetTaskType();
                        task = i.GetTask();
                        complete = i.GetComplete();              
                        outputFile.Write($"{type} {task} {complete},");
                    }
                    outputFile.Write("\n");
                }
                else
                {
                    int timesRequired = item.GetTimesRequired();
                    int timesDone = item.GetTimesDone();
                    outputFile.WriteLine($"{type}|{task}|{complete}|{timesRequired}|{timesDone}");
                }
            }
        }
    }

    public virtual void NewTask(string filename)
    {
        string input = "1";   
        Task newTask;   
        while (input == "1" || input == "2" || input == "3" || input == "4")
        {
            Console.Clear();
            Console.Write(
                "1. Task\n"+
                "2. Daily task\n"+
                "3. List task\n"+
                "4. Number task\n"
            );
            Console.Write("\nWhich type of task would you like to create? ");
            input = Console.ReadLine();
            List<Task> tasks = this.GetTasks();
            if (input == "1")
            {
                Console.Clear();
                Console.Write("What is the name of the task? ");
                string task = Console.ReadLine();
                string type = "task";
                newTask = new(filename, task, type);
                tasks.Add(newTask);
                break;
            }
            if (input == "2")
            {
                Console.Clear();
                Task newDailyTask = new DailyTask();
                Task task = newDailyTask.NewDailyTask(filename);
                tasks.Add(task);
                break;
            }
            if (input == "3")
            {
                Console.Clear();
                Task newListTask = new ListTask();
                Task task = newListTask.NewDailyTask(filename);
                tasks.Add(task);
                break;
            }
            if (input == "4")
            {
                Console.Clear();
                Task newNumberTask = new NumberTask();
                Task task = newNumberTask.NewDailyTask(filename);
                tasks.Add(task);
                break;
            }
            else
            {
                Console.WriteLine("Please enter a 1,2,3, or 4 only");
            }
        }
        Console.WriteLine("\nTask created");
        Thread.Sleep(1000);
    }

    public virtual void CompleteTask()
    {
        List<Task> tasks = this.GetTasks();
        this.ViewTasks();
        Console.Write("\nWhich task would you like to complete? ");
        string input = Console.ReadLine();
        int i = int.Parse(input) - 1;
        Task task = tasks[i];
        string type = task.GetTaskType();
        if (type == "dailytask")
        {
            DateTime dateComplete = DateTime.Now;
            task.SetDayComplete(dateComplete);
        }
        else if (type == "listtask")
        {
            List<Task> listTasks = task.GetListTasks();
            int index = 1;
            foreach (Task listTask in listTasks)
            {
                string name = listTask.GetTask();
                bool complete = listTask.GetComplete();
                string com = Complete(complete);
                Console.WriteLine($"{index}: {name} [{com}]");
                index += 1;
            }
            Console.Write("Which task in your list do you want to complete? ");
            input = Console.ReadLine();
            i = int.Parse(input)-1;
            listTasks[i].SetComplete();
        }
        else if (type == "numbertask")
        {
            int timesRequired = task.GetTimesRequired();
            int timesDone = task.GetTimesDone();
            timesDone += 1;
            if (timesRequired > timesDone)
            {
                task.SetTimesDone(timesDone);
            }
            else
            {
                task.SetComplete();
            }
        }
        else
        {
            task.SetComplete();
        }
    }

    public void ViewTasks()
    {
        Console.Clear();
        List<Task> tasks = this.GetTasks();

        int num = tasks.Count();
        if (num > 0)
        { 
            int index = 1;
            Console.WriteLine("Tasks:");
            foreach (Task task in tasks)
            {
                string name = task.GetTask();
                string type = task.GetTaskType();
                bool complete = task.GetComplete();
                string com = Complete(complete);
                if (type == "task")
                {
                    Console.WriteLine($"{index}: {name} [{com}]");
                    index += 1;
                }
            }
            Console.WriteLine("\n\nDaily tasks:");
            foreach (Task task in tasks)
            {
                string name = task.GetTask();
                string type = task.GetTaskType();
                bool complete = task.GetComplete();
                DateTime dayComplete = task.GetDayComplete();
                DateTime today = DateTime.Now;
                TimeSpan difference = today - dayComplete;
                int days = difference.Days;
                string com = Complete(complete);
                if (type == "dailytask")
                {
                    if (days > 0)
                    {                    
                        Console.WriteLine($"{index}: {name} [ ]");
                        index += 1;
                    }
                    else
                    {
                        Console.WriteLine($"{index}: {name} [X]");
                        index += 1;
                    }
                }
            }
            Console.WriteLine("\n\n\nList tasks:");
            foreach (Task task in tasks)
            {
                string name = task.GetTask();
                string type = task.GetTaskType();
                List<Task> listTasks = task.GetListTasks();
                if (type == "listtask")
                {

                    Console.WriteLine($"{index}: {name}");
                    index += 1;
                    foreach (Task item in listTasks)
                    {
                        name = item.GetTask();
                        bool complete = item.GetComplete();
                        string com = Complete(complete);
                        Console.WriteLine($"   -{name} [{com}]");
                    }
                }
            }
            Console.WriteLine("\n\n\nNumber tasks:");
            foreach (Task task in tasks)
            {
                string name = task.GetTask();
                string type = task.GetTaskType();
                if (type == "numbertask")
                {   
                    int timesRequired = task.GetTimesRequired();
                    int timesDone = task.GetTimesDone();
                    bool complete = task.GetComplete();
                    if (complete == true)
                    {
                        Console.WriteLine($"{index}: {name} [X]");
                    }
                    else
                    {                       
                        Console.WriteLine($"{index}: {name} [{timesDone}/{timesRequired}]");
                    }
                    index += 1;
                }
            }
        }
        else
        {
            Console.WriteLine("There are no entries");
            Thread.Sleep(1000);
        }
    }

    public string Complete(bool complete)
    {
        string com;
        if (complete == true)
        {
            com = "X";
        }
        else
        {
            com = " ";
        }
        return com;
    }

    public void DeleteTask()
    {
        List<Task> tasks = this.GetTasks();
        this.ViewTasks();
        Console.Write("Which task number do you want to delete? ");
        string input = Console.ReadLine();
        int i = int.Parse(input)-1;
        string type = tasks[i].GetTaskType();
        if (type == "listtask")
        {
            Console.Write("\nDo you want to delete the list or a task in the list (1/2)? ");
            input = Console.ReadLine();
            if (input == "1")
            {
                tasks.RemoveAt(i);
            }
            else
            {    
                List<Task> listTasks = tasks[i].GetListTasks();
                int index = 1;
                foreach (Task item in listTasks)
                {
                    string name = item.GetTask();
                    Console.WriteLine($"{index}: {name}");
                    index += 1;
                }
                Console.Write("Which task do you want to delete? ");
                input = Console.ReadLine();
                i = int.Parse(input)-1;
                listTasks.RemoveAt(i);
            }

        }
        else
        {
            tasks.RemoveAt(i);
        }
        Console.WriteLine("Task removed");
        Thread.Sleep(1000);
    }
}