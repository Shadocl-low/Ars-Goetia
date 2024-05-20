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
        public int SoulCoins { get; protected set; }
        public int Strength { get; protected set; }
        public Player MainPlayer { get; protected set; }
        public EnemyAC(Player mainPlayer) : base()
        {
            MainPlayer = mainPlayer;
            IsDead = false;
        }
        public override void SetHitbox()
        {
            EntityHitBox = new Rect(Canvas.GetLeft(EntityRect), Canvas.GetTop(EntityRect), EntityRect.Width, EntityRect.Height);
        }
        public void Death(List<Rectangle> itemRemover)
        {
            if (HealthPoints <= 0 && !IsDead)
            {
                itemRemover.Add(EntityRect);
                IsDead = true;
                MainPlayer.SetSoulCoins(this);
                EntityHitBox = new();
            }
        }
        public void TakeDamageFrom()
        {
            if (EntityHitBox.IntersectsWith(MainPlayer.AttackHitBox))
            {
                MainPlayer.DeleteAttackHitbox();
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
        public abstract void SetEntityBehavior(List<Rectangle> itemRemover);
        public abstract void Moving();
        public abstract void WallHit();
        public override void Attack()
        {
            if (!IsDead)
            {
                if (EntityHitBox.IntersectsWith(MainPlayer.EntityHitBox))
                {
                    MainPlayer.TakeDamageFrom(this);
                }
            }
        }
    }
}
