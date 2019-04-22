using System;

namespace task6
{
    class Program
    {
        static void Main(string[] args)
        {
            Rational r = new Rational(5, 2);
            Rational r1 = r + new Rational(1901, 132);
            Rational r2 = r - new Rational(5, 2);
            Rational r3 = r * new Rational(5, 2);
            Rational r4 = r / new Rational(100, 78);
        }
    }
}
