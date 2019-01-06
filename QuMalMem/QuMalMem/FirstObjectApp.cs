using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstObjectApp
{
    class Point
    {
        private int x;
        private int y;

        public Point()
        {
            this.x = 0;
            this.y = 0;
        }

        public Point(int xCoord, int yCoord)
        {
            this.x = xCoord;
            this.y = yCoord;
        }

        public Point(Point p)
        {
            this.x = p.x;
            this.y = p.y;
        }

        public void SetCoords(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void IncrementX()
        {
            x++;
        }

        public void MoveX(int i)
        {
            // this.x += i;
            this.x = this.x + i;
        }
        public void MoveY(int i)
        {
            this.y = this.y + i;
        }

        public void Add(Point p)
        {
            this.MoveX(p.x);
            this.MoveY(p.y);
        }


        public override string ToString()
        {
            return "(" + x + "," + y + ")";
        }
    }
    class Circle
    {
        public Point Center { get; set; }
        public int Radius { get; set; }

        public int Diameter
        {
            get { return GetDiameter(); }
        }

        public double Area
        {
            get { return GetArea(); }
        }

        public Circle(Point center, int radius)
        {
            this.Center = center;
            this.Radius = radius;
        }

        private int GetDiameter()
        {
            return 2 * Radius;
        }

        private double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override string ToString()
        {
            return "Circle" + Center + "r" + Radius;
        }
    }
    class Line
    {
        private Point a;
        private Point b;

        public Line(Point aPoint, Point anotherPoint)
        {
            this.a = aPoint;
            this.b = anotherPoint;
            // this.a = new Point(aPoint);
            //this.b = new Point(anotherPoint);
        }

        public void MoveX(int i)
        {
            this.a.MoveX(i);
            this.b.MoveX(i);
        }

        public override string ToString()
        {
            return a + "<-line->" + b;
        }
    }
}
