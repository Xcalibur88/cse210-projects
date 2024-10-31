public class Job(string company, string jobTitle, int startYear, int endYear) {
    public string Company { get; private set; } = company;
    public string JobTitle { get; private set; } = jobTitle;
    public int StartYear { get; private set; } = startYear;
    public int EndYear { get; private set; } = endYear;

    public void Display() {
        Console.WriteLine($"{this}");
    }

    public override string ToString() {
        return $"{JobTitle} ({Company}) {StartYear}-{EndYear}";
    }
}