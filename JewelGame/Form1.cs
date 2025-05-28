using JewelGame._Scripts;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace JewelGame
{
    public partial class Form1 : Form
    {
        JewelGrid jewelGrid;
        int currenTRanDau;
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = DatabaseGame.GetDataTable_ListTranDau().DefaultView.ToTable(false, "maTranDau", "tenNguoiChoi1", "tenNguoiChoi2", "kichCo", "thoiGian");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            jewelGrid = new JewelGrid(GridCount: 10);
            panel_JewelGrid.Controls.Add(jewelGrid);
        }

        private void button_saveGame_Click(object sender, EventArgs e)
        {
            DatabaseGame.InsertData(newData: new DatabaseGame.Data_tranDau
            {
                kichCo = jewelGrid._GridCount,
                thoiGian = 0,

                tenNguoiChoi1 = "Player_test1",
                hpNguoiChoi1 = 50,
                giapNguoiChoi1 = 29,
                noNguoiChoi1 = 43,
                nangLuongNguoiChoi1 = 54,

                tenNguoiChoi2 = "Player_test2",
                hpNguoiChoi2 = 50,
                giapNguoiChoi2 = 29,
                noNguoiChoi2 = 43,
                nangLuongNguoiChoi2 = 54,
            }, newJewels: jewelGrid._GetDataTable_Jewels());

            //Cập nhật Data cho trận đấu vừa chọn
            //DatabaseGame.UpdateData(DatabaseGame.GetData_TranDau(currenTRanDau), jewelGrid._GetDataTable_Jewels());

            _setDataSoure();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var clickCells = dataGridView1.CurrentRow.Cells;
            if (clickCells == null) return;
            int maTranDauDuocChon = Convert.ToInt32(clickCells["Column1"].Value);
            int kichCo = Convert.ToInt32(clickCells["Column4"].Value);

            panel_JewelGrid.Controls.Remove(jewelGrid);
            jewelGrid = new JewelGrid(kichCo, DatabaseGame.GetDataTable_Jewels(maTranDauDuocChon));
            panel_JewelGrid.Controls.Add(jewelGrid);

            _setDataSoure();

            currenTRanDau = maTranDauDuocChon;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var clickCells = dataGridView1.CurrentRow.Cells;
            if (clickCells == null) return;
            int maTranDauDuocChon = Convert.ToInt32(clickCells["Column1"].Value);

            DatabaseGame.DeleteData(maTranDauDuocChon);

            _setDataSoure();
        }

        private void _setDataSoure()
        {
            dataGridView1.DataSource = DatabaseGame.GetDataTable_ListTranDau().DefaultView.ToTable(false, "maTranDau", "tenNguoiChoi1", "tenNguoiChoi2", "kichCo", "thoiGian");
        }
    }
}
