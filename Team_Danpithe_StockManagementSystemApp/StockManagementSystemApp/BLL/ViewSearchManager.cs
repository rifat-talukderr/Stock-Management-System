using StockManagementSystemApp.DAL;
using StockManagementSystemApp.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystemApp.BLL
{
    public class ViewSearchManager
    {
        ViewSearchGateWay viewSearchGateWay = new ViewSearchGateWay();
        public List<SearchView> SearchByCompany(int companyId,string companyName)
        {
            
            return viewSearchGateWay.SearchByCompany(companyId,companyName);
            
        }
        public List<SearchView> SearchByCategory(int CategoryId)
        {
            return viewSearchGateWay.SearchByCategory(CategoryId);
        }

        public List<SearchView> SearchByCompanyAndCategory(int companyid, int CategoryId)
        {
            return viewSearchGateWay.SearchByCompanyAndCategory(companyid,CategoryId);
        }

        public List<SearchView> SearchByAll()
        {
            return viewSearchGateWay.SearchByAll();
        }
    }
}