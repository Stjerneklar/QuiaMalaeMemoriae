﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    public class Program
    {
        public static List<string> Main() //args param removed due to lack of use
        {
            List<string> output = new List<string>();
            
            output.Add("plus operator: " + Math.Add(2, 3));
            Console.WriteLine("div operator: " + Math.Divide(2, 3));

            Book b1 = new Book( // example with publisher given
                "Programming C# 3.0", 
                "Jesse Liberty and Donald Xie",
                "9780596527433",
                "O’Reilly");
            Book b2 = new Book( // no publisher given
                "C# 3.0 In a Nutshell", 
                "Joseph Albahari and Ben Albahari", 
                "9780596527570");

            output.Add( b1.DisplayBook() );
            output.Add( b2.DisplayBook() );

            b1.Author = "Peter";
            // b1.Title = "asdf";

            //b1.DisplayBook()
            output.Add( b1.DisplayBook() );

            output.Add("Book1 title: "+b1.Title);

            return output;

        }
    }
    class Book
    {
        public string Title { get; private set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Isbn { get; set; }

        public Book(string title, string author, string isbn)
        {
            this.Author = author;
            this.Title = title;
            this.Isbn = isbn;
            this.Publisher = "O'Reilly";
        }
        public Book(string title, string author, string isbn, string publisher)
        {
            this.Author = author;
            this.Title = title;
            this.Isbn = isbn;
            this.Publisher = publisher;
        }

        public string DisplayBook()
        {
            //Console.WriteLine(this.ToString());
            return this.ToString();
        }

        public override string ToString()
        {
            return Title + " : " + Author + " : " + Publisher + " : " + Isbn;
        }
    }
    class Math
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }
        public static int Subtract(int a, int b)
        {
            return a - b;
        }
        public static int Multiply(int a, int b)
        {
            return a * b;
        }
        public static double Divide(int a, int b)
        {
            return a / (double)b;
        }

    }
}
