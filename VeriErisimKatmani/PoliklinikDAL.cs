using Npgsql;
using System;
using System.Collections.Generic;
using VarlikKatmani;

namespace VeriErisimKatmani
{

    public class PoliklinikDAL
    {

        public static List<Poliklinik> TumPoliklinikeleriGetir()
        {
            List<Poliklinik> poliklinikler = new List<Poliklinik>();
            
            try
            {
                using (var baglanti = VeritabaniBaglanti.BaglantiOlustur())
                {
                    baglanti.Open();
                    string sorgu = "SELECT * FROM poliklinik ORDER BY poliklinikadi";
                    
                    using (var komut = new NpgsqlCommand(sorgu, baglanti))
                    using (var okuyucu = komut.ExecuteReader())
                    {
                        while (okuyucu.Read())
                        {
                            poliklinikler.Add(new Poliklinik
                            {
                                PoliklinikAdi = okuyucu.GetString(0),
                                Durum = okuyucu.GetBoolean(1),
                                Aciklama = okuyucu.IsDBNull(2) ? null : okuyucu.GetString(2)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Poliklinikler getirilirken hata oluştu: " + ex.Message);
            }
            
            return poliklinikler;
        }

   
        public static List<Poliklinik> AktifPoliklinikeleriGetir()
        {
            List<Poliklinik> poliklinikler = new List<Poliklinik>();
            
            try
            {
                using (var baglanti = VeritabaniBaglanti.BaglantiOlustur())
                {
                    baglanti.Open();
                    string sorgu = "SELECT * FROM poliklinik WHERE durum = true ORDER BY poliklinikadi";
                    
                    using (var komut = new NpgsqlCommand(sorgu, baglanti))
                    using (var okuyucu = komut.ExecuteReader())
                    {
                        while (okuyucu.Read())
                        {
                            poliklinikler.Add(new Poliklinik
                            {
                                PoliklinikAdi = okuyucu.GetString(0),
                                Durum = okuyucu.GetBoolean(1),
                                Aciklama = okuyucu.IsDBNull(2) ? null : okuyucu.GetString(2)  //Genel amaçlı koşul operatörü
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Aktif poliklinikler getirilirken hata oluştu: " + ex.Message);
            }
            
            return poliklinikler;
        }

   
        public static bool PoliklinikEkle(Poliklinik poliklinik)
        {
            try
            {
                using (var baglanti = VeritabaniBaglanti.BaglantiOlustur())
                {
                    baglanti.Open();
                    string sorgu = "INSERT INTO poliklinik (poliklinikadi, durum, aciklama) VALUES (@adi, @durum, @aciklama)";
                    
                    using (var komut = new NpgsqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@adi", poliklinik.PoliklinikAdi);
                        komut.Parameters.AddWithValue("@durum", poliklinik.Durum);
                        komut.Parameters.AddWithValue("@aciklama", (object)poliklinik.Aciklama ?? DBNull.Value); //??Sol taraf null ise sağ tarafı kullan",  DBNull.Value → Veritabanında NULL değeri temsil eder 



                        return komut.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Poliklinik eklenirken hata oluştu: " + ex.Message);
            }
        }

        public static bool PoliklinikGuncelle(string eskiAd, Poliklinik poliklinik)
        {
            try
            {
                using (var baglanti = VeritabaniBaglanti.BaglantiOlustur())
                {
                    baglanti.Open();
                    string sorgu = "UPDATE poliklinik SET poliklinikadi=@yeniadi, durum=@durum, aciklama=@aciklama WHERE poliklinikadi=@eskiadi";
                    
                    using (var komut = new NpgsqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@eskiadi", eskiAd);
                        komut.Parameters.AddWithValue("@yeniadi", poliklinik.PoliklinikAdi);
                        komut.Parameters.AddWithValue("@durum", poliklinik.Durum);
                        komut.Parameters.AddWithValue("@aciklama", (object)poliklinik.Aciklama ?? DBNull.Value);

                        return komut.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Poliklinik güncellenirken hata oluştu: " + ex.Message);
            }
        }

        public static bool PoliklinikSil(string poliklinikAdi)
        {
            try
            {
                using (var baglanti = VeritabaniBaglanti.BaglantiOlustur())
                {
                    baglanti.Open();
                    string sorgu = "DELETE FROM poliklinik WHERE poliklinikadi = @adi";
                    
                    using (var komut = new NpgsqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@adi", poliklinikAdi);
                        return komut.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Poliklinik silinirken hata oluştu: " + ex.Message);
            }
        }
    }
}
