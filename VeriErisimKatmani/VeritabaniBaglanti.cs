using Npgsql;
using System;

namespace VeriErisimKatmani
{
   
    public class VeritabaniBaglanti
    {
       
        private static string baglantiCumlesi = "Host=localhost;Port=5432;Database=SOHTS;Username=postgres;Password=YOUR_PASSWORD_HERE;";

 
        public static void BaglantiCumlesiAyarla(string host, string port, string database, string username, string password)
        {
            baglantiCumlesi = $"Host={host};Port={port};Database={database};Username={username};Password={password};";
        }

     
        public static void BaglantiCumlesiAyarla(string connectionString)
        {
            baglantiCumlesi = connectionString;
        }

      
        public static NpgsqlConnection BaglantiOlustur()
        {
            try
            {
                NpgsqlConnection baglanti = new NpgsqlConnection(baglantiCumlesi);
                return baglanti;
            }
            catch (Exception ex)
            {
                throw new Exception("Veritabanı bağlantısı oluşturulamadı: " + ex.Message);
            }
        }

 
        public static bool BaglantiTest()
        {
            try
            {
                using (var baglanti = BaglantiOlustur())
                {
                    baglanti.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static string BaglantiCumlesiGetir()
        {
            return baglantiCumlesi;
        }
    }
}
