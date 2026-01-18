using System;
using Microsoft.Data.SqlClient;
using Andrii_Kishchuk_72228_Projekt;
class Program
{
    static Database database = new Database();
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=========================================");
            Console.WriteLine("   SYSTEM ZARZĄDZANIA CZĘŚCIAMI AUTO");
            Console.WriteLine("=========================================");
            Console.WriteLine("1. Dodaj nową część");
            Console.WriteLine("2. Wyświetl wszystkie części");
            Console.WriteLine("3. Edytuj część");
            Console.WriteLine("4. Usuń część");
            Console.WriteLine("5. Statystyki magazynu");
            Console.WriteLine("0. Zakończ program");
            Console.WriteLine("-----------------------------------------");
            Console.Write("Wybierz opcję: ");

            switch (Console.ReadLine())
            {
                case "1":
                    NewDodajProdukt();
                    break;
                case "2":
                    NewWyswetlProdukty();
                    break;
                case "3":
                    NewEdytujProdukt();
                    break;
                case "4":
                    NewUsunProdukt();
                    break;
                case "5":
                    NewStatystykiMagazynu();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Nieprawidłowa opcja. Naciśnij dowolny klawisz, aby kontynuować...");
                    Console.ReadKey();
                    break;
            }
        }
    }
    static void NewDodajProdukt()
    {
        try
        {
            Console.WriteLine("Nazwa Produktu:");
            string nazwa = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nazwa))
            {
                throw new ArgumentException("Nazwa produktu nie może być pusta.");
            }

            Console.WriteLine("Id kategorii:");
            if (!int.TryParse(Console.ReadLine(), out int kategoriaId) || kategoriaId <= 0 || kategoriaId>10)
            {
                throw new ArgumentException("Nieprawidłowe Id kategorii.");
            }
            Console.WriteLine("Id producenta: ");
            if (!int.TryParse(Console.ReadLine(), out int producentId) || producentId <= 0 || producentId>10)
            {
               throw new ArgumentException("Nieprawidłowe Id producenta.");
            }


            Console.WriteLine("Cena:");
            if (!decimal.TryParse(Console.ReadLine(), out decimal cena) || cena <= 0)
            {
                throw new ArgumentException("Nieprawidłowa cena.");
            }

            Console.WriteLine("Ilość:");
            if (!int.TryParse(Console.ReadLine(), out int ilosc) || ilosc < 0)
            {
               throw new ArgumentException("Nieprawidłowa ilość.");
            }
            Produkt produkt = new Produkt
            {
                Nazwa = nazwa,
                KategoriaId = kategoriaId,
                ProducentId = producentId,
                Cena = cena,
                Ilosc = ilosc
            };
            database.DodajProdukt(produkt);
            Console.WriteLine("Produkt dodany pomyślnie.");

        }
        catch (Exception ex)
        {
            Console.WriteLine("Błąd: " + ex.Message);
        }
        Console.WriteLine("Naciśnij dowolny klawisz...");
        Console.ReadKey();
    }

    static void NewWyswetlProdukty()
    {
        try
        {
            var produkty = database.WyswetlProdukty();

            Console.WriteLine($"{"ID",-4} | {"Nazwa Produktu",-25} | {"Kat.",-4} | {"Prod.",-5} | {"Cena",10} | {"Ilość",5}");
        
            Console.WriteLine(new string('-', 75));
            foreach (var p in produkty)
            {
              Console.WriteLine($"{p.Id,-4} | {p.Nazwa,-25} | {p.KategoriaId,-4} | {p.ProducentId,-5} | {p.Cena,10:F2} | {p.Ilosc,5}");              
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Błąd: " + ex.Message);
        }
        Console.ReadKey();
    }

    static void NewEdytujProdukt()
    {
        try
        {
            Console.WriteLine("Poday ID produktu:");
            if (!int.TryParse(Console.ReadLine(), out int idProduktu) || idProduktu <= 0)
            {
                throw new ArgumentException("Nieprawidłowe ID produktu.");
            }
            Console.WriteLine("Nowa cena produktu:");
            if (!decimal.TryParse(Console.ReadLine(), out decimal nowaCena) || nowaCena <= 0)
            {
                throw new ArgumentException("Nieprawidłowa cena.");
            }
            database.EdytujProdukt(idProduktu, nowaCena);
            Console.WriteLine("Produkt zaktualizowany pomyślnie.");

        }
        catch (Exception ex)
        {
            Console.WriteLine("Błąd: " + ex.Message);
        }
        Console.ReadKey();
    }
    static void NewUsunProdukt()
    {
        try
        {
            Console.WriteLine("Poday ID produktu do usunięcia");
            if (!int.TryParse(Console.ReadLine(), out int idProduktu) || idProduktu <= 0)
            {
                throw new ArgumentException("Nieprawidłowe ID produktu.");
            }

            database.UsunProdukt(idProduktu);
            Console.WriteLine("Produkt usunięty pomyślnie.");

        }
        catch (Exception ex)
        {
            Console.WriteLine("Błąd: " + ex.Message);
        }
    }
    static void NewStatystykiMagazynu()
    {
        try
        {
            var statystyki = database.StatystykiProduktu();
            Console.WriteLine("Liczba różnych produktów: " + statystyki.LiczbaProduktow);
            Console.WriteLine("Łączna ilość produktów: " + statystyki.LacznaIlosc);
            Console.WriteLine("Wartość magazynu: " + statystyki.WartoscMagazynu.ToString("C"));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Błąd: " + ex.Message);
        }
        Console.ReadKey();
    }
}