﻿using System;
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

        public static int Width { get; set; }
        public static int Height { get; set; }

        public static void Initialize(Form form)
        {
            Width = form.Width;
            Height = form.Height;

            contex = BufferedGraphicsManager.Current;
            Graphics graphics = form.CreateGraphics();
            buffer = contex.Allocate(graphics, new Rectangle(0,0, Width, Height));
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

            for (int i = 0; i < gameObjects.Length; i++)
                gameObjects[i] = new BaseVisualObject(new Point(600, i * 20), new Point(15 - i, 15 - i), new Size(20, 20));           
        }
        public static void Update()
        {
            foreach (BaseVisualObject gameObject in gameObjects)            
                gameObject.Update();            
        }
    }
}
