using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_13
{
    internal class Cucumber:Produkt
    {
        public int Count { get; }
        public Cucumber(double basePrice, int Count) : base(basePrice)
        {
            this.Count = Count;
        }
        public override double CalculatePrice()
        {
            return base.CalculatePrice() * Count;
        }
        public override string ToString()
        {
            return $"Cucumber | Price per unit: {BasePrice} грн | Count: {Count} | Total Price: {CalculatePrice()} грн";
        }
    }
}
