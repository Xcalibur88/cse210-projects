namespace Develop03;
using CommonUtils;
using System.Text.Json;

class Program {

    public static List<Scripture> scriptures = [];
    public static readonly JsonSerializerOptions serializationOptions = new() { WriteIndented = true, IncludeFields = true };
    public static string fileName = "scriptures.json";

    static void Main(string[] args) {
        LoadSciptures();
        Menu mainMenu = new(true, ("Memorize", Memorize), ("Add", Add), ("Exit", Exit));
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

    static void Memorize() {
        Scripture scripture = scriptures[new Random().Next(scriptures.Count)];

        bool quit = false;
        while(!quit) {
            Console.Clear();
            Console.WriteLine(scripture.GetRenderedScripture());
            quit = ConsoleUtils.PromptInput<string, bool>("Press enter to continue or type 'quit' to finish: ", process: (ii) => ii.Equals("quit")) || scripture.IsAllHidden();
            scripture.HideWords(3);
        }
    }

    static void Add() {
        string book = ConsoleUtils.PromptInput<string>("Book of scripture (ex. 1 Nephi): ");
        int chapter = ConsoleUtils.PromptInput<int>("Chapter: ");

        bool next = false;
        Dictionary<int, List<Word>> verses = [];
        int verseNumber = ConsoleUtils.PromptInput<int>("Verse number: ");
        do {
            string verse = ConsoleUtils.PromptInput<string>("Paste the verse: ");
            verses[verseNumber] = verse.Split(" ").Select(text => new Word(text)).ToList();;

            next = ConsoleUtils.PromptInput<string, bool>("Add another verse (y/n)?: ",
                criteria: (i) => i.ToLower().Equals("y") || i.ToLower().Equals("n"),
                process: (ii) => ii.Equals("y") || !ii.Equals("n"));
            verseNumber++;
        } while(next);

        Reference reference = new(book, chapter, verses.First().Key, verses.Count - 1);
        Scripture scripture = new(reference, verses);
        
        scriptures.Add(scripture);
        SaveScriptures();
    }

    static void Exit() {
        Environment.Exit(0);
    }
}