using System;
using System.Drawing;

namespace AsteroidGame.VisualObjects
{
    abstract class BaseVisualObject
    {
        //Основные параметры обьекта
        protected Point position;//положение обьекта
        protected Point direction;//направление движения обьекта
        protected Size size;//размер
        protected static Random random = new Random();

        //Свойства
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        ///Конструктор для задания базовых параметров
        /// </summary>
        /// <param name="position"></param>
        /// <param name="direction"></param>
        /// <param name="size"></param>
        protected BaseVisualObject(Point position, Point direction, Size size)
        {
            this.position = position;
            this.direction = direction;
            this.size =  size;
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
