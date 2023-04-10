using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Nimap_Task.Models;

namespace Nimap_Task.Edit
{
    public class Edit_Product
    {
        int _return = 0;
        SqlConnection _sqlCon;
        SqlCommand _sqlCmd;
        Connection _connection;
        SqlDataAdapter da;
        public Product_Model Reportlist(int id)
        {


            try
            {
                List<Product_Model> _List = new List<Product_Model>();
                Connection Con = new Connection();
                DataTable dt = new DataTable();
                dt = Con.EditData(id);

                Product_Model model = new Product_Model();
                model.Product_Id = Convert.ToInt32(dt.Rows[0]["product_id"]);
                model.Product_Name = dt.Rows[0]["product_name"].ToString();
                model.Category_Id = Convert.ToInt32(dt.Rows[0]["category_id"]);



                return model;
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}