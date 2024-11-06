using CommonUtils;
using Develop02;

class Program {

    static Journal Journal = new();
    static void Main(string[] args) {
        MainMenu();
    }

    static void MainMenu() {
        Console.WriteLine("Please select one of the following options");

        Dictionary<string, Action> options = new(){{"1. Write", Write}, {"2. Display", Display}, {"3. Load", Load}, {"4. Save", Save}, {"5. Exit", Exit}};
        foreach (KeyValuePair<string, Action> pair in options) {
            Console.WriteLine(pair.Key);
        }

        int index = ConsoleUtils.PromptInput<int>("What would you like to do? ", (i) => i > 0 && i <= options.Count(), "Out of bound option index! Please try again.");
        Action selection = options.ElementAt(index - 1).Value;

        Console.WriteLine();
        selection();
        Console.WriteLine();

        MainMenu();
    }

    static void Write() {
        List<string> prompts = [
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What made me smile today?",
            "What am I looking forward to this week?",
            "What’s something I’m grateful for right now?",
            "What’s one small win I had today?",
            "How am I feeling, and why?",
            "What's one thing I love about myself?",
            "Who or what inspires me lately?",
            "What’s something new I’ve learned recently?",
            "What's something I want to let go of?",
            "What would I say to my past self?"
        ];

        string prompt = prompts.ElementAt(new Random().Next(prompts.Count));
        string response = ConsoleUtils.PromptInput<string>($"{prompt}\n");
        
        Entry entry = new(response, prompt);
        Journal.Add(entry);
    }

    static void Display() {
        foreach (Entry entry in Journal.Entries) {
            entry.Display();
            Console.WriteLine("");
        }
    }

    static void Load() {
        string fileName = ConsoleUtils.PromptInput<string>("What is the filename?: ", File.Exists, "File does not exist!");
        Journal = Journal.Load(fileName);
    }

    static void Save() {
        string fileName = ConsoleUtils.PromptInput<string>("What is the filename?: ", (i) => i.EndsWith(".txt"), "File needs to be .txt!");
        
        if (!File.Exists(fileName)) {
            using FileStream fs = File.Create(fileName);
        }

        Journal.Save(fileName);
    }

    static void Exit() {
        Environment.Exit(0);
    }
}


/*
Exceeded Requirements:
 - Uses JSON for storage instead of csv
 - Even more journal prompts
*/