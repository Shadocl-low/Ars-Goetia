using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsCL
{
    public class Chest : MyObject
    {
        public Chest() : base()
        {
            Width = 100; Height = 100;
            HealthPoints = 2;
        }
        public override void TakeDamage(int atk)
        {
            HealthPoints -= atk;
        }
    }
}
