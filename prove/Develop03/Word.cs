namespace Develop03;
using System.Text.Json.Serialization;

public class Word(string text) {

    public string Text { get; private set; } = text;
    [JsonIgnore]
    public bool Hidden { get; private set; }= false;

    public void Hide() {
        Hidden = true;
    }

    public void UnHide() {
        Hidden = false;
    }

    public string GetRenderedText() {
        if (Hidden) {
            return new string('_', Text.Length);
        }
        return Text;
    }
}