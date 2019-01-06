using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterfacePlay
{
    public interface ISuperSortable
    {
        int CompareItems(Object obj);
    }
    public class Car : ISuperSortable
    {
        public string Brand { get; set; }
        public int NumOfWheels { get; set; }
        public int MaxSpeed { get; set; }

        public Car(string brand, int numberOfWheels, int maxSpeed)
        {
            Brand = brand;
            NumOfWheels = numberOfWheels;
            MaxSpeed = maxSpeed;
        }

        public int CompareItems(object obj)
        {
            return MaxSpeed - ((Car)obj).MaxSpeed;
        }

        public override string ToString()
        {
            return Brand + " (" + NumOfWheels + " wheels - " + MaxSpeed + " km/h)";
        }
    }
    public class Person : ISuperSortable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }

        public Person(string name, int age, int height)
        {
            Name = name;
            Age = age;
            Height = height;
        }

        public override string ToString()
        {
            return Name + " age " + Age + " is " + Height + "cm";
        }

        public int CompareItems(object obj)
        {
            if (Height > ((Person)obj).Height)
            {
                return 1; // this is the largest
            }
            else if (Height == ((Person)obj).Height)
            {
                return 0; // identical
            }
            else
            {
                return -1; // other is the largest
            }
        }
    }
    public class Util
    {

        // bubblesort
        public static void BubbleSort(ISuperSortable[] iso)
        {
            ISuperSortable swop;
            for (int i = iso.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (iso[j].CompareItems(iso[j + 1]) > 0)
                    {
                        swop = iso[j];
                        iso[j] = iso[j + 1];
                        iso[j + 1] = swop;
                    }
                }
            }
        }

    }
}