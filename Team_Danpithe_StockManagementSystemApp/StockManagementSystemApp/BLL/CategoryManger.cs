using StockManagementSystemApp.DAL;
using StockManagementSystemApp.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystemApp.BLL
{
    public class CategoryManger
    {
        CategoryGateWay categoryGatway = new CategoryGateWay();
        public string SaveCategory(Category categoryObj){

            Category acategory = categoryGatway.IsExcited(categoryObj);

            if (acategory == null)
            {
                int row = categoryGatway.SaveCategory(categoryObj);
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
                return "Category Already Existed";
            }

        }

        public List<Category> GetAllCategory()
        {
            return categoryGatway.GetAllCategory();
        }

        public Category GetCategoryById(int id)
        {
            return categoryGatway.GetCategoryById(id);
        }

        public bool UpdateCategoryById(Category category)
        {
            Category categoryExcited = categoryGatway.UpateCategoryIsExcited(category);
            if (categoryExcited == null)
            {
                categoryGatway.UpdateByCategoryId(category);
                return true;
                
            }
            else
            {
                return false;
            }
            
        }
        
    }
}