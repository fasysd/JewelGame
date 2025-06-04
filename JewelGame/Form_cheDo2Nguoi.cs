using JewelGame._Scripts;
using System;
using System.Data;
using System.Reflection.Emit;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JewelGame
{
    public partial class Form_cheDo2Nguoi : Form
    {
        TimeSpan timeSpan;
        DateTime startTime;
        DataRow thongTinTranDau;
        JewelGrid jewelGrid;
        Player player1 = GameManager._player1;
        Player player2 = GameManager._player2;
        GameManager gameManager;
        private bool gameOff = false;
        int a, b, c;
        int time = 0;
        public Form_cheDo2Nguoi()
        {
            InitializeComponent();

            textDamage_player1.Location = new System.Drawing.Point(panel1.Location.X, panel1.Location.Y - this.ClientSize.Height / 30);
            a = this.ClientSize.Height;
        }

        private void Form1_Resize(object sender, System.EventArgs e)
        {
            if (thongTinTranDau == null) return;


            textDamage_player1.Location = new System.Drawing.Point(panel1.Location.X, panel1.Location.Y - this.ClientSize.Height / 30);
            textDamage_player2.Location = new System.Drawing.Point(this.ClientSize.Width / 21 + this.ClientSize.Width / 2, textDamage_player1.Location.Y);
            if (this.ClientSize.Height <= a + a / 2)
            {
                Lbresize(9);
            }
            else if (this.ClientSize.Height > a + a / 2)
            {
                Lbresize(15);
            }
            else if (this.ClientSize.Height > a * 2)
            {
                Lbresize(26);
            }

        }
        private void Form1_Load(object sender, System.EventArgs e)
        {
            TimeCount();
            gameManager = new GameManager(jewelGrid);
            gameManager._isPlayer1Turn = Convert.ToBoolean(thongTinTranDau["luotNguoiChoi"]);

            time = Convert.ToInt32(((TimeSpan)thongTinTranDau["thoiGian"]).TotalSeconds);

            player1.Name = thongTinTranDau["tenNguoiChoi1"].ToString().TrimEnd();
            player1.HP = Convert.ToInt32(thongTinTranDau["hpNguoiChoi1"]);
            player1.Shield = Convert.ToInt32(thongTinTranDau["giapNguoiChoi1"]);
            player1.controlMana = Convert.ToInt32(thongTinTranDau["nangLuongNguoiChoi1"]);

            player2.Name = thongTinTranDau["tenNguoiChoi2"].ToString().TrimEnd();
            player2.HP = Convert.ToInt32(thongTinTranDau["hpNguoiChoi2"]);
            player2.Shield = Convert.ToInt32(thongTinTranDau["giapNguoiChoi2"]);
            player2.controlMana = Convert.ToInt32(thongTinTranDau["nangLuongNguoiChoi2"]);
            ///

            gameManager.Update(player1SMana, player1.Shield);
            gameManager.Update(player2SMana, player2.Shield);
            gameManager.Update(Cp1, player1.controlMana);
            gameManager.Update(Cp2, player2.controlMana);

            Player1Health.Value = player1.HP;
            Player2Health.Value = player2.HP;
            player1Name.Text = player1.Name;
            player2Name.Text = player2.Name;
            label_time.Text = time.ToString();
        }

        public void _SetData(DataRow data)
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
            if( gameOff)
            {
                DatabaseGame.DeleteData(Convert.ToInt32(thongTinTranDau["maTranDau"]));
            }
            else if (Convert.ToInt32(thongTinTranDau["maTranDau"]) != -1)
            {
                DatabaseGame.UpdateData_tranDau2Nguoi(thongTinTranDau, jewelGrid._GetDataTable_Jewels());
            }
            else
            {
                DatabaseGame.InsertData_tranDau2Nguoi(thongTinTranDau, jewelGrid._GetDataTable_Jewels());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TurnManager();
            label_hpPlayer1.Text = "HP: " + player1.HP.ToString() + "/100";
            label_hpPlayer2.Text = "HP: " + player2.HP.ToString() + "/100";
            label_shieldPlayer1.Text = "Shield: " + player1.Shield.ToString();
            label_shieldPlayer2.Text = "Shield: " + player2.Shield.ToString();
            label_manaPlayer1.Text = "Control: " + player1.controlMana.ToString();
            label_manaPlayer2.Text = "Control: " + player2.controlMana.ToString();

            textDame();

            Player1Health.Value = player1.HP;
            Player2Health.Value = player2.HP;
            gameManager.Update(player1SMana, player1.Shield);
            gameManager.Update(player2SMana, player2.Shield);
            gameManager.Update(Cp1, player1.controlMana);
            gameManager.Update(Cp2, player2.controlMana);
            if ((player1.IsDefeated() | player2.IsDefeated()) & gameOff == false)
            {
                gameOff = true;
                MessageBox.Show( ( player1.IsDefeated() ? player2.Name : player1.Name) + " chiến thắng!");
                DialogResult result = MessageBox.Show(
                                        "Trận đấu đã kết thúc, trận đấu này sẽ bị xóa!!!",
                                        "Thông báo",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Question);
                this.Close();
            }
        }

        private async Task textDame()
        {
            if (player1.isDamage == true)
            {
                Control originParent = textDamage_player1.Parent;
                textDamage_player1.Visible = true;
                textDamage_player1.Text = " - " + player1._damage.ToString();
                for (int i = 0; i < 3; i++)
                {

                    textDamage_player1.Top -= 1;
                    await Task.Delay(500);
                }

                textDamage_player1.Location = new System.Drawing.Point(panel1.Location.X, panel1.Location.Y - this.ClientSize.Height / 30);
                player1.isDamage = false;
                textDamage_player1.Visible = false;


            }
            else if (player2.isDamage == true)
            {
                Control originParent = textDamage_player2.Parent;
                textDamage_player2.Visible = true;
                textDamage_player2.Text = " - " + player2._damage.ToString();
                for (int i = 0; i < 3; i++)
                {

                    textDamage_player2.Top -= 1;
                    await Task.Delay(500);
                }

                textDamage_player2.Location = new System.Drawing.Point(this.ClientSize.Width / 3 + this.ClientSize.Width / 10, textDamage_player1.Location.Y);
                player2.isDamage = false;
                textDamage_player2.Visible = false;
            }

        }
        private void TurnManager()
        {
            if (gameManager._isPlayer1Turn == true && GameManager.canClick == true)
            {
                pictureBox1.Visible = true;
                pictureBox2.Visible = false;

            }
            else if (gameManager._isPlayer1Turn == false && GameManager.canClick == true)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;

            }
        }
        private async Task TimeCount()
        {
            while (true)
            {
                label_time.Text = time.ToString();
                await Task.Delay(1000);
                time++;
            }
        }
        private void Lbresize(int a)
        {
            this.label_hpPlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", a, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_hpPlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", a, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_shieldPlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", a, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_shieldPlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", a, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_manaPlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", a, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_manaPlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", a, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDamage_player1.Font = new System.Drawing.Font("Microsoft Sans Serif", a, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDamage_player2.Font = new System.Drawing.Font("Microsoft Sans Serif", a, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_time.Font = new System.Drawing.Font("Microsoft Sans Serif", a * 2, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

    }
}
