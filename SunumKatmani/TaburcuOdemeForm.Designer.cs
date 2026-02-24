namespace SunumKatmani
{
    partial class TaburcuOdemeForm
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
            this.lblDosyaNo = new System.Windows.Forms.Label();
            this.txtDosyaNo = new System.Windows.Forms.TextBox();
            this.lblSevkTarihi = new System.Windows.Forms.Label();
            this.dtpSevkTarihi = new System.Windows.Forms.DateTimePicker();
            this.lblCikisTarihi = new System.Windows.Forms.Label();
            this.dtpCikisTarihi = new System.Windows.Forms.DateTimePicker();
            this.lblOdemeSecili = new System.Windows.Forms.Label();
            this.cmbOdemeSecili = new System.Windows.Forms.ComboBox();
            this.lblToplamTutar = new System.Windows.Forms.Label();
            this.txtToplamTutar = new System.Windows.Forms.TextBox();
            this.btnVazgec = new System.Windows.Forms.Button();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDosyaNo
            // 
            this.lblDosyaNo.AutoSize = true;
            this.lblDosyaNo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDosyaNo.Location = new System.Drawing.Point(20, 20);
            this.lblDosyaNo.Name = "lblDosyaNo";
            this.lblDosyaNo.Size = new System.Drawing.Size(60, 15);
            this.lblDosyaNo.TabIndex = 0;
            this.lblDosyaNo.Text = "Dosya No:";
            // 
            // txtDosyaNo
            // 
            this.txtDosyaNo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDosyaNo.Location = new System.Drawing.Point(120, 17);
            this.txtDosyaNo.Name = "txtDosyaNo";
            this.txtDosyaNo.ReadOnly = true;
            this.txtDosyaNo.Size = new System.Drawing.Size(200, 23);
            this.txtDosyaNo.TabIndex = 0;
            // 
            // lblSevkTarihi
            // 
            this.lblSevkTarihi.AutoSize = true;
            this.lblSevkTarihi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSevkTarihi.Location = new System.Drawing.Point(20, 50);
            this.lblSevkTarihi.Name = "lblSevkTarihi";
            this.lblSevkTarihi.Size = new System.Drawing.Size(70, 15);
            this.lblSevkTarihi.TabIndex = 1;
            this.lblSevkTarihi.Text = "Sevk Tarihi:";
            // 
            // dtpSevkTarihi
            // 
            this.dtpSevkTarihi.Enabled = false;
            this.dtpSevkTarihi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpSevkTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSevkTarihi.Location = new System.Drawing.Point(120, 47);
            this.dtpSevkTarihi.Name = "dtpSevkTarihi";
            this.dtpSevkTarihi.Size = new System.Drawing.Size(200, 23);
            this.dtpSevkTarihi.TabIndex = 1;
            // 
            // lblCikisTarihi
            // 
            this.lblCikisTarihi.AutoSize = true;
            this.lblCikisTarihi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCikisTarihi.Location = new System.Drawing.Point(20, 80);
            this.lblCikisTarihi.Name = "lblCikisTarihi";
            this.lblCikisTarihi.Size = new System.Drawing.Size(70, 15);
            this.lblCikisTarihi.TabIndex = 2;
            this.lblCikisTarihi.Text = "Çıkış Tarihi:";
            // 
            // dtpCikisTarihi
            // 
            this.dtpCikisTarihi.Enabled = false;
            this.dtpCikisTarihi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpCikisTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCikisTarihi.Location = new System.Drawing.Point(120, 77);
            this.dtpCikisTarihi.Name = "dtpCikisTarihi";
            this.dtpCikisTarihi.Size = new System.Drawing.Size(200, 23);
            this.dtpCikisTarihi.TabIndex = 2;
            // 
            // lblOdemeSecili
            // 
            this.lblOdemeSecili.AutoSize = true;
            this.lblOdemeSecili.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOdemeSecili.Location = new System.Drawing.Point(20, 110);
            this.lblOdemeSecili.Name = "lblOdemeSecili";
            this.lblOdemeSecili.Size = new System.Drawing.Size(80, 15);
            this.lblOdemeSecili.TabIndex = 3;
            this.lblOdemeSecili.Text = "Ödeme Şekli:";
            // 
            // cmbOdemeSecili
            // 
            this.cmbOdemeSecili.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOdemeSecili.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbOdemeSecili.FormattingEnabled = true;
            this.cmbOdemeSecili.Location = new System.Drawing.Point(120, 107);
            this.cmbOdemeSecili.Name = "cmbOdemeSecili";
            this.cmbOdemeSecili.Size = new System.Drawing.Size(200, 23);
            this.cmbOdemeSecili.TabIndex = 3;
            // 
            // lblToplamTutar
            // 
            this.lblToplamTutar.AutoSize = true;
            this.lblToplamTutar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblToplamTutar.Location = new System.Drawing.Point(20, 140);
            this.lblToplamTutar.Name = "lblToplamTutar";
            this.lblToplamTutar.Size = new System.Drawing.Size(80, 15);
            this.lblToplamTutar.TabIndex = 4;
            this.lblToplamTutar.Text = "Toplam Tutar:";
            // 
            // txtToplamTutar
            // 
            this.txtToplamTutar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtToplamTutar.Location = new System.Drawing.Point(120, 137);
            this.txtToplamTutar.Name = "txtToplamTutar";
            this.txtToplamTutar.ReadOnly = true;
            this.txtToplamTutar.Size = new System.Drawing.Size(200, 23);
            this.txtToplamTutar.TabIndex = 4;
            // 
            // btnVazgec
            // 
            this.btnVazgec.BackColor = System.Drawing.Color.Gray;
            this.btnVazgec.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnVazgec.ForeColor = System.Drawing.Color.White;
            this.btnVazgec.Location = new System.Drawing.Point(70, 180);
            this.btnVazgec.Name = "btnVazgec";
            this.btnVazgec.Size = new System.Drawing.Size(90, 30);
            this.btnVazgec.TabIndex = 5;
            this.btnVazgec.Text = "Vazgeç";
            this.btnVazgec.UseVisualStyleBackColor = false;
            this.btnVazgec.Click += new System.EventHandler(this.btnVazgec_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.LightGreen;
            this.btnKaydet.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnKaydet.Location = new System.Drawing.Point(180, 180);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(90, 30);
            this.btnKaydet.TabIndex = 6;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // TaburcuOdemeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(340, 230);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.btnVazgec);
            this.Controls.Add(this.txtToplamTutar);
            this.Controls.Add(this.lblToplamTutar);
            this.Controls.Add(this.cmbOdemeSecili);
            this.Controls.Add(this.lblOdemeSecili);
            this.Controls.Add(this.dtpCikisTarihi);
            this.Controls.Add(this.lblCikisTarihi);
            this.Controls.Add(this.dtpSevkTarihi);
            this.Controls.Add(this.lblSevkTarihi);
            this.Controls.Add(this.txtDosyaNo);
            this.Controls.Add(this.lblDosyaNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TaburcuOdemeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SOHATS - Taburcu";
            this.Load += new System.EventHandler(this.TaburcuOdemeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblDosyaNo;
        private System.Windows.Forms.TextBox txtDosyaNo;
        private System.Windows.Forms.Label lblSevkTarihi;
        private System.Windows.Forms.DateTimePicker dtpSevkTarihi;
        private System.Windows.Forms.Label lblCikisTarihi;
        private System.Windows.Forms.DateTimePicker dtpCikisTarihi;
        private System.Windows.Forms.Label lblOdemeSecili;
        private System.Windows.Forms.ComboBox cmbOdemeSecili;
        private System.Windows.Forms.Label lblToplamTutar;
        private System.Windows.Forms.TextBox txtToplamTutar;
        private System.Windows.Forms.Button btnVazgec;
        private System.Windows.Forms.Button btnKaydet;
    }
}
