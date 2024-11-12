namespace Develop03;
using System.Text.Json.Serialization;

public class Reference(string book, int chapter, int startVerse, int verseRange) {

    [JsonInclude]
    private readonly string book = book;
    [JsonInclude]
    private readonly int chapter = chapter;
    [JsonInclude]
    public int StartVerse { get; private set; } = startVerse;
    [JsonInclude]
    private readonly int verseRange = Math.Max(0, verseRange);

    public int EndVerse() {
        return StartVerse + verseRange;
    }

    public bool IsMultiVerse() {
        return verseRange > 0;
    }

    public override string ToString() {
        return  book + " " + chapter + ":" + (verseRange > 0 ? StartVerse + "-" + EndVerse() : StartVerse);
    }

    
}