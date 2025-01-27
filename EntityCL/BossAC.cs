using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace EntityCL
{
    public abstract class BossAC : EnemyAC
    {
        public ProgressBar HealthBar { get; protected set; }
        public DispatcherTimer AttackTimer { get; protected set; }
        public BossAC(Player mainPlayer) : base(mainPlayer) 
        {
            LinearGradientBrush BossBarBrush = new();
            BossBarBrush.StartPoint = new Point(0, 0);
            BossBarBrush.EndPoint = new Point(1, 1);
            BossBarBrush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#C40C0C"), 0.00));
            BossBarBrush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF6500"), 0.25));
            BossBarBrush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF8A08"), 0.50));
            BossBarBrush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FFC100"), 0.75));

            HealthBar = new();
            HealthBar.Foreground = BossBarBrush;
            HealthBar.Width = 952;
            HealthBar.Height = 25;

            AttackTimer = new();
        }
        public override void WallHit() { }
        public override void Moving() { }
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
        public void StopTimer()
        {
            AttackTimer.Stop();
        }
    }
}
