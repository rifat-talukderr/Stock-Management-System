using StockManagementSystemApp.DAL;
using StockManagementSystemApp.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystemApp.BLL
{
    public class StockOutManager
    {
        StockOutGateWay stockOutgateway = new StockOutGateWay();
        //sell
        public void SaveStockOutItem(StockOut stockOutItem)
        {
            bool exitSellcheck = stockOutgateway.IsExicedStockOutItem(stockOutItem);
            if (exitSellcheck == false)
            {
                stockOutgateway.SaveStockOutItem(stockOutItem);
            }
            else
            {
                stockOutgateway.UpdateStockOutItem(stockOutItem);
            }

        }
    }
}