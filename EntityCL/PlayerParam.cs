using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EntityCL
{
    public class PlayerParam : EntityParam
    {
        public int AmountOfEstus { get; private set; }
        public int AmountOfSoulCoins { get; private set; }
        public int Speed { get; private set; } = 5;
        public float Stamina { get; private set; } = 100f;
        public int MAXDefaultHealth { get; private set; } = 10;
        public int DefaultSpeed { get; private set; } = 5;
        public int SprintSpeed { get; private set; } = 10;
        public int BlockSpeed { get; private set; } = 2;
        public float StaminaRegenRate { get; private set; } = 0.5f;
        public int AttackStaminaCost { get; private set; } = 30;
        public int EstusHealthRegen { get; private set; } = 2;
        public PlayerParam(int hearth, int attack, int coins, int estus, int width, int height) : base(hearth, attack, width, hearth)
        {
            AmountOfEstus = estus;
            AmountOfSoulCoins = coins;
        }
}
}
