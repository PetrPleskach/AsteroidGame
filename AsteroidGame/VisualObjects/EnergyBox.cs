using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AsteroidGame.Properties.Resources;

namespace AsteroidGame.VisualObjects
{
    class EnergyBox : CollisionObject, ICollision
    {
        //Основные поля
        private static Image image = new Bitmap(energybox);
        private const int energyBoxSizeX = 30;
        private const int energyBoxSizeY = 30;
        private int energyBoxSpeedX = 5;
        private int energyBoxSpeedY = 5;

        public int EnergyRestore => 10;//количество восполняемой энергии

        public EnergyBox(int position) : base(new Point(200, position), Point.Empty, new Size(energyBoxSizeX, energyBoxSizeY))
        {

        }

        public override void Draw(Graphics graphics)
        {            
            Rectangle rect = Rect;
            graphics.DrawImage(image, rect);
        }

        public override void Update()
        {            
            position.X += energyBoxSpeedX;
            position.Y += energyBoxSpeedY;
            if (position.X < 0 || position.X+energyBoxSizeX > Game.Width)
                energyBoxSpeedX *= -1;
            if (position.Y < 0 || position.Y+energyBoxSizeY > Game.Height)
                energyBoxSpeedY *= -1;
        }

        public void Drop(Asteroid asteroid)
        {
            position =  new Point(asteroid.Rect.X , asteroid.Rect.Y);
            IsEnabled = true;
        }
    }
}
