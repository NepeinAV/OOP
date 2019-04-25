// хранить число в обратном порядке
// избавиться от медленных substring


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
        private int maxLength = 700;

        /// <param name="number">Signed number</param>
        public HugeInteger(string number)
        {
            this.sign = (number[0] == '-') ? -1 : 1;
            // number = new String(number.Where(Char.IsDigit).ToArray()).TrimStart('0');
            number = number.TrimStart('-').TrimStart('0');
            this.SetNumber(number);
        }

        /// <param name="sign">Знак числа -1 или 1</param>
        /// <param name="number">Array of int</param>
        public HugeInteger(int[] number, int sign = 1, bool reversed = false)
        {
            this.sign = sign;

            if (reversed)
            {
                int length = this.maxLength;
                string num = String.Join("", number).TrimEnd('0');
                if (num.Length > length) throw new OverflowException("Слишком длинное число");
                this.Length = (num.Length == 0) ? 1 : num.Length;
                this.number = number;
            }
            else this.SetNumber(String.Join("", number).TrimStart('0'));
        }

        private void SetNumber(string num)
        {
            int length = this.maxLength;
            if (num.Length > length) throw new OverflowException("Слишком длинное число");
            this.Length = (num.Length == 0) ? 1 : num.Length;

            int[] n = new int[length];

            for (int i = 0, j = num.Length - 1; i < num.Length; i++, j--)
            {
                n[i] = int.Parse(num[j].ToString());
            }

            this.number = n;
        }

        public override string ToString() => ((this.sign == -1 && !this.isZero()) ? "-" : "") + String.Join("", this.number.Take(this.Length).Reverse());

        public bool isZero() => this.Length == 1 && this.number[0] == 0;

        public static int CompareUnsigned(HugeInteger a, HugeInteger b)
        {
            if (a.Length == b.Length)
            {
                for (int i = a.Length - 1; i >= 0; i--)
                {
                    if (a.number[i] > b.number[i]) return 1;
                    else if (a.number[i] < b.number[i]) return -1;
                }

                return 0;
            }
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
                int i = 0;
                while (i < max.Length)
                {
                    int sum = (method == 1) ? initialNumber[i] + min.number[i] : max.sign * initialNumber[i] + min.sign * min.number[i];
                    initialNumber[i] = (sum < 0) ? (10 + sum) : (sum % 10);
                    if (sum >= 10 || sum < 0) initialNumber[i + 1] += (sum < 0) ? -1 : ((sum >= 10) ? 1 : 0);
                    i++;
                }

                if (swap) { max.sign = -max.sign; min.sign = -min.sign; }
            }
            catch (IndexOutOfRangeException) { throw new OverflowException(); }

            return new HugeInteger(initialNumber, max.sign, true);
        }

        public static HugeInteger operator -(HugeInteger initial, HugeInteger substracted) => new HugeInteger(initial.number, initial.sign, true) + new HugeInteger(substracted.number, -substracted.sign, true);

        public static HugeInteger operator *(HugeInteger initial, HugeInteger multiplied)
        {
            int sign = initial.sign * multiplied.sign;
            int[] newNumber = new int[initial.maxLength];

            for (int i = 0; i < multiplied.Length; i++)
            {
                int addition = 0;
                for (int j = 0; j < initial.Length; j++)
                {
                    int m = multiplied.number[i] * initial.number[j] + addition;
                    m += newNumber[i + j];
                    newNumber[i + j] = m % 10;
                    addition = m / 10;
                }
                if (addition != 0) newNumber[initial.Length + i] = addition;
            }

            return new HugeInteger(newNumber, sign, true);
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
            if (initial < divided) { return ("0", initial.ToString()); }
            if (divided.isZero()) throw new DivideByZeroException();
            if (divided.ToString() == "1") return (((sign == -1) ? "-" : "") + initial.ToString(), "0");

            int zeros = Math.Min(divided.Length - String.Join("", divided.number).TrimStart('0').Length, initial.Length - String.Join("", initial.number).TrimStart('0').Length);

            divided = new HugeInteger(divided.number.Skip(zeros).Take(divided.Length - zeros).ToArray(), 1, true);
            initial = new HugeInteger(initial.number.Skip(zeros).Take(initial.Length - zeros).ToArray(), 1, true);

            HugeInteger newNumber;
            string dividedNumberStr = divided.ToString();

            string q, tmp, tail; q = tmp = tail = "";
            bool first = true;
            bool zero = true;
            string sliceI;
            int i, count;
            int lastLength = divided.Length;

            while (initial >= divided)
            {
                i = initial.maxLength - initial.Length;
                count = (zero) ? 0 : 1;
                int sliceLength = lastLength + count;
                sliceI = String.Join("", initial.number.Skip(initial.Length - sliceLength).Take(sliceLength).Reverse());
                count++;

                while (HugeInteger.CompareUnsigned(sliceI, dividedNumberStr) < 0)
                {
                    if (!first) q += "0";
                    sliceI += initial.number[initial.Length - sliceI.Length - 1].ToString();
                    count++;
                }

                first = false;

                (newNumber, tmp) = HugeInteger.DivideBySub(new HugeInteger(sliceI), divided);

                if (newNumber.isZero()) zero = true;
                else zero = false;

                q += tmp;
                lastLength = newNumber.Length;
                tail = String.Join("", initial.number.Take(initial.Length - sliceI.Length).Reverse());
                initial = new HugeInteger(newNumber.ToString() + tail);
            }

            if (tail != "") q = q.PadLeft(q.Length + tail.Length, '0');

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
