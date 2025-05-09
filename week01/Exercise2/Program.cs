using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your grade percentage: ");
        string input = Console.ReadLine();
        int grade = int.Parse(input);

        string letter = "";
        string sign = "";

        // Determine the letter grade
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determine the sign
        int lastDigit = grade % 10;

        if (letter != "A" && letter != "F")
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }
        else if (letter == "A" && grade < 93)
        {
            sign = "-";
        }

        // Output the final grade
        Console.WriteLine($"Your grade is: {letter}{sign}");

        // Pass/fail message
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations,  you passed the class!");
        }
        else
        {
            Console.WriteLine("Don't worry, keep trying and you'll do better next time.");
        }
    }
}