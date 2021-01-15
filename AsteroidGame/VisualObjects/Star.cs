using System.Drawing;

namespace AsteroidGame
{
    class Star : BaseVisualObject
    {        
        public Star(Point position, Point direction, int size) : base(position, direction, new Size(size, size)) { }

        public override void Draw(Graphics graphics)
        {
            //рисуем звезду
            graphics.DrawLine(Pens.White, Position.X, Position.Y, Position.X + Size.Width, Position.Y + Size.Height);
            graphics.DrawLine(Pens.White, Position.X + Size.Width, Position.Y, Position.X, Position.Y + Size.Height);            
        }
        public override void Update()
        {
            //обновляем положение звезды только по оси X
            Position.X -= Direction.X;
            if (Position.X < -Size.Width)
            {
                Position.X = SplashScreen.Width + Size.Width;
                Position.Y = random.Next(Size.Height, (SplashScreen.Height - Size.Height));//Меняем положение обьекта
            }
        }        
    }
}
