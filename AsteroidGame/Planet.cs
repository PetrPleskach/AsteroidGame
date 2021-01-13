using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AsteroidGame
{
    class Planet : BaseVisualObject
    {
        public Planet(Point position, Point direction, Size size) : base(position, direction, size) { }

        public override void Update()
        {
            Position.X = Position.X - Direction.X;
            if (Position.X < -200) Position.X = Game.Width + Size.Width;
        }
    }    
}
