using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObjects
{
    static class AsteroidsListExtencion
    {
        public static int NumOfActiveAsteroids(this List<Asteroid> asteroids) => asteroids.Where(a => a.IsEnabled == true).Count();        
        
        public static void Load(this List<Asteroid> asteroids, int count)
        {            
            for (int i = 0; i < count; i++)
                asteroids.Add(new Asteroid());
        }
        
        public static void ActivateOrAddAsteriod(this List<Asteroid> asteroids, int maxAsteroids)
        {
            int num = NumOfActiveAsteroids(asteroids);
            if(num - maxAsteroids < 0)
            {
                while(num < maxAsteroids)
                {
                    foreach (Asteroid asteroid in asteroids.Where(a => a.IsEnabled == false))
                    {
                        asteroid.ResetPosition();
                        num++;
                        if (num >= maxAsteroids)
                            break;
                    }                           
                    
                    if (num < maxAsteroids)
                    {
                        asteroids.Add(new Asteroid());
                        num++;
                    }
                }
            }
        }
    }
}
