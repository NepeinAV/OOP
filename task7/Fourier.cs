using System;
using System.Numerics;

namespace task7
{
    class Fourier
    {
        public static void FFT(ref Complex[] polinomial, bool invert)
        {
            int l = polinomial.Length;
            if (l == 1) return;

            Complex[] p1 = new Complex[l / 2];
            Complex[] p2 = new Complex[l / 2];

            for (int i = 0; i < l / 2; i++)
            {
                p1[i] = polinomial[2 * i];
                p2[i] = polinomial[2 * i + 1];
            }

            Fourier.FFT(ref p1, invert);
            Fourier.FFT(ref p2, invert);

            double angle = 2 * Math.PI / l * (invert ? -1 : 1);
            Complex w = new Complex(1, 0);
            Complex wn = new Complex(Math.Cos(angle), Math.Sin(angle));

            for (int i = 0; i < l / 2; i++)
            {
                polinomial[i] = p1[i] + w * p2[i];
                polinomial[i + l / 2] = p1[i] - w * p2[i];
                if (invert) { polinomial[i] /= 2; polinomial[i + l / 2] /= 2; }
                w *= wn;
            }
        }
    }
}
