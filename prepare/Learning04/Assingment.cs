namespace Learning04;

public class Assingment(string studentName, string topic) {

    protected string StudentName { get; private set;} = studentName;
    private readonly string topic = topic;

    public string GetSummary() {
        return $"{StudentName} - {topic}";
    }
}