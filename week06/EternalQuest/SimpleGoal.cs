// SimpleGoal.cs
// This file defines the SimpleGoal class, a type of goal that can be completed once.

public class SimpleGoal : Goal
{
    // Encapsulation: Private member variable to track completion status.
    private bool _isComplete;

    // Constructor for SimpleGoal.
    // It calls the base class constructor for common properties and initializes _isComplete.
    // Default value for isComplete is false, as a new simple goal is not complete.
    public SimpleGoal(string name, string description, int points, bool isComplete = false)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    // Polymorphism: Overrides the RecordEvent method from the base Goal class.
    // When a SimpleGoal event is recorded, it marks the goal as complete
    // and returns the points associated with it.
    public override int RecordEvent()
    {
        if (!_isComplete) // Only award points and mark complete if not already completed
        {
            _isComplete = true; // Mark the goal as complete
            return _points;     // Return the points for completing the goal
        }
        return 0; // If already complete, no points are awarded
    }

    // Polymorphism: Overrides the GetDetailsString method from the base Goal class.
    // Provides a detailed string representation including its completion status ([ ] or [X]).
    public override string GetDetailsString()
    {
        // Use a ternary operator to display [X] if complete, otherwise [ ].
        string status = _isComplete ? "[X]" : "[ ]";
        return $"{status} {_shortName} ({_description})";
    }

    // Overrides the GetStringRepresentation method for saving the goal to a file.
    // The format is "SimpleGoal:shortName,description,points,isComplete".
    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_shortName},{_description},{_points},{_isComplete}";
    }
}
