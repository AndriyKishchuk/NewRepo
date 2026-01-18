using System;
using Microsoft.Data.SqlClient;

namespace Andrii_Kishchuk_72228_Projekt
{
    internal class Database
    {
        private readonly string connectionString = @"Server=USER\SQLEXPRESS;Database = SklepMotoryzacyjny; Trusted_Connection= true;TrustServerCertificate=true";
        public void DodajProdukt(Produkt produkt)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand sqlCommand = new SqlCommand("INSERT INTO Produkty(NazwaProduktu,IdKategorii,IdProducenta,Cena,IloscNaMagazynie) VALUES (@nazwa,@kategoriaId,@producentId, @cena, @ilosc)", connection);
                sqlCommand.Parameters.AddWithValue("@nazwa", produkt.Nazwa);
                sqlCommand.Parameters.AddWithValue("@kategoriaId", produkt.KategoriaId);
                sqlCommand.Parameters.AddWithValue("@producentId", produkt.ProducentId);
                sqlCommand.Parameters.AddWithValue("@cena", produkt.Cena);
                sqlCommand.Parameters.AddWithValue("@ilosc", produkt.Ilosc);

                sqlCommand.ExecuteNonQuery();

            }

        }
        public List<Produkt> WyswetlProdukty()
        {
            var produkty = new List<Produkt>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT IdProduktu,IdKategorii,IdProducenta,NazwaProduktu,Cena,IloscNaMagazynie FROM Produkty", connection);
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var produkt = new Produkt
                        {
                            Id = (int)reader["IdProduktu"],
                            KategoriaId = (int)reader["IdKategorii"],
                            ProducentId = (int)reader["IdProducenta"],
                            Nazwa = reader["NazwaProduktu"].ToString(),
                            Cena = (decimal)reader["Cena"],
                            Ilosc = (int)reader["IloscNaMagazynie"]

                        };
                        produkty.Add(produkt);
                    }
                }
            }
            return produkty;
        }
        public void EdytujProdukt(int id, decimal nowaCena)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("UPDATE Produkty SET Cena = @nowaCena WHERE IdProduktu = @id", connection);
                sqlCommand.Parameters.AddWithValue("@nowaCena", nowaCena);
                sqlCommand.Parameters.AddWithValue("@id", id);
                sqlCommand.ExecuteNonQuery();
            }
        }
        public void UsunProdukt(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("DELETE FROM Produkty WHERE IdProduktu = @id", connection);
                sqlCommand.Parameters.AddWithValue("@id", id);
                sqlCommand.ExecuteNonQuery();
            }
        }
        public StatystykiProduktu StatystykiProduktu()
        {
            var statystyki = new StatystykiProduktu();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) AS LiczbaProduktow, SUM(IloscNaMagazynie) AS LacznaIlosc, SUM(Cena * IloscNaMagazynie) AS WartoscMagazynu FROM Produkty", connection);
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        statystyki.LiczbaProduktow = reader["LiczbaProduktow"] != DBNull.Value ? (int)reader["LacznaIlosc"] : 0;
                        statystyki.LacznaIlosc = reader["LacznaIlosc"] != DBNull.Value ? (int)reader["LacznaIlosc"] : 0;
                        statystyki.WartoscMagazynu = reader["WartoscMagazynu"] != DBNull.Value ? (decimal)reader["WartoscMagazynu"] : 0;
                    }
                }
            }
            return statystyki;
        }
    }
}
