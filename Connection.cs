using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace QLNV
{
    internal class Connection
    {
       private static string stringConn = "Data Source=LAPTOP-KM6LD1T8\\PHAMVANHUONG;Initial Catalog=QLNV;Integrated Security=True";
        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(stringConn);
        }
    }
}
