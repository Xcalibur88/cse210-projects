using System.Text.Json.Serialization;
using Develop05.Goals;

class ChecklistGoal(string name, string description, int pointValue, int goalCompletions) : Goal(name, description, pointValue) {
    [JsonInclude]
    private readonly int goalCompletions = goalCompletions;
    [JsonInclude]
    private int currentCompletions;

    public override bool IsCompleted() {
        return currentCompletions >= goalCompletions;
    }

    public override string GetRendered() {
        return $"{(IsCompleted() ? "[x]" : "[ ]")} {Name} ({Description}) -- Currently Completed {currentCompletions}/{goalCompletions}";
    }

    public override void Record() {
        currentCompletions++;
        AddPoints();
        if (currentCompletions == goalCompletions) {
            AddPoints(pointValue * 10);
        }
    }
}