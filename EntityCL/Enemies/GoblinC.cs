using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace EntityCL.Enemies
{
    public class GoblinC : EnemyAC
    {
        private int Speed { get; set; }
        public GoblinC(Player mainPlayer) : base(mainPlayer)
        {
            MAXHealthPoints = 2;
            HealthPoints = MAXHealthPoints;
            AttackDamage = 2;
            EntityName = "Burly Goblin";
            SoulCoins = 3;
            Strength = 20;
            Speed = 2;

            EntityRect.Tag = "goblinTag";
            EntityRect.Height = 50;
            EntityRect.Width = 50;
            ImageBrush Image = new ImageBrush();
            Image.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Goblin/Goblin.png"));
            EntityRect.Fill = Image;
        }

        public override void SetEntityBehavior(List<Rectangle> itemRemover)
        {
            SetHitbox();
            LookToPlayer(MainPlayer.EntityRect);
            Moving();
            Attack();

            Death(itemRemover);
            TakeDamageFrom();
        }
        public override void Moving()
        {
            if (Math.Abs(Canvas.GetLeft(EntityRect) - Canvas.GetLeft(MainPlayer.EntityRect)) < 350 && Math.Abs(Canvas.GetTop(EntityRect) - Canvas.GetTop(MainPlayer.EntityRect)) < 350)
            {
                base.Moving();

                Vector2D direction = CalculateVector.Normalize(EntityRect, Canvas.GetLeft(MainPlayer.EntityRect), Canvas.GetTop(MainPlayer.EntityRect));

                Canvas.SetLeft(EntityRect, Canvas.GetLeft(EntityRect) + (direction.X * Speed));
                Canvas.SetTop(EntityRect, Canvas.GetTop(EntityRect) + (direction.Y * Speed));
            }
        }
        public override void WallHit()
        {
            if (RotateWay.ScaleX == 1)
            {
                Canvas.SetLeft(EntityRect, Canvas.GetLeft(EntityRect) - Speed);
            }
            if (RotateWay.ScaleX == -1)
            {
                Canvas.SetLeft(EntityRect, Canvas.GetLeft(EntityRect) + Speed);
            }
        }
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
