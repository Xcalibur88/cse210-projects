namespace Develop05.Goals;

using System.Text.Json.Serialization;
using CommonUtils;

[JsonConverter(typeof(GoalConverter))]
abstract class Goal(string name, string description, int pointValue) {
    [JsonInclude]
    public string Name {get; private set;} = name;
    [JsonInclude]
    public string Description {get; private set;} = description;
    [JsonInclude]
    protected readonly int pointValue = pointValue;

    public abstract void Record();

    public abstract bool IsCompleted();

    public virtual string GetRendered() {
        return $"{(IsCompleted() ? "[x]" : "[ ]")} {Name} ({Description})";
    }

    protected void AddPoints() {
        AddPoints(pointValue);
    }

    protected void AddPoints(int pointValue) {
        Program.points += pointValue;
    }

    protected void RemovePoints(int pointValue) {
        Program.points -= pointValue;
    }

    public static Goal CreateGoal(Type goalType) {
        if (!typeof(Goal).IsAssignableFrom(goalType))
            throw new InvalidOperationException($"The type {goalType.Name} is not a valid Goal type.");

        string name = ConsoleUtils.PromptInput<string>("What is the name of your goal? ");
        string description = ConsoleUtils.PromptInput<string>("What is a short description of it? ");
        int pointValue = ConsoleUtils.PromptInput<int>("What is the amount of points associated with the goal? ");

        Goal goal;
        if (goalType == typeof(ChecklistGoal)) {
            int goalCompletions = ConsoleUtils.PromptInput<int>("How many times does this goal need to be accomplished for a bonus? ");
            goal = new ChecklistGoal(name, description, pointValue, goalCompletions);
        } else {
            goal = (Goal) Activator.CreateInstance(goalType, name, description, pointValue);
        }
        return goal;
    }
}