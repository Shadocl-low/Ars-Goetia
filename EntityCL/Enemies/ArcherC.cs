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
        public ArcherC() : base()
        {
            MAXHealthPoints = 5;
            HealthPoints = 5;
            AttackDamage = 1;
            EntityName = "Old Archer";
            ImuneState = false;
            IsDead = false;

            EntityRect = new Rectangle();
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
        public override void SetEntityBehavior(List<Rectangle> itemRemover, Player MainPlayer)
        {
            SetHitbox();
            LookToPlayer(MainPlayer.EntityRect);

            Death(itemRemover); 
            TakeDamageFrom(MainPlayer);

            if (arrow != null)
            {
                arrow.Flying(arrow.TargetAimX, arrow.TargetAimY, itemRemover);
                arrow.WallHit(itemRemover);
            }
        }
    }
}
