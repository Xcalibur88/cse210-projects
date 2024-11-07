namespace Develop02;
using System.Text.Json;

public class Journal {

    public List<Entry> Entries { get; set; } = [];
    private readonly JsonSerializerOptions serializationOptions = new() { WriteIndented = true };

    public void Add(Entry entry) {
        Entries.Add(entry);
    }

    public void Save(string fileName) {
        string jsonString = JsonSerializer.Serialize(this, serializationOptions);
        File.WriteAllText(fileName, jsonString);
    }

    public static Journal Load(string fileName) {
        string jsonString = File.ReadAllText(fileName);
        return JsonSerializer.Deserialize<Journal>(jsonString);;
    }

}