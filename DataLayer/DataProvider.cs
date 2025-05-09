using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataProvider
    {
        public string connString = "Data Source=.\\SQLEXPRESS;Initial Catalog=CoffeeShop;Integrated Security=True;TrustServerCertificate=True";
        public SqlConnection conn;
        public DataProvider() {
            conn = new SqlConnection(connString);
        }

        public DataTable MyExecuteReader(string sql,CommandType type,List<SqlParameter> parameters = null)
        {
            SqlCommand cmd = new SqlCommand(sql,conn);
            cmd.CommandType = type;
            if (parameters != null)
            {
                foreach (var item in parameters)
                {
                    cmd.Parameters.Add(item);
                }
            }

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
                return dt;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public void MyExecuteNonQuery(string sql, CommandType type,DataTable dt, List<SqlParameter> parameters = null)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = type;
            if (parameters != null)
            {
                foreach (var item in parameters)
                {
                    cmd.Parameters.Add(item);
                }
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            try
            {
                da.Update(dt);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
