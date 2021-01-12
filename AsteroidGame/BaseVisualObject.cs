using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame
{
    class BaseVisualObject
    {
        protected Point Position;
        protected Point Direction;
        protected Size Size;

        public BaseVisualObject() { }
        public BaseVisualObject(Point position, Point direction, Size size)
        {
            Position = position;
            Direction = direction;
            Size = size;
        }

        public void Draw(Graphics graphics)
        {
            graphics.DrawEllipse(Pens.White, Position.X, Position.Y, Size.Width, Size.Height);
        }
        public void Update()
        {
            Position.X += Direction.X;
            Position.Y += Direction.Y;
            if (Position.X < 0) Direction.X = -Direction.X;
            if (Position.Y < 0) Direction.Y = -Direction.Y;
            if (Position.X > Game.Width) Direction.X = -Direction.X;
            if (Position.Y > Game.Height) Direction.Y = -Direction.Y;
        }
    }
}
