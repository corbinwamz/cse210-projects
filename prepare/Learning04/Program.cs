using System;
using System.Reflection;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        string name = "Corbin Wamsley";
        string topic = "Computer Science";
        Assignment homework = new(name, topic);
        Console.WriteLine(homework.GetSummary());
        
        string textbookSection = "Section 7.3";
        string problems = "Problems 8-19";
        MathAssignment textbook = new(textbookSection, problems, name, topic);
        Console.Write(textbook.GetHomeworkList());
        
        string title = "Mr Bean";
        topic = "Comedy";
        WritingAssignment f = new(title, name, topic);
        Console.Write(f.GetWritingInformation());
    }
}