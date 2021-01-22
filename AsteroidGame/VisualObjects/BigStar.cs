using System.Drawing;

namespace AsteroidGame.VisualObjects
{
    class BigStar : Star
    {
        public BigStar(Point position, Point direction, int size) : base(position, direction, size) { }

        public override void Draw(Graphics graphics)
        {
            base.Draw(graphics);
            //Рисуем дополнительные лучи
            graphics.DrawLine(Pens.AntiqueWhite, position.X + size.Width / 2, position.Y - size.Height, position.X + size.Width / 2, position.Y + size.Height * 2);
            graphics.DrawLine(Pens.AntiqueWhite, position.X - size.Width, position.Y + size.Height / 2, position.X + size.Width * 2, position.Y + size.Height / 2);
        }

    }
}
