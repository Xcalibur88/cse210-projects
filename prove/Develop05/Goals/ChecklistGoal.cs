using System.Text.Json.Serialization;
using Develop05.Goals;

class ChecklistGoal(string name, string description, int pointValue, int targetCompletions) : Goal(name, description, pointValue) {
    [JsonInclude]
    private readonly int targetCompletions = targetCompletions;
    [JsonInclude]
    private int currentCompletions;

    public override bool IsCompleted() {
        return currentCompletions >= targetCompletions;
    }

    public override string GetRendered() {
        return $"{(IsCompleted() ? "[x]" : "[ ]")} {Name} ({Description}) -- Currently Completed {currentCompletions}/{targetCompletions}";
    }

    public override void Record() {
        currentCompletions++;
        AddPoints();
        if (currentCompletions == targetCompletions) {
            AddPoints(pointValue * 10);
        }
    }
}