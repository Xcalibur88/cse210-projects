namespace CommonUtils;

public class Menu {

    private readonly Dictionary<string, Action> options;
    private readonly bool clear;
    private readonly string title;
    private readonly string prompt;

    public Menu(string title, string prompt, bool clear, params (string key, Action action)[] options) {
        this.clear = clear;
        this.title = title;
        this.prompt = prompt;
        this.options = options.ToDictionary(option => $"{Array.IndexOf(options, option) + 1}. {option.key}", option => option.action);
    }

    public Menu(bool clear, params (string key, Action action)[] options) : this("Please select one of the following options", "What would you like to do?", clear, options) {}

    public Menu(params (string key, Action action)[] options) : this(false, options) {}

    public void Open(bool rePrompt) {
        Space();
        Console.WriteLine(title);

        foreach (KeyValuePair<string, Action> pair in options) {
            Console.WriteLine($" {pair.Key}");
        }

        int index = ConsoleUtils.PromptInput<int>($"{prompt} ", (i) => i > 0 && i <= options.Count, "Out of bound option index! Please try again.");
        Action selection = options.ElementAt(index - 1).Value;

        Space();
        selection();

        if (rePrompt) {
            Open();
        }
    }

    public void Open() {
        Open(true);
    }

    public void Space() {
        if (clear) {
            Console.Clear();
        } else {
            Console.WriteLine();
        }
    }
}