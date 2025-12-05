class Journal
{
    private string _filename;
    private List<List<Journal>> _entries;

    public Journal()
    {
        
    }

    public Journal(string filename) // constructor
    {
        _filename = filename;
    }

    public Journal(string filename, List<List<Journal>> entries) // constructor
    {
        _filename = filename;
        _entries = entries;
    }

    public string GetFilename() // getter
    {
        return _filename;
    }

    public List<List<Journal>> GetEntries() // getter
    {
        return _entries;
    }

    public virtual string GetEntryNum() // getter
    {
        return "";
    }

    public virtual string GetEntry() // getter
    {
        return "";
    }
    public virtual string GetDateTime() // getter
    {
        return "";
    }

    public virtual string GetPrompt() // getter
    {
        return "";
    }
    public virtual string GetResponse() // getter
    {
        return "";
    }

    public void SetFilename(string filename) // setter
    {
        _filename = filename;
    }

    public virtual void Display()
    {
        Console.Write("\n\nWould you like to load an existing journal (1) or create a new one (2)? ");
        string input = Console.ReadLine();
        if (input == "1")
        {
            bool found = false;
            while (found == false)
            {               
                Console.WriteLine("\nWhat is the file name for your journal? ");
                string filename = Console.ReadLine();
                if (File.Exists(filename))
                {  
                    Journal newJournal = new(filename);
                    newJournal.LoadJournal(filename);
                    Console.WriteLine("\nJournal loaded!");
                    found = true;
                }
                else
                {
                    Console.WriteLine("\nFile not found. Check your spelling and try again");
                }
            }
            Console.Write(
                "\n   1. New entry\n"+
                "   2. Delete entry\n"+
                "   3. View entries\n"+
                "What action would you like to do? "
            );
            input = Console.ReadLine();
        }
        else if (input == "2")
        {
            Console.WriteLine("\nWhat would you like to name the file for your journal? ");
            string filename = Console.ReadLine();
        }

    }

    // entryNumber|entry|dateTime|prompt|response
    public void LoadJournal(string filename)
    {
        string[] linesArray = File.ReadAllLines(filename);
        List<string> lines = linesArray.ToList();

        foreach (string line in lines)
        {
            string[] items = line.Split("|");
            string entryNumber = items[0].Trim();
            string entry = items[1].Trim();
            string dateTime = items[2].Trim();
            string prompt = items[3].Trim();
            string response = items[4].Trim();

            Journal newentry = new Entry(entryNumber, entry, dateTime, filename);
            Journal newPrompt = new Prompt(prompt, response, filename);
            List<List<Journal>> entries = GetEntries();
            entries.Add([newentry,newPrompt]);
        }
    }

    public void Save(string filename, List<List<Journal>> entries)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
            { 
                foreach (List<Journal> items in entries)
                {   
                    string entryNumber = items[0].GetEntryNum();
                    string entry = items[0].GetEntry();
                    string dateTime = items[0].GetDateTime();
                    string prompt = items[1].GetPrompt();
                    string response = items[1].GetResponse();
                    outputFile.WriteLine($"{entryNumber}|{entry}|{dateTime}|{prompt}|{response}");
                }
            }
    }

    public void NewEntry(Journal entry)
    {
        string input = "";
        while (input != "yes" || input != "no")
        {          
            Console.Write("Would you like a prompt to write to (yes/no)? ");
            input = Console.ReadLine();
            if (input != "yes" || input != "no")
            {
                Console.WriteLine("Please type 'yes' or 'no' only");
            }
        }
        Console.Clear();
        Console.WriteLine($"\n\nDate: {DateTime.Now}\n\n");
        if (input == "yes")
        {  
            string change = "change";
            while (change == "change")
            {
                Prompt prompt = new();
                prompt.Display(); 
                Console.Write("Change or keep prompt (change/keep)? ");
                change = Console.ReadLine();
            
                if (change == "change")
                {
                    Console.Clear();
                    Console.WriteLine($"Date: {DateTime.Now}\n\n");
                    prompt.Display();
                }
                else if (change != "change" || change != "keep")
                {
                    Console.WriteLine("Please type 'change' or 'keep' only");
                    change = "change";
                }
            }

            Console.WriteLine("Entry:");
        }
        else
        {
            Console.WriteLine("Entry:");
        }

        string response = Console.ReadLine(); 
    }

    public void DeleteEntry()
    {
        
    }
}