using System;

namespace VarlikKatmani
{
  
    public class Sevk
    {
        public int SevkID { get; set; }
        public string DosyaNo { get; set; }
        public DateTime SevkTarihi { get; set; }
        public string Saat { get; set; }
        public string Poliklinik { get; set; }
        public int? DrKod { get; set; }
        public int? SiraNo { get; set; }
        public decimal ToplamTutar { get; set; }
        public bool Taburcu { get; set; }
        public DateTime? CikisTarihi { get; set; }

       //ilişkili veriler için
        public string HastaAdi { get; set; }
        public string DoktorAdi { get; set; }

        public Sevk()
        {
            SevkTarihi = DateTime.Now.Date;
            ToplamTutar = 0;
            Taburcu = false;
        }

        public Sevk(string dosyaNo, DateTime sevkTarihi, string poliklinik)
        {
            DosyaNo = dosyaNo;
            SevkTarihi = sevkTarihi;
            Poliklinik = poliklinik;
            ToplamTutar = 0;
            Taburcu = false;
        }
    }
}
