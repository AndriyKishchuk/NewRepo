using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_13
{
    internal class Carrot : Produkt
    {
        public Carrot(double basePrice) : base(basePrice) { }

        public override double CalculatePrice()
        {
            return base.CalculatePrice();
        }

        public override string ToString()
        {
            return $"Carrot | Price: {BasePrice} грн";
        }
    }
}
