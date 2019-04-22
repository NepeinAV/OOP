using System;

namespace task7
{
    class Program
    {
        static void Main(string[] args)
        {
            Polinomials p = new Polinomials(new double[] { 1, 0, 1, 0, -3, -3, 8, 2, -5 });
            Polinomials p1 = new Polinomials(new double[] { 3, 0, 5, 0, -4, -9, 21 });
            Console.WriteLine(p *= p1);
        }
    }
}
