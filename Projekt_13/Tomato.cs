using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_13
{
    internal class Tomato : Produkt
    {
        public Tomato(double basePrice) : base(basePrice) { }

        public override double CalculatePrice()
        {
            return base.CalculatePrice();
        }
        public override string ToString()
        {
            return $"Tomato | Price: {BasePrice} грн";
        }
    }
}
