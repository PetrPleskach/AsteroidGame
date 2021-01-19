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
        private const int energyBoxSizeX = 30;
        private const int energyBoxSizeY = 30;
        private int energyBoxSpeed = 5;

        public int EnergyRestore => 10;//количество восполняемой энергии

        public EnergyBox(int position) : base(new Point(200, position), Point.Empty, new Size(energyBoxSizeX, energyBoxSizeY))
        {

        }

        public override void Draw(Graphics graphics)
        {
            Rectangle rect = Rect;
            graphics.FillEllipse(Brushes.Red, rect);
            graphics.DrawEllipse(Pens.White, rect);
        }

        public override void Update()
        {
            Position.X += energyBoxSpeed;
            Position.Y += energyBoxSpeed;
            if (Position.X < 0 || Position.X > Game.Width)
                energyBoxSpeed *= -1;
            if (Position.Y < 0 || Position.Y > Game.Height)
                energyBoxSpeed *= -1;
        }
    }
}
