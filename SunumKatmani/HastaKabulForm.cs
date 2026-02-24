using System;
using System.Windows.Forms;
using VarlikKatmani;
using VeriErisimKatmani;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Drawing.Printing;

namespace SunumKatmani
{
    public partial class HastaKabulForm : Form
    {
        private List<YapilanIslem> yapilanIslemler = new List<YapilanIslem>();
        private Hasta aktifHasta = null;
        private decimal toplamTutar = 0;
        private int aktifSevkID = 0; // Aktif sevk ID'si

        public HastaKabulForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void HastaKabulForm_Load(object sender, EventArgs e)
        {
            ComboBoxlariDoldur();
            YeniHasta();
        }

        private void ComboBoxlariDoldur()
        {
            try
            {
                // Öncelikli hasta seçenekleri
                cmbOncelikliHasta.Items.AddRange(new string[] { "Normal", "Acil", "Öncelikli" });
                cmbOncelikliHasta.SelectedIndex = 0; // Varsayılan: Normal
                
                // Poliklinik listesi
                var poliklinikler = PoliklinikDAL.TumPoliklinikeleriGetir();
                cmbPoliklinik.DataSource = poliklinikler;
                cmbPoliklinik.DisplayMember = "PoliklinikAdi";
                cmbPoliklinik.ValueMember = "PoliklinikAdi";

                // İşlem listesi
                var islemler = IslemDAL.TumIslemleriGetir();
                
                if (islemler == null || islemler.Count == 0)
                {
                    MessageBox.Show("Veritabanında hiç işlem tanımlı değil!\n\nLütfen önce işlem tanımlayın.", 
                        "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
                cmbYapilanIslem.DataSource = islemler;
                cmbYapilanIslem.DisplayMember = "IslemAdi";
                cmbYapilanIslem.ValueMember = "IslemAdi";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veriler yüklenirken hata:\n{ex.Message}\n\nStack Trace:\n{ex.StackTrace}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            DosyaBulForm form = new DosyaBulForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                aktifHasta = form.SecilenHasta;
                if (aktifHasta != null)
                {
                    txtDosyaNo.Text = aktifHasta.DosyaNo;
                    HastaBilgileriniGoster();
                }
            }
        }

        private void txtDosyaNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Bip sesini engelle
                
                if (!string.IsNullOrWhiteSpace(txtDosyaNo.Text))
                {
                    string dosyaNo = txtDosyaNo.Text.Trim();
                    aktifHasta = HastaDAL.DosyaNoIleGetir(dosyaNo);

                    if (aktifHasta != null)
                    {
                        HastaBilgileriniGoster();
                    }
                    else
                    {
                        MessageBox.Show($"Dosya No '{dosyaNo}' ile hasta bulunamadı!\n\nDetaylı arama için 'Bul' butonunu kullanın.", 
                            "Hasta Bulunamadı", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnGit_Click(object sender, EventArgs e)
        {
            // Git butonu: Sadece mevcut işlemleri listele/yenile
            // Debug: Kaç işlem var?
            MessageBox.Show($"Bellekte {yapilanIslemler.Count} işlem var", "Debug", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            DataGridGuncelle();
            ToplamHesapla();
        }

        private void HastaBilgileriniGoster()
        {
            if (aktifHasta != null)
            {
                txtDosyaNo.Text = aktifHasta.DosyaNo.ToString();
                txtHastaAdi.Text = aktifHasta.Ad;
                txtSoyad.Text = aktifHasta.Soyad;
                txtDogumAdi.Text = aktifHasta.DogumYeri;
                
                // Hastanın önceki işlemlerini yükle
                YapilanIslemleriYukle();
            }
        }

        private void YapilanIslemleriYukle()
        {
            try
            {
                if (aktifHasta == null)
                    return;
                
                // Hastanın daha önce kaydedilmiş işlemlerini veritabanından getir
                var dbIslemler = YapilanIslemDAL.HastayaGoreGetir(aktifHasta.DosyaNo);
                
                if (dbIslemler != null && dbIslemler.Count > 0)
                {
                    yapilanIslemler.Clear();
                    yapilanIslemler.AddRange(dbIslemler);
                    
                    // aktifSevkID'yi set et (ilk işlemin sevkID'si)
                    aktifSevkID = dbIslemler[0].SevkID;
                }
                
                DataGridGuncelle();
                ToplamHesapla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("İşlemler yüklenirken hata: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (aktifHasta == null)
            {
                MessageBox.Show("Önce hasta seçiniz!", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbYapilanIslem.SelectedItem == null)
            {
                MessageBox.Show("Lütfen işlem seçiniz!", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Islem seciliIslem = (Islem)cmbYapilanIslem.SelectedItem;
                int miktar = string.IsNullOrWhiteSpace(txtMiktar.Text) ? 1 : int.Parse(txtMiktar.Text);
                decimal birimFiyat = string.IsNullOrWhiteSpace(txtBirimFiyat.Text) ? 
                    seciliIslem.BirimFiyati : decimal.Parse(txtBirimFiyat.Text);

                YapilanIslem yeniIslem = new YapilanIslem
                {
                    SevkID = 0,
                    Poliklinik = cmbPoliklinik.Text,
                    IslemAdi = seciliIslem.IslemAdi,
                    DrKodu = txtDrKodu.Text,
                    Miktar = miktar,
                    BirimFiyat = birimFiyat
                };
                yeniIslem.ToplamHesapla();

                // Sevk kaydı oluştur (eğer yoksa)
                if (aktifSevkID == 0)
                {
                    try
                    {
                        // Önce bugün için sevk kaydı var mı kontrol et
                        var mevcutSevk = SevkDAL.BugunSevkGetir(aktifHasta.DosyaNo);
                        if (mevcutSevk != null)
                        {
                            aktifSevkID = mevcutSevk.SevkID;
                        }
                        else
                        {
                            // Yeni sevk kaydı oluştur
                            Sevk yeniSevk = new Sevk
                            {
                                DosyaNo = aktifHasta.DosyaNo,
                                SevkTarihi = dtpSiraTarih.Value,
                                Poliklinik = cmbPoliklinik.Text,
                                ToplamTutar = 0
                            };
                            aktifSevkID = SevkDAL.SevkEkle(yeniSevk);
                        }
                    }
                    catch (Exception sevkEx)
                    {
                        MessageBox.Show("Sevk kaydı oluşturulurken hata: " + sevkEx.Message, "Hata",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // İşlemi veritabanına kaydet
                yeniIslem.SevkID = aktifSevkID;
                YapilanIslemDAL.IslemEkle(yeniIslem);

                // Listeye ekle
                yapilanIslemler.Add(yeniIslem);
                DataGridGuncelle();
                ToplamHesapla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("İşlem eklenirken hata: " + ex.Message, "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridGuncelle()
        {
            dgvIslemler.DataSource = null;
            dgvIslemler.DataSource = yapilanIslemler;
            
            // Gereksiz kolonları gizle
            if (dgvIslemler.Columns.Contains("IslemID"))
                dgvIslemler.Columns["IslemID"].Visible = false;
            if (dgvIslemler.Columns.Contains("SevkID"))
                dgvIslemler.Columns["SevkID"].Visible = false;
            
            // Kolon başlıklarını düzenle
            if (dgvIslemler.Columns.Contains("Poliklinik"))
                dgvIslemler.Columns["Poliklinik"].HeaderText = "POLİKLİNİK";
            if (dgvIslemler.Columns.Contains("IslemAdi"))
                dgvIslemler.Columns["IslemAdi"].HeaderText = "YAPILAN İŞLEM";
            if (dgvIslemler.Columns.Contains("DrKodu"))
                dgvIslemler.Columns["DrKodu"].HeaderText = "DR.KODU";
            if (dgvIslemler.Columns.Contains("Miktar"))
                dgvIslemler.Columns["Miktar"].HeaderText = "MİKTAR";
            if (dgvIslemler.Columns.Contains("BirimFiyat"))
                dgvIslemler.Columns["BirimFiyat"].HeaderText = "BİRİM FİYATI";
            if (dgvIslemler.Columns.Contains("Toplam"))
                dgvIslemler.Columns["Toplam"].HeaderText = "TOPLAM";
        }

        private void ToplamHesapla()
        {
            toplamTutar = 0;
            foreach (var islem in yapilanIslemler)
            {
                toplamTutar += islem.Toplam;
            }
            lblToplamTutar.Text = $"Toplam Tutar: {toplamTutar:C2}";
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            HastaBilgileriForm form = new HastaBilgileriForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                // Hasta kaydedildi, bilgileri al
                aktifHasta = form.KaydedilenHasta;
                if (aktifHasta != null)
                {
                    txtDosyaNo.Text = aktifHasta.DosyaNo;
                    HastaBilgileriniGoster();
                }
            }
        }

        private void YeniHasta()
        {
            aktifHasta = null;
            txtDosyaNo.Clear();
            txtHastaAdi.Clear();
            txtSoyad.Clear();
            txtDogumAdi.Clear();
            // yapilanIslemler.Clear(); // KALDIRILDI - işlemler korunsun
            DataGridGuncelle();
            toplamTutar = 0;
            lblToplamTutar.Text = "Toplam Tutar: 0,00 ₺";
            dtpSiraTarih.Value = DateTime.Now;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvIslemler.SelectedRows.Count > 0)
            {
                int index = dgvIslemler.SelectedRows[0].Index;
                yapilanIslemler.RemoveAt(index);
                DataGridGuncelle();
                ToplamHesapla();
            }
        }

        private void btnTaburcu_Click(object sender, EventArgs e)
        {
            if (aktifHasta == null)
            {
                MessageBox.Show("Önce hasta seçiniz!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (aktifSevkID == 0)
            {
                MessageBox.Show("Henüz işlem eklenmemiş!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Sevk kaydını getir
                Sevk aktifSevk = SevkDAL.SevkIDIleGetir(aktifSevkID);
                if (aktifSevk == null)
                {
                    MessageBox.Show("Sevk kaydı bulunamadı!", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Taburcu ödeme formunu aç
                TaburcuOdemeForm odemeForm = new TaburcuOdemeForm();
                odemeForm.AktifSevk = aktifSevk;
                odemeForm.ToplamTutar = yapilanIslemler.Sum(i => i.Toplam);

                if (odemeForm.ShowDialog() == DialogResult.OK)
                {
                    // Ödeme yapıldı - hastayı taburcu et
                    SevkDAL.HastaTaburcuEt(aktifSevkID);

                    MessageBox.Show("Hasta başarıyla taburcu edildi!", "Başarılı",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Formu temizle
                    YeniHasta();
                    aktifSevkID = 0;
                    yapilanIslemler.Clear();
                    DataGridGuncelle();
                    ToplamHesapla();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Taburcu işlemi sırasında hata: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            if (aktifHasta == null)
            {
                MessageBox.Show("Lütfen önce bir hasta seçiniz!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                PrintDocument printDoc = new PrintDocument();
                printDoc.PrintPage += PrintDoc_PrintPage;
                
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDoc;
                
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDoc.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Yazdırma hatası: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBaskaOnizleme_Click(object sender, EventArgs e)
        {
            if (aktifHasta == null)
            {
                MessageBox.Show("Lütfen önce bir hasta seçiniz!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                PrintDocument printDoc = new PrintDocument();
                printDoc.PrintPage += PrintDoc_PrintPage;
                
                PrintPreviewDialog previewDialog = new PrintPreviewDialog();
                previewDialog.Document = printDoc;
                previewDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Önizleme hatası: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Yazı tipleri
            Font baslikFont = new Font("Arial", 16, FontStyle.Bold);
            Font normalFont = new Font("Arial", 10);
            Font kucukFont = new Font("Arial", 8);
            
            // Kalemler
            Pen kalem = new Pen(Color.Black, 1);
            
            // Başlangıç pozisyonları
            int x = 100;
            int y = 100;
            
            // Başlık
            string baslik = $"Hasta Sevk İşlemleri : {aktifHasta.Ad} {aktifHasta.Soyad}";
            e.Graphics.DrawString(baslik, baslikFont, Brushes.Black, x, y);
            y += 40;
            
            // Tablo başlıkları
            e.Graphics.DrawString("POLİKLİNİK", normalFont, Brushes.Black, x, y);
            e.Graphics.DrawString("SIRA NO", normalFont, Brushes.Black, x + 120, y);
            e.Graphics.DrawString("HASTA ADI", normalFont, Brushes.Black, x + 200, y);
            e.Graphics.DrawString("İŞLEMLER KODU", normalFont, Brushes.Black, x + 300, y);
            e.Graphics.DrawString("MİKTAR", normalFont, Brushes.Black, x + 420, y);
            e.Graphics.DrawString("BİRİM FİYATI", normalFont, Brushes.Black, x + 490, y);
            y += 25;
            
            // Çizgi
            e.Graphics.DrawLine(kalem, x, y, x + 600, y);
            y += 10;
            
            // İşlemler
            foreach (var islem in yapilanIslemler)
            {
                e.Graphics.DrawString(islem.Poliklinik ?? "", kucukFont, Brushes.Black, x, y);
                e.Graphics.DrawString("1", kucukFont, Brushes.Black, x + 120, y);
                e.Graphics.DrawString($"{aktifHasta.Ad} {aktifHasta.Soyad}", kucukFont, Brushes.Black, x + 200, y);
                e.Graphics.DrawString(islem.IslemAdi, kucukFont, Brushes.Black, x + 300, y);
                e.Graphics.DrawString(islem.Miktar.ToString(), kucukFont, Brushes.Black, x + 420, y);
                e.Graphics.DrawString(islem.BirimFiyat.ToString("N2"), kucukFont, Brushes.Black, x + 490, y);
                y += 20;
            }
            
            y += 20;
            
            // Toplam
            decimal toplam = yapilanIslemler.Sum(i => i.Toplam);
            e.Graphics.DrawString($"Toplam : {toplam:N2} ₺", normalFont, Brushes.Black, x + 400, y);
            y += 40;
            
            // Doktor ve Tarih
            e.Graphics.DrawString($"Doktor: {txtDrKodu.Text}", normalFont, Brushes.Black, x, y);
            y += 25;
            e.Graphics.DrawString($"Tarih: {dtpSiraTarih.Value:dd.MM.yyyy}", normalFont, Brushes.Black, x, y);
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
