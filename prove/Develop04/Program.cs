using Develop04.Activities;
using CommonUtils;

class Program {

    static void Main(string[] args) {
        Menu menu = new(true, ("Breathing activity", new BreathingActivity().Begin),
                              ("Reflection activity", new ReflectionActivity().Begin),
                              ("Listing activity", new ListingActivity().Begin),
                              ("Exit", Exit));
        menu.Open();
    }

    static void Exit() {
        Environment.Exit(0);
    }
}