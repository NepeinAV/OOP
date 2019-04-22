using System;
using System.Linq;
// using System.Windows;
using System.Numerics;

namespace task9
{
    class Matrix
    {
        private double[] _matrix;
        private int _dimension;

        private double this[int i]
        {
            get { return this._matrix[i]; }
        }

        public Matrix(double[] matrix)
        {
            if (Math.Sqrt(matrix.Length) % 1 == 0) { this._matrix = matrix; this._dimension = (int)Math.Sqrt(matrix.Length); }
            else throw new ArgumentException("Матрица должна быть квадратной");
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a._dimension != b._dimension) throw new ArgumentException("Матрицы должны быть одинаковой размерности");
            double[] m = new double[a._matrix.Length];
            for (int i = 0; i < a._matrix.Length; i++)
            {
                m[i] = a[i] + b[i];
            }

            return new Matrix(m);
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            return a + new Matrix(b._matrix.Select(x => -x).ToArray());
        }

        private static double GetScalar(Matrix a, int index, double[] row)
        {
            double n = 0;
            for (int i = 0; i < a._dimension; i++) n += a[i * (a._dimension) + index] * row[i];

            return n;
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            double[] n = new double[a._matrix.Length];
            int dimension = a._dimension;
            int length = a._matrix.Length;

            for (int i = 0; i < length; i += dimension)
            {
                for (int j = 0; j < dimension; j++)
                {
                    n[i + j] = Matrix.GetScalar(b, j, a._matrix.Skip(i).Take(dimension).ToArray());
                }
            }

            return new Matrix(n);
        }

        public override string ToString()
        {
            int max = Math.Max(this._matrix.Max().ToString().Length, this._matrix.Min().ToString().Length);

            string res = "";
            for (int i = 0; i < this._matrix.Length; i++)
            {
                res += this[i].ToString().PadRight(max + 1, ' ');
                if ((i + 1) % this._dimension == 0) res += "\n";
            }

            return res;
        }
    }
}
