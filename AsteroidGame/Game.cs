using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace AsteroidGame
{
    static class Game
    {
        private static BufferedGraphicsContext contex;
        public static BufferedGraphics Buffer;

        public static int Width { get; set; }
        public static int Height { get; set; }

        public static void Initialize(Form form)
        {
            Width = form.Width;
            Height = form.Height;

            contex = BufferedGraphicsManager.Current;
            Graphics graphics = form.CreateGraphics();
            Buffer = contex.Allocate(graphics, new Rectangle(0,0, Width, Height));
        }
        public static void Draw()
        {
            Graphics graphics = Buffer.Graphics;
            graphics.Clear(Color.Black);
            graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            graphics.FillEllipse(Brushes.Red, new Rectangle(100, 100, 200, 200));

            Buffer.Render();
        }
    }
}
