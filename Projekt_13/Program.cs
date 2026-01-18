using Projekt_13;
using System;
class Program
{
    static void Main(string[] args)
    {
        VegetableShop shop = new VegetableShop();

        shop.AddProdukt(new Carrot(15.5));
        shop.AddProdukt(new Potato(20.0, 3));
        shop.AddProdukt(new Tomato(25.5));
        shop.AddProdukt(new Cucumber(18.0, 5));

        shop.AllProducts();
    }
}