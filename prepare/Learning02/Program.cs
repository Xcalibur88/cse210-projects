using System;

class Program {
    static void Main(string[] args) {
        Resume resume = new Resume("Bilbo Baggins");
        Job job1 = new Job("Microsoft", "Software Engineer", 2019, 2022);
        Job job2 = new Job("Apple", "Manager", 2022, 2023);

        resume.Jobs.Add(job1);
        resume.Jobs.Add(job2);

        resume.Display();
    }
}