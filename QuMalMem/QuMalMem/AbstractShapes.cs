using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuMalMem
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return "(" + X + "," + Y + ")";
        }
    }

    public abstract class Shape
    {
        public string Id { get; set; }
        public Point RefPoint { get; set; }
        public String Color { get; set; }

        public Shape(string id, Point referencePoint, string color)
        {
            Id = id;
            RefPoint = referencePoint;
            Color = color;
        }

        public string GetColor()
        {
            return Color;
        }

        public abstract double GetArea();
        public abstract double GetCircumference();
        public abstract double GetWidth();
        public abstract double GetHeight();

        public override string ToString()
        {
            return "[" + Id + ": refpoint=" + RefPoint.ToString() + " area=" + GetArea() + " circ=" + GetCircumference() + "]";
        }
    }
    public class Rectangle : Shape
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public Rectangle(string id, Point refPoint, string color, int height, int width) : base(id, refPoint, color)
        {
            Height = height;
            Width = width;
        }

        public override double GetArea()
        {
            return Width * Height;
        }

        public override double GetCircumference()
        {
            return 2 * Width + 2 * Height;
        }

        public override double GetHeight()
        {
            return Height;
        }

        public override double GetWidth()
        {
            return Width;
        }
    }
    public class Square : Rectangle
    {
        public Square(string id, Point refPoint, string color, int sideLength)
            : base(id, refPoint, color, sideLength, sideLength)
        {

        }
    }
}