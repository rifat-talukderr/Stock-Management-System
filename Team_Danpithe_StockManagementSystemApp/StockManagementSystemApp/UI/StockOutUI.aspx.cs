using StockManagementSystemApp.BLL;
using StockManagementSystemApp.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StockManagementSystemApp.UI
{
    public partial class StockOutUI : System.Web.UI.Page
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

                BindGridWithSingleRow();
                   
                
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

        

        protected void DropdownCompanySelectedIndexChanged(object sender, EventArgs e)
        {
            StockInManager item = new StockInManager();
            int companyid = Convert.ToInt32(DropDownCompanyList.SelectedItem.Value);
            DropDownItemList.DataSource = item.GetAllitem(companyid);
            DropDownItemList.DataTextField = "ItemName";
            DropDownItemList.DataValueField = "ItemId";
            DropDownItemList.DataBind();
            DropDownItemList.Items.Insert(0, new ListItem("Select", "0"));
        }
     

        protected void DropDwonItemSelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownItemList.SelectedItem.Value != "0")
            {
                Item ItemObj = new Item();
                ItemManager aItem = new ItemManager();
                int itemid = Convert.ToInt32(DropDownItemList.SelectedItem.Value);
                ItemObj = aItem.GetItemById(itemid);
                TextBoxReorderLevel.Text = ItemObj.ReorderLevel.ToString();

                bool IsExcited = false;
                if (ViewState["Data"] != null)
                {
                    DataTable dttable = (DataTable)ViewState["Data"];


                    for (int i = 0; i < dttable.Rows.Count; i++)
                    {
                        Label labelItem = (Label)GridViewStockOutList.Rows[i].Cells[1].FindControl("ItemName");
                        Label labelCompany = (Label)GridViewStockOutList.Rows[i].Cells[2].FindControl("CompanyName");
                        string Availquantity = ((Label)GridViewStockOutList.Rows[i].FindControl("idHiddenAvailquantity")).Text;

                        // Response.Write("Item " + labelItem.Text + "Company " + labelCompany.Text + " Quantity" + labelQuantity.Text);
                        if (DropDownItemList.SelectedItem.Text == labelItem.Text && DropDownCompanyList.SelectedItem.Text == labelCompany.Text)
                        {
                            IsExcited = true;

                            TextBoxAvailableQuantity.Text = dttable.Rows[i]["Availablequantity"].ToString();

                            break;
                        }
                    }

                }
                if (IsExcited == false)
                {
                    TextBoxAvailableQuantity.Text = ItemObj.AvailableQuantity.ToString();
                }
            }
            else
            {
                TextBoxAvailableQuantity.Text = "";
            }
            
        }

        //check validate
        private bool ValidateFrom()
        {
            bool ret = true;
            string StockOutQuantity = TextBoxStockOut.Text.Trim();
            int n;
            bool isNumeric = int.TryParse(StockOutQuantity, out n);

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
            else if (isNumeric == false || StockOutQuantity == "")
            {
                ret = false;
                LabelStockInMessageError.Text = "Stock Out Quantity is Not Valid";
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
        protected void SaveButtonStockOut(object sender, EventArgs e)
        {
            if (ValidateFrom())
            {

                int availQuantity = Convert.ToInt32(TextBoxAvailableQuantity.Text);
                int stockQuantiy = Convert.ToInt32(TextBoxStockOut.Text);
                if (stockQuantiy <= availQuantity)
                {

                    if (ViewState["Data"] != null)
                    {
                        //we binding gridview for iterating loop
                        DataTable dttable = (DataTable)ViewState["Data"];

                        //check  row is excited in gridview
                        bool IsExcied = false;
                        for (int i = 0; i < dttable.Rows.Count; i++)
                        {
                            Label labelItem = (Label)GridViewStockOutList.Rows[i].Cells[1].FindControl("ItemName");
                            Label labelCompany = (Label)GridViewStockOutList.Rows[i].Cells[2].FindControl("CompanyName");
                            Label labelQuantity = (Label)GridViewStockOutList.Rows[i].Cells[3].FindControl("quantityName");

                            string Availquantity = ((Label)GridViewStockOutList.Rows[i].FindControl("idHiddenAvailquantity")).Text;

                            if (DropDownItemList.SelectedItem.Text == labelItem.Text && DropDownCompanyList.SelectedItem.Text == labelCompany.Text)
                            {
                                IsExcied = true;
                                int addQuantity = Convert.ToInt32(labelQuantity.Text) + Convert.ToInt32(TextBoxStockOut.Text);
                                dttable.Rows[i]["Item"] = labelItem.Text;
                                dttable.Rows[i]["Company"] = labelCompany.Text;
                                dttable.Rows[i]["quantity"] = addQuantity.ToString();

                                int saveNewAvailable = Convert.ToInt32(Availquantity) - Convert.ToInt32(TextBoxStockOut.Text);
                                dttable.Rows[i]["Availablequantity"] = saveNewAvailable.ToString();
                                TextBoxAvailableQuantity.Text = saveNewAvailable.ToString();

                                break;
                            }
                        }


                        if (IsExcied == false)
                        {
                            DataRow dataRow = dttable.NewRow();
                            dataRow["Item"] = DropDownItemList.SelectedItem.Text;
                            dataRow["Itemid"] = DropDownItemList.SelectedItem.Value;
                            dataRow["Company"] = DropDownCompanyList.SelectedItem.Text;
                            dataRow["Companyid"] = DropDownCompanyList.SelectedItem.Value;
                            dataRow["quantity"] = TextBoxStockOut.Text;
                            dataRow["Availablequantity"] = (availQuantity - stockQuantiy).ToString();

                            int saveAvailableQuantity = availQuantity - stockQuantiy;
                            TextBoxAvailableQuantity.Text = saveAvailableQuantity.ToString();
                            dttable.Rows.Add(dataRow);
                        }
                        ViewState["Data"] = dttable;
                        GridViewStockOutList.DataSource = dttable;
                        GridViewStockOutList.DataBind();


                        DamageButton.Visible = true;
                        LostButton.Visible = true;
                        ButtonSellId.Visible = true;


                    }



                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Quantity is Not Available in Stock.Please valid input')", true);
                    return;
                   
                }


            }
            
        }

        protected void BindGridWithSingleRow()
        {
            DataTable dtTemp = new DataTable();


            dtTemp.Columns.Add(new DataColumn("Item", typeof(string)));
            dtTemp.Columns.Add(new DataColumn("Itemid", typeof(int)));
            dtTemp.Columns.Add(new DataColumn("Company", typeof(string)));
            dtTemp.Columns.Add(new DataColumn("Companyid", typeof(int)));
            dtTemp.Columns.Add(new DataColumn("Availablequantity", typeof(int)));         
            dtTemp.Columns.Add(new DataColumn("quantity", typeof(int)));

            ViewState["Data"] = dtTemp;
           

            GridViewStockOutList.DataSource = dtTemp;
            GridViewStockOutList.DataBind();
        }

        protected void sellButtonClick(object sender, EventArgs e)
        {
            StockOut("sell");
        }

        protected void DamageButtonClick(object sender, EventArgs e)
        {

            StockOut("damage");
           
        }

        protected void LostButtonClick(object sender, EventArgs e)
        {
            StockOut("lost");
           
        }

        protected void StockOut(string type)
        {
            if (ViewState["Data"] != null)
            {
                DataTable dttable = (DataTable)ViewState["Data"];
                for (int i = 0; i < dttable.Rows.Count; i++)
                {
                    //get data from gridview
                    Label labelItem = (Label)GridViewStockOutList.Rows[i].Cells[1].FindControl("ItemName");
                    string itemid = ((Label)GridViewStockOutList.Rows[i].FindControl("idItemHiddenField")).Text;
                    string companyid = ((Label)GridViewStockOutList.Rows[i].FindControl("idCompanyHiddenField")).Text;
                    Label labelQuantity = (Label)GridViewStockOutList.Rows[i].Cells[4].FindControl("quantityName");

                    StockOut stockOutitem = new StockOut();
                    stockOutitem.Itemid = Convert.ToInt32(itemid);
                    stockOutitem.Quantity = Convert.ToInt32(labelQuantity.Text);
                    stockOutitem.ItemType = type;

                    StockOutManager stockoutmanager = new StockOutManager();
                    stockoutmanager.SaveStockOutItem(stockOutitem);

                    Item updateItem = new Item();
                    updateItem.ItemName = labelItem.Text;
                    updateItem.CompanyID = Convert.ToInt32(companyid);
                    updateItem.AvailableQuantity = Convert.ToInt32(labelQuantity.Text);

                    ItemManager updatAvailablequantity = new ItemManager();
                    LabelMessage.Visible = true;
                   
                    LabelMessage.Text = updatAvailablequantity.UpdateAvailablity(updateItem);



                    


                }
                //clear gridview after inserting
                dttable.Clear();
                ViewState["Data"] = dttable;
                GridViewStockOutList.DataSource = dttable;
                GridViewStockOutList.DataBind();

            }
            GridViewStockOutList.DataSource = null;
            GridViewStockOutList.DataBind();

            ButtonSellId.Visible = false;
            DamageButton.Visible = false;
            LostButton.Visible = false;
        }
        protected void LogoutClick(object sender, EventArgs e)
        {
            Session.Remove("Username");
            Response.Redirect("UserLoginUI.aspx");
        }
}
}
