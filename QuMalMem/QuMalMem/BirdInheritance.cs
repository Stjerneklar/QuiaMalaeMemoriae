using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuMalMem
{
    public static class BirdDemo
    {
        public static List<string> Demo() //equivalent to page_load
        {
            List<string> output = new List<string>();

            Bird b1 = new Bird("sparrow", "green");
            Songbird b2 = new Songbird("Nightinggale", "brown", 5);
            output.Add(b1.ToString());
            output.Add(b2.ToString());

            Bird b3 = new Songbird("Canarrie", "Yellow", 2);
            output.Add(b3.SayTweet());
            output.Add(((Songbird)b3).NumberOfSongs.ToString());

            Owl b4 = new Owl("Snowowl", "White");

            output.Add(b4.ToString());
            b4.ChangeColor("Green");
            output.Add(b4.ToString());

            return output;
        }
    }

    public class Bird
    {
        private string species;
        private string color;

        public string Species
        {
            get { return species; }
            private set { species = value; }
        }

        public string Color
        {
            get { return color; }
            protected set { color = value; }
        }

        public Bird(string species, string color)
        {
            this.Species = species;
            this.Color = color;
        }

        public virtual string SayTweet()
        {
            return "chirp chirp";
        }

        public override string ToString()
        {
            return "The " + Species + " is " + Color + " and it tweets " + SayTweet();
        }
    }

    public class Owl : Bird
    {
        public int NumOfMiceCaught { get; private set; }

        public Owl(string species, string color) : base(species, color)
        {
            NumOfMiceCaught = 0;
        }

        public void ChangeColor(string newColor)
        {
            this.Color = newColor;
        }
    }

    public class Songbird : Bird
    {
        private int numberOfSongs;

        public int NumberOfSongs
        {
            get { return numberOfSongs; }
            set { numberOfSongs = value; }
        }

        public Songbird(string species, string color, int numberOfSongs)
            : base(species, color)
        {
            this.NumberOfSongs = numberOfSongs;
        }

        public override string SayTweet()
        {
            return "sing sing singeling";
        }

        public string CallTheParentToString()
        {
            return base.ToString();
        }

        public override string ToString()
        {
            return base.ToString() + " and it knows " + NumberOfSongs + " songs";
        }
    }
}