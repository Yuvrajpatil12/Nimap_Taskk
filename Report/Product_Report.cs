using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nimap_Task.Models;
using System.Data;

namespace Nimap_Task.Report
{
    public class Product_Report
    {
        int _return = 0;
        SqlConnection _sqlCon;
        SqlCommand _sqlCmd;
        Connection _connection;
        SqlDataAdapter da;
        public IEnumerable<Product_Model> Report(string sp_reportt)
        {

            try
            {
                List<Product_Model> _List = new List<Product_Model>();
                Connection Con = new Connection();
                DataTable dt = new DataTable();
                dt = Con.FillGridView(sp_reportt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Product_Model model = new Product_Model();
                    model.Product_Id = Convert.ToInt32(dt.Rows[i]["product_id"]);
                    model.Product_Name = dt.Rows[i]["product_name"].ToString();
                    model.Category_Id = Convert.ToInt32(dt.Rows[i]["category_id"]);
                    model.Categoty_Name = dt.Rows[i]["category_name"].ToString();


                    _List.Add(model);

                }


                return _List;
            }

            catch (Exception Ex)
            {
                throw Ex;
            }


        }

        public IEnumerable<Product_Model> Product_Report_s(string sp_reportt)
        {

            try
            {
                List<Product_Model> _List = new List<Product_Model>();
                Connection Con = new Connection();
                DataTable dt = new DataTable();
                dt = Con.FillGridView(sp_reportt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Product_Model model = new Product_Model();
                    model.Product_Id = Convert.ToInt32(dt.Rows[i]["product_id"]);
                    model.Product_Name = dt.Rows[i]["product_name"].ToString();
                   


                    _List.Add(model);

                }


                return _List;
            }

            catch (Exception Ex)
            {
                throw Ex;
            }


        }
    }
}