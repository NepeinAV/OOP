using System;

namespace task9
{
    class Program
    {
        static void Main(string[] args)
        {
            // Matrix m1 = new Matrix(new double[] {
            //     1, 2, 3,
            //     4, 5, 6,
            //     7, 8, 9
            // });
            // Matrix m2 = new Matrix(new double[] {
            //     2, 5, 8,
            //     9, 11, 90,
            //     10, 1, 3
            // });
            Matrix m1 = new Matrix(new double[] {
                2, 2,
                1, 3
            });
            Matrix m2 = new Matrix(new double[] {
                1, 9,
                -1, 1.2
            });

            Console.WriteLine(m1 * m2);
        }
    }
}
