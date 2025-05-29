using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JewelGame._Scripts
{
    public static class GameContext
    {
        public static Player Player1 { get; set; }
        public static Player Player2 { get; set; }

        public static ProgressBar Player1HPBar { get; set; }
        public static ProgressBar Player2HPBar { get; set; }
        public static Panel Player1Sbar { get; set; }
        public static Panel Player2Sbar { get; set; }
        public static Panel Player1Cbar { get; set; }
        public static Panel Player2Cbar { get; set; }
        public static void Init( ProgressBar p1HPBar, ProgressBar p2HPBar, Panel Sp1 , Panel Sp2, Panel Cp1, Panel Cp2)
        {
            Player1 = new Player();
            Player2 = new Player();
            Player1HPBar = p1HPBar;
            Player2HPBar = p2HPBar;
            Player1Sbar = Sp1;
            Player2Sbar = Sp2;
            Player1Cbar = Cp1;
            Player2Cbar = Cp2;
        }
    }
}
