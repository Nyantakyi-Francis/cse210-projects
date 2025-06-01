using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity helps you relax by guiding deep breathing. Clear your mind and focus on your breath.";
    }

    public void Run()
    {
        DisplayStartingMessage();

        int elapsed = 0;
        while (elapsed < _duration)
        {
            Console.Write("\nBreathe in... ");
            ShowCountdown(4);

            Console.Write("Now breathe out... ");
            ShowCountdown(6);

            elapsed += 10;
        }

        DisplayEndingMessage();
    }
}
