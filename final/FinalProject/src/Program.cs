using FinalProject.Maps;
using CommonUtils;
using Ical.Net;

class Program {
    static OpenRouteService openRouteService;

    static void Main(string[] args) {
        openRouteService = new();
        openRouteService.StartORS();
        AppDomain.CurrentDomain.ProcessExit += (sender, eventArgs) => openRouteService.StopORS();
        Console.WriteLine();
        ConsoleUtils.PromptInput<string>("Press enter to continue...");

        var calendar = Calendar.Load(File.ReadAllText("./data/Fall_2024_schedule.ics"));
        Schedule schedule = new(calendar);
        Route route = new(43.82102665792033, -111.78354463789711, 43.819511901490934, -111.78327855565847);
        route.SendRequestAsync().GetAwaiter().GetResult();

        // foreach (Class cls in schedule.GetClasses()) {
        //     Console.WriteLine($"{cls.startTime} {cls.endTime} {cls.location} {cls.roomNumber}");
        // }

        Console.WriteLine();
        ConsoleUtils.PromptInput<string>("Press enter to continue...");
    }
}