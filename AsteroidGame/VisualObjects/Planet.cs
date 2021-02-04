using System.Collections.Generic;
using System.Drawing;
using static AsteroidGame.Properties.Resources;

namespace AsteroidGame.VisualObjects
{
    class Planet : BaseVisualObject
    {        
        private Bitmap image;//переменная для хранения изображения
        private static List<Bitmap> planetSkins = new List<Bitmap>()//список изображений для планет
        {            
            new Bitmap(planet01),
            new Bitmap(planet02),
            new Bitmap(planet03),
            new Bitmap(planet04),
            new Bitmap(planet05),
            new Bitmap(planet06),
            new Bitmap(planet07),
            new Bitmap(planet08),
        };
        
        public Planet(Point position, Point direction, int size) : base(position, direction, new Size(size, size))
        {
            image = planetSkins[random.Next(0, planetSkins.Count)];//указываем случайное изображение
        }

        public override void Update()
        {
            position.X -= direction.X;
            if (position.X < -random.Next(size.Width, 500))//добавляем немного рандома в поведение планеты
            {
                position.X = Game.Width + size.Width;
                position.Y = random.Next(size.Height, (Game.Height - size.Height));//Меняем положение обьекта
                image = planetSkins[random.Next(0, planetSkins.Count)];//Меняем скин планеты
            }                
        }
        public override void Draw(Graphics graphics)
        {            
            graphics.DrawImage(image, position.X, position.Y, size.Width, size.Height);
        }
    }    
}
