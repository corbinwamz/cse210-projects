class WritingAssignment : Assignment
{
    private string _title;

    public WritingAssignment(string title, string studentName, string topic) : base(studentName, topic)
    {
        _title = title;
    }

    public string GetWritingInformation()
    {
        string name = GetStudentName();
        string topic = GetTopic();
        return "\n" + _title + " by " + name + "\n" + topic;
    }
}