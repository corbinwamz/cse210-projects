class Circle : Shape
{
    private double _radius;

    public Circle(double radius, string color) : base(color)
    {
        _radius = radius;
    }

    public override double GetArea()
    {
        double area = Math.PI * Math.Pow(_radius, 2);
        return area;
    }
}