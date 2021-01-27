using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AsteroidGame
{
    internal interface ICollision
    {
        public Rectangle Rect { get; }

        bool CheckCollision(ICollision obj);
    }
}
