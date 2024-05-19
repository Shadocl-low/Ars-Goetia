using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace EntityCL.Enemies
{
    public class SlimeC : EnemyAC
    {
        readonly Random random = new();
        public SlimeC(Player mainPlayer) : base(mainPlayer)
        {
            MAXHealthPoints = 1;
            HealthPoints = 1;
            AttackDamage = 0;
            EntityName = "Acid Slime";
            ImuneState = false;
            IsDead = false;
            SoulCoins = 1;
            Strength = 0;
            if (random.Next(-1, 1) == -1) 
            {
                RotateWay.ScaleX = -1;
            }
            else
            {
                RotateWay.ScaleX = 1;
            }

            EntityRect = new Rectangle();
            EntityRect.Tag = "slimeTag";
            EntityRect.Height = 30;
            EntityRect.Width = 35;
            ImageBrush SlimeImage = new ImageBrush();
            SlimeImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Slime/GreenSlime.png"));
            EntityRect.Fill = SlimeImage;
        }
        public override void SetEntityBehavior(List<Rectangle> itemRemover)
        {
            SetHitbox();
            Moving();

            Death(itemRemover);
            TakeDamageFrom();
        }
        public override void Moving()
        {
            if (RotateWay.ScaleX == 1)
            {
                if (Canvas.GetLeft(EntityRect) > 1500)
                {
                    WallHit();
                }
                Canvas.SetLeft(EntityRect, Canvas.GetLeft(EntityRect) + 1);
            }
            else
            {
                if (Canvas.GetLeft(EntityRect) < 5)
                {
                    WallHit();
                }
                Canvas.SetLeft(EntityRect, Canvas.GetLeft(EntityRect) - 1);
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
    }
}
