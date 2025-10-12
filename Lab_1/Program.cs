using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("This is exercise 1");

        Animal[] animal = new Animal[3];
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Enter name of animal:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter kind of animal:");
            string kind = Console.ReadLine();
            Console.WriteLine("Enter number of legs:");
            int legs = int.Parse(Console.ReadLine());
            animal[i] = new Animal(name, kind, legs);
            Console.WriteLine();
        }
        Animal klon = new Animal(animal[0]);
        klon.Name = "Klon";

        Animal[] animals = new Animal[4];
        animal.CopyTo(animals, 0);
        animals[3] = klon;
        foreach (var a in animals)
        {
            Console.WriteLine($"Name of animal: {a.Name}, kind is {a.Kind} , number of legs {a.Legs}");
        }
        Console.WriteLine($"Total number of animals: {Animal.GetAnimalCount()}");
    }
}
class Animal
{
    private string name;
    private string kind;
    private int legs;
    private static int animalCount = 0;

    public string Kind => kind;
    public int Legs => legs;

    public string Name
    {
        get { return name; }
        set { name = value; }

    }

    public Animal()
    {
        name = "Rex";
        kind = "Dog";
        legs = 4;
        animalCount++;
    }
    public Animal(string name, string kind, int legs)
    {
        this.name = name;
        this.kind = kind;
        this.legs = legs;
        animalCount++;
    }
    public Animal(Animal animal)
    {
        this.name = animal.name;
        this.kind = animal.kind;
        this.legs = animal.legs;
        animalCount++;
    }
    public void daj_glos()
    {
        if (kind == "Dog")
        {
            Console.WriteLine("Hau hau");
        }
        else if (kind == "Cat")
        {
            Console.WriteLine("Miau miau");
        }
        else if (kind == "Cow")
        {
            Console.WriteLine("Mumu mumu");
        }
        else
        {
            Console.WriteLine("Do not name of sounds animal's");
        }
    }
    public static int GetAnimalCount()
    {
        return animalCount;
    }
}
