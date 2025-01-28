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
        private readonly Random random = new();
        private EntityParam Params;
        public SlimeBoss(Player mainPlayer, Canvas gameField, List<EnemyAC> enemies) : base(mainPlayer)
        {
            Params = new EntityParam(20, 6, 65, 35, 300, 204);
            
            EntityName = "King Slime";
            ImuneState = false;
            IsDead = false;

            GameScreen = gameField;
            Enemies = enemies;

            SetupEntityParams();
            SetupEntityAppearance();
            InitializeHealthBar();
            InitializeAttackTimer();
        }
        private void SetupEntityParams()
        {
            MAXHealthPoints = Params.DefaultHealth;
            HealthPoints = Params.DefaultHealth;
            AttackDamage = Params.DefaultAttackDamage;
            SoulCoins = Params.DefaultSoulCoins;
            Strength = Params.DefaultStrength;
        }
        private void SetupEntityAppearance()
        {
            EntityRect = new Rectangle
            {
                Tag = "slimeTag",
                Height = Params.EntityHeight,
                Width = Params.EntityWidth,
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
            if (!IsDead)
            {
                Random rand = new();
                int randomAttack = rand.Next(0, 3);

                DoubleAnimationUsingKeyFrames startAttack = new();
                startAttack.KeyFrames.Add(new LinearDoubleKeyFrame(EntityRect.Height, KeyTime.FromPercent(0.0)));
                startAttack.KeyFrames.Add(new LinearDoubleKeyFrame(EntityRect.Height + 100, KeyTime.FromPercent(0.3)));
                startAttack.SpeedRatio = 0.7;
                startAttack.AutoReverse = true;

                EntityRect.BeginAnimation(Canvas.HeightProperty, startAttack);

                if (randomAttack == 0)
                {
                    DoubleAnimationUsingKeyFrames moving = new();
                    moving.KeyFrames.Add(new LinearDoubleKeyFrame(Canvas.GetLeft(EntityRect), KeyTime.FromPercent(0.6)));
                    moving.KeyFrames.Add(new LinearDoubleKeyFrame(50, KeyTime.FromPercent(1.0)));
                    moving.SpeedRatio = 0.7;
                    moving.AutoReverse = true;

                    EntityRect.BeginAnimation(Canvas.LeftProperty, moving);
                }
                if (randomAttack == 1)
                {
                    DoubleAnimationUsingKeyFrames moving = new();
                    moving.KeyFrames.Add(new LinearDoubleKeyFrame(Canvas.GetLeft(EntityRect), KeyTime.FromPercent(0.6)));
                    moving.KeyFrames.Add(new LinearDoubleKeyFrame(1250, KeyTime.FromPercent(1.0)));
                    moving.SpeedRatio = 0.6;
                    moving.AutoReverse = true;

                    EntityRect.BeginAnimation(Canvas.LeftProperty, moving);
                }
                if (randomAttack == 2)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        var slime = new SlimeC(MainPlayer, 70, 60, 3);
                        Canvas.SetLeft(slime.EntityRect, Canvas.GetLeft(EntityRect) + EntityRect.Width / 2);
                        if (i == 0) Canvas.SetTop(slime.EntityRect, Canvas.GetTop(EntityRect) - new Random().Next(100, 250));
                        else Canvas.SetTop(slime.EntityRect, Canvas.GetTop(EntityRect) + EntityRect.Height + new Random().Next(150, 250));
                        GameScreen.Children.Add(slime.EntityRect);
                        Enemies.Add(slime);
                    }
                }
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
