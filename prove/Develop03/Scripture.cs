namespace Develop03;
using System.Text;
using System.Text.Json.Serialization;

public class Scripture(Reference reference, Dictionary<int, List<Word>> verses) {
    [JsonInclude]
    private readonly Reference reference = reference;
    [JsonInclude]
    private readonly Dictionary<int, List<Word>> verses = verses;

    public void HideWords(int wordCount) {
        Random r = new();
        for (int i = 0; i < wordCount; i++) {
            List<Word> words = verses.ElementAt(r.Next(verses.Count)).Value;
            
            Word word;
            int attempts = 0;
            do {
                word = words[r.Next(words.Count)];
                attempts++;
            } while (word.Hidden && attempts < words.Count);
            word.Hidden = true;
        }
    }

    public bool IsAllHidden() {
        return verses.All(verse => verse.Value.All(word => word.Hidden));   
    }

    public string GetRenderedScripture() {
        var text = new StringBuilder(reference.ToString());
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
            if (reference.IsMultiVerse()) {
                text.Append('\n');
            }
        }
        return text.ToString();
    }

}