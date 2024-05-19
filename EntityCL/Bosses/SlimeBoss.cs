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
    public class SlimeBoss : SlimeC
    {
        public ProgressBar HealthBar { get; protected set; }
        public DispatcherTimer AttackTimer { get; protected set; }
        private bool IsDangerous { get; set; }
        public SlimeBoss(Player mainPlayer) : base(mainPlayer)
        {
            MAXHealthPoints = 20;
            HealthPoints = 20;
            AttackDamage = 2;
            EntityName = "King Slime";
            ImuneState = false;
            IsDead = false;
            IsDangerous = true;
            SoulCoins = 25;
            Strength = 50;

            EntityRect = new();
            EntityRect.Tag = "slimeTag";
            EntityRect.Height = 204;
            EntityRect.Width = 300;
            ImageBrush SlimeImage = new();
            SlimeImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Bosses/Slime/SlimeBoss.png"));

            EntityRect.Fill = SlimeImage;

            LinearGradientBrush BossBarBrush = new();
            BossBarBrush.StartPoint = new Point(0, 0);
            BossBarBrush.EndPoint = new Point(1, 1);
            BossBarBrush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#C40C0C"), 0.00));
            BossBarBrush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF6500"), 0.25));
            BossBarBrush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF8A08"), 0.50));
            BossBarBrush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FFC100"), 0.75));

            HealthBar = new()
            {
                Value = HealthPoints,
                Maximum = MAXHealthPoints,
                Width = 952,
                Height = 25,
                Foreground = BossBarBrush
            };

            AttackTimer = new();
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
        public override void Attack()
        {
            if (!IsDead && IsDangerous)
            {
                if (EntityHitBox.IntersectsWith(MainPlayer.EntityHitBox))
                {
                    IsDangerous = false;
                    MainPlayer.TakeDamageFrom(this);
                }
            }
        }
    }
}
