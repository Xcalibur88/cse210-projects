using System;

class Program {
    static void Main(string[] args) {
        Console.Write("What is your percentage grade: ");
        int percentageGrade = int.Parse(Console.ReadLine());

        NotifyGrade(percentageGrade, GetLetterGrade(percentageGrade));
    }

    static string GetLetterGrade(int percentageGrade) {
        string letter = "";
        if (percentageGrade >= 90) {
            letter = "A";
            if (percentageGrade >= 97) {
                return letter;
            }
        } else if (percentageGrade >= 80) {
            letter = "B";
        } else if (percentageGrade >= 70) {
            letter = "C";
        } else if (percentageGrade >= 60) {
            letter = "D";
        } else {
            return "F";
        }

        if (percentageGrade % 10 >= 7) {
            return letter + "+";
        } else if (percentageGrade % 10 <= 3) {
            return letter + "-";
        }
        return letter;
    }

    static void NotifyGrade(int percentageGrade, string letterGrade) {
         Console.WriteLine($"\nYour grade: {letterGrade}");
         if (percentageGrade >= 70) {
            Console.WriteLine("Good work, you passed!");
         } else {
            Console.WriteLine("Non-passing grade. Better luck next time!");
         }
    }
}