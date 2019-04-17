using System;

namespace task2
{
    class Triangle : Shape
    {
        private double a;
        private double b;
        private double c;
        public Triangle(double a, double b, double c)
        {
            this.a = Math.Abs(a);
            this.b = Math.Abs(b);
            this.c = Math.Abs(c);
        }
        private bool isPossible(double a, double b, double c) => (a + b > c && a + c > b && b + c > a);
        override public double Perimeter()
        {
            return a + b + c;
        }
        override public double Area()
        {
            double p = (a + b + c) / 2;
            double h = 2 / a * Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return (a * h) / 2;
        }

        override public void Display()
        {
            if (this.isPossible(a, b, c))
            {
                Console.WriteLine(String.Format("Периметр: {0}\nПлощадь: {1}\n", this.Perimeter(), this.Area()));

            }
            else
            {
                Console.WriteLine(String.Format("Треугольник со сторонами {0}, {1}, {2} не существует\n", a, b, c));
            }
        }
    }
}
