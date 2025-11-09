// using System;
// using CsvHelper;
// using System.Globalization;
// using System.ComponentModel;

// class Program
// {
//     static void Main(string[] args)
//     {
//         List<string> linesToWrite = new List<string>();
//         // linesToWrite = ["Header1,Header2,Header3"];
//         string file = "sandbox.csv";
//         // using (StreamWriter outputFile = new StreamWriter(file))
//         // {
//         //     foreach (string i in linesToWrite)
//         //     {
//         //         string line = string.Join(",", i);
//         //         outputFile.WriteLine(line);
//         //     }
//         // }
//         // linesToWrite = ["jan", "jay", "jimmer\n"];
//         // string line = string.Join(",", linesToWrite);
//         // File.AppendAllText(file, line);
//         // linesToWrite = ["6", "7", "8"];
//         // line = string.Join(",", linesToWrite);
//         // File.AppendAllText(file, line);
//         //     var records = new List<Foo>
//         // {
//         //     new Foo { Id = "1,", Name = "one" },
//         // };

//         //     // Write to a file.
//         //     using (var writer = new StreamWriter("C:\\Users\\corbi\\OneDrive\\Documents\\Semester 3\\cse210\\cse210-projects\\sandbox\\Sandbox\\sandbox.csv"))
//         //     using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
//         //     {
//         //         csv.WriteRecords(records);
//         //     }
//         //     using (var reader = new StreamReader($"..\\Sandbox\\{file}"))
//         //     using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
//         //     {
//         //         var infor = csv.GetRecords<Foo>().ToList();

//         //         foreach (Foo line in infor)
//         //         {
//         //             Console.WriteLine($"{line.Id}");
//         //             Console.WriteLine($"{line.Name}");
//         //     }
//         // }
//         string line = ""Hello, my brother"";
//         File.AppendAllText(file, line);
//     }
// }

// // public class Foo
// // {
// //     public string Id { get; set; }
// //     public string Name { get; set; }
// // }

// Console.Write(new string("|"));
// Console.SetCursorPosition(0, Console.CursorTop);
// Thread.Sleep(250);
// Console.Write(new string("/"));
// Console.SetCursorPosition(0, Console.CursorTop);                
// Thread.Sleep(250);
// Console.Write(new string("-"));
// Console.SetCursorPosition(0, Console.CursorTop);                
// Thread.Sleep(250);
// Console.Write(new string("\\"));
// Console.SetCursorPosition(0, Console.CursorTop);                
// Thread.Sleep(250);
// Console.Write(new string("|"));
// Console.SetCursorPosition(0, Console.CursorTop);
// Console.Write("3");
// Thread.Sleep(1000);
// Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
// Console.Write("2");
string path = "example.txt";
string content = "Hello, world!";

if (!File.Exists(path))
{
    File.WriteAllText(path, content);
}
else
{
    Console.WriteLine("File already exists. Not overwriting.");
}
