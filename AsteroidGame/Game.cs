using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
        private static int width;//ширина игровой области
        private static int heigth;//высота игровой области
        private static int score = 0;//заработанные очки

        //События
        public delegate void Message(string message);
        public static event Message Logging;

        //Количество обьектов разных типов в игре
        private const int numOfPLanets = 2;
        private const int numOfBigStars = 7;
        private const int numOfStars = 20;
        private const int numOfSmallStars = 100;

        private static int numOfAsteroids = 5;

        //Игровые обьекты
        private static List<Bullet> bullets;
        private static SpaceShip spaceShip;
        private static EnergyBox energyBox;
        private static List<Asteroid> asteroids;//Список астероидов
        private static BaseVisualObject[] backgroundObjects;//Массив обьектов для отрисовки

        //Свойства
        public static int Width
        {
            get => width;
            set
            {
                if (value > 1000 || value < 0)
                    throw new ArgumentOutOfRangeException("Ширина окна не может быть больше 1000px или 0px");
                else
                    width = value;
            }
        }
        public static int Height
        {
            get => heigth;
            set
            {
                if (value > 1000 || value < 0)
                    throw new ArgumentOutOfRangeException("Высота окна не может быть больше 1000px или 0px");
                else
                    heigth = value;
            }
        }

        public static int Score => score;
        public static bool TimerEnable
        {
            get => timer.Enabled;
            set { if (value) timer.Start(); else timer.Stop(); }
        }

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
            timer = new Timer { Interval = 100 };//задаём интервал для вызова события
            timer.Tick += Timer_Tick;//Добавляем обработчик к событию таймера
            timer.Start();
            form.KeyDown += form_KeyDown;
        }

        private static void form_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                case Keys.ControlKey:
                    Bullet disableBullet = bullets.FirstOrDefault(b => !b.IsEnabled);
                    if (Bullet.StartPositionLeft)
                    {
                        e.SuppressKeyPress = true;
                        Bullet.StartPositionLeft = false;
                        if (disableBullet != null)
                            disableBullet.ResetPosition(new Point(spaceShip.Rect.X + spaceShip.Size.Width / 2, spaceShip.Rect.Y));
                        else
                            bullets.Add(new Bullet(new Point(spaceShip.Rect.X + spaceShip.Size.Width / 2, spaceShip.Rect.Y)));
                    }
                    else
                    {
                        e.SuppressKeyPress = true;
                        Bullet.StartPositionLeft = true;
                        if (disableBullet != null)
                            disableBullet.ResetPosition(new Point(spaceShip.Rect.X + spaceShip.Size.Width / 2, spaceShip.Rect.Y + spaceShip.Size.Height));
                        else
                            bullets.Add(new Bullet(new Point(spaceShip.Rect.X + spaceShip.Size.Width / 2, spaceShip.Rect.Y + spaceShip.Size.Height)));
                    }
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

        private static void Load()
        {
            int length = numOfStars + numOfSmallStars + numOfPLanets + numOfBigStars;
            backgroundObjects = new BaseVisualObject[length];
            asteroids = new List<Asteroid>(numOfAsteroids);
            asteroids.Load(numOfAsteroids);
            List<BaseVisualObject> gameObjectsList = new List<BaseVisualObject>(length);

            #region заполняем gameObjectsList
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
            #endregion

            backgroundObjects = gameObjectsList.ToArray();
            bullets = new List<Bullet>(50);
            energyBox = new EnergyBox(200) { IsEnabled = false };
            spaceShip = new SpaceShip(new Point(10, 400), new Point(5, 5), new Size(60, 30));
            spaceShip.ShipDestoyed += OnShipDestoyed;
            Logging?.Invoke("Game objects loaded");
        }

        private static void OnShipDestoyed(object sender, EventArgs e)
        {
            timer.Stop();
            Logging?.Invoke($"Game Over! Score recived: {score}");
        }

        public static void Draw()
        {
            Graphics graphics = buffer.Graphics;
            graphics.Clear(Color.Black);

            foreach (var obj in backgroundObjects.Where(o => o.IsEnabled))
                obj.Draw(graphics);

            foreach (var asteroid in asteroids.Where(a => a.IsEnabled))
                asteroid.Draw(graphics);

            foreach (var bullet in bullets.Where(b => b.IsEnabled))
                bullet.Draw(graphics);

            spaceShip.Draw(graphics);
            if (energyBox.IsEnabled) energyBox.Draw(graphics);
            graphics.DrawString("Shields: " + spaceShip.Energy, SystemFonts.DefaultFont, Brushes.Cyan, 0, 0);
            graphics.DrawString("Score: " + Score, SystemFonts.DefaultFont, Brushes.Cyan, 0, 10);
            buffer.Render();
        }

        public static void Update()
        {
            foreach (var obj in backgroundObjects.Where(o => o.IsEnabled))
                obj.Update();

            foreach (var asteroid in asteroids.Where(a => a.IsEnabled))
                asteroid.Update();

            foreach (var bullet in bullets.Where(b => b.IsEnabled))
                bullet.Update();

            energyBox.Update();//Обновление положения аптечки
            if (energyBox.IsEnabled && spaceShip.CheckCollision(energyBox)) energyBox.IsEnabled = false;

            foreach (Asteroid asteroid in asteroids.Where(a => a.IsEnabled))
            {
                foreach (Bullet bullet in bullets.Where(b => b.IsEnabled))
                {
                    if (bullet.CheckCollision(asteroid))
                    {
                        asteroid.Durability--;//При столкновении пули с астероидом уменьшаем его прочность
                        if (asteroid.Durability <= 0) asteroid.IsEnabled = false;//Если прочность астероида падает до 0 выключаем его
                        bullet.IsEnabled = false;
                        score++;
                        if (!energyBox.IsEnabled && score % 50 == 0) energyBox.Drop(asteroid);
                        break;
                    }
                }
                if (spaceShip.CheckCollision(asteroid))
                {
                    asteroid.IsEnabled = false;
                }
            }
            foreach (Bullet bullet in bullets.Where(b => b.Rect.X > width && b.IsEnabled))
                bullet.IsEnabled = false;

            if (asteroids.NumOfActiveAsteroids() < numOfAsteroids)
            {
                numOfAsteroids++;
                asteroids.ActivateOrAddAsteriod(numOfAsteroids);
                if (numOfAsteroids > 40)//Если число астероидов на экране больше 40, сбрасываем максимальное число астероидов на экране и увеличивам мощьность астероидов
                {
                    numOfAsteroids = 15;
                    Asteroid.Power += 3;
                }
            }
        }
    }
}
