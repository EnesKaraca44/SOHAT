using System;
using System.Windows.Forms;
using VarlikKatmani;

namespace SunumKatmani
{
    public partial class TaburcuOdemeForm : Form
    {
        public Sevk AktifSevk { get; set; }
        public decimal ToplamTutar { get; set; }
        public string OdemeYapildi { get; private set; }

        public TaburcuOdemeForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void TaburcuOdemeForm_Load(object sender, EventArgs e)
        {
            // Ödeme şekilleri
            cmbOdemeSecili.Items.AddRange(new string[] 
            { 
                "Nakit", 
                "Kredi Kartı-tek ödeme", 
                "Kredi Kartı-taksit", 
                "Çek", 
                "Senet" 
            });
            cmbOdemeSecili.SelectedIndex = 0;

            // Form bilgilerini doldur
            if (AktifSevk != null)
            {
                txtDosyaNo.Text = AktifSevk.DosyaNo;
                dtpSevkTarihi.Value = AktifSevk.SevkTarihi;
                dtpCikisTarihi.Value = DateTime.Now;
                txtToplamTutar.Text = ToplamTutar.ToString("N2") + " ₺";
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (cmbOdemeSecili.SelectedItem == null)
            {
                MessageBox.Show("Lütfen ödeme şekli seçiniz!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OdemeYapildi = cmbOdemeSecili.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
