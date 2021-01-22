using System.Drawing;

namespace AsteroidGame.VisualObjects
{
    class Star : BaseVisualObject
    {        
        public Star(Point position, Point direction, int size) : base(position, direction, new Size(size, size)) { }

        public override void Draw(Graphics graphics)
        {
            //рисуем звезду
            graphics.DrawLine(Pens.White, position.X, position.Y, position.X + size.Width, position.Y + size.Height);
            graphics.DrawLine(Pens.White, position.X + size.Width, position.Y, position.X, position.Y + size.Height);            
        }
        public override void Update()
        {
            //обновляем положение звезды только по оси X
            position.X -= direction.X;
            if (position.X < -size.Width)
            {
                position.X = Game.Width + size.Width;
                position.Y = random.Next(size.Height, (Game.Height - size.Height));//Меняем положение обьекта
            }
        }        
    }
}
