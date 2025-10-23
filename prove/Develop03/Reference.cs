using System.Collections.Concurrent;

class Reference
{
    private string _bookName;
    private string _chapter;
    private string _verse;

    public void Display()
    {
        string bookname = GetBook();
        string chapter = GetChapter();
        string verse = GetVerse();
        Console.Write($"{bookname} {chapter}: {verse} - ");
    }

    public Reference(string book, string chapter, string verse) // constructor
    {
        _bookName = book;
        _chapter = chapter;
        _verse = verse;
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
}