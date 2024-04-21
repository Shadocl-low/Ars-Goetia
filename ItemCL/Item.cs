using EntityCL.Interfaces;
using System.Drawing;

namespace ItemCL
{
    public abstract class Item : IDamageble
    {
        public int HealthPoints { get; protected set; }
        public int Width { get; protected set; }
        public int Height { get; protected set; }
        public Item(int hp, int width, int height)
        {
            HealthPoints = hp;
            Width = width;
            Height = height;
        }
        public Item() { }
        public abstract void TakeDamage(int atk);
    }
}
