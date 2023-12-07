using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystemApp.MODEL
{
    [Serializable]
    public class ViewSell
    {
        public string CompanyName { get; set; }
        public string ItemName { get; set; }
        public string SaleQuantity { get; set; }
    }
}