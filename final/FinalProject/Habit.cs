class Habit
{
    private string _habit;
    private string _desc;
    private List<DateTime> _dayComplete;
    private string _frequency;
    private List<Habit> _habits;
    private DateTime _dayCreated; // so it can be included in the graph 

    public Habit()
    {
        _habit = "";
        _desc = "";
        _dayComplete = [];
        _frequency = "";
        _habits = [];
        _dayCreated = DateTime.Today;
    }

    public Habit(string habit, string desc, string frequency)
    {
        _habit = habit;
        _desc = desc;
        _dayComplete = [];
        _frequency = frequency;
        _habits = [];
        _dayCreated = DateTime.Today;
    }

    public Habit(string habit, string desc, List<DateTime> dayComplete, string frequency)
    {
        _habit = habit;
        _desc = desc;
        _dayComplete = dayComplete;
        _frequency = frequency;
        _habits = [];
        _dayCreated = DateTime.Today;
    }

    public Habit(string habit, string desc, List<DateTime> dayComplete, string frequency, DateTime dayCreated)
    {
        _habit = habit;
        _desc = desc;
        _dayComplete = dayComplete;
        _frequency = frequency;
        _habits = [];
        _dayCreated = dayCreated;
    }

    public List<Habit> GetHabits()
    {
        return _habits;
    }

    public List<DateTime> GetComplete()
    {
        return _dayComplete;
    }

    public string GetHabit()
    {
        return _habit;
    }
    public string GetDesc()
    {
        return _desc;
    }
    public string GetFrequency()
    {
        return _frequency;
    }

    public DateTime GetDayCreated()
    {
        return _dayCreated;
    }
    public void Display()
    {
        Habit newHabit = null;
        string filename = "";
        string input = "3";
        while (input != "1" & input != "2")
        {
            Console.Write("Would you like to load an existing habits file (1) or create a new one (2)? ");
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
                Console.Write("\nWhat is the file name for your habits? ");
                filename = Console.ReadLine();
                if (File.Exists(filename))
                {  
                    newHabit = new();
                    newHabit.Load(filename);
                    Console.WriteLine("\nHabits loaded!");
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
            newHabit = new();
            Console.Write("\nWhat would you like to name the file for your habits? ");
            filename = Console.ReadLine();
            Console.WriteLine("\nHabits file created!\n");
            Thread.Sleep(1000);
        }

        input = "1";
        while (input == "1" || input == "2" || input == "3" || input == "4")
        {
            Console.Clear();
            Console.Clear();
            List<Habit> habits = newHabit.GetHabits();
            if (habits.Count() == 0)
            {
                Console.WriteLine("You have no habits logged. Make and complete some habits and a graph of your progress for the week will be made");
            }
            else
            {    
                GraphHabit newGraphHabit = new();
                newGraphHabit.DisplayGraph(habits);
            }
            Console.Write(
                    $"\n\n\n[{filename}]\n\n"+
                    "   1. New Habit\n"+
                    "   2. Complete habit\n"+
                    "   3. Delete habits\n"+
                    "   4. View habits\n"+
                    "   5. Save and quit\n"
                );
            int index = 1;
            int count = 0;

            List<string> prints = [];
            if (habits.Count() != 0)
            {
                foreach (Habit habit in habits)
                {
                    List<DateTime> dateComplete = habit.GetComplete();
                    int i = dateComplete.Count();
                    string name = habit.GetHabit();
                    string frequency = habit.GetFrequency();
                    DateTime today = DateTime.Today;
                    TimeSpan difference = new TimeSpan(2, 30, 0);
                    int days = 0;
                    bool print = false;
                    if (i != 0)
                    {  
                        difference = today - dateComplete[i-1];
                        days = difference.Days;
                    }
                    else
                    {
                        print = true;
                    }

                    if (frequency == "daily" & days > 0 || print == true)
                    {
                        prints.Add($"    {index}: {name}");
                        index += 1;
                        count += 1;
                    }
                    else if (frequency == "everyotherday" & days > 1 || print == true)
                    {
                        prints.Add($"    {index}: {name}");
                        index += 1;
                        count += 1;
                    }
                    else if (frequency == "weekly" & days > 6 || print == true)
                    {
                        prints.Add($"    {index}: {name}");
                        index += 1;
                        count += 1;
                    }
                    else if (print == true || frequency == "monthly" & today >= dateComplete[i-1].AddMonths(1))
                    {
                        prints.Add($"    {index}: {name}");
                        index += 1;
                        count += 1;
                    }
                }
            }
            if (prints.Count() > 0)
            {
                Console.WriteLine("\nYou have incomplete habits today:");
                foreach (string line in prints)
                {
                    Console.WriteLine(line);
                }
            }
            if (count == 0 & habits.Count() != 0)
            {
                Console.WriteLine("\nWell done! There are no habit left to do today!");
            }
            Console.Write("\nWhat action would you like to do? ");
            input = Console.ReadLine();
            if (input == "1")
            {
                newHabit.NewHabit();
            }
            if (input == "2")
            {
                newHabit.CompleteHabit();
            }
            else if (input == "3")
            {
                newHabit.DeleteHabit();
            }
            else if (input == "4")
            {
                newHabit.DisplayHabits();
                Console.Write("Type enter when done");
                Console.ReadKey(true);
            }
            else if (input == "5")
            {
                newHabit.Save(filename);
                Console.Write("\nSave sucessful!");
                Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine("Please type in a 1,2,3,4, or 5 only");
                input = "1";
            }
        }
    }

    public void NewHabit()
    {  
        Habit newHabit;   
        Console.Clear();
        Console.Write("What would you like to name your habit? ");
        string name = Console.ReadLine();
        Console.Write("\nType in the description of the habit: ");
        string desc = Console.ReadLine();
        List<Habit> habits = this.GetHabits();
        Console.Write("\nWhat is the frequency of your habit?\n1. Daily\n2. Every other day\n3. Weekly\n4. Monthly\nType 1,2,3, or 4: ");
        string frequency = Console.ReadLine();
        while (frequency != "1" & frequency != "2" & frequency != "3" & frequency != "4")
        {
            Console.WriteLine("\nPlease enter a 1,2,3, or 4 only: ");
            frequency = Console.ReadLine();
        }
        if (frequency == "1")
        {
            frequency = "daily";
            newHabit = new(name, desc, frequency);
        }
        else if (frequency == "2")
        {
            frequency = "everyotherday";
            newHabit = new(name, desc, frequency);
        }
        else if (frequency == "3")
        {
            frequency = "weekly";
            newHabit = new(name, desc, frequency);
        }
        else
        {
            frequency = "monthly";
            newHabit = new(name, desc, frequency);
        }
        habits.Add(newHabit);
        Console.WriteLine("\n\nTask created");
        Thread.Sleep(1000);
    }

    public void Save(string filename)
    {
        List<Habit> habits = this.GetHabits();
        using (StreamWriter outputFile = new StreamWriter(filename))
        { 
            foreach (Habit habit in habits)
            {   
                string name = habit.GetHabit();
                string desc = habit.GetDesc();
                string frequency = habit.GetFrequency();
                List<DateTime> dateComplete = habit.GetComplete();
                DateTime dateCreated = habit.GetDayCreated();
                outputFile.Write($"{name}|{desc}|{frequency}|{dateCreated}|");
                foreach (DateTime date in dateComplete)
                {
                    outputFile.Write($"{date},");
                }
                outputFile.Write("\n");
            }
        }
    }

    public void Load(string filename)
    {
        string[] linesArray = File.ReadAllLines(filename);
        List<string> lines = linesArray.ToList();
        List<Habit> habits = this.GetHabits();

        foreach (string line in lines)
        {
            string[] items = line.Split("|");
            string name = items[0].Trim();
            string desc = items[1].Trim();
            string frequency = items[2].Trim();
            string d = items[3].Trim();
            DateTime dateCreated = DateTime.Parse(d);
            List<string> dates = items[4].Split(",").ToList();
            int num = dates.Count();
            dates.RemoveAt(num-1);
            List<DateTime> dates1 = [];
            foreach (string date in dates)
            {
                DateTime day = DateTime.Parse(date);
                dates1.Add(day);
            }

            Habit habit = new(name, desc, dates1, frequency, dateCreated);
            habits.Add(habit);
        }
    }

    public void DeleteHabit()
    {
        List<Habit> habits = this.GetHabits();
        this.DisplayHabits();
        Console.Write("Which habit do you want to delete? ");
        string input = Console.ReadLine();
        int i = int.Parse(input);
        habits.RemoveAt(i-1);
        Console.WriteLine("\n\nHabit removed");
        Thread.Sleep(1000);
    }

    public void CompleteHabit()
    {
        List<Habit> habits = this.GetHabits();
        this.DisplayHabits();
        Console.Write("Which habit have you completed? ");
        string input = Console.ReadLine();
        int i = int.Parse(input);
        List<DateTime> dates = habits[i-1].GetComplete();
        dates.Add(DateTime.Today);
        Console.WriteLine("\n\nHabit completed");
        Thread.Sleep(1000);
    }

    public void DisplayHabits()
    {
        Console.Clear();
        List<Habit> habits = this.GetHabits();
        int index = 1;
        foreach (Habit habit in habits)
        {   
            string name = habit.GetHabit();
            string desc = habit.GetDesc();
            string frequency = habit.GetFrequency();
            List<DateTime> dateComplete = habit.GetComplete();
            Console.WriteLine($"{index}: {name} - {desc}\n  Frequency: {frequency}\n");
            index+=1;
        }
    }
}