using System;
using System.Web.UI;

namespace QuMalMem
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (DropDownSCC.Text)
            {
                case "BasicTypes":
                    LiteralResults.Text = BasicTypes.Main("5");
                    break;
                case "CountryCodes":
                    ListBoxResults.DataSource = CountryCodeApp.Demo();
                    ListBoxResults.DataBind();
                    break;
                default:
                    break;
            }            
        }
    }
}