using System;

namespace task3
{
    class Test
    {
        public static void isEquals(double n1, double n2)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine(String.Format("Test: {0} equals {1}", n1, n2));
            Console.WriteLine((n1.ToString() == n2.ToString()) ? "--> Test passed!✅" : "--> Test failed!⛔");
            // Console.WriteLine("");
        }
    }
}
