using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JewelGame._scripts
{
    public static class GameContext
    {
        public static Player Player1 { get; set; }
        public static Player Player2 { get; set; }

        public static ProgressBar Player1HPBar { get; set; }
        public static ProgressBar Player2HPBar { get; set; }
        public static Label player1Name { get; set; }
        public static Label player2Name { get; set; } 
        public static void Init(Player p1, Player p2, ProgressBar p1HPBar, ProgressBar p2HPBar)
        {
            Player1 = p1;
            Player2 = p2;
          
            Player1HPBar = p1HPBar;
            Player2HPBar = p2HPBar;
        }
    }
}
