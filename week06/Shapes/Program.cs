// Program.cs

using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("CSE 210 | Polymorphism Learning Activity");
        Console.WriteLine("------------------------------------------");

        List<Shape> shapes = new List<Shape>();

        Square mySquare = new Square("Red", 5.0);
        Rectangle myRectangle = new Rectangle("Blue", 4.0, 6.0);
        Circle myCircle = new Circle("Green", 3.0);

        shapes.Add(mySquare);
        shapes.Add(myRectangle);
        shapes.Add(myCircle);

        Console.WriteLine("\nDisplaying Shape Information:");
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"\nShape Color: {shape.GetColor()}");
            Console.WriteLine($"Shape Area: {shape.GetArea():F2}"); // :F2 formats to 2 decimal places
        }

        Console.WriteLine("\n------------------------------------------");
        Console.WriteLine("Program execution complete.");
    }
}
