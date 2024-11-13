namespace Develop03;
using System.Text;
using System.Text.Json.Serialization;

public class Scripture(Reference reference, Dictionary<int, List<Word>> verses) {
    [JsonInclude]
    private readonly Reference reference = reference;
    [JsonInclude]
    private readonly Dictionary<int, List<Word>> verses = verses;

    public void HideWords(int wordCount) {
        List<Word> words = verses.SelectMany(verse => verse.Value).ToList();
        Random r = new();
        Word word;
        for (int i = 0; i < wordCount && !IsAllHidden(); i++) {
            do {
                word = words[r.Next(words.Count)];
            } while (word.Hidden);
            word.Hide();
        }
    }

    public void UnHideAll() {
        foreach(var word in verses.Values.SelectMany(words => words)) {
            word.UnHide();
        }
    }

    public bool IsAllHidden() {
        return verses.All(verse => verse.Value.All(word => word.Hidden));   
    }

    public string GetRenderedScripture() {
        var text = new StringBuilder(Colors.Bright + reference.ToString() + Colors.Reset);
        if (reference.IsMultiVerse()) {
            text.Append('\n');
        }
        foreach (var verse in verses) {
            if (reference.IsMultiVerse()) {
                text.Append(verse.Key);
            }
            foreach (Word word in verse.Value) {
                text.Append(' ').Append(word.GetRenderedText());
            }
            if (reference.IsMultiVerse() && verse.Key != verses.Last().Key) {
                text.Append('\n');
            }
        }
        return text.ToString();
    }

}