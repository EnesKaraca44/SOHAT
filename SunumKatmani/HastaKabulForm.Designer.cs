namespace SunumKatmani
{
    partial class HastaKabulForm
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
            this.groupBoxHastaIslemleri = new System.Windows.Forms.GroupBox();
            this.lblDosyaNo = new System.Windows.Forms.Label();
            this.txtDosyaNo = new System.Windows.Forms.TextBox();
            this.btnBul = new System.Windows.Forms.Button();
            this.lblHastaAdi = new System.Windows.Forms.Label();
            this.txtHastaAdi = new System.Windows.Forms.TextBox();
            this.lblSiraTarih = new System.Windows.Forms.Label();
            this.dtpSiraTarih = new System.Windows.Forms.DateTimePicker();
            this.lblSoyad = new System.Windows.Forms.Label();
            this.txtSoyad = new System.Windows.Forms.TextBox();
            this.lblOncelikliHasta = new System.Windows.Forms.Label();
            this.cmbOncelikliHasta = new System.Windows.Forms.ComboBox();
            this.btnGit = new System.Windows.Forms.Button();
            this.lblDogumAdi = new System.Windows.Forms.Label();
            this.txtDogumAdi = new System.Windows.Forms.TextBox();
            this.lblPoliklinik = new System.Windows.Forms.Label();
            this.cmbPoliklinik = new System.Windows.Forms.ComboBox();
            this.lblYapilanIslem = new System.Windows.Forms.Label();
            this.cmbYapilanIslem = new System.Windows.Forms.ComboBox();
            this.lblDrKodu = new System.Windows.Forms.Label();
            this.txtDrKodu = new System.Windows.Forms.TextBox();
            this.lblMiktar = new System.Windows.Forms.Label();
            this.txtMiktar = new System.Windows.Forms.TextBox();
            this.lblBirimFiyat = new System.Windows.Forms.Label();
            this.txtBirimFiyat = new System.Windows.Forms.TextBox();
            this.btnEkle = new System.Windows.Forms.Button();
            this.dgvIslemler = new System.Windows.Forms.DataGridView();
            this.lblToplamTutar = new System.Windows.Forms.Label();
            this.btnYeni = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnTaburcu = new System.Windows.Forms.Button();
            this.btnYazdir = new System.Windows.Forms.Button();
            this.btnBaskaOnizleme = new System.Windows.Forms.Button();
            this.btnCikis = new System.Windows.Forms.Button();
            this.groupBoxHastaIslemleri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIslemler)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxHastaIslemleri
            // 
            this.groupBoxHastaIslemleri.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBoxHastaIslemleri.Controls.Add(this.lblDosyaNo);
            this.groupBoxHastaIslemleri.Controls.Add(this.txtDosyaNo);
            this.groupBoxHastaIslemleri.Controls.Add(this.btnBul);
            this.groupBoxHastaIslemleri.Controls.Add(this.lblHastaAdi);
            this.groupBoxHastaIslemleri.Controls.Add(this.txtHastaAdi);
            this.groupBoxHastaIslemleri.Controls.Add(this.lblSiraTarih);
            this.groupBoxHastaIslemleri.Controls.Add(this.dtpSiraTarih);
            this.groupBoxHastaIslemleri.Controls.Add(this.lblSoyad);
            this.groupBoxHastaIslemleri.Controls.Add(this.txtSoyad);
            this.groupBoxHastaIslemleri.Controls.Add(this.lblOncelikliHasta);
            this.groupBoxHastaIslemleri.Controls.Add(this.cmbOncelikliHasta);
            this.groupBoxHastaIslemleri.Controls.Add(this.btnGit);
            this.groupBoxHastaIslemleri.Controls.Add(this.lblDogumAdi);
            this.groupBoxHastaIslemleri.Controls.Add(this.txtDogumAdi);
            this.groupBoxHastaIslemleri.Controls.Add(this.lblPoliklinik);
            this.groupBoxHastaIslemleri.Controls.Add(this.cmbPoliklinik);
            this.groupBoxHastaIslemleri.Controls.Add(this.lblYapilanIslem);
            this.groupBoxHastaIslemleri.Controls.Add(this.cmbYapilanIslem);
            this.groupBoxHastaIslemleri.Controls.Add(this.lblDrKodu);
            this.groupBoxHastaIslemleri.Controls.Add(this.txtDrKodu);
            this.groupBoxHastaIslemleri.Controls.Add(this.lblMiktar);
            this.groupBoxHastaIslemleri.Controls.Add(this.txtMiktar);
            this.groupBoxHastaIslemleri.Controls.Add(this.lblBirimFiyat);
            this.groupBoxHastaIslemleri.Controls.Add(this.txtBirimFiyat);
            this.groupBoxHastaIslemleri.Controls.Add(this.btnEkle);
            this.groupBoxHastaIslemleri.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBoxHastaIslemleri.Location = new System.Drawing.Point(12, 12);
            this.groupBoxHastaIslemleri.Name = "groupBoxHastaIslemleri";
            this.groupBoxHastaIslemleri.Size = new System.Drawing.Size(760, 180);
            this.groupBoxHastaIslemleri.TabIndex = 0;
            this.groupBoxHastaIslemleri.TabStop = false;
            this.groupBoxHastaIslemleri.Text = "Hasta İşlemleri";
            // 
            // Satır 1 - Sol
            // 
            this.lblDosyaNo.AutoSize = true;
            this.lblDosyaNo.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblDosyaNo.Location = new System.Drawing.Point(10, 25);
            this.lblDosyaNo.Name = "lblDosyaNo";
            this.lblDosyaNo.Size = new System.Drawing.Size(55, 13);
            this.lblDosyaNo.TabIndex = 0;
            this.lblDosyaNo.Text = "Dosya No";
            // 
            this.txtDosyaNo.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.txtDosyaNo.Location = new System.Drawing.Point(70, 22);
            this.txtDosyaNo.Name = "txtDosyaNo";
            this.txtDosyaNo.Size = new System.Drawing.Size(80, 22);
            this.txtDosyaNo.TabIndex = 0;
            this.txtDosyaNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDosyaNo_KeyPress);
            // 
            this.btnBul.BackColor = System.Drawing.Color.LightBlue;
            this.btnBul.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnBul.Location = new System.Drawing.Point(155, 21);
            this.btnBul.Name = "btnBul";
            this.btnBul.Size = new System.Drawing.Size(50, 23);
            this.btnBul.TabIndex = 1;
            this.btnBul.Text = "Bul";
            this.btnBul.UseVisualStyleBackColor = false;
            this.btnBul.Click += new System.EventHandler(this.btnBul_Click);
            // 
            // Satır 1 - Sağ
            // 
            this.lblHastaAdi.AutoSize = true;
            this.lblHastaAdi.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblHastaAdi.Location = new System.Drawing.Point(220, 25);
            this.lblHastaAdi.Name = "lblHastaAdi";
            this.lblHastaAdi.Size = new System.Drawing.Size(55, 13);
            this.lblHastaAdi.TabIndex = 2;
            this.lblHastaAdi.Text = "Hasta Adı";
            // 
            this.txtHastaAdi.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.txtHastaAdi.Location = new System.Drawing.Point(280, 22);
            this.txtHastaAdi.Name = "txtHastaAdi";
            this.txtHastaAdi.Size = new System.Drawing.Size(150, 22);
            this.txtHastaAdi.TabIndex = 2;
            // 
            // Satır 2 - Sol
            // 
            this.lblSiraTarih.AutoSize = true;
            this.lblSiraTarih.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblSiraTarih.Location = new System.Drawing.Point(10, 55);
            this.lblSiraTarih.Name = "lblSiraTarih";
            this.lblSiraTarih.Size = new System.Drawing.Size(55, 13);
            this.lblSiraTarih.TabIndex = 3;
            this.lblSiraTarih.Text = "Sıra/Tarih";
            // 
            this.dtpSiraTarih.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.dtpSiraTarih.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSiraTarih.Location = new System.Drawing.Point(70, 52);
            this.dtpSiraTarih.Name = "dtpSiraTarih";
            this.dtpSiraTarih.Size = new System.Drawing.Size(135, 22);
            this.dtpSiraTarih.TabIndex = 3;
            // 
            // Satır 2 - Sağ
            // 
            this.lblSoyad.AutoSize = true;
            this.lblSoyad.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblSoyad.Location = new System.Drawing.Point(220, 55);
            this.lblSoyad.Name = "lblSoyad";
            this.lblSoyad.Size = new System.Drawing.Size(40, 13);
            this.lblSoyad.TabIndex = 4;
            this.lblSoyad.Text = "Soyad";
            // 
            this.txtSoyad.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.txtSoyad.Location = new System.Drawing.Point(280, 52);
            this.txtSoyad.Name = "txtSoyad";
            this.txtSoyad.Size = new System.Drawing.Size(150, 22);
            this.txtSoyad.TabIndex = 4;
            // 
            // Satır 3 - Sol
            // 
            this.lblOncelikliHasta.AutoSize = true;
            this.lblOncelikliHasta.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblOncelikliHasta.Location = new System.Drawing.Point(10, 85);
            this.lblOncelikliHasta.Name = "lblOncelikliHasta";
            this.lblOncelikliHasta.Size = new System.Drawing.Size(55, 13);
            this.lblOncelikliHasta.TabIndex = 5;
            this.lblOncelikliHasta.Text = "Öncelikli";
            // 
            this.cmbOncelikliHasta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOncelikliHasta.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cmbOncelikliHasta.FormattingEnabled = true;
            this.cmbOncelikliHasta.Location = new System.Drawing.Point(70, 82);
            this.cmbOncelikliHasta.Name = "cmbOncelikliHasta";
            this.cmbOncelikliHasta.Size = new System.Drawing.Size(100, 21);
            this.cmbOncelikliHasta.TabIndex = 5;
            // 
            this.btnGit.BackColor = System.Drawing.Color.LightGreen;
            this.btnGit.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnGit.Location = new System.Drawing.Point(175, 81);
            this.btnGit.Name = "btnGit";
            this.btnGit.Size = new System.Drawing.Size(30, 23);
            this.btnGit.TabIndex = 6;
            this.btnGit.Text = "Git";
            this.btnGit.UseVisualStyleBackColor = false;
            this.btnGit.Click += new System.EventHandler(this.btnGit_Click);
            // 
            // Satır 3 - Sağ
            // 
            this.lblDogumAdi.AutoSize = true;
            this.lblDogumAdi.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblDogumAdi.Location = new System.Drawing.Point(220, 85);
            this.lblDogumAdi.Name = "lblDogumAdi";
            this.lblDogumAdi.Size = new System.Drawing.Size(60, 13);
            this.lblDogumAdi.TabIndex = 7;
            this.lblDogumAdi.Text = "Doğum Adı";
            // 
            this.txtDogumAdi.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.txtDogumAdi.Location = new System.Drawing.Point(280, 82);
            this.txtDogumAdi.Name = "txtDogumAdi";
            this.txtDogumAdi.Size = new System.Drawing.Size(150, 22);
            this.txtDogumAdi.TabIndex = 7;
            // 
            // Satır 4 - Alt kısım
            // 
            this.lblPoliklinik.AutoSize = true;
            this.lblPoliklinik.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblPoliklinik.Location = new System.Drawing.Point(10, 115);
            this.lblPoliklinik.Name = "lblPoliklinik";
            this.lblPoliklinik.Size = new System.Drawing.Size(55, 13);
            this.lblPoliklinik.TabIndex = 8;
            this.lblPoliklinik.Text = "Poliklinik";
            // 
            this.cmbPoliklinik.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPoliklinik.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cmbPoliklinik.FormattingEnabled = true;
            this.cmbPoliklinik.Location = new System.Drawing.Point(10, 132);
            this.cmbPoliklinik.Name = "cmbPoliklinik";
            this.cmbPoliklinik.Size = new System.Drawing.Size(100, 21);
            this.cmbPoliklinik.TabIndex = 8;
            // 
            this.lblYapilanIslem.AutoSize = true;
            this.lblYapilanIslem.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblYapilanIslem.Location = new System.Drawing.Point(220, 115);
            this.lblYapilanIslem.Name = "lblYapilanIslem";
            this.lblYapilanIslem.Size = new System.Drawing.Size(70, 13);
            this.lblYapilanIslem.TabIndex = 9;
            this.lblYapilanIslem.Text = "Yapılan İşlem";
            // 
            this.cmbYapilanIslem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYapilanIslem.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cmbYapilanIslem.FormattingEnabled = true;
            this.cmbYapilanIslem.Location = new System.Drawing.Point(220, 132);
            this.cmbYapilanIslem.Name = "cmbYapilanIslem";
            this.cmbYapilanIslem.Size = new System.Drawing.Size(150, 21);
            this.cmbYapilanIslem.TabIndex = 9;
            // 
            this.lblDrKodu.AutoSize = true;
            this.lblDrKodu.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblDrKodu.Location = new System.Drawing.Point(380, 115);
            this.lblDrKodu.Name = "lblDrKodu";
            this.lblDrKodu.Size = new System.Drawing.Size(50, 13);
            this.lblDrKodu.TabIndex = 10;
            this.lblDrKodu.Text = "Dr. Kodu";
            // 
            this.txtDrKodu.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.txtDrKodu.Location = new System.Drawing.Point(380, 132);
            this.txtDrKodu.Name = "txtDrKodu";
            this.txtDrKodu.Size = new System.Drawing.Size(50, 22);
            this.txtDrKodu.TabIndex = 10;
            this.txtDrKodu.Text = "1";
            // 
            this.lblMiktar.AutoSize = true;
            this.lblMiktar.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblMiktar.Location = new System.Drawing.Point(440, 115);
            this.lblMiktar.Name = "lblMiktar";
            this.lblMiktar.Size = new System.Drawing.Size(40, 13);
            this.lblMiktar.TabIndex = 11;
            this.lblMiktar.Text = "Miktar";
            // 
            this.txtMiktar.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.txtMiktar.Location = new System.Drawing.Point(440, 132);
            this.txtMiktar.Name = "txtMiktar";
            this.txtMiktar.Size = new System.Drawing.Size(50, 22);
            this.txtMiktar.TabIndex = 11;
            this.txtMiktar.Text = "1";
            // 
            this.lblBirimFiyat.AutoSize = true;
            this.lblBirimFiyat.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblBirimFiyat.Location = new System.Drawing.Point(500, 115);
            this.lblBirimFiyat.Name = "lblBirimFiyat";
            this.lblBirimFiyat.Size = new System.Drawing.Size(60, 13);
            this.lblBirimFiyat.TabIndex = 12;
            this.lblBirimFiyat.Text = "Birim Fiyat";
            // 
            this.txtBirimFiyat.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.txtBirimFiyat.Location = new System.Drawing.Point(500, 132);
            this.txtBirimFiyat.Name = "txtBirimFiyat";
            this.txtBirimFiyat.Size = new System.Drawing.Size(80, 22);
            this.txtBirimFiyat.TabIndex = 12;
            // 
            this.btnEkle.BackColor = System.Drawing.Color.LightGreen;
            this.btnEkle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEkle.Location = new System.Drawing.Point(590, 128);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(80, 28);
            this.btnEkle.TabIndex = 13;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = false;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // DataGridView
            // 
            this.dgvIslemler.AllowUserToAddRows = false;
            this.dgvIslemler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIslemler.Location = new System.Drawing.Point(12, 200);
            this.dgvIslemler.Name = "dgvIslemler";
            this.dgvIslemler.ReadOnly = true;
            this.dgvIslemler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIslemler.Size = new System.Drawing.Size(760, 220);
            this.dgvIslemler.TabIndex = 1;
            // 
            // Toplam Tutar
            // 
            this.lblToplamTutar.AutoSize = true;
            this.lblToplamTutar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblToplamTutar.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblToplamTutar.Location = new System.Drawing.Point(580, 430);
            this.lblToplamTutar.Name = "lblToplamTutar";
            this.lblToplamTutar.Size = new System.Drawing.Size(150, 19);
            this.lblToplamTutar.TabIndex = 2;
            this.lblToplamTutar.Text = "Toplam Tutar: 0,00 ₺";
            // 
            // Butonlar
            // 
            this.btnYeni.BackColor = System.Drawing.Color.LightBlue;
            this.btnYeni.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnYeni.Location = new System.Drawing.Point(80, 460);
            this.btnYeni.Name = "btnYeni";
            this.btnYeni.Size = new System.Drawing.Size(80, 35);
            this.btnYeni.TabIndex = 3;
            this.btnYeni.Text = "Yeni";
            this.btnYeni.UseVisualStyleBackColor = false;
            this.btnYeni.Click += new System.EventHandler(this.btnYeni_Click);
            // 
            this.btnSil.BackColor = System.Drawing.Color.LightCoral;
            this.btnSil.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSil.Location = new System.Drawing.Point(170, 460);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(80, 35);
            this.btnSil.TabIndex = 4;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            this.btnTaburcu.BackColor = System.Drawing.Color.LightGreen;
            this.btnTaburcu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTaburcu.Location = new System.Drawing.Point(260, 460);
            this.btnTaburcu.Name = "btnTaburcu";
            this.btnTaburcu.Size = new System.Drawing.Size(80, 35);
            this.btnTaburcu.TabIndex = 5;
            this.btnTaburcu.Text = "Taburcu";
            this.btnTaburcu.UseVisualStyleBackColor = false;
            this.btnTaburcu.Click += new System.EventHandler(this.btnTaburcu_Click);
            // 
            this.btnYazdir.BackColor = System.Drawing.Color.LightYellow;
            this.btnYazdir.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnYazdir.Location = new System.Drawing.Point(350, 460);
            this.btnYazdir.Name = "btnYazdir";
            this.btnYazdir.Size = new System.Drawing.Size(80, 35);
            this.btnYazdir.TabIndex = 6;
            this.btnYazdir.Text = "Yazdır";
            this.btnYazdir.UseVisualStyleBackColor = false;
            this.btnYazdir.Click += new System.EventHandler(this.btnYazdir_Click);
            // 
            this.btnBaskaOnizleme.BackColor = System.Drawing.Color.LightGray;
            this.btnBaskaOnizleme.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnBaskaOnizleme.Location = new System.Drawing.Point(440, 460);
            this.btnBaskaOnizleme.Name = "btnBaskaOnizleme";
            this.btnBaskaOnizleme.Size = new System.Drawing.Size(100, 35);
            this.btnBaskaOnizleme.TabIndex = 7;
            this.btnBaskaOnizleme.Text = "Başka Önizleme";
            this.btnBaskaOnizleme.UseVisualStyleBackColor = false;
            this.btnBaskaOnizleme.Click += new System.EventHandler(this.btnBaskaOnizleme_Click);
            // 
            this.btnCikis.BackColor = System.Drawing.Color.Gray;
            this.btnCikis.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCikis.ForeColor = System.Drawing.Color.White;
            this.btnCikis.Location = new System.Drawing.Point(620, 460);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(80, 35);
            this.btnCikis.TabIndex = 8;
            this.btnCikis.Text = "Çıkış";
            this.btnCikis.UseVisualStyleBackColor = false;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // HastaKabulForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(784, 511);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnBaskaOnizleme);
            this.Controls.Add(this.btnYazdir);
            this.Controls.Add(this.btnTaburcu);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnYeni);
            this.Controls.Add(this.lblToplamTutar);
            this.Controls.Add(this.dgvIslemler);
            this.Controls.Add(this.groupBoxHastaIslemleri);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "HastaKabulForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hasta Kabul";
            this.Load += new System.EventHandler(this.HastaKabulForm_Load);
            this.groupBoxHastaIslemleri.ResumeLayout(false);
            this.groupBoxHastaIslemleri.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIslemler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxHastaIslemleri;
        private System.Windows.Forms.Label lblDosyaNo;
        private System.Windows.Forms.TextBox txtDosyaNo;
        private System.Windows.Forms.Button btnBul;
        private System.Windows.Forms.Label lblHastaAdi;
        private System.Windows.Forms.TextBox txtHastaAdi;
        private System.Windows.Forms.Label lblSiraTarih;
        private System.Windows.Forms.DateTimePicker dtpSiraTarih;
        private System.Windows.Forms.Label lblSoyad;
        private System.Windows.Forms.TextBox txtSoyad;
        private System.Windows.Forms.Label lblOncelikliHasta;
        private System.Windows.Forms.ComboBox cmbOncelikliHasta;
        private System.Windows.Forms.Button btnGit;
        private System.Windows.Forms.Label lblDogumAdi;
        private System.Windows.Forms.TextBox txtDogumAdi;
        private System.Windows.Forms.Label lblPoliklinik;
        private System.Windows.Forms.ComboBox cmbPoliklinik;
        private System.Windows.Forms.Label lblYapilanIslem;
        private System.Windows.Forms.ComboBox cmbYapilanIslem;
        private System.Windows.Forms.Label lblDrKodu;
        private System.Windows.Forms.TextBox txtDrKodu;
        private System.Windows.Forms.Label lblMiktar;
        private System.Windows.Forms.TextBox txtMiktar;
        private System.Windows.Forms.Label lblBirimFiyat;
        private System.Windows.Forms.TextBox txtBirimFiyat;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.DataGridView dgvIslemler;
        private System.Windows.Forms.Label lblToplamTutar;
        private System.Windows.Forms.Button btnYeni;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnTaburcu;
        private System.Windows.Forms.Button btnYazdir;
        private System.Windows.Forms.Button btnBaskaOnizleme;
        private System.Windows.Forms.Button btnCikis;
    }
}
