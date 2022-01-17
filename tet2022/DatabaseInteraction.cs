using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace tet2022
{
    class DatabaseInteraction
    {
        string chuoikn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Tet Nham Dan\tet2022\tet2022\db.mdf;Integrated Security=True";
        SqlConnection conn;

        public DatabaseInteraction()
        {
            conn = new SqlConnection(chuoikn);
        }

        public object TruyVan(string sql) {
            SqlCommand cm = new SqlCommand(sql, conn);
            conn.Open();
            object result = cm.ExecuteScalar();
            conn.Close();
            return result;
        }

        public DataTable HienThiDuLieu(string sql)
        {
            SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }

    }
}
