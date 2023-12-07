using StockManagementSystemApp.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace StockManagementSystemApp.DAL
{
    public class ViewSearchGateWay
    {
        private string connectionString;
        private SqlConnection connection;
        public void SetConnection()
        {
            connectionString = WebConfigurationManager.ConnectionStrings["StockMangementDBconnectionStrings"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        public List<SearchView> SearchByCompany(int companyId, string companyName)
        {
                        
            SetConnection();
            string query = "SELECT * FROM Item WHERE CompanyID=" + companyId;
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            List<SearchView> AllCompanyItem = new List<SearchView>();
            
            SqlDataReader reader = command.ExecuteReader();
           
            while (reader.Read())
            {
              
                string itemName = reader["ItemName"].ToString();
                int reorderLevel = (int)reader["ReorderLevel"];
                int availableQuantity = (int)reader["AvailableQuantity"];
                SearchView aitem = new SearchView();
                aitem.ItemName = itemName;
                aitem.ReorderLevel = reorderLevel.ToString();
                aitem.AvailableQuantity = availableQuantity.ToString();
                aitem.CompanyName = companyName;
                AllCompanyItem.Add(aitem);
            }
            reader.Close();
            connection.Close();

            return AllCompanyItem;
        
        }

        public List<SearchView> SearchByCategory(int CategoryId)
        {
            SetConnection();
            string query = "SELECT Item.ItemName,Item.ReorderLevel,Item.AvailableQuantity,Company.CompanyName FROM Item INNER JOIN Company ON Item.CompanyID = Company.CompanyID AND Item.CategoryID="+CategoryId;


            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            List<SearchView> AllCompanyItem = new List<SearchView>();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                string itemName = reader["ItemName"].ToString();
                int reorderLevel = (int)reader["ReorderLevel"];
                int availableQuantity = (int)reader["AvailableQuantity"];
                string companyName=reader["CompanyName"].ToString();

                SearchView aitem = new SearchView();
                aitem.ItemName = itemName;
                aitem.ReorderLevel = reorderLevel.ToString();
                aitem.AvailableQuantity = availableQuantity.ToString();
                aitem.CompanyName = companyName;
                AllCompanyItem.Add(aitem);
            }
            reader.Close();
            connection.Close();

            return AllCompanyItem;
        }

        public List<SearchView> SearchByCompanyAndCategory(int companyid,int CategoryId)
        {
            SetConnection();
            string query = "SELECT Item.ItemName,Item.ReorderLevel,Item.AvailableQuantity,Company.CompanyName FROM Item INNER JOIN Company ON Item.CompanyID = Company.CompanyID AND Item.CompanyID="+companyid+" AND Item.CategoryID=" + CategoryId;


            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            List<SearchView> AllCompanyItem = new List<SearchView>();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                string itemName = reader["ItemName"].ToString();
                int reorderLevel = (int)reader["ReorderLevel"];
                int availableQuantity = (int)reader["AvailableQuantity"];
                string companyName = reader["CompanyName"].ToString();

                SearchView aitem = new SearchView();
                aitem.ItemName = itemName;
                aitem.ReorderLevel = reorderLevel.ToString();
                aitem.AvailableQuantity = availableQuantity.ToString();
                aitem.CompanyName = companyName;
                AllCompanyItem.Add(aitem);
            }
            reader.Close();
            connection.Close();

            return AllCompanyItem;
        }


        public List<SearchView> SearchByAll()
        {
            SetConnection();
            string query = "SELECT Item.ItemName,Item.ReorderLevel,Item.AvailableQuantity,Company.CompanyName FROM Item INNER JOIN Company ON Item.CompanyID = Company.CompanyID";


            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            List<SearchView> AllCompanyItem = new List<SearchView>();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                string itemName = reader["ItemName"].ToString();
                int reorderLevel = (int)reader["ReorderLevel"];
                int availableQuantity = (int)reader["AvailableQuantity"];
                string companyName = reader["CompanyName"].ToString();

                SearchView aitem = new SearchView();
                aitem.ItemName = itemName;
                aitem.ReorderLevel = reorderLevel.ToString();
                aitem.AvailableQuantity = availableQuantity.ToString();
                aitem.CompanyName = companyName;
                AllCompanyItem.Add(aitem);
            }
            reader.Close();
            connection.Close();

            return AllCompanyItem;
        }
    }
}