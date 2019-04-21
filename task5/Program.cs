using System;
using System.Numerics;

namespace task5
{
    class Program
    {
        static void Main(string[] args)
        {
            HugeInteger h1 = new HugeInteger("64623742387434762374682374623874");
            HugeInteger h2 = new HugeInteger("10568347328947234623");
            Console.WriteLine(new HugeInteger("10") * new HugeInteger("0"));
            // Console.WriteLine(new HugeInteger("10") / new HugeInteger("0"));
            Console.WriteLine(h1 * h2);
            Console.WriteLine(h1 / h2);
            Console.WriteLine(h1 % h2);
            Console.WriteLine(h1 + h2);
            Console.WriteLine(h1 - h2);
            Console.WriteLine(h1 > h2);
            Console.WriteLine(h1 < h2);
            Console.WriteLine(h1 == h2);
            Console.WriteLine(h1 >= h2);
            Console.WriteLine(h1 <= h2);
            Console.WriteLine(h1 != h2);
        }
    }
}