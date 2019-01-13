using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuMalMem
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public int RngBackgroundNumber()
        {
            List<int> Lint = new List<int>() { 1,2,3,4,5,6,7,8,9,10 };

            StoryTeller.Shuffle(Lint);

            return Lint.First();
        }
    }
}