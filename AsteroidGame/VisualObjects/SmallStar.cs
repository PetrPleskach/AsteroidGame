using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame
{
    class SmallStar : Star
    {
        private Random random = new Random();
        private Color color;

        public SmallStar(Point position, Point direction, Size size) : base(position, direction, size)
        {
            color = Color.FromArgb(random.Next(150, 255), random.Next(150, 255), random.Next(150, 255));
        }

        public override void Draw(Graphics graphics)
        {            
            Brush brush = new SolidBrush(color);
            graphics.FillEllipse(brush,Position.X, Position.Y, Size.Width, Size.Height);
        }
    }
}
