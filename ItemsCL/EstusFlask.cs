using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsumablesCL;
using EntityCL;

namespace ItemsCL
{
    public class EstusFlask : Consumable
    {
        public EstusFlask(string name, string description, int amount) : base(name, description, amount) 
        {
        
        }
        public override void Effect(Player player)
        {
            player.HealthPoints = player.MAXHealthPoints;
        }
    }
}
