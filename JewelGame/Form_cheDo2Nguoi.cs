using JewelGame._Scripts;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace JewelGame
{
    public partial class Form_cheDo2Nguoi : Form
    {
        DataRow thongTinTranDau;
        JewelGrid jewelGrid;
        Player player1 => GameContext.Player1;
        Player player2 => GameContext.Player2;
        GameManager gameManager;
        public Form_cheDo2Nguoi()
        {
            InitializeComponent();
            GameContext.Init(Player1Health, Player2Health, player1SMana, player2SMana, Cp1, Cp2);
            loadGame();
        }

        private void Form1_Resize(object sender, System.EventArgs e)
        {
            player2SMana.Width = panel4.Width;
            player1SMana.Width = panel1.Width;
            Cp1.Width = panel2.Width;
            Cp2.Width = panel2.Width;
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            BeginInvoke((Action)(() =>
            {
                if (gameManager.playerTurn())
                {
                    MessageBox.Show("Đến lượt " + player1.Name);
                }
                else
                {
                    MessageBox.Show("Đến lượt " + player2.Name);
                }
            }));
        }
        private void loadGame()
        {
            DataRow data = DatabaseGame.GetDataRow_TranDau2Nguoi(3);

            jewelGrid = new JewelGrid(Convert.ToInt32(data["kichCo"]), DatabaseGame.GetDataTable_Jewels(3));
            panel_JewelGrid.Controls.Add(jewelGrid);

            gameManager = new GameManager(jewelGrid);
            gameManager._isPlayer1Turn = Convert.ToBoolean(data["luotNguoiChoi"]);

            player1.Name = data["tenNguoiChoi1"].ToString();
            player1.HP = Convert.ToInt32(data["hpNguoiChoi1"]);
            player1.Shield = Convert.ToInt32(data["giapNguoiChoi1"]);
            player1.controlMana = Convert.ToInt32(data["nangLuongNguoiChoi1"]);


            player2.Name = data["tenNguoiChoi2"].ToString();
            player2.HP = Convert.ToInt32(data["hpNguoiChoi2"]);
            player2.Shield = Convert.ToInt32(data["giapNguoiChoi2"]);
            player2.controlMana = Convert.ToInt32(data["nangLuongNguoiChoi2"]);

            Player1Health.Value = player1.HP;
            Player2Health.Value = player2.HP;
            gameManager.Update(player1SMana, player1.Shield);
            gameManager.Update(player1SMana, player2.Shield);
            gameManager.Update(Cp1, player1.controlMana);
            gameManager.Update(Cp2, player2.controlMana);

            player1Name.Text = player1.Name;
            player2Name.Text = player2.Name;
        }
    }
}
