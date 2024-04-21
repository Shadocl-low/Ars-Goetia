using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCL.Enemies
{
    public class SwordsmanC : EnemyAC
    {
        public SwordsmanC() : base()
        {
            MAXHealthPoints = 12;
            HealthPoints = 12;
            AttackGamage = 1;
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
