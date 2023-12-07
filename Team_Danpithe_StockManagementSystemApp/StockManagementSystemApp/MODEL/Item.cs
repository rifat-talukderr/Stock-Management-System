using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystemApp.MODEL
{
    public class Item
    {
        public int ItemID { get; set; }
        public string ItemName{get;set;}
        public int ReorderLevel{get;set;}
        public int AvailableQuantity{get;set;}
        public int CategoryID{get;set;}
        public int CompanyID { get; set; }

        public Item(){

        }
        public Item(int itemId,string itemName,int reorderlevel,int availableQuantity,int categoryid,int companyid){
            ItemID = itemId;
            ItemName = itemName;
            ReorderLevel = reorderlevel;
            AvailableQuantity = availableQuantity;
            CategoryID = categoryid;
            CompanyID = companyid;

        }
    }
}