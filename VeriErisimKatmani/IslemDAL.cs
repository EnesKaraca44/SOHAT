using Npgsql;
using System;
using System.Collections.Generic;
using VarlikKatmani;

namespace VeriErisimKatmani
{
   
    public class IslemDAL
    {
      
        public static List<Islem> TumIslemleriGetir()
        {
            List<Islem> islemler = new List<Islem>();
            
            try
            {
                using (var baglanti = VeritabaniBaglanti.BaglantiOlustur())
                {
                    baglanti.Open();
                    string sorgu = "SELECT * FROM islem ORDER BY islemadi";
                    
                    using (var komut = new NpgsqlCommand(sorgu, baglanti))
                    using (var okuyucu = komut.ExecuteReader())
                    {
                        while (okuyucu.Read())
                        {
                            islemler.Add(new Islem
                            {
                                IslemAdi = okuyucu.GetString(0),
                                BirimFiyati = okuyucu.GetDecimal(1)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("İşlemler getirilirken hata oluştu: " + ex.Message);
            }
            
            return islemler;
        }


        public static decimal? BirimFiyatGetir(string islemAdi)
        {
            try
            {
                using (var baglanti = VeritabaniBaglanti.BaglantiOlustur())
                {
                    baglanti.Open();
                    string sorgu = "SELECT birimfiyati FROM islem WHERE islemadi = @adi";
                    
                    using (var komut = new NpgsqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@adi", islemAdi);
                        var sonuc = komut.ExecuteScalar();
                        return sonuc != null ? Convert.ToDecimal(sonuc) : (decimal?)null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Birim fiyat getirilirken hata oluştu: " + ex.Message);
            }
        }

        public static bool IslemEkle(Islem islem)
        {
            try
            {
                using (var baglanti = VeritabaniBaglanti.BaglantiOlustur())
                {
                    baglanti.Open();
                    string sorgu = "INSERT INTO islem (islemadi, birimfiyati) VALUES (@adi, @fiyat)";
                    
                    using (var komut = new NpgsqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@adi", islem.IslemAdi);
                        komut.Parameters.AddWithValue("@fiyat", islem.BirimFiyati);

                        return komut.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("İşlem eklenirken hata oluştu: " + ex.Message);
            }
        }


        public static bool IslemGuncelle(string eskiAd, Islem islem)
        {
            try
            {
                using (var baglanti = VeritabaniBaglanti.BaglantiOlustur())
                {
                    baglanti.Open();
                    string sorgu = "UPDATE islem SET islemadi=@yeniadi, birimfiyati=@fiyat WHERE islemadi=@eskiadi";
                    
                    using (var komut = new NpgsqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@eskiadi", eskiAd);
                        komut.Parameters.AddWithValue("@yeniadi", islem.IslemAdi);
                        komut.Parameters.AddWithValue("@fiyat", islem.BirimFiyati);

                        return komut.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("İşlem güncellenirken hata oluştu: " + ex.Message);
            }
        }


        public static bool IslemSil(string islemAdi)
        {
            try
            {
                using (var baglanti = VeritabaniBaglanti.BaglantiOlustur())
                {
                    baglanti.Open();
                    string sorgu = "DELETE FROM islem WHERE islemadi = @adi";
                    
                    using (var komut = new NpgsqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@adi", islemAdi);
                        return komut.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("İşlem silinirken hata oluştu: " + ex.Message);
            }
        }
    }
}
