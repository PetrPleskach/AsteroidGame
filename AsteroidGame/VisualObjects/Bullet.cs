using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObjects
{
    class Bullet : CollisionObject, ICollision
    {
        private const int bulletSizeX = 10;
        private const int bulletSizeY = 2;
        private const int bulletSpeed = 10;

        public static bool StartPositionLeft { get; set; } = true;

        public Bullet(Point position) : base(position, Point.Empty, new Size(bulletSizeX, bulletSizeY)) { }

        public override void Draw(Graphics graphics)
        {            
            Rectangle rect = Rect;
            graphics.FillEllipse(Brushes.Red, rect);
            graphics.DrawEllipse(Pens.White, rect);
        }

        public override void Update() => position.X += bulletSpeed;

        public void ResetPosition(Point x)
        {
            position = x;
            IsEnabled = true;
        }
    }
}
