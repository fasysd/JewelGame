using System;
using System.Data;
using System.Windows.Forms;

namespace JewelGame._Scripts
{
    public class DatabaseGame
    {
        private DataSet gameDataSet;
        private int nextMaTranDau;

        // Singleton instance
        private static readonly DatabaseGame instance = new DatabaseGame();

        // Private constructor for Singleton pattern
        private DatabaseGame()
        {
            gameDataSet = new DataSet();
            nextMaTranDau = 1;
            InitializeDataTables();
        }

        private void InitializeDataTables()
        {
            // Create TranDau DataTable
            DataTable tranDauTable = new DataTable("TranDau");
            tranDauTable.Columns.Add("maTranDau", typeof(int));
            tranDauTable.Columns.Add("kichCo", typeof(int));
            tranDauTable.Columns.Add("thoiGian", typeof(TimeSpan));
            tranDauTable.Columns.Add("cheDoChoi", typeof(string));
            tranDauTable.PrimaryKey = new DataColumn[] { tranDauTable.Columns["maTranDau"] };
            gameDataSet.Tables.Add(tranDauTable);

            // Create TranDau_1Nguoi DataTable
            DataTable tranDau1NguoiTable = new DataTable("TranDau_1Nguoi");
            tranDau1NguoiTable.Columns.Add("maTranDau", typeof(int));
            tranDau1NguoiTable.Columns.Add("diemSo", typeof(int));
            tranDau1NguoiTable.Columns.Add("tenNguoiChoi", typeof(string));
            tranDau1NguoiTable.PrimaryKey = new DataColumn[] { tranDau1NguoiTable.Columns["maTranDau"] };
            gameDataSet.Tables.Add(tranDau1NguoiTable);

            // Create TranDau_2Nguoi DataTable
            DataTable tranDau2NguoiTable = new DataTable("TranDau_2Nguoi");
            tranDau2NguoiTable.Columns.Add("maTranDau", typeof(int));
            tranDau2NguoiTable.Columns.Add("luotNguoiChoi", typeof(bool));
            tranDau2NguoiTable.Columns.Add("tenNguoiChoi1", typeof(string));
            tranDau2NguoiTable.Columns.Add("hpNguoiChoi1", typeof(int));
            tranDau2NguoiTable.Columns.Add("giapNguoiChoi1", typeof(int));
            tranDau2NguoiTable.Columns.Add("nangLuongNguoiChoi1", typeof(int));
            tranDau2NguoiTable.Columns.Add("tenNguoiChoi2", typeof(string));
            tranDau2NguoiTable.Columns.Add("hpNguoiChoi2", typeof(int));
            tranDau2NguoiTable.Columns.Add("giapNguoiChoi2", typeof(int));
            tranDau2NguoiTable.Columns.Add("nangLuongNguoiChoi2", typeof(int));
            tranDau2NguoiTable.PrimaryKey = new DataColumn[] { tranDau2NguoiTable.Columns["maTranDau"] };
            gameDataSet.Tables.Add(tranDau2NguoiTable);

            // Create Jewel DataTable
            DataTable jewelTable = new DataTable("Jewel");
            jewelTable.Columns.Add("maTranDau", typeof(int));
            jewelTable.Columns.Add("toaDoX", typeof(int));
            jewelTable.Columns.Add("toaDoY", typeof(int));
            jewelTable.Columns.Add("loaiJewel", typeof(string));
            DataColumn[] jewelPK = new DataColumn[]
            {
                jewelTable.Columns["maTranDau"],
                jewelTable.Columns["toaDoX"],
                jewelTable.Columns["toaDoY"]
            };
            jewelTable.PrimaryKey = jewelPK;
            gameDataSet.Tables.Add(jewelTable);
        }

        private static DatabaseGame Instance => instance;

        public static DataRow NewRow_TranDau1Nguoi()
        {
            DataTable resultTable = new DataTable();

            // Thêm cột của TranDau
            resultTable.Columns.Add("maTranDau", typeof(int));
            resultTable.Columns.Add("kichCo", typeof(int));
            resultTable.Columns.Add("thoiGian", typeof(TimeSpan));
            resultTable.Columns.Add("cheDoChoi", typeof(string));

            // Thêm cột của TranDau_1Nguoi
            resultTable.Columns.Add("maTranDau1Nguoi", typeof(int));
            resultTable.Columns.Add("diemSo", typeof(int));
            resultTable.Columns.Add("tenNguoiChoi", typeof(string));

            DataRow row = resultTable.NewRow();
            //Giá trị mặc định
            row["maTranDau"] = -1;
            row["kichCo"] = 10;
            row["thoiGian"] = new TimeSpan(0);
            row["cheDoChoi"] = "1 Player";

            row["maTranDau1Nguoi"] = -1;
            row["diemSo"] = 0;
            row["tenNguoiChoi"] = "Player không có tên";

            return row;
        }
        public static DataRow NewRow_TranDau2Nguoi()
        {
            DataTable resultTable = new DataTable();

            // Thêm cột của TranDau
            resultTable.Columns.Add("maTranDau", typeof(int));
            resultTable.Columns.Add("kichCo", typeof(int));
            resultTable.Columns.Add("thoiGian", typeof(TimeSpan));
            resultTable.Columns.Add("cheDoChoi", typeof(string));

            // Thêm cột của TranDau_1Nguoi
            resultTable.Columns.Add("maTranDau2Nguoi", typeof(int));
            resultTable.Columns.Add("luotNguoiChoi", typeof(bool));

            resultTable.Columns.Add("tenNguoiChoi1", typeof(string));
            resultTable.Columns.Add("hpNguoiChoi1", typeof(int));
            resultTable.Columns.Add("giapNguoiChoi1", typeof(int));
            resultTable.Columns.Add("nangLuongNguoiChoi1", typeof(int));

            resultTable.Columns.Add("tenNguoiChoi2", typeof(string));
            resultTable.Columns.Add("hpNguoiChoi2", typeof(int));
            resultTable.Columns.Add("giapNguoiChoi2", typeof(int));
            resultTable.Columns.Add("nangLuongNguoiChoi2", typeof(int));

            DataRow row = resultTable.NewRow();
            //Giá trị mặc định
            row["maTranDau"] = -1;
            row["kichCo"] = 10;
            row["thoiGian"] = new TimeSpan(0);
            row["cheDoChoi"] = "2 Player";

            row["maTranDau2Nguoi"] = -1;
            row["luotNguoiChoi"] = true;

            row["tenNguoiChoi1"] = "Player 1 không có tên";
            row["hpNguoiChoi1"] = 100;
            row["giapNguoiChoi1"] = 0;
            row["nangLuongNguoiChoi1"] = 0;

            row["tenNguoiChoi2"] = "Player 2 không có tên";
            row["hpNguoiChoi2"] = 100;
            row["giapNguoiChoi2"] = 0;
            row["nangLuongNguoiChoi2"] = 0;

            return row;
        }

        public static DataTable GetDataTable_TranDau()
        {
            return Instance.gameDataSet.Tables["TranDau"];
        }

        public static DataRow GetDataRow_TranDau1Nguoi(int maTranDau)
        {
            var tranDauRow = Instance.gameDataSet.Tables["TranDau"].Rows.Find(maTranDau);
            var tranDau1NguoiRow = Instance.gameDataSet.Tables["TranDau_1Nguoi"].Rows.Find(maTranDau);

            if (tranDauRow == null || tranDau1NguoiRow == null)
                return null;

            DataTable tempTable = new DataTable();

            // Cột từ TranDau
            tempTable.Columns.Add("maTranDau", typeof(int));
            tempTable.Columns.Add("kichCo", typeof(int));
            tempTable.Columns.Add("thoiGian", typeof(TimeSpan));
            tempTable.Columns.Add("cheDoChoi", typeof(string));

            // Cột từ TranDau_1Nguoi
            tempTable.Columns.Add("diemSo", typeof(int));
            tempTable.Columns.Add("tenNguoiChoi", typeof(string));

            DataRow combinedRow = tempTable.NewRow();

            combinedRow["maTranDau"] = tranDauRow["maTranDau"];
            combinedRow["kichCo"] = tranDauRow["kichCo"];
            combinedRow["thoiGian"] = tranDauRow["thoiGian"];
            combinedRow["cheDoChoi"] = tranDauRow["cheDoChoi"];
            combinedRow["diemSo"] = tranDau1NguoiRow["diemSo"];
            combinedRow["tenNguoiChoi"] = tranDau1NguoiRow["tenNguoiChoi"];

            return combinedRow;
        }


        public static DataRow GetDataRow_TranDau2Nguoi(int maTranDau)
        {
            var tranDauRow = Instance.gameDataSet.Tables["TranDau"].Rows.Find(maTranDau);
            var tranDau2NguoiRow = Instance.gameDataSet.Tables["TranDau_2Nguoi"].Rows.Find(maTranDau);

            if (tranDauRow == null || tranDau2NguoiRow == null)
                return null;

            DataTable tempTable = new DataTable();

            // Cột từ TranDau
            tempTable.Columns.Add("maTranDau", typeof(int));
            tempTable.Columns.Add("kichCo", typeof(int));
            tempTable.Columns.Add("thoiGian", typeof(TimeSpan));
            tempTable.Columns.Add("cheDoChoi", typeof(string));

            // Cột từ TranDau_2Nguoi
            tempTable.Columns.Add("luotNguoiChoi", typeof(bool));
            tempTable.Columns.Add("tenNguoiChoi1", typeof(string));
            tempTable.Columns.Add("hpNguoiChoi1", typeof(int));
            tempTable.Columns.Add("giapNguoiChoi1", typeof(int));
            tempTable.Columns.Add("nangLuongNguoiChoi1", typeof(int));
            tempTable.Columns.Add("tenNguoiChoi2", typeof(string));
            tempTable.Columns.Add("hpNguoiChoi2", typeof(int));
            tempTable.Columns.Add("giapNguoiChoi2", typeof(int));
            tempTable.Columns.Add("nangLuongNguoiChoi2", typeof(int));

            DataRow combinedRow = tempTable.NewRow();

            combinedRow["maTranDau"] = tranDauRow["maTranDau"];
            combinedRow["kichCo"] = tranDauRow["kichCo"];
            combinedRow["thoiGian"] = tranDauRow["thoiGian"];
            combinedRow["cheDoChoi"] = tranDauRow["cheDoChoi"];

            combinedRow["luotNguoiChoi"] = tranDau2NguoiRow["luotNguoiChoi"];
            combinedRow["tenNguoiChoi1"] = tranDau2NguoiRow["tenNguoiChoi1"];
            combinedRow["hpNguoiChoi1"] = tranDau2NguoiRow["hpNguoiChoi1"];
            combinedRow["giapNguoiChoi1"] = tranDau2NguoiRow["giapNguoiChoi1"];
            combinedRow["nangLuongNguoiChoi1"] = tranDau2NguoiRow["nangLuongNguoiChoi1"];
            combinedRow["tenNguoiChoi2"] = tranDau2NguoiRow["tenNguoiChoi2"];
            combinedRow["hpNguoiChoi2"] = tranDau2NguoiRow["hpNguoiChoi2"];
            combinedRow["giapNguoiChoi2"] = tranDau2NguoiRow["giapNguoiChoi2"];
            combinedRow["nangLuongNguoiChoi2"] = tranDau2NguoiRow["nangLuongNguoiChoi2"];

            return combinedRow;
        }


        public static DataTable GetDataTable_Jewels(int maTranDau)
        {
            var inst = Instance;
            DataTable jewelTable = inst.gameDataSet.Tables["Jewel"];
            DataTable jewels = jewelTable.Clone();

            foreach (DataRow row in jewelTable.Rows)
            {
                if ((int)row["maTranDau"] == maTranDau)
                {
                    jewels.ImportRow(row);
                }
            }

            return jewels;
        }

        public static void InsertData_tranDau1Nguoi(DataRow dataRow_tranDau1Nguoi, DataTable dataTable_jewel)
        {
            if (dataRow_tranDau1Nguoi == null)
            {
                MessageBox.Show("Không có dữ liệu TranDau để thêm.");
                return;
            }

            var inst = Instance;
            DataTable tranDau = inst.gameDataSet.Tables["TranDau"];
            DataTable td1Nguoi = inst.gameDataSet.Tables["TranDau_1Nguoi"];
            DataTable jewelTable = inst.gameDataSet.Tables["Jewel"];

            // Tạo mã trận đấu mới
            int maTranDauMoi = inst.nextMaTranDau++;
            dataRow_tranDau1Nguoi["maTranDau"] = maTranDauMoi;

            // Thêm dòng vào bảng TranDau
            DataRow rowTD = tranDau.NewRow();
            rowTD["maTranDau"] = maTranDauMoi;
            rowTD["kichCo"] = dataRow_tranDau1Nguoi["kichCo"];
            rowTD["thoiGian"] = dataRow_tranDau1Nguoi["thoiGian"];
            rowTD["cheDoChoi"] = "1 Player"; // Hoặc lấy từ dataRow_tranDau1Nguoi nếu cần
            tranDau.Rows.Add(rowTD);

            // Thêm dòng vào bảng TranDau_1Nguoi
            DataRow row1Nguoi = td1Nguoi.NewRow();
            row1Nguoi["maTranDau"] = maTranDauMoi;
            row1Nguoi["diemSo"] = dataRow_tranDau1Nguoi["diemSo"];
            row1Nguoi["tenNguoiChoi"] = dataRow_tranDau1Nguoi["tenNguoiChoi"];
            td1Nguoi.Rows.Add(row1Nguoi);

            // Thêm các jewel vào bảng Jewel
            foreach (DataRow row in dataTable_jewel.Rows)
            {
                DataRow jewelRow = jewelTable.NewRow();
                jewelRow["maTranDau"] = maTranDauMoi;
                jewelRow["toaDoX"] = row["toaDoX"];
                jewelRow["toaDoY"] = row["toaDoY"];
                jewelRow["loaiJewel"] = row["loaiJewel"];
                jewelTable.Rows.Add(jewelRow);
            }
        }

        public static void InsertData_tranDau2Nguoi(DataRow dataRow_tranDau2Nguoi, DataTable dataTable_jewel)
        {
            if (dataRow_tranDau2Nguoi == null)
            {
                MessageBox.Show("Không có dữ liệu TranDau để thêm.");
                return;
            }

            var inst = Instance;
            DataTable tranDau = inst.gameDataSet.Tables["TranDau"];
            DataTable td2Nguoi = inst.gameDataSet.Tables["TranDau_2Nguoi"];
            DataTable jewelTable = inst.gameDataSet.Tables["Jewel"];

            // Tạo mã trận đấu mới
            int maTranDauMoi = inst.nextMaTranDau++;
            dataRow_tranDau2Nguoi["maTranDau"] = maTranDauMoi;

            // Thêm dòng vào bảng TranDau
            DataRow rowTD = tranDau.NewRow();
            rowTD["maTranDau"] = maTranDauMoi;
            rowTD["kichCo"] = dataRow_tranDau2Nguoi["kichCo"];
            rowTD["thoiGian"] = dataRow_tranDau2Nguoi["thoiGian"];
            rowTD["cheDoChoi"] = "2 Player"; // Hoặc lấy từ dataRow_tranDau2Nguoi nếu cần
            tranDau.Rows.Add(rowTD);

            // Thêm dòng vào bảng TranDau_2Nguoi
            DataRow row2Nguoi = td2Nguoi.NewRow();
            row2Nguoi["maTranDau"] = maTranDauMoi;
            row2Nguoi["luotNguoiChoi"] = dataRow_tranDau2Nguoi["luotNguoiChoi"];
            row2Nguoi["tenNguoiChoi1"] = dataRow_tranDau2Nguoi["tenNguoiChoi1"];
            row2Nguoi["hpNguoiChoi1"] = dataRow_tranDau2Nguoi["hpNguoiChoi1"];
            row2Nguoi["giapNguoiChoi1"] = dataRow_tranDau2Nguoi["giapNguoiChoi1"];
            row2Nguoi["nangLuongNguoiChoi1"] = dataRow_tranDau2Nguoi["nangLuongNguoiChoi1"];
            row2Nguoi["tenNguoiChoi2"] = dataRow_tranDau2Nguoi["tenNguoiChoi2"];
            row2Nguoi["hpNguoiChoi2"] = dataRow_tranDau2Nguoi["hpNguoiChoi2"];
            row2Nguoi["giapNguoiChoi2"] = dataRow_tranDau2Nguoi["giapNguoiChoi2"];
            row2Nguoi["nangLuongNguoiChoi2"] = dataRow_tranDau2Nguoi["nangLuongNguoiChoi2"];
            td2Nguoi.Rows.Add(row2Nguoi);

            // Thêm các jewel vào bảng Jewel
            foreach (DataRow row in dataTable_jewel.Rows)
            {
                DataRow jewelRow = jewelTable.NewRow();
                jewelRow["maTranDau"] = maTranDauMoi;
                jewelRow["toaDoX"] = row["toaDoX"];
                jewelRow["toaDoY"] = row["toaDoY"];
                jewelRow["loaiJewel"] = row["loaiJewel"];
                jewelTable.Rows.Add(jewelRow);
            }
        }


        public static void UpdateData_tranDau1Nguoi(DataRow dataRow_tranDau1Nguoi, DataTable dataTable_jewel)
        {
            if (dataRow_tranDau1Nguoi == null)
            {
                MessageBox.Show("Không có dữ liệu TranDau để cập nhật.");
                return;
            }

            var inst = Instance;
            DataTable tranDau = inst.gameDataSet.Tables["TranDau"];
            DataTable td1Nguoi = inst.gameDataSet.Tables["TranDau_1Nguoi"];
            DataTable jewelTable = inst.gameDataSet.Tables["Jewel"];

            int maTranDau = (int)dataRow_tranDau1Nguoi["maTranDau"];

            DataRow rowTD = tranDau.Rows.Find(maTranDau);
            if (rowTD != null)
            {
                rowTD["thoiGian"] = dataRow_tranDau1Nguoi["thoiGian"];
                rowTD["kichCo"] = dataRow_tranDau1Nguoi["kichCo"];
                rowTD["cheDoChoi"] = dataRow_tranDau1Nguoi["cheDoChoi"];
            }

            DataRow row1P = td1Nguoi.Rows.Find(maTranDau);
            if (row1P != null)
            {
                row1P["diemSo"] = dataRow_tranDau1Nguoi["diemSo"];
                row1P["tenNguoiChoi"] = dataRow_tranDau1Nguoi["tenNguoiChoi"];
            }

            foreach (DataRow jewelRow in dataTable_jewel.Rows)
            {
                DataRow rowJewel = jewelTable.Rows.Find(new object[] { maTranDau, jewelRow["toaDoX"], jewelRow["toaDoY"] });
                if (rowJewel != null)
                {
                    rowJewel["loaiJewel"] = jewelRow["loaiJewel"];
                }
            }
        }

        public static void UpdateData_tranDau2Nguoi(DataRow dataRow_tranDau2Nguoi, DataTable dataTable_jewel)
        {
            if (dataRow_tranDau2Nguoi == null)
            {
                MessageBox.Show("Không có dữ liệu TranDau để cập nhật.");
                return;
            }

            var inst = Instance;
            DataTable tranDau = inst.gameDataSet.Tables["TranDau"];
            DataTable td2Nguoi = inst.gameDataSet.Tables["TranDau_2Nguoi"];
            DataTable jewelTable = inst.gameDataSet.Tables["Jewel"];

            int maTranDau = (int)dataRow_tranDau2Nguoi["maTranDau"];

            DataRow rowTD = tranDau.Rows.Find(maTranDau);
            if (rowTD != null)
            {
                rowTD["thoiGian"] = dataRow_tranDau2Nguoi["thoiGian"];
                rowTD["kichCo"] = dataRow_tranDau2Nguoi["kichCo"];
                rowTD["cheDoChoi"] = dataRow_tranDau2Nguoi["cheDoChoi"];
            }

            DataRow row2P = td2Nguoi.Rows.Find(maTranDau);
            if (row2P != null)
            {
                row2P["luotNguoiChoi"] = dataRow_tranDau2Nguoi["luotNguoiChoi"];
                row2P["tenNguoiChoi1"] = dataRow_tranDau2Nguoi["tenNguoiChoi1"];
                row2P["hpNguoiChoi1"] = dataRow_tranDau2Nguoi["hpNguoiChoi1"];
                row2P["giapNguoiChoi1"] = dataRow_tranDau2Nguoi["giapNguoiChoi1"];
                row2P["nangLuongNguoiChoi1"] = dataRow_tranDau2Nguoi["nangLuongNguoiChoi1"];
                row2P["tenNguoiChoi2"] = dataRow_tranDau2Nguoi["tenNguoiChoi2"];
                row2P["hpNguoiChoi2"] = dataRow_tranDau2Nguoi["hpNguoiChoi2"];
                row2P["giapNguoiChoi2"] = dataRow_tranDau2Nguoi["giapNguoiChoi2"];
                row2P["nangLuongNguoiChoi2"] = dataRow_tranDau2Nguoi["nangLuongNguoiChoi2"];
            }

            foreach (DataRow jewelRow in dataTable_jewel.Rows)
            {
                DataRow rowJewel = jewelTable.Rows.Find(new object[] { maTranDau, jewelRow["toaDoX"], jewelRow["toaDoY"] });
                if (rowJewel != null)
                {
                    rowJewel["loaiJewel"] = jewelRow["loaiJewel"];
                }
            }
        }

        public static void DeleteData(int maTranDau)
        {
            var inst = Instance;
            DataTable tranDau = inst.gameDataSet.Tables["TranDau"];
            DataTable td1Nguoi = inst.gameDataSet.Tables["TranDau_1Nguoi"];
            DataTable td2Nguoi = inst.gameDataSet.Tables["TranDau_2Nguoi"];
            DataTable jewelTable = inst.gameDataSet.Tables["Jewel"];

            // Delete Jewel rows
            for (int i = jewelTable.Rows.Count - 1; i >= 0; i--)
            {
                if ((int)jewelTable.Rows[i]["maTranDau"] == maTranDau)
                {
                    jewelTable.Rows.RemoveAt(i);
                }
            }

            // Delete TranDau_1Nguoi row
            DataRow row1 = td1Nguoi.Rows.Find(maTranDau);
            if (row1 != null)
            {
                td1Nguoi.Rows.Remove(row1);
            }

            // Delete TranDau_2Nguoi row
            DataRow row2 = td2Nguoi.Rows.Find(maTranDau);
            if (row2 != null)
            {
                td2Nguoi.Rows.Remove(row2);
            }

            // Delete TranDau row
            DataRow rowTD = tranDau.Rows.Find(maTranDau);
            if (rowTD != null)
            {
                tranDau.Rows.Remove(rowTD);
            }
        }
    }
}























//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


//using System;
//using System.Data;
//using System.Data.SqlClient;
//using System.Windows.Forms;

//namespace JewelGame._Scripts
//{
//    public class DatabaseGame
//    {
//        private const string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=GameKimCuong;Integrated Security=True;";
//        public static DataRow NewRow_TranDau1Nguoi()
//        {
//            DataTable resultTable = new DataTable();

//            // Thêm cột của TranDau
//            resultTable.Columns.Add("maTranDau", typeof(int));
//            resultTable.Columns.Add("kichCo", typeof(int));
//            resultTable.Columns.Add("thoiGian", typeof(TimeSpan));
//            resultTable.Columns.Add("cheDoChoi", typeof(string));

//            // Thêm cột của TranDau_1Nguoi
//            resultTable.Columns.Add("maTranDau1Nguoi", typeof(int));
//            resultTable.Columns.Add("diemSo", typeof(int));
//            resultTable.Columns.Add("tenNguoiChoi", typeof(string));

//            DataRow row = resultTable.NewRow();
//            //Giá trị mặc định
//            row["maTranDau"] = -1;
//            row["kichCo"] = 10;
//            row["thoiGian"] = new TimeSpan(0);
//            row["cheDoChoi"] = "1 Player";

//            row["maTranDau1Nguoi"] = -1;
//            row["diemSo"] = 0;
//            row["tenNguoiChoi"] = "Player không có tên";

//            return row;
//        }
//        public static DataRow NewRow_TranDau2Nguoi()
//        {
//            DataTable resultTable = new DataTable();

//            // Thêm cột của TranDau
//            resultTable.Columns.Add("maTranDau", typeof(int));
//            resultTable.Columns.Add("kichCo", typeof(int));
//            resultTable.Columns.Add("thoiGian", typeof(TimeSpan));
//            resultTable.Columns.Add("cheDoChoi", typeof(string));

//            // Thêm cột của TranDau_1Nguoi
//            resultTable.Columns.Add("maTranDau2Nguoi", typeof(int));
//            resultTable.Columns.Add("luotNguoiChoi", typeof(bool));

//            resultTable.Columns.Add("tenNguoiChoi1", typeof(string));
//            resultTable.Columns.Add("hpNguoiChoi1", typeof(int));
//            resultTable.Columns.Add("giapNguoiChoi1", typeof(int));
//            resultTable.Columns.Add("nangLuongNguoiChoi1", typeof(int));

//            resultTable.Columns.Add("tenNguoiChoi2", typeof(string));
//            resultTable.Columns.Add("hpNguoiChoi2", typeof(int));
//            resultTable.Columns.Add("giapNguoiChoi2", typeof(int));
//            resultTable.Columns.Add("nangLuongNguoiChoi2", typeof(int));

//            DataRow row = resultTable.NewRow();
//            //Giá trị mặc định
//            row["maTranDau"] = -1;
//            row["kichCo"] = 10;
//            row["thoiGian"] = new TimeSpan(0);
//            row["cheDoChoi"] = "2 Player";

//            row["maTranDau2Nguoi"] = -1;
//            row["luotNguoiChoi"] = true;

//            row["tenNguoiChoi1"] = "Player 1 không có tên";
//            row["hpNguoiChoi1"] = 100;
//            row["giapNguoiChoi1"] = 0;
//            row["nangLuongNguoiChoi1"] = 0;

//            row["tenNguoiChoi2"] = "Player 2 không có tên";
//            row["hpNguoiChoi2"] = 100;
//            row["giapNguoiChoi2"] = 0;
//            row["nangLuongNguoiChoi2"] = 0;

//            return row;
//        }
//        public static DataTable GetDataTable_TranDau()
//        {
//            var result = new DataTable();
//            string query = "SELECT * FROM dbo.TranDau";

//            try
//            {
//                using (var conn = new SqlConnection(connectionString))
//                {
//                    conn.Open();
//                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
//                    adapter.Fill(result);
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Lỗi khi tải dữ liệu TranDau từ SQL: " + ex.Message);
//            }

//            return result;
//        }
//        public static DataRow GetDataRow_TranDau1Nguoi(int maTranDau)
//        {
//            var resultTable = new DataTable();
//            string query = @"
//                    SELECT td.*, td_1P.*
//                    FROM dbo.TranDau td
//                    JOIN dbo.TranDau_1Nguoi td_1P ON td.maTranDau = td_1P.maTranDau
//                    WHERE td.maTranDau = @maTranDau";

//            try
//            {
//                using (var conn = new SqlConnection(connectionString))
//                {
//                    conn.Open();
//                    using (SqlCommand cmd = new SqlCommand(query, conn))
//                    {
//                        cmd.Parameters.AddWithValue("@maTranDau", maTranDau);
//                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
//                        adapter.Fill(resultTable);
//                    }
//                }

//                if (resultTable.Rows.Count > 0) return resultTable.Rows[0];
//                else return null;
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Lỗi khi tải dữ liệu TranDau_1Nguoi từ SQL: " + ex.Message);
//                return null;
//            }
//        }
//        public static DataRow GetDataRow_TranDau2Nguoi(int maTranDau)
//        {
//            var resultTable = new DataTable();
//            string query = @"
//                    SELECT td.*, td_2P.*
//                    FROM dbo.TranDau td
//                    JOIN dbo.TranDau_2Nguoi td_2P ON td.maTranDau = td_2P.maTranDau
//                    WHERE td.maTranDau = @maTranDau";

//            try
//            {
//                using (var conn = new SqlConnection(connectionString))
//                {
//                    conn.Open();
//                    using (SqlCommand cmd = new SqlCommand(query, conn))
//                    {
//                        cmd.Parameters.AddWithValue("@maTranDau", maTranDau);
//                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
//                        adapter.Fill(resultTable);
//                    }
//                }

//                // Trả về dòng đầu tiên nếu có
//                if (resultTable.Rows.Count > 0)
//                {
//                    return resultTable.Rows[0];
//                }
//                else
//                {
//                    return null; // hoặc throw nếu muốn xử lý lỗi dữ liệu không tồn tại
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Lỗi khi tải dữ liệu TranDau_2Nguoi từ SQL: " + ex.Message);
//                return null;
//            }
//        }
//        public static DataTable GetDataTable_Jewels(int MaTranDau)
//        {
//            var result = new DataTable();

//            string query = @"SELECT * FROM dbo.Jewel
//                             WHERE maTranDau = @maTranDau";

//            try
//            {
//                using (var conn = new SqlConnection(connectionString))
//                {
//                    conn.Open();
//                    using (var cmd = new SqlCommand(query, conn))
//                    {
//                        cmd.Parameters.AddWithValue("@maTranDau", MaTranDau);

//                        using (var adapter = new SqlDataAdapter(cmd))
//                        {
//                            adapter.Fill(result);
//                        }
//                    }
//                }

//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Lỗi khi tải Jewel dữ liệu từ SQL: " + ex.Message);
//            }
//            return result;
//        }
//        public static void InsertData_tranDau1Nguoi(DataRow dataRow_tranDau1Nguoi, DataTable dataTable_jewel)
//        {
//            if (dataRow_tranDau1Nguoi == null)
//            {
//                MessageBox.Show("Không có dữ liệu TranDau để thêm.");
//                return;
//            }

//            string query_tranDau = @"INSERT INTO dbo.TranDau (thoiGian, kichCo, cheDoChoi)
//                     OUTPUT INSERTED.maTranDau
//                     VALUES (@thoiGian, @kichCo, @cheDoChoi)";

//            string query_tranDau1Nguoi = @"INSERT INTO dbo.TranDau_1Nguoi (maTranDau, diemSo, tenNguoiChoi)
//                           VALUES (@maTranDau, @diemSo, @tenNguoiChoi)";

//            string query_jewel = @"INSERT INTO dbo.Jewel (maTranDau, toaDoX, toaDoY, loaiJewel)
//                   VALUES (@maTranDau, @toaDoX, @toaDoY, @loaiJewel)";

//            try
//            {
//                using (var conn = new SqlConnection(connectionString))
//                {
//                    conn.Open();

//                    int maTranDauMoi;

//                    // Insert vào bảng TranDau
//                    using (var cmd = new SqlCommand(query_tranDau, conn))
//                    {
//                        cmd.Parameters.AddWithValue("@thoiGian", dataRow_tranDau1Nguoi["thoiGian"]);
//                        cmd.Parameters.AddWithValue("@kichCo", dataRow_tranDau1Nguoi["kichCo"]);
//                        cmd.Parameters.AddWithValue("@cheDoChoi", dataRow_tranDau1Nguoi["cheDoChoi"]);

//                        maTranDauMoi = (int)cmd.ExecuteScalar();
//                    }

//                    // Insert vào bảng TranDau_1Nguoi
//                    using (var cmd = new SqlCommand(query_tranDau1Nguoi, conn))
//                    {
//                        cmd.Parameters.AddWithValue("@maTranDau", maTranDauMoi);
//                        cmd.Parameters.AddWithValue("@diemSo", dataRow_tranDau1Nguoi["diemSo"]);
//                        cmd.Parameters.AddWithValue("@tenNguoiChoi", dataRow_tranDau1Nguoi["tenNguoiChoi"]);

//                        cmd.ExecuteNonQuery();
//                    }

//                    // Insert các Jewel
//                    foreach (DataRow row in dataTable_jewel.Rows)
//                    {
//                        using (var cmd = new SqlCommand(query_jewel, conn))
//                        {
//                            cmd.Parameters.AddWithValue("@maTranDau", maTranDauMoi);
//                            cmd.Parameters.AddWithValue("@toaDoX", row["toaDoX"]);
//                            cmd.Parameters.AddWithValue("@toaDoY", row["toaDoY"]);
//                            cmd.Parameters.AddWithValue("@loaiJewel", row["loaiJewel"]);

//                            cmd.ExecuteNonQuery();
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Lỗi khi thêm dữ liệu TranDau vào SQL: " + ex.Message);
//            }
//        }
//        public static void InsertData_tranDau2Nguoi(DataRow dataRow_tranDau2Nguoi, DataTable dataTable_jewel)
//        {
//            if (dataRow_tranDau2Nguoi == null)
//            {
//                MessageBox.Show("Không có dữ liệu TranDau để thêm.");
//                return;
//            }

//            string query_tranDau = @"INSERT INTO dbo.TranDau (thoiGian, kichCo, cheDoChoi)
//                                     OUTPUT INSERTED.maTranDau
//                                     VALUES (@thoiGian, @kichCo, @cheDoChoi)";

//            string query_tranDau2Nguoi = @"INSERT INTO dbo.TranDau_2Nguoi (
//                                                maTranDau, luotNguoiChoi,
//                                                tenNguoiChoi1, hpNguoiChoi1, giapNguoiChoi1, nangLuongNguoiChoi1, 
//                                                tenNguoiChoi2, hpNguoiChoi2, giapNguoiChoi2, nangLuongNguoiChoi2)
//                                            VALUES (
//                                                @maTranDau, @luotNguoiChoi, @tenNguoiChoi1, @hpNguoiChoi1, @giapNguoiChoi1, @nangLuongNguoiChoi1,
//                                                @tenNguoiChoi2, @hpNguoiChoi2, @giapNguoiChoi2, @nangLuongNguoiChoi2)";

//            string query_jewel = @"INSERT INTO dbo.Jewel (maTranDau, toaDoX, toaDoY, loaiJewel)
//                   VALUES (@maTranDau, @toaDoX, @toaDoY, @loaiJewel)";

//            try
//            {
//                using (var conn = new SqlConnection(connectionString))
//                {
//                    conn.Open();

//                    int maTranDauMoi;

//                    // Insert vào bảng TranDau
//                    using (var cmd = new SqlCommand(query_tranDau, conn))
//                    {
//                        cmd.Parameters.AddWithValue("@thoiGian", dataRow_tranDau2Nguoi["thoiGian"]);
//                        cmd.Parameters.AddWithValue("@kichCo", dataRow_tranDau2Nguoi["kichCo"]);
//                        cmd.Parameters.AddWithValue("@cheDoChoi", dataRow_tranDau2Nguoi["cheDoChoi"]);

//                        maTranDauMoi = (int)cmd.ExecuteScalar();
//                    }

//                    // Insert vào bảng TranDau_2Nguoi
//                    using (var cmd = new SqlCommand(query_tranDau2Nguoi, conn))
//                    {
//                        cmd.Parameters.AddWithValue("@maTranDau", maTranDauMoi);
//                        cmd.Parameters.AddWithValue("@luotNguoiChoi", dataRow_tranDau2Nguoi["luotNguoiChoi"]);
//                        cmd.Parameters.AddWithValue("@tenNguoiChoi1", dataRow_tranDau2Nguoi["tenNguoiChoi1"]);
//                        cmd.Parameters.AddWithValue("@hpNguoiChoi1", dataRow_tranDau2Nguoi["hpNguoiChoi1"]);
//                        cmd.Parameters.AddWithValue("@giapNguoiChoi1", dataRow_tranDau2Nguoi["giapNguoiChoi1"]);
//                        cmd.Parameters.AddWithValue("@nangLuongNguoiChoi1", dataRow_tranDau2Nguoi["nangLuongNguoiChoi1"]);
//                        cmd.Parameters.AddWithValue("@tenNguoiChoi2", dataRow_tranDau2Nguoi["tenNguoiChoi2"]);
//                        cmd.Parameters.AddWithValue("@hpNguoiChoi2", dataRow_tranDau2Nguoi["hpNguoiChoi2"]);
//                        cmd.Parameters.AddWithValue("@giapNguoiChoi2", dataRow_tranDau2Nguoi["giapNguoiChoi2"]);
//                        cmd.Parameters.AddWithValue("@nangLuongNguoiChoi2", dataRow_tranDau2Nguoi["nangLuongNguoiChoi2"]);

//                        cmd.ExecuteNonQuery();
//                    }

//                    // Insert các Jewel
//                    foreach (DataRow row in dataTable_jewel.Rows)
//                    {
//                        using (var cmd = new SqlCommand(query_jewel, conn))
//                        {
//                            cmd.Parameters.AddWithValue("@maTranDau", maTranDauMoi);
//                            cmd.Parameters.AddWithValue("@toaDoX", row["toaDoX"]);
//                            cmd.Parameters.AddWithValue("@toaDoY", row["toaDoY"]);
//                            cmd.Parameters.AddWithValue("@loaiJewel", row["loaiJewel"]);

//                            cmd.ExecuteNonQuery();
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Lỗi khi thêm dữ liệu TranDau 2 người vào SQL: " + ex.Message);
//            }
//        }


//        public static void UpdateData_tranDau1Nguoi(DataRow dataRow_tranDau1Nguoi, DataTable dataTable_jewel)
//        {
//            if (dataRow_tranDau1Nguoi == null)
//            {
//                MessageBox.Show("Không có dữ liệu TranDau để cập nhật.");
//                return;
//            }

//            string query_tranDau = @"UPDATE dbo.TranDau
//                            SET 
//                                thoiGian = @thoiGian,
//                                kichCo = @kichCo,
//                                cheDoChoi = @cheDoChoi
//                            WHERE 
//                                maTranDau = @maTranDau";

//            string query_tranDau1Nguoi = @"UPDATE dbo.TranDau_1Nguoi
//                                  SET diemSo = @diemSo,
//                                      tenNguoiChoi = @tenNguoiChoi
//                                  WHERE maTranDau = @maTranDau";

//            string query_jewel = @"UPDATE dbo.Jewel 
//                            SET loaiJewel = @loaiJewel
//                            WHERE maTranDau = @maTranDau AND toaDoX = @toaDoX AND toaDoY = @toaDoY";

//            try
//            {
//                using (var conn = new SqlConnection(connectionString))
//                {
//                    conn.Open();

//                    // Cập nhật bảng TranDau
//                    using (var cmd = new SqlCommand(query_tranDau, conn))
//                    {
//                        cmd.Parameters.AddWithValue("@maTranDau", dataRow_tranDau1Nguoi["maTranDau"]);
//                        cmd.Parameters.AddWithValue("@thoiGian", dataRow_tranDau1Nguoi["thoiGian"]);
//                        cmd.Parameters.AddWithValue("@kichCo", dataRow_tranDau1Nguoi["kichCo"]);
//                        cmd.Parameters.AddWithValue("@cheDoChoi", dataRow_tranDau1Nguoi["cheDoChoi"]);

//                        if (cmd.ExecuteNonQuery() == 0)
//                            MessageBox.Show("Lỗi khi cập nhật dữ liệu TranDau.");
//                    }

//                    // Cập nhật bảng TranDau_1Nguoi
//                    using (var cmd = new SqlCommand(query_tranDau1Nguoi, conn))
//                    {
//                        cmd.Parameters.AddWithValue("@maTranDau", dataRow_tranDau1Nguoi["maTranDau"]);
//                        cmd.Parameters.AddWithValue("@diemSo", dataRow_tranDau1Nguoi["diemSo"]);
//                        cmd.Parameters.AddWithValue("@tenNguoiChoi", dataRow_tranDau1Nguoi["tenNguoiChoi"]);

//                        if (cmd.ExecuteNonQuery() == 0)
//                            MessageBox.Show("Lỗi khi cập nhật dữ liệu TranDau_1Nguoi.");
//                    }

//                    // Cập nhật các Jewel
//                    foreach (DataRow jewelRow in dataTable_jewel.Rows)
//                    {
//                        using (var cmd = new SqlCommand(query_jewel, conn))
//                        {
//                            cmd.Parameters.AddWithValue("@maTranDau", dataRow_tranDau1Nguoi["maTranDau"]);
//                            cmd.Parameters.AddWithValue("@toaDoX", jewelRow["toaDoX"]);
//                            cmd.Parameters.AddWithValue("@toaDoY", jewelRow["toaDoY"]);
//                            cmd.Parameters.AddWithValue("@loaiJewel", jewelRow["loaiJewel"]);

//                            if (cmd.ExecuteNonQuery() == 0)
//                                MessageBox.Show("Lỗi khi cập nhật dữ liệu Jewel.");
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Lỗi khi cập nhật dữ liệu TranDau vào SQL: " + ex.Message);
//            }
//        }
//        public static void UpdateData_tranDau2Nguoi(DataRow dataRow_tranDau2Nguoi, DataTable dataTable_jewel)
//        {
//            if (dataRow_tranDau2Nguoi == null)
//            {
//                MessageBox.Show("Không có dữ liệu TranDau để cập nhật.");
//                return;
//            }
//            string query_tranDau = @"UPDATE dbo.TranDau
//                            SET 
//                                thoiGian = @thoiGian,
//                                kichCo = @kichCo,
//                                cheDoChoi = @cheDoChoi
//                            WHERE 
//                                maTranDau = @maTranDau";
//            string query_tranDau_2Nguoi = @"UPDATE dbo.TranDau_2Nguoi
//                                   SET 
//                                       luotNguoiChoi = @luotNguoiChoi,
//                                       tenNguoiChoi1 = @tenNguoiChoi1,
//                                       hpNguoiChoi1 = @hpNguoiChoi1,
//                                       giapNguoiChoi1 = @giapNguoiChoi1,
//                                       nangLuongNguoiChoi1 = @nangLuongNguoiChoi1,
//                                       tenNguoiChoi2 = @tenNguoiChoi2,
//                                       hpNguoiChoi2 = @hpNguoiChoi2,
//                                       giapNguoiChoi2 = @giapNguoiChoi2,
//                                       nangLuongNguoiChoi2 = @nangLuongNguoiChoi2
//                                   WHERE 
//                                       maTranDau = @maTranDau";
//            string query_jewel = @"UPDATE dbo.Jewel 
//                          SET loaiJewel = @loaiJewel
//                          WHERE maTranDau = @maTranDau AND toaDoX = @toaDoX AND toaDoY = @toaDoY";
//            try
//            {
//                using (var conn = new SqlConnection(connectionString))
//                {
//                    conn.Open();
//                    // Cập nhật bảng TranDau
//                    using (var cmd = new SqlCommand(query_tranDau, conn))
//                    {
//                        cmd.Parameters.AddWithValue("@maTranDau", dataRow_tranDau2Nguoi["maTranDau"]);
//                        cmd.Parameters.AddWithValue("@thoiGian", dataRow_tranDau2Nguoi["thoiGian"]);
//                        cmd.Parameters.AddWithValue("@kichCo", dataRow_tranDau2Nguoi["kichCo"]);
//                        cmd.Parameters.AddWithValue("@cheDoChoi", dataRow_tranDau2Nguoi["cheDoChoi"]);

//                        if (cmd.ExecuteNonQuery() == 0)
//                            MessageBox.Show("Lỗi khi cập nhật dữ liệu TranDau.");
//                    }
//                    // Cập nhật bảng TranDau_2Nguoi
//                    using (var cmd = new SqlCommand(query_tranDau_2Nguoi, conn))
//                    {
//                        cmd.Parameters.AddWithValue("@maTranDau", dataRow_tranDau2Nguoi["maTranDau"]);
//                        cmd.Parameters.AddWithValue("@luotNguoiChoi", dataRow_tranDau2Nguoi["luotNguoiChoi"]);

//                        cmd.Parameters.AddWithValue("@tenNguoiChoi1", dataRow_tranDau2Nguoi["tenNguoiChoi1"]);
//                        cmd.Parameters.AddWithValue("@hpNguoiChoi1", dataRow_tranDau2Nguoi["hpNguoiChoi1"]);
//                        cmd.Parameters.AddWithValue("@giapNguoiChoi1", dataRow_tranDau2Nguoi["giapNguoiChoi1"]);
//                        cmd.Parameters.AddWithValue("@nangLuongNguoiChoi1", dataRow_tranDau2Nguoi["nangLuongNguoiChoi1"]);

//                        cmd.Parameters.AddWithValue("@tenNguoiChoi2", dataRow_tranDau2Nguoi["tenNguoiChoi2"]);
//                        cmd.Parameters.AddWithValue("@hpNguoiChoi2", dataRow_tranDau2Nguoi["hpNguoiChoi2"]);
//                        cmd.Parameters.AddWithValue("@giapNguoiChoi2", dataRow_tranDau2Nguoi["giapNguoiChoi2"]);
//                        cmd.Parameters.AddWithValue("@nangLuongNguoiChoi2", dataRow_tranDau2Nguoi["nangLuongNguoiChoi2"]);

//                        if (cmd.ExecuteNonQuery() == 0)
//                            MessageBox.Show("Lỗi khi cập nhật dữ liệu TranDau_2Nguoi vào SQL");
//                    }
//                    // Cập nhật bảng Jewel
//                    foreach (DataRow dataRow_Jewel in dataTable_jewel.Rows)
//                    {
//                        using (var cmd = new SqlCommand(query_jewel, conn))
//                        {
//                            cmd.Parameters.AddWithValue("@maTranDau", dataRow_tranDau2Nguoi["maTranDau"]);
//                            cmd.Parameters.AddWithValue("@toaDoX", dataRow_Jewel["toaDoX"]);
//                            cmd.Parameters.AddWithValue("@toaDoY", dataRow_Jewel["toaDoY"]);
//                            cmd.Parameters.AddWithValue("@loaiJewel", dataRow_Jewel["loaiJewel"]);

//                            if (cmd.ExecuteNonQuery() == 0)
//                                MessageBox.Show($"Lỗi khi cập nhật dữ liệu của Jewel tại tọa độ ({dataRow_Jewel["toaDoX"]}, {dataRow_Jewel["toaDoY"]})");
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Lỗi khi cập nhật dữ liệu TranDau và Jewel vào SQL: " + ex.Message);
//            }
//        }

//        //----------------------------------------------------------

//        public static void DeleteData(int maTranDau)
//        {
//            string query_tranDau = @"DELETE FROM dbo.TranDau
//                                    WHERE maTranDau = @maTranDau";

//            string query_tranDau_1Nguoi = @"DELETE FROM dbo.TranDau_1Nguoi
//                                    WHERE maTranDau = @maTranDau";

//            string query_tranDau_2Nguoi = @"DELETE FROM dbo.TranDau_2Nguoi
//                                    WHERE maTranDau = @maTranDau";

//            string query_jewel = @"DELETE FROM dbo.Jewel
//                                    WHERE maTranDau = @maTranDau";
//            try
//            {
//                using (var conn = new SqlConnection(connectionString))
//                {
//                    conn.Open();
//                    using (var cmd = new SqlCommand(query_jewel, conn))
//                    {
//                        cmd.Parameters.AddWithValue("@maTranDau", maTranDau);

//                        int rowsAffected = cmd.ExecuteNonQuery();
//                        if (rowsAffected <= 0) MessageBox.Show("Không tìm thấy dữ liệu để xóa.");
//                    }
//                    using (var cmd = new SqlCommand(query_tranDau_1Nguoi, conn))
//                    {
//                        cmd.Parameters.AddWithValue("@maTranDau", maTranDau);

//                        cmd.ExecuteNonQuery();
//                    }
//                    using (var cmd = new SqlCommand(query_tranDau_2Nguoi, conn))
//                    {
//                        cmd.Parameters.AddWithValue("@maTranDau", maTranDau);

//                        cmd.ExecuteNonQuery();
//                    }
//                    using (var cmd = new SqlCommand(query_tranDau, conn))
//                    {
//                        cmd.Parameters.AddWithValue("@maTranDau", maTranDau);

//                        int rowsAffected = cmd.ExecuteNonQuery();
//                        if (rowsAffected <= 0) MessageBox.Show("Không tìm thấy dữ liệu để xóa.");
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Lỗi khi xóa dữ liệu TranDau từ SQL: " + ex.Message);
//            }
//        }
//    }
//}
