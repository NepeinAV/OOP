using System;

namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Date d = new Date(12, 4, 2019);
            d--; Console.WriteLine(d);
            d += 60; Console.WriteLine(d);
            d -= 736902; Console.WriteLine(d);
            d++; Console.WriteLine(d);
        }
    }
}
