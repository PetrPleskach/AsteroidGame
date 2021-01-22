﻿using System;
using System.Drawing;
using System.Windows.Forms;
using AsteroidGame.VisualObjects;

namespace AsteroidGame
{

    static class Game
    {        
        static Random random = new Random(); 
        private static BufferedGraphicsContext contex;
        private static BufferedGraphics buffer;
        private static BaseVisualObject[] gameObjects;//Массив обьектов для отрисовки

        private static int width;//ширина игровой области
        private static int heigth;//высота игровой области


        //константы для задания количества обьектов разных типов на заставке
        private const int numOfPLanets = 2;
        private const int numOfBigStars = 7;
        private const int numOfStars = 20;
        private const int numOfSmallStars = 100;


        //Свойства ширины и высоты игровой области
        public static int Width { get => width;
            set 
            {
                if (value > 1000 || value < 0)
                    throw new ArgumentOutOfRangeException("Ширина окна не может быть больше 1000px или 0px");
                else
                    width = value;
            } }
        public static int Height { get => heigth;
            set 
            {
                if (value > 1000 || value < 0)
                    throw new ArgumentOutOfRangeException("Высота окна не может быть больше 1000px или 0px");
                else
                    heigth = value;
            } }


        public static void Initialize(Form form)
        {
            //запоминаем размер формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;

            contex = BufferedGraphicsManager.Current;// Предоставляет доступ к главному буферу графического контекста для текущего приложения
            Graphics graphics = form.CreateGraphics();// Создаем объект (поверхность рисования) и связываем его с формой
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            buffer = contex.Allocate(graphics, new Rectangle(0,0, Width, Height));
            Load();//Выполняем загрузку обьектов
            Timer timer = new Timer { Interval = 100 };//Добавляем таймер, задаём интервал для вызова события
            timer.Tick += Timer_Tick;//Создаём событие для таймера
            timer.Start();
        }
        /// <summary>
        /// перерисовывает и обновляет положение обьектов при каждом тике таймера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        
        public static void Draw()
        {
            Graphics graphics = buffer.Graphics;
            graphics.Clear(Color.Black);
            foreach (BaseVisualObject gameObject in gameObjects)
                gameObject.Draw(graphics);

            buffer.Render();
        }
        public static void Load()
        {            
            const int visualObjectsCount = numOfSmallStars + numOfStars + numOfBigStars + numOfPLanets;
            gameObjects = new BaseVisualObject[visualObjectsCount];
            int length, startCount;//переменные для удобства перебора данных в массиве                       
            for (int i = startCount = 0; i < (length = numOfSmallStars); i++)
                gameObjects[i] = new SmallStar(
                    new Point(random.Next(0, Width), random.Next(0, Height)),
                    new Point(random.Next(1, 5), 0),
                    2);
            length += numOfStars;
            for (int i = (startCount += numOfSmallStars); i < length; i++)
                gameObjects[i] = new Star(
                    new Point(random.Next(0, Width), random.Next(0, Height)),
                    new Point(random.Next(2,8), 0),
                    5);
            length += numOfBigStars;
            for (int i = (startCount += numOfStars); i < length; i++)
                gameObjects[i] = new BigStar(
                    new Point(random.Next(0, Width), random.Next(0, Height)),
                    new Point(random.Next(3,10), 0),
                    7);
            length += numOfPLanets;
            for (int i = (startCount += numOfBigStars); i < length; i++)
                gameObjects[i] = new Planet(
                    new Point(random.Next(0, Width), random.Next(0, Height)),
                    new Point(random.Next(5,10), 0),
                    90); 
        }
        public static void Update()
        {
            foreach (BaseVisualObject gameObject in gameObjects)            
                gameObject.Update();     
        }
    }
}
