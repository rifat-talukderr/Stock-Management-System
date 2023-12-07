using StockManagementSystemApp.DAL;
using StockManagementSystemApp.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystemApp.BLL
{
    public class ViewSellManger
    {
        ViewSalesGateWay viewSalesGateWay = new ViewSalesGateWay();
        public List<ViewSell> SearchByDate(string fromdate, string todate)
        {
            return viewSalesGateWay.SearchByDate(fromdate, todate);
        }
    }
}