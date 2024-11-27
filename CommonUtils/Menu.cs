namespace CommonUtils;

public class Menu {

    private readonly Dictionary<string, Action> options;
    private readonly bool clear;
    private readonly string title = "Please select one of the following options";
    private readonly string prompt = "What would you like to do?";

    public Menu(bool clear, params (string, Action)[] options) {
        this.clear = clear;
        this.options = [];
        int index = 1;
        foreach (var (key, action) in options) {
            this.options[index + ". " + key] = action;
            index++;
        }
    }

    public Menu(string title, string prompt, bool clear, params (string, Action)[] options) : this(false, options) {
        this.title = title;
        this.prompt = prompt;
    }

    public Menu(params (string, Action)[] options) : this(false, options) {}

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