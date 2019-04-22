using System;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;

namespace task7
{
    class Polinomials
    {
        private double[] _numbers;

        public Polinomials(double[] numbers)
        {
            List<double> n = numbers.ToList();

            int i = n.Count - 1;
            while (i > 0 && n[i] == 0)
            {
                n.RemoveAt(i);
                i = n.Count - 1;
            }

            this._numbers = n.ToArray();
        }

        public double[] Numbers
        {
            get { return this._numbers; }
        }

        public int Length
        {
            get { return this._numbers.Length; }
        }

        ~Polinomials()
        {

        }

        public override string ToString()
        {
            if (this.Length == 1 && this._numbers[0] == 0) return "0";

            string result = "";
            bool first = true;
            string pattern = " + 0.##; - 0.##";
            for (int i = _numbers.Length - 1; i >= 0; i--)
            {
                if (_numbers[i] == 0) continue;
                result += String.Format((i == 0) ? "{0}" : "{0}x^{1}", _numbers[i].ToString((first) ? "" : pattern), i);
                first = false;
            }

            return result;
        }

        public static Polinomials operator +(Polinomials a, Polinomials b)
        {
            int minLength = Math.Min(a.Length, b.Length);
            int maxLength = Math.Max(a.Length, b.Length);

            List<double> n = new List<double>();

            for (int i = 0; i < minLength; i++)
            {
                n.Add(a._numbers[i] + b._numbers[i]);
            }

            double[] bigger = a._numbers;
            if (a.Length < b.Length) bigger = b._numbers;
            n.AddRange(bigger.Skip(minLength).Take(maxLength - minLength));

            return new Polinomials(n.ToArray());
        }

        public static Polinomials operator -(Polinomials a, Polinomials b)
        {
            Polinomials newB = new Polinomials(b._numbers.Select(x => -x).ToArray());
            return a + newB;
        }

        public static Polinomials operator *(Polinomials a, Polinomials b)
        {
            int n = 1;
            while (n < Math.Max(a.Length, b.Length)) n <<= 1;
            n <<= 1;

            double[] res = new double[n];
            Complex[] p1 = a.Numbers.Select(x => new Complex(x, 0)).ToArray(); Array.Resize<Complex>(ref p1, n);
            Complex[] p2 = b.Numbers.Select(x => new Complex(x, 0)).ToArray(); Array.Resize<Complex>(ref p2, n);

            Fourier.FFT(ref p1, false);
            Fourier.FFT(ref p2, false);

            for (int i = 0; i < n; i++) p1[i] *= p2[i];

            Fourier.FFT(ref p1, true);

            for (int i = 0; i < n; i++) res[i] = Math.Round((p1[i].Real), 2);

            return new Polinomials(res);
        }
    }
}
