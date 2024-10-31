using System;
using CommonUtils;

class Program {
    static void Main(string[] args) {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int number = -1;
        do {
            number = ConsoleUtils.PromptInput<int, int>("Enter number: ");
            numbers.Add(number);
        } while (number != 0);

        Console.WriteLine($"The sum is: {sum(numbers)}");
        Console.WriteLine($"The average is: {average(numbers)}");
        Console.WriteLine($"The largest number is: {find_highest(numbers)}");
        Console.WriteLine($"The smallest positive number is: {find_smallest_positive(numbers)}");

        numbers.Sort();
        Console.WriteLine("The sorted list is: [" + string.Join(", ", numbers) + "]");
    }

    static int sum(List<int> numbers) {
        int sum = 0;
        foreach (int number in numbers) {
            sum += number;
        }
        return sum;
    }

    static int average(List<int> numbers) {
        return sum(numbers) / numbers.Count();
    }

    static int find_highest(List<int> numbers) {
        int highest = 0;
        foreach (int number in numbers) {
            if (number > highest) {
                highest = number;
            }
        }
        return highest;
    }

    static int find_smallest_positive(List<int> numbers) {
        int smallest = int.MaxValue;
        foreach (int number in numbers) {
            if (number > 0 && number < smallest) {
                smallest = number;
            }
        }
        return smallest;
    }

}