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
        private Brush brush;//переменная для заливки

        public SmallStar(Point position, Point direction, Size size) : base(position, direction, size)
        {
            //присваиваем начальный цвет            
            brush = new SolidBrush(Color.FromArgb(random.Next(170, 255), random.Next(170, 255), random.Next(170, 255)));
        }

        public override void Draw(Graphics graphics)
        {
            graphics.FillEllipse(brush, Position.X, Position.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
            Position.X -= Direction.X;
            if (Position.X < 0) 
            { 
                Position.X = Game.Width + Size.Width;
                //меняем цвет для кисти
                brush = new SolidBrush(Color.FromArgb(random.Next(170, 255), random.Next(170, 255), random.Next(170, 255)));
            }
        }
    }
}
