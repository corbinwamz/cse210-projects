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
        _entries = [];
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
        Journal newJournal = null;
        string filename = "";
        string input = "3";
        while (input != "1" & input != "2")
        {
            Console.Write("Would you like to load an existing journal (1) or create a new one (2)? ");
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
                Console.Write("\nWhat is the file name for your journal? ");
                filename = Console.ReadLine();
                if (File.Exists(filename))
                {  
                    newJournal = new(filename);
                    newJournal.LoadJournal(filename);
                    Console.WriteLine("\nJournal loaded!");
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
            Console.Write("\nWhat would you like to name the file for your journal? ");
            filename = Console.ReadLine();
            newJournal = new(filename);
            Console.WriteLine("\nJournal created!\n");
            Thread.Sleep(1000);
        }

        input = "1";
        while (input == "1" || input == "2" || input == "3")
        {
            Console.Clear();
            Console.Write(
                    $"\n[{filename}]\n\n"+
                    "   1. New entry\n"+
                    "   2. Delete entry\n"+
                    "   3. View entries\n"+
                    "   4. Save and quit\n"+
                    "\nWhat action would you like to do? "
                );
            input = Console.ReadLine();
            if (input == "1")
            {
                newJournal.NewEntry(filename);
            }
            else if (input == "2")
            {
                newJournal.DeleteEntry();
            }
            else if (input == "3")
            {
                newJournal.ViewJournal();
            }
            else if (input == "4")
            {
                newJournal.Save(filename);
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

    // entry|dateTime|prompt|response
    public void LoadJournal(string filename)
    {
        string[] linesArray = File.ReadAllLines(filename);
        List<string> lines = linesArray.ToList();

        foreach (string line in lines)
        {
            string[] items = line.Split("|");
            string entry = items[0].Trim();
            string dateTime = items[1].Trim();
            string prompt = items[2].Trim();
            string response = items[3].Trim();

            Journal newentry = new Entry(entry, dateTime, filename);
            Journal newPrompt = new Prompt(prompt, response, filename);
            List<List<Journal>> entries = GetEntries();
            entries.Add([newentry,newPrompt]);
        }
    }

    public void Save(string filename)
    {
        List<List<Journal>> entries = GetEntries();
        using (StreamWriter outputFile = new StreamWriter(filename))
        { 
            foreach (List<Journal> items in entries)
            {   
                string entry = items[0].GetEntry();
                string dateTime = items[0].GetDateTime();
                string prompt = items[1].GetPrompt();
                string response = items[1].GetResponse();
                outputFile.WriteLine($"{entry}|{dateTime}|{prompt}|{response}");
            }
        }
    }

    public void NewEntry(string filename)
    {
        string input = "";
        Console.Write("What do you want to title your entry? ");
        string title = Console.ReadLine();
        while (input != "yes" & input != "no")
        {          
            Console.Write("Would you like a prompt to write to (yes/no)? ");
            input = Console.ReadLine();
            if (input != "yes" & input != "no")
            {
                Console.WriteLine("Please type 'yes' or 'no' only");
            }
        }
        Console.Clear();
        string line = " ";
        DateTime dateTime = DateTime.Now;
        if (input == "yes")
        {  
            string change = "change";
            while (change == "change")
            {
                Prompt prompt = new();
                line = prompt.GetRandomPrompt();
                Console.WriteLine(line); 
                Console.Write("Change or keep prompt (change/keep)? ");
                change = Console.ReadLine();
            
                if (change == "change")
                {
                    Console.Clear();
                }
                else if (change != "change" & change != "keep")
                {
                    Console.WriteLine("Please type 'change' or 'keep' only");
                    change = "change";
                }
            }
            Console.Clear();
            dateTime = DateTime.Now;
            Console.WriteLine("Type enter when done");
            Console.WriteLine(title);
            Console.WriteLine($"\n\nDate: {dateTime}\n\n");
            Console.WriteLine($"Prompt: {line}\n");
            Console.WriteLine("Entry:");
        }
        else
        {
            line = " ";
            Console.Clear();
            dateTime = DateTime.Now;
            Console.WriteLine(title);
            Console.WriteLine($"\n\nDate: {dateTime}\n\n");
            Console.WriteLine("Entry:");
        }

        string response = Console.ReadLine();
        string date = dateTime.ToString();
        Journal entry = new Entry(title, date, filename);
        Journal journalPrompt = new Prompt(line, response, filename);
        List<List<Journal>> entries = this.GetEntries();
        entries.Add([entry,journalPrompt]);
    }

    public void DeleteEntry()
    {
        List<List<Journal>> entries = this.GetEntries();
        int num = entries.Count();
        if (num > 0)
        {          
            int index = 1;

            foreach (List<Journal> entry in entries)
            {
                string title = entry[0].GetEntry();
                Console.WriteLine($"{index}: {title}");
                index += 1;
            }
            Console.Write("Which entry do you want to delete? ");
            string delete = Console.ReadLine();
            int i = int.Parse(delete);
            List<Journal> items = entries[i-=1];
            Console.WriteLine($"Entry {items[0].GetEntry()} sucessfully deleted");
            entries.RemoveAt(i);
            Thread.Sleep(1000);
        }
        else
        {
            Console.WriteLine("There are no entries yet to delete");
        }
    }

    public void ViewJournal()
    {
        List<List<Journal>> entries = this.GetEntries();
        int num = entries.Count();
        if (num > 0)
        { 
            int index = 1;
            foreach (List<Journal> entry in entries)
            {
                string title = entry[0].GetEntry();
                Console.WriteLine($"{index}: {title}");
                index += 1;
            }
            Console.Write("Which entry would you like to view? ");
            string input = Console.ReadLine();
            int i = int.Parse(input);
            List<Journal> items = entries[i-=1];
            Console.Clear();
            Console.WriteLine(items[0].GetEntry());
            Console.WriteLine($"\n\nDate: {items[0].GetDateTime()}\n\n");
            if (items[1].GetPrompt() == " ")
            {            
                Console.WriteLine($"Entry:\n{items[1].GetResponse()}");
            }
        else
        {
            Console.WriteLine($"Prompt: {items[1].GetPrompt()}\n");
            Console.WriteLine($"Entry:\n{items[1].GetResponse()}");
        }
        Console.Write("\nType enter when done: ");
        Console.ReadLine();
        }
        else
        {
            Console.WriteLine("There are no entries");
            Thread.Sleep(1000);
        }
    }
}