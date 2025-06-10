// Program.cs
// Main entry point for the Eternal Quest Program.
// This file initializes and runs the GoalManager.

using System;

class Program
{
    static void Main(string[] args)
    {
        // Create an instance of the GoalManager to run the application.
        // The GoalManager handles all the logic for creating, tracking,
        // saving, and loading goals.
        GoalManager goalManager = new GoalManager();

        // Start the main menu loop of the Eternal Quest program.
        goalManager.Start();

        //
        // Creativity and Exceeding Requirements:
        // You can describe any additional features or creative elements
        // you've added to the program here as comments.
        //
        // For example:
        // - Implemented a 'leveling' system based on total score.
        // - Added a 'negative goal' type where points are deducted.
        // - Introduced a graphical representation of goal progress.
        // - Implemented a 'streak' bonus for consecutive eternal goals.
        //
        // Example of a creative feature description:
        // // This program includes a simple 'leveling' system.
        // // Users gain a new 'level' for every 1000 points accumulated,
        // // displayed alongside their score, encouraging continued engagement.
    }
}
