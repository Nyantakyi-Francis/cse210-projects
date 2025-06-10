// Goal.cs
// This file defines the abstract base class for all goal types.
// It enforces common properties and behaviors for all goals.

using System;

public abstract class Goal
{
    // Encapsulation: Private member variables to store goal properties.
    protected string _shortName;
    protected string _description;
    protected int _points;

    // Constructor to initialize the common properties of a goal.
    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    // Abstraction: Public getters to allow controlled access to private data.
    public string GetShortName()
    {
        return _shortName;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetPoints()
    {
        return _points;
    }

    // Polymorphism: Abstract method to record an event for the goal.
    // Derived classes must provide their specific implementation for this.
    // It returns the points earned from recording this event.
    public abstract int RecordEvent();

    // Polymorphism: Abstract method to get a detailed string representation of the goal.
    // Derived classes will customize how their details are displayed (e.g., [ ], [X], progress).
    public abstract string GetDetailsString();

    // Abstract method to get a string representation suitable for saving to a file.
    // Each derived class will define its own format for serialization.
    public abstract string GetStringRepresentation();
}
