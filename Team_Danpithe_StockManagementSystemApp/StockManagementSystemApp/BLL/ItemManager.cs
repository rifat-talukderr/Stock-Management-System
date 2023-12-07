using StockManagementSystemApp.DAL;
using StockManagementSystemApp.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystemApp.BLL
{
    public class ItemManager
    {
        ItemGateWay itemgateWay = new ItemGateWay();

        public string SaveItem(Item item)
        {
            

            Item aitem = itemgateWay.IsExcited(item);
            if (aitem == null)
            {
                int row = itemgateWay.SaveItem(item);
                if (row > 0)
                {
                    return "Item Successfully Inserted";
                }
                else
                {
                    return "Insert Failed";
                }
            }
            else
            {
                return "Item Already Excited";
            }
        }

        public List<Category> GetAllCategory()
        {
            return itemgateWay.GetAllCategory();
        }

        public List<Company> GetAllCompany()
        {
            return itemgateWay.GetAllCompany();
        }

        public Item GetItemById(int id)
        {
            return itemgateWay.GetItemById(id);
        }

        public string UpdateAvailablity(Item updateitem)
        {
            int row=itemgateWay.UpdateAvailablity(updateitem);
            if (row > 0)
            {
                return "susscessfull";
            }
            else
            {
                return "Unsusscessfull";
            }
        }


        //version 6
        public List<Category> GetCategoryByCompanyID(int companyId)
        {
            return itemgateWay.CategoryByCompanyID(companyId);
        }
        //end version 6

    }
}