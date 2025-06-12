using System;
using System.Collections.Generic;
using System.Globalization; // Needed for DateTime formatting

// Base Activity class
// This class holds common attributes and defines abstract methods
// for calculations that must be implemented by derived classes.
public abstract class Activity
{
    // Private member variables for encapsulation
    private DateTime _date;
    private int _minutes;

    // Constructor for the Activity base class
    // All derived classes will call this constructor.
    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    // Public getters for the private member variables
    public DateTime Date
    {
        get { return _date; }
    }

    public int Minutes
    {
        get { return _minutes; }
    }

    // Abstract methods for getting distance, speed, and pace.
    // These methods have no implementation in the base class and
    // *must* be overridden in any non-abstract derived class.
    public abstract double GetDistance(); // Returns distance in kilometers
    public abstract double GetSpeed();    // Returns speed in kilometers per hour (kph)
    public abstract double GetPace();     // Returns pace in minutes per kilometer (min/km)

    // GetSummary method.
    // This method is implemented in the base class and utilizes polymorphism
    // by calling the abstract methods (which will execute the derived class's implementation).
    public virtual string GetSummary()
    {
        // Format the date as "dd Mmm yyyy"
        string formattedDate = _date.ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

        // Call the overridden methods to get the specific activity's data
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();

        // Construct the summary string
        // Using string interpolation for cleaner output
        return $"{formattedDate} ({_minutes} min): Distance {distance:F2} km, Speed: {speed:F2} kph, Pace: {pace:F2} min per km";
    }
}

// Derived class for Running activities
public class Running : Activity
{
    // Private member variable specific to Running
    private double _distance; // Stored in kilometers

    // Constructor for Running class
    // Calls the base class constructor and initializes its own attributes.
    public Running(DateTime date, int minutes, double distance) : base(date, minutes)
    {
        _distance = distance; // Distance is directly provided
    }

    // Overrides the GetDistance method from the base class
    // Returns the stored distance for running.
    public override double GetDistance()
    {
        return _distance;
    }

    // Overrides the GetSpeed method from the base class
    // Calculation: (distance / minutes) * 60 for kph
    public override double GetSpeed()
    {
        // Avoid division by zero
        if (Minutes == 0) return 0;
        return (_distance / Minutes) * 60;
    }

    // Overrides the GetPace method from the base class
    // Calculation: minutes / distance for min/km
    public override double GetPace()
    {
        // Avoid division by zero
        if (_distance == 0) return 0;
        return Minutes / _distance;
    }
}

// Derived class for Cycling activities
public class Cycling : Activity
{
    // Private member variable specific to Cycling
    private double _speed; // Stored in kilometers per hour (kph)

    // Constructor for Cycling class
    // Calls the base class constructor and initializes its own attributes.
    public Cycling(DateTime date, int minutes, double speed) : base(date, minutes)
    {
        _speed = speed; // Speed is directly provided
    }

    // Overrides the GetDistance method from the base class
    // Calculation: (speed / 60) * minutes for kilometers
    public override double GetDistance()
    {
        return (_speed / 60) * Minutes;
    }

    // Overrides the GetSpeed method from the base class
    // Returns the stored speed for cycling.
    public override double GetSpeed()
    {
        return _speed;
    }

    // Overrides the GetPace method from the base class
    // Calculation: 60 / speed for min/km
    public override double GetPace()
    {
        // Avoid division by zero
        if (_speed == 0) return 0;
        return 60 / _speed;
    }
}

// Derived class for Swimming activities
public class Swimming : Activity
{
    // Private member variable specific to Swimming
    private int _laps;

    // A constant for the length of one lap in meters
    private const double LapLengthMeters = 50;

    // Constructor for Swimming class
    // Calls the base class constructor and initializes its own attributes.
    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    // Overrides the GetDistance method from the base class
    // Calculation: (laps * 50) / 1000 for kilometers
    public override double GetDistance()
    {
        return (_laps * LapLengthMeters) / 1000;
    }

    // Overrides the GetSpeed method from the base class
    // Calculation: (distance / minutes) * 60 for kph
    public override double GetSpeed()
    {
        // Avoid division by zero
        if (Minutes == 0) return 0;
        double distance = GetDistance(); // Get distance using the overridden method
        return (distance / Minutes) * 60;
    }

    // Overrides the GetPace method from the base class
    // Calculation: minutes / distance for min/km
    public override double GetPace()
    {
        double distance = GetDistance(); // Get distance using the overridden method
        // Avoid division by zero
        if (distance == 0) return 0;
        return Minutes / distance;
    }
}

// Main program class to demonstrate the usage of the activity classes
public class Program
{
    public static void Main(string[] args)
    {
        // Create a list to hold various activity objects (polymorphism in action)
        List<Activity> activities = new List<Activity>();

        // Create instances of each derived activity type
        // Use realistic example values for date, duration, and specific metrics.
        activities.Add(new Running(new DateTime(2023, 11, 3), 30, 4.8)); // 4.8 km in 30 min
        activities.Add(new Cycling(new DateTime(2023, 11, 4), 45, 20.0)); // 20.0 kph for 45 min
        activities.Add(new Swimming(new DateTime(2023, 11, 5), 25, 40)); // 40 laps (50m/lap) in 25 min

        // Iterate through the list and call GetSummary on each item.
        // Due to polymorphism, the correct overridden GetSummary (or its calls to GetDistance/Speed/Pace)
        // will be executed for each specific activity type.
        Console.WriteLine("--- Exercise Activity Summaries ---");
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }

        Console.WriteLine("\nPress any key to exit.");
        Console.ReadKey(); // Keep console open until a key is pressed
    }
}
