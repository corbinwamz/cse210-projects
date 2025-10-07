using System.Security.Cryptography.X509Certificates;

class Journal
{
    public List<Entry> writeEntries = new();

    static List<string> Write(List<string> writeEntries)
    {
        List<string> promptBank = [
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        ];

        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 5);
        string prompt = promptBank[number];
        Console.Write($"{prompt}: ");
        string response = Console.ReadLine();
        Entry entry = new();
        entry._dateTime = DateTime.Now.ToString("yyyy-MM-dd");
        entry._prompt = prompt;
        entry._entries = response;
        writeEntries.Add($"{entry._dateTime},{entry._prompt},{entry._entries}\n");
        return writeEntries;
    }

    void Load()
    {
        Console.Write("What is your file name? ");
        string file = Console.ReadLine();
        foreach (string line in File.ReadLines(file))
        {
            string[] entryInfo = line.Split(",");
            Console.WriteLine($"Date: {entryInfo[0]} - Prompt: {entryInfo[1]}\n{entryInfo[2]}");
        }

    }

    void Save(List<string> writeEntries)
    {
        Console.Write("What is the file name: ");
        string file = Console.ReadLine();
        // Date,Prompt,Entry
        foreach (string line in writeEntries)
        {
            File.AppendAllText(file, line);
        }
    }

    void Display(List<string> writeEntries)
    {
        Console.WriteLine("Please select one of the following choices:");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Quit");
        Console.Write("What would you like to do? ");
        string action = Console.ReadLine();
        if (action == "1")
        {
            Write(writeEntries);
        }
        else if (action == "2")
        {
            Display(writeEntries);
        }
        else if (action == "3")
        {
            Load();
        }
        else if (action == "4")
        {
            Save(writeEntries);
        }
        else if (action == "5")
        {
            Quit();
        }
    }

    void Quit()
    {

    }
}