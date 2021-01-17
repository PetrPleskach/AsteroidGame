using AsteroidGame.VisualObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AsteroidGame
{
    static class SplashScreen
    {
        private static Random random = new Random();
        private static BufferedGraphicsContext contex;
        private static BufferedGraphics buffer;
        private static List<BaseVisualObject> gameObjects;

        //константы для задания количества обьектов разных типов на заставке
        private const int numOfPLanets = 3;
        private const int numOfBigStars = 7;
        private const int numOfStars = 20;
        private const int numOfSmallStars = 100;
        private const int numOfAsteroids = 15;

        //Ширина и высота игровой области
        public static int Width { get; set; }
        public static int Height { get; set; }

        public static void Initialize(Form form)
        {
            //запоминаем размер формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;

            contex = BufferedGraphicsManager.Current;// Предоставляет доступ к главному буферу графического контекста для текущего приложения
            Graphics graphics = form.CreateGraphics();// Создаем объект (поверхность рисования) и связываем его с формой
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            buffer = contex.Allocate(graphics, new Rectangle(0, 0, Width, Height));
            Load();//Выполняем загрузку обьектов
            Timer timer = new Timer { Interval = 100 };//Добавляем таймер, задаём интервал для вызова события
            timer.Tick += Timer_Tick;//Создаём событие для таймера
            timer.Start();
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
            gameObjects = new List<BaseVisualObject>();                                   
            for (int i = 0; i < numOfSmallStars; i++)
                gameObjects.Add(new SmallStar(
                    new Point(random.Next(0, Width), random.Next(0, Height)),
                    new Point(random.Next(1, 3), 0),
                    2));
            
            for (int i = 0; i < numOfStars; i++)
                gameObjects.Add(new Star(
                    new Point(random.Next(0, Width), random.Next(0, Height)),
                    new Point(random.Next(2, 4), 0),
                    5));
            
            for (int i = 0; i < numOfBigStars; i++)
                gameObjects.Add(new BigStar(
                    new Point(random.Next(0, Width), random.Next(0, Height)),
                    new Point(random.Next(3, 5), 0),
                    7));
            
            for (int i = 0; i < numOfPLanets; i++)
                gameObjects.Add(new Planet(
                    new Point(random.Next(0, Width), random.Next(0, Height)),
                    new Point(random.Next(4, 6), 0),
                    90));

            for (int i = 0; i < numOfAsteroids; i++)
                gameObjects.Add(new Asteroid(
                    new Point(random.Next(0, Width), random.Next(0, Height)),
                    new Point(random.Next(5, 7), random.Next(-4, 5)),
                    40));

        }
        public static void Update()
        {
            foreach (BaseVisualObject gameObject in gameObjects)
                gameObject.Update();
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
    }
}
