using System;

namespace task5
{
    class Program
    {
        static void Main(string[] args)
        {
            HugeInteger h1 = new HugeInteger("9");
            HugeInteger h2 = new HugeInteger("9");
            Console.WriteLine(h1 * h2);
        }
    }
}
