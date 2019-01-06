using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuMalMem
{
    public class BasicTypes
    {
        //static void Main(string[] args)
        public static string Main(string numParam)
        {
            //Console.WriteLine("Hello World");
            //replaced with string output - also changed from void to string return, aaand made public
            string output = "Hello World";
            output += "<hr>";

            int a = 25;
            int b = 10;
            output += "a+b=" + a + b;
            output += "a+b=" + (a + b);
            output += "<hr>";

            string s = "My string is here and i can write anything :-)";
            output += "s=" + s;
            output += "<hr>";

            // double is a float with 64 bits  (unprecise decimal type)
            double d1 = 23d;
            double d2 = 23.5;
            double d3 = d1 * d2;

            output += "d1*d2=" + d1 + "*" + d2 + "=" + d3;
            output += "<hr>";

            // precise decimal type
            decimal de1 = 23m;
            decimal de2 = 23.5m;
            output += "de1*de2=" + de1 + "*" + de2 + "=" + (de1 * de2);
            output += "<hr>";

            bool b1 = true;
            bool b2 = false || b1; // Boolean OR
            bool b3 = b1 && b2; // boolean AND
            output += "b3=" + b3;
            output += "<hr>";

            double d = 723.8;
            int i1 = (int)d;
            output += "double " + d + " cast (int)=" + i1;
            output += "<hr>";
            int i2 = Convert.ToInt32(d);
            output += "double " + d + " Convert.ToInt32=" + i2;
            output += "<hr>";
            long i3 = Convert.ToInt64(d);
            output += "double " + d + " Convert.ToInt64=" + i3;
            output += "<hr>";

            output += "Give me a number I can test?";
            output += "<hr>";
            string numString = numParam;
            //string numString = Console.ReadLine();
            int num = Convert.ToInt32(numString);
            output += "Well, after extensive testing I found that:";
            output += "<hr>";
            if (num % 2 == 0)
            {
                output += num + " is an even number";
                output += "<hr>";
            }
            else
            {
                output += num + " is an odd number";
                output += "<hr>";
            }

            if (num > 0)
            {
                output += "and " + num + " is a positive number";
                output += "<hr>";
            }
            else if (num == 0)
            {
                output += "and " + num + " is ZERO";
                output += "<hr>";
            }
            else // not positive or zero => must be negative
            {
                output += "and " + num + " is a negative number";
                output += "<hr>";
            }

            return output;
            //            Console.WriteLine("Press any key to exit...");
            //          Console.ReadKey();

        }
    }
}