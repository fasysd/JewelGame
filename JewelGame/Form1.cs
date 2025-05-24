using JewelGame;
using Project_JewelGame._Scripts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_JewelGame
{
    public partial class Form1 : Form
    {
        JewelGrid jewelGrid;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            jewelGrid = new JewelGrid(GridCount: 15);
            panel_JewelGrid.Controls.Add(jewelGrid);

            //jewelGrid = new JewelGrid( DatabaseGame.GetData_JewelGrid( 8));
        }

        private void button_saveGame_Click(object sender, EventArgs e)
        {
            DatabaseGame.InsertData(newData: new DatabaseGame.Data_tranDau
            {
                tenNguoiChoi1 = "Player_test1",
                tenNguoiChoi2 = "Player_test2",
            }, newJewels: jewelGrid._GetData_Jewels());
        }
    }
}
