using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Nimap_Task
{
    public class Connection
    {
        SqlConnection _sqlConn = null;
        public static string connectionString = @"Data Source=DESKTOP-VTQDCBN; Initial Catalog=Nimap_task;integrated security=True";

        public SqlConnection Connect()
        {
            try
            {
                _sqlConn = new SqlConnection(connectionString);
                _sqlConn.Close();
                if (_sqlConn.State == ConnectionState.Open)
                    _sqlConn.Close();
                _sqlConn.Open();
            }
            catch (Exception ex)
            {

            }

            return _sqlConn;
        }
        public DataTable FillGridView(String Storeproname)
        {
            try
            {
                Connection sp = new Connection();
                SqlConnection sqlconn = sp.Connect();
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = Storeproname;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = sqlconn;

                DataTable dt = new DataTable();
                dt = null;
                dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable EditData(int id)
        {
            try
            {
                Connection sp = new Connection();
                SqlConnection sqlconn = sp.Connect();
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.CommandText = "sp_product_edit";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = sqlconn;

                DataTable dt = new DataTable();
                dt = null;
                dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable DeleteData(int id)
        {
            try
            {
                Connection sp = new Connection();
                SqlConnection sqlconn = sp.Connect();
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.CommandText = "sp_product_delete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = sqlconn;

                DataTable dt = new DataTable();
                dt = null;
                dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    
        public DataTable FillDropDown(string Qurey)
        {
            Connection sp = new Connection();
            // SqlConnection sqlCon = new SqlConnection();
            SqlConnection sqlcon = null;
             sqlcon = sp.Connect();
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            cmd = new SqlCommand();
            cmd.Connection = sqlcon;
           SqlDataAdapter da = new SqlDataAdapter(Qurey, sqlcon);
            da.Fill(dt);
            return dt;
        }
    }
}
