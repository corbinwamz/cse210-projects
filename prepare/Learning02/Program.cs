using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        Job job2 = new Job();
        Resume name = new Resume();
        job1._company = "Meta";
        job1._jobTitle = "CEO";
        job1._startYear = 2019;
        job1._endYear = 2025;

        job2._company = "Apple";
        job2._jobTitle = "Software Developer";
        job2._startYear = 2004;
        job2._endYear = 2017;

        name._name = "Corbin Wamsley";
        name._jobs.Add(job1);
        name._jobs.Add(job2);
        name.printResume();
    }
}