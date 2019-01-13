using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.Xsl;

namespace QuMalMem
{
    public static class StoryTeller
    {
        public static Random rng = new Random(); //random number

        public static void Shuffle<T>(this IList<T> list)
        { //shuffle a passed list
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

        public class StoryPart
        {
            public int Id { get; set; }
            public string SpValue { get; set; }
            public string SpType { get; set; }
            public int TimesPicked { get; set; }
            public int TimesPickable { get; set; }
            public int TimesNotPicked { get; set; }

            public StoryPart() { } //needed for serialization, unsure why tbh

            public StoryPart(int id, string spValue, string spType, int timesPicked, int timesPickable)
            { //the normal constructor
                this.Id = id;
                this.SpValue = spValue;
                this.SpType = spType;
                this.TimesPicked = timesPicked;
                this.TimesPickable = timesPickable;
                this.TimesNotPicked = this.TimesPickable - this.TimesPicked; // remember that properties can be based on other properties
            }            

            // create new - only needs value and type since we calculate id and the times start at 0
            // needs exception handling for the Id calc tho - if Allparts had nothing in it this would fail
            public StoryPart(string spValue, string spType)
            {
                //https://stackoverflow.com/questions/3309188/how-to-sort-a-listt-by-a-property-in-the-object
                StoryXDL.Allparts.Sort((x, y) => x.Id.CompareTo(y.Id));
                
                this.Id = StoryXDL.Allparts.Last().Id + 1; //homebodged autoincrement
                this.SpValue = spValue;
                this.SpType = spType;
                this.TimesPicked = 0;
                this.TimesPickable = 0;
                this.TimesNotPicked = 0;
            }

            public override string ToString() { return this.SpValue; } // mainly done for easy display in a listbox atm            

            public string ToHtml()
            {
                return "<a href = '#'class='StoryPart type-" + this.SpType + "'><span>" + this.SpValue + "</span></a>";
            }
        }

        public static class StoryXDL
        {
            public static List<StoryPart> LoadAllParts() // LoadAllParts - Deserializing XML with LINQ
            {   
                XElement root = XElement.Load(HttpContext.Current.Server.MapPath("~/Content/DB.xml"));

                IEnumerable<XElement> selector =
                    from el in root.Elements("StoryPart")
                        // where (string)el.Attribute("type") == typeofparts 
                    select el;

                List<StoryPart> Parts = new List<StoryPart>();
                foreach (XElement el in selector)
                {
                    Parts.Add(new StoryPart(
                                (int)el.Element("Id"),
                                (string)el.Element("SpValue"),
                                (string)el.Element("SpType"),
                                (int)el.Element("TimesPicked"),
                                (int)el.Element("TimesPickable"))
                            );
                }
                return Parts;
            }

            public static void UpdateAll() // Serialize all StoryParts to XML and save on server
            {  
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(Allparts.Serialize());

                XmlWriterSettings settings = new XmlWriterSettings { Indent = true };
                string filelocation = HttpContext.Current.Server.MapPath("~/Content/DB.xml");

                XmlWriter writer = XmlWriter.Create(filelocation, settings);
                doc.Save(writer);
                writer.Close(); //otherwise update fails second time
            }

            public static List<StoryPart> Allparts = StoryXDL.LoadAllParts();

            public static List<StoryPart> OfType(string spType) { return Allparts.FindAll(StoryPart => StoryPart.SpType.Contains(spType)); }

            public static StoryPart ById(int ID) { return Allparts.Find(StoryPart => StoryPart.Id.Equals(ID)); }

            public static List<StoryPart> GetChoices(int listlength, string type) //get a randomized list of a specified @length, of SPs of a @type 
            {
                List<StoryPart> StoryPartList = new List<StoryPart>(OfType(type));
                StoryPartList.Shuffle();

                return StoryPartList.GetRange(0, listlength);
            }

            public static List<string> GetChoicesHTML(int listlength, string type) //get a randomized list of a specified @length, of SPs of a @type 
            {
                List<StoryPart> StoryPartList = new List<StoryPart>(OfType(type));
                List<string> output = new List<string>();

                output.Shuffle();

                foreach (StoryPart StoryPart in StoryPartList)
                {
                    output.Add(StoryPart.ToHtml());
                }

                return output.GetRange(0, listlength);
            }
        }

        public static string Serialize<T>(this T value)  //with try/catch for improved debugging aka exception handling
        { 
            if (value == null) { return string.Empty; }
            try
                {
                    var xmlserializer = new XmlSerializer(typeof(T));
                    var stringWriter = new StringWriter();
                    using (var writer = XmlWriter.Create(stringWriter))
                    {
                        xmlserializer.Serialize(writer, value);
                        return stringWriter.ToString();
                    }
                }
            catch (Exception ex) { throw new Exception("An error occurred", ex);}
        }
    }
}
