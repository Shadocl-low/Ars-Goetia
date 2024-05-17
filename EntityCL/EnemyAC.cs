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
using System.ComponentModel;

namespace EntityCL
{
    public abstract class EnemyAC : EntityAC
    {
        public bool IsDead { get; protected set; }
        public ScaleTransform RotateWay { get; protected set; }
        public EnemyAC() : base()
        {
            RotateWay = new ScaleTransform();
            RotateWay.CenterX = 25;
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
        public void RotateRect(Rectangle Player)
        {

            if (Canvas.GetLeft(Player) > Canvas.GetLeft(EntityRect))
            {
                RotateWay.ScaleX = (1);
            }
            else
            {
                RotateWay.ScaleX = (-1);
            }
            EntityRect.RenderTransform = RotateWay;

        }
    }
}
