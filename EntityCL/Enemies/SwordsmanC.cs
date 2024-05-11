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
        public SwordsmanC() : base()
        {
            MAXHealthPoints = 12;
            HealthPoints = 12;
            AttackDamage = 1;
            EntityName = "Royal Guard";
            Class = "Knight";
        }
        public override void Burning()
        {
            State = "Burning";
            HealthPoints -= MAXHealthPoints * 0.03 / 16;
        }
        public override void SetHitbox()
        {
            EntityHitBox = new Rect(Canvas.GetLeft(EntityRect), Canvas.GetTop(EntityRect), EntityRect.Width, EntityRect.Height);
        }
    }
}
