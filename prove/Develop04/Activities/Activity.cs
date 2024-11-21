namespace Develop04.Activities;
using System.Text.Json;
using Develop04.Animations;
using CommonUtils;


abstract class Activity(string name, string description) {
    private readonly string name = name;
    private readonly string description = description;
    private int duration;
    private DateTime start;
    
    protected bool IsOver() {
        return start.Ticks < DateTime.Now.Ticks - (duration * TimeSpan.TicksPerSecond);
    }

    protected void SetStart() {
        start = DateTime.Now;
    }

    public void Begin() {
        Console.WriteLine($"Welcome to the {name}.");
        Console.WriteLine(description);
        Console.WriteLine();

        duration = ConsoleUtils.PromptInput<int>("How long, in seconds, would you like your session? ", (i) => i > 0);

        Console.Clear();
        Console.WriteLine("Get Ready...");
        new LoadingAnimation().Play(3);

        StartActivity();
        Finish();
    }

    protected abstract void StartActivity();

    private void Finish() {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        new LoadingAnimation().Play(2);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {duration} seconds of the {name}.");
        new LoadingAnimation().Play(6);
        Log();
    }

    private void Log() {
        Dictionary<string, int> stats = GetLogs();
        if (!stats.TryAdd(name, duration)) {
            stats[name] += duration;
        }
        string jsonString = JsonSerializer.Serialize(stats, serializationOptions);
        File.WriteAllText(saveFile, jsonString);
    }


    private static readonly JsonSerializerOptions serializationOptions = new() { WriteIndented = true, IncludeFields = true };
    private static readonly string saveFile = "stats.json"; 
    public static Dictionary<string, int> GetLogs() {
        Dictionary<string, int> stats;
        if (!File.Exists(saveFile)) {
            stats = [];
        } else {
            string jsonString = File.ReadAllText("stats.json");
            stats = JsonSerializer.Deserialize<Dictionary<string, int>>(jsonString, serializationOptions);
        }
        return stats;
    }
}