using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than others?",
        "What is your favorite thing about this experience?",
        "What can you learn from this experience?",
        "How can you apply this to your life?"
    };

    public ReflectionActivity()
    {
        _name = "Reflection Activity";
        _description = "This activity helps you reflect on moments of strength and resilience.";
    }

    public void Run()
    {
        DisplayStartingMessage();

        Random rand = new Random();
        Console.WriteLine($"\n--- Prompt ---\n{_prompts[rand.Next(_prompts.Count)]}");
        ShowSpinner(5);

        int elapsed = 0;
        while (elapsed < _duration)
        {
            string question = _questions[rand.Next(_questions.Count)];
            Console.WriteLine($"\n> {question}");
            ShowSpinner(5);
            elapsed += 5;
        }

        DisplayEndingMessage();
    }
}
