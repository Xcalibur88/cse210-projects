using Develop05.Goals;

class NegativeGoal(string name, string description, int pointValue) : Goal(name, description, pointValue) {
    public override bool IsCompleted() {
        return false;
    }

    public override void Record() {
        RemovePoints(pointValue);
    }
}
