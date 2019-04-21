using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace task5
{
    class HugeInteger
    {
        private int[] number;
        private int Length;
        private int sign;
        private int maxLength = 100;

        /// <param name="number">Signed number</param>
        public HugeInteger(string number)
        {
            this.sign = (number[0] == '-') ? -1 : 1;
            number = new String(number.Where(Char.IsDigit).ToArray()).TrimStart('0');
            this.SetNumber(number);
        }

        /// <param name="sign">Знак числа -1 или 1</param>
        /// <param name="number">Array of int</param>
        public HugeInteger(int[] number, int sign = 1)
        {
            this.sign = sign;
            string num = new String(String.Join("", number).Where(Char.IsDigit).ToArray()).TrimStart('0');
            this.SetNumber(num);
        }

        private void SetNumber(string num)
        {
            if (num.Length > this.maxLength) throw new OverflowException("Слишком длинное число");
            this.Length = (num.Length == 0) ? 1 : num.Length;
            this.number = Array.ConvertAll<char, int>(num.PadLeft(this.maxLength, '0').ToCharArray(), (x) => int.Parse(x.ToString()));
        }

        public override string ToString() => ((this.sign == -1 && !this.isZero()) ? "-" : "") + String.Join("", new ArraySegment<int>(this.number, this.number.Length - this.Length, this.Length));

        public bool isZero() => this.Length == 1 && this.number[this.maxLength - 1] == 0;

        private static int CompareUnsigned(HugeInteger a, HugeInteger b)
        {
            if (a.Length == b.Length) return String.Compare(a.ToString().TrimStart('-'), b.ToString().TrimStart('-'));
            return (a.Length > b.Length) ? 1 : -1;
        }

        private static int CompareUnsigned(string a, string b)
        {
            if (a.Length == b.Length) return String.Compare(a, b);
            return (a.Length > b.Length) ? 1 : -1;
        }

        public static HugeInteger operator +(HugeInteger initial, HugeInteger added)
        {
            int compare = HugeInteger.CompareUnsigned(initial, added);
            HugeInteger max, min;
            (max, min) = (compare == -1) ? (added, initial) : (initial, added);

            int[] initialNumber = max.number;
            bool swap = false;

            int method = (max.sign == min.sign) ? 1 : -1;

            if (method == -1 && max.sign == -1) { max.sign = -max.sign; min.sign = -min.sign; swap = true; }

            try
            {
                int i = initial.maxLength - 1;
                while (i >= max.maxLength - max.Length)
                {
                    int sum = (method == 1) ? initialNumber[i] + min.number[i] : max.sign * initialNumber[i] + min.sign * min.number[i];
                    initialNumber[i] = (sum < 0) ? (10 + sum) : (sum % 10);
                    if (sum >= 10 || sum < 0) initialNumber[i - 1] += (sum < 0) ? -1 : ((sum >= 10) ? 1 : 0);
                    i--;
                }

                if (swap) { max.sign = -max.sign; min.sign = -min.sign; }
            }
            catch (IndexOutOfRangeException) { throw new OverflowException(); }

            return new HugeInteger(initialNumber, max.sign);
        }

        public static HugeInteger operator -(HugeInteger initial, HugeInteger substracted) => new HugeInteger(initial.number, initial.sign) + new HugeInteger(substracted.number, -substracted.sign);

        public static HugeInteger operator *(HugeInteger initial, HugeInteger multiplied)
        {
            int sign = initial.sign * multiplied.sign;
            HugeInteger newNumber = new HugeInteger("0");

            for (int i = multiplied.maxLength - 1; i >= multiplied.maxLength - multiplied.Length; i--)
            {
                int addition = 0;
                List<int> initialNumber = new List<int>();

                for (int j = initial.maxLength - 1; j >= initial.maxLength - initial.Length; j--)
                {
                    int m = multiplied.number[i] * initial.number[j] + addition;
                    initialNumber.Insert(0, m % 10);
                    addition = m / 10;
                }

                if (addition != 0) initialNumber.Insert(0, addition);
                newNumber += new HugeInteger(String.Join("", initialNumber.ToArray()).PadRight(initialNumber.Count + (multiplied.maxLength - i - 1), '0'));
            }

            return new HugeInteger(newNumber.number, sign);
        }

        private static (HugeInteger, string) DivideBySub(HugeInteger initial, HugeInteger divided)
        {
            int q = 0;
            while (initial >= divided)
            {
                initial -= divided;
                q++;
            }

            return (initial, q.ToString());
        }

        private static (string, string) Divide(HugeInteger initial, HugeInteger divided)
        {
            int sign = initial.sign * divided.sign; initial.sign = 1; divided.sign = 1;

            if (initial < divided) return ("0", initial.ToString());
            if (divided.isZero()) throw new DivideByZeroException();
            if (divided.ToString() == "1") return (((sign == -1) ? "-" : "") + initial.ToString(), "0");

            int zeros = Math.Min(divided.Length - divided.ToString().TrimEnd('0').Length, initial.Length - initial.ToString().TrimEnd('0').Length);
            divided = new HugeInteger(divided.ToString().Substring(0, divided.Length - zeros));
            initial = new HugeInteger(initial.ToString().Substring(0, initial.Length - zeros));

            HugeInteger newNumber;
            string dividedNumberStr = divided.ToString();

            string q, tmp, sliceI, tail; q = tmp = tail = sliceI = "";
            bool first = true;
            int i, count;
            int lastLength = divided.Length;


            while (initial >= divided)
            {
                i = initial.maxLength - initial.Length;
                sliceI = String.Join("", initial.number.Skip(i).Take(lastLength + ((first) ? 0 : 1)));
                count = (first) ? 1 : 2;

                while (HugeInteger.CompareUnsigned(sliceI, dividedNumberStr) < 0)
                {
                    if (!first) q += "0";
                    sliceI = String.Join("", initial.number.Skip(i).Take(lastLength + count));
                    count++;
                }

                first = false;

                (newNumber, tmp) = HugeInteger.DivideBySub(new HugeInteger(sliceI), new HugeInteger(dividedNumberStr));
                q += tmp;
                lastLength = newNumber.Length;
                tail = String.Join("", initial.number.Skip(initial.maxLength - initial.Length + sliceI.Length).Take(initial.maxLength - (initial.maxLength - initial.Length + sliceI.Length)));
                initial = new HugeInteger(newNumber.ToString() + tail);
            }

            if (tail != "") q = q.PadRight(q.Length + tail.Length, '0');

            return (((sign == -1) ? "-" : "") + q, initial.ToString());
        }

        public static HugeInteger operator /(HugeInteger initial, HugeInteger divided) => new HugeInteger(HugeInteger.Divide(initial, divided).Item1);

        public static HugeInteger operator %(HugeInteger initial, HugeInteger divided) => new HugeInteger(HugeInteger.Divide(initial, divided).Item2);

        public static bool operator ==(HugeInteger a, HugeInteger b) => a.ToString() == b.ToString();

        public static bool operator !=(HugeInteger a, HugeInteger b) => !(a == b);

        public static bool operator >(HugeInteger a, HugeInteger b)
        {
            if (a.sign < b.sign) return false;
            else if (a.sign > b.sign) return true;
            int comp = HugeInteger.CompareUnsigned(a, b);
            return comp == a.sign;
        }

        public static bool operator <(HugeInteger a, HugeInteger b) => !(a > b) && a != b;

        public static bool operator >=(HugeInteger a, HugeInteger b)
        {
            return a > b || HugeInteger.CompareUnsigned(a, b) == 0 && a.sign == b.sign;
        }

        public static bool operator <=(HugeInteger a, HugeInteger b) => !(a > b);

        public override bool Equals(object value)
        {
            HugeInteger number = value as HugeInteger;

            return !Object.ReferenceEquals(null, number)
                && String.Equals(this.sign, number.sign)
                && String.Equals(this.number, number.number);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                const int HashingBase = (int)2166136261;
                const int HashingMultiplier = 16777619;

                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, this.sign) ? this.sign.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, this.number) ? this.number.GetHashCode() : 0);
                return hash;
            }
        }
    }
}
