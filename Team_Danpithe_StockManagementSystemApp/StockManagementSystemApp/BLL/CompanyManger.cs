using StockManagementSystemApp.DAL;
using StockManagementSystemApp.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystemApp.BLL
{
    public class CompanyManger
    {
        CompanyGateWay companyGatway = new CompanyGateWay();
        public string SaveCompany(Company companyObj)
        {
            Company acompany = companyGatway.IsExcited(companyObj);

            if (acompany == null)
            {
                int row = companyGatway.SaveCompany(companyObj);
                if (row > 0)
                {
                    return "Successfully Inserted";
                }
                else
                {
                    return "Insert Failed";
                }
            }
            else
            {
                return "Company Already Existed";
            }

        }

        public List<Company> GetAllCompany()
        {
            return companyGatway.GetAllCompany();
        }

        public int GetCompanyByName(string companyName)
        {
            return companyGatway.GetCompanyByName(companyName);
        }

    }
}