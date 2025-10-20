using System;
using System.Diagnostics.Contracts;

namespace Folder
{
    class Program
    {
        static void Main(string[] args)
        {
           // Animal animal = new Animal("Burek");
            Dog dog = new Dog("Rex");
            Kot kot = new Kot("Mruczek");
            Wez wez = new Wez("Kaa");

            static void powiedz_cos(Animal animal)
            {
                animal.daj_glos();
                Console.WriteLine($"Typ obiektu: {animal.GetType().Name}");
            }

           // powiedz_cos(animal);
            powiedz_cos(dog);
            powiedz_cos(kot);
            powiedz_cos(wez);
            

        }
    }
    public class Animal
    {
        protected string name;
        public Animal(string name)
        {
            this.name = name;
        }

        public virtual void daj_glos()
        {
            Console.WriteLine(".....");
        }
    }
    public class Dog : Animal
    {
        public Dog(string name) : base(name)
        {
            this.name = name;
        }
        public override void daj_glos()
        {
            Console.WriteLine($"{name}-Hau Hau");
        }
    }
    public class Kot : Animal
    {
        public Kot(string name) : base(name)
        {
            this.name = name;
        }
        public override void daj_glos()
        {
            Console.WriteLine($"{name}-Miu miu");
        }
    }
    public class Wez : Animal
    {
        public Wez(string name) : base(name)
        {
            this.name = name;
        }
        public override void daj_glos()
        {
            Console.WriteLine($"{name}-Ssssss");

        }
    }
}

