using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuMalMem
{
    public class ConsoleApp1
    {
        //static void Main(string[] args)
        public static string BasicTypes(string numParam)
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
        public static string CountryCode(string conCode)
        {
            conCode = conCode.ToLower();

            string country; 
            
            switch (conCode)
            {
                case "dk":
                    country = "Denmark";
                    break;
                case "se":
                    country = "Sweden";
                    break;
                case "no":
                    country = "Norway";
                    break;
                default:
                    country = "unknown";
                    break;
            }

            //needs to be after the switch since it no longer breaks a while
            //resulting in "contry" becoming "unknown" rather than "exit"
            //and causing errors due to the expectation of a break at "exit" (see codebehind)

            if (conCode == "exit")
            {
                country = "exit";
            }
            return country;
        }

        //alternative 1 - simplified copy of example
        public static string CountryCodeASKW(string conCode)
        {
            conCode = conCode.ToLower(); //ensure lowercase parameter

            switch (conCode)
            {
                case "exit":
                    conCode = "exit";
                    break;
                case "dk":
                    conCode = "Denmark";
                    break;
                case "se":
                    conCode = "Sweden";
                    break;
                case "no":
                    conCode = "Norway";
                    break;
                default:
                    conCode = "unknown";
                    break;
            }
            return conCode;
        }

        //alternative 2 - replaces previously external(aspx codebehind) while loop with a in-method foreach loop
        //by taking an array of strings. also uses the string version of "itself" - seems pretty neat. 
        //in alt1 we stop calling the method when we get an exit result. here, we stop adding results to the return string.
        public static string CountryCodeASKW(string[] CountryCodes)
        {
            string output ="";
            foreach (string code in CountryCodes)
            {
                string result = CountryCodeASKW(code);//might as well reuse string version of method, no repeated code
                output += result; 
                if (result == "exit") { break; }
            }
            return output;
        }

        //alternative 3 - using a list to output in order to have better access to output values.
        public static string CountryCodeASKW(List<string> CountryCodes)
        {
            List<string> output = new List<string>();   

            foreach (string code in CountryCodes)
            {
                output.Add(CountryCodeASKW(code));
                if (output.Last() == "exit") { break; } //stop adding if the last item added was "exit"
            }
            return String.Join(",",output);               // more info:https://stackoverflow.com/questions/3575029/c-sharp-liststring-to-string-with-delimiter
        }

     //sooo, we dont even need the foreach do we? - wait yeah we fucking do, we need to run the country code.
     //...we could filter match or something?... well okay its still kinda clever, i just gotta stop believing in magic.
     //we can avoid needing to worry about the "exit" logic like so:
            
        //alternative 4 - seperating the conversion of code to country name and the output logic
        public static string CountryCodeASKW2(List<string> CountryCodes)
        {
            List<string> output = new List<string>();

            foreach (string code in CountryCodes)
            {
                output.Add(CountryCodeASKW(code));
            }
            return String.Join(",", output.GetRange(0,output.IndexOf("exit")+1)); //effectively truncates list after "exit"
            //by returning a string of the outputs from the start(0) to the one with the value exit(really its index), joined with commas 
        }
    }
}