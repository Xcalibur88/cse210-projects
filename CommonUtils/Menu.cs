namespace CommonUtils;

public class Menu {

    private readonly Dictionary<string, Action> options;
    private readonly bool clear;

    public Menu(bool clear, params (string, Action)[] options) {
        this.clear = clear;
        this.options = [];
        int index = 1;
        foreach (var (key, action) in options) {
            this.options[index + ". " + key] = action;
            index++;
        }
    }

    public Menu(params (string, Action)[] options) {
        this.options = [];
        int index = 1;
        foreach (var (key, action) in options) {
            this.options[index + ". " + key] = action;
            index++;
        }
    }

    public void Open(bool rePrompt) {
        Space();
        Console.WriteLine("Please select one of the following options");

        foreach (KeyValuePair<string, Action> pair in options) {
            Console.WriteLine(pair.Key);
        }

        int index = ConsoleUtils.PromptInput<int>("What would you like to do? ", (i) => i > 0 && i <= options.Count, "Out of bound option index! Please try again.");
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