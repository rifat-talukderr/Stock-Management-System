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
    public partial class CategoryUI : System.Web.UI.Page
    {
        CategoryManger categoryManger = new CategoryManger();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("UserLoginUI.aspx");
            }

            if (!Page.IsPostBack)
            {         
              LoadCategory();
            }
        }
        public void LoadCategory()
        {
            GridViewCategory.DataSource = categoryManger.GetAllCategory();
            GridViewCategory.DataBind();
        }

        protected void saveButtonClick(object sender, EventArgs e)
        {
            if (ValidateFrom())
            {
                Category categoryObj = new Category();
                categoryObj.CategoryName = TextBoxName.Text.Trim();

                string message = categoryManger.SaveCategory(categoryObj);
                LabelMessage.Visible = true;
                LabelMessage.Text = message;
                LoadCategory();
            }
            
        }

        private bool ValidateFrom()
        {
            bool ret = true;
            if(string.IsNullOrEmpty(TextBoxName.Text)){
                ret = false;
                LabelMessageError.Text = "Category Name is required";
                LabelMessageError.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                LabelMessageError.Text = "";
            }
            return ret;
            
        }
        //update link button open model popup
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            DataControlFieldCell cell = (DataControlFieldCell)linkButton.Parent;
            GridViewRow row = (GridViewRow)cell.Parent;
            HiddenField idHiddenField = (HiddenField)row.FindControl("idHiddenField");
            int id = Convert.ToInt32(idHiddenField.Value);
            ViewState["id"] = id;
            Category category = categoryManger.GetCategoryById(id);
            TextBoxCategoryName.Text = category.CategoryName;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                                         
        }

        //model popup update button
        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
           
                Category category = new Category();
                string categoryName=TextBoxCategoryName.Text.Trim();
                category.CategoryID = Convert.ToInt32(ViewState["id"]);
                category.CategoryName = categoryName;
                if (categoryName == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Category Name is Required')", true);          
                    return;
                }
                bool message = categoryManger.UpdateCategoryById(category);
                
                if (message == true)
                {
                    Response.Redirect("CategoryUI.aspx");
                }
                else
                {
                    TextBoxCategoryName.Text = category.CategoryName;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Category Already Existed')", true);
                    return;
                }
              


        }

        //validate updatebox
        private bool updateValidateFrom()
        {
            bool ret = true;
            if (string.IsNullOrEmpty(TextBoxCategoryName.Text))
            {
                ret = false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                LabelMessage.Visible = true;
                this.LabelMessage.Text = "Category Name is required";
                this.LabelMessage.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                this.LabelMessage.Text = "";
            }
            return ret;

        }


        protected void LogoutClick(object sender, EventArgs e)
        {
            Session.Remove("Username");
            Response.Redirect("UserLoginUI.aspx");
        }
    }
}