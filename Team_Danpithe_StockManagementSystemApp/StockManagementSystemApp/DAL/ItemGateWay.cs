using StockManagementSystemApp.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace StockManagementSystemApp.DAL
{
    public class ItemGateWay
    {
        private string connectionString;
        private SqlConnection connection;
        public void SetConnection()
        {
            connectionString = WebConfigurationManager.ConnectionStrings["StockMangementDBconnectionStrings"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        public Item IsExcited(Item item)
        {
            SetConnection();
            string query = "SELECT * FROM Item WHERE ItemName='" + item.ItemName + "' AND CompanyID="+item.CompanyID;
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            Item aitem=null;
            SqlDataReader reader = command.ExecuteReader();
             if (reader.HasRows)
             {
             reader.Read();
             int itemID = Convert.ToInt32(reader["ItemID"]);
             string itemName = reader["ItemName"].ToString();
             int reorderLevel = Convert.ToInt32(reader["ReorderLevel"]);
             int availableQuantity = Convert.ToInt32(reader["AvailableQuantity"]);
             int categoryID = Convert.ToInt32(reader["CategoryID"]);
             int companyID = Convert.ToInt32(reader["CompanyID"]);
             aitem = new Item(itemID, itemName, reorderLevel, availableQuantity, categoryID, companyID);
             reader.Close();
             connection.Close();
             return aitem;
             }
             reader.Close();
             connection.Close();
             return aitem;
        }
        
        public int SaveItem(Item item)
        {
            SetConnection();
            string query = "INSERT INTO Item(ItemName,ReorderLevel,CategoryID,CompanyID) VALUES('"+item.ItemName+"',"+item.ReorderLevel+","+item.CategoryID+","+item.CompanyID+")";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        //version 6
        public List<Category> CategoryByCompanyID(int companyId)
        {
            SetConnection();
            string query = "SELECT Category.CategoryID,Category.CategoryName FROM Category INNER JOIN ITEM ON Category.CategoryID=Item.CategoryID WHERE Item.CompanyID=" + companyId + " GROUP BY Category.CategoryID,Category.CategoryName";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            List<Category> Categorylist = new List<Category>();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int categoryID = (int)reader["CategoryID"];
                string categoryName = reader["CategoryName"].ToString();
                Category aCategory = new Category();
                aCategory.CategoryID = categoryID;
                aCategory.CategoryName = categoryName;
                Categorylist.Add(aCategory);
            }
            reader.Close();
            connection.Close();

            return Categorylist;
        }

        //end version 6

        public List<Category> GetAllCategory()
        {
            CategoryGateWay categoryAll = new CategoryGateWay();
            return categoryAll.GetAllCategory();
        }

        public List<Company> GetAllCompany()
        {
            CompanyGateWay companyAll = new CompanyGateWay();
            return companyAll.GetAllCompany();
        }

        public Item GetItemById(int id)
        {
            SetConnection();
            string query = "SELECT * FROM Item WHERE ItemID="+id;
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            Item aitem ;
            SqlDataReader reader = command.ExecuteReader();

            reader.Read();
            int itemID = Convert.ToInt32(reader["ItemID"]);
            string itemName = reader["ItemName"].ToString();
            int reorderLevel = Convert.ToInt32(reader["ReorderLevel"]);
            int availableQuantity = Convert.ToInt32(reader["AvailableQuantity"]);
            int categoryID = Convert.ToInt32(reader["CategoryID"]);
            int companyID = Convert.ToInt32(reader["CompanyID"]);

            aitem = new Item(itemID, itemName, reorderLevel, availableQuantity, categoryID, companyID);
            reader.Close();
            connection.Close();
            return aitem;       
        }

        public int UpdateAvailablity(Item updateitem)
        {
            SetConnection();
            string query = "UPDATE Item SET AvailableQuantity=AvailableQuantity-" + updateitem.AvailableQuantity + "WHERE ItemName='" + updateitem.ItemName + "' AND CompanyID="+updateitem.CompanyID;
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
    }
}