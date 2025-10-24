using System;

class Program
{
    static void Main(string[] args)
    {
        List<Word> words = new();
        List<List<string>> listOfScriptures = [["This", "is", "my", "commandment,", "That,", "ye", "love", "one", "another,", "as", "I", "have",
        "loved", "you.", "Greater", "love", "hath", "no", "man", "than", "this,", "that", "a", "man", "lay", "down", "his", "life", "for", "his",
        "friends.", "Ye", "are", "my", "friends,", "if", "ye", "do", "whatsoever", "I", "command", "you."],

        ["O", "all", "ye", "that", "are", "spared", "because", "ye", "were", "more", "righteous", "than", "they,", "will", "ye", "not", "now",
         "return", "unto", "me,", "and", "repent", "of", "your", "sins,", "and", "be", "converted,", "that", "I", "may", "heal", "you?"],

        ["And", "he", "said", "unto", "me:", "Because", "of", "thy", "faith", "in", "Christ,", "whom", "thou", "hast", "never", "before","heard",
        "nor", "seen.", "And", "many", "years", "pass", "away", "before", "he", "shall", "manifest" ,"himself", "in", "the", "flesh;","wherefore,",
        "go", "to,", "thy", "faith","hath", "made", "thee", "whole."],

        ["And", "it", "came", "to", "pass", "that", "after", "they", "had", "spoken", "these", "words", "the", "Spirit", "of", "the", "Lord",
        "came", "upon", "them,", "and", "they", "were", "filled", "with", "joy,", "having", "received", "a", "remission", "of", "their",
        "sins,", "and", "having", "peace", "of", "conscience,", "because", "of", "the", "exceeding", "faith", "which", "they", "had", "in",
        "Jesus", "Christ", "who", "should", "come,", "according", "to", "the", "words", "which", "king", "Benjamin", "had", "spoken",
        "unto", "them."]];

        Scripture k = new(words);
        List<List<string>> references = [["John", "15", "14-15"], ["3 Nephi", "9", "13"], ["Enos", "1", "8"], ["Mosiah", "4", "3"]];

        int option = 1;
        foreach (List<string> q in references)
        {
            Console.WriteLine($"[{option}] {q[0]} {q[1]}:{q[2]}");
            option += 1;
        }
        Console.WriteLine("Which scripture would you like to memorize?");
        string book = "";
        string chapter = "";
        string verse = "";
        string choice = Console.ReadLine();
        if (choice == "1")
        {
            book = references[0][0];
            chapter = references[0][1];
            verse = references[0][2];
            foreach (string i in listOfScriptures[0])
            {
                Word word = new(i);
                words.Add(word);
            }
        }
        else if (choice == "2")
        {
            book = references[1][0];
            chapter = references[1][1];
            verse = references[1][2];
            foreach (string i in listOfScriptures[1])
            {
                Word word = new(i);
                words.Add(word);
            }
        }
        else if (choice == "3")
        {
            book = references[2][0];
            chapter = references[2][1];
            verse = references[2][2];
            foreach (string i in listOfScriptures[1])
            {
                Word word = new(i);
                words.Add(word);
            }
        }
        else
        {
            book = references[3][0];
            chapter = references[3][1];
            verse = references[3][2];
            foreach (string i in listOfScriptures[3])
            {
                Word word = new(i);
                words.Add(word);
            }
        }

        Reference scriptureRef = new(book, chapter, verse);

        Console.Clear();
        scriptureRef.Display();
        k.Menu(scriptureRef);
    }   
}