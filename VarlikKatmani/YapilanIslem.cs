using System;

namespace VarlikKatmani
{
  
    public class YapilanIslem
    {
        public int IslemID { get; set; }
        public int SevkID { get; set; }
        public string Poliklinik { get; set; }
        public string IslemAdi { get; set; }
        public string DrKodu { get; set; }
        public int Miktar { get; set; }
        public decimal BirimFiyat { get; set; }
        public decimal Toplam { get; set; }

        public YapilanIslem()
        {
            Miktar = 1;
        }

        public YapilanIslem(int sevkID, string islemAdi, int miktar, decimal birimFiyat)
        {
            SevkID = sevkID;
            IslemAdi = islemAdi;
            Miktar = miktar;
            BirimFiyat = birimFiyat;
            Toplam = miktar * birimFiyat;
        }

   
        public void ToplamHesapla()
        {
            Toplam = Miktar * BirimFiyat;
        }
    }
}
