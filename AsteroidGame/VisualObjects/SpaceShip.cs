using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AsteroidGame.Properties.Resources;

namespace AsteroidGame.VisualObjects
{
    class SpaceShip : BaseVisualObject, ICollision
    {
        public event EventHandler ShipDestoyed;
        private Image image = new Bitmap(spaceship);
        private int energy = 100;
        public int Energy
        {
            get => energy;
            set => energy = (energy + value > 100) ? 100 : energy + value;
        }
        public Rectangle Rect => new Rectangle(position, size);
        public Size Size => size;

        public SpaceShip(Point position, Point direction, Size size) : base(position, direction, size) { }

        public override void Draw(Graphics graphics) { graphics.DrawImage(image, position.X, position.Y, size.Width, size.Height);  }

        public override void Update() { }

        public void MoveUp()
        {
            if (position.Y > 0) position.Y -= direction.Y;                
        }

        public void MoveDown()
        {
            if (position.Y < Game.Height + size.Height) position.Y += direction.Y;
        }

        public bool CheckCollision(ICollision obj)
        {
            bool isCollision = Rect.IntersectsWith(obj.Rect);
            if(isCollision && obj is Asteroid asteroid)            
                ChangeEnergy(-asteroid.Durability);
            if (isCollision && obj is EnergyBox energyBox)
                ChangeEnergy(energyBox.EnergyRestore);
            return isCollision;
        }

        public void ChangeEnergy(int valueToChange)
        {
            Energy = valueToChange;
            if (Energy < 0)
                ShipDestoyed?.Invoke(this, EventArgs.Empty);
        }


    }
}
