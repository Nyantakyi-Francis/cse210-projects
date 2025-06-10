// GoalManager.cs
// This file manages the collection of goals, the user's score,
// and handles all program operations (menu, create, record, list, save, load).

using System;
using System.Collections.Generic;
using System.IO; // Required for file operations (StreamWriter, StreamReader)

public class GoalManager
{
    // Encapsulation: Private member variables to hold the list of goals and the player's score.
    private List<Goal> _goals;
    private int _score;

    // Constructor for GoalManager.
    // Initializes a new list of goals and sets the initial score to 0.
    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    // The main loop for the Eternal Quest Program.
    // Displays the menu and handles user input until the user chooses to quit.
    public void Start()
    {
        string choice = "";
        while (choice != "6") // Loop until the user chooses to quit (option 6)
        {
            DisplayPlayerInfo(); // Always display player info at the top of the menu

            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            // Process user's menu choice
            switch (choice)
            {
                case "1":
                    CreateGoal(); // Call method to create a new goal
                    break;
                case "2":
                    ListGoalDetails(); // Call method to list all goal details
                    break;
                case "3":
                    SaveGoals(); // Call method to save goals to a file
                    break;
                case "4":
                    LoadGoals(); // Call method to load goals from a file
                    break;
                case "5":
                    RecordEvent(); // Call method to record an event for a goal
                    break;
                case "6":
                    Console.WriteLine("Exiting the program. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                    break;
            }
        }
    }

    // Displays the player's current score.
    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.");
    }

    // Lists the short names of all goals with a numbered index for selection.
    public void ListGoalNames()
    {
        Console.WriteLine("The types of Goals are:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals created yet. Please create a new goal first.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetShortName()}");
        }
    }

    // Displays the detailed string representation of all goals.
    public void ListGoalDetails()
    {
        Console.WriteLine("\nYour Goals:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to display. Please create a new goal first.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            // Polymorphism in action: GetDetailsString() is called on the base type,
            // but the specific overridden method for each goal type is executed.
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}") ;
        }
    }

    // Guides the user through creating a new goal based on their chosen type.
    public void CreateGoal()
    {
        Console.WriteLine("\nSelect the type of Goal to create:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Enter your choice: ");
        string goalTypeChoice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        // Create the specific goal type based on user input
        switch (goalTypeChoice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("What is the target amount for this goal? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type. Goal not created.");
                break;
        }
    }

    // Allows the user to record an event for a selected goal, updating the score.
    public void RecordEvent()
    {
        Console.WriteLine("\nSelect the goal you would like to record:");
        ListGoalNames(); // Show numbered list of goals for selection

        if (_goals.Count == 0)
        {
            return; // No goals to record event for
        }

        Console.Write("Enter the number of the goal: ");
        if (int.TryParse(Console.ReadLine(), out int goalIndex) && goalIndex > 0 && goalIndex <= _goals.Count)
        {
            Goal selectedGoal = _goals[goalIndex - 1]; // Adjust for 0-based index

            // Polymorphism in action: RecordEvent() is called on the base type,
            // but the specific overridden method for the selected goal type is executed.
            int pointsEarned = selectedGoal.RecordEvent();
            _score += pointsEarned; // Add earned points to the total score

            Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
            Console.WriteLine($"You now have {_score} points.");
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    // Saves the current list of goals and the player's score to a text file.
    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        try
        {
            // Use StreamWriter to write to the file. 'true' for append, 'false' for overwrite.
            // Using 'false' to overwrite for saving, as a new save should replace the old one.
            using (StreamWriter outputFile = new StreamWriter(filename, false))
            {
                outputFile.WriteLine(_score); // Save the total score on the first line

                foreach (Goal goal in _goals)
                {
                    // Polymorphism: GetStringRepresentation() is called on the base type,
                    // but the specific overridden method for each goal type is executed
                    // to save its unique data.
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine($"Goals saved to {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving goals: {ex.Message}");
        }
    }

    // Loads goals and the player's score from a text file.
    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine($"File '{filename}' not found. No goals loaded.");
            return;
        }

        try
        {
            _goals.Clear(); // Clear current goals before loading new ones
            _score = 0;     // Reset score

            // Use StreamReader to read from the file line by line.
            using (StreamReader inputFile = new StreamReader(filename))
            {
                // Read the first line as the score
                if (int.TryParse(inputFile.ReadLine(), out int loadedScore))
                {
                    _score = loadedScore;
                }
                else
                {
                    Console.WriteLine("Warning: Could not read score from file. Score set to 0.");
                }

                string line;
                // Read remaining lines, each representing a goal
                while ((line = inputFile.ReadLine()) != null)
                {
                    // Parse the goal type and data from the line
                    string[] parts = line.Split(':'); // Split by the first colon to separate type and data
                    string goalType = parts[0];
                    string[] data = parts[1].Split(','); // Split data by commas

                    // Reconstruct goal objects based on their type
                    switch (goalType)
                    {
                        case "SimpleGoal":
                            _goals.Add(new SimpleGoal(
                                data[0],    // name
                                data[1],    // description
                                int.Parse(data[2]), // points
                                bool.Parse(data[3]) // isComplete
                            ));
                            break;
                        case "EternalGoal":
                            _goals.Add(new EternalGoal(
                                data[0],    // name
                                data[1],    // description
                                int.Parse(data[2])  // points
                            ));
                            break;
                        case "ChecklistGoal":
                            _goals.Add(new ChecklistGoal(
                                data[0],    // name
                                data[1],    // description
                                int.Parse(data[2]), // points
                                int.Parse(data[3]), // target
                                int.Parse(data[4]), // bonus
                                int.Parse(data[5])  // amountCompleted
                            ));
                            break;
                        default:
                            Console.WriteLine($"Unknown goal type encountered: {goalType}. Skipping goal.");
                            break;
                    }
                }
            }
            Console.WriteLine($"Goals loaded from {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading goals: {ex.Message}");
            _goals.Clear(); // Clear any partially loaded data on error
            _score = 0;
        }
    }
}
