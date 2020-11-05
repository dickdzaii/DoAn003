using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace DoAn003.Models
{
    public class Connecting
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        string str = ConfigurationManager.ConnectionStrings["strconnect"].ConnectionString;
        DataTable dt;
        public Connecting()
        {
            cn = new SqlConnection(str);
        }
        public DataTable getdata(string query)
        {
            da = new SqlDataAdapter(query, cn);
            dt = new DataTable();
            da.Fill(dt);
            cn.Close();
            return dt;
        }
        public void ghiDuLieu(string query)
        {
            cn.Open();
            cmd = new SqlCommand(query, cn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cn.Close();
        }
    }
}