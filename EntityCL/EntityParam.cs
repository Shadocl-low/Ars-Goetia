using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCL
{
    public class EntityParam
    {
        public int DefaultHealth { get; private set; }
        public int DefaultAttackDamage { get; private set; }
        public int DefaultStrength { get; private set; }
        public int DefaultSoulCoins { get; private set; }
        public int EntityWidth { get; private set; }
        public int EntityHeight { get; private set; }
        public EntityParam(int health, int attack, int strength, int soulCoins, int width, int height) 
        {
            DefaultHealth = health;
            DefaultAttackDamage = attack;
            DefaultStrength = strength;
            DefaultSoulCoins = soulCoins;
            EntityWidth = width;
            EntityHeight = height;
        }
    }
}
