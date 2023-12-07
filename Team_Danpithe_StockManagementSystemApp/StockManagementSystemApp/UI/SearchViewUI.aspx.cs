using StockManagementSystemApp.BLL;
using StockManagementSystemApp.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

namespace StockManagementSystemApp.UI
{
    public partial class SearchViewUI : System.Web.UI.Page
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
            DropDownCompanyList.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));

            ItemManager itemManager = new ItemManager();
            DropDownCategoryList.DataSource = itemManager.GetAllCategory();
            DropDownCategoryList.DataTextField = "CategoryName";
            DropDownCategoryList.DataValueField = "CategoryID";
            DropDownCategoryList.DataBind();
            DropDownCategoryList.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));

        }

        //version 6
        protected void DropDownCompanySelectedIndexChange(object sender, EventArgs e)
        {
            if (DropDownCompanyList.SelectedIndex != 0)
            {
                ItemManager itemManager = new ItemManager();
                int companyId = Convert.ToInt32(DropDownCompanyList.SelectedItem.Value);
                DropDownCategoryList.DataSource = itemManager.GetCategoryByCompanyID(companyId);
                DropDownCategoryList.DataTextField = "CategoryName";
                DropDownCategoryList.DataValueField = "CategoryID";
                DropDownCategoryList.DataBind();
                DropDownCategoryList.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));
            }
            else
            {
                ItemManager itemManager = new ItemManager();
                DropDownCategoryList.DataSource = itemManager.GetAllCategory();
                DropDownCategoryList.DataTextField = "CategoryName";
                DropDownCategoryList.DataValueField = "CategoryID";
                DropDownCategoryList.DataBind();
                DropDownCategoryList.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));
            }
        }
        //end version 6

        protected void searchButtonClick(object sender, EventArgs e)
        {

            ViewSearchManager viewSearchManager = new ViewSearchManager();

            if (DropDownCompanyList.SelectedIndex != 0  && DropDownCategoryList.SelectedIndex == 0)
            {
                
                int companyId = Convert.ToInt32(DropDownCompanyList.SelectedItem.Value);
                string companyName = DropDownCompanyList.SelectedItem.Text;
                List<SearchView> asearchView = viewSearchManager.SearchByCompany(companyId, companyName);
                if (asearchView.Count > 0)
                {
                    ViewState["stockin"] = asearchView;
                    SearchViewGridViewList.DataSource = asearchView;
                    SearchViewGridViewList.DataBind(); 
                    pdfbuttonid.Visible = true;
                }
                else
                {
                    LabelMessage.Visible = true;               
                    LabelMessage.Text = "Quantity not Available";
                    SearchViewGridViewList.DataSource = asearchView;
                    SearchViewGridViewList.DataBind();
                    pdfbuttonid.Visible = false;
                    
                }
                
            }
            else if (DropDownCompanyList.SelectedIndex == 0 && DropDownCategoryList.SelectedIndex != 0)
            {
                int categoryId = Convert.ToInt32(DropDownCategoryList.SelectedItem.Value);
                 List<SearchView> asearchView = viewSearchManager.SearchByCategory(categoryId);
                 if (asearchView.Count > 0)
                 {
                     ViewState["stockin"] = asearchView;
                     SearchViewGridViewList.DataSource = asearchView;
                     SearchViewGridViewList.DataBind();
                     pdfbuttonid.Visible = true;
                 }
                 else
                 {
                     LabelMessage.Visible = true;                  
                     LabelMessage.Text = "Quantity not Available";
                     SearchViewGridViewList.DataSource = asearchView;
                     SearchViewGridViewList.DataBind();
                     pdfbuttonid.Visible = false;
                 }
            }
            else if (DropDownCompanyList.SelectedIndex != 0 && DropDownCategoryList.SelectedIndex != 0)
            {
                int companyId = Convert.ToInt32(DropDownCompanyList.SelectedItem.Value);
                int categoryId = Convert.ToInt32(DropDownCategoryList.SelectedItem.Value);
                List<SearchView> asearchView  =viewSearchManager.SearchByCompanyAndCategory(companyId, categoryId);
                if (asearchView.Count > 0)
                 {
                     ViewState["stockin"] = asearchView;
                     SearchViewGridViewList.DataSource = asearchView;
                     SearchViewGridViewList.DataBind();
                     pdfbuttonid.Visible = true;
                 }
                 else
                 {
                     LabelMessage.Visible = true;
                     LabelMessage.Text = "Quantity not Available";
                     SearchViewGridViewList.DataSource = asearchView;
                     SearchViewGridViewList.DataBind();
                    
                 }
            }
            else if (DropDownCompanyList.SelectedIndex == 0 && DropDownCategoryList.SelectedIndex == 0)
            {
                List<SearchView> asearchView = viewSearchManager.SearchByAll();
                if (asearchView.Count > 0)
                {
                    ViewState["stockin"] = asearchView;
                    SearchViewGridViewList.DataSource = asearchView;
                    SearchViewGridViewList.DataBind();
                    pdfbuttonid.Visible = true;
                }
                else
                {
                    LabelMessage.Visible = true;
                    LabelMessage.Text = "Stock In Quantity is not Available";
                    SearchViewGridViewList.DataSource = asearchView;
                    SearchViewGridViewList.DataBind();
                    pdfbuttonid.Visible = false;
                    
                }
            }
        }
        protected void ButtonPdfClick(object sender, EventArgs e)
        {

            List<SearchView> asearchView = (List<SearchView>)ViewState["stockin"];
            SearchViewGridViewList.DataSource = asearchView;
            SearchViewGridViewList.DataBind();

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=StockInReports.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            SearchViewGridViewList.AllowPaging = false;
            SearchViewGridViewList.DataBind();
            SearchViewGridViewList.RenderControl(hw);
            SearchViewGridViewList.HeaderRow.Style.Add("width", "15%");
            SearchViewGridViewList.HeaderRow.Style.Add("font-size", "10px");
            SearchViewGridViewList.Style.Add("text-decoration", "none");
            SearchViewGridViewList.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
            SearchViewGridViewList.Style.Add("font-size", "8px");
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 70f, 70f, 70f, 70f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            pdfDoc.Add(new Paragraph("Stock Management System\n"));
            pdfDoc.Add(new Paragraph("Item Stock In Reports\n"));
            pdfDoc.Add(new Paragraph("Date : " + DateTime.UtcNow.ToString("dd-mm-yyyy HH:mm:ss") + "\n\n\n"));
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();

        }
        //override method for error controling pdf
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
        protected void LogoutClick(object sender, EventArgs e)
        {
            Session.Remove("Username");
            Response.Redirect("UserLoginUI.aspx");
        }

        
    }
}