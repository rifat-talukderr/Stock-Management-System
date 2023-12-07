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
    public partial class CompanyUI : System.Web.UI.Page
    {
        CompanyManger companyManger = new CompanyManger();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("UserLoginUI.aspx");
            }

            if (!IsPostBack)
            {
                LoadCompany(); 
            }
        }

        protected void saveButtonClick(object sender, EventArgs e)
        {
            if (ValidateFrom())
            {
                Company companyObj = new Company();
                companyObj.CompanyName = TextBoxNameCompany.Text.Trim();
                string message = companyManger.SaveCompany(companyObj);
                LabelMessage.Visible = true;
                LabelMessage.Text = message;
                LoadCompany();
            }
            
        }

        //check validation
        private bool ValidateFrom()
        {
            bool ret = true;
            if (string.IsNullOrEmpty(TextBoxNameCompany.Text))
            {
                ret = false;
                LabelMessageError.Text = "Company Name is required";
                LabelMessageError.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                LabelMessageError.Text = "";
            }
            return ret;

        }

        protected void LoadCompany()
        {
            GridViewCompany.DataSource = companyManger.GetAllCompany();
            GridViewCompany.DataBind();
        }
        protected void LogoutClick(object sender, EventArgs e)
        {
            Session.Remove("Username");
            Response.Redirect("UserLoginUI.aspx");
        }
    }
}