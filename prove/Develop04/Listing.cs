class Listing : Activity
{
    private List<string> _prompt;
    private List<string> _response;

    public Listing(List<string> prompt, string name, string activityDesc) : base(name, activityDesc)
    {
        _prompt = prompt;
        _response = [];
    }

    public List<string> GetPrompts()
    {
        return _prompt;
    }

    public List<string> GetResponse()
    {
        return _response;
    }

    public void SetResponse(List<string> response)
    {
        _response = response;
    }

    public string RandomPrompt()
    {
        List<string> prompts = this.GetPrompts();
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
        Console.WriteLine("\nList as many responses you can to the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.Write("You may begin in: 5");
        Counter(5);
        Console.Write("\n");

        DateTime startTime = DateTime.Now;
        double i = double.Parse(input);
        DateTime futureTime = startTime.AddSeconds(i);

        while (startTime < futureTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();

            List<string> responses = this.GetResponse();

            responses.Add(response);
            this.SetResponse(responses);
            startTime = DateTime.Now;
        }
        List<string> items = this.GetResponse();
        int number = items.Count();
        Console.WriteLine($"You listed {number} items!");
        List<string> Resetresponse = [];
        SetResponse(Resetresponse);

    }
}