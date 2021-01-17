using System;
using System.Drawing;

namespace AsteroidGame
{
    abstract class BaseVisualObject
    {
        protected Point Position;//положение обьекта
        protected Point Direction;//направление движения обьекта
        protected Size Size;//размер
        protected static Random random = new Random();
        
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
        public abstract void Draw(Graphics graphics);

        /// <summary>
        /// Базовый метод обновления положения
        /// </summary>
        public abstract void Update();
 
    }
}
