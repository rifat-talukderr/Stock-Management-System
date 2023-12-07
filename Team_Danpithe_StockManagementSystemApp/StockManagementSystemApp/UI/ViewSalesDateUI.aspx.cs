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
    public partial class ViewSalesDateUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("UserLoginUI.aspx");
            }
        }

        protected void CompareDate(string fromDate,string Todate)
        {
            if (fromDate == "" && Todate == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Textbox can not be blank!')", true);
                return;
            }
            else if (fromDate == "" || Todate == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Please input your Date')", true);
                return;
            }
            else
            {
                //here I have taken day part from textbox  
                string date1Day = fromDate.Substring(8);
                string date2Day = Todate.Substring(8);

                //here I have taken month part from textbox  
                string date1Month = fromDate.Substring(5, 2);
                string date2Month = Todate.Substring(5, 2);

                //here I have taken year part from textbox  
                string date1Year = fromDate.Remove(4);
                string date2Year = Todate.Remove(4);
               
                //here I have converting in datetime format  
                DateTime d1 = Convert.ToDateTime(date1Year + "/" + date1Month + "/" + date1Day);
                DateTime d2 = Convert.ToDateTime(date2Year + "/" + date2Month + "/" + date2Day);


                if (d1 > d2)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('From Date must be less or equal To Date')", true);
                }
                else
                {
                    // Search in database sell item
                    ViewSellManger viewSellManger = new ViewSellManger();
                    List<ViewSell> aviewSell = viewSellManger.SearchByDate(fromDate, Todate);
                    
                    if (aviewSell.Count > 0)
                    {
                        ViewState["Sales"] = aviewSell;
                        SearchSellGridViewList.DataSource = aviewSell;
                        SearchSellGridViewList.DataBind();
                        
                        pdfbuttonid.Visible = true;
                    }
                    else
                    {
                        LabelMessage.Visible = true;
                        LabelMessage.Text = "Sale Quantity Is Not Available";
                      
                        SearchSellGridViewList.DataSource = aviewSell;
                        SearchSellGridViewList.DataBind();
                    }
                }
            }
        } 
        protected void SearchButtonClick(object sender, EventArgs e)
        {
            string fromDate = FromDateTextboxId.Text;
            string Todate = ToDateTextboxId.Text;
            CompareDate(fromDate, Todate);
                           
        }

        //pdf export
        protected void ButtonPdfClick(object sender, EventArgs e)
        {

            List<ViewSell> aviewSell = (List<ViewSell>)ViewState["Sales"];
            SearchSellGridViewList.DataSource = aviewSell;
            SearchSellGridViewList.DataBind();

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=StockManagementReports.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            SearchSellGridViewList.AllowPaging = false;
            SearchSellGridViewList.DataBind();
            SearchSellGridViewList.RenderControl(hw);
            SearchSellGridViewList.HeaderRow.Style.Add("width", "15%");
            SearchSellGridViewList.HeaderRow.Style.Add("font-size", "10px");
            SearchSellGridViewList.Style.Add("text-decoration", "none");
            SearchSellGridViewList.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
            SearchSellGridViewList.Style.Add("font-size", "8px");
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 80f, 80f, 80f, 80f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            pdfDoc.Add(new Paragraph("Stock Management System\n"));
            pdfDoc.Add(new Paragraph("Item Sale Reports\n"));
            pdfDoc.Add(new Paragraph("Date : "+DateTime.UtcNow.ToString("dd-mm-yyyy HH:mm:ss")+"\n\n\n"));
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