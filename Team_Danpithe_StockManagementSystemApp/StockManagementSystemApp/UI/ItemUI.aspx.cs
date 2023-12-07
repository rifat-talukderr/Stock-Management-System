using StockManagementSystemApp.BLL;
using StockManagementSystemApp.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StockManagementSystemApp.UI
{
    public partial class ItemUI : System.Web.UI.Page
    {
        ItemManager itemManger = new ItemManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("UserLoginUI.aspx");
            }

            if (!IsPostBack)
            {
                FillDropDownList();
            }
        }

        protected void FillDropDownList()
        {
            DropDownCategoryList.DataSource = itemManger.GetAllCategory();
            DropDownCategoryList.DataTextField = "CategoryName";
            DropDownCategoryList.DataValueField = "CategoryID";
            DropDownCategoryList.DataBind();
            DropDownCategoryList.Items.Insert(0, new ListItem("Select", "0"));

            DropDownCompanyList.DataSource = itemManger.GetAllCompany();
            DropDownCompanyList.DataTextField = "CompanyName";
            DropDownCompanyList.DataValueField = "CompanyID";
            DropDownCompanyList.DataBind();
            DropDownCompanyList.Items.Insert(0, new ListItem("Select", "0"));
        }

        //check validation
        private bool ValidateFrom()
        {
            bool ret = true;
            string item = TextBoxItemName.Text.Trim();
            if (string.IsNullOrEmpty(item))
            {
                ret = false;
                LabelItemMessageError.Text = "Item Name is required";
                LabelItemMessageError.ForeColor = System.Drawing.Color.Red;
            }
            else if(DropDownCategoryList.SelectedIndex == 0)
            {
                ret = false;
                LabelCategpryMessageError.Text = "Category Name is required";
                LabelCategpryMessageError.ForeColor = System.Drawing.Color.Red;
            }
            else if(DropDownCompanyList.SelectedIndex == 0){
                ret = false;
                LabelCompanyMessageError.Text = "Company Name is required";
                LabelCompanyMessageError.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                LabelItemMessageError.Text = "";
                LabelCategpryMessageError.Text = "";
                LabelCompanyMessageError.Text = "";
            }
            return ret;

        }

        protected void SaveButtonClick(object sender, EventArgs e)
        {
            if (ValidateFrom())
            {
                Item item = new Item();
                
                item.CategoryID = Convert.ToInt32(DropDownCategoryList.SelectedValue);
                item.CompanyID = Convert.ToInt32(DropDownCompanyList.SelectedValue);
                item.ItemName = TextBoxItemName.Text.Trim();
                item.ReorderLevel = Convert.ToInt32(TextBoxReorder.Text.Trim());
                string message = itemManger.SaveItem(item);
                LabelMessage.Visible = true;
                LabelMessage.Text = message;
            }
        }
        protected void LogoutClick(object sender, EventArgs e)
        {
            Session.Remove("Username");
            Response.Redirect("UserLoginUI.aspx");
        }
    }
}