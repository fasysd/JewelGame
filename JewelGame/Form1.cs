using Project_JewelGame._Scripts;
using System.Windows.Forms;

namespace Project_JewelGame
{
    public partial class Form1 : Form
    {
        JewelGrid jewelGrid;
        public Form1()
        {
            InitializeComponent();
            jewelGrid = new JewelGrid( this);
            //this.Controls.Add(jewelGrid._TableLayoutPanel);
        }

    }
}
