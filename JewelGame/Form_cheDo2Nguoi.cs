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
        TimeSpan timeSpan;
        DateTime startTime;
        DataRow thongTinTranDau;
        JewelGrid jewelGrid;
        Player player1 => GameContext.Player1;
        Player player2 => GameContext.Player2;
        GameManager gameManager;
        public Form_cheDo2Nguoi()
        {
            InitializeComponent();
            GameContext.Init(Player1Health, Player2Health, player1SMana, player2SMana, Cp1, Cp2);
        }

        private void Form1_Resize(object sender, System.EventArgs e)
        {
            if (thongTinTranDau == null) return;
            player1SMana.Width = panel1.Width;
            player2SMana.Width = panel4.Width;
            Cp1.Width = panel2.Width;
            Cp2.Width = panel2.Width;
            gameManager.Update(player1SMana, player1.Shield);
            gameManager.Update(player2SMana, player2.Shield);
            gameManager.Update(Cp1, player1.controlMana);
            gameManager.Update(Cp2, player2.controlMana);
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            gameManager = new GameManager(jewelGrid);
            gameManager._isPlayer1Turn = Convert.ToBoolean(thongTinTranDau["luotNguoiChoi"]);

            player1.Name = thongTinTranDau["tenNguoiChoi1"].ToString();
            player1.HP = Convert.ToInt32(thongTinTranDau["hpNguoiChoi1"]);
            player1.Shield = Convert.ToInt32(thongTinTranDau["giapNguoiChoi1"]);
            player1.controlMana = Convert.ToInt32(thongTinTranDau["nangLuongNguoiChoi1"]);

            player2.Name = thongTinTranDau["tenNguoiChoi2"].ToString();
            player2.HP = Convert.ToInt32(thongTinTranDau["hpNguoiChoi2"]);
            player2.Shield = Convert.ToInt32(thongTinTranDau["giapNguoiChoi2"]);
            player2.controlMana = Convert.ToInt32(thongTinTranDau["nangLuongNguoiChoi2"]);

            gameManager.Update(player1SMana, player1.Shield);
            gameManager.Update(player1SMana, player2.Shield);
            gameManager.Update(Cp1, player1.controlMana);
            gameManager.Update(Cp2, player2.controlMana);

            Player1Health.Value = player1.HP;
            Player2Health.Value = player2.HP;
            player1Name.Text = player1.Name;
            player2Name.Text = player2.Name;

            MessageBox.Show("Bắt đầu trận đấu, đến lượt " + ( gameManager._isPlayer1Turn ? player1.Name : player2.Name));
            BeginInvoke((Action)(() =>
            {
                if (player1.IsDefeated() | player2.IsDefeated())
                {
                    DialogResult result = MessageBox.Show(
                                            "Trận đấu đã kết thúc, trận đấu này sẽ bị xóa!!!",
                                            "Thông báo",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Question);
                     DatabaseGame.DeleteData(Convert.ToInt32(thongTinTranDau["maTranDau"]));
                }
            }));
        }

        public void _SetData( DataRow data)
        {
            thongTinTranDau = data;
            if (Convert.ToInt32(thongTinTranDau["maTranDau"]) != -1)
            {
                jewelGrid = new JewelGrid(Convert.ToInt32(thongTinTranDau["kichCo"]), DatabaseGame.GetDataTable_Jewels(Convert.ToInt32(thongTinTranDau["maTranDau"])));
                panel_JewelGrid.Controls.Add(jewelGrid);
            }
            else
            {
                jewelGrid = new JewelGrid(Convert.ToInt32(thongTinTranDau["kichCo"]));
                panel_JewelGrid.Controls.Add(jewelGrid);
            }
            timeSpan = (TimeSpan)thongTinTranDau["thoiGian"];
            startTime = DateTime.Now;
        }
        private void Form_cheDo2Nguoi_FormClosed(object sender, FormClosedEventArgs e)
        {
            thongTinTranDau["thoiGian"] = timeSpan + (TimeSpan)(DateTime.Now - startTime);
            thongTinTranDau["luotNguoiChoi"] = gameManager.playerTurn();
            thongTinTranDau["hpNguoiChoi1"] = player1.HP;
            thongTinTranDau["giapNguoiChoi1"] = player1.Shield;
            thongTinTranDau["nangLuongNguoiChoi1"] = player1.controlMana;
            thongTinTranDau["hpNguoiChoi2"] = player2.HP;
            thongTinTranDau["giapNguoiChoi2"] = player2.Shield;
            thongTinTranDau["nangLuongNguoiChoi2"] = player2.controlMana;

            if (Convert.ToInt32(thongTinTranDau["maTranDau"]) != -1)
            {
                DatabaseGame.UpdateData_tranDau2Nguoi(thongTinTranDau, jewelGrid._GetDataTable_Jewels());
            }
            else
            {
                DatabaseGame.InsertData_tranDau2Nguoi(thongTinTranDau, jewelGrid._GetDataTable_Jewels());
            }
        }
    }
}
