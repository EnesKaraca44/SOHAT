namespace SunumKatmani
{
    partial class DosyaBulForm
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
            this.lblAramaKriteri = new System.Windows.Forms.Label();
            this.cmbAramaKriteri = new System.Windows.Forms.ComboBox();
            this.txtAramaDegeri = new System.Windows.Forms.TextBox();
            this.btnBul = new System.Windows.Forms.Button();
            this.dgvHastalar = new System.Windows.Forms.DataGridView();
            this.btnIptal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHastalar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAramaKriteri
            // 
            this.lblAramaKriteri.AutoSize = true;
            this.lblAramaKriteri.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAramaKriteri.Location = new System.Drawing.Point(15, 20);
            this.lblAramaKriteri.Name = "lblAramaKriteri";
            this.lblAramaKriteri.Size = new System.Drawing.Size(90, 19);
            this.lblAramaKriteri.TabIndex = 0;
            this.lblAramaKriteri.Text = "Arama Kriteri";
            // 
            // cmbAramaKriteri
            // 
            this.cmbAramaKriteri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAramaKriteri.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbAramaKriteri.FormattingEnabled = true;
            this.cmbAramaKriteri.Location = new System.Drawing.Point(110, 17);
            this.cmbAramaKriteri.Name = "cmbAramaKriteri";
            this.cmbAramaKriteri.Size = new System.Drawing.Size(180, 25);
            this.cmbAramaKriteri.TabIndex = 0;
            // 
            // txtAramaDegeri
            // 
            this.txtAramaDegeri.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAramaDegeri.Location = new System.Drawing.Point(300, 17);
            this.txtAramaDegeri.Name = "txtAramaDegeri";
            this.txtAramaDegeri.Size = new System.Drawing.Size(200, 25);
            this.txtAramaDegeri.TabIndex = 1;
            // 
            // btnBul
            // 
            this.btnBul.BackColor = System.Drawing.Color.LightBlue;
            this.btnBul.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBul.Location = new System.Drawing.Point(510, 15);
            this.btnBul.Name = "btnBul";
            this.btnBul.Size = new System.Drawing.Size(80, 30);
            this.btnBul.TabIndex = 2;
            this.btnBul.Text = "Bul";
            this.btnBul.UseVisualStyleBackColor = false;
            this.btnBul.Click += new System.EventHandler(this.btnBul_Click);
            // 
            // dgvHastalar
            // 
            this.dgvHastalar.AllowUserToAddRows = false;
            this.dgvHastalar.AllowUserToDeleteRows = false;
            this.dgvHastalar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHastalar.Location = new System.Drawing.Point(15, 60);
            this.dgvHastalar.Name = "dgvHastalar";
            this.dgvHastalar.ReadOnly = true;
            this.dgvHastalar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHastalar.Size = new System.Drawing.Size(575, 300);
            this.dgvHastalar.TabIndex = 3;
            this.dgvHastalar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHastalar_CellDoubleClick);
            // 
            // btnIptal
            // 
            this.btnIptal.BackColor = System.Drawing.Color.Gray;
            this.btnIptal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnIptal.ForeColor = System.Drawing.Color.White;
            this.btnIptal.Location = new System.Drawing.Point(250, 370);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(100, 35);
            this.btnIptal.TabIndex = 4;
            this.btnIptal.Text = "İptal";
            this.btnIptal.UseVisualStyleBackColor = false;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // DosyaBulForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(604, 417);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.dgvHastalar);
            this.Controls.Add(this.btnBul);
            this.Controls.Add(this.txtAramaDegeri);
            this.Controls.Add(this.cmbAramaKriteri);
            this.Controls.Add(this.lblAramaKriteri);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DosyaBulForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dosya Bul";
            this.Load += new System.EventHandler(this.DosyaBulForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHastalar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblAramaKriteri;
        private System.Windows.Forms.ComboBox cmbAramaKriteri;
        private System.Windows.Forms.TextBox txtAramaDegeri;
        private System.Windows.Forms.Button btnBul;
        private System.Windows.Forms.DataGridView dgvHastalar;
        private System.Windows.Forms.Button btnIptal;
    }
}
