namespace Learning04;

public class WritingAssingment(string studentName, string topic, string title) : Assingment(studentName, topic) {

    private readonly string title = title;

    public string GetWritingInformation() {
        return $"{title} by {StudentName}";
    }

}