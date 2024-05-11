using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows;

namespace EntityCL
{
    public abstract class EnemyAC : EntityAC
    {
        public string? Class { get; protected set; }
        public bool IsDead { get; protected set; }
        public EnemyAC() : base()
        {

        }
        public override void SetHitbox()
        {
            EntityHitBox = new Rect(Canvas.GetLeft(EntityRect), Canvas.GetTop(EntityRect), EntityRect.Width, EntityRect.Height);
        }
        public void Death(List<Rectangle> itemRemover)
        {
            if (HealthPoints <= 0)
            {
                itemRemover.Add(EntityRect);
                IsDead = true;
            }
        }
        public override async void TakeDamage(int atk)
        {
            base.TakeDamage(atk);

        }
    }
}
