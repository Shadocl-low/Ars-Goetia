using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Shapes;

namespace EntityCL.Enemies
{
    public class SlimeC : EnemyAC
    {
        public SlimeC() 
        {
            MAXHealthPoints = 1;
            HealthPoints = 1;
            AttackDamage = 0;
            EntityName = "Acid Slime";
            ImuneState = false;
            IsDead = false;

            EntityRect = new Rectangle();
            EntityRect.Tag = "slimeTag";
            EntityRect.Height = 30;
            EntityRect.Width = 35;
            ImageBrush SlimeImage = new ImageBrush();
            SlimeImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Slime/GreenSlime.png"));
            EntityRect.Fill = SlimeImage;
        }
        public override void SetEntityBehavior(List<Rectangle> itemRemover, Player MainPlayer)
        {
            SetHitbox();

            Death(itemRemover);
            TakeDamageFrom(MainPlayer);
        }
    }
}
