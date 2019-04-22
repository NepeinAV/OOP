using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace task7
{
    class Polinomials
    {
        private int[] _numbers;

        public Polinomials(int[] numbers)
        {
            this._numbers = numbers;
        }

        public int Length
        {
            get { return this._numbers.Length; }
        }

        ~Polinomials()
        {

        }

        private string GetNumberString(int index)
        {
            if (index == 0)
            {
                return _numbers[index].ToString();
            }
            else
            {
                return _numbers[index].ToString("+#;-#;0");
            }
        }

        public override string ToString()
        {
            Console.OutputEncoding = Encoding.Unicode;
            string result = "";
            for (int i = 0; i < _numbers.Length; i++)
                result += (i == 0) ? _numbers[i].ToString() : String.Format("{0}x^{1}", _numbers[i].ToString(" + #; - #; + 0"), i);

            return result;
        }

        public static Polinomials operator +(Polinomials a, Polinomials b)
        {
            int minLength = Math.Min(a.Length, b.Length);
            int maxLength = Math.Max(a.Length, b.Length);

            List<int> n = new List<int>();

            for (int i = 0; i < minLength; i++)
            {
                n.Add(a._numbers[i] + b._numbers[i]);
            }

            int[] bigger = a._numbers;
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

            return a + b;
        }
    }
}
