using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AsteroidGame
{
    class Star : BaseVisualObject
    {
        public Star(Point position, Point direction, Size size) : base(position, direction, size) { }

        public override void Draw(Graphics graphics)
        {
            //рисуем звезду
            graphics.DrawLine(Pens.White, Position.X, Position.Y, Position.X + Size.Width, Position.Y + Size.Height);
            graphics.DrawLine(Pens.White, Position.X + Size.Width, Position.Y, Position.X, Position.Y + Size.Height);            
        }
        public override void Update()
        {
            //обновляем положение звезды только по оси X
            Position.X -= Direction.X;
            if (Position.X < 0)
                Position.X = Game.Width + Size.Width;
        }        
    }
}
