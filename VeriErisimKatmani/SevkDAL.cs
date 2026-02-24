using Npgsql;
using System;
using System.Collections.Generic;
using VarlikKatmani;

namespace VeriErisimKatmani
{
   
    public class SevkDAL
    {
   
        public static int SevkEkle(Sevk sevk)
        {
            try
            {
                using (var baglanti = VeritabaniBaglanti.BaglantiOlustur())
                {
                    baglanti.Open();
                    string sorgu = @"INSERT INTO sevk (dosyano, sevktarihi, saat, poliklinik, drkod, sirano, toplamtutar, taburcu) 
                                    VALUES (@dosyano, @tarih, @saat, @poliklinik, @drkod, @sirano, @tutar, @taburcu) 
                                    RETURNING sevkid";
                    
                    using (var komut = new NpgsqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@dosyano", sevk.DosyaNo);
                        komut.Parameters.AddWithValue("@tarih", sevk.SevkTarihi);
                        komut.Parameters.AddWithValue("@saat", (object)sevk.Saat ?? DBNull.Value);
                        komut.Parameters.AddWithValue("@poliklinik", (object)sevk.Poliklinik ?? DBNull.Value);
                        komut.Parameters.AddWithValue("@drkod", (object)sevk.DrKod ?? DBNull.Value);
                        komut.Parameters.AddWithValue("@sirano", (object)sevk.SiraNo ?? DBNull.Value);
                        komut.Parameters.AddWithValue("@tutar", sevk.ToplamTutar);
                        komut.Parameters.AddWithValue("@taburcu", sevk.Taburcu);

                        var sonuc = komut.ExecuteScalar();
                        return Convert.ToInt32(sonuc);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sevk eklenirken hata oluştu: " + ex.Message);
            }
        }

       
        public static bool SevkGuncelle(Sevk sevk)
        {
            try
            {
                using (var baglanti = VeritabaniBaglanti.BaglantiOlustur())
                {
                    baglanti.Open();
                    string sorgu = @"UPDATE sevk SET dosyano=@dosyano, sevktarihi=@tarih, saat=@saat, 
                                    poliklinik=@poliklinik, drkod=@drkod, sirano=@sirano, 
                                    toplamtutar=@tutar, taburcu=@taburcu, cikistarihi=@cikis 
                                    WHERE sevkid=@id";
                    
                    using (var komut = new NpgsqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@id", sevk.SevkID);
                        komut.Parameters.AddWithValue("@dosyano", sevk.DosyaNo);
                        komut.Parameters.AddWithValue("@tarih", sevk.SevkTarihi);
                        komut.Parameters.AddWithValue("@saat", (object)sevk.Saat ?? DBNull.Value);
                        komut.Parameters.AddWithValue("@poliklinik", (object)sevk.Poliklinik ?? DBNull.Value);
                        komut.Parameters.AddWithValue("@drkod", (object)sevk.DrKod ?? DBNull.Value);
                        komut.Parameters.AddWithValue("@sirano", (object)sevk.SiraNo ?? DBNull.Value);
                        komut.Parameters.AddWithValue("@tutar", sevk.ToplamTutar);
                        komut.Parameters.AddWithValue("@taburcu", sevk.Taburcu);
                        komut.Parameters.AddWithValue("@cikis", (object)sevk.CikisTarihi ?? DBNull.Value);

                        return komut.ExecuteNonQuery() > 0;  //WHERE sevkid=@id koşuluna uyan bir kayıt bulunamadıysa 0 döner.
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sevk güncellenirken hata oluştu: " + ex.Message);
            }
        }

    
        public static bool HastaTaburcuEt(int sevkID)
        {
            try
            {
                using (var baglanti = VeritabaniBaglanti.BaglantiOlustur())
                {
                    baglanti.Open();
                    string sorgu = "UPDATE sevk SET taburcu=true, cikistarihi=@cikis WHERE sevkid=@id";
                    
                    using (var komut = new NpgsqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@id", sevkID);
                        komut.Parameters.AddWithValue("@cikis", DateTime.Now);

                        return komut.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hasta taburcu edilirken hata oluştu: " + ex.Message);
            }
        }


        public static List<Sevk> TariheGoreSevkleriGetir(DateTime tarih)
        {
            List<Sevk> sevkler = new List<Sevk>();
            
            try
            {
                using (var baglanti = VeritabaniBaglanti.BaglantiOlustur())
                {
                    baglanti.Open();
                    string sorgu = @"SELECT s.*, h.ad || ' ' || h.soyad as hastaadi, k.ad || ' ' || k.soyad as doktoradi 
                                    FROM sevk s 
                                    LEFT JOIN hasta h ON s.dosyano = h.dosyano 
                                    LEFT JOIN kullanici k ON s.drkod = k.kodu 
                                    WHERE s.sevktarihi = @tarih 
                                    ORDER BY s.sirano";
                    
                    using (var komut = new NpgsqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@tarih", tarih.Date);

                        using (var okuyucu = komut.ExecuteReader())
                        {
                            while (okuyucu.Read())
                            {
                                sevkler.Add(OkuyucudanSevkOlustur(okuyucu));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sevkler getirilirken hata oluştu: " + ex.Message);
            }
            
            return sevkler;
        }


        public static List<Sevk> DosyaNoIleSevkleriGetir(string dosyaNo)
        {
            List<Sevk> sevkler = new List<Sevk>();
            
            try
            {
                using (var baglanti = VeritabaniBaglanti.BaglantiOlustur())
                {
                    baglanti.Open();
                    string sorgu = @"SELECT s.*, h.ad || ' ' || h.soyad as hastaadi, k.ad || ' ' || k.soyad as doktoradi 
                                    FROM sevk s 
                                    LEFT JOIN hasta h ON s.dosyano = h.dosyano 
                                    LEFT JOIN kullanici k ON s.drkod = k.kodu 
                                    WHERE s.dosyano = @dosyano 
                                    ORDER BY s.sevktarihi DESC";
                    
                    using (var komut = new NpgsqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@dosyano", dosyaNo);

                        using (var okuyucu = komut.ExecuteReader())
                        {
                            while (okuyucu.Read())
                            {
                                sevkler.Add(OkuyucudanSevkOlustur(okuyucu));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sevkler getirilirken hata oluştu: " + ex.Message);
            }
            
            return sevkler;
        }


        public static Sevk SevkIDIleGetir(int sevkID)
        {
            try
            {
                using (var baglanti = VeritabaniBaglanti.BaglantiOlustur())
                {
                    baglanti.Open();
                    string sorgu = @"SELECT s.*, h.ad || ' ' || h.soyad as hastaadi, k.ad || ' ' || k.soyad as doktoradi 
                                    FROM sevk s 
                                    LEFT JOIN hasta h ON s.dosyano = h.dosyano 
                                    LEFT JOIN kullanici k ON s.drkod = k.kodu 
                                    WHERE s.sevkid = @id";
                    
                    using (var komut = new NpgsqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@id", sevkID);

                        using (var okuyucu = komut.ExecuteReader())
                        {
                            if (okuyucu.Read())
                            {
                                return OkuyucudanSevkOlustur(okuyucu);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sevk getirilirken hata oluştu: " + ex.Message);
            }
            
            return null;
        }


        public static Sevk BugunSevkGetir(string dosyaNo)
        {
            try
            {
                using (var baglanti = VeritabaniBaglanti.BaglantiOlustur())
                {
                    baglanti.Open();
                    string sorgu = @"SELECT s.*, h.ad || ' ' || h.soyad as hastaadi, k.ad || ' ' || k.soyad as doktoradi 
                                    FROM sevk s 
                                    LEFT JOIN hasta h ON s.dosyano = h.dosyano 
                                    LEFT JOIN kullanici k ON s.drkod = k.kodu 
                                    WHERE s.dosyano = @dosyano AND s.sevktarihi = @tarih";
                    
                    using (var komut = new NpgsqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@dosyano", dosyaNo);
                        komut.Parameters.AddWithValue("@tarih", DateTime.Now.Date);

                        using (var okuyucu = komut.ExecuteReader())
                        {
                            if (okuyucu.Read())
                            {
                                return OkuyucudanSevkOlustur(okuyucu);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sevk getirilirken hata oluştu: " + ex.Message);
            }
            
            return null;
        }


        public static int YeniSiraNoOlustur(DateTime tarih, string poliklinik)
        {
            try
            {
                using (var baglanti = VeritabaniBaglanti.BaglantiOlustur())
                {
                    baglanti.Open();
                    string sorgu = @"SELECT COALESCE(MAX(sirano), 0) + 1 
                                    FROM sevk 
                                    WHERE sevktarihi = @tarih AND poliklinik = @poliklinik";
                    
                    using (var komut = new NpgsqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@tarih", tarih.Date);
                        komut.Parameters.AddWithValue("@poliklinik", poliklinik);

                        var sonuc = komut.ExecuteScalar();
                        return Convert.ToInt32(sonuc);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sıra numarası oluşturulurken hata oluştu: " + ex.Message);
            }
        }

         //Veritabanı okuyucusundan (NpgsqlDataReader) gelen ham veriyi,  Sevk nesnesine dönüştürür.
        private static Sevk OkuyucudanSevkOlustur(NpgsqlDataReader okuyucu)
        {
            return new Sevk
            {
                SevkID = okuyucu.GetInt32(0),
                DosyaNo = okuyucu.GetString(1),
                SevkTarihi = okuyucu.GetDateTime(2),
                Saat = okuyucu.IsDBNull(3) ? null : okuyucu.GetString(3),
                Poliklinik = okuyucu.IsDBNull(4) ? null : okuyucu.GetString(4),
                DrKod = okuyucu.IsDBNull(5) ? (int?)null : okuyucu.GetInt32(5),
                SiraNo = okuyucu.IsDBNull(6) ? (int?)null : okuyucu.GetInt32(6),
                ToplamTutar = okuyucu.GetDecimal(7),
                Taburcu = okuyucu.GetBoolean(8),
                CikisTarihi = okuyucu.IsDBNull(9) ? (DateTime?)null : okuyucu.GetDateTime(9),
                HastaAdi = okuyucu.IsDBNull(10) ? null : okuyucu.GetString(10),
                DoktorAdi = okuyucu.IsDBNull(11) ? null : okuyucu.GetString(11)
            };
        }
    }
}
