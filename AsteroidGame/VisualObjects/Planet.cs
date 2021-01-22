using System.Collections.Generic;
using System.Drawing;


namespace AsteroidGame.VisualObjects


{
    class Planet : BaseVisualObject
    {        
        private Bitmap image;//переменная для хранения изображения
        private static List<Bitmap> planetSkins = new List<Bitmap>()//список изображений для планет
        {            
            new Bitmap(@"..\..\..\img/planets/planet01.png"),
            new Bitmap(@"..\..\..\img/planets/planet02.png"),
            new Bitmap(@"..\..\..\img/planets/planet03.png"),
            new Bitmap(@"..\..\..\img/planets/planet04.png"),
            new Bitmap(@"..\..\..\img/planets/planet05.png"),
            new Bitmap(@"..\..\..\img/planets/planet06.png"),
            new Bitmap(@"..\..\..\img/planets/planet07.png"),
            new Bitmap(@"..\..\..\img/planets/planet08.png"),
        };
        
        public Planet(Point position, Point direction, int size) : base(position, direction, new Size(size, size))
        {
            image = planetSkins[random.Next(0, planetSkins.Count)];//указываем случайное изображение
        }

        public override void Update()
        {
            Position.X -= Direction.X;
            if (Position.X < -random.Next(Size.Width, 500))//добавляем немного рандома в поведение планеты
            {
                Position.X = Game.Width + Size.Width;
                Position.Y = random.Next(Size.Height, (Game.Height - Size.Height));//Меняем положение обьекта
                image = planetSkins[random.Next(0, planetSkins.Count)];//Меняем скин планеты
            }                
        }
        public override void Draw(Graphics graphics)
        {            
            graphics.DrawImage(image, Position.X, Position.Y, Size.Width, Size.Height);
        }
    }    
}
