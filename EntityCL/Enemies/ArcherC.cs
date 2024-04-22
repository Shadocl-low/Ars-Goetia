using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows;

namespace EntityCL.Enemies
{
    public class ArcherC : EnemyAC
    {
        public override Rectangle EntityRect { get; protected set; }
        public override Rect EntityHitBox { get; protected set; }
        public ArcherC() : base()
        {
            MAXHealthPoints = 10;
            HealthPoints = 10;
            AttackDamage = 1;
            EntityName = "Old Archer";
            Class = "Archer";

            EntityRect = new Rectangle();
            EntityRect.Height = 50;
            EntityRect.Width = 50;
            ImageBrush ArcherImage = new ImageBrush();
            ArcherImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/ArcherEnemy.png"));
            EntityRect.Fill = ArcherImage;
            ScaleTransform ArcherScaleTransform = new ScaleTransform();
            ArcherScaleTransform.ScaleX = -1;
            ArcherScaleTransform.CenterX = 0.5;
            EntityRect.RenderTransform = ArcherScaleTransform;
        }
        public override void Burning()
        {
            State = "Burning";
            HealthPoints -= MAXHealthPoints * 0.03 / 16;
        }
        public override void TakeDamage(int atk)
        {
            HealthPoints -= atk;
        }
    }
}
