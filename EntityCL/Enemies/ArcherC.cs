using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCL.Enemies
{
    internal class ArcherC : EnemyAC
    {
        public ArcherC() : base()
        {
            MAXHealthPoints = 10;
            HealthPoints = 10;
            AttackGamage = 1;
            EntityName = "Old Archer";
            Class = "Archer";
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
