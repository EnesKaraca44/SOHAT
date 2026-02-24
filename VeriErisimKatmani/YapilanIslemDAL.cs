using Npgsql;
using System;
using System.Collections.Generic;
using VarlikKatmani;

namespace VeriErisimKatmani
{

    public class YapilanIslemDAL
    {

        public static bool IslemEkle(YapilanIslem islem)
        {
            try
            {
                using (var baglanti = VeritabaniBaglanti.BaglantiOlustur())
                {
                    baglanti.Open();
                    
                    // Transaction başlat
                    using (var transaction = baglanti.BeginTransaction())
                    {
                        try
                        {
                            // İşlemi ekle
                            string sorgu = @"INSERT INTO yapilan_islemler (sevkid, islemadi, miktar, birimfiyat, toplam) 
                                            VALUES (@sevkid, @islemadi, @miktar, @birimfiyat, @toplam)";
                            
                            using (var komut = new NpgsqlCommand(sorgu, baglanti, transaction))
                            {
                                komut.Parameters.AddWithValue("@sevkid", islem.SevkID);
                                komut.Parameters.AddWithValue("@islemadi", islem.IslemAdi);
                                komut.Parameters.AddWithValue("@miktar", islem.Miktar);
                                komut.Parameters.AddWithValue("@birimfiyat", islem.BirimFiyat);
                                komut.Parameters.AddWithValue("@toplam", islem.Toplam);

                                komut.ExecuteNonQuery();
                            }

                            // Sevk toplam tutarını güncelle
                            string toplamGuncelle = @"UPDATE sevk SET toplamtutar = (
                                                        SELECT COALESCE(SUM(toplam), 0) 
                                                        FROM yapilan_islemler 
                                                        WHERE sevkid = @sevkid
                                                    ) WHERE sevkid = @sevkid";
                            
                            using (var komut = new NpgsqlCommand(toplamGuncelle, baglanti, transaction))
                            {
                                komut.Parameters.AddWithValue("@sevkid", islem.SevkID);
                                komut.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            return true;
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("İşlem eklenirken hata oluştu: " + ex.Message);
            }
        }


        public static bool IslemSil(int islemID)
        {
            try
            {
                using (var baglanti = VeritabaniBaglanti.BaglantiOlustur())
                {
                    baglanti.Open();
                    
                    using (var transaction = baglanti.BeginTransaction())
                    {
                        try
                        {
                            // Önce sevkID'yi al
                            int sevkID = 0;
                            string sevkSorgu = "SELECT sevkid FROM yapilan_islemler WHERE islemid = @id";
                            using (var komut = new NpgsqlCommand(sevkSorgu, baglanti, transaction))
                            {
                                komut.Parameters.AddWithValue("@id", islemID);
                                var sonuc = komut.ExecuteScalar();
                                if (sonuc != null)
                                    sevkID = Convert.ToInt32(sonuc);
                            }

                            // İşlemi sil
                            string sorgu = "DELETE FROM yapilan_islemler WHERE islemid = @id";
                            using (var komut = new NpgsqlCommand(sorgu, baglanti, transaction))
                            {
                                komut.Parameters.AddWithValue("@id", islemID);
                                komut.ExecuteNonQuery();
                            }

                            // Sevk toplam tutarını güncelle
                            if (sevkID > 0)
                            {
                                string toplamGuncelle = @"UPDATE sevk SET toplamtutar = (
                                                            SELECT COALESCE(SUM(toplam), 0) 
                                                            FROM yapilan_islemler 
                                                            WHERE sevkid = @sevkid
                                                        ) WHERE sevkid = @sevkid";
                                
                                using (var komut = new NpgsqlCommand(toplamGuncelle, baglanti, transaction))
                                {
                                    komut.Parameters.AddWithValue("@sevkid", sevkID);
                                    komut.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();
                            return true;
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("İşlem silinirken hata oluştu: " + ex.Message);
            }
        }

 
        public static List<YapilanIslem> SevkIslemleriniGetir(int sevkID)
        {
            List<YapilanIslem> islemler = new List<YapilanIslem>();
            
            try
            {
                using (var baglanti = VeritabaniBaglanti.BaglantiOlustur())
                {
                    baglanti.Open();
                    string sorgu = "SELECT * FROM yapilan_islemler WHERE sevkid = @sevkid ORDER BY islemid";
                    
                    using (var komut = new NpgsqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@sevkid", sevkID);

                        using (var okuyucu = komut.ExecuteReader())
                        {
                            while (okuyucu.Read())
                            {
                                islemler.Add(new YapilanIslem
                                {
                                    IslemID = okuyucu.GetInt32(0),
                                    SevkID = okuyucu.GetInt32(1),
                                    IslemAdi = okuyucu.IsDBNull(2) ? null : okuyucu.GetString(2),
                                    Miktar = okuyucu.GetInt32(3),
                                    BirimFiyat = okuyucu.GetDecimal(4),
                                    Toplam = okuyucu.GetDecimal(5)
                                });
                            }
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


        public static List<YapilanIslem> HastayaGoreGetir(string dosyaNo)
        {
            List<YapilanIslem> islemler = new List<YapilanIslem>();
            
            try
            {
                using (var baglanti = VeritabaniBaglanti.BaglantiOlustur())
                {
                    baglanti.Open();
                    
                    // Hastanın sevk kayıtlarını ve işlemlerini getir
                    string sorgu = @"SELECT yi.* FROM yapilan_islemler yi
                                    INNER JOIN sevk s ON yi.sevkid = s.sevkid
                                    WHERE s.dosyano = @dosyano AND s.taburcu = false
                                    ORDER BY yi.islemid DESC";
                    
                    using (var komut = new NpgsqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@dosyano", dosyaNo);

                        using (var okuyucu = komut.ExecuteReader())
                        {
                            while (okuyucu.Read())
                            {
                                islemler.Add(new YapilanIslem
                                {
                                    IslemID = okuyucu.GetInt32(0),
                                    SevkID = okuyucu.GetInt32(1),
                                    IslemAdi = okuyucu.IsDBNull(2) ? null : okuyucu.GetString(2),
                                    Miktar = okuyucu.GetInt32(3),
                                    BirimFiyat = okuyucu.GetDecimal(4),
                                    Toplam = okuyucu.GetDecimal(5)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hasta işlemleri getirilirken hata oluştu: " + ex.Message);
            }
            
            return islemler;
        }

  
        public static bool IslemGuncelle(YapilanIslem islem)
        {
            try
            {
                using (var baglanti = VeritabaniBaglanti.BaglantiOlustur())
                {
                    baglanti.Open();
                    
                    using (var transaction = baglanti.BeginTransaction())
                    {
                        try
                        {
                            string sorgu = @"UPDATE yapilan_islemler SET islemadi=@islemadi, miktar=@miktar, 
                                            birimfiyat=@birimfiyat, toplam=@toplam 
                                            WHERE islemid=@id";
                            
                            using (var komut = new NpgsqlCommand(sorgu, baglanti, transaction))
                            {
                                komut.Parameters.AddWithValue("@id", islem.IslemID);
                                komut.Parameters.AddWithValue("@islemadi", islem.IslemAdi);
                                komut.Parameters.AddWithValue("@miktar", islem.Miktar);
                                komut.Parameters.AddWithValue("@birimfiyat", islem.BirimFiyat);
                                komut.Parameters.AddWithValue("@toplam", islem.Toplam);

                                komut.ExecuteNonQuery();
                            }

                            // Sevk toplam tutarını güncelle
                            string toplamGuncelle = @"UPDATE sevk SET toplamtutar = (
                                                        SELECT COALESCE(SUM(toplam), 0) 
                                                        FROM yapilan_islemler 
                                                        WHERE sevkid = @sevkid
                                                    ) WHERE sevkid = @sevkid";
                            
                            using (var komut = new NpgsqlCommand(toplamGuncelle, baglanti, transaction))
                            {
                                komut.Parameters.AddWithValue("@sevkid", islem.SevkID);
                                komut.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            return true;
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("İşlem güncellenirken hata oluştu: " + ex.Message);
            }
        }
    }
}
