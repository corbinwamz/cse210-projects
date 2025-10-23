using System;

class Program
{
    static void Main(string[] args)
    {
        // Word word1 = new Word("Jesus");
        // Word word2 = new Word("wept.");
        // word1.Display();
        // word2.Display();
        // word1.SetHidden();
        // word1.Display();
        // word2.Display();
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
        Reference scripture = new(book, chapter, verse);

        scripture.Display();
        k.Menu();
    }   
}