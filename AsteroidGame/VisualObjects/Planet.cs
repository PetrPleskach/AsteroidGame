using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AsteroidGame
{
    class Planet : BaseVisualObject
    {
        private Random random = new Random();
        private Bitmap image;//переменная для хранения изображения
        private List<Bitmap> planetSkins = new List<Bitmap>()//список изображений для планет
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
        
        public Planet(Point position, Point direction, Size size) : base(position, direction, size)
        {
            image = planetSkins[random.Next(0, planetSkins.Count)];//указываем случайное изображение
        }

        public override void Update()
        {
            Position.X -= Direction.X;
            if (Position.X < -200)
            {
                Position.X = Game.Width + Size.Width;                 
                image = planetSkins[random.Next(0, planetSkins.Count)];//Меняем скин планеты
            }                
        }
        public override void Draw(Graphics graphics)
        {            
            graphics.DrawImage(image, Position.X, Position.Y, Size.Width, Size.Height);
        }
    }    
}
