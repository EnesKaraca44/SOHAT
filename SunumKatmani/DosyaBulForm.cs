using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VarlikKatmani;
using VeriErisimKatmani;
using System.Linq;

namespace SunumKatmani
{
    public partial class DosyaBulForm : Form
    {
        public Hasta SecilenHasta { get; private set; }

        public DosyaBulForm()
        {
            InitializeComponent();
        }

        private void DosyaBulForm_Load(object sender, EventArgs e)
        {
            // Arama kriterleri
            cmbAramaKriteri.Items.AddRange(new string[] 
            { 
                "Hasta Adı Soyadı", 
                "Kimlik No", 
                "Kurum Sicil No", 
                "Dosya No" 
            });
            cmbAramaKriteri.SelectedIndex = 0;
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAramaDegeri.Text))
            {
                MessageBox.Show("Lütfen arama değeri giriniz!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                List<Hasta> hastalar = new List<Hasta>();
                string aramaDegeri = txtAramaDegeri.Text.Trim();

                switch (cmbAramaKriteri.SelectedIndex)
                {
                    case 0: // Hasta Adı Soyadı
                        hastalar = HastaDAL.HastaAra(aramaDegeri);
                        break;
                    case 1: // Kimlik No
                        var hastaTC = HastaDAL.TcIleAra(aramaDegeri);
                        if (hastaTC != null)
                            hastalar.Add(hastaTC);
                        break;
                    case 2: // Kurum Sicil No
                        var tumHastalar = HastaDAL.TumHastalariGetir();
                        hastalar = tumHastalar.Where(h => 
                            h.KurumSicilNo != null && 
                            h.KurumSicilNo.Contains(aramaDegeri)).ToList();
                        break;
                    case 3: // Dosya No
                        var hastaDosya = HastaDAL.DosyaNoIleGetir(aramaDegeri);
                        if (hastaDosya != null)
                            hastalar.Add(hastaDosya);
                        break;
                }

                if (hastalar.Count > 0)
                {
                    dgvHastalar.DataSource = hastalar;
                    DuzenleDGV();
                }
                else
                {
                    MessageBox.Show("Hasta bulunamadı!", "Bilgi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvHastalar.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DuzenleDGV()
        {
            if (dgvHastalar.Columns.Count > 0)
            {
                dgvHastalar.Columns["TcKimlikNo"].HeaderText = "TC Kimlik No";
                dgvHastalar.Columns["DosyaNo"].HeaderText = "Dosya No";
                dgvHastalar.Columns["Ad"].HeaderText = "Ad";
                dgvHastalar.Columns["Soyad"].HeaderText = "Soyad";
                dgvHastalar.Columns["DogumYeri"].HeaderText = "Doğum Yeri";

                // Gereksiz kolonları gizle
                if (dgvHastalar.Columns.Contains("BabaAdi"))
                    dgvHastalar.Columns["BabaAdi"].Visible = false;
                if (dgvHastalar.Columns.Contains("AnneAdi"))
                    dgvHastalar.Columns["AnneAdi"].Visible = false;
                if (dgvHastalar.Columns.Contains("Adres"))
                    dgvHastalar.Columns["Adres"].Visible = false;
                if (dgvHastalar.Columns.Contains("Tel"))
                    dgvHastalar.Columns["Tel"].Visible = false;
                if (dgvHastalar.Columns.Contains("KurumSicilNo"))
                    dgvHastalar.Columns["KurumSicilNo"].Visible = false;
                if (dgvHastalar.Columns.Contains("KurumAdi"))
                    dgvHastalar.Columns["KurumAdi"].Visible = false;
                if (dgvHastalar.Columns.Contains("YakinTel"))
                    dgvHastalar.Columns["YakinTel"].Visible = false;
                if (dgvHastalar.Columns.Contains("YakinKurumSicilNo"))
                    dgvHastalar.Columns["YakinKurumSicilNo"].Visible = false;
                if (dgvHastalar.Columns.Contains("YakinKurumAdi"))
                    dgvHastalar.Columns["YakinKurumAdi"].Visible = false;
                if (dgvHastalar.Columns.Contains("TamAd"))
                    dgvHastalar.Columns["TamAd"].Visible = false;
                if (dgvHastalar.Columns.Contains("Yas"))
                    dgvHastalar.Columns["Yas"].Visible = false;
            }
        }

        private void dgvHastalar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SecilenHasta = (Hasta)dgvHastalar.Rows[e.RowIndex].DataBoundItem;
                this.DialogResult = DialogResult.OK; //OK ise kullanıcı hasta seçti demek, Cancel ise iptal etti demek."
                this.Close();
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
