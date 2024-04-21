using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCL
{
    public class Player : EntityAC
    {
        public string Weapon { get; protected set; }
        public int AmoutOfEstus { get; protected set; }
        public Player(string name, int maxhp, double hp, int atk, string weapon, int estus) : base(name, maxhp, hp, atk)
        {
            Weapon = weapon;
            AmoutOfEstus = estus;
        }
        public override void Burning()
        {
            State = "Burning";
            HealthPoints -= MAXHealthPoints * 0.01 / 16;
        }
        public override void TakeDamage(int atk)
        {
            HealthPoints -= atk;
        }
        public void DrinkEstus()
        {
            if ((int)HealthPoints != MAXHealthPoints)
            {
                AmoutOfEstus--;
                HealthPoints = MAXHealthPoints;
            }
        }
    }
}
