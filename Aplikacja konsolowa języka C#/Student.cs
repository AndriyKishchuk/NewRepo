using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacja_konsolowa_języka_C_
{
    internal class Student
    {
        public int StudentId { get; set; }
        public string Imie { get; set; } = "";
        public string Nazwisko { get; set; } = "";
        public List<Ocena> Oceny { get; set; } = new();

    }
    internal class Ocena
    {
        public int OcenaId { get; set; }
        public double Wartosc { get; set; }
        public string Przedmiot { get; set; } = "";
        public int StudentId { get; set; }

    }

}
