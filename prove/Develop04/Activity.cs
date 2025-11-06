class Activity
{
    private string _name;
    private List<string> _activityDesc;

    public int RandomGen()
    {
        Random random = new();
        int number = random.Next(1, 10);
        return number;
    }

    public void Menu()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine(" 1. Start breathing activity");
        Console.WriteLine(" 2. Start reflecting activity");
        Console.WriteLine(" 3. Start listing activity");
        Console.WriteLine(" 4. Quit");
        Console.WriteLine("Select a choice from the menu: ");
        string input = Console.ReadLine();
    }

    public void DisplayMessage()
    {

    }

    public void Spinner()
    {
        Console.Write(new string("|"));
        Console.SetCursorPosition(0, Console.CursorTop);
        Thread.Sleep(500);
        Console.Write(new string("/"));
        Console.SetCursorPosition(0, Console.CursorTop);                
        Thread.Sleep(500);
        Console.Write(new string("-"));
        Console.SetCursorPosition(0, Console.CursorTop);                
        Thread.Sleep(500);
        Console.Write(new string("\\"));
        Console.SetCursorPosition(0, Console.CursorTop);                
        Thread.Sleep(500);            
    }

    public void EndMessage()
    {

    }

    public string GetName()
    {
        return _name;
    }

    public List<string> GetActivityDesc()
    {
        return _activityDesc;
    }
    
    public Activity(string name, List<string> activityDesc)
    {
        
    }
}