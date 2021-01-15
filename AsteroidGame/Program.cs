using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

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
            
            Button startButton = new Button();
            startButton.Parent = gameForm;
            startButton.Text = "New Game";
            startButton.Location = new Point(200, gameForm.Height / 2);

            Button recordsButton = new Button();
            recordsButton.Parent = gameForm;
            recordsButton.Text = "Hi-score";
            recordsButton.Location = new Point(400, gameForm.Height / 2);

            Button exitButton = new Button();
            exitButton.Parent = gameForm;
            exitButton.Text = "Exit";
            exitButton.Location = new Point(600, gameForm.Height / 2);

            Label credits = new Label();
            credits.Parent = gameForm;
            credits.AutoSize = true; 
            credits.Text = $"Плескач Петр ©{DateTime.Now.Year}";            
            credits.Location = new Point(0, gameForm.ClientSize.Height - credits.Size.Height);

            Game.Width = 800;
            Game.Height = 600;
            SplashScreen.Initialize(gameForm);
            SplashScreen.Draw();
            Application.Run(gameForm);           
        }
    }
}
