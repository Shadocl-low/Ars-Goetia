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
        public int HealthPoints { get; protected set; }
        public int AttackDamage { get; protected set; }
        public string State { get; protected set; }
        public Rectangle? EntityRect { get; protected set; }
        public Rect EntityHitBox { get; protected set; }
        public bool ImuneState { get; protected set; }
        public ScaleTransform RotateWay { get; protected set; }
        public EntityAC(string name, int maxhp, int hp, int atk)
        {
            EntityName = name;
            MAXHealthPoints = maxhp;
            HealthPoints = hp;
            AttackDamage = atk;
            State = "Normal";
            RotateWay = new ScaleTransform();
            RotateWay.CenterX = 25;
        }
        public EntityAC() 
        {
            State = "Normal";
            RotateWay = new ScaleTransform();
            RotateWay.CenterX = 25;
        }
        public void Burning()
        {
            State = "Burning";
            HealthPoints--;
        }
        public abstract void SetHitbox();
        public virtual async void TakeDamageFrom(EntityAC Entity)
        {
            if (!ImuneState)
            {
                HealthPoints -= Entity.AttackDamage;
                ImuneState = true;
                await Task.Delay(500);
            }
            ImuneState = false;
        }
    }
}
