public class Resume(string name) {

    public string Name { get; private set; } = name;
    public List<Job> Jobs { get; } = [];

    public void Display() {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine("Jobs: ");
        Jobs.ForEach(job => job.Display());
    }
}