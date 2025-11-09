using System.ComponentModel.DataAnnotations;

class Activity
{
    private string _name;
    private string _activityDesc;
    private int _timesPerformed;

    public Activity(string name, string activityDesc)
    {
        _name = name;
        _activityDesc = activityDesc;
        _timesPerformed = 0;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetActivityDesc()
    {
        return _activityDesc;
    }

    public void SetTimesPerformed(int timesPerformed)
    {
        _timesPerformed = timesPerformed;
    }
    public int GetTimesPerformed()
    {
        return _timesPerformed;
    }

    public void Menu(Activity breathActivity, Breath breath, Activity reflectionActivity, Reflection reflection, Listing listing)
    {
        string input = "1";
        while (input != "4")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine(" 1. Start breathing activity");
            Console.WriteLine(" 2. Start reflecting activity");
            Console.WriteLine(" 3. Start listing activity");
            Console.WriteLine(" 4. Quit");
            Console.Write("Select a choice from the menu: ");
            input = Console.ReadLine();
            string length = "0";
            if (input == "1")
            {
                length = breathActivity.DisplayMessage();
                breath.Display(length);
                breathActivity.EndMessage(length);
            }
            else if (input == "2")
            {
                length = reflectionActivity.DisplayMessage();
                reflection.Display(length);
                reflectionActivity.EndMessage(length);
            }
            else if (input == "3")
            {
                length = this.DisplayMessage();
                listing.Display(length);
                this.EndMessage(length);
            }
        }
    }

    public void TimesPerformed(string activity)
    {
        if (!File.Exists("activities.txt"))
        {
            using (StreamWriter writer = new StreamWriter("activities.txt"))
            {
                writer.WriteLine($"breathActivity 0");
                writer.WriteLine($"reflectionActivity 0");
                writer.WriteLine($"listingActivity 0");
            }
        }

        string[] lines = File.ReadAllLines("activities.txt");
        string[] content = [];
        List<string> times = [];
        foreach (string line in lines)
        {
            content = line.Split(" ");
            times.Add(content[1]);
        }
        int breathTimes = int.Parse(times[0]);
        int reflectionTimes = int.Parse(times[1]);
        int listingTimes = int.Parse(times[2]);
        if (activity == "Listing")
        {
            breathTimes += 1;
            this.SetTimesPerformed(breathTimes);
        }
        else if (activity == "Reflection")
        {
            reflectionTimes += 1;
            this.SetTimesPerformed(reflectionTimes);
        }
        else
        {
            listingTimes += 1;
            this.SetTimesPerformed(listingTimes);
        }
        using (StreamWriter writer = new StreamWriter("activities.txt"))
        {
            writer.WriteLine($"breathActivity {breathTimes}");
            writer.WriteLine($"reflectionActivity {reflectionTimes}");
            writer.WriteLine($"listingActivity {listingTimes}");
        }
    }

    public string DisplayMessage()
    {
        Console.Clear();
        string name = this.GetName();
        string activityDesc = this.GetActivityDesc();
        Console.WriteLine($"Welcome to the {name} Activity.");
        Console.WriteLine($"\n{activityDesc}");
        Console.Write($"\nHow long, in seconds, would you like for your session? ");
        string length = Console.ReadLine();
        Console.Clear();
        return length;
    }

    public void Spinner()
    {
        for (int i = 1; i < 4; i++)
        { 
            Console.Write("|");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("/");
            Thread.Sleep(250);
            Console.Write("\b \b");                
            Console.Write("-");
            Thread.Sleep(250);
            Console.Write("\b \b");                
            Console.Write("\\");
            Thread.Sleep(250);
            Console.Write("\b \b");            
        }
    }

    public void EndMessage(string input)
    {
        string name = this.GetName();
        this.TimesPerformed(name);
        int timesPerformed = this.GetTimesPerformed();
        Console.WriteLine("\n\nWell done!!");
        Spinner();
        Console.Write("\b \b");
        Console.Write(" ");
        Console.WriteLine($"\n\nYou have completed another {input} seconds of the {name} Activity with a total of {timesPerformed} iterations.");
        Spinner();
        Console.Clear();
    }
    
    public void Counter(int number)
    {
        for (int i = 1; i < number + 1; i++)
        {
            Thread.Sleep(1000);
            Console.Write("\b \b");
            Console.Write($"{number - i}");
        }
        Console.Write("\b \b");
        Console.Write(" ");
    }
}