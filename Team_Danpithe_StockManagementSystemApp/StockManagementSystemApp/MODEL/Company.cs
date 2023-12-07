using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystemApp.MODEL
{
    public class Company
    {
        public int SerielNo { get; set; }
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public Company()
        {

        }
        public Company(int companyID, string companyName)
        {
            CompanyID = companyID;
            CompanyName=companyName;
        }
    }
}