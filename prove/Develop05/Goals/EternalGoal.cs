using Develop05.Goals;

class EternalGoal(string name, string description, int pointValue) : Goal(name, description, pointValue) {
    
    public override bool IsCompleted() {
        return false;
    }

    public override void Record() {
        AddPoints();
    }

}