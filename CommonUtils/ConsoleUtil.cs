namespace CommonUtils;
using System;

public static class ConsoleUtils {

    public static T2 PromptInput<T, T2>(string prompt, Func<string, bool> criteria = null, Func<T, T2> process = null, string reprompt = null) {
        criteria ??= (i) => true;
        process ??= (ii) => (T2) Convert.ChangeType(ii, typeof(T2));
        while (true) {
            try {
                Console.Write(prompt);
                string userInput = Console.ReadLine();
                T convertedInput = (T) Convert.ChangeType(userInput, typeof(T));
                if (criteria(userInput)) {
                    return process(convertedInput);
                }
            } catch (InvalidCastException) {
            } catch (FormatException) {}

            if (reprompt != null) {
                Console.WriteLine(reprompt);
            }
        }
    }

    public static T PromptInput<T>(string prompt, Func<string, bool> criteria = null, string reprompt = null) {
        criteria ??= (i) => true;
        while (true) {
            try {
                Console.Write(prompt);
                string userInput = Console.ReadLine();
                T convertedInput = (T) Convert.ChangeType(userInput, typeof(T));
                if (criteria(userInput)) {
                    return convertedInput;
                }
            } catch (InvalidCastException) {
            } catch (FormatException) {}

            if (reprompt != null) {
                Console.WriteLine(reprompt);
            }
        }
    }

}
