using Develop04.Animations;

namespace Develop04.Activities;

public class BreathingActivity() : Activity("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.") {

    protected override void StartActivity() {
        CountdownAnimation countdown = new(5);
        while(!IsOver()) {
            Console.WriteLine();
            Console.Write("Breath in...");
            countdown.Play();
            Console.WriteLine();
            Console.Write("Breath out...");
            countdown.Play();
            Console.WriteLine();
        }
        Finish();
    }
    
}