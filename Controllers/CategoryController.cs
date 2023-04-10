using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nimap_Task.Models;
using Nimap_Task.Report;
namespace Nimap_Task.Controllers
{
    public class CategoryController : Controller
    {
        int _return = 0;
        SqlConnection _sqlCon;
        SqlCommand _sqlCmd;
        Connection _connection;
        SqlDataAdapter da;
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Category_Parial()
        {

            return View();

        }
        public ActionResult Category_Report()
        {
            
            return View();
        }
        public ActionResult SaveorUpdateCategory(Category_Model model)
        {
            string Flag = "";
            try
            {
                if (model.Categoty_Id == 0)
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
                _sqlCmd.CommandText = "sp_category";
                _sqlCmd.CommandType = CommandType.StoredProcedure;
                _sqlCmd.Connection = _sqlCon;

                _sqlCmd.Parameters.AddWithValue("@Id", model.Categoty_Id);
                _sqlCmd.Parameters.AddWithValue("@Name", model.Categoty_Name);
               
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
           
            return RedirectToAction("Category_Parial");
        }
    }
}