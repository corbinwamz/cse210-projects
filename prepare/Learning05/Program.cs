using System;
using System.Formats.Asn1;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = [];

        double side = 4;
        string color = "blue";
        Shape shapeSquare = new Square(side, color);
        shapes.Add(shapeSquare);

        double length = 15;
        double width = 10;
        color = "green";
        Shape shapeRectangle = new Rectangle(length, width, color);
        shapes.Add(shapeRectangle);

        double radius = 10;
        color = "yellow";
        Shape shapeCircle = new Circle(radius, color);
        shapes.Add(shapeCircle);

        double area = 0;

        foreach (Shape shape in shapes)
        {
            color = shape.GetColor();
            area = shape.GetArea();
            Console.WriteLine($"{color} {area}");
        }
    }
}