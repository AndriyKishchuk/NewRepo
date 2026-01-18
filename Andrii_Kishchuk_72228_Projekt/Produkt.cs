using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andrii_Kishchuk_72228_Projekt
{
    internal class Produkt
    {
        public int Id { get; set; }
        public string? Nazwa { get; set; }
        public int KategoriaId { get; set; }
        public int ProducentId { get; set; }
        public int Ilosc { get; set; }
        public decimal Cena { get; set; }
    }
    internal class StatystykiProduktu
    {
        public int LiczbaProduktow { get; set; }
        public int LacznaIlosc { get; set; }
        public decimal WartoscMagazynu { get; set; }
    }
}
