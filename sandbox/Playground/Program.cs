using System.IO;
class Program
{
    static void Main()
    {
        List<string> linesToWrite = new List<string>();
        linesToWrite = ["Header1,Header2,Header3", "Value1A,Value1B,Value1C", "Value2A,Value2B,Value2C"];
        string file = "playground.csv";
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            file.WriteAllLines(file, linesToWrite);
        }
    }
}