using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AsteroidGame.VisualObjects
{
    class Asteroid : BaseVisualObject
    {
        private Bitmap image;
        private static List<Bitmap> asteroidSkins = new List<Bitmap>()
        {
            new Bitmap(@"..\..\..\img/asteroids/pngegg (1).png"),
            new Bitmap(@"..\..\..\img/asteroids/pngegg (2).png"),
            new Bitmap(@"..\..\..\img/asteroids/pngegg (3).png"),
            new Bitmap(@"..\..\..\img/asteroids/pngegg (4).png"),
            new Bitmap(@"..\..\..\img/asteroids/pngegg (5).png"),
            new Bitmap(@"..\..\..\img/asteroids/pngegg (6).png"),
            new Bitmap(@"..\..\..\img/asteroids/pngegg (7).png"),
            new Bitmap(@"..\..\..\img/asteroids/pngegg (8).png"),
            new Bitmap(@"..\..\..\img/asteroids/pngegg (9).png"),
            new Bitmap(@"..\..\..\img/asteroids/pngegg (10).png"),
        };
        public Asteroid(Point position, Point direction, int size) : base(position, direction, new Size(size, size))
        {
            image = asteroidSkins[random.Next(0, asteroidSkins.Count)];
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawImage(image, Position.X, Position.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Position.X -= Direction.X;            
            if (Position.X < -random.Next(Size.Width, 100))
            {
                if (Direction.Y == 0)
                    Direction.Y = random.Next(-4, 5);
                Position.X = Game.Width + Size.Width;
                Position.Y = random.Next(Size.Height, (Game.Height - Size.Height));
                image = asteroidSkins[random.Next(0, asteroidSkins.Count)];
            }
            Position.Y += Direction.Y;
            if (Position.Y < -random.Next(Size.Height, 100))
            {
                Position.X = Game.Width + Size.Width;
                Position.Y = random.Next(Size.Height, (Game.Height - Size.Height));
                image = asteroidSkins[random.Next(0, asteroidSkins.Count)];
            }
        }
    }
}
