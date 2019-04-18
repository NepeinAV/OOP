using System;

namespace task2
{
    class Dog : Animal
    {
        public Dog()
        {
            this.isViviparous = true;
        }
        override public void Display()
        {
            Console.WriteLine(String.Format("Собака {0}\n", (this.isViviparous) ? "живородящая" : "несёт яйца"));
        }
    }
}
