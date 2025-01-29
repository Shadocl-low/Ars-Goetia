using EntityCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EntityCL
{
    public class InputManager
    {
        public bool UpKeyPressed { get; set; }
        public bool DownKeyPressed { get; set; }
        public bool LeftKeyPressed { get; set; }
        public bool RightKeyPressed { get; set; }
        public bool SprintKeyPressed { get; private set; }
        public bool BlockKeyPressed { get; private set; }

        private readonly Player player;

        public InputManager(Player mainPlayer)
        {
            player = mainPlayer;
        }

        public void HandleKey(KeyEventArgs e, bool isKeyDown)
        {
            switch (e.Key)
            {
                case Key.W: UpKeyPressed = isKeyDown; break;
                case Key.A: LeftKeyPressed = isKeyDown; break;
                case Key.S: DownKeyPressed = isKeyDown; break;
                case Key.D: RightKeyPressed = isKeyDown; break;
                case Key.LeftShift: SprintKeyPressed = isKeyDown; break;
                case Key.LeftCtrl: BlockKeyPressed = isKeyDown; break;
                case Key.Q: if (isKeyDown) player.DrinkEstus(); break;
                case Key.F: if (isKeyDown) player.Attack(); break;
            }
        }
    }
}
