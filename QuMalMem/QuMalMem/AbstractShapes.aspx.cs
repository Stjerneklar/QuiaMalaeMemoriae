using System;

namespace QuMalMem
{
    public partial class AbstractShapes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Point p = new Point(4, 23);
            ListBox1.Items.Add(p.ToString());

            Shape s = new Rectangle("A", new Point(3, 4), "Green", 3, 2);
            ListBox1.Items.Add(s.ToString());

            Shape s2 = new Square("B", new Point(2, 4), "Yellow", 10);
            ListBox1.Items.Add(s2.ToString());
        }
    }
}