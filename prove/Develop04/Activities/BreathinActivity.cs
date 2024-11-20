using Develop04.Animations;

namespace Develop04.Activities;

class BreathingActivity() : Activity("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.") {

    protected override void StartActivity() {
        CountdownAnimation countdownIn = new(4);
        CountdownAnimation countdownOut = new(5);
        SetStart();
        while(!IsOver()) {
            Console.WriteLine();
            Console.Write("Breath in...");
            countdownIn.Play();
            Console.WriteLine();
            Console.Write("Breath out...");
            countdownOut.Play();
            Console.WriteLine();
        }
    }
    
}