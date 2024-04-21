using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCL
{
    public abstract class EnemyAC : EntityAC
    {
        public string? Class { get; protected set; }
        public EnemyAC() : base()
        {

        }
    }
}
