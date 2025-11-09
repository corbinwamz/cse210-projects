class Breath : Activity
{
    private int _durationIn;
    private int _durationOut;

    public Breath(int durationIn, int durationOut, string name, string activityDesc) : base(name, activityDesc)
    {
        _durationIn = durationIn;
        _durationOut = durationOut;
    }

    public void Display(string input)
    {
        Console.WriteLine("Get ready...");
        Spinner();
        Console.Write("\b \b");
        Console.Write(" ");

        DateTime startTime = DateTime.Now;
        double i = double.Parse(input);
        DateTime futureTime = startTime.AddSeconds(i);

        while (startTime < futureTime)
        {
            List<int> numbers = RandomGen();
            string name = this.GetName();
            string activityDesc = this.GetActivityDesc();
            Breath duration = new(numbers[0], numbers[1], name, activityDesc);
            int durationIn = duration.GetDurationIn();
            int durationOut = duration.GetDurationOut();

            Console.Write($"\n\nBreathe in...{durationIn}");
            Counter(durationIn);
            Console.Write($"\nNow breathe out...{durationOut}");
            Counter(durationOut);
            startTime = DateTime.Now;
        }
    }

    public List<int> RandomGen()
    {
        Random random = new();
        int number = random.Next(4, 7);
        Random random2 = new();
        int number2 = random2.Next(2, 5);
        List<int> numbers = [number, number2];
        return numbers;
    }

    public int GetDurationIn()
    {
        return _durationIn;
    }

    public int GetDurationOut()
    {
        return _durationOut;
    }
}