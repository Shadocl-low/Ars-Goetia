using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace EntityCL.Enemies
{
    public class SwordsmanC : EnemyAC
    {
        public SwordsmanC(Player mainPlayer) : base(mainPlayer)
        {
            MAXHealthPoints = 12;
            HealthPoints = 12;
            AttackDamage = 1;
            EntityName = "Royal Guard";
        }
        public override void SetHitbox()
        {
            EntityHitBox = new Rect(Canvas.GetLeft(EntityRect), Canvas.GetTop(EntityRect), EntityRect.Width, EntityRect.Height);
        }
        public override void SetEntityBehavior(List<Rectangle> itemRemover)
        {
            throw new NotImplementedException();
        }
    }
}
