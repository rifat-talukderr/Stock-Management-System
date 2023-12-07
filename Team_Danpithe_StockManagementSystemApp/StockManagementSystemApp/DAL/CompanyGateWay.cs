using StockManagementSystemApp.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace StockManagementSystemApp.DAL
{
    public class CompanyGateWay
    {
        private string connectionString;
        private SqlConnection connection;
        public void SetConnection()
        {
            connectionString = WebConfigurationManager.ConnectionStrings["StockMangementDBconnectionStrings"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        public Company IsExcited(Company company)
        {
            SetConnection();
            string query = "SELECT * FROM Company WHERE CompanyName='" + company.CompanyName + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            Company aCompany = null;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                int companyID = Convert.ToInt32(reader["CompanyID"]);
                string companyName = reader["CompanyName"].ToString();

                aCompany = new Company(companyID, companyName);
               

                reader.Close();
                connection.Close();
                return aCompany;
            }
            reader.Close();
            connection.Close();
            return aCompany;
        }

        public int SaveCompany(Company companyObj)
        {
            SetConnection();
            string query = "INSERT INTO Company VALUES('" + companyObj.CompanyName + "')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public List<Company> GetAllCompany()
        {
            SetConnection();
            string query = "SELECT * FROM Company";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            List<Company> Companylist = new List<Company>();
            SqlDataReader reader = command.ExecuteReader();
            int serielNo = 0;
            while (reader.Read())
            {
                int CompanyID = (int)reader["CompanyID"];
                string CompanyName = reader["CompanyName"].ToString();
                Company aCompany = new Company();
                serielNo++;
                aCompany.SerielNo = serielNo;
                aCompany.CompanyID = CompanyID;
                aCompany.CompanyName = CompanyName;
                Companylist.Add(aCompany);
            }
            reader.Close();
            connection.Close();

            return Companylist;
        }

        public int GetCompanyByName(string companyName)
        {
            SetConnection();
            string query = "SELECT CompanyID FROM Company WHERE CompanyName='" + companyName + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
           
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int CompanyID = Convert.ToInt32(reader["CompanyID"]);
            reader.Close();
            connection.Close();
            return CompanyID;       
        }
    }
}