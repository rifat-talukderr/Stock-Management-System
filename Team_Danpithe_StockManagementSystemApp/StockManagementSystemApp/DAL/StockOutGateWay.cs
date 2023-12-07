using StockManagementSystemApp.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace StockManagementSystemApp.DAL
{
    public class StockOutGateWay
    {
        private string connectionString;
        private SqlConnection connection;
        public void SetConnection()
        {
            connectionString = WebConfigurationManager.ConnectionStrings["StockMangementDBconnectionStrings"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        public bool IsExicedStockOutItem(StockOut item)
        {
            SetConnection();
            string query = "SELECT * FROM StockOut WHERE Date='" + DateTime.Now.ToString("yyyy-MM-dd") + "' AND ItemId=" + item.Itemid + " AND ItemType='" + item.ItemType + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                connection.Close();
                return true;
            }
            connection.Close();
            return false;
        }

        public int SaveStockOutItem(StockOut item)
        {
            SetConnection();
            string query = "INSERT INTO StockOut(Date,ItemId,Quantity,ItemType) VALUES('" + DateTime.Now.ToString("yyyy-MM-dd") + "'," + item.Itemid + "," + item.Quantity + ",'" + item.ItemType + "')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public int UpdateStockOutItem(StockOut item)
        {
            SetConnection();
            string query = "UPDATE StockOut SET Quantity=Quantity+" + item.Quantity + " WHERE Date='" + DateTime.Now.ToString("yyyy-MM-dd") + "' AND ItemId=" + item.Itemid + " AND ItemType='" + item.ItemType + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
    }
}