using System;

namespace task2
{
    class Platypus : Animal
    {
        public Platypus()
        {
            this.isViviparous = false;
        }
        override public void Display()
        {
            Console.WriteLine(String.Format("Утконос {0}\n", (this.isViviparous) ? "живородящий" : "несёт яйца"));
        }
    }
}
