using System;

namespace task2
{
    class Rectangle : Shape
    {
        private double a;
        private double b;
        public Rectangle(double a, double b)
        {
            this.a = Math.Abs(a);
            this.b = Math.Abs(b);
        }
        override public double Perimeter()
        {
            return (a + b) * 2;
        }
        override public double Area()
        {
            return a * b;
        }
    }
}
