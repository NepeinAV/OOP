using System;

namespace task8
{
    class Program
    {
        static void Main(string[] args)
        {
            Counter counter = new Counter(0, 59);
            counter++;
            Console.WriteLine(++counter);
        }
    }
}
