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
        public override async void TakeDamageFrom(EntityAC MainPlayer)
        {
            if (EntityHitBox.IntersectsWith((MainPlayer as Player).AttackHitBox))
            {
                (MainPlayer as Player).DeleteAttackHitbox();
                base.TakeDamageFrom(MainPlayer);
            }
        }
        public void LookToPlayer(Rectangle Player)
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
        public abstract void SetEntityBehavior(List<Rectangle> itemRemover, Player MainPlayer);
    }
}
