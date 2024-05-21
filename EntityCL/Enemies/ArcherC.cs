using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace EntityCL.Enemies
{
    public class ArcherC : EnemyAC
    {
        public Arrow? arrow { get; set; }
        public ArcherC(Player mainPlayer) : base(mainPlayer)
        {
            MAXHealthPoints = 5;
            HealthPoints = MAXHealthPoints;
            AttackDamage = 1;
            EntityName = "Old Archer";
            ImuneState = false;
            IsDead = false;
            SoulCoins = 15;
            Strength = 15;

            EntityRect.Tag = "archerTag";
            EntityRect.Height = 50;
            EntityRect.Width = 50;
            ImageBrush ArcherImage = new ImageBrush();
            ArcherImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Archer/ArcherEnemy.png"));
            EntityRect.Fill = ArcherImage;
        }
        public void CreateArrow(Canvas GameScreen, Player MainPlayer)
        {
            if (!IsDead) arrow = new Arrow(this, GameScreen, MainPlayer);
        }
        public override void SetEntityBehavior(List<Rectangle> itemRemover)
        {
            SetHitbox();
            LookToPlayer(MainPlayer.EntityRect);
            Moving();
            arrow?.SetArrowHitbox();

            Death(itemRemover);
            TakeDamageFrom();

            if (arrow != null)
            {
                arrow.Flying(arrow.TargetAimX, arrow.TargetAimY, itemRemover);
                arrow.WallHit(itemRemover);
            }
        }
        public override void Moving()
        {
            if (CanMove && Math.Abs(Canvas.GetLeft(EntityRect) - Canvas.GetLeft(MainPlayer.EntityRect)) < 100 && Math.Abs(Canvas.GetTop(EntityRect) - Canvas.GetTop(MainPlayer.EntityRect)) < 100)
            {
                base.Moving();

                if (RotateWay.ScaleX == 1) Canvas.SetLeft(EntityRect, Canvas.GetLeft(EntityRect) - 1);
                if (RotateWay.ScaleX == -1) Canvas.SetLeft(EntityRect, Canvas.GetLeft(EntityRect) + 1);

                if (Canvas.GetTop(EntityRect) > Canvas.GetTop(MainPlayer.EntityRect) + MainPlayer.EntityRect.Height)
                {
                    Canvas.SetTop(EntityRect, Canvas.GetTop(EntityRect) + 1);
                }
                if (Canvas.GetTop(EntityRect) < Canvas.GetTop(MainPlayer.EntityRect) - MainPlayer.EntityRect.Height)
                {
                    Canvas.SetTop(EntityRect, Canvas.GetTop(EntityRect) - 1);
                }
            }
        }
        public override void WallHit()
        {
            CanMove = false;
        }
    }
}
