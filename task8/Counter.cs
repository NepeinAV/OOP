using System;

namespace task8
{
    class Counter
    {
        private int _min;
        private int _max;
        private int _value;

        public int CurrentValue
        {
            get { return this._value; }
        }

        public Counter(int min, int max)
        {
            this._min = min; this._max = max; this._value = min;
        }

        public Counter(int min, int max, int value)
        {
            this._min = min; this._max = max; this._value = value;
            if (value > max) this._value = max;
            else if (value < min) this._value = min;
        }

        public static Counter operator ++(Counter a)
        {
            return new Counter(a._min, a._max, (a._value + 1 > a._max) ? a._min : a._value + 1);
        }

        public override string ToString()
        {
            return this.CurrentValue.ToString();
        }
    }
}
