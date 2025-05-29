using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JewelGame._Scripts
{
    public class DatabaseGame
    {
        private const string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=GameKimCuong;Integrated Security=True;";
        public class Data_tranDau
        {
            public int maTranDau;

            public int kichCo;
            public int thoiGian;

            public string tenNguoiChoi1;
            public int hpNguoiChoi1;
            public int giapNguoiChoi1;
            public int noNguoiChoi1;
            public int nangLuongNguoiChoi1;

            public string tenNguoiChoi2;
            public int hpNguoiChoi2;
            public int giapNguoiChoi2;
            public int noNguoiChoi2;
            public int nangLuongNguoiChoi2;
        }
        public class Data_jewel
        {
            public int toaDoX;
            public int toaDoY;
            public int loaiJewel;
        }
        public static DataTable GetDataTable_TranDau()
        {
            var result = new DataTable();
            string query = "SELECT * FROM dbo.TranDau";

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu TranDau từ SQL: " + ex.Message);
            }

            return result;
        }
        public static DataTable GetDataTable_Jewels( int MaTranDau)
        {
            var result = new DataTable();

            string query = @"SELECT * FROM dbo.Jewel
                             WHERE maTranDau = @maTranDau";

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maTranDau", MaTranDau);

                        using (var adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(result);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải Jewel dữ liệu từ SQL: " + ex.Message);
            }
            return result;
        }
        public static Data_tranDau InsertData(Data_tranDau newData, DataTable newJewels)
        {
            string query_tranDau = @"INSERT INTO dbo.TranDau ( thoiGian, kichCo,
                                        tenNguoiChoi1, hpNguoiChoi1, giapNguoiChoi1, noNguoiChoi1, nangLuongNguoiChoi1,
                                        tenNguoiChoi2, hpNguoiChoi2, giapNguoiChoi2, noNguoiChoi2, nangLuongNguoiChoi2
                                        )
                                    OUTPUT INSERTED.maTranDau
                                    VALUES ( @thoiGian, @kichCo,
                                        @tenNguoiChoi1, @hpNguoiChoi1, @giapNguoiChoi1, @noNguoiChoi1, @nangLuongNguoiChoi1,
                                        @tenNguoiChoi2, @hpNguoiChoi2, @giapNguoiChoi2, @noNguoiChoi2, @nangLuongNguoiChoi2
                                    )";

            string query_jewel = @"INSERT INTO dbo.Jewel (maTranDau, toaDoX, toaDoY, loaiJewel)
                                    VALUES (@maTranDau, @toaDoX, @toaDoY, @loaiJewel)";

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    int maTranDauMoiTao;

                    using (var cmd = new SqlCommand(query_tranDau, conn))
                    {
                        cmd.Parameters.AddWithValue("@thoiGian", newData.thoiGian);
                        cmd.Parameters.AddWithValue("@kichCo", newData.kichCo);

                        cmd.Parameters.AddWithValue("@tenNguoiChoi1", newData.tenNguoiChoi1);
                        cmd.Parameters.AddWithValue("@hpNguoiChoi1", newData.hpNguoiChoi1);
                        cmd.Parameters.AddWithValue("@giapNguoiChoi1", newData.giapNguoiChoi1);
                        cmd.Parameters.AddWithValue("@noNguoiChoi1", newData.noNguoiChoi1);
                        cmd.Parameters.AddWithValue("@nangLuongNguoiChoi1", newData.nangLuongNguoiChoi1);

                        cmd.Parameters.AddWithValue("@tenNguoiChoi2", newData.tenNguoiChoi2);
                        cmd.Parameters.AddWithValue("@hpNguoiChoi2", newData.hpNguoiChoi2);
                        cmd.Parameters.AddWithValue("@giapNguoiChoi2", newData.giapNguoiChoi2);
                        cmd.Parameters.AddWithValue("@noNguoiChoi2", newData.noNguoiChoi2);
                        cmd.Parameters.AddWithValue("@nangLuongNguoiChoi2", newData.nangLuongNguoiChoi2);

                        maTranDauMoiTao = (int)cmd.ExecuteScalar(); // Lấy khóa chính được sinh ra
                        newData.maTranDau = maTranDauMoiTao;
                    }

                    foreach (DataRow dataRow in newJewels.Rows)
                    {
                        using (var cmd = new SqlCommand(query_jewel, conn))
                        {
                            cmd.Parameters.AddWithValue("@maTranDau", maTranDauMoiTao);
                            cmd.Parameters.AddWithValue("@toaDoX", dataRow["toaDoX"]);
                            cmd.Parameters.AddWithValue("@toaDoY", dataRow["toaDoY"]);
                            cmd.Parameters.AddWithValue("@loaiJewel", dataRow["loaiJewel"]);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dữ liệu TranDau vào SQL: " + ex.Message);
            }
            return newData;
        }
        public static void UpdateData(Data_tranDau newData, DataTable newJewels)
        {
            string query_tranDau = @"UPDATE dbo.TranDau
                                    SET 
                                        thoiGian = @thoiGian,
                                        tenNguoiChoi1 = @tenNguoiChoi1,
                                        hpNguoiChoi1 = @hpNguoiChoi1,
                                        giapNguoiChoi1 = @giapNguoiChoi1,
                                        noNguoiChoi1 = @noNguoiChoi1,
                                        nangLuongNguoiChoi1 = @nangLuongNguoiChoi1,
                                        tenNguoiChoi2 = @tenNguoiChoi2,
                                        hpNguoiChoi2 = @hpNguoiChoi2,
                                        giapNguoiChoi2 = @giapNguoiChoi2,
                                        noNguoiChoi2 = @noNguoiChoi2,
                                        nangLuongNguoiChoi2 = @nangLuongNguoiChoi2
                                    WHERE 
                                        maTranDau = @maTranDau";

            string query_jewel = @"UPDATE dbo.Jewel 
                                    SET
                                        loaiJewel = @loaiJewel
                                    WHERE
                                        maTranDau = @maTranDau AND toaDoX = @toaDoX AND toaDoY = @toaDoY";

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(query_tranDau, conn))
                    {
                        cmd.Parameters.AddWithValue("@maTranDau", newData.maTranDau);
                        cmd.Parameters.AddWithValue("@thoiGian", newData.thoiGian);

                        cmd.Parameters.AddWithValue("@tenNguoiChoi1", newData.tenNguoiChoi1);
                        cmd.Parameters.AddWithValue("@hpNguoiChoi1", newData.hpNguoiChoi1);
                        cmd.Parameters.AddWithValue("@giapNguoiChoi1", newData.giapNguoiChoi1);
                        cmd.Parameters.AddWithValue("@noNguoiChoi1", newData.noNguoiChoi1);
                        cmd.Parameters.AddWithValue("@nangLuongNguoiChoi1", newData.nangLuongNguoiChoi1);

                        cmd.Parameters.AddWithValue("@tenNguoiChoi2", newData.tenNguoiChoi2);
                        cmd.Parameters.AddWithValue("@hpNguoiChoi2", newData.hpNguoiChoi2);
                        cmd.Parameters.AddWithValue("@giapNguoiChoi2", newData.giapNguoiChoi2);
                        cmd.Parameters.AddWithValue("@noNguoiChoi2", newData.noNguoiChoi2);
                        cmd.Parameters.AddWithValue("@nangLuongNguoiChoi2", newData.nangLuongNguoiChoi2);

                        if (cmd.ExecuteNonQuery() == 0) MessageBox.Show("Lỗi khi cập nhật lại dữ liệu của trận đấu");
                    }

                    foreach (DataRow dataRow in newJewels.Rows)
                    {
                        using (var cmd = new SqlCommand(query_jewel, conn))
                        {
                            cmd.Parameters.AddWithValue("@maTranDau", newData.maTranDau);
                            cmd.Parameters.AddWithValue("@toaDoX", dataRow["toaDoX"]);
                            cmd.Parameters.AddWithValue("@toaDoY", dataRow["toaDoY"]);
                            cmd.Parameters.AddWithValue("@loaiJewel", dataRow["loaiJewel"]);

                            if (cmd.ExecuteNonQuery() == 0) MessageBox.Show("Lỗi khi cập nhật lại dữ liệu của jewel");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật dữ liệu TranDau vào SQL: " + ex.Message);
            }
        }
        public static void UpdateData_TranDau(Data_tranDau newData)
        {
            string query_tranDau = @"UPDATE dbo.TranDau
                                    SET 
                                        thoiGian = @thoiGian,
                                        tenNguoiChoi1 = @tenNguoiChoi1,
                                        hpNguoiChoi1 = @hpNguoiChoi1,
                                        giapNguoiChoi1 = @giapNguoiChoi1,
                                        noNguoiChoi1 = @noNguoiChoi1,
                                        nangLuongNguoiChoi1 = @nangLuongNguoiChoi1,
                                        tenNguoiChoi2 = @tenNguoiChoi2,
                                        hpNguoiChoi2 = @hpNguoiChoi2,
                                        giapNguoiChoi2 = @giapNguoiChoi2,
                                        noNguoiChoi2 = @noNguoiChoi2,
                                        nangLuongNguoiChoi2 = @nangLuongNguoiChoi2
                                    WHERE 
                                        maTranDau = @maTranDau";

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(query_tranDau, conn))
                    {
                        cmd.Parameters.AddWithValue("@maTranDau", newData.maTranDau);
                        cmd.Parameters.AddWithValue("@thoiGian", newData.thoiGian);

                        cmd.Parameters.AddWithValue("@tenNguoiChoi1", newData.tenNguoiChoi1);
                        cmd.Parameters.AddWithValue("@hpNguoiChoi1", newData.hpNguoiChoi1);
                        cmd.Parameters.AddWithValue("@giapNguoiChoi1", newData.giapNguoiChoi1);
                        cmd.Parameters.AddWithValue("@noNguoiChoi1", newData.noNguoiChoi1);
                        cmd.Parameters.AddWithValue("@nangLuongNguoiChoi1", newData.nangLuongNguoiChoi1);

                        cmd.Parameters.AddWithValue("@tenNguoiChoi2", newData.tenNguoiChoi2);
                        cmd.Parameters.AddWithValue("@hpNguoiChoi2", newData.hpNguoiChoi2);
                        cmd.Parameters.AddWithValue("@giapNguoiChoi2", newData.giapNguoiChoi2);
                        cmd.Parameters.AddWithValue("@noNguoiChoi2", newData.noNguoiChoi2);
                        cmd.Parameters.AddWithValue("@nangLuongNguoiChoi2", newData.nangLuongNguoiChoi2);

                        if (cmd.ExecuteNonQuery() == 0) MessageBox.Show("Lỗi khi cập nhật dữ liệu Jewel vào SQL");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật dữ liệu Jewel vào SQL: " + ex.Message);
            }
        }
        public static void UpdateData_Jewel(int maTranDau, DataTable newJewels)
        {
            string query_jewel = @"UPDATE dbo.Jewel 
                                    SET
                                        loaiJewel = @loaiJewel
                                    WHERE
                                        maTranDau = @maTranDau AND toaDoX = @toaDoX AND toaDoY = @toaDoY";

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    foreach (DataRow dataRow in newJewels.Rows)
                    {
                        using (var cmd = new SqlCommand(query_jewel, conn))
                        {
                            cmd.Parameters.AddWithValue("@maTranDau", maTranDau);
                            cmd.Parameters.AddWithValue("@toaDoX", dataRow["toaDoX"]);
                            cmd.Parameters.AddWithValue("@toaDoY", dataRow["toaDoY"]);
                            cmd.Parameters.AddWithValue("@loaiJewel", dataRow["loaiJewel"]);

                            if (cmd.ExecuteNonQuery() == 0) MessageBox.Show("Lỗi khi cập nhật lại dữ liệu của jewel");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật dữ liệu TranDau vào SQL: " + ex.Message);
            }
        }
        //----------------------------------------------------------
        public static Data_tranDau GetData_TranDau(int MaTranDau)
        {
            var result = new Data_tranDau();
            string query = @"SELECT * FROM dbo.TranDau
                            WHERE maTranDau = @maTranDau";

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maTranDau", MaTranDau);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                result.maTranDau = Convert.ToInt32(reader["maTranDau"]);
                                result.thoiGian = Convert.ToInt32(reader["thoiGian"]);
                                result.kichCo = Convert.ToInt32(reader["kichCo"]);

                                result.tenNguoiChoi1 = Convert.ToString(reader["tenNguoiChoi1"]);
                                result.hpNguoiChoi1 = Convert.ToInt32(reader["hpNguoiChoi1"]);
                                result.giapNguoiChoi1 = Convert.ToInt32(reader["giapNguoiChoi1"]);
                                result.noNguoiChoi1 = Convert.ToInt32(reader["noNguoiChoi1"]);
                                result.nangLuongNguoiChoi1 = Convert.ToInt32(reader["nangLuongNguoiChoi1"]);

                                result.tenNguoiChoi2 = Convert.ToString(reader["tenNguoiChoi2"]);
                                result.hpNguoiChoi2 = Convert.ToInt32(reader["hpNguoiChoi2"]);
                                result.giapNguoiChoi2 = Convert.ToInt32(reader["giapNguoiChoi2"]);
                                result.noNguoiChoi2 = Convert.ToInt32(reader["noNguoiChoi2"]);
                                result.nangLuongNguoiChoi2 = Convert.ToInt32(reader["nangLuongNguoiChoi2"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu TranDau từ SQL: " + ex.Message);
            }

            return result;
        }

        public static void DeleteData(int maTranDau)
        {
            var result = new Data_tranDau();

            string query_tranDau = @"DELETE FROM dbo.TranDau
                                    WHERE maTranDau = @maTranDau";
            string query_jewel = @"DELETE FROM dbo.Jewel
                                    WHERE maTranDau = @maTranDau";
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(query_jewel, conn))
                    {
                        cmd.Parameters.AddWithValue("@maTranDau", maTranDau);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected <= 0) MessageBox.Show("Không tìm thấy dữ liệu để xóa.");
                    }
                    using (var cmd = new SqlCommand(query_tranDau, conn))
                    {
                        cmd.Parameters.AddWithValue("@maTranDau", maTranDau);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected <= 0) MessageBox.Show("Không tìm thấy dữ liệu để xóa.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dữ liệu TranDau từ SQL: " + ex.Message);
            }
        }
    }
}
