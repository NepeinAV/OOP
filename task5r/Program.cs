using System;
using System.Numerics;
using System.Diagnostics;

namespace task5
{
    class Program
    {
        static void Main(string[] args)
        {
            HugeInteger h1 = new HugeInteger("954237482347816239123671237123478263476237482364782364782346782346237846237351267351272347826347623748236478236478234678234623784623735126735127234782634762374823647823647823467823462378462373512673512723123611231295423748234781623912367123712312361123129542374823478162391236712371231236112312954237482347816239123671237123123611231295423748234781623912367123712312361123129542374823478162391236712371231236112312954237482347816239123671237123123611231295423748234781623912367123712312361123129542374823478162391236712371231236112312");
            HugeInteger h2 = new HugeInteger("2347826347623748236478236478234678234623784623735126735127");
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