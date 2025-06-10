// EternalGoal.cs
// This file defines the EternalGoal class, a type of goal that is never truly completed,
// but can be recorded repeatedly for points.

public class EternalGoal : Goal
{
    // Constructor for EternalGoal.
    // It calls the base class constructor for common properties.
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
        // Eternal goals do not have a concept of being "complete", so no _isComplete field is needed.
    }

    // Polymorphism: Overrides the RecordEvent method from the base Goal class.
    // When an EternalGoal event is recorded, it always returns its points,
    // as it can be completed repeatedly.
    public override int RecordEvent()
    {
        return _points; // Always return the points for recording this event.
    }

    // Polymorphism: Overrides the GetDetailsString method from the base Goal class.
    // Provides a detailed string representation for an eternal goal,
    // always showing it as uncompleted as per its nature.
    public override string GetDetailsString()
    {
        return $"[ ] {_shortName} ({_description})"; // Eternal goals are never truly complete
    }

    // Overrides the GetStringRepresentation method for saving the goal to a file.
    // The format is "EternalGoal:shortName,description,points".
    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_shortName},{_description},{_points}";
    }
}
