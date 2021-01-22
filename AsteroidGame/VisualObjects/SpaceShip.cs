using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObjects
{
    class SpaceShip : BaseVisualObject, ICollision
    {
        public event EventHandler ShipDestoyed;
        private Image image = Image.FromFile(@"..\..\..\img/spaceship/spaceship.png");
        private int energy = 100;
        public int Energy
        {
            get => energy;
            set => energy = (energy + value > 100) ? 100 : energy + value;
        }
        public Rectangle Rect => new Rectangle(Position, Size);

        public SpaceShip(Point position, Point direction, Size size) : base(position, direction, size) { }

        public override void Draw(Graphics graphics) { graphics.DrawImage(image, Position.X, Position.Y, Size.Width, Size.Height);  }

        public override void Update() { }

        public void MoveUp()
        {
            if (Position.Y > 0) Position.Y -= Direction.Y;                
        }

        public void MoveDown()
        {
            if (Position.Y < Game.Height + Size.Height) Position.Y += Direction.Y;
        }

        public bool CheckCollision(ICollision obj)
        {
            bool isCollision = Rect.IntersectsWith(obj.Rect);
            if(isCollision && obj is Asteroid asteroid)            
                ChangeEnergy(-asteroid.Power);
            if (isCollision && obj is EnergyBox energyBox)
                ChangeEnergy(energyBox.EnergyRestore);
            return isCollision;
        }

        public void ChangeEnergy(int valueToChange)
        {
            energy = Energy + valueToChange;
            if (Energy < 0)
                ShipDestoyed?.Invoke(this, EventArgs.Empty);
        }


    }
}
