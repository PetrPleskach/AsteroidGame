using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObjects
{
    class Bullet : BaseVisualObject
    {
        private const int bulletSizeX = 20;
        private const int bulletSizeY = 5;
        private const int bulletSpeed = 3;

        public Bullet(int position) : base(new Point(0, position), Point.Empty, new Size(bulletSizeX, bulletSizeY)) { }

        public override void Draw(Graphics graphics)
        {
            throw new NotImplementedException();
        }

        public override void Update() => Position.X += bulletSpeed;
    }
}
