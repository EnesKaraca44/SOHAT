using System;
using System.Windows.Forms;
using VarlikKatmani;
using VeriErisimKatmani;
using System.ComponentModel;

namespace SunumKatmani
{
    public partial class HastaBilgileriForm : Form
    {
        private Hasta mevcutHasta = null;
        public Hasta KaydedilenHasta { get; private set; }

        public HastaBilgileriForm()
        {
            InitializeComponent();
            YeniHasta();
        }

        public HastaBilgileriForm(Hasta hasta) : this()
        {
            mevcutHasta = hasta;
            HastaBilgileriniGoster();
        }

        private void HastaBilgileriForm_Load(object sender, EventArgs e)
        {
            ComboBoxlariDoldur();
        }

        private void ComboBoxlariDoldur()
        {
            // Cinsiyet
            cmbCinsiyet.Items.AddRange(new string[] { "Erkek", "Kadın" });

            // Medeni Hal
            cmbMedeniHal.Items.AddRange(new string[] { "Bekar", "Evli", "Dul", "Boşanmış" });

            // Kan Grubu
            cmbKanGrubu.Items.AddRange(new string[] { "A+", "A-", "B+", "B-", "AB+", "AB-", "0+", "0-" });
        }

        private void HastaBilgileriniGoster()
        {
            if (mevcutHasta != null)
            {
                txtDosyaNo.Text = mevcutHasta.DosyaNo;
                txtTcKimlikNo.Text = mevcutHasta.TcKimlikNo;
                txtAd.Text = mevcutHasta.Ad;
                txtSoyad.Text = mevcutHasta.Soyad;
                txtDogumYeri.Text = mevcutHasta.DogumYeri;
                if (mevcutHasta.DogumTarihi.HasValue)
                    dtpDogumTarihi.Value = mevcutHasta.DogumTarihi.Value;
                txtBabaAdi.Text = mevcutHasta.BabaAdi;
                txtAnneAdi.Text = mevcutHasta.AnneAdi;
                cmbCinsiyet.Text = mevcutHasta.Cinsiyet;
                cmbMedeniHal.Text = mevcutHasta.MedeniHali;
                cmbKanGrubu.Text = mevcutHasta.KanGrubu;
                txtAdres.Text = mevcutHasta.Adres;
                txtTelefon.Text = mevcutHasta.Tel;
                txtKurumSicilNo.Text = mevcutHasta.KurumSicilNo;
                txtKurumAdi.Text = mevcutHasta.KurumAdi;
                txtYakinTelefon.Text = mevcutHasta.YakinTel;
                txtYakinKurumSicilNo.Text = mevcutHasta.YakinKurumSicilNo;
                txtYakinKurumAdi.Text = mevcutHasta.YakinKurumAdi;
            }
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            YeniHasta();
        }

        private void YeniHasta()
        {
            mevcutHasta = null;
            txtDosyaNo.Clear();
            txtTcKimlikNo.Clear();
            txtAd.Clear();
            txtSoyad.Clear();
            txtDogumYeri.Clear();
            dtpDogumTarihi.Value = DateTime.Now;
            txtBabaAdi.Clear();
            txtAnneAdi.Clear();
            cmbCinsiyet.SelectedIndex = -1;
            cmbMedeniHal.SelectedIndex = -1;
            cmbKanGrubu.SelectedIndex = -1;
            txtAdres.Clear();
            txtTelefon.Clear();
            txtKurumSicilNo.Clear();
            txtKurumAdi.Clear();
            txtYakinTelefon.Clear();
            txtYakinKurumSicilNo.Clear();
            txtYakinKurumAdi.Clear();
            txtDosyaNo.Focus();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (!BilgileriKontrolEt())
                return;

            try
            {
                Hasta hasta = new Hasta
                {
                    DosyaNo = txtDosyaNo.Text.Trim(),
                    TcKimlikNo = txtTcKimlikNo.Text.Trim(),
                    Ad = txtAd.Text.Trim(),
                    Soyad = txtSoyad.Text.Trim(),
                    DogumYeri = txtDogumYeri.Text.Trim(),
                    DogumTarihi = dtpDogumTarihi.Value,
                    BabaAdi = txtBabaAdi.Text.Trim(),
                    AnneAdi = txtAnneAdi.Text.Trim(),
                    Cinsiyet = cmbCinsiyet.Text,
                    MedeniHali = cmbMedeniHal.Text,
                    KanGrubu = cmbKanGrubu.Text,
                    Adres = txtAdres.Text.Trim(),
                    Tel = txtTelefon.Text.Trim(),
                    KurumSicilNo = txtKurumSicilNo.Text.Trim(),
                    KurumAdi = txtKurumAdi.Text.Trim(),
                    YakinTel = txtYakinTelefon.Text.Trim(),
                    YakinKurumSicilNo = txtYakinKurumSicilNo.Text.Trim(),
                    YakinKurumAdi = txtYakinKurumAdi.Text.Trim()
                };

                bool basarili;
                if (mevcutHasta == null)
                {
                    basarili = HastaDAL.HastaEkle(hasta);
                }
                else
                {
                    basarili = HastaDAL.HastaGuncelle(hasta);
                }

                if (basarili)
                {
                    KaydedilenHasta = hasta;
                    MessageBox.Show("Hasta başarıyla kaydedildi!", "Başarılı",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Hasta kaydedilemedi!", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool BilgileriKontrolEt()
        {
            if (string.IsNullOrWhiteSpace(txtDosyaNo.Text))
            {
                MessageBox.Show("Lütfen dosya numarası giriniz!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDosyaNo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAd.Text))
            {
                MessageBox.Show("Lütfen hasta adını giriniz!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAd.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSoyad.Text))
            {
                MessageBox.Show("Lütfen hasta soyadını giriniz!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoyad.Focus();
                return false;
            }

            return true;
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
