using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace EntityCL.Enemies
{
    public class SlimeC : EnemyAC
    {
        readonly Random random = new();
        private int Speed { get; set; }
        public SlimeC(Player mainPlayer) : base(mainPlayer)
        {
            MAXHealthPoints = 1;
            HealthPoints = MAXHealthPoints;
            AttackDamage = 1;
            EntityName = "Acid Slime";
            SoulCoins = 1;
            Strength = 0;
            Speed = 1;
            if (random.Next(-1, 1) == -1)
            {
                RotateWay.ScaleX = -1;
            }
            else
            {
                RotateWay.ScaleX = 1;
            }

            EntityRect.Tag = "slimeTag";
            EntityRect.Height = 30;
            EntityRect.Width = 35;
            ImageBrush SlimeImage = new ImageBrush();
            SlimeImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Slime/GreenSlime.png"));
            EntityRect.Fill = SlimeImage;
        }
        public SlimeC(Player mainPlayer, int width, int height, int speed) : base(mainPlayer)
        {
            MAXHealthPoints = 1;
            HealthPoints = MAXHealthPoints;
            AttackDamage = 1;
            EntityName = "Acid Slime";
            SoulCoins = 1;
            Strength = 0;
            Speed = speed;
            if (random.Next(-1, 1) == -1)
            {
                RotateWay.ScaleX = -1;
            }
            else
            {
                RotateWay.ScaleX = 1;
            }

            EntityRect.Tag = "slimeTag";
            EntityRect.Height = height;
            EntityRect.Width = width;
            ImageBrush Image = new ImageBrush();
            Image.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Slime/GreenSlime.png"));
            EntityRect.Fill = Image;
        }
        public override void SetEntityBehavior(List<Rectangle> itemRemover)
        {
            SetHitbox();
            Moving();
            Attack();
            Death(itemRemover);

            TakeDamageFrom();
        }
        public override void Moving()
        {
            if (!IsDead)
            {
                int direction = RotateWay.ScaleX == 1 ? 1 : -1;

                double currentPosition = Canvas.GetLeft(EntityRect);
                double maxPosition = 1540 - EntityRect.Width;
                double minPosition = 5;

                if ((direction == 1 && currentPosition > maxPosition) || (direction == -1 && currentPosition < minPosition))
                {
                    WallHit();
                }

                Canvas.SetLeft(EntityRect, currentPosition + direction * Speed);
            }
        }
        public override void WallHit()
        {
            if (RotateWay.ScaleX == 1)
            {
                Canvas.SetLeft(EntityRect, Canvas.GetLeft(EntityRect) - 5);
            }
            else
            {
                Canvas.SetLeft(EntityRect, Canvas.GetLeft(EntityRect) + 5);
            }
            RotateWay.ScaleX *= -1;
        }
        public override void Attack()
        {
            if (!IsDead)
            {
                if (EntityHitBox.IntersectsWith(MainPlayer.EntityHitBox))
                {
                    HealthPoints--;

                    MainPlayer.TakeDamageFrom(this);
                }
            }
        }
    }
}
