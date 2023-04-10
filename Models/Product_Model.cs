using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nimap_Task.Models
{
    public class Product_Model
    {
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
        public int Category_Id { get; set; }
       
        public string Categoty_Name { get; set; }
    }
}