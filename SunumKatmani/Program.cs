using System;
using System.Windows.Forms;

namespace SunumKatmani
{
    internal static class Program
    {
       
        /// Uygulamanın ana giriş noktası.
   
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Login formunu göster
            LoginForm loginForm = new LoginForm();
            
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // Giriş başarılı - Ana menü aç
                Application.Run(new AnaMenuForm(loginForm.GirisYapanKullanici));
            }
        }
    }
}