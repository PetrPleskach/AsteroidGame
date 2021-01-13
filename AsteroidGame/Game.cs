using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace AsteroidGame
{
    static class Game
    {
        private static BufferedGraphicsContext contex;
        private static BufferedGraphics buffer;
        private static BaseVisualObject[] gameObjects;

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
            const int visualObjectsCount = 30;
            gameObjects = new BaseVisualObject[visualObjectsCount];

            for (int i = 0; i < gameObjects.Length/2; i++)
                gameObjects[i] = new Planet(new Point(600, i * 20), new Point(15 - i, 20 - i), new Size(50, 50));
            for (int i = gameObjects.Length/2; i < gameObjects.Length; i++)            
                gameObjects[i] = new SmallStar(new Point(600, i * 20), new Point(i, 0), new Size(2, 2));            
        }
        public static void Update()
        {
            foreach (BaseVisualObject gameObject in gameObjects)            
                gameObject.Update();     
        }
    }
}
