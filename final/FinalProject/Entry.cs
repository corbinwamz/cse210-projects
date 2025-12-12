class Entry : Journal
{
    private string _entry;
    private  string _dateTime;

    public Entry()
    {   
    }
    public Entry(string entry, string dateTime, string filename) : base(filename) // constructor
    {
        _entry = entry;
        _dateTime = dateTime;
    }

    public override string GetEntry() // getter
    {
        return _entry;
    }
    public override string GetDateTime() // getter
    {
        return _dateTime;
    }

    public override void Display()
    {
        
    }
}