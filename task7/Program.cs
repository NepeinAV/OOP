using System;

namespace task7
{
    class Program
    {
        static void Main(string[] args)
        {
            Polinomials p = new Polinomials(new int[] { 0, 0, 6, -2 });
            Polinomials p1 = new Polinomials(new int[] { 0, 0, 6, -2, 4 });
            Console.WriteLine(p - p1 + p1 + p);
        }
    }
}
