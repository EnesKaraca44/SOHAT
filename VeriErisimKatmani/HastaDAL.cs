using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using VarlikKatmani;

namespace VeriErisimKatmani
{

    public class HastaDAL
    {

        public static List<Hasta> TumHastalariGetir()
        {
            List<Hasta> hastalar = new List<Hasta>();
            
            try
            {
                using (var baglanti = VeritabaniBaglanti.BaglantiOlustur())
                {
                    baglanti.Open();
                    string sorgu = "SELECT * FROM hasta ORDER BY ad, soyad";
                    
                    using (var komut = new NpgsqlCommand(sorgu, baglanti))
                    using (var okuyucu = komut.ExecuteReader())
                    {
                        while (okuyucu.Read())
                        {
                            hastalar.Add(OkuyucudanHastaOlustur(okuyucu));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hastalar getirilirken hata oluştu: " + ex.Message);
            }
            
            return hastalar;
        }


        public static Hasta DosyaNoIleGetir(string dosyaNo)
        {
            try
            {
               
                var tumHastalar = TumHastalariGetir();
                var arananDosyaNo = dosyaNo?.Trim() ?? "";
                
                foreach (var hasta in tumHastalar)
                {
                    var hastaDosyaNo = hasta.DosyaNo?.Trim() ?? "";
                    if (hastaDosyaNo.Equals(arananDosyaNo, StringComparison.OrdinalIgnoreCase))
                    {
                        return hasta;
                    }
                }
                
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Hasta getirilirken hata oluştu: " + ex.Message);
            }
        }


        public static Hasta TcIleAra(string tcKimlikNo)
        {
            try
            {
                using (var baglanti = VeritabaniBaglanti.BaglantiOlustur())
                {
                    baglanti.Open();
                    string sorgu = "SELECT * FROM hasta WHERE tckimlikno = @tc";
                    
                    using (var komut = new NpgsqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@tc", tcKimlikNo);

                        using (var okuyucu = komut.ExecuteReader())
                        {
                            if (okuyucu.Read())
                            {
                                return OkuyucudanHastaOlustur(okuyucu);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hasta aranırken hata oluştu: " + ex.Message);
            }
            
            return null;
        }


        public static bool HastaEkle(Hasta hasta)
        {
            try
            {
                using (var baglanti = VeritabaniBaglanti.BaglantiOlustur())
                {
                    baglanti.Open();
                    string sorgu = @"INSERT INTO hasta (tckimlikno, dosyano, ad, soyad, dogumyeri, dogumtarihi, 
                                    babaadi, anneadi, cinsiyet, kangrubu, medenihali, adres, tel, 
                                    kurumsicilno, kurumadi, yakintel, yakinkurumsicilno, yakinkurumadi) 
                                    VALUES (@tc, @dosyano, @ad, @soyad, @dogumyeri, @dogumtarihi, 
                                    @babaadi, @anneadi, @cinsiyet, @kangrubu, @medenihali, @adres, @tel, 
                                    @kurumsicilno, @kurumadi, @yakintel, @yakinkurumsicilno, @yakinkurumadi)";
                    
                    using (var komut = new NpgsqlCommand(sorgu, baglanti))
                    {
                        ParametreleriEkle(komut, hasta);
                        return komut.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hasta eklenirken hata oluştu: " + ex.Message);
            }
        }

        public static bool HastaGuncelle(Hasta hasta)
        {
            try
            {
                using (var baglanti = VeritabaniBaglanti.BaglantiOlustur())
                {
                    baglanti.Open();
                    string sorgu = @"UPDATE hasta SET tckimlikno=@tc, ad=@ad, soyad=@soyad, 
                                    dogumyeri=@dogumyeri, dogumtarihi=@dogumtarihi, babaadi=@babaadi, 
                                    anneadi=@anneadi, cinsiyet=@cinsiyet, kangrubu=@kangrubu, 
                                    medenihali=@medenihali, adres=@adres, tel=@tel, 
                                    kurumsicilno=@kurumsicilno, kurumadi=@kurumadi, yakintel=@yakintel, 
                                    yakinkurumsicilno=@yakinkurumsicilno, yakinkurumadi=@yakinkurumadi 
                                    WHERE dosyano=@dosyano";
                    
                    using (var komut = new NpgsqlCommand(sorgu, baglanti))
                    {
                        ParametreleriEkle(komut, hasta);
                        return komut.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hasta güncellenirken hata oluştu: " + ex.Message);
            }
        }

        public static bool HastaSil(string dosyaNo)
        {
            try
            {
                using (var baglanti = VeritabaniBaglanti.BaglantiOlustur())
                {
                    baglanti.Open();
                    string sorgu = "DELETE FROM hasta WHERE dosyano = @dosyano";
                    
                    using (var komut = new NpgsqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@dosyano", dosyaNo);
                        return komut.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hasta silinirken hata oluştu: " + ex.Message);
            }
        }


        public static List<Hasta> HastaAra(string aramaMetni)
        {
            List<Hasta> hastalar = new List<Hasta>();
            
            try
            {
                using (var baglanti = VeritabaniBaglanti.BaglantiOlustur())
                {
                    baglanti.Open();
                    string sorgu = @"SELECT * FROM hasta WHERE 
                                    LOWER(ad) LIKE LOWER(@arama) OR 
                                    LOWER(soyad) LIKE LOWER(@arama) OR 
                                    tckimlikno LIKE @arama OR 
                                    dosyano LIKE @arama 
                                    ORDER BY ad, soyad";
                    
                    using (var komut = new NpgsqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@arama", "%" + aramaMetni + "%");

                        using (var okuyucu = komut.ExecuteReader())
                        {
                            while (okuyucu.Read())
                            {
                                hastalar.Add(OkuyucudanHastaOlustur(okuyucu));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hasta aranırken hata oluştu: " + ex.Message);
            }
            
            return hastalar;
        }

   
        private static Hasta OkuyucudanHastaOlustur(NpgsqlDataReader okuyucu)
        {
            return new Hasta
            {
                TcKimlikNo = okuyucu.IsDBNull(0) ? null : okuyucu.GetString(0),
                DosyaNo = okuyucu.GetString(1),
                Ad = okuyucu.IsDBNull(2) ? null : okuyucu.GetString(2),
                Soyad = okuyucu.IsDBNull(3) ? null : okuyucu.GetString(3),
                DogumYeri = okuyucu.IsDBNull(4) ? null : okuyucu.GetString(4),
                DogumTarihi = okuyucu.IsDBNull(5) ? (DateTime?)null : okuyucu.GetDateTime(5),
                BabaAdi = okuyucu.IsDBNull(6) ? null : okuyucu.GetString(6),
                AnneAdi = okuyucu.IsDBNull(7) ? null : okuyucu.GetString(7),
                Cinsiyet = okuyucu.IsDBNull(8) ? null : okuyucu.GetString(8),
                KanGrubu = okuyucu.IsDBNull(9) ? null : okuyucu.GetString(9),
                MedeniHali = okuyucu.IsDBNull(10) ? null : okuyucu.GetString(10),
                Adres = okuyucu.IsDBNull(11) ? null : okuyucu.GetString(11),
                Tel = okuyucu.IsDBNull(12) ? null : okuyucu.GetString(12),
                KurumSicilNo = okuyucu.IsDBNull(13) ? null : okuyucu.GetString(13),
                KurumAdi = okuyucu.IsDBNull(14) ? null : okuyucu.GetString(14),
                YakinTel = okuyucu.IsDBNull(15) ? null : okuyucu.GetString(15),
                YakinKurumSicilNo = okuyucu.IsDBNull(16) ? null : okuyucu.GetString(16),
                YakinKurumAdi = okuyucu.IsDBNull(17) ? null : okuyucu.GetString(17)
            };
        }

        private static void ParametreleriEkle(NpgsqlCommand komut, Hasta hasta)
        {
            komut.Parameters.AddWithValue("@tc", (object)hasta.TcKimlikNo ?? DBNull.Value);
            komut.Parameters.AddWithValue("@dosyano", hasta.DosyaNo);
            komut.Parameters.AddWithValue("@ad", (object)hasta.Ad ?? DBNull.Value);
            komut.Parameters.AddWithValue("@soyad", (object)hasta.Soyad ?? DBNull.Value);
            komut.Parameters.AddWithValue("@dogumyeri", (object)hasta.DogumYeri ?? DBNull.Value);
            komut.Parameters.AddWithValue("@dogumtarihi", (object)hasta.DogumTarihi ?? DBNull.Value);
            komut.Parameters.AddWithValue("@babaadi", (object)hasta.BabaAdi ?? DBNull.Value);
            komut.Parameters.AddWithValue("@anneadi", (object)hasta.AnneAdi ?? DBNull.Value);
            komut.Parameters.AddWithValue("@cinsiyet", (object)hasta.Cinsiyet ?? DBNull.Value);
            komut.Parameters.AddWithValue("@kangrubu", (object)hasta.KanGrubu ?? DBNull.Value);
            komut.Parameters.AddWithValue("@medenihali", (object)hasta.MedeniHali ?? DBNull.Value);
            komut.Parameters.AddWithValue("@adres", (object)hasta.Adres ?? DBNull.Value);
            komut.Parameters.AddWithValue("@tel", (object)hasta.Tel ?? DBNull.Value);
            komut.Parameters.AddWithValue("@kurumsicilno", (object)hasta.KurumSicilNo ?? DBNull.Value);
            komut.Parameters.AddWithValue("@kurumadi", (object)hasta.KurumAdi ?? DBNull.Value);
            komut.Parameters.AddWithValue("@yakintel", (object)hasta.YakinTel ?? DBNull.Value);
            komut.Parameters.AddWithValue("@yakinkurumsicilno", (object)hasta.YakinKurumSicilNo ?? DBNull.Value);
            komut.Parameters.AddWithValue("@yakinkurumadi", (object)hasta.YakinKurumAdi ?? DBNull.Value);
        }
    }
}
