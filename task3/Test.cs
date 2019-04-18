using System;

namespace task3
{
    class Test
    {
        private string testTitle;

        public Test(string testTitle)
        {
            this.testTitle = testTitle;
        }

        public void isEquals(double n1, double n2)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("\n" + this.testTitle);
            Console.WriteLine(String.Format("Incoming values: \n  {0}\n  {1}", n1, n2));
            Console.ForegroundColor = (n1.ToString() == n2.ToString()) ? ConsoleColor.DarkGreen : ConsoleColor.Red;
            Console.WriteLine((n1.ToString() == n2.ToString()) ? "--> Test passed!✅" : "--> Test failed!⛔");
            Console.ForegroundColor = ConsoleColor.White;

        }
    }
}
