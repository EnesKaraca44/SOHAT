namespace SunumKatmani
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblBaslik = new System.Windows.Forms.Label();
            lblKullaniciAd = new System.Windows.Forms.Label();
            lblSifre = new System.Windows.Forms.Label();
            txtKullaniciAd = new System.Windows.Forms.TextBox();
            txtSifre = new System.Windows.Forms.TextBox();
            btnGiris = new System.Windows.Forms.Button();
            btnTemizle = new System.Windows.Forms.Button();
            btnCikis = new System.Windows.Forms.Button();
            panelBaslik = new System.Windows.Forms.Panel();
            panelBaslik.SuspendLayout();
            SuspendLayout();
            // 
            // lblBaslik
            // 
            lblBaslik.AutoSize = true;
            lblBaslik.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblBaslik.ForeColor = System.Drawing.Color.White;
            lblBaslik.Location = new System.Drawing.Point(147, 18);
            lblBaslik.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new System.Drawing.Size(180, 32);
            lblBaslik.TabIndex = 0;
            lblBaslik.Text = "SOHAT - Login";
            // 
            // lblKullaniciAd
            // 
            lblKullaniciAd.AutoSize = true;
            lblKullaniciAd.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblKullaniciAd.Location = new System.Drawing.Point(67, 123);
            lblKullaniciAd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblKullaniciAd.Name = "lblKullaniciAd";
            lblKullaniciAd.Size = new System.Drawing.Size(103, 23);
            lblKullaniciAd.TabIndex = 1;
            lblKullaniciAd.Text = "Kullanıcı Adı";
            // 
            // lblSifre
            // 
            lblSifre.AutoSize = true;
            lblSifre.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblSifre.Location = new System.Drawing.Point(67, 185);
            lblSifre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblSifre.Name = "lblSifre";
            lblSifre.Size = new System.Drawing.Size(43, 23);
            lblSifre.TabIndex = 2;
            lblSifre.Text = "Şifre";
            // 
            // txtKullaniciAd
            // 
            txtKullaniciAd.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtKullaniciAd.Location = new System.Drawing.Point(200, 118);
            txtKullaniciAd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            txtKullaniciAd.MaxLength = 20;
            txtKullaniciAd.Name = "txtKullaniciAd";
            txtKullaniciAd.Size = new System.Drawing.Size(239, 30);
            txtKullaniciAd.TabIndex = 0;
            txtKullaniciAd.KeyPress += txtKullaniciAd_KeyPress;
            // 
            // txtSifre
            // 
            txtSifre.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtSifre.Location = new System.Drawing.Point(200, 180);
            txtSifre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            txtSifre.MaxLength = 20;
            txtSifre.Name = "txtSifre";
            txtSifre.PasswordChar = '●';
            txtSifre.Size = new System.Drawing.Size(239, 30);
            txtSifre.TabIndex = 1;
            txtSifre.KeyPress += txtSifre_KeyPress;
            // 
            // btnGiris
            // 
            btnGiris.BackColor = System.Drawing.Color.LimeGreen;
            btnGiris.Cursor = System.Windows.Forms.Cursors.Hand;
            btnGiris.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnGiris.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnGiris.ForeColor = System.Drawing.Color.White;
            btnGiris.Location = new System.Drawing.Point(67, 262);
            btnGiris.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            btnGiris.Name = "btnGiris";
            btnGiris.Size = new System.Drawing.Size(120, 54);
            btnGiris.TabIndex = 2;
            btnGiris.Text = "Giriş";
            btnGiris.UseVisualStyleBackColor = false;
            btnGiris.Click += btnGiris_Click;
            // 
            // btnTemizle
            // 
            btnTemizle.BackColor = System.Drawing.Color.Orange;
            btnTemizle.Cursor = System.Windows.Forms.Cursors.Hand;
            btnTemizle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnTemizle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnTemizle.ForeColor = System.Drawing.Color.White;
            btnTemizle.Location = new System.Drawing.Point(200, 262);
            btnTemizle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            btnTemizle.Name = "btnTemizle";
            btnTemizle.Size = new System.Drawing.Size(120, 54);
            btnTemizle.TabIndex = 3;
            btnTemizle.Text = "Temizle";
            btnTemizle.UseVisualStyleBackColor = false;
            btnTemizle.Click += btnTemizle_Click;
            // 
            // btnCikis
            // 
            btnCikis.BackColor = System.Drawing.Color.Crimson;
            btnCikis.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCikis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCikis.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnCikis.ForeColor = System.Drawing.Color.White;
            btnCikis.Location = new System.Drawing.Point(333, 262);
            btnCikis.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            btnCikis.Name = "btnCikis";
            btnCikis.Size = new System.Drawing.Size(120, 54);
            btnCikis.TabIndex = 4;
            btnCikis.Text = "Çıkış";
            btnCikis.UseVisualStyleBackColor = false;
            btnCikis.Click += btnCikis_Click;
            // 
            // panelBaslik
            // 
            panelBaslik.BackColor = System.Drawing.Color.SteelBlue;
            panelBaslik.Controls.Add(lblBaslik);
            panelBaslik.Dock = System.Windows.Forms.DockStyle.Top;
            panelBaslik.Location = new System.Drawing.Point(0, 0);
            panelBaslik.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            panelBaslik.Name = "panelBaslik";
            panelBaslik.Size = new System.Drawing.Size(969, 77);
            panelBaslik.TabIndex = 0;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.WhiteSmoke;
            ClientSize = new System.Drawing.Size(969, 493);
            Controls.Add(btnCikis);
            Controls.Add(btnTemizle);
            Controls.Add(btnGiris);
            Controls.Add(txtSifre);
            Controls.Add(txtKullaniciAd);
            Controls.Add(lblSifre);
            Controls.Add(lblKullaniciAd);
            Controls.Add(panelBaslik);
            Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            Name = "LoginForm";
            Text = "SOHAT - Giriş";
            panelBaslik.ResumeLayout(false);
            panelBaslik.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelBaslik;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Label lblKullaniciAd;
        private System.Windows.Forms.Label lblSifre;
        private System.Windows.Forms.TextBox txtKullaniciAd;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.Button btnGiris;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.Button btnCikis;
    }
}
