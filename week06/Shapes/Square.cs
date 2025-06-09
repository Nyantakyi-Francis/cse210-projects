// Square.cs
public class Square : Shape // Step 4: Make sure this class inherits from the base class.
{
    private double _side;

    public Square(string color, double side) : base(color)
    {
        _side = side;
    }

    public override double GetArea()
    {
        return _side * _side;
    }
}