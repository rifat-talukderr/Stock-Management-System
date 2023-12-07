using StockManagementSystemApp.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace StockManagementSystemApp.DAL
{
    public class StockInGateWay
    {
        private string connectionString;
        private SqlConnection connection;

         public void SetConnection()
        {
            connectionString = WebConfigurationManager.ConnectionStrings["StockMangementDBconnectionStrings"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        public List<StockIn> GetAllitem(int companyId)
        {
                  
            SetConnection();
            string query = "SELECT * FROM Item WHERE CompanyID="+companyId;
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            List<StockIn> StockInlist = new List<StockIn>();
            SqlDataReader reader = command.ExecuteReader();
           
            while (reader.Read())
            {
                int itemID= (int)reader["ItemID"];
                string itemName = reader["ItemName"].ToString();
                StockIn astock = new StockIn();               
                astock.ItemId=itemID;
                astock.ItemName=itemName;
                StockInlist.Add(astock);
            }
            reader.Close();
            connection.Close();

            return StockInlist;
        }

        public int UpdateStockById(int companyId, int ItemId, int quanty)
        {  
            SetConnection();
            string query="UPDATE Item SET AvailableQuantity = AvailableQuantity+"+quanty+"WHERE CompanyID="+companyId+"AND ItemID="+ItemId;       
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
        
    }
}