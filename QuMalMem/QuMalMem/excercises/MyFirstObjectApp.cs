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

    class MyFirstObjectDemo
    {
        public static List<string> Demo()
        {
            List<string> output = new List<string>();

            Circle c = new Circle(new Point(3,5), 14);
            output.Add(c.ToString());
            output.Add("Diameter:" + c.Diameter);
            output.Add("Area:" + c.Area);
            //Console.ReadLine();

            Point p = new Point();


            Point p1 = new Point();
            Point p2 = new Point();

            output.Add("my first point is " + p1.ToString());
            output.Add("my second point is " + p2);

            p1.IncrementX();

            output.Add("first after increment x: " + p1);
            p1.IncrementX();
            p1.IncrementX();
            p1.IncrementX();
            p1.IncrementX();
            output.Add("first after more increments: " + p1);

            p2.SetCoords(2, 7);
            output.Add("p1:" + p1 + " p2:" + p2);

            Point p3 = new Point(5, 67);
            output.Add("p1:" + p1 + " p2:" + p2+ " p3:"+p3);


            Line myLine = new Line(p1, p3);
            output.Add("myLine is: " + myLine);
            p1.IncrementX();
            output.Add("myLine is: " + myLine);

            myLine.MoveX(-2);
            output.Add("myLine is: " + myLine);

            return output;
        }
    }
}
