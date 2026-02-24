using System;

namespace VarlikKatmani
{

    public class Hasta
    {
        public string TcKimlikNo { get; set; }
        public string DosyaNo { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string DogumYeri { get; set; }
        public DateTime? DogumTarihi { get; set; }
        public string BabaAdi { get; set; }
        public string AnneAdi { get; set; }
        public string Cinsiyet { get; set; }
        public string KanGrubu { get; set; }
        public string MedeniHali { get; set; }
        public string Adres { get; set; }
        public string Tel { get; set; }
        public string KurumSicilNo { get; set; }
        public string KurumAdi { get; set; }
        public string YakinTel { get; set; }
        public string YakinKurumSicilNo { get; set; }
        public string YakinKurumAdi { get; set; }

        public Hasta()
        {
        }

        public Hasta(string dosyaNo, string tcKimlikNo, string ad, string soyad)
        {
            DosyaNo = dosyaNo;
            TcKimlikNo = tcKimlikNo;
            Ad = ad;
            Soyad = soyad;
        }

        public string TamAd
        {
            get { return $"{Ad} {Soyad}"; }  //DataGridView'de hasta listesinde gösterim
        }


        public int? Yas
        {                  //Doðum tarihinden otomatik olarak yaþý hesaplar.
            get
            {
                if (DogumTarihi.HasValue)
                {
                    int yas = DateTime.Now.Year - DogumTarihi.Value.Year;
                    if (DateTime.Now < DogumTarihi.Value.AddYears(yas))
                        yas--;
                    return yas;
                }
                return null;
            }
        }
    }
}
