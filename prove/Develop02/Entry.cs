namespace Develop02;
using System.Text.Json.Serialization;

public class Entry(string response, string prompt) {

    public string Response { get; private set; } = response;
    public string Prompt { get; private set; } = prompt;
    [JsonInclude]
    public DateTime Time { get; private set; } = DateTime.Now;

    public void Display() {
        Console.WriteLine($"Date: {Time} - {Prompt}");
        Console.WriteLine(Response);
    }

}