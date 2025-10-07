using System.Security.Cryptography.X509Certificates;

public class Journal
{
    //public List<Entry> writeEntries = new();

    static List<string> Write(List<string> writeEntries)
    {
        List<string> promptBank = [
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What thoughts kept recurring throughout the day?",
            "What did I learn today?",
            "What did I accomplish today, big or small?",
            "Did I express myself clearly and kindly?",
            "Is there someone I want to reach out to tomorrow?",
            "What’s one thing I’m proud of from today?"
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
        writeEntries.Add($"{entry._dateTime}|{entry._prompt}|{entry._entries}\n");
        return writeEntries;
    }

    static string Load()
    {
        Console.Write("What is your file name? ");
        string file = Console.ReadLine();
        return file;
    }

    static List<string> Save(List<string> writeEntries)
    {
        if (writeEntries.Count == 0)
        {
            Console.WriteLine("You need to write something to save first...");
        }
        else
        {
            Console.Write("What is the file name: ");
            string file = Console.ReadLine();
            // Date,Prompt,Entry
            foreach (string line in writeEntries)
            {
                File.AppendAllText(file, line);
            }
            writeEntries = [];
        }
        return writeEntries;
    }

    public void DisplayMenu()
    {
        List<string> writeEntries = [];
        string action = "";
        string file = "";
        while (action != "5")
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            action = Console.ReadLine();
            if (action == "1")
            {
                writeEntries = Write(writeEntries);
            }
            else if (action == "2")
            {
                file = Display(writeEntries, file);
            }
            else if (action == "3")
            {
                file = Load();
            }
            else if (action == "4")
            {
                writeEntries = Save(writeEntries);
            }
        }
    }

    static string Display(List<string> writeEntries, string file)
    {
        if (writeEntries.Count > 0)
        {
            foreach (string line in writeEntries)
            {
                string[] entryInfo = line.Split("|");
                Console.WriteLine($"Date: {entryInfo[0]} - Prompt: {entryInfo[1]}\n{entryInfo[2]}");
            }
        }
        else if (file == "")
        {
            Console.WriteLine("You need to load a file or write something first...");
        }
        else
        {
            foreach (string line in File.ReadLines(file))
            {
                string[] entryInfo = line.Split("|");
                Console.WriteLine($"Date: {entryInfo[0]} - Prompt: {entryInfo[1]}\n{entryInfo[2]}");
            }
        }
        file = "";
        return file;
    }
}