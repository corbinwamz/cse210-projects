using System.Collections.Concurrent;

class Reference
{
    private string _bookName;
    private string _chapter;
    private string _verse;
    private string _toVerse;

    public void Display()
    {
        string bookname = GetBook();
        string chapter = GetChapter();
        string verse = GetVerse();
        string toVerse = GetToVerse();
        if (toVerse != "")
        {
            Console.Write($"{bookname} {chapter}:{verse}-{toVerse} - ");
        }
        else
        {
            Console.Write($"{bookname} {chapter}:{verse} - ");
        }
    }   

    public Reference(string book, string chapter, string verse) // constructor
    {
        if (verse.Contains("-"))
        {
            string[] verses = verse.Split("-");
            _verse = verses[0];
            _toVerse = verses[1];
        }
        _bookName = book;
        _chapter = chapter;
        _verse = verse;
        _toVerse = "";
    }

    public string GetBook() // getter
    {
        return _bookName;
    }

    public string GetChapter() // getter
    {
        return _chapter;
    }
    
    public string GetVerse() // getter
    {
        return _verse;
    }
    public string GetToVerse() // getter
    {
        return _toVerse;
    }
}