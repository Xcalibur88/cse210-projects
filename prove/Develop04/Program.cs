using Develop04.Activities;
using CommonUtils;

class Program {

    static void Main(string[] args) {
        Menu menu = new(true, ("Breathing activity", new BreathingActivity().Begin),
                              ("Reflection activity", new ReflectionActivity().Begin),
                              ("Listing activity", new ListingActivity().Begin),
                              ("Activity stats", ShowStatistics),
                              ("Exit", Exit));
        menu.Open();
    }

    static void ShowStatistics() {
        Dictionary<string, int> logs = Activity.GetLogs();
        if (logs.Count < 0) {
            Console.WriteLine("No logs to show.");
        } else {
            Console.WriteLine(Colors.Bright + "Type | Seconds" + Colors.Reset);
            foreach (KeyValuePair<string, int> entry in logs) {
                Console.WriteLine($"{entry.Key}: {entry.Value}s");
            }
        }
        Console.WriteLine();
        ConsoleUtils.PromptInput<string>("Press enter to continue...");
    }

    static void Exit() {
        Environment.Exit(0);
    }
}

/*
Exceeded Requirements:
 - Added statistic logging system
*/