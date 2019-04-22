using System;

namespace task6
{
    class Rational
    {
        private int numerator;
        private int divider;
        private int sign;

        public int itsDivider
        {
            get { return this.divider; }
        }

        public int itsNumerator
        {
            get { return this.numerator; }
        }

        public int itsSign
        {
            get { return this.sign; }
        }

        public Rational(int numerator = 1, int divider = 1, int sign = 1, bool reduce = true)
        {
            if (divider == 0) throw new DivideByZeroException();

            var (n, d) = (reduce) ? GCD.ReduceNumber(Math.Abs(numerator), Math.Abs(divider)) : (numerator, divider);

            this.numerator = n;
            this.divider = d;
            this.sign = sign;
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

        private static (Rational, Rational) GetNumbersWithSameDivider(Rational a, Rational b)
        {
            int commonDivider = a.divider * b.divider;
            return (new Rational(commonDivider / a.divider * a.numerator, commonDivider, a.sign, false), new Rational(commonDivider / b.divider * b.numerator, commonDivider, b.sign, false));
        }

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

        public static bool operator ==(Rational origin, Rational number) => origin.Equals(number);
        public static bool operator !=(Rational origin, Rational number) => !origin.Equals(number);
        public static bool operator >(Rational origin, Rational number)
        {
            Rational a, b;
            if (origin.sign < number.sign) return false;
            else if (origin.sign > number.sign) return true;
            (a, b) = Rational.GetNumbersWithSameDivider(origin, number);
            if (a.numerator > b.numerator) return (a.sign == 1) ? true : false;
            return false;
        }
        public static bool operator <(Rational origin, Rational number) => !(origin > number) && origin != number;
        public static bool operator >=(Rational origin, Rational number) => !(origin < number);
        public static bool operator <=(Rational origin, Rational number) => !(origin > number);

        public override bool Equals(object value)
        {
            Rational number = value as Rational;

            return !Object.ReferenceEquals(null, number)
                && String.Equals(this.sign, number.sign)
                && String.Equals(this.numerator, number.numerator)
                && String.Equals(this.divider, number.divider);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                const int HashingBase = (int)2166136261;
                const int HashingMultiplier = 16777619;

                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, this.sign) ? this.sign.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, this.numerator) ? this.numerator.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, this.divider) ? this.divider.GetHashCode() : 0);
                return hash;
            }
        }
    }
}
