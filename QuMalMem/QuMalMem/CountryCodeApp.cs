using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuMalMem
{
    public class CountryCodeApp
    {
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


        //all this navigation is dumb, lets just have a method that executes the example, adds that to results and lists it for a listbox
        //should be possible in most cases
        public static List<string> Demo()
        {
            List<string> output = new List<string>();

            //basics: 
            output.Add(CountryCodeApp.CountryCode("dk"));
            output.Add(CountryCodeApp.CountryCode("Dk")); //also works since we lowercase inputs 

            output.Add("");

            string[] cCodes = new string[4] { "se", "no", "EXIT", "ru" };

            //CountryCode app simulation using array instead of user input. should never output "unknown" on the "ru" 

            //Close copy of example - dosent work for unknown reason - expected return value of exit never given?

            int i = 0;
            while (true)
            {
                string result = CountryCodeApp.CountryCodeASKW(cCodes[i]);

                if (result == "exit")
                {
                    output.Add( CountryCodeApp.CountryCode(cCodes[i]));
                    break;
                }
                else
                {
                    output.Add( CountryCodeApp.CountryCode(cCodes[i]));
                    i++;
                }
            }

            output.Add( "alt 1:");

            //CountryCode Working alternative implementation
            foreach (string cString in cCodes)
            {
                string result = CountryCodeApp.CountryCodeASKW(cString);
                output.Add(result);
                if (result == "exit")
                {
                    break;
                }
            }

            output.Add( "alt 2:");

            //CountryCode 2nd alternative implementation using string array overload 
            output.Add( CountryCodeApp.CountryCodeASKW(cCodes));

            output.Add( "alt 3:");

            //CountryCode 3rd alternative implementation using list of strings made from the existing string array
            output.Add( CountryCodeApp.CountryCodeASKW(new List<string>(cCodes)));

            output.Add( "alt 4:");
            output.Add( CountryCodeApp.CountryCodeASKW2(new List<string>(cCodes)));

            return output;
        }
    }
}