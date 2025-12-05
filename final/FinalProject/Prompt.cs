class Prompt : Journal
{
    private string _prompt;
    private string _response;

    public Prompt()
    {
        
    }

    public Prompt(string prompt, string filename) : base(filename)
    {
        _prompt = prompt;
        _response = "";
    }

    public Prompt(string prompt, string response, string filename) : base(filename)
    {
        _prompt = prompt;
        _response = response;
    }

    public override string GetPrompt() // getter
    {
        return _prompt;
    }
    public override string GetResponse() // getter
    {
        return _response;
    }

    public void ChangePrompt()
    {
        
    }

    public void NoPrompt()
    {
        
    }

    public void YesPrompt()
    {
        
    }

    public override void Display()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");
    }

    public string GetRandomPrompt()
    {
        List<string> prompts = [
            "What am I grateful for today", "What three small wins did I have this week", "What emotion is strongest right now and why", 
            "What fear would I like to understand better", "What habit do I want to build and why", "What habit do I want to break and how", 
            "Describe my ideal day from morning to night", "What lesson did I learn from a recent mistake", 
            "Who in my life deserves more appreciation", "What boundary do I need to set and how", "What does success mean to me this year", 
            "What memory makes me smile and why", "What is one thing I can do today to be kinder to myself", 
            "What project excites me most right now", "What limiting belief is holding me back", 
            "How do I recharge when I'm depleted", "What would I tell my younger self", 
            "What am I avoiding and what's one small step to face it", "What does my perfect morning routine include", 
            "What skill do I want to learn and why", "When did I feel most proud recently", "What relationship needs honest conversation", 
            "What does forgiveness look like for me", "What are three things I value most", "What would I do if I knew I could not fail", 
            "How do I want to be remembered", "What's a boundary I admire in others and can adopt", "What small pleasure can I savor today", 
            "What is one financial goal I can start working toward today"
        ];

        Random random = new();
        int num = random.Next(0,28);
        string prompt = prompts[num];
        return prompt;
    }
}