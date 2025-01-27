using EntityCL.Interfaces;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

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
        public DispatcherTimer ImuneTimer { get; protected set; }
        public EntityAC(string name, int maxhp, int hp, int atk)
        {
            EntityName = name;
            MAXHealthPoints = maxhp;
            HealthPoints = hp;
            AttackDamage = atk;
            State = "Normal";
            RotateWay = new ScaleTransform();
            RotateWay.CenterX = 25;

            ImuneTimer = new DispatcherTimer();
            ImuneTimer.Interval = TimeSpan.FromSeconds(1.0);
            ImuneTimer.Tick += ImuneTick;
        }
        public EntityAC() 
        {
            State = "Normal";
            RotateWay = new ScaleTransform();
            RotateWay.CenterX = 25;
            EntityRect = new Rectangle();

            ImuneTimer = new DispatcherTimer();
            ImuneTimer.Interval = TimeSpan.FromSeconds(0.5);
            ImuneTimer.Tick += ImuneTick; ;
        }
        public void Burning()
        {
            State = "Burning";
            HealthPoints--;
        }
        public abstract void SetHitbox();
        public virtual void TakeDamageFrom(EntityAC Entity)
        {
            if (!ImuneState)
            {
                ImuneState = true;
                ImuneTimer.Start();
                HealthPoints -= Entity.AttackDamage;
            }
        }
        public abstract void Attack();
        public void ImuneTick(object sender, EventArgs e)
        {
            ImuneState = false;
            ImuneTimer.Stop();
        }
    }
}
