using System;
using System.Windows.Forms;
using VarlikKatmani;

namespace SunumKatmani
{
    public partial class AnaMenuForm : Form
    {
        private Kullanici aktifKullanici;

        public AnaMenuForm(Kullanici kullanici)
        {
            InitializeComponent();
            aktifKullanici = kullanici;
            this.WindowState = FormWindowState.Maximized;
            this.IsMdiContainer = true;
            
            // Kullanıcı bilgisini göster
            this.Text = $"Sağlık Ocağı Hasta Takip Sistemi - {aktifKullanici.TamAd} ({(aktifKullanici.Yetki ? "Yönetici" : "Personel")})";
        }

        // Referanslar Menüsü
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", 
                "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (sonuc == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void poliklinikTanimaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Poliklinik Tanıma formunu aç
            PoliklinikTanimaForm form = new PoliklinikTanimaForm();
            form.MdiParent = this;
            form.Show();
        }

        private void kullaniciTanimaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Sadece yönetici kullanıcı tanımlayabilir
            if (!aktifKullanici.Yetki)
            {
                MessageBox.Show("Bu işlem için yetkiniz bulunmamaktadır!", 
                    "Yetki Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // Kullanıcı Seçim formunu popup olarak aç
            KullaniciSecimForm form = new KullaniciSecimForm();
            form.ShowDialog();
        }

        private void cikisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = MessageBox.Show("Programdan çıkmak istediğinize emin misiniz?", 
                "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (sonuc == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // Hasta Kabul Menüsü
        private void hastaKabulToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Hasta Kabul formunu aç
            HastaKabulForm form = new HastaKabulForm();
            form.MdiParent = this;
            form.Show();
        }

        // Raporlar Menüsü
        private void raporlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Raporlar formu açılacak", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // TODO: Raporlar formu açılacak
        }

        private void AnaMenuForm_Load(object sender, EventArgs e)
        {
            // Hoş geldiniz mesajı
            MessageBox.Show($"Hoş geldiniz {aktifKullanici.TamAd}!", 
                "Giriş Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
