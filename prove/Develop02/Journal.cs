using System.Security.Cryptography.X509Certificates;
using System.IO;
using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration;

public class Journal
{
    //public List<Entry> writeEntries = new();

    static List<List<string>> Write(List<List<string>> writeEntries)
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
        int number = randomGenerator.Next(0, 10);
        string prompt = promptBank[number];
        Console.Write($"{prompt}:\n> ");
        string response = Console.ReadLine();
        Entry entry = new();
        entry._dateTime = DateTime.Now.ToString("yyyy-MM-dd");
        entry._prompt = prompt;
        entry._entries = response;
        writeEntries.Add(new List<string> {$"{entry._dateTime}",$"{entry._prompt}",$"{entry._entries}"});
        return writeEntries;
    }

    static string Load()
    {
        Console.Write("What is your file name?\n> ");
        string file = Console.ReadLine();
        while (!File.Exists($"{file}"))
        {
            Console.Write("File does not exist...\n");
        }
        return file;
    }

    static List<List<string>> Save(List<List<string>> writeEntries)
    {
        List<Entry> records = new();
        if (writeEntries.Count == 0)
        {
            Console.WriteLine("You need to write something to save first...\n");
        }
        else
        {
            Console.Write("What is the file name: \n> ");
            string file = Console.ReadLine();
            // Date,Prompt,Entry
            if (!File.Exists($"{file}"))
            {
                File.AppendAllText(file, "_dateTime,_prompt,_entries\n");
            }
                CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = false,
                };
                foreach (List<string> line in writeEntries)
                {
                records.Add(new Entry { _dateTime = $"{line[0]}", _prompt = $"{line[1]}", _entries = $"{line[2]}" });
                }
                using (FileStream stream = File.Open($"{file}", FileMode.Append))
                using (StreamWriter writer = new StreamWriter(stream))
                using (CsvWriter csv = new CsvWriter(writer, config))
                {
                    csv.WriteRecords(records);
                }
            writeEntries = [];
        }
        return writeEntries;
    }

    public void DisplayMenu()
    {
        List<List<string>> writeEntries = [];
        string action = "";
        string file = "";
        while (action != "5")
        {
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.WriteLine("-----------------------------------------------");
            Console.Write("What would you like to do?\n> ");
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
            else if (action == "5" & writeEntries.Count >=1)
            {
                Console.Write("Warning: There are unsaved entries. Are you sure you want to quit? y/n\n> ");
                string answer = Console.ReadLine();
                if (answer == "y")
                {
                    action = "5";
                }
                else
                {
                    action = "";
                }
            }
        }
    }

    static string Display(List<List<string>> writeEntries, string file)
    {
        if (writeEntries.Count > 0)
        {
            foreach (List<string> line in writeEntries)
            {
                Console.WriteLine($"Date: {line[0]} - Prompt: {line[1]}\n{line[2]}");
                Console.WriteLine("-------------------------------------------------------------------\n");

            }
        }
        else if (file == "")
        {
            Console.WriteLine("You need to load a file or write something first...\n");
        }
        else
        {
            using (StreamReader reader = new StreamReader($"..\\Develop02\\{file}"))
            using (CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                List<Entry> info = csv.GetRecords<Entry>().ToList();

                foreach (Entry line in info)
                {
                    Console.WriteLine($"Date: {line._dateTime} - Prompt: {line._prompt}\n{line._entries}");
                    Console.WriteLine("-------------------------------------------------------------------\n");
                }
            }
        }
        file = "";
        return file;
    }
}