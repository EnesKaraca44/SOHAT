using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using VarlikKatmani;
using VeriErisimKatmani;

namespace SunumKatmani
{
    public partial class LoginForm : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Kullanici GirisYapanKullanici { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            try
            {
                // Boş alan kontrolü
                if (string.IsNullOrWhiteSpace(txtKullaniciAd.Text))
                {
                    MessageBox.Show("Lütfen kullanıcı adını giriniz!", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtKullaniciAd.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtSifre.Text))
                {
                    MessageBox.Show("Lütfen şifrenizi giriniz!", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSifre.Focus();
                    return;
                }

                // Giriş kontrolü (bağlantı hatası varsa zaten KullaniciDAL'da yakalanacak)
                GirisYapanKullanici = KullaniciDAL.GirisYap(txtKullaniciAd.Text.Trim(), txtSifre.Text);

                if (GirisYapanKullanici != null)
                {
                    MessageBox.Show($"Hoş geldiniz {GirisYapanKullanici.TamAd}!", "Giriş Başarılı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Giriş Başarısız", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSifre.Clear();
                    txtKullaniciAd.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Giriş sırasında hata oluştu:\n" + ex.Message, "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtKullaniciAd.Clear();
            txtSifre.Clear();
            txtKullaniciAd.Focus();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = MessageBox.Show("Programdan çıkmak istediğinize emin misiniz?", 
                "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (sonuc == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txtSifre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Enter tuşuna basıldığında giriş yap
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnGiris_Click(sender, e);
                e.Handled = true;
            }
        }

        private void txtKullaniciAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Enter tuşuna basıldığında şifre alanına geç
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtSifre.Focus();
                e.Handled = true;
            }
        }
    }
}
