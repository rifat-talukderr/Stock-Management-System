using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystemApp.MODEL
{
    public class StockOut
    {
        public int StockOutid { get; set; }
        public string Date { get; set; }
        public int Itemid { get; set; }
        public int Quantity { get; set; }
        public string ItemType { get; set; }

    }
}