using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;
using System.Data.SqlTypes;

namespace QLNV
{
    internal class Modify
    {
        SqlDataAdapter adapter; //Truy xuất dữ liệu vào bảng
        SqlCommand command; //truy vấn

        public DataTable getAllNhanVien()
        {
            DataTable dataTable = new DataTable();
            string sql = "Select * from NV1";
            using (SqlConnection conn = Connection.GetSqlConnection())
            {
                conn.Open();
                adapter = new SqlDataAdapter(sql, conn);
                
                // hoac
                //command = conn.CreateCommand();
                //adapter.SelectCommand = command;
                dataTable.Clear();
                adapter.Fill(dataTable); 
                conn.Close();
            }

            return dataTable;
        }
        public bool insert(NhanVien nv)
        {
            string sql = "Insert into NV1 values (@maNV,@tenNV,@ngaySinh,@GioiTinh,@DiaChi,@soDT)";
            using(SqlConnection conn = Connection.GetSqlConnection())
            {
                try
                {
                    conn.Open();
                    command = new SqlCommand(sql, conn);
                    //hoặc
                    //command = conn.CreateCommand();
                    //command.CommandText = sql;
                    command.Parameters.Add("@maNV", SqlDbType.NVarChar).Value = nv.Id;
                    command.Parameters.Add("@tenNV", SqlDbType.NVarChar).Value = nv.Name;
                    command.Parameters.Add("@ngaySinh", SqlDbType.Date).Value = nv.DateOfBirth.ToShortDateString();
                    command.Parameters.Add("@gioiTinh", SqlDbType.NVarChar).Value = nv.Gender;
                    command.Parameters.Add("@diaChi", SqlDbType.NVarChar).Value = nv.Address;
                    command.Parameters.Add("@soDt", SqlDbType.NVarChar).Value = nv.PhoneNumber;
                    
                    command.ExecuteNonQuery();
                    
                }
                catch(Exception ex) 
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
                finally { conn.Close(); }
                return true;
            }
        }

        public int update(NhanVien nv)
        {
            string sql = "update NV1 set maNV=@maNV,tenNV=@tenNV," +
                "ngaySinh=@ngaySinh,gioiTinh=@GioiTinh,diaChi=@DiaChi,sodt=@soDT" +
                " where maNV=@maNV";
            using (SqlConnection conn = Connection.GetSqlConnection())
            {
                int i = -1;
                try
                {
                    conn.Open();
                    command = new SqlCommand(sql, conn);
                    //hoặc
                    //command = conn.CreateCommand();
                    //command.CommandText = sql;
                    command.Parameters.Add("@maNV", SqlDbType.NVarChar).Value = nv.Id;
                    command.Parameters.Add("@tenNV", SqlDbType.NVarChar).Value = nv.Name;
                    command.Parameters.Add("@ngaySinh", SqlDbType.Date).Value = nv.DateOfBirth.ToShortDateString();
                    command.Parameters.Add("@gioiTinh", SqlDbType.NVarChar).Value = nv.Gender;
                    command.Parameters.Add("@diaChi", SqlDbType.NVarChar).Value = nv.Address;
                    command.Parameters.Add("@soDt", SqlDbType.NVarChar).Value = nv.PhoneNumber;

                   i = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return i;
                }
                finally { conn.Close(); }
                return i;
            }
        }
        public int delete(string maNV)
        {
            int i = -1;
            string sql = "delete from NV1 where maNV = '" + maNV + "'";
            using (SqlConnection conn = Connection.GetSqlConnection())
            {
                try
                {
                    conn.Open();
                    command = new SqlCommand(sql, conn);
                    i = command.ExecuteNonQuery();

                }
                catch(Exception ex) 
                {
                    MessageBox.Show(ex.Message);
                    return i;
                }finally { conn.Close(); }
            }
            return i;
        }

    }
}
