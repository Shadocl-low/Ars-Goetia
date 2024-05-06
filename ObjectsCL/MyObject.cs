using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsCL
{
    public abstract class MyObject
    {
        public int HealthPoints { get; protected set; }
        public int Width { get; protected set; }
        public int Height { get; protected set; }
        public MyObject(int hp, int width, int height)
        {
            HealthPoints = hp;
            Width = width;
            Height = height;
        }
        public MyObject() { }
        public abstract void TakeDamage(int atk);
    }
}
