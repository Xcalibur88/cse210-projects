namespace Develop03;
using CommonUtils;
using System.Text.Json;

class Program {

    public static List<Scripture> scriptures = [];
    public static string fileName = "scriptures.json";
    public static readonly JsonSerializerOptions serializationOptions = new() { WriteIndented = true, IncludeFields = true };

    static void Main(string[] args) {
        LoadSciptures();
        Menu mainMenu = new(true, ("Memorize Random", MemorizeRandom), ("Select Memorize", MemorizesSelect), ("List", ListScriptures), ("Add", AddScripture), ("Exit", Exit));
        mainMenu.Open();
        SaveScriptures();
    }

    static void LoadSciptures() {
        if (!File.Exists(fileName)) {
            SaveScriptures();
        }
        string jsonString = File.ReadAllText(fileName);
        scriptures = JsonSerializer.Deserialize<List<Scripture>>(jsonString, serializationOptions);
    }

    static void SaveScriptures() {
        string jsonString = JsonSerializer.Serialize(scriptures, serializationOptions);
        File.WriteAllText(fileName, jsonString);
    }

    static void Memorize(Scripture scripture) {
        bool quit = false;
        while(!quit) {
            Console.Clear();
            Console.WriteLine(scripture.GetRenderedScripture());
            Console.WriteLine();
            quit = ConsoleUtils.PromptInput<string, bool>("Press enter to continue or type 'quit' to finish: ", process: (ii) => ii.Equals("quit")) || scripture.IsAllHidden();
            scripture.HideWords(3);
        }
        scripture.UnHideAll();
    }

    static void MemorizeRandom() {
        Memorize(scriptures[new Random().Next(scriptures.Count)]);
    }

    static void MemorizesSelect() {
        List<(string, Action)> options = [];
        foreach(Scripture scripture in scriptures) {
            options.Add((scripture.GetRenderedReference(), () => Memorize(scripture)));
        }
        Menu scriptureOptionsMenu = new(true, [.. options]);
        scriptureOptionsMenu.Open(false);
    }

    static void ListScriptures() {
        foreach(Scripture scripture in scriptures) {
            Console.WriteLine(scripture.GetRenderedScripture());
            Console.WriteLine();
        }
        ConsoleUtils.PromptInput<string>("Press enter to continue...");
    }

    static void AddScripture() {
        string book = ConsoleUtils.PromptInput<string>("Book of scripture (ex. 1 Nephi): ");
        int chapter = ConsoleUtils.PromptInput<int>("Chapter: ");

        Dictionary<int, List<Word>> verses = [];
        int verseNumber = ConsoleUtils.PromptInput<int>("Verse number: ");
        string verse = ConsoleUtils.PromptInput<string>("Paste the verse: ");
        do {
            verses[verseNumber] = verse.Split(" ").Select(text => new Word(text)).ToList();
            verseNumber++;
            verse = ConsoleUtils.PromptInput<string>("Paste the next verse or press enter to continue: ");
        } while(verse.Length > 0);

        Reference reference = new(book, chapter, verses.First().Key, verses.Count - 1);
        Scripture scripture = new(reference, verses);
        scriptures.Add(scripture);
        SaveScriptures();
    }

    static void Exit() {
        Environment.Exit(0);
    }
}