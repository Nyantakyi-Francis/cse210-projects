using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int userNumber;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // Input loop
        do
        {
            Console.Write("Enter number: ");
            userNumber = int.Parse(Console.ReadLine());

            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }

        } while (userNumber != 0);

        // Core calculations
        int sum = 0;
        int max = int.MinValue;
        foreach (int number in numbers)
        {
            sum += number;
            if (number > max)
            {
                max = number;
            }
        }

        float average = (float)sum / numbers.Count;

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");

        // Stretch: Smallest positive number
        int smallestPositive = int.MaxValue;
        foreach (int number in numbers)
        {
            if (number > 0 && number < smallestPositive)
            {
                smallestPositive = number;
            }
        }

        if (smallestPositive != int.MaxValue)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }
        else
        {
            Console.WriteLine("There are no positive numbers.");
        }

        // Stretch: Sort and display
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}