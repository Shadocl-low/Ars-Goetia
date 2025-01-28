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
        private List<EnemyAC> Enemies;
        private Canvas GameScreen;
        private EntityParam Parameters;
        private readonly Random random = new();
        public SlimeBoss(Player mainPlayer, Canvas gameField, List<EnemyAC> enemies) : base(mainPlayer)
        {
            Parameters = new EntityParam(20, 6, 65, 35, 300, 204);

            EntityName = "King Slime";
            ImuneState = false;
            IsDead = false;

            GameScreen = gameField;
            Enemies = enemies;

            SetupEntityParameters();
            SetupEntityAppearance();
            InitializeHealthBar();
            InitializeAttackTimer();
        }
        private void SetupEntityParameters()
        {
            MAXHealthPoints = Parameters.DefaultHealth;
            HealthPoints = MAXHealthPoints;
            AttackDamage = Parameters.DefaultAttackDamage;
            SoulCoins = Parameters.DefaultSoulCoins;
            Strength = Parameters.DefaultStrength;
        }
        private void SetupEntityAppearance()
        {
            EntityRect = new Rectangle
            {
                Tag = "slimeTag",
                Height = Parameters.EntityHeight,
                Width = Parameters.EntityWidth,
                Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Bosses/Slime/SlimeBoss.png"))
                }
            };
        }
        private void InitializeHealthBar()
        {
            HealthBar.Maximum = MAXHealthPoints;
            Canvas.SetLeft(HealthBar, 294);
            Canvas.SetTop(HealthBar, 16);
            GameScreen.Children.Add(HealthBar);
        }

        private void InitializeAttackTimer()
        {
            AttackTimer.Interval = TimeSpan.FromSeconds(4);
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
            if (IsDead) return;

            var randomAttack = random.Next(3);
            PerformAttack(randomAttack);
        }

        private void PerformAttack(int attackType)
        {
            PlayAttackAnimation();

            switch (attackType)
            {
                case 0:
                    PerformHorizontalAttack(50);
                    break;
                case 1:
                    PerformHorizontalAttack(1250);
                    break;
                case 2:
                    SummonSlimes();
                    break;
            }
        }

        private void PlayAttackAnimation()
        {
            var attackAnimation = new DoubleAnimationUsingKeyFrames
            {
                SpeedRatio = 0.7,
                AutoReverse = true
            };
            attackAnimation.KeyFrames.Add(new LinearDoubleKeyFrame(EntityRect.Height, KeyTime.FromPercent(0.0)));
            attackAnimation.KeyFrames.Add(new LinearDoubleKeyFrame(EntityRect.Height + 100, KeyTime.FromPercent(0.3)));

            EntityRect.BeginAnimation(Canvas.HeightProperty, attackAnimation);
        }

        private void PerformHorizontalAttack(double targetPosition)
        {
            var horizontalAnimation = new DoubleAnimationUsingKeyFrames
            {
                SpeedRatio = 0.7,
                AutoReverse = true
            };
            horizontalAnimation.KeyFrames.Add(new LinearDoubleKeyFrame(Canvas.GetLeft(EntityRect), KeyTime.FromPercent(0.6)));
            horizontalAnimation.KeyFrames.Add(new LinearDoubleKeyFrame(targetPosition, KeyTime.FromPercent(1.0)));

            EntityRect.BeginAnimation(Canvas.LeftProperty, horizontalAnimation);
        }

        private void SummonSlimes()
        {
            for (int i = 0; i < 2; i++)
            {
                var slime = new SlimeC(MainPlayer, 70, 60, 3);
                var offset = i == 0 ? -random.Next(100, 250) : Parameters.EntityHeight + random.Next(150, 250);

                Canvas.SetLeft(slime.EntityRect, Canvas.GetLeft(EntityRect) + EntityRect.Width / 2);
                Canvas.SetTop(slime.EntityRect, Canvas.GetTop(EntityRect) + offset);

                GameScreen.Children.Add(slime.EntityRect);
                Enemies.Add(slime);
            }
        }
        public override void Death(List<Rectangle> itemRemover)
        {
            base.Death(itemRemover);
            if (IsDead)
            {
                foreach (var slime in Enemies)
                {
                    slime.SetDeath();
                }
            }
        }
    }
}
