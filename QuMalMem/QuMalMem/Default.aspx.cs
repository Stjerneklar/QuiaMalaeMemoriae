using System;
using System.Web.UI;

namespace QuMalMem
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //reset
            LiteralResults.Text = "";
            ListBoxResults.Items.Clear();
            switch (DropDownSCC.Text)
            {
                case "BasicTypes":
                    LiteralResults.Text = BasicTypes.Main("5");
                    break;
                case "CountryCodes":
                    ListBoxResults.DataSource = CountryCodeApp.Demo();
                    ListBoxResults.DataBind();
                    break;
                case "AbstractShapes":
                    ListBoxResults.DataSource = AbstractShapesCode.Demo();
                    ListBoxResults.DataBind();
                    break;
                case "BirdInheritance":
                    ListBoxResults.DataSource = BirdDemo.Demo();
                    ListBoxResults.DataBind();
                    break;
                case "Excercise1":
                    ListBoxResults.DataSource = Exercise.Program.Main();
                    ListBoxResults.DataBind();
                    break;
                case "MyFirstObject":
                    ListBoxResults.DataSource = MyFirstObjectApp.MyFirstObjectDemo.Demo();
                    ListBoxResults.DataBind();
                    break;
            }            
        }
    }
}