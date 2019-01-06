using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuMalMem
{
    public partial class ConsoleApp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //basics: 
            literal1.Text += CountryCodeApp.CountryCode("dk");
            literal1.Text += CountryCodeApp.CountryCode("dK"); //also works since we lowercase inputs 

            literal1.Text += "<hr>";

            string[] cCodes = new string[4] { "se", "no", "EXIT", "ru" };

            //CountryCode app simulation using array instead of user input. should never output "unknown" on the "ru" 

            //Close copy of example - dosent work for unknown reason - expected return value of exit never given?
            
            int i = 0;
            while (true)
            {
                string result = CountryCodeApp.CountryCodeASKW(cCodes[i]);

                if (result == "exit")
                {
                    literal1.Text += CountryCodeApp.CountryCode(cCodes[i]);
                    break;
                }
                else
                {
                    literal1.Text += CountryCodeApp.CountryCode(cCodes[i]);
                    i++;
                }
            }           

            literal1.Text += "<hr>alt 1:<hr>";

            //CountryCode Working alternative implementation
            foreach (string cString in cCodes)
            {
                string result = CountryCodeApp.CountryCodeASKW(cString);
                literal1.Text += result;
                if (result == "exit") {
                    break;                    
                }
            }

            literal1.Text += "<hr>alt 2:<hr>";

            //CountryCode 2nd alternative implementation using string array overload 
            literal1.Text += CountryCodeApp.CountryCodeASKW(cCodes);

            literal1.Text += "<hr>alt 3:<hr>";

            //CountryCode 3rd alternative implementation using list of strings made from the existing string array
            literal1.Text += CountryCodeApp.CountryCodeASKW(new List<string>(cCodes));

            literal1.Text += "<hr>alt 4:<hr>";
            literal1.Text += CountryCodeApp.CountryCodeASKW2(new List<string>(cCodes));
        }
    }
}