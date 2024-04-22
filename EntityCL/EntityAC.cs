using EntityCL.Interfaces;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows;

namespace EntityCL
{
    public abstract class EntityAC : IBurnable, IDamageble
    {
        public string? EntityName { get; protected set; }
        public int MAXHealthPoints { get; protected set; }
        public double HealthPoints { get; protected set; }
        public int AttackDamage { get; protected set; }
        public string State { get; protected set; }
        public abstract Rectangle EntityRect { get; protected set; }
        public abstract Rect EntityHitBox { get; protected set; }
        public EntityAC(string name, int maxhp, double hp, int atk)
        {
            EntityName = name;
            MAXHealthPoints = maxhp;
            HealthPoints = hp;
            AttackDamage = atk;
            State = "Normal";
        }
        public EntityAC() 
        {
            State = "Normal";
        }
        public abstract void Burning();
        public abstract void TakeDamage(int atk);
    }
}
