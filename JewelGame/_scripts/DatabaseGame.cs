using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_JewelGame._Scripts
{
    public class DatabaseGame
    {
        private const string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=GameKimCuong;Integrated Security=True;";
        public class Data_tranDau
        {
            public int maTranDau;
            public string tenNguoiChoi1;
            public string tenNguoiChoi2;
        }
        public class Data_jewel
        {
            public int maTranDau;
            public int toaDoX;
            public int toaDoY;
            public int loaiJewel;
        }
        public static List<Data_tranDau> GetData_ListTranDau()
        {
            var result = new List<Data_tranDau>();
            string query = "SELECT * FROM dbo.TranDau";

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int key = reader.GetInt32(reader.GetOrdinal("maTranDau"));
                            result.Add(new Data_tranDau()
                            {
                                maTranDau = Convert.ToInt32(reader["maTranDau"]),
                                tenNguoiChoi1 = Convert.ToString(reader["tenNguoiChoi1"]),
                                tenNguoiChoi2 = Convert.ToString(reader["tenNguoiChoi2"]),
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu từ SQL: " + ex.Message);
            }

            return result;
        }
        public static Data_tranDau GetData_TranDau(int MaTranDau)
        {
            var result = new Data_tranDau();
            string query = "SELECT * FROM dbo.TranDau " +
                        "WHERE maTranDau = @maTranDau";

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
                            reader.Read();

                            result.maTranDau = Convert.ToInt32(reader["maTranDau"]);
                            result.tenNguoiChoi1 = Convert.ToString(reader["tenNguoiChoi1"]);
                            result.tenNguoiChoi2 = Convert.ToString(reader["tenNguoiChoi2"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu từ SQL: " + ex.Message);
            }

            return result;
        }
        public static List<Data_jewel> GetData_JewelGrid(int MaTranDau)
        {
            var result = new List<Data_jewel>();

            string query = "SELECT * FROM dbo.Jewel " +
                            "WHERE maTranDau = @maTranDau";

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
                            while (reader.Read())
                            {
                                result.Add(new Data_jewel
                                {
                                    maTranDau = Convert.ToInt32(reader["maTranDau"]),
                                    toaDoX = Convert.ToInt32(reader["toaDoX"]),
                                    toaDoY = Convert.ToInt32(reader["toaDoY"]),
                                    loaiJewel = Convert.ToInt32(reader["loaiJewel"]),
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu từ SQL Jewels: " + ex.Message);
            }

            return result;
        }

        public static void InsertData(Data_tranDau newData, List<DatabaseGame.Data_jewel> newJewels)
        {
            string query_tranDau = "INSERT INTO dbo.TranDau (tenNguoiChoi1, tenNguoiChoi2) " +
                                   "OUTPUT INSERTED.maTranDau " +
                                   "VALUES (@tenNguoiChoi1, @tenNguoiChoi2)";
            string query_jewel = "INSERT INTO dbo.Jewel (maTranDau, toaDoX, toaDoY, loaiJewel) " +
                                 "VALUES (@maTranDau, @toaDoX, @toaDoY, @loaiJewel)";

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    int maTranDau;
                    using (var cmd = new SqlCommand(query_tranDau, conn))
                    {
                        cmd.Parameters.AddWithValue("@tenNguoiChoi1", newData.tenNguoiChoi1);
                        cmd.Parameters.AddWithValue("@tenNguoiChoi2", newData.tenNguoiChoi2);

                        maTranDau = (int)cmd.ExecuteScalar();
                    }

                    foreach (var jewel in newJewels)
                    {
                        using (var cmd = new SqlCommand(query_jewel, conn))
                        {
                            cmd.Parameters.AddWithValue("@maTranDau", maTranDau);
                            cmd.Parameters.AddWithValue("@toaDoX", jewel.toaDoX);
                            cmd.Parameters.AddWithValue("@toaDoY", jewel.toaDoY);
                            cmd.Parameters.AddWithValue("@loaiJewel", jewel.loaiJewel); // fallback nếu null

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu từ SQL Jewels: " + ex.Message);
            }
        }

        public static void DeleteData(int maTranDau)
        {
            var result = new Data_tranDau();

            string query_tranDau = "DELETE FROM dbo.TranDau " +
                            "WHERE maTranDau = @maTranDau";
            string query_jewel = "DELETE FROM dbo.Jewel " +
                            "WHERE maTranDau = @maTranDau";
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
                MessageBox.Show("Lỗi khi tải dữ liệu từ SQL Jewels: " + ex.Message);
            }
        }
    }
}
