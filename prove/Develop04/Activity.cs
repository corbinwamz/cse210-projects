using System.ComponentModel.DataAnnotations;

class Activity
{
    private string _name;
    private string _activityDesc;

    public Activity(string name, string activityDesc)
    {
        _name = name;
        _activityDesc = activityDesc;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetActivityDesc()
    {
        return _activityDesc;
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
        Console.WriteLine("\n\nWell done!!");
        Spinner();
        Console.Write("\b \b");
        Console.Write(" ");
        Console.WriteLine($"\n\nYou have completed another {input} seconds of the {name} Activity.");
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