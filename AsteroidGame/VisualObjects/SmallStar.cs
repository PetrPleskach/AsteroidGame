using System.Drawing;

namespace AsteroidGame.VisualObjects
{
    class SmallStar : Star
    {               
        private Brush brush;//переменная для заливки

        public SmallStar(Point position, Point direction, int size) : base(position, direction, size)
        {
            //присваиваем начальный цвет            
            brush = new SolidBrush(Color.FromArgb(random.Next(170, 255), random.Next(170, 255), random.Next(170, 255)));
        }

        public override void Draw(Graphics graphics) => graphics.FillEllipse(brush, position.X, position.Y, size.Width, size.Height);

        public override void Update()
        {
            position.X -= direction.X;
            if (position.X < -size.Width)
            { 
                position.X = Game.Width + size.Width;
                position.Y = random.Next(size.Height, (Game.Height - size.Height));//Меняем положение обьекта
                //меняем цвет кисти
                brush = new SolidBrush(Color.FromArgb(random.Next(170, 255), random.Next(170, 255), random.Next(170, 255)));
            }
        }
    }
}
