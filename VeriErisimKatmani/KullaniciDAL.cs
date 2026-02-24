using Npgsql;
using System;
using System.Collections.Generic;
using VarlikKatmani;

namespace VeriErisimKatmani
{
    
    public class KullaniciDAL
    {
        
        public static Kullanici GirisYap(string username, string sifre)
        {
            try
            {
                using (var baglanti = VeritabaniBaglanti.BaglantiOlustur())
                {
                    baglanti.Open();
                    string sorgu = "SELECT * FROM kullanici WHERE username = @username AND sifre = @sifre";
                    
                    using (var komut = new NpgsqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@username", username);
                        komut.Parameters.AddWithValue("@sifre", sifre);

                        using (var okuyucu = komut.ExecuteReader())
                        {
                            if (okuyucu.Read())
                            {
                                return new Kullanici
                                {
                                    Kodu = okuyucu.GetInt32(0),
                                    TcKimlikNo = okuyucu.IsDBNull(1) ? null : okuyucu.GetString(1),
                                    Ad = okuyucu.IsDBNull(2) ? null : okuyucu.GetString(2),
                                    Soyad = okuyucu.IsDBNull(3) ? null : okuyucu.GetString(3),
                                    DogumYeri = okuyucu.IsDBNull(4) ? null : okuyucu.GetString(4),
                                    DogumTarihi = okuyucu.IsDBNull(5) ? (DateTime?)null : okuyucu.GetDateTime(5),
                                    IseBaslama = okuyucu.IsDBNull(6) ? (DateTime?)null : okuyucu.GetDateTime(6),
                                    BabaAdi = okuyucu.IsDBNull(7) ? null : okuyucu.GetString(7),
                                    AnneAdi = okuyucu.IsDBNull(8) ? null : okuyucu.GetString(8),
                                    Cinsiyet = okuyucu.IsDBNull(9) ? null : okuyucu.GetString(9),
                                    KanGrubu = okuyucu.IsDBNull(10) ? null : okuyucu.GetString(10),
                                    MedeniHali = okuyucu.IsDBNull(11) ? null : okuyucu.GetString(11),
                                    Adres = okuyucu.IsDBNull(12) ? null : okuyucu.GetString(12),
                                    EvTel = okuyucu.IsDBNull(13) ? null : okuyucu.GetString(13),
                                    CepTel = okuyucu.IsDBNull(14) ? null : okuyucu.GetString(14),
                                    Unvan = okuyucu.IsDBNull(15) ? null : okuyucu.GetString(15),
                                    Sifre = okuyucu.IsDBNull(16) ? null : okuyucu.GetString(16),
                                    Yetki = okuyucu.GetBoolean(17),
                                    Maas = okuyucu.IsDBNull(18) ? (decimal?)null : okuyucu.GetDecimal(18),
                                    Username = okuyucu.IsDBNull(19) ? null : okuyucu.GetString(19)
                                };
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Giriş yapılırken hata oluştu: " + ex.Message);
            }
        }

        
        public static List<Kullanici> TumKullanicilariGetir()
        {
            List<Kullanici> kullanicilar = new List<Kullanici>();
            
            try
            {
                using (var baglanti = VeritabaniBaglanti.BaglantiOlustur())
                {
                    baglanti.Open();
                    string sorgu = "SELECT * FROM kullanici ORDER BY kodu";
                    
                    using (var komut = new NpgsqlCommand(sorgu, baglanti))
                    using (var okuyucu = komut.ExecuteReader())
                    {
                        while (okuyucu.Read())
                        {
                            kullanicilar.Add(new Kullanici
                            {
                                Kodu = okuyucu.GetInt32(0),
                                TcKimlikNo = okuyucu.IsDBNull(1) ? null : okuyucu.GetString(1),
                                Ad = okuyucu.IsDBNull(2) ? null : okuyucu.GetString(2),
                                Soyad = okuyucu.IsDBNull(3) ? null : okuyucu.GetString(3),
                                DogumYeri = okuyucu.IsDBNull(4) ? null : okuyucu.GetString(4),
                                DogumTarihi = okuyucu.IsDBNull(5) ? (DateTime?)null : okuyucu.GetDateTime(5),
                                IseBaslama = okuyucu.IsDBNull(6) ? (DateTime?)null : okuyucu.GetDateTime(6),
                                BabaAdi = okuyucu.IsDBNull(7) ? null : okuyucu.GetString(7),
                                AnneAdi = okuyucu.IsDBNull(8) ? null : okuyucu.GetString(8),
                                Cinsiyet = okuyucu.IsDBNull(9) ? null : okuyucu.GetString(9),
                                KanGrubu = okuyucu.IsDBNull(10) ? null : okuyucu.GetString(10),
                                MedeniHali = okuyucu.IsDBNull(11) ? null : okuyucu.GetString(11),
                                Adres = okuyucu.IsDBNull(12) ? null : okuyucu.GetString(12),
                                EvTel = okuyucu.IsDBNull(13) ? null : okuyucu.GetString(13),
                                CepTel = okuyucu.IsDBNull(14) ? null : okuyucu.GetString(14),
                                Unvan = okuyucu.IsDBNull(15) ? null : okuyucu.GetString(15),
                                Sifre = okuyucu.IsDBNull(16) ? null : okuyucu.GetString(16),
                                Yetki = okuyucu.GetBoolean(17),
                                Maas = okuyucu.IsDBNull(18) ? (decimal?)null : okuyucu.GetDecimal(18),
                                Username = okuyucu.IsDBNull(19) ? null : okuyucu.GetString(19)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Kullanıcılar getirilirken hata oluştu: " + ex.Message);
            }
            
            return kullanicilar;
        }

   
        public static bool KullaniciEkle(Kullanici kullanici)
        {
            try
            {
                using (var baglanti = VeritabaniBaglanti.BaglantiOlustur())
                {
                    baglanti.Open();
                    string sorgu = @"INSERT INTO kullanici (kodu, tckimlikno, ad, soyad, dogumyeri, dogumtarihi, 
                                    isebaslama, babaadi, anneadi, cinsiyet, kangrubu, medenihali, adres, 
                                    evtel, ceptel, unvan, sifre, yetki, maas, username) 
                                    VALUES (@kodu, @tc, @ad, @soyad, @dogumyeri, @dogumtarihi, 
                                    @isebaslama, @babaadi, @anneadi, @cinsiyet, @kangrubu, @medenihali, @adres, 
                                    @evtel, @ceptel, @unvan, @sifre, @yetki, @maas, @username)";
                    
                    using (var komut = new NpgsqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@kodu", kullanici.Kodu);
                        komut.Parameters.AddWithValue("@tc", (object)kullanici.TcKimlikNo ?? DBNull.Value);
                        komut.Parameters.AddWithValue("@ad", (object)kullanici.Ad ?? DBNull.Value);
                        komut.Parameters.AddWithValue("@soyad", (object)kullanici.Soyad ?? DBNull.Value);
                        komut.Parameters.AddWithValue("@dogumyeri", (object)kullanici.DogumYeri ?? DBNull.Value);
                        komut.Parameters.AddWithValue("@dogumtarihi", (object)kullanici.DogumTarihi ?? DBNull.Value);
                        komut.Parameters.AddWithValue("@isebaslama", (object)kullanici.IseBaslama ?? DBNull.Value);
                        komut.Parameters.AddWithValue("@babaadi", (object)kullanici.BabaAdi ?? DBNull.Value);
                        komut.Parameters.AddWithValue("@anneadi", (object)kullanici.AnneAdi ?? DBNull.Value);
                        komut.Parameters.AddWithValue("@cinsiyet", (object)kullanici.Cinsiyet ?? DBNull.Value);
                        komut.Parameters.AddWithValue("@kangrubu", (object)kullanici.KanGrubu ?? DBNull.Value);
                        komut.Parameters.AddWithValue("@medenihali", (object)kullanici.MedeniHali ?? DBNull.Value);
                        komut.Parameters.AddWithValue("@adres", (object)kullanici.Adres ?? DBNull.Value);
                        komut.Parameters.AddWithValue("@evtel", (object)kullanici.EvTel ?? DBNull.Value);
                        komut.Parameters.AddWithValue("@ceptel", (object)kullanici.CepTel ?? DBNull.Value);
                        komut.Parameters.AddWithValue("@unvan", (object)kullanici.Unvan ?? DBNull.Value);
                        komut.Parameters.AddWithValue("@sifre", (object)kullanici.Sifre ?? DBNull.Value);
                        komut.Parameters.AddWithValue("@yetki", kullanici.Yetki);
                        komut.Parameters.AddWithValue("@maas", (object)kullanici.Maas ?? DBNull.Value);
                        komut.Parameters.AddWithValue("@username", (object)kullanici.Username ?? DBNull.Value);

                        return komut.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Kullanıcı eklenirken hata oluştu: " + ex.Message);
            }
        }

      
        public static bool KullaniciGuncelle(Kullanici kullanici)
        {
            try
            {
                using (var baglanti = VeritabaniBaglanti.BaglantiOlustur())
                {
                    baglanti.Open();
                    string sorgu = @"UPDATE kullanici SET tckimlikno=@tc, ad=@ad, soyad=@soyad, 
                                    dogumyeri=@dogumyeri, dogumtarihi=@dogumtarihi, isebaslama=@isebaslama, 
                                    babaadi=@babaadi, anneadi=@anneadi, cinsiyet=@cinsiyet, kangrubu=@kangrubu, 
                                    medenihali=@medenihali, adres=@adres, evtel=@evtel, ceptel=@ceptel, 
                                    unvan=@unvan, sifre=@sifre, yetki=@yetki, maas=@maas, username=@username 
                                    WHERE kodu=@kodu";
                    
                    using (var komut = new NpgsqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@kodu", kullanici.Kodu);
                        komut.Parameters.AddWithValue("@tc", (object)kullanici.TcKimlikNo ?? DBNull.Value);
                        komut.Parameters.AddWithValue("@ad", (object)kullanici.Ad ?? DBNull.Value);
                        komut.Parameters.AddWithValue("@soyad", (object)kullanici.Soyad ?? DBNull.Value);
                        komut.Parameters.AddWithValue("@dogumyeri", (object)kullanici.DogumYeri ?? DBNull.Value);
                        komut.Parameters.AddWithValue("@dogumtarihi", (object)kullanici.DogumTarihi ?? DBNull.Value);
                        komut.Parameters.AddWithValue("@isebaslama", (object)kullanici.IseBaslama ?? DBNull.Value);
                        komut.Parameters.AddWithValue("@babaadi", (object)kullanici.BabaAdi ?? DBNull.Value);
                        komut.Parameters.AddWithValue("@anneadi", (object)kullanici.AnneAdi ?? DBNull.Value);
                        komut.Parameters.AddWithValue("@cinsiyet", (object)kullanici.Cinsiyet ?? DBNull.Value);
                        komut.Parameters.AddWithValue("@kangrubu", (object)kullanici.KanGrubu ?? DBNull.Value);
                        komut.Parameters.AddWithValue("@medenihali", (object)kullanici.MedeniHali ?? DBNull.Value);
                        komut.Parameters.AddWithValue("@adres", (object)kullanici.Adres ?? DBNull.Value);
                        komut.Parameters.AddWithValue("@evtel", (object)kullanici.EvTel ?? DBNull.Value);
                        komut.Parameters.AddWithValue("@ceptel", (object)kullanici.CepTel ?? DBNull.Value);
                        komut.Parameters.AddWithValue("@unvan", (object)kullanici.Unvan ?? DBNull.Value);
                        komut.Parameters.AddWithValue("@sifre", (object)kullanici.Sifre ?? DBNull.Value);
                        komut.Parameters.AddWithValue("@yetki", kullanici.Yetki);
                        komut.Parameters.AddWithValue("@maas", (object)kullanici.Maas ?? DBNull.Value);
                        komut.Parameters.AddWithValue("@username", (object)kullanici.Username ?? DBNull.Value);

                        return komut.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Kullanıcı güncellenirken hata oluştu: " + ex.Message);
            }
        }

      
        public static bool KullaniciSil(int kodu)
        {
            try
            {
                using (var baglanti = VeritabaniBaglanti.BaglantiOlustur())
                {
                    baglanti.Open();
                    string sorgu = "DELETE FROM kullanici WHERE kodu = @kodu";
                    
                    using (var komut = new NpgsqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@kodu", kodu);
                        return komut.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Kullanıcı silinirken hata oluştu: " + ex.Message);
            }
        }
        public static List<Kullanici> DoktorlariGetir()
        {
            List<Kullanici> doktorlar = new List<Kullanici>();
            
            try
            {
                using (var baglanti = VeritabaniBaglanti.BaglantiOlustur())
                {
                    baglanti.Open();
                    string sorgu = "SELECT * FROM kullanici WHERE unvan LIKE '%Dr%' OR unvan LIKE '%Doktor%' ORDER BY ad, soyad";
                    
                    using (var komut = new NpgsqlCommand(sorgu, baglanti))
                    using (var okuyucu = komut.ExecuteReader())
                    {
                        while (okuyucu.Read())
                        {
                            doktorlar.Add(new Kullanici
                            {
                                Kodu = okuyucu.GetInt32(0),
                                TcKimlikNo = okuyucu.IsDBNull(1) ? null : okuyucu.GetString(1),
                                Ad = okuyucu.IsDBNull(2) ? null : okuyucu.GetString(2),
                                Soyad = okuyucu.IsDBNull(3) ? null : okuyucu.GetString(3),
                                Unvan = okuyucu.IsDBNull(15) ? null : okuyucu.GetString(15)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Doktorlar getirilirken hata oluştu: " + ex.Message);
            }
            
            return doktorlar;
        }
    }
}
