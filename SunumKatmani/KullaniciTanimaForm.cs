using System;
using System.ComponentModel;
using System.Windows.Forms;
using VarlikKatmani;
using VeriErisimKatmani;

namespace SunumKatmani
{
    public partial class KullaniciTanimaForm : Form
    {
        private Kullanici secilenKullanici = null;

        public KullaniciTanimaForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public KullaniciTanimaForm(Kullanici kullanici) : this()  //Önce parametresiz constructor'ı çağır

        {
            secilenKullanici = kullanici;
        }

        private void KullaniciTanimaForm_Load(object sender, EventArgs e)
        {
            
            ComboBoxlariDoldur();
            KullaniciSecildi(); // Seçilen kullanıcıyı göster
        }

        private void ComboBoxlariDoldur()
        {
            // Ünvan
            cmbUnvan.Items.AddRange(new string[] { "Sağlık Personel", "Doktor", "Hemşire", "Ebe", "Teknisyen" });
            
            // Cinsiyet
            cmbCinsiyet.Items.AddRange(new string[] { "Erkek", "Kadın" });
            
            // Medeni Hal
            cmbMedeniHal.Items.AddRange(new string[] { "Evli", "Bekar" });
            
            // Kan Grubu
            cmbKanGrubu.Items.AddRange(new string[] { "A Rh+", "A Rh-", "B Rh+", "B Rh-", "AB Rh+", "AB Rh-", "0 Rh+", "0 Rh-" });
        }

        private void KullanicilariYukle()
        {
            
        }

        private void cmbKullaniciKodu_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void KullaniciSecildi()
        {
            if (secilenKullanici != null)
            {
                Kullanici secili = secilenKullanici;
                txtKullaniciKodu.Text = secili.Kodu.ToString();
                
                txtTcKimlikNo.Text = secili.TcKimlikNo;
                txtDogumYeri.Text = secili.DogumYeri;
                txtBabaAdi.Text = secili.BabaAdi;
                txtAnneAdi.Text = secili.AnneAdi;
                txtTelefonNo.Text = secili.EvTel;
                txtGSM.Text = secili.CepTel;
                cmbUnvan.Text = secili.Unvan;
                txtAd.Text = secili.Ad;
                txtSoyad.Text = secili.Soyad;
                txtMaas.Text = secili.Maas?.ToString();
                
                if (secili.IseBaslama.HasValue)
                    dtpIseBaslama.Value = secili.IseBaslama.Value;
                
                if (secili.DogumTarihi.HasValue)
                    dtpDogumTarihi.Value = secili.DogumTarihi.Value;
                
                cmbCinsiyet.Text = secili.Cinsiyet;
                cmbMedeniHal.Text = secili.MedeniHali;
                cmbKanGrubu.Text = secili.KanGrubu;
                chkYetkili.Checked = secili.Yetki;
                txtAdres.Text = secili.Adres;
                txtKullaniciAd.Text = secili.Username;
                txtSifre.Text = secili.Sifre;
            }
        }

        private void btnYeniKullaniciEkle_Click(object sender, EventArgs e)
        {
            Temizle();
            // Yeni kullanıcı kodu oluştur
            try
            {
                var kullanicilar = KullaniciDAL.TumKullanicilariGetir();
                int yeniKod = 1;
                if (kullanicilar.Count > 0)
                {
                    yeniKod = kullanicilar[kullanicilar.Count - 1].Kodu + 1;
                }
                txtKullaniciKodu.Text = yeniKod.ToString();
            }
            catch { }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void Temizle()
        {
            txtKullaniciKodu.Clear();
            txtTcKimlikNo.Clear();
            txtDogumYeri.Clear();
            txtBabaAdi.Clear();
            txtAnneAdi.Clear();
            txtTelefonNo.Clear();
            txtGSM.Clear();
            cmbUnvan.SelectedIndex = -1;
            txtAd.Clear();
            txtSoyad.Clear();
            txtMaas.Clear();
            dtpIseBaslama.Value = DateTime.Now;
            dtpDogumTarihi.Value = DateTime.Now;
            cmbCinsiyet.SelectedIndex = -1;
            cmbMedeniHal.SelectedIndex = -1;
            cmbKanGrubu.SelectedIndex = -1;
            chkYetkili.Checked = false;
            txtAdres.Clear();
            txtKullaniciAd.Clear();
            txtSifre.Clear();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidasyonKontrol())
                    return;

                Kullanici kullanici = new Kullanici
                {
                    Kodu = int.Parse(txtKullaniciKodu.Text),
                    TcKimlikNo = txtTcKimlikNo.Text.Trim(),
                    Ad = txtAd.Text.Trim(),
                    Soyad = txtSoyad.Text.Trim(),
                    DogumYeri = txtDogumYeri.Text.Trim(),
                    DogumTarihi = dtpDogumTarihi.Value,
                    IseBaslama = dtpIseBaslama.Value,
                    BabaAdi = txtBabaAdi.Text.Trim(),
                    AnneAdi = txtAnneAdi.Text.Trim(),
                    Cinsiyet = cmbCinsiyet.Text,
                    KanGrubu = cmbKanGrubu.Text,
                    MedeniHali = cmbMedeniHal.Text,
                    Adres = txtAdres.Text.Trim(),
                    EvTel = txtTelefonNo.Text.Trim(),
                    CepTel = txtGSM.Text.Trim(),
                    Unvan = cmbUnvan.Text,
                    Sifre = txtSifre.Text,
                    Yetki = chkYetkili.Checked,
                    Maas = string.IsNullOrWhiteSpace(txtMaas.Text) ? (decimal?)null : decimal.Parse(txtMaas.Text),
                    Username = txtKullaniciAd.Text.Trim()
                };

                // Mevcut kullanıcı mı kontrol et
                var mevcutKullanici = KullaniciDAL.TumKullanicilariGetir().Find(k => k.Kodu == kullanici.Kodu);
                
                if (mevcutKullanici != null)
                {
                    // Güncelleme
                    if (KullaniciDAL.KullaniciGuncelle(kullanici))
                    {
                        MessageBox.Show("Kullanıcı başarıyla güncellendi!", "Başarılı", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else
                {
                    // Yeni ekleme
                    if (KullaniciDAL.KullaniciEkle(kullanici))
                    {
                        MessageBox.Show("Yeni kullanıcı başarıyla eklendi!", "Başarılı", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("İşlem sırasında hata oluştu: " + ex.Message, 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidasyonKontrol()
        {
            if (string.IsNullOrWhiteSpace(txtKullaniciKodu.Text))
            {
                MessageBox.Show("Kullanıcı kodu boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAd.Text))
            {
                MessageBox.Show("Ad boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAd.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSoyad.Text))
            {
                MessageBox.Show("Soyad boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoyad.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtKullaniciAd.Text))
            {
                MessageBox.Show("Kullanıcı adı boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKullaniciAd.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                MessageBox.Show("Şifre boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSifre.Focus();
                return false;
            }

            return true;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (secilenKullanici == null)
                {
                    MessageBox.Show("Kullanıcı bilgisi bulunamadı!", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Kullanici secili = secilenKullanici;

                DialogResult sonuc = MessageBox.Show(
                    $"'{secili.TamAd}' kullanıcısını silmek istediğinize emin misiniz?", 
                    "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (sonuc == DialogResult.Yes)
                {
                    if (KullaniciDAL.KullaniciSil(secili.Kodu))
                    {
                        MessageBox.Show("Kullanıcı başarıyla silindi!", "Başarılı", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme işlemi sırasında hata oluştu: " + ex.Message, 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
