using System;

namespace VarlikKatmani
{
    
    public class Islem
    {
        public string IslemAdi { get; set; }
        public decimal BirimFiyati { get; set; }



        //Boþ constructor olmadan veritabanýndan veri okuyamazsýn
        public Islem()  
        {                      
        }

        public Islem(string islemAdi, decimal birimFiyati)
        {
            IslemAdi = islemAdi;
            BirimFiyati = birimFiyati;
        }
    }
}
