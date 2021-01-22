using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AsteroidGame.VisualObjects
{
    class Asteroid : BaseVisualObject, ICollision
    {
        private Bitmap image;
        private static List<Bitmap> asteroidSkins = new List<Bitmap>()
        {
            new Bitmap(@"..\..\..\img/asteroids/pngegg (1).png"),            
            new Bitmap(@"..\..\..\img/asteroids/pngegg (3).png"),
            new Bitmap(@"..\..\..\img/asteroids/pngegg (4).png"),
            new Bitmap(@"..\..\..\img/asteroids/pngegg (5).png"),            
            new Bitmap(@"..\..\..\img/asteroids/pngegg (7).png"),
            new Bitmap(@"..\..\..\img/asteroids/pngegg (8).png"),
            new Bitmap(@"..\..\..\img/asteroids/pngegg (9).png"),
            new Bitmap(@"..\..\..\img/asteroids/pngegg (10).png"),
        };

        //Свойства
        public Rectangle Rect => new Rectangle(position, size);
        public int Power { get; set; } = 10;

        public Asteroid(Point position, Point direction, int size) : base(position, direction, new Size(size, size))
        {
            image = asteroidSkins[random.Next(0, asteroidSkins.Count)];
        }

        public override void Draw(Graphics graphics) => graphics.DrawImage(image, position.X, position.Y, size.Width, size.Height); 

        public override void Update()
        {            
            position.X -= direction.X;            
            if (position.X < -random.Next(size.Width, 100))
            {
                if (direction.Y == 0)
                    direction.Y = random.Next(-4, 5);
                position.X = Game.Width + size.Width;
                position.Y = random.Next(size.Height, (Game.Height - size.Height));
                image = asteroidSkins[random.Next(0, asteroidSkins.Count)];
            }
            position.Y += direction.Y;
            if (position.Y < -random.Next(size.Height, 100))
            {
                position.X = Game.Width + size.Width;
                position.Y = random.Next(size.Height, (Game.Height - size.Height));
                image = asteroidSkins[random.Next(0, asteroidSkins.Count)];
            }
        }

        public bool CheckCollision(ICollision obj) => Rect.IntersectsWith(obj.Rect);

    }
}
