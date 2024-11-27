using Develop05.Goals;
using System.Text.Json.Serialization;

class SimpleGoal(string name, string description, int pointValue) : Goal(name, description, pointValue) {
    [JsonInclude]
    private bool completed = false;

    public override bool IsCompleted() {
        return completed;
    }

    public override void Record() {
        completed = true;
        AddPoints();
    }
}
