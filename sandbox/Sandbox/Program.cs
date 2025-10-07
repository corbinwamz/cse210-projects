using System;

class Program
{
    static void Main(string[] args)
    {
        List<string> linesToWrite = new List<string>();
        // linesToWrite = ["Header1,Header2,Header3"];
        string file = "sandbox.csv";
        // using (StreamWriter outputFile = new StreamWriter(file))
        // {
        //     foreach (string i in linesToWrite)
        //     {
        //         string line = string.Join(",", i);
        //         outputFile.WriteLine(line);
        //     }
        // }
        linesToWrite = ["jan", "jay", "jimmer\n"];
        string line = string.Join(",", linesToWrite);
        File.AppendAllText(file, line);
        linesToWrite = ["6", "7", "8"];
        line = string.Join(",", linesToWrite);
        File.AppendAllText(file, line);
    }
}