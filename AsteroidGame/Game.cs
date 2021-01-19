using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AsteroidGame.VisualObjects;

namespace AsteroidGame
{

    static class Game
    {
        //Основные поля
        private static Timer timer;//Добавляем таймер
        private static Random random = new Random(); 
        private static BufferedGraphicsContext contex;
        private static BufferedGraphics buffer;
        private static BaseVisualObject[] gameObjects;//Массив обьектов для отрисовки
        private static int width;//ширина игровой области
        private static int heigth;//высота игровой области
        private static int score = 0;//заработанные очки

        //Константы для задания количества обьектов разных типов на заставке
        private const int numOfPLanets = 2;
        private const int numOfBigStars = 7;
        private const int numOfStars = 20;
        private const int numOfSmallStars = 100;
        private const int numOfAsteroids = 20;

        //Игровые обьекты
        private static Bullet bullet;
        private static SpaceShip spaceShip;
        private static EnergyBox energyBox;

        //Свойства
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
        public static int Score => score;

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
            timer = new Timer { Interval = 100 };//задаём интервал для вызова события
            timer.Tick += Timer_Tick;//Создаём событие для таймера
            timer.Start();
            form.KeyDown += form_KeyDown; 
        }

        public static void form_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    bullet = new Bullet(spaceShip.Rect.Y);
                    break;
                case Keys.Up:
                case Keys.W:
                    spaceShip.MoveUp();
                    break;
                case Keys.Down:
                case Keys.S:
                    spaceShip.MoveDown();
                    break;
                default:
                    break;
            }
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

        public static void Load()
        {
            int length = numOfStars + numOfSmallStars + numOfPLanets + numOfBigStars + numOfAsteroids;
            gameObjects = new BaseVisualObject[length];
            List<BaseVisualObject> gameObjectsList = new List<BaseVisualObject>();
            for (int i = 0; i < numOfSmallStars; i++)
                gameObjectsList.Add(new SmallStar(
                    new Point(random.Next(0, Width), random.Next(0, Height)),
                    new Point(random.Next(1, 3), 0),
                    2));

            for (int i = 0; i < numOfStars; i++)
                gameObjectsList.Add(new Star(
                    new Point(random.Next(0, Width), random.Next(0, Height)),
                    new Point(random.Next(2, 4), 0),
                    5));

            for (int i = 0; i < numOfBigStars; i++)
                gameObjectsList.Add(new BigStar(
                    new Point(random.Next(0, Width), random.Next(0, Height)),
                    new Point(random.Next(3, 5), 0),
                    7));

            for (int i = 0; i < numOfPLanets; i++)
                gameObjectsList.Add(new Planet(
                    new Point(random.Next(0, Width), random.Next(0, Height)),
                    new Point(random.Next(4, 6), 0),
                    90));

            for (int i = 0; i < numOfAsteroids; i++)
                gameObjectsList.Add(new Asteroid(
                    new Point(random.Next(0, Width), random.Next(0, Height)),
                    new Point(random.Next(5, 7), random.Next(-4, 5)),
                    40));

            gameObjects = gameObjectsList.ToArray();
            energyBox = new EnergyBox(200);
            spaceShip = new SpaceShip(new Point(10, 400), new Point(5, 5), new Size(40, 20));
            spaceShip.ShipDestoyed += OnShipDestoyed;
        }

        private static void OnShipDestoyed(object sender, EventArgs e)
        {
            timer.Stop();
            SplashScreen.Initialize(new Form());
            SplashScreen.Draw();            
        }

        public static void Draw()
        {
            Graphics graphics = buffer.Graphics;
            graphics.Clear(Color.Black);
            foreach (BaseVisualObject gameObject in gameObjects)
                gameObject?.Draw(graphics);
            spaceShip.Draw(graphics);
            bullet?.Draw(graphics);
            energyBox?.Draw(graphics);
            graphics.DrawString("Shields: " + spaceShip.Energy, SystemFonts.DefaultFont, Brushes.Cyan, 0, 0);
            graphics.DrawString("Score: " + Score, SystemFonts.DefaultFont, Brushes.Cyan, 0, 10);
            buffer.Render();
        }

        public static void Update()
        {           
            foreach (BaseVisualObject gameObject in gameObjects)            
                gameObject?.Update();
            bullet?.Update();
            energyBox?.Update();
            if (energyBox != null && spaceShip.CheckCollision(energyBox))
                energyBox = null;

            for (int i = 0; i < gameObjects.Length; i++)
            {
                var obj = gameObjects[i];
                if (obj is ICollision collisionObj)
                {
                    if (bullet?.CheckCollision(collisionObj) == true)
                    {
                        bullet = null;
                        gameObjects[i] = null;
                        System.Media.SystemSounds.Asterisk.Play();
                        score++;
                    }
                    else
                        if (spaceShip.CheckCollision(collisionObj))
                        gameObjects[i] = null;
                }
            }
        }
    }
}
