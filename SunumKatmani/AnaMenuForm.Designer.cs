namespace SunumKatmani
{
    partial class AnaMenuForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.referanslarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.poliklinikTanimaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kullaniciTanimaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cikisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hastaKabulToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.raporlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.referanslarToolStripMenuItem,
            this.hastaKabulToolStripMenuItem,
            this.raporlarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1024, 27);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // referanslarToolStripMenuItem
            // 
            this.referanslarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem,
            this.poliklinikTanimaToolStripMenuItem,
            this.kullaniciTanimaToolStripMenuItem,
            this.cikisToolStripMenuItem});
            this.referanslarToolStripMenuItem.Name = "referanslarToolStripMenuItem";
            this.referanslarToolStripMenuItem.Size = new System.Drawing.Size(92, 23);
            this.referanslarToolStripMenuItem.Text = "Referanslar";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(193, 24);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // poliklinikTanimaToolStripMenuItem
            // 
            this.poliklinikTanimaToolStripMenuItem.Name = "poliklinikTanimaToolStripMenuItem";
            this.poliklinikTanimaToolStripMenuItem.Size = new System.Drawing.Size(193, 24);
            this.poliklinikTanimaToolStripMenuItem.Text = "Poliklinik Tanıma";
            this.poliklinikTanimaToolStripMenuItem.Click += new System.EventHandler(this.poliklinikTanimaToolStripMenuItem_Click);
            // 
            // kullaniciTanimaToolStripMenuItem
            // 
            this.kullaniciTanimaToolStripMenuItem.Name = "kullaniciTanimaToolStripMenuItem";
            this.kullaniciTanimaToolStripMenuItem.Size = new System.Drawing.Size(193, 24);
            this.kullaniciTanimaToolStripMenuItem.Text = "Kullanıcı Tanıma";
            this.kullaniciTanimaToolStripMenuItem.Click += new System.EventHandler(this.kullaniciTanimaToolStripMenuItem_Click);
            // 
            // cikisToolStripMenuItem
            // 
            this.cikisToolStripMenuItem.Name = "cikisToolStripMenuItem";
            this.cikisToolStripMenuItem.Size = new System.Drawing.Size(193, 24);
            this.cikisToolStripMenuItem.Text = "Çıkış";
            this.cikisToolStripMenuItem.Click += new System.EventHandler(this.cikisToolStripMenuItem_Click);
            // 
            // hastaKabulToolStripMenuItem
            // 
            this.hastaKabulToolStripMenuItem.Name = "hastaKabulToolStripMenuItem";
            this.hastaKabulToolStripMenuItem.Size = new System.Drawing.Size(98, 23);
            this.hastaKabulToolStripMenuItem.Text = "Hasta Kabul";
            this.hastaKabulToolStripMenuItem.Click += new System.EventHandler(this.hastaKabulToolStripMenuItem_Click);
            // 
            // raporlarToolStripMenuItem
            // 
            this.raporlarToolStripMenuItem.Name = "raporlarToolStripMenuItem";
            this.raporlarToolStripMenuItem.Size = new System.Drawing.Size(78, 23);
            this.raporlarToolStripMenuItem.Text = "Raporlar";
            this.raporlarToolStripMenuItem.Click += new System.EventHandler(this.raporlarToolStripMenuItem_Click);
            // 
            // AnaMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AnaMenuForm";
            this.Text = "Sağlık Ocağı Hasta Takip Sistemi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AnaMenuForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem referanslarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem poliklinikTanimaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kullaniciTanimaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cikisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hastaKabulToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem raporlarToolStripMenuItem;
    }
}
