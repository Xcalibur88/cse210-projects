using CommonUtils;
using Develop05.Goals;
using System.Text.Json;

class Program {
    public static readonly JsonSerializerOptions serializationOptions = new() { WriteIndented = true, IncludeFields = true, Converters = { new GoalConverter() } };
    static readonly string saveFile = "goals.json";
    static List<Goal> goals = [];
    public static int points;

    static void Main(string[] args) {
        Load();
        Menu menu = new(true, ("Create New Goal", GoalCreationMenu),
                            ("List Goals", ListGoals),
                            ("Record Event", RecordEvent),
                            ("Exit", Exit));
        menu.Open();
    }

    static void GoalCreationMenu() {
        static void CreateGoal(Type goalType) {
            goals.Add(Goal.CreateGoal(goalType));
            Save();
        }
        Menu goalOptions = new ("The types of goals are:", "Which type of goal would you like to create?", false,
                             ("Simple Goal", () => CreateGoal(typeof(SimpleGoal))),
                             ("Eternal Goal", () => CreateGoal(typeof(EternalGoal))),
                             ("Checklist Goal", () => CreateGoal(typeof(ChecklistGoal))));
        goalOptions.Open(false);

    }

    static void ListGoals() {
        Console.WriteLine("Goals:");
        if (goals.Count <= 0) {
            Console.WriteLine("You have not made any goals yet!");
        } else {
            foreach (Goal goal in goals) {
                Console.WriteLine($" {goal.GetRendered()}");
            }
        }
        Console.WriteLine();
        ConsoleUtils.PromptInput<string>("Press enter to continue...");
    }

    static void RecordEvent() {
        (string, Action)[] goalArray = goals.Select<Goal,(string, Action)>(goal => (goal.Name, goal.Record)).ToArray();
        int previousPoints = points;
        Menu goalMenu = new("Your goals are:", "Which goal did you accomplish?", false, goalArray);
        goalMenu.Open(false);
        Save();

        Console.WriteLine($"Congradulations! You have earned {points - previousPoints} points!");
        Console.WriteLine($"You now have {points} points.");
        Console.WriteLine();
        ConsoleUtils.PromptInput<string>("Press enter to continue...");
    }

    static void Load() {
        if (!File.Exists(saveFile)) {
            Save();
        }
        string jsonString = File.ReadAllText(saveFile);
        var data = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonString, serializationOptions);
        goals = JsonSerializer.Deserialize<List<Goal>>(data["Goals"].ToString(), serializationOptions);
        points = Convert.ToInt32(data["TotalPoints"].ToString());
    }

    static void Save() {
        var data = new Dictionary<string, object> {
                { "Goals", goals },
                { "TotalPoints", points }
        };
        string jsonString = JsonSerializer.Serialize(data, serializationOptions);
        File.WriteAllText(saveFile, jsonString);
    }

    static void Exit() {
        Environment.Exit(0);
    }
}