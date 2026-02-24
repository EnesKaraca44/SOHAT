namespace SunumKatmani
{
    partial class KullaniciSecimForm
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
            this.panelBaslik = new System.Windows.Forms.Panel();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.lblKullaniciKodu = new System.Windows.Forms.Label();
            this.cmbKullaniciKodu = new System.Windows.Forms.ComboBox();
            this.btnYeniKullaniciEkle = new System.Windows.Forms.Button();
            this.btnDuzenle = new System.Windows.Forms.Button();
            this.panelBaslik.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBaslik
            // 
            this.panelBaslik.BackColor = System.Drawing.Color.SteelBlue;
            this.panelBaslik.Controls.Add(this.lblBaslik);
            this.panelBaslik.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBaslik.Location = new System.Drawing.Point(0, 0);
            this.panelBaslik.Name = "panelBaslik";
            this.panelBaslik.Size = new System.Drawing.Size(350, 40);
            this.panelBaslik.TabIndex = 0;
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.ForeColor = System.Drawing.Color.White;
            this.lblBaslik.Location = new System.Drawing.Point(70, 8);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(210, 21);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "SOHATS - Kullanıcı Tanıma";
            // 
            // lblKullaniciKodu
            // 
            this.lblKullaniciKodu.AutoSize = true;
            this.lblKullaniciKodu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblKullaniciKodu.Location = new System.Drawing.Point(20, 60);
            this.lblKullaniciKodu.Name = "lblKullaniciKodu";
            this.lblKullaniciKodu.Size = new System.Drawing.Size(100, 19);
            this.lblKullaniciKodu.TabIndex = 1;
            this.lblKullaniciKodu.Text = "Kullanıcı Kodu";
            // 
            // cmbKullaniciKodu
            // 
            this.cmbKullaniciKodu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKullaniciKodu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbKullaniciKodu.FormattingEnabled = true;
            this.cmbKullaniciKodu.Location = new System.Drawing.Point(20, 85);
            this.cmbKullaniciKodu.Name = "cmbKullaniciKodu";
            this.cmbKullaniciKodu.Size = new System.Drawing.Size(310, 25);
            this.cmbKullaniciKodu.TabIndex = 0;
            this.cmbKullaniciKodu.SelectedIndexChanged += new System.EventHandler(this.cmbKullaniciKodu_SelectedIndexChanged);
            this.cmbKullaniciKodu.DoubleClick += new System.EventHandler(this.cmbKullaniciKodu_DoubleClick);
            // 
            // btnYeniKullaniciEkle
            // 
            this.btnYeniKullaniciEkle.BackColor = System.Drawing.Color.LimeGreen;
            this.btnYeniKullaniciEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYeniKullaniciEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYeniKullaniciEkle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnYeniKullaniciEkle.ForeColor = System.Drawing.Color.White;
            this.btnYeniKullaniciEkle.Location = new System.Drawing.Point(20, 125);
            this.btnYeniKullaniciEkle.Name = "btnYeniKullaniciEkle";
            this.btnYeniKullaniciEkle.Size = new System.Drawing.Size(150, 35);
            this.btnYeniKullaniciEkle.TabIndex = 1;
            this.btnYeniKullaniciEkle.Text = "Yeni Kullanıcı Ekle";
            this.btnYeniKullaniciEkle.UseVisualStyleBackColor = false;
            this.btnYeniKullaniciEkle.Click += new System.EventHandler(this.btnYeniKullaniciEkle_Click);
            // 
            // btnDuzenle
            // 
            this.btnDuzenle.BackColor = System.Drawing.Color.Orange;
            this.btnDuzenle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDuzenle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDuzenle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDuzenle.ForeColor = System.Drawing.Color.White;
            this.btnDuzenle.Location = new System.Drawing.Point(180, 125);
            this.btnDuzenle.Name = "btnDuzenle";
            this.btnDuzenle.Size = new System.Drawing.Size(150, 35);
            this.btnDuzenle.TabIndex = 2;
            this.btnDuzenle.Text = "Düzenle";
            this.btnDuzenle.UseVisualStyleBackColor = false;
            this.btnDuzenle.Click += new System.EventHandler(this.btnDuzenle_Click);
            // 
            // KullaniciSecimForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(350, 180);
            this.Controls.Add(this.btnDuzenle);
            this.Controls.Add(this.btnYeniKullaniciEkle);
            this.Controls.Add(this.cmbKullaniciKodu);
            this.Controls.Add(this.lblKullaniciKodu);
            this.Controls.Add(this.panelBaslik);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KullaniciSecimForm";
            this.Text = "Kullanıcı Tanıma";
            this.Load += new System.EventHandler(this.KullaniciSecimForm_Load);
            this.panelBaslik.ResumeLayout(false);
            this.panelBaslik.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelBaslik;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Label lblKullaniciKodu;
        private System.Windows.Forms.ComboBox cmbKullaniciKodu;
        private System.Windows.Forms.Button btnYeniKullaniciEkle;
        private System.Windows.Forms.Button btnDuzenle;
    }
}
