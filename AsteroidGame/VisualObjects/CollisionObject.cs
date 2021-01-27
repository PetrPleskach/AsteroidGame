using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AsteroidGame.VisualObjects
{
    abstract class CollisionObject : BaseVisualObject
    {
        protected CollisionObject(Point Position, Point Direction, Size Size)
            : base(Position, Direction, Size) { }

        public Rectangle Rect => new Rectangle(position, size);

        public bool CheckCollision(ICollision obj) => Rect.IntersectsWith(obj.Rect);
    }
}
