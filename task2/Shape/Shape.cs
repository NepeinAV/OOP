using System;

namespace task2
{
    abstract class Shape
    {
        abstract public double Perimeter();
        abstract public double Area();
        public virtual void Display()
        {
            Console.WriteLine(String.Format("Периметр: {0}\nПлощадь: {1}\n", this.Perimeter(), this.Area()));
        }
    }
}
