using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Xsl;

namespace QuMalMem
{
    public static class StoryTeller
    {
        private static Random rng = new Random();

        //stackoverflow code to shuffle a list... any list i guess since it seems to just find out its type using "this"? - research
        private static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        /* cba with public/private right now, just making xmldatalayer public
        public static string Tellit()
        {
            return string.Join(", ",XmlDataLayer.LoadParts());
        }
        */
        public static class XmlDataLayer 
        {
            //prototype example - i kinda feel like trying to set up a list that just has all parts and seeing how working with that would be in comparison
            public static List<Storypart> LoadParts(string typeofparts)
            {
                List<Storypart> Parts = new List<Storypart>();
                if (File.Exists(HttpContext.Current.Server.MapPath("~/Content/DB.xml"))) 
                {
                    // Loading XML from a file with LINQ
                    XElement root = XElement.Load(HttpContext.Current.Server.MapPath("~/Content/DB.xml"));

                    IEnumerable<XElement> selector =
                        from el in root.Elements("StoryPart")
                        where (string)el.Attribute("type") == typeofparts
                        select el;
                    //"deserialize" xml nodes into our objects, putting them in a list. (is this really deserialization? seems only to be in spirit)
                    foreach (XElement el in selector)
                    {
                        Parts.Add(new Storypart(
                                    (int)el.Attribute("id"), 
                                    (string)el.Attribute("value"), 
                                    (string)el.Attribute("type"), 
                                    (int)el.Attribute("picked"), 
                                    (int)el.Attribute("pickable"))
                                );
                    }
                }
                else {
                    //do some error handling for the missing xml - could just create a new file with a placeholder/error message storypart....
                    // - maybe just the new file part otherwise we're using data for logic
                }

                return Parts;
            }                  

            //second iteration - list manipulation instead of data selection/query/where to eg get parts by type.
            public static List<Storypart> PartsByType(string typeofpart) //filter master parts list down to those of the requested type
            {
                List<Storypart> Parts = new List<Storypart>(
                    Allparts.FindAll(
                        storypart => storypart.spType.Contains(typeofpart)
                        )
                );
                return Parts;
            }

        }

        private static List<Storypart> Allparts = AllpartsGetter();   //like that i guess @ the line below. [went from using what is now allpartsgetter (theoretically) each time, to get it once... i think atleast? okay toot ired.
                                                                      //get all our data, filter it later    -   having it read from xml each time seems wasteful though, what i want is a shared representation of this...
        private static List<Storypart> AllpartsGetter()
        {
            List<Storypart> Parts = new List<Storypart>();

            XElement root = XElement.Load(HttpContext.Current.Server.MapPath("~/Content/DB.xml"));

            IEnumerable<XElement> selector = from el in root.Elements("StoryPart") select el;

            foreach (XElement el in selector)
            {
                Parts.Add(new Storypart(
                    (int)el.Attribute("id"),
                    (string)el.Attribute("value"),
                    (string)el.Attribute("type"),
                    (int)el.Attribute("picked"),
                    (int)el.Attribute("pickable"))
                    );
            }
            return Parts;
        }

        public class Storypart
        {
            public int id;
            public string spValue;
            public string spType;
            public int timesPicked;
            public int timesPickable;
            public int timesNotPicked;

            public Storypart(int id, string spValue, string spType, int timesPicked, int timesPickable)
            {
                this.id = id;
                this.spValue = spValue;
                this.spType = spType;
                this.timesPicked = timesPicked;
                this.timesPickable = timesPickable;
                this.timesNotPicked = this.timesPickable - this.timesPicked; // remember that properties can be based on other properties
            }
            /*
            public Storypart(int ID)
            {
                DAL.StorypartsDataTable storyparts = spData.GetDataById(ID);

                this.id = int.Parse(storyparts[0]["ID"].ToString());
                this.spValue = storyparts[0]["spValue"].ToString();
                this.spType = storyparts[0]["spType"].ToString();
                this.timesPicked = int.Parse(storyparts[0]["timesPicked"].ToString());
                this.timesPickable = int.Parse(storyparts[0]["timesRolled"].ToString());
                this.timesNotPicked = this.timesPickable - this.timesPicked
            }
           

            //dude, fuck giving objects dedicated methods just to change a value like inc viewcount - you have the object, the object can be changed, after which you update everything about the object - no need to run in circles
            
            public void Update()
            {
                spData.Update(this.spValue, this.spType, this.timesPicked, this.timesPickable, this.id, this.id);
            }

            //should work like this if i wanted to replace one item with another
            public void Replace(int IDtoReplace)
            {
                spData.Update(this.spValue, this.spType, this.timesPicked, this.timesPickable, IDtoReplace, this.id);
            }

            //get a randomized list of a specified @length, of SPs of a @type  
            public static string StorypartsTypeListChoices(int listlength, string type)
            {
                List<Storypart> StorypartList = new List<Storypart>();

                foreach (DAL.StorypartsRow row in spData.GetDataByType(type))
                {
                    Storypart readStorypart = new Storypart(row.id, row.spValue, row.spType, row.timesPicked, row.timesRolled);
                    StorypartList.Add(readStorypart);
                }
                //randomize list
                StorypartList.Shuffle();
                StorypartList.Take(3);

                return WebSpinner(StorypartList);
            }
                         */
            //essentaily a custom tostring or that but with a list 
            private static string WebSpinner(List<Storypart> StoryPartsList)
            {
                string DatStringDoe = "";
                if (StoryPartsList.Count == 0) { DatStringDoe = "invalid spType, probably"; }

                foreach (Storypart storypart in StoryPartsList) { DatStringDoe += storypart.ToHtml(); }

                return DatStringDoe;
            }

            public string ToHtml()
            {
                string output = "<a href = '#'class='StoryPart type-" + this.spType + "'><span>";
                output += this.spValue;
                output += "</span></a>";
                return output;
            }
            public override string ToString()
            {
                return this.spValue;
            }

        }
        // also need a system for including storyparts within storyparts, symbol-key filter looping kinda shit[.join?]
    }
}