namespace Learning04;

public class MathAssingment(string studentName, string topic, string textBookSection, string problems) : Assingment(studentName, topic) {

    private readonly string textBookSection = textBookSection;
    private readonly string problems = problems;

    public string GetHomeworkList() {
        return $"Section {textBookSection} Problems {problems}";
    }
}