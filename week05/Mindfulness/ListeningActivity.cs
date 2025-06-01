using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are your personal strengths?",
        "Who have you helped recently?",
        "What are moments you felt peace?",
        "Who are your personal heroes?"
    };

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity helps you reflect by listing positive thoughts or things.";
    }

    public void Run()
    {
        DisplayStartingMessage();

        Random rand = new Random();
        Console.WriteLine($"\n--- Prompt ---\n{_prompts[rand.Next(_prompts.Count)]}");
        Console.WriteLine("You may begin listing items. Press Enter after each one.");
        ShowCountdown(3);

        int startTime = Environment.TickCount;
        int count = 0;

        while ((Environment.TickCount - startTime) / 1000 < _duration)
        {
            Console.Write("> ");
            Console.ReadLine();
            count++;
        }

        Console.WriteLine($"\nYou listed {count} items.");
        DisplayEndingMessage();
    }
}
