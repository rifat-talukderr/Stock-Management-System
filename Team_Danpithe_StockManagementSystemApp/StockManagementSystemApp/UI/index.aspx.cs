using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StockManagementSystemApp.UI
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("UserLoginUI.aspx");
            }
        }

        protected void CategoryButtonClick(object sender, EventArgs e)
        {
            Response.Redirect("CategoryUI.aspx");
        }

        protected void ButtonCompany_Click(object sender, EventArgs e)
        {
            Response.Redirect("CompanyUI.aspx");
        }


        protected void ButtonItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("ItemUI.aspx");
        }

        protected void viewSellsButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewSalesDateUI.aspx");
        }

       

        protected void ButtonstockOutQuantity_Click(object sender, EventArgs e)
        {
            Response.Redirect("StockOutUI.aspx");
        }

        protected void ButtonStockIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("StockInUI.aspx");
        }


        protected void ButtonSearchview_Click(object sender, EventArgs e)
        {
            Response.Redirect("SearchViewUI.aspx");
        }

        protected void LogoutClick(object sender, EventArgs e)
        {
            Session.Remove("Username");
            Response.Redirect("UserLoginUI.aspx");
        }
    }
}