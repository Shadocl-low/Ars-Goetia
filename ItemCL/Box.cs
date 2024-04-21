using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace ItemCL
{
    public class Box : Item
    {
        public Box() : base() 
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
