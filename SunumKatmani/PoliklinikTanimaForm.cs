using System;
using System.ComponentModel;
using System.Windows.Forms;
using VarlikKatmani;
using VeriErisimKatmani;

namespace SunumKatmani
{
    public partial class PoliklinikTanimaForm : Form
    {
        public PoliklinikTanimaForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void PoliklinikTanimaForm_Load(object sender, EventArgs e)
        {
            PoliklinikeleriYukle();
        }

        private void PoliklinikeleriYukle()
        {
            try
            {
                var poliklinikler = PoliklinikDAL.TumPoliklinikeleriGetir();
                cmbPoliklinikAdi.DataSource = poliklinikler;
                cmbPoliklinikAdi.DisplayMember = "PoliklinikAdi";
                cmbPoliklinikAdi.ValueMember = "PoliklinikAdi";
                
                if (poliklinikler.Count > 0)
                {
                    PoliklinikSecildi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Poliklinikler yüklenirken hata oluştu: " + ex.Message, 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbPoliklinikAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            PoliklinikSecildi();
        }

        private void PoliklinikSecildi()
        {
            if (cmbPoliklinikAdi.SelectedItem != null)
            {
                Poliklinik secili = (Poliklinik)cmbPoliklinikAdi.SelectedItem;
                chkDurum.Checked = secili.Durum;
                txtAciklama.Text = secili.Aciklama;
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                string yeniAd = cmbPoliklinikAdi.Text.Trim();

                if (string.IsNullOrWhiteSpace(yeniAd))
                {
                    MessageBox.Show("Poliklinik adı boş olamaz!", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Poliklinik poliklinik = new Poliklinik
                {
                    PoliklinikAdi = yeniAd,
                    Durum = chkDurum.Checked,
                    Aciklama = txtAciklama.Text.Trim()
                };

                if (PoliklinikDAL.PoliklinikEkle(poliklinik))
                {
                    MessageBox.Show("Yeni poliklinik başarıyla eklendi!", "Başarılı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PoliklinikeleriYukle();
                    cmbPoliklinikAdi.SelectedValue = poliklinik.PoliklinikAdi;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ekleme işlemi sırasında hata oluştu: " + ex.Message, 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbPoliklinikAdi.SelectedItem == null)
                {
                    MessageBox.Show("Lütfen güncellenecek poliklinik seçiniz!", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string eskiAd = ((Poliklinik)cmbPoliklinikAdi.SelectedItem).PoliklinikAdi;
                
                Poliklinik poliklinik = new Poliklinik
                {
                    PoliklinikAdi = cmbPoliklinikAdi.Text.Trim(),
                    Durum = chkDurum.Checked,
                    Aciklama = txtAciklama.Text.Trim()
                };

                if (string.IsNullOrWhiteSpace(poliklinik.PoliklinikAdi))
                {
                    MessageBox.Show("Poliklinik adı boş olamaz!", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (PoliklinikDAL.PoliklinikGuncelle(eskiAd, poliklinik))
                {
                    MessageBox.Show("Poliklinik başarıyla güncellendi!", "Başarılı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PoliklinikeleriYukle();
                    cmbPoliklinikAdi.SelectedValue = poliklinik.PoliklinikAdi;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme işlemi sırasında hata oluştu: " + ex.Message, 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbPoliklinikAdi.SelectedItem == null)
                {
                    MessageBox.Show("Lütfen silinecek poliklinik seçiniz!", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string poliklinikAdi = ((Poliklinik)cmbPoliklinikAdi.SelectedItem).PoliklinikAdi;

                DialogResult sonuc = MessageBox.Show(
                    $"'{poliklinikAdi}' poliklinik kaydını silmek istediğinize emin misiniz?", 
                    "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (sonuc == DialogResult.Yes)
                {
                    if (PoliklinikDAL.PoliklinikSil(poliklinikAdi))
                    {
                        MessageBox.Show("Poliklinik başarıyla silindi!", "Başarılı", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PoliklinikeleriYukle();
                        Temizle();
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

        private void Temizle()
        {
            cmbPoliklinikAdi.Text = "";
            chkDurum.Checked = true;
            txtAciklama.Clear();
        }
    }
}
