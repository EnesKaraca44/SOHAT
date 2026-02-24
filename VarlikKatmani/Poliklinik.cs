using System;

namespace VarlikKatmani
{

    public class Poliklinik
    {
        public string PoliklinikAdi { get; set; }
        public bool Durum { get; set; }
        public string Aciklama { get; set; }

        public Poliklinik()
        {
            Durum = true;
        }

        public Poliklinik(string poliklinikAdi, bool durum, string aciklama)
        {
            PoliklinikAdi = poliklinikAdi;
            Durum = durum;
            Aciklama = aciklama;
        }
    }
}
