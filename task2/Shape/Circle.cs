using System;

namespace task2
{
    class Circle : Shape
    {
        private double radius;
        public Circle(double radius)
        {
            this.radius = radius;
        }
        override public double Perimeter()
        {
            return 2 * Math.PI * this.radius;
        }
        override public double Area()
        {
            return Math.PI * Math.Pow(this.radius, 2);
        }
    }
}