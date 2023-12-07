using StockManagementSystemApp.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace StockManagementSystemApp.DAL
{
    public class CategoryGateWay
    {
        private string connectionString;
        private SqlConnection connection;
        public void SetConnection()
        {
            connectionString = WebConfigurationManager.ConnectionStrings["StockMangementDBconnectionStrings"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        public Category IsExcited(Category category)
        {
            SetConnection();
            string query = "SELECT * FROM Category WHERE CategoryName='" +category.CategoryName + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            Category aCategory = null;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                int categoryID = Convert.ToInt32(reader["CategoryID"]);
                string categoryName = reader["CategoryName"].ToString();
                aCategory = new Category(categoryID, categoryName);
                reader.Close();
                connection.Close();
                return aCategory;
            }
            reader.Close();
            connection.Close();
            return aCategory;
        }
        public int SaveCategory(Category categoryObj)
        {
            SetConnection();
            string query = "INSERT INTO Category VALUES('"+categoryObj.CategoryName+"')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public List<Category> GetAllCategory()
        {
            SetConnection();
            string query = "SELECT * FROM Category";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            List<Category> Categorylist = new List<Category>();
            SqlDataReader reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                int categoryID= (int)reader["CategoryID"];
                string categoryName = reader["CategoryName"].ToString();
                Category aCategory = new Category();            
                aCategory.CategoryID=categoryID ;
                aCategory.CategoryName = categoryName;
                Categorylist.Add(aCategory);
            }
            reader.Close();
            connection.Close();

            return Categorylist;
        }

        public Category GetCategoryById(int id)
        {
            SetConnection();
            string query = "SELECT * FROM Category WHERE CategoryID="+id;
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();      
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Category category = null;
            if (reader.HasRows)
            {
                category = new Category();
                int categoryID = (int)reader["CategoryID"];
                string categoryName = reader["CategoryName"].ToString();
                category.CategoryID = categoryID;
                category.CategoryName = categoryName;
                reader.Close();
                connection.Close();
            }
            return category;
            
        }

        public int UpdateByCategoryId(Category category)
        {
            SetConnection();
            string query = "UPDATE Category SET CategoryName='"+category.CategoryName+"'WHERE CategoryID="+category.CategoryID;
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;

        }


        public Category UpateCategoryIsExcited(Category category)
        {
            SetConnection();
            string query = "SELECT * FROM Category WHERE CategoryName='" + category.CategoryName + "' AND CategoryID <>"+category.CategoryID;
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            Category aCategory = null;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                int categoryID = Convert.ToInt32(reader["CategoryID"]);
                string categoryName = reader["CategoryName"].ToString();
                aCategory = new Category(categoryID, categoryName);
                reader.Close();
                connection.Close();
                return aCategory;
            }
            reader.Close();
            connection.Close();
            return aCategory;
        }
    }
}