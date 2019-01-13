using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuMalMem
{
    public class BasicTypes
    {
        //static void Main(string[] args)
        public static List<string> Main(string numParam)
        {
            //Console.WriteLine("Hello World");
            //replaced with string output - also changed from void to string return, aaand made public
            List<string> output = new List<string>();
            output.Add( "<hr>");

            int a = 25;
            int b = 10;
            output.Add( "a+b=" + a + b);
            output.Add( "a+b=" + (a + b));
            output.Add( "<hr>");

            string s = "My string is here and i can write anything :-)";
            output.Add( "s=" + s);
            output.Add( "<hr>");

            // double is a float with 64 bits  (unprecise decimal type)
            double d1 = 23d;
            double d2 = 23.5;
            double d3 = d1 * d2;

            output.Add( "d1*d2=" + d1 + "*" + d2 + "=" + d3);
            output.Add( "<hr>");

            // precise decimal type
            decimal de1 = 23m;
            decimal de2 = 23.5m;
            output.Add( "de1*de2=" + de1 + "*" + de2 + "=" + (de1 * de2));
            output.Add( "<hr>");

            bool b1 = true;
            bool b2 = false || b1; // Boolean OR
            bool b3 = b1 && b2; // boolean AND
            output.Add( "b3=" + b3);
            output.Add( "<hr>");

            double d = 723.8;
            int i1 = (int)d;
            output.Add( "double " + d + " cast (int)=" + i1);
            output.Add( "<hr>");
            int i2 = Convert.ToInt32(d);
            output.Add( "double " + d + " Convert.ToInt32=" + i2);
            output.Add( "<hr>");
            long i3 = Convert.ToInt64(d);
            output.Add( "double " + d + " Convert.ToInt64=" + i3);
            output.Add( "<hr>");

            output.Add( "Give me a number I can test?");
            output.Add( "<hr>");
            string numString = numParam;
            //string numString = Console.ReadLine();
            int num = Convert.ToInt32(numString);
            output.Add( "Well, after extensive testing I found that:");
            output.Add( "<hr>");
            if (num % 2 == 0)
            {
                output.Add( num + " is an even number");
                output.Add( "<hr>");
            }
            else
            {
                output.Add( num + " is an odd number");
                output.Add( "<hr>");
            }

            if (num > 0)
            {
                output.Add( "and " + num + " is a positive number");
                output.Add( "<hr>");
            }
            else if (num == 0)
            {
                output.Add( "and " + num + " is ZERO");
                output.Add( "<hr>");
            }
            else // not positive or zero => must be negative
            {
                output.Add( "and " + num + " is a negative number");
                output.Add( "<hr>");
            }

            return output;
            //            Console.WriteLine("Press any key to exit...");
            //          Console.ReadKey();

        }
    }
}