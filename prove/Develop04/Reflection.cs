using System.ComponentModel.DataAnnotations;

class Reflection : Activity
{
    private List<string> _prompts;
    private List<string> _promptReflections;

    public Reflection(List<string> prompts, List<string> promptReflections, string name, string activityDesc) : base(name, activityDesc)
    {
        _prompts = prompts;
        _promptReflections = promptReflections;
    }

    public string RandomPrompt()
    {
        List<string> prompts = this.GetPrompts();
        Random i = new();
        int number = i.Next(0, prompts.Count() - 1);
        string prompt = prompts[number];
        return prompt;
    }

    public string RandomPromptReflection()
    {
        List<string> prompts = this.GetPromptReflection();
        Random i = new();
        int number = i.Next(0, prompts.Count() - 1);
        string prompt = prompts[number];
        return prompt;
    }

    public void Display(string input)
    {
        string prompt = this.RandomPrompt();
        Console.WriteLine("Get ready...");
        Spinner();
        Console.Write("\b \b");
        Console.Write(" ");

        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine($"\n--- {prompt} ---");
        Console.Write("\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("\nNow ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: 5");
        Counter(5);
        Console.Clear();

        DateTime startTime = DateTime.Now;
        double i = double.Parse(input);
        DateTime futureTime = startTime.AddSeconds(i);

        while (startTime < futureTime)
        {
            string promptReflection = this.RandomPromptReflection();
            Console.Write($"\n{promptReflection} ");
            Spinner();
            Spinner();
            Spinner();
            startTime = DateTime.Now;
        }
    }

    public List<string> GetPrompts()
    {
        return _prompts;
    }

    public List<string> GetPromptReflection()
    {
        return _promptReflections;
    }
}