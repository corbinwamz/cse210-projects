class Entry : Journal
{
    private string _entryNum;
    private string _entry;
    private string _dateTime;

    public Entry()
    {
        
    }
    public Entry(string entryNum, string entry, string dateTime, string filename) : base(filename) // constructor
    {
        _entryNum = entryNum;
        _entry = entry;
        _dateTime = dateTime;
    }

    public override string GetEntryNum() // getter
    {
        return _entryNum;
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