using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;
using EntityCL.Enemies;

namespace EntityCL.Bosses
{
    public class SwordsmanBoss : BossAC
    {
        public SwordsmanBoss(Player mainPlayer, Canvas gameField) : base(mainPlayer)
        {
        }

        public override void SetEntityBehavior(List<Rectangle> itemRemover)
        {
            throw new NotImplementedException();
        }
    }
}
