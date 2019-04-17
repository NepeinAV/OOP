using System;

namespace task3
{
    class Rational
    {
        private int numerator;
        private int divider;
        private int sign;

        public int itsDivider
        {
            get { return this.divider; }
            set { this.divider = value; }
        }

        public int itsNumerator
        {
            get { return this.numerator; }
            set { this.numerator = value; }
        }

        public int itsSign
        {
            get { return this.sign; }
            set { this.sign = value; }
        }

        public Rational(int numerator = 1, int divider = 1)
        {
            if (divider == 0) throw new DivideByZeroException();

            var (n, d) = GCD.ReduceNumber(Math.Abs(numerator), Math.Abs(divider));

            this.numerator = n;
            this.divider = d;
            this.sign = (numerator * divider >= 0) ? 1 : -1;
        }

        public void Display()
        {
            Console.WriteLine(String.Format("{0}{1}", this.numerator * this.sign, (this.numerator == 0 || this.numerator == 1) ? "" : "/" + this.divider));
        }

        public void DisplayDouble()
        {
            Console.WriteLine((double)(this.numerator * this.sign) / this.divider);
        }

        public double GetDouble() => (double)(this.numerator * this.sign) / this.divider;

        public static Rational operator +(Rational origin, Rational number)
        {
            int CN = origin.itsDivider;
            if (origin.itsDivider != number.itsDivider) CN = origin.itsDivider * number.itsDivider;

            int n = origin.itsSign * origin.itsNumerator * (CN / origin.itsDivider) + number.itsSign * number.itsNumerator * (CN / number.itsDivider);

            return new Rational(n, CN);
        }

        public static Rational operator -(Rational origin, Rational number) => origin + new Rational(-number.itsNumerator, number.itsDivider);

        public static Rational operator *(Rational origin, Rational number)
        {
            int n = origin.itsSign * origin.itsNumerator * number.itsSign * number.itsNumerator;
            int d = origin.itsDivider * number.itsDivider;

            return new Rational(n, d);
        }

        public static Rational operator /(Rational origin, Rational number) => origin * new Rational(number.itsDivider, number.itsNumerator);
    }
}
