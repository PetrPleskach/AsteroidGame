using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame
{
    class BaseVisualObject
    {
        protected Point Position;//положение обьекта
        protected Point Direction;//направление движения обьекта
        protected Size Size;//размер
        protected static Random random = new Random();

        public BaseVisualObject() { }
        public BaseVisualObject(Point position, Point direction, Size size)//конструктор для задания базовых параметров
        {
            Position = position;
            Direction = direction;
            Size =  size;
        }

        /// <summary>
        /// Базовый метод отрисовки
        /// </summary>
        /// <param name="graphics"></param>
        public virtual void Draw(Graphics graphics)
        {
            graphics.DrawEllipse(Pens.White, Position.X, Position.Y, Size.Width, Size.Height);
        }
        /// <summary>
        /// Базовый метод обновления положения
        /// </summary>
        public virtual void Update()
        {
            Position.X += Direction.X;
            Position.Y += Direction.Y;
            if (Position.X < 0) Direction.X = -Direction.X;
            if (Position.Y < 0) Direction.Y = -Direction.Y;
            if (Position.X > Game.Width - Size.Width) Direction.X = -Direction.X;
            if (Position.Y > Game.Height - Size.Height) Direction.Y = -Direction.Y;
        }
    }
}
