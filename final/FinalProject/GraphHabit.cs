class GraphHabit : Habit
{
    private List<DateTime> _daysDue;
    private List<DateTime> _daysDone;

    public GraphHabit(List<DateTime> daysDue, List<DateTime> daysDone, string habit, string desc, List<DateTime> dayComplete, string frequency, DateTime dateCreated) : base(habit, desc, dayComplete, frequency, dateCreated)
    {
       _daysDue = daysDue;
       _daysDone = daysDone; 
    }

    public GraphHabit()
    {}

    public List<DateTime> GetDaysDue()
    {
        return _daysDue;
    }

    public List<DateTime> GetDaysDone()
    {
        return _daysDone;
    }

    public void DisplayGraph(List<Habit> habits)
    {
        List<DateTime> weekDates = DatesThisWeek();
        DateTime today = DateTime.Today;

        Console.Clear();
        Console.WriteLine("\n--- Weekly Progress Graph ---\n");

        ConsoleColor[] palette = {
            ConsoleColor.Cyan, ConsoleColor.Magenta, ConsoleColor.Yellow,
            ConsoleColor.Green, ConsoleColor.Red, ConsoleColor.Blue,
            ConsoleColor.White, ConsoleColor.DarkYellow, ConsoleColor.DarkCyan,
            ConsoleColor.DarkMagenta, ConsoleColor.DarkGreen, ConsoleColor.Gray
        };

        Dictionary<string, ConsoleColor> habitColors = new();
        for (int i = 0; i < habits.Count; i++)
        {
            habitColors[habits[i].GetHabit()] = palette[i % palette.Length];
        }

        HashSet<string> graphedHabits = new HashSet<string>();

        foreach (DateTime day in weekDates)
        {
            Console.Write($"{day.DayOfWeek.ToString().PadRight(10)} | ");

            if (day > today)
            {
                Console.WriteLine();
                continue;
            }

            List<Habit> dueOnThisDay = [];
            List<Habit> completedOnThisDay = [];

            foreach (Habit habit in habits)
            {
                List<DateTime> daysDue = GetWeeklyHabitsDue(habit);

                if (daysDue.Contains(day))
                {
                    dueOnThisDay.Add(habit);

                    List<DateTime> daysDone = GetWeeklyHabitsDone(habit);
                    if (daysDone.Contains(day))
                    {
                        completedOnThisDay.Add(habit);
                        
                        graphedHabits.Add(habit.GetHabit()); 
                    }
                }
            }

            if (dueOnThisDay.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Rest Day");
                Console.ResetColor();
                continue;
            }

            int totalBarWidth = 20;
            double widthPerHabit = (double)totalBarWidth / dueOnThisDay.Count;
            int blocksPrinted = 0;

            foreach (Habit doneHabit in completedOnThisDay)
            {
                Console.ForegroundColor = habitColors[doneHabit.GetHabit()];
                int blocksToDraw = (int)Math.Round(widthPerHabit);

                for (int b = 0; b < blocksToDraw; b++)
                {
                    if (blocksPrinted < totalBarWidth)
                    {
                        Console.Write("█");
                        blocksPrinted++;
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.DarkGray;
            while (blocksPrinted < totalBarWidth)
            {
                Console.Write("░");
                blocksPrinted++;
            }

            int percentage = (int)((double)completedOnThisDay.Count / dueOnThisDay.Count * 100);
            Console.ResetColor();
            Console.WriteLine($" {percentage}%");
        }

        Console.WriteLine("-----------------------------");

        Console.WriteLine("Key:");
        foreach (var kvp in habitColors)
        {
            if (graphedHabits.Contains(kvp.Key))
            {
                Console.ForegroundColor = kvp.Value;
                Console.Write("■ ");
                Console.ResetColor();
                Console.Write($"{kvp.Key}  ");
            }
        }
    }

    public List<DateTime> GetWeeklyHabitsDue(Habit habit)
    {
        List<DateTime> datesThisWeek = DatesThisWeek();
        List<DateTime> datesDue = [];
        DateTime dateCreated = habit.GetDayCreated();
        DateTime saturday = datesThisWeek[6].Date;
        string frequency = habit.GetFrequency();

        if (frequency == "daily")
        {
            datesDue = datesThisWeek;
        }
        else if (frequency == "everyotherday")
        {
            bool iterate = true;
            DateTime d = dateCreated;
            while (iterate == true)
            {
                d = d.AddDays(2);
                if (datesThisWeek.Contains(d))
                {
                    datesDue.Add(d);
                }

                if (d > saturday)
                {
                    iterate = false;
                }
            }
        }
        else if (frequency == "weekly" || frequency == "monthly")
        {
            int type = 0;
            if (frequency == "weekly")
            {
                type = 1;
            }

            bool iterate = true;
            DateTime d = dateCreated;
            while (iterate == true)
            {
                if (type == 1)
                {
                    d = d.AddDays(7);
                }
                else
                {
                    d = d.AddMonths(1);
                }

                if (datesThisWeek.Contains(d))
                {
                    datesDue.Add(d);
                }

                if (d > saturday)
                {
                    iterate = false;
                }
            }
        }
        return datesDue;
    }

    public List<DateTime> GetWeeklyHabitsDone(Habit habit)
    {
        List<DateTime> datesDone = [];
        List<DateTime> datesThisWeek = DatesThisWeek();
        List<DateTime> dates = habit.GetComplete();
        foreach (DateTime date in dates)
        {
            if (datesThisWeek.Contains(date))
            {
                datesDone.Add(date);
            }
        }
        return datesDone;
    }

    public List<DateTime> DatesThisWeek()
    {
        List<DateTime> datesThisWeek = [];
        DayOfWeek d = DateTime.Today.DayOfWeek;
        string day = d.ToString();
        int index = 0;
        if (day == "Monday")
        {
            index = -1;
        }
        else if (day == "Wednesday")
        {
            index = -3;
        }
        else if (day == "Thursday")
        {
            index = -4;
        }
        else if (day == "Friday")
        {
            index = -5;
        }
        else if (day == "Saturday")
        {
            index = -6;
        }
        else if (day == "Tuesday")
        {
            index = -2;
        }
        for (int i = 0; i < 7; i++)
        {
            DateTime dayThisWeek = DateTime.Today.AddDays(index);
            datesThisWeek.Add(dayThisWeek);
            index+=1;
        }
        return datesThisWeek;
    }
}