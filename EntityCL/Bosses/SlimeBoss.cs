using EntityCL.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Media.Animation;

namespace EntityCL.Bosses
{
    public class SlimeBoss : BossAC
    {
        public SlimeBoss(Player mainPlayer) : base(mainPlayer)
        {
            MAXHealthPoints = 20;
            HealthPoints = MAXHealthPoints;
            AttackDamage = 6;
            EntityName = "King Slime";
            ImuneState = false;
            IsDead = false;
            SoulCoins = 35;
            Strength = 65;

            EntityRect = new();
            EntityRect.Tag = "slimeTag";
            EntityRect.Height = 204;
            EntityRect.Width = 300;
            ImageBrush SlimeImage = new();
            SlimeImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Bosses/Slime/SlimeBoss.png"));

            EntityRect.Fill = SlimeImage;

            HealthBar.Maximum = MAXHealthPoints;

            AttackTimer.Interval = TimeSpan.FromSeconds(8);
            AttackTimer.Tick += AttackTick;
            AttackTimer.Start();
        }
        public override void SetEntityBehavior(List<Rectangle> itemRemover)
        {
            SetHitbox();
            Attack();

            Death(itemRemover);
            TakeDamageFrom();

            HealthBar.Value = HealthPoints;
        }
        public void AttackTick(object sender, EventArgs e)
        {
            Random rand = new();
            int randomAttack = rand.Next(0, 2);

            DoubleAnimationUsingKeyFrames startAttack = new();
            startAttack.KeyFrames.Add(new LinearDoubleKeyFrame(EntityRect.Height, KeyTime.FromPercent(0.0)));
            startAttack.KeyFrames.Add(new LinearDoubleKeyFrame(EntityRect.Height+100, KeyTime.FromPercent(0.3)));
            startAttack.SpeedRatio = 0.7;
            startAttack.AutoReverse = true;

            EntityRect.BeginAnimation(Canvas.HeightProperty, startAttack);

            if (randomAttack == 0)
            {
                DoubleAnimationUsingKeyFrames moving = new();
                moving.KeyFrames.Add(new LinearDoubleKeyFrame(Canvas.GetLeft(EntityRect), KeyTime.FromPercent(0.6)));
                moving.KeyFrames.Add(new LinearDoubleKeyFrame(100, KeyTime.FromPercent(1.0)));
                moving.SpeedRatio = 0.7;
                moving.AutoReverse = true;
                
                EntityRect.BeginAnimation(Canvas.LeftProperty, moving);
            }
            if (randomAttack == 1)
            {

            }
            IsDangerous = true;
        }
        
    }
}
