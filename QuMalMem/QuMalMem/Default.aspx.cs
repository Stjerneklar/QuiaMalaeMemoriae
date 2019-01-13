using System;
using System.Web.UI;

namespace QuMalMem
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ListBoxResults.Items.Clear();
            ListBoxResults.DataSource = null;
            switch (ListBoxSCC.Text)
            {
                case "StoryTellerA":
                    ListBoxResults.DataSource = StoryTeller.StoryXDL.Allparts;
                    break;
                case "StoryTellerB":
                    ListBoxResults.DataSource = StoryTeller.StoryXDL.GetChoices(3, "quotes");
                    ListBoxResults.AutoPostBack = true;
                    break;
                case "StoryTellerC":
                    ListBoxResults.DataSource = StoryTeller.StoryXDL.OfType("myquotes");
                    break;
                case "BasicTypes":
                    ListBoxResults.DataSource = BasicTypes.Main("5");
                    break;
                case "CountryCodes":
                    ListBoxResults.DataSource = CountryCodeApp.Demo();
                    break;
                case "AbstractShapes":
                    ListBoxResults.DataSource = AbstractShapesCode.Demo();
                    break;
                case "BirdInheritance":
                    ListBoxResults.DataSource = BirdDemo.Demo();
                    break;
                case "Excercise1":
                    ListBoxResults.DataSource = Exercise.Program.Main();
                    break;
                case "MyFirstObject":
                    ListBoxResults.DataSource = MyFirstObjectApp.MyFirstObjectDemo.Demo();
                    break;
            }
            ListBoxResults.DataBind();
        }
        protected void ListBoxResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = ListBoxResults.SelectedIndex.ToString();

            foreach (StoryTeller.StoryPart sp in StoryTeller.StoryXDL.Allparts)
            {
                if (sp.Id == Int32.Parse(id))
                {
                    sp.TimesPicked++;
                }
            }
            StoryTeller.StoryXDL.UpdateAll();
        }
    }
}