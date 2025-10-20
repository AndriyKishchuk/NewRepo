using System;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Baker baker = new Baker();
            baker.Work();
            // Employee employee = new Employee() // Error - Because Employee is abstract and objects of abstract classes cannot be created.
            Console.ReadKey();
        }
    }
    abstract class Employee
    {
        public abstract void Work();
    }
    class Baker : Employee
    {
        public override void Work()
        {
            Console.WriteLine("Baking bread");
        }
    }

}
