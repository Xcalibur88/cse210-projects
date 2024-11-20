namespace Develop04.Activities;
using Develop04.Animations;
using CommonUtils;

class ListingActivity() : Activity("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.") {

    protected override void StartActivity() {
        Console.WriteLine();
        Console.WriteLine("List as many responses as you can to the following prompt: ");
        Console.WriteLine($"{Colors.Bright}{GetPrompt()}{Colors.Reset}");
        Console.WriteLine();
        Console.Write("You may begin in: ");
        new CountdownAnimation(5).Play();
        Console.WriteLine();

        SetStart();
        List<string> responses = [];
        while(!IsOver()) {
            responses.Add(ConsoleUtils.PromptInput<string>("> "));
        }
        Console.WriteLine($"You listed {responses.Count} items!");
        new LoadingAnimation().Play(2);
    }

    private string GetPrompt() {
        string[] prompts = ["Who are people that you appreciate?",
                "What are personal strengths of yours?",
                "Who are people that you have helped this week?",
                "When have you felt the Holy Ghost this month?",
                "Who are some of your personal heroes?"];
        return prompts[new Random().Next(prompts.Length)];
    }
    
}