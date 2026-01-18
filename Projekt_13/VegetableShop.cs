using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_13
{
    internal class VegetableShop
    {
        List<Produkt> produkts = new List<Produkt>();


        public void AddProdukt(Produkt produkt)
        {
            produkts.Add(produkt);
        }

        public void AllProducts()
        {
            double total = 0;
            foreach (var produkt in produkts)
            {
                Console.WriteLine(produkt.ToString());
                total += produkt.CalculatePrice();

            }
            Console.WriteLine("Total price = " + total);
        }

    }
}
