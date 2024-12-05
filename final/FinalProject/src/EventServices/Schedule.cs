using Ical.Net;

class Schedule {
    private readonly List<Class> classes = [];
    
    public Schedule(Calendar calendar) {
        DateTime semesterStart = calendar.Events[0].Start.AsSystemLocal;
        DateTime fullWeekStart = semesterStart.AddDays(6 - (int) semesterStart.DayOfWeek);
        DateTime fullWeekEnd = fullWeekStart.AddDays(7);

        foreach (var evt in calendar.Events) {
            var eventStart = evt.Start.AsSystemLocal;
            var eventEnd = evt.End.AsSystemLocal;
            if (eventStart < fullWeekEnd && eventEnd >= fullWeekStart) {
                Console.WriteLine(evt.Location.ToString());
                if (Enum.TryParse(evt.Location.ToString()[..3], out Building building)) {
                    classes.Add(new Class(eventStart, eventEnd, building, int.Parse(evt.Location[4..])));
                } else {
                    Console.WriteLine($"Invalid or missing location for class: {evt.Summary}");
                }
            }
        }
    }

    public List<Class> GetClasses() {
        return classes;
    }
}