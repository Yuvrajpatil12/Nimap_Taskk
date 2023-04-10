using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Nimap_Task.Models;

namespace Nimap_Task.Delete
{
    public class Delete_Product
    {
        int _return = 0;
        SqlConnection _sqlCon;
        SqlCommand _sqlCmd;
        Connection _connection;
        SqlDataAdapter da;
        public Product_Model ReportDelete(int id)
        {


            try
            {
                List<Product_Model> _List = new List<Product_Model>();
                Connection Con = new Connection();
                DataTable dt = new DataTable();
                dt = Con.DeleteData(id);

                Product_Model model = new Product_Model();

                model.Product_Id = id;

                return model;
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}