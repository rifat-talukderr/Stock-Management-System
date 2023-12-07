using StockManagementSystemApp.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StockManagementSystemApp.UI
{
    
    public partial class UserLoginUI : System.Web.UI.Page
    {
        UserManger user = new UserManger();
        protected void Page_Load(object sender, EventArgs e)
        {
            //for showing ..... in inputbox
            if (this.IsPostBack)
            {
                TextBoxPassword.Attributes["value"] = TextBoxPassword.Text;

                
                
            }
            if (Request.QueryString["Id"]!=null && Request.QueryString["Id"].ToString() == "1")
            {
                loginMessage.Text = "User Name or Password Not match";
            }
           
        }

        protected void ButtonLogin(object sender, EventArgs e)
        {
       
            string username=TextBoxUserName.Text;
            string password=TextBoxPassword.Text;
            bool hasUser = user.UserIsExicted(username, password);
            if (hasUser)
            {
                Session["Username"] = username;
                Response.Redirect("index.aspx");
            }
            else
            {
                
                Response.Redirect("UserLoginUI.aspx?Id="+1);
                

            }

        }
    }
}