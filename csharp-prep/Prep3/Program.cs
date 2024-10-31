using System;
using CommonUtils;

class Program {
    static void Main(string[] args) {
        bool playAgain = false;
        do {
            GuessingGame();

            playAgain = ConsoleUtils.PromptInput<string, bool>("Play again (y/n)? ",
                criteria: (i) => i.ToLower().Equals("y") || i.ToLower().Equals("n"),
                process: (ii) => ii.Equals("y") ? true : ii.Equals("n") ? false : true);
        } while (playAgain);
    }

    static void GuessingGame() {
        int magicNumber = new Random().Next(1, 101);
        int guesses = 0;
        do {
            int guess = ConsoleUtils.PromptInput<int, int>("What is your guess? ");

            if (guess > magicNumber) {
                Console.WriteLine("Lower");
            } else if (guess < magicNumber) {
                Console.WriteLine("Higher");
            } else {             
                Console.WriteLine($"You guessed it in {guesses} guesses!");
                return;
            }
            guesses++;
        } while (true);
    }

}