using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace StockManagementSystemApp.DAL
{
    public class UserLoginGateWay
    {
        private string connectionString;
        private SqlConnection connection;
        public void SetConnection()
        {
            connectionString = WebConfigurationManager.ConnectionStrings["StockMangementDBconnectionStrings"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }
        public bool userExitedCheaked(string username, string password)
        {
            SetConnection();
            string query = "SELECT * FROM UserInfo WHERE UserName='" + username + "' AND Password='" + password + "'"; 
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                
                reader.Close();
                connection.Close();
                return true;
            }
            reader.Close();
            connection.Close();
            return false;
            
        }
    }
}