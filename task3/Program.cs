using System;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Rational r = new Rational(1, 2);

            Rational r1 = r + new Rational(1901, 132);
            Test.isEquals(
                r1.GetDouble(),
                (r.itsSign * r.itsNumerator / (double)r.itsDivider) + (1901 / 132.0)
            );

            Rational r2 = r - new Rational(5, 2);
            Test.isEquals(r2.GetDouble(), (r.itsSign * r.itsNumerator / (double)r.itsDivider) - (5 / 2.0));

            Rational r3 = r * new Rational(5, 2);
            Test.isEquals(r3.GetDouble(), (r.itsSign * r.itsNumerator / (double)r.itsDivider) * (5 / 2.0));

            Rational r4 = r / new Rational(100, 78);
            Test.isEquals(r4.GetDouble(), (r.itsSign * r.itsNumerator / (double)r.itsDivider) / (100 / 78.0));
        }
    }
}
