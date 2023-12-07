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
    public partial class StockInUI : System.Web.UI.Page
    {
        
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
            CompanyManger company = new CompanyManger();
            DropDownCompanyList.DataSource = company.GetAllCompany();
            DropDownCompanyList.DataTextField = "CompanyName";
            DropDownCompanyList.DataValueField = "CompanyID";
            DropDownCompanyList.DataBind();
            DropDownCompanyList.Items.Insert(0, new ListItem("Select", "0"));
           
        }

        protected void DropDownCompanyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            StockInManager item = new StockInManager();
            int companyid = Convert.ToInt32(DropDownCompanyList.SelectedItem.Value);         
            DropDownItemList.DataSource = item.GetAllitem(companyid);
            DropDownItemList.DataTextField = "ItemName";
            DropDownItemList.DataValueField = "ItemId";
            DropDownItemList.DataBind();
            DropDownItemList.Items.Insert(0, new ListItem("Select", "0"));
        }

        protected void DropdownItemSelectedIndexChange(object sender, EventArgs e)
        {
            if (DropDownItemList.SelectedItem.Value != "0")
            {
                Item ItemObj = new Item();
                ItemManager aItem = new ItemManager();
                int itemid = Convert.ToInt32(DropDownItemList.SelectedItem.Value);
                ItemObj = aItem.GetItemById(itemid);
                TextBoxReorderLevel.Text = ItemObj.ReorderLevel.ToString();
                TextBoxAvailableQuantity.Text = ItemObj.AvailableQuantity.ToString();
            }
            else
            {
                TextBoxReorderLevel.Text = "";
                TextBoxAvailableQuantity.Text = "";
            }

        }

        //check validation
        private bool ValidateFrom()
        {
            bool ret = true;
            string AvailableQuantity = TextBoxStockIn.Text.Trim();
            int n;
            bool isNumeric = int.TryParse(AvailableQuantity, out n);

            if (DropDownCompanyList.SelectedIndex == 0)
            {
                ret = false;
                LabelCompanyMessageError.Text = "Company Name is required";
                LabelCompanyMessageError.ForeColor = System.Drawing.Color.Red;
            }
            else if (DropDownItemList.SelectedIndex == 0)
            {
                ret = false;
                LabelItemMessageError.Text = "Item Name is required";
                LabelItemMessageError.ForeColor = System.Drawing.Color.Red;
            }
            else if (isNumeric==false || AvailableQuantity=="")
            {
                ret = false;
                LabelStockInMessageError.Text = "AvailableQuantity is Not Valid";
                LabelStockInMessageError.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                LabelCompanyMessageError.Text = "";
                LabelItemMessageError.Text = "";
                LabelStockInMessageError.Text = "";
            }
            return ret;

        }

        protected void SaveButtonStockIn(object sender, EventArgs e)
        {
            if (ValidateFrom())
            {
                StockInManager stockInItem = new StockInManager();
                int stockInQuanty = Convert.ToInt32(TextBoxStockIn.Text);
                int itemid = Convert.ToInt32(DropDownItemList.SelectedItem.Value);
                int companyid = Convert.ToInt32(DropDownCompanyList.SelectedItem.Value);

                string message = stockInItem.UpdateStockById(companyid, itemid, stockInQuanty);

                int reorderlevel = Convert.ToInt32(TextBoxReorderLevel.Text);
                int availQuantity = Convert.ToInt32(TextBoxAvailableQuantity.Text) + stockInQuanty;

                TextBoxReorderLevel.Text = reorderlevel.ToString();
                TextBoxAvailableQuantity.Text = availQuantity.ToString();
                TextBoxStockIn.Text = "";
                LabelMessage.Visible = true;
                LabelMessage.Text = "Stock In Successfully";
            }


        }
        protected void LogoutClick(object sender, EventArgs e)
        {
            Session.Remove("Username");
            Response.Redirect("UserLoginUI.aspx");
        }


       
    }
}