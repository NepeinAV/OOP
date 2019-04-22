using System;

namespace task6
{
    static class GCD
    {

        public static (int, int) ReduceNumber(int numerator, int divider)
        {
            int maxDivider = GCD.findGCD(numerator, divider);
            return (numerator / maxDivider, divider / maxDivider);
        }

        private static int findGCD(int numerator, int divider)
        {
            int n = numerator;
            int d = divider;

            while (n != 0 && d != 0) if (n > d) n %= d; else d %= n;

            return n + d;
        }
    }
}
