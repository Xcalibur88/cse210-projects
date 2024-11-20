namespace Develop04.Activities;
using CommonUtils;
using Develop04.Animations;

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
    }
}