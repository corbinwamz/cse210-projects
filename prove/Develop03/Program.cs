using System;

class Program
{
    static void Main(string[] args)
    {
        List<Word> words = new();
        List<string> listOfWords = ["This", "is", "my", "commandment,", "That,", "ye", "love", "one", "another,", "as", "I", "have", "loved", "you.", "Greater", "love", "hath", "no", "man", "than", "this,", "that", "a", "man", "lay", "down", "his", "life", "for", "his", "friends.",
        "Ye", "are", "my", "friends,", "if", "ye", "do", "whatsoever", "I", "command", "you."];
        foreach (string i in listOfWords)
        {
            Word word = new(i);
            words.Add(word);
        }
        Scripture k = new(words);

        string book = "John";
        string chapter = "15";
        string verse = "14-15";
        Reference scriptureRef = new(book, chapter, verse);

        Console.Clear();
        scriptureRef.Display();
        k.Menu(scriptureRef);
    }   
}