using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsteroidGame
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form gameForm = new Form();
            gameForm.Width = 800;
            gameForm.Height = 600;
            gameForm.StartPosition = FormStartPosition.CenterScreen;
            gameForm.Show();

            SplashScreen.Initialize(gameForm);
            SplashScreen.Draw();
            Application.Run(gameForm);            
        }
    }
}
