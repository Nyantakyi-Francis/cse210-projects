// ChecklistGoal.cs
// This file defines the ChecklistGoal class, a type of goal that requires
// multiple repetitions to complete, offering a bonus upon final completion.

public class ChecklistGoal : Goal
{
    // Encapsulation: Private member variables to track progress and bonus.
    private int _amountCompleted; // How many times the goal has been done
    private int _target;          // How many times the goal needs to be done
    private int _bonus;           // Bonus points awarded upon reaching the target

    // Constructor for ChecklistGoal.
    // It calls the base class constructor for common properties and initializes
    // target, bonus, and amount completed.
    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted = 0)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    // Polymorphism: Overrides the RecordEvent method from the base Goal class.
    // Increments the completion count and awards regular points.
    // If the goal is completed, it also awards the bonus points.
    public override int RecordEvent()
    {
        _amountCompleted++; // Increment the count of times completed
        int pointsEarned = _points; // Start with regular points for this event

        // Check if the goal is now complete (reached the target)
        if (_amountCompleted == _target)
        {
            pointsEarned += _bonus; // Add bonus points if target is reached
        }
        return pointsEarned; // Return total points earned for this event
    }

    // Method to check if the ChecklistGoal is complete.
    public bool IsComplete()
    {
        return _amountCompleted >= _target; // Goal is complete if amount completed meets or exceeds target
    }

    // Polymorphism: Overrides the GetDetailsString method from the base Goal class.
    // Provides a detailed string representation including completion status ([ ] or [X])
    // and current progress (e.g., "Completed 2/5 times").
    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]"; // Check completion status using IsComplete()
        return $"{status} {_shortName} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
    }

    // Overrides the GetStringRepresentation method for saving the goal to a file.
    // The format is "ChecklistGoal:shortName,description,points,target,bonus,amountCompleted".
    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_shortName},{_description},{_points},{_target},{_bonus},{_amountCompleted}";
    }
}
