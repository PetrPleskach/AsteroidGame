using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObjects
{
    class EnergyBox : CollisionObject, ICollision
    {
        //Основные поля
        private static Image image = Image.FromFile(@"..\..\..\img/energybox/energybox.png");
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
            Position.X += energyBoxSpeedX;
            Position.Y += energyBoxSpeedY;
            if (Position.X < 0 || Position.X+energyBoxSizeX > Game.Width)
                energyBoxSpeedX *= -1;
            if (Position.Y < 0 || Position.Y+energyBoxSizeY > Game.Height)
                energyBoxSpeedY *= -1;
        }
    }
}
