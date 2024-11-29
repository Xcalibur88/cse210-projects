namespace Develop05.Goals;

using System.Text.Json;
using System.Text.Json.Serialization;

class GoalConverter : JsonConverter<Goal> {
    public override Goal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        using var jsonDoc = JsonDocument.ParseValue(ref reader);
        var root = jsonDoc.RootElement;

        if (!root.TryGetProperty("type", out var typeProp)) {
            throw new JsonException("Missing type discriminator.");
        }

        var type = typeProp.GetString();
        return type switch {
            "SimpleGoal" => JsonSerializer.Deserialize<SimpleGoal>(root.GetRawText(), options),
            "NegativeGoal" => JsonSerializer.Deserialize<EternalGoal>(root.GetRawText(), options),
            "ChecklistGoal" => JsonSerializer.Deserialize<ChecklistGoal>(root.GetRawText(), options),
            "EternalGoal" => JsonSerializer.Deserialize<EternalGoal>(root.GetRawText(), options),
            _ => throw new JsonException($"Unknown goal type: {type}")
        };
    }

    public override void Write(Utf8JsonWriter writer, Goal value, JsonSerializerOptions options) {
        var temp = new Dictionary<string, object> {
            { "type", value.GetType().Name }
        };
        var serializedProperties = JsonSerializer.SerializeToElement(value, value.GetType(), options);
        foreach (var property in serializedProperties.EnumerateObject()) {
            temp[property.Name] = property.Value;
        }
        JsonSerializer.Serialize(writer, temp, typeof(Dictionary<string, object>), options);
    }
}