using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace EntityCL.Enemies
{
    public class SwordsmanC : EnemyAC
    {
        public override Rectangle EntityRect { get; protected set; }
        public override Rect EntityHitBox { get; protected set; }
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
        public override void TakeDamage(int atk)
        {
            HealthPoints -= atk;
        }
    }
}
