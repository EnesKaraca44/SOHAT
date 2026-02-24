using System;
using System.ComponentModel;
using System.Windows.Forms;
using VarlikKatmani;
using VeriErisimKatmani;

namespace SunumKatmani
{
    public partial class KullaniciSecimForm : Form
    {
        public KullaniciSecimForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void KullaniciSecimForm_Load(object sender, EventArgs e)
        {
            KullanicilariYukle();
        }

        private void KullanicilariYukle()
        {
            try
            {
                var kullanicilar = KullaniciDAL.TumKullanicilariGetir();
                cmbKullaniciKodu.DataSource = kullanicilar;
                cmbKullaniciKodu.DisplayMember = "TamAd";
                cmbKullaniciKodu.ValueMember = "Kodu";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcılar yüklenirken hata oluştu: " + ex.Message, 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnYeniKullaniciEkle_Click(object sender, EventArgs e)
        {
            // Yeni kullanıcı ekleme formu aç
            KullaniciTanimaForm form = new KullaniciTanimaForm();
            form.ShowDialog();
            
            // Form kapandıktan sonra listeyi yenile
            KullanicilariYukle();
        }

        private void cmbKullaniciKodu_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            // Düzenle butonuna basıldığında formu aç
            if (cmbKullaniciKodu.SelectedItem != null)
            {
                Kullanici secili = (Kullanici)cmbKullaniciKodu.SelectedItem;
                KullaniciTanimaForm form = new KullaniciTanimaForm(secili);
                form.ShowDialog();
                
                // Form kapandıktan sonra listeyi yenile
                KullanicilariYukle();
            }
            else
            {
                MessageBox.Show("Lütfen düzenlenecek kullanıcıyı seçiniz!", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cmbKullaniciKodu_DoubleClick(object sender, EventArgs e)
        {
            // Çift tıklandığında da düzenleme formu aç
            btnDuzenle_Click(sender, e);
        }
    }
}
