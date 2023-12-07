using StockManagementSystemApp.DAL;
using StockManagementSystemApp.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystemApp.BLL
{
    public class StockInManager
    {
        StockInGateWay stockgateway = new StockInGateWay();
        public List<StockIn> GetAllitem(int companyId)
        {
            return stockgateway.GetAllitem(companyId);
        }

        public string UpdateStockById(int companyId, int ItemId, int quanty)
        {
           int row= stockgateway.UpdateStockById(companyId, ItemId, quanty);
           if (row > 0)
           {
               return "Successfully Stock In";
           }
           else
           {
               return "Failed";
           }
        }
    }
}