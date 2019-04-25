using System;
using System.Numerics;
using System.Diagnostics;

namespace task5
{
    class Program
    {
        static void Main(string[] args)
        {
            HugeInteger h1 = new HugeInteger("954237482347816239123671237123478263476237482364782364782346234782348972389467234789237489234567834457903534895678934572348573489563489573487348634578467589234578348956789347568934573489573489534");
            HugeInteger h2 = new HugeInteger("23234872347962347823647823467238462378");
            // Console.WriteLine(new HugeInteger("10") * new HugeInteger("0"));
            // Console.WriteLine(new HugeInteger("10") / new HugeInteger("0"));
            // Console.WriteLine(h1 * h2);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            h1 /= h2;
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            Console.WriteLine(h1);
            // Console.WriteLine(h1 % h2);
            // Console.WriteLine(h1 + h2);
            // Console.WriteLine(h1 - h2);
            // Console.WriteLine(h1 > h2);
            // Console.WriteLine(h1 < h2);
            // Console.WriteLine(h1 == h2);
            // Console.WriteLine(h1 >= h2);
            // Console.WriteLine(h1 <= h2);
            // Console.WriteLine(h1 != h2);
        }
    }
}