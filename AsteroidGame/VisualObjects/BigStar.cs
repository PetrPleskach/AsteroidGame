using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AsteroidGame
{
    class BigStar : Star
    {
        public BigStar(Point position, Point direction, int size) : base(position, direction, size) { }

        public override void Draw(Graphics graphics)
        {
            base.Draw(graphics);
            //Рисуем дополнительные лучи
            graphics.DrawLine(Pens.AntiqueWhite, Position.X + Size.Width / 2, Position.Y - Size.Height, Position.X + Size.Width / 2, Position.Y + Size.Height * 2);
            graphics.DrawLine(Pens.AntiqueWhite, Position.X - Size.Width, Position.Y + Size.Height / 2, Position.X + Size.Width * 2, Position.Y + Size.Height / 2);
        }

    }
}
