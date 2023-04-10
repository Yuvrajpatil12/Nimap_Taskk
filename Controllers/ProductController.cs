using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nimap_Task.Models;
using Nimap_Task.Report;
using Nimap_Task.Edit;
using Nimap_Task.Delete;
namespace Nimap_Task.Controllers
{
    public class ProductController : Controller
    {
        int _return = 0;
        SqlConnection _sqlCon;
        SqlCommand _sqlCmd;
        Connection _connection;
        SqlDataAdapter da;
        // GET: Product
        public ActionResult Index()
        {
           
            //ViewBag.category_name = Category();
            return View();
        }
        public ActionResult Product_Partial()
        {
           // ViewBag.category_name = Category();
            return View();

        }
        public ActionResult EditData(int id)
        {

            Product_Model model = new Product_Model();
             Edit_Product edit = new Edit_Product();
            model = edit.Reportlist(id);

            return PartialView("Product_Partial", model);
        }
        public ActionResult DeleteData(int id)
        {

            Product_Model model = new Product_Model();
            Delete_Product delete = new Delete_Product();
            model = delete.ReportDelete(id);

            return RedirectToAction("Product_Partial");
        }
        public ActionResult Product_Partial_s()
        {
            
            Product_Report report = new Product_Report();
            var data = report.Product_Report_s("sp_product_s");
            return View(data);
           

        }
        public ActionResult Product_Report()
        {
            Product_Report report = new Product_Report();
            var data = report.Report("sp_repot");
            return View(data);
        }

        public ActionResult SaveOrUpdateProduct(Product_Model model)
        {
            string Flag = "";
            try
            {
                if (model.Product_Id == 0)
                {
                    Flag = "I";
                }
                else
                {
                    Flag = "U";
                }
                _connection = new Connection();
                _sqlCon = _connection.Connect();
                _sqlCmd = new SqlCommand();
                _sqlCmd.CommandText = "sp_product";
                _sqlCmd.CommandType = CommandType.StoredProcedure;
                _sqlCmd.Connection = _sqlCon;

                _sqlCmd.Parameters.AddWithValue("@Id", model.Product_Id);
                _sqlCmd.Parameters.AddWithValue("@Name", model.Product_Name);
                _sqlCmd.Parameters.AddWithValue("@CID", model.Category_Id);

                _sqlCmd.Parameters.AddWithValue("@Flag", Flag);
                _sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _sqlCmd.Dispose();
                _sqlCon.Close();
            }

            return RedirectToAction("Product_Partial");
        }
        //public List<SelectListItem> Category()
        //{
        //    DataTable dt = new DataTable();

        //    var list = new List<SelectListItem>();
        //    list.Add(new SelectListItem { Value = "0", Text = "--Select--" });
        //    // clsfuncion = new Clsfuntion(Configuration);
        //    dt = _connection.FillDropDown("select category_id,category_name from category_table");
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        list.Add(new SelectListItem
        //        {
        //            Value = dt.Rows[i]["category_id"].ToString(),
        //            Text = dt.Rows[i]["category_name"].ToString()
        //        });
        //    }

        //    return list;


        //}

    }
    
}