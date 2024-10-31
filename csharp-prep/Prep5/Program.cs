using System;
using CommonUtils;

class Program {
    static void Main(string[] args) {
        DisplayWelcome();
        string name = PromptUserName();
        int number = PromptUserNumber();
        DisplayResult(name, SquareNumber(number));
    }

    static void DisplayWelcome() {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName() {
        return ConsoleUtils.PromptInput<string>("Please enter your name: ");
    }

    static int PromptUserNumber() {
        return ConsoleUtils.PromptInput<int>("Please enter your favorite number: ");
    }

    static int SquareNumber(int number) {
        return (int) Math.Pow(number, 2);
    }

    static void DisplayResult(string name, double squared) {
        Console.WriteLine($"{name}, the square of your number is {squared}");
    }
}