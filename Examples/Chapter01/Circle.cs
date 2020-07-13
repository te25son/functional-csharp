using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Chapter01
{
    using static System.Math;

    public class Circle
    {
        public Circle(double radius) 
            => Radius = radius;

        public double Radius { get; }  // public get-only field that can only be declared in the constructor.

        public double Circumference
            => PI * 2 * Radius;

        public double Area
        {
            get
            {
                double Square(double d) => Pow(d, 2);  // Uses local function.
                return PI * Square(Radius);
            }
        }

        public (double Circumference, double Area) Stats
            => (Circumference, Area);
    }
}
