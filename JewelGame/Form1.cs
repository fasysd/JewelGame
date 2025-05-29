using JewelGame._Scripts;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace JewelGame
{
    public partial class Form1 : Form
    {
        JewelGrid jewelGrid;
        DatabaseGame.Data_tranDau currenTRanDau;
        public Form1()
        {
            InitializeComponent();
            _setDataSoure();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            jewelGrid = new JewelGrid(GridCount: 7);
            panel_JewelGrid.Controls.Add(jewelGrid);
        }

        private void button_saveGame_Click(object sender, EventArgs e)
        {
            currenTRanDau = new DatabaseGame.Data_tranDau
            {
                maTranDau = currenTRanDau.maTranDau,
                kichCo = jewelGrid._GridCount,
                thoiGian = 0,

                tenNguoiChoi1 = textBox_ten1.Text,
                hpNguoiChoi1 = 50,
                giapNguoiChoi1 = 29,
                noNguoiChoi1 = 43,
                nangLuongNguoiChoi1 = 54,

                tenNguoiChoi2 = textBox_ten2.Text,
                hpNguoiChoi2 = 50,
                giapNguoiChoi2 = 29,
                noNguoiChoi2 = 43,
                nangLuongNguoiChoi2 = 54,
            };
            DatabaseGame.UpdateData_Jewel( currenTRanDau.maTranDau, jewelGrid._GetDataTable_Jewels());

            _setDataSoure();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Hiển thị trận đấu được chọn
            var clickCells = dataGridView1.CurrentRow.Cells;
            if (clickCells == null) return;
            int maTranDauDuocChon = Convert.ToInt32(clickCells["Column1"].Value);
            int kichCo = Convert.ToInt32(clickCells["Column4"].Value);

            panel_JewelGrid.Controls.Remove(jewelGrid);
            jewelGrid = new JewelGrid(kichCo, DatabaseGame.GetDataTable_Jewels(maTranDauDuocChon));
            panel_JewelGrid.Controls.Add(jewelGrid);

            currenTRanDau = DatabaseGame.GetData_TranDau( maTranDauDuocChon);
            label_tranDauHienTai.Text = "Mã trận dấu hiện tại: " + currenTRanDau.maTranDau.ToString();
            textBox_ten1.Text = currenTRanDau.tenNguoiChoi1;
            textBox_ten2.Text = currenTRanDau.tenNguoiChoi2;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Xóa được chọn
            var clickCells = dataGridView1.CurrentRow.Cells;
            if (clickCells == null) return;
            int maTranDauDuocChon = Convert.ToInt32(clickCells["Column1"].Value);

            DatabaseGame.DeleteData(maTranDauDuocChon);
            _setDataSoure();
        }

        private void _setDataSoure()
        {
            dataGridView1.DataSource = DatabaseGame.GetDataTable_TranDau().DefaultView.ToTable(false, "maTranDau", "tenNguoiChoi1", "tenNguoiChoi2", "kichCo", "thoiGian");
        }

        private void button_Click_newGame(object sender, EventArgs e)
        {
            currenTRanDau = new DatabaseGame.Data_tranDau
            {
                kichCo = jewelGrid._GridCount,
                thoiGian = 0,

                tenNguoiChoi1 = textBox_ten1.Text,
                hpNguoiChoi1 = 50,
                giapNguoiChoi1 = 29,
                noNguoiChoi1 = 43,
                nangLuongNguoiChoi1 = 54,

                tenNguoiChoi2 = textBox_ten2.Text,
                hpNguoiChoi2 = 50,
                giapNguoiChoi2 = 29,
                noNguoiChoi2 = 43,
                nangLuongNguoiChoi2 = 54,
            };


            panel_JewelGrid.Controls.Remove(jewelGrid);
            jewelGrid = new JewelGrid(GridCount: 10);
            panel_JewelGrid.Controls.Add(jewelGrid);
            currenTRanDau = DatabaseGame.InsertData(currenTRanDau, jewelGrid._GetDataTable_Jewels());

            _setDataSoure();
            label_tranDauHienTai.Text = "Mã trận dấu hiện tại: " + currenTRanDau.maTranDau.ToString();
            textBox_ten1.Text = currenTRanDau.tenNguoiChoi1;
            textBox_ten2.Text = currenTRanDau.tenNguoiChoi2;
        }
    }
}
