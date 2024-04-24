using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MainMenu.Pages
{
    public class KeysControl
    {
        public Key MoveUp { get; set; }
        public Key MoveDown { get; set;}
        public Key MoveLeft { get; set; }
        public Key MoveRight { get; set;}
        public KeysControl()
        {
            MoveUp = Key.W;
            MoveDown = Key.S;
            MoveLeft = Key.A;
            MoveRight = Key.D;
        }
    }
}
