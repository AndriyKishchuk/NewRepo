using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_13
{
    internal class Produkt
    {
        public double BasePrice { get; set; }

        public Produkt(double basePrice)
        {
            BasePrice = basePrice;
        }

        public virtual double CalculatePrice()
        {
            return BasePrice;
        }

        public override string ToString()
        {
            return $"Produkt mit Grundpreis: {BasePrice}";
        }

    }
}
