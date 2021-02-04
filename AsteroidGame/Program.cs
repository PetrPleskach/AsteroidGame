using System;
using System.Windows.Forms;
using System.Drawing;
using AsteroidGame.Logging;

namespace AsteroidGame
{
    static class Program
    {
        private static TextFileLogger textLogger;
        private static DebugLogger debugLogger;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            textLogger = new TextFileLogger(@$"logs\{DateTime.Now.ToFileTime()}.log", false);            
            debugLogger = new DebugLogger();
            textLogger.LogInfo("Application Load");
            debugLogger.LogInfo("Application Run");
            Game.Logging += Game_Logging;
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form gameForm = new Form();
            gameForm.Width = 800;
            gameForm.Height = 600;
            gameForm.StartPosition = FormStartPosition.CenterScreen;
            gameForm.Text = "Asteroids";
            gameForm.FormClosing += gameForm_FormClosing;
            gameForm.Show();
            /*
            Button startButton = new Button();
            startButton.Parent = menuForm;
            startButton.Text = "New Game";
            startButton.Location = new Point(200, menuForm.Height / 2);
            startButton.Click += StartButton_Click;

            Button recordsButton = new Button();
            recordsButton.Parent = menuForm;
            recordsButton.Text = "Hi-score";
            recordsButton.Location = new Point(400, menuForm.Height / 2);

            Button exitButton = new Button();
            exitButton.Parent = menuForm;
            exitButton.Text = "Exit";
            exitButton.Location = new Point(600, menuForm.Height / 2);

            Label credits = new Label();
            credits.Parent = menuForm;
            credits.AutoSize = true; 
            credits.Text = $"Плескач Петр ©{DateTime.Now.Year}";            
            credits.Location = new Point(0, menuForm.ClientSize.Height - credits.Size.Height);
            */

            Game.Initialize(gameForm);
            Game.Draw();
            Application.Run(gameForm);            
        }

        private static void Game_Logging(string message)
        {
            textLogger.LogInfo(message);
            debugLogger.LogInfo(message);
        }

        private static void gameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вы уверены?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
            else
            {
                Game.TimerEnable = false;
                textLogger.LogInfo("Application closed");
                debugLogger.LogInfo("Application closed");
            }
        }

        static void StartButton_Click(object sender, EventArgs e)
        {
                        
        }

    }
}
