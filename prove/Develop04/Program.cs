using Develop04.Activities;
using CommonUtils;

class Program {

    static void Main(string[] args) {
        Menu menu = new(true, ("Breathing", new BreathingActivity().Begin),
                              ("Reflection", new ReflectionActivity().Begin),
                              ("Listing", new ListingActivity().Begin),
                              ("Exit", Exit));
        menu.Open();
    }

    static void Exit() {
        Environment.Exit(0);
    }
}