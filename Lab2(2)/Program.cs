using System;
namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            B b = new B();
            C c = new C();
            Console.ReadKey();
        }
    }
    class A
    {
        public A()
        {
            Console.WriteLine("To jest konstruktor A");
        }

    }
    class B : A
    {
        public B()
        {
            Console.WriteLine("To jest konstruktor B");
        }
    }
    class C : B
    {
        public C()
        {
            Console.WriteLine("To jest konsstruktor C ");
        }
    }
}