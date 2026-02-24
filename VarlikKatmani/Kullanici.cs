using System;

namespace VarlikKatmani
{
  
    public class Kullanici
    {
        public int Kodu { get; set; }
        public string TcKimlikNo { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string DogumYeri { get; set; }
        public DateTime? DogumTarihi { get; set; }
        public DateTime? IseBaslama { get; set; }
        public string BabaAdi { get; set; }
        public string AnneAdi { get; set; }
        public string Cinsiyet { get; set; }
        public string KanGrubu { get; set; }
        public string MedeniHali { get; set; }
        public string Adres { get; set; }
        public string EvTel { get; set; }
        public string CepTel { get; set; }
        public string Unvan { get; set; }
        public string Sifre { get; set; }
        public bool Yetki { get; set; } // True: Yönetici, False: Personel
        public decimal? Maas { get; set; }
        public string Username { get; set; }

        public Kullanici()
        {
        }

        public Kullanici(int kodu, string ad, string soyad, string username, string sifre, bool yetki)
        {
            Kodu = kodu;
            Ad = ad;
            Soyad = soyad;
            Username = username;
            Sifre = sifre;
            Yetki = yetki;
        }


        public string TamAd
        {
            get { return $"{Ad} {Soyad}"; }
        }
    }
}
