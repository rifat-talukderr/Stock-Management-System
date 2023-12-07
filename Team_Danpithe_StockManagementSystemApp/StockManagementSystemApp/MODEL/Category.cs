using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystemApp.MODEL
{
    public class Category
    {
      
        public int CategoryID { get; set; }
        public string CategoryName{get;set;}

        public Category()
        {

        }
        public Category(int category,string categoryName)
        {
            CategoryID = category;
            CategoryName = categoryName;
        }
    }
}