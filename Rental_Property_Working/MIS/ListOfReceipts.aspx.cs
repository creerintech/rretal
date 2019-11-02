using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using Build.Utility;
using Build.EntityClass;
using Build.DB;
using Build.DataModel;
using Build.DALSQLHelper;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Drawing;

using System.Text;
using System.Globalization;

public partial class MIS_ListOfReceipts : System.Web.UI.Page
{
    #region[Private Variables]
    DMMISReceipt Obj_Receipt = new DMMISReceipt();   
    ReceiptMaster Entity_Receipt = new ReceiptMaster();
    CommanFunction Obj_Comm = new CommanFunction();
    DataSet DS = new DataSet();
    public static DataSet dsExport = new DataSet();
    private string StrError = string.Empty;
    private string StrCondition = string.Empty;
    decimal NetAmount = 0;
    private static bool FlagPrint = false;
    #endregion

    public void CheckUserRight()
    {
        try
        {
            FlagPrint = false;
            #region [USER RIGHT]
            //Checking Session Varialbels========
            if (Session["UserName"] != null && Session["UserRole"] != null)
            {
                ////Checking User Role========
                //if (!Session["UserRole"].Equals("Administrator"))
                //{
                //    //Checking Right of users=======

                System.Data.DataSet dsChkUserRight = new System.Data.DataSet();
                System.Data.DataSet dsChkUserRight1 = new System.Data.DataSet();
                dsChkUserRight1 = (DataSet)Session["DataSet"];

                DataRow[] dtRow = dsChkUserRight1.Tables[1].Select("FormName ='List Of Receipts'");
                if (dtRow.Length > 0)
                {
                    DataTable dt = dtRow.CopyToDataTable();
                    dsChkUserRight.Tables.Add(dt);
                }
                if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["ViewAuth"].ToString()) == false
                    && Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["PrintAuth"].ToString()) == false)
                {
                    Response.Redirect("~/Masters/NotAuthUser.aspx");

                }
                //Checking View Right ========                    
                if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["ViewAuth"].ToString()) == false)
                {
                    BtnShow.Visible = false;
                }
                //Checking Print Right ========                    
                if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["PrintAuth"].ToString()) == false)
                {
                    ImgBtnPrint.Visible = false;
                    ImgBtnExport.Visible = false;
                    ImgPDF.Visible = false;

                    FlagPrint = true;
                }

                dsChkUserRight.Dispose();
                // }
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            #endregion
        }
        catch (ThreadAbortException)
        {
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    private void MakeEmptyForm()
    {
        ChkFrmDate.Checked = false;

        ChkFrmDate.Focus();

        ddlProperty.SelectedIndex = 0;
        ddlParty.Items.Clear();

        ddlCompany.SelectedIndex = 0;
       // ddlFlatNo.Items.Clear();
        txtFromDate.Enabled = txtToDate.Enabled = true;
        
        ImgBtnPrint.Visible = false;
        ImgBtnExport.Visible = false;
        ImgPDF.Visible = false;

        HttpContext.Current.Cache["DirAllCustomer"] = "";
        txtUnitNo.Text = "";

        lblCount.Visible = false;
        lblCount.ForeColor = Color.Red;
        lblCount.Font.Bold = true;
        lblCount.Font.Size = 10;

        

        Fillcombo();
        SetInitialRow();
    }

    private void Fillcombo()
    {
        try
        {
            DS = Obj_Receipt.BindCombo(out StrError);
            if (DS.Tables.Count > 0)
            {
                if (DS.Tables[0].Rows.Count > 0)
                {
                    ddlProperty.DataSource = DS.Tables[0];
                    ddlProperty.DataTextField = "Property";
                    ddlProperty.DataValueField = "PropertyId";
                    ddlProperty.DataBind();
                }

                if (DS.Tables[1].Rows.Count > 0)
                {
                    ddlParty.DataSource = DS.Tables[1];
                    ddlParty.DataTextField = "PartyName";
                    ddlParty.DataValueField = "PartyId";
                    ddlParty.DataBind();
                }

                if (DS.Tables[2].Rows.Count > 0)
                {
                    ddlCompany.DataSource = DS.Tables[2];
                    ddlCompany.DataTextField = "CompanyName";
                    ddlCompany.DataValueField = "CompanyId";
                    ddlCompany.DataBind();
                }
            }
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }

    public void SetInitialRow()
    {
        try
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("Property", typeof(string)));          
            dt.Columns.Add(new DataColumn("PartyName", typeof(string)));
            dt.Columns.Add(new DataColumn("UnitNo", typeof(string)));
            dt.Columns.Add(new DataColumn("CompanyName", typeof(string)));
            dt.Columns.Add(new DataColumn("ReceiptNo", typeof(string)));
            dt.Columns.Add(new DataColumn("ReceiptDate", typeof(string))); 
            dt.Columns.Add(new DataColumn("VoucherAmt", typeof(decimal)));        
            dt.Columns.Add(new DataColumn("#", typeof(int)));
            dt.Columns.Add(new DataColumn("ForTheMonth", typeof(string)));                                  
            dr = dt.NewRow();

            dr["#"] = 0;         
            dr["Property"] = "";
            dr["PartyName"] = "";
            dr["UnitNo"] = "";
            dr["CompanyName"] = "";
            dr["ReceiptNo"] = "";
            dr["ReceiptDate"] = "";                
            dr["VoucherAmt"] = 0;
            dr["ForTheMonth"] = ""; 
                                        
            dt.Rows.Add(dr);
            ViewState["Summary"] = dt;
            GridReceiptList.DataSource = dt;
            GridReceiptList.DataBind();
            dt = null;
            dr = null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
   
    protected void ChkFrmDate_CheckedChanged(object sender, EventArgs e)
    {
        if (ChkFrmDate.Checked == true)
        {
            txtFromDate.Text = DateTime.Now.AddMonths(-1).ToString("dd-MMM-yyyy");
            txtToDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            txtFromDate.Enabled = true;
            txtToDate.Enabled = true;
            ChkFrmDate.Focus();
        }
        else
        {
            txtFromDate.Text = string.Empty;
            txtToDate.Text = string.Empty;
            txtFromDate.Enabled = false;
            txtToDate.Enabled = false;
            ChkFrmDate.Focus();
        }
    }

    protected void ddlProperty_SelectedIndexChanged(object sender, EventArgs e)
    {
        //try
        //{
        //    DS = Obj_Receipt.BindCombo(out StrError);
        //    if (DS.Tables.Count > 0)
        //    { 
        //        if (DS.Tables[0].Rows.Count > 0)
        //        {
        //            ddlPROPERTYTo.DataSource = DS.Tables[0];
        //            ddlPROPERTYTo.DataTextField = "Property";
        //            ddlPROPERTYTo.DataValueField = "PropertyId";
        //            ddlPROPERTYTo.DataBind();
        //        }

        //        if (DS.Tables[1].Rows.Count > 0)
        //        {
        //            ddlReceivedFrom.DataSource = DS.Tables[1];
        //            ddlReceivedFrom.DataTextField = "PartyName";
        //            ddlReceivedFrom.DataValueField = "PartyId";
        //            ddlReceivedFrom.DataBind();
        //        }
        //    }
        //}
        //catch (Exception ex) { throw new Exception(ex.Message); }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CheckUserRight();
            MakeEmptyForm();
        }
    }

    protected void BtnShow_Click(object sender, EventArgs e)
    {
        try
        {
            ReportGrid();
            GridReceiptList.Focus();
        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg(ex.Message, this.Page);
        }
    }

    private void ReportGrid()
    {
        try
        {

            StrCondition = string.Empty;

            if (ChkFrmDate.Checked == true)
            {
                StrCondition = StrCondition + " and RV.ReceiptDate between '" + Convert.ToDateTime(txtFromDate.Text).ToString("MM-dd-yyyy") + "' AND '" + Convert.ToDateTime(txtToDate.Text).ToString("MM-dd-yyyy") + "' ";
            }
            if (Convert.ToInt32(ddlProperty.SelectedValue) > 0)
            {
                StrCondition = StrCondition + " and RV.PropertyId='" + (ddlProperty.SelectedValue) + "' ";
            }
            if (!string.IsNullOrEmpty(ddlParty.Text) && Convert.ToInt32(ddlParty.SelectedValue) > 0)
            {
                StrCondition = StrCondition + " and RV.PartyId='" + (ddlParty.SelectedValue) + "' ";
            }
            if (!string.IsNullOrEmpty(ddlCompany.Text) && Convert.ToInt32(ddlCompany.SelectedValue) > 0)
            {
                StrCondition = StrCondition + " and PM.CompanyId='" + (ddlCompany.SelectedValue) + "' ";
            }
            if (!string.IsNullOrEmpty(txtUnitNo.Text))
            {
                StrCondition = StrCondition + " RV.UnitNo='" + (txtUnitNo.Text) + "' ";
            }
           
        
            DS = Obj_Receipt.GetReceiptMaster(StrCondition, out StrError);
            if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
            {
                ViewState["Summary"] = DS.Tables[0];
                GridReceiptList.DataSource = DS.Tables[0];
                GridReceiptList.DataBind();

                if (!FlagPrint)
                {
                    ImgBtnPrint.Visible = false;
                    ImgBtnExport.Visible = true;
                    ImgPDF.Visible = true;
                }
                lblCount.Text = DS.Tables[0].Rows.Count + " Records Found";
                lblCount.Visible = true;
                dsExport = DS.Copy();
            }
            else
            {

                GridReceiptList.DataSource = null;
                GridReceiptList.DataBind();
                lblCount.Text = "No Records Found!!";
                lblCount.Visible = true;
                SetInitialRow();
              
                ImgBtnPrint.Visible = false;
                ImgBtnExport.Visible = false;
                ImgPDF.Visible = false;

            }

        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg(ex.Message, this.Page);
        }
    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        MakeEmptyForm();
    }

    protected void ImgPDF_Click(object sender, ImageClickEventArgs e)
    {
        //#region OLD
        ////try
        ////{

        ////    if (dsExport.Tables.Count > 0 && dsExport.Tables[0].Rows.Count > 0)
        ////    {
        ////        GridView GridExp = new GridView();
        ////        GridExp.DataSource = dsExport.Tables[0];
        ////        GridExp.DataBind();
        ////        Build.Utility.CommanFunctionPDF oPDF = new Build.Utility.CommanFunctionPDF();
        ////        string ImagePath = Server.MapPath("~/Images/Icon/mayurlogo1.jpg");
        ////        string Header = string.Empty;
        ////        //if (ViewState["Header"] != null)
        ////        //{
        ////        Response.Clear();
        ////        //   Header = Convert.ToString(ViewState["Header"]);
        ////        Header = "List Of Receipts";
        ////        GeneratePDF(ImagePath, Header + ".pdf", Header, GridExp, this.Page);
        ////        Header = Header.Replace(" ", "_");
        ////        Response.ContentType = "application/pdf";
        ////        Response.AddHeader("content-disposition", "attachment; filename=" + Header + ".pdf");
        ////        Response.Flush();
        ////        Response.End();
        ////        //}
        ////    }

        ////    else
        ////    {
        ////        Obj_Comm.ShowPopUpMsg("No Data Found..!", this.Page);
        ////        //GridReportList.DataSource = dsLogin.Tables[0];
        ////        //GridReportList.DataBind();

        ////        //dsLogin.Clear();

        ////    }


        ////}
        ////catch (Exception ex)
        ////{
        ////    ////Obj_Comm.ShowPopUpMsg(ex.Message, this.Page);
        ////}
        //#endregion
        //#region[DATATABLE]
        //try
        //{
        //    //  string BillNo = string.Empty;
        //    if (dsExport.Tables[0].Rows.Count > 0)
        //    {
        //        DataTable dtGrid = new DataTable();
        //        DataTable dtGridTemp = new DataTable();
        //        dtGrid = (DataTable)ViewState["Summary"];

        //        //dtGrid.Columns.Remove("BookingId");
        //        //To set the Columns Order in Excel Sheet
        //        //DataTableExtensionsForClolumnsBooking.SetColumnsOrder(dtGrid, "Employee", "BookingDate", "Project", "Building",
        //        //    "FlatNo", "FlatType", "PaymentTitle", "GrandAmount", "CustomerName", "EmailId", "ContactNo", "AreaInSqft",
        //        //    "RateperSqft", "InfraCharges", "DevelopmentCharges", "TotalFlatAmount", "OtherCharges",
        //        //    "Tax", "PaidAmount", "DuesPayment");


        //       // dtGrid.Columns["GrandAmount"].ColumnName = "GrandTotal";
        //        //dtGrid.Columns["TotalFlatAmount"].ColumnName = "AgreementValue";
        //        //To add A new Column T dataTable
        //        DataColumn dcolColumn = new DataColumn("SrNo", typeof(string));
        //        dtGrid.Columns.Add(dcolColumn);
        //        dtGrid.Columns["SrNo"].SetOrdinal(0);

        //        int CntAdd = 0;
        //        for (int i = 0; i < dtGrid.Rows.Count; i++)
        //        {
        //            CntAdd++;
        //            dtGrid.Rows[i]["SrNo"] = CntAdd.ToString();
        //        }
        //        CntAdd = 0;
        //        dtGridTemp = dtGrid.Copy();

        //        dtGridTemp.Columns["ChequeDDNo"].ColumnName = "Cheque/DDNo";
        //        dtGridTemp.Columns["ChequeDDDate"].ColumnName = "Cheque/DDDate";
        //        dtGridTemp.Columns["BankName"].ColumnName = "DraweeBank";
        //        dtGridTemp.Columns["RTGSTranNo"].ColumnName = "RTGSTransactionNo";

        //#endregion

        //        using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
        //        {
        //            #region[PDF Table Declaration]

        //            Document document = new Document();

        //            //Document document = new Document(new iTextSharp.text.Rectangle(288f, 144f), 10, 10, 10, 10);
        //            document.SetPageSize(iTextSharp.text.PageSize.A4_LANDSCAPE.Rotate());

        //            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);


        //            document.Open();

        //            iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.TIMES, 7);
        //            iTextSharp.text.Font font6 = iTextSharp.text.FontFactory.GetFont(FontFactory.TIMES_BOLD, 7);
        //            iTextSharp.text.Font font14 = iTextSharp.text.FontFactory.GetFont(FontFactory.TIMES_BOLD, 8);
        //            iTextSharp.text.Font font16 = iTextSharp.text.FontFactory.GetFont(FontFactory.COURIER_BOLD, 9);

        //            #endregion

        //            #region [ADDRESS]
        //            string ProjectName = string.Empty;
        //            if (long.Parse(ddlProject.SelectedIndex.ToString()) > 0)
        //            {
        //                ProjectName = ddlProject.SelectedItem.Text;
        //            }

        //            PdfPTable tableAddress = new PdfPTable(6);
        //            float[] widthAddress = new float[] { 4f, 4f, 4f, 4f, 4f, 4f };
        //            PdfPCell cellAddress = new PdfPCell(new Phrase(ProjectName));
        //            cellAddress.Colspan = 6;
        //            cellAddress.FixedHeight = 80.0f;
        //            cellAddress.HorizontalAlignment = 1;
        //            cellAddress.HorizontalAlignment = Element.ALIGN_RIGHT;
        //            cellAddress.VerticalAlignment = Element.ALIGN_MIDDLE;
        //            cellAddress.Border = PdfPCell.NO_BORDER;

        //            tableAddress.SetWidths(widthAddress);
        //            tableAddress.WidthPercentage = 45;
        //            tableAddress.HorizontalAlignment = Element.ALIGN_RIGHT;
        //            tableAddress.AddCell(cellAddress);
        //            document.Add(tableAddress);

        //            #endregion

        //            #region[GENERATED DATE AND TIME]
        //            PdfPTable tableDate = new PdfPTable(1);
        //            PdfPCell cellDateTime = new PdfPCell(new Phrase("PDF Generated Date & Time " + DateTime.Now.ToString(), font5));
        //            //  cellDateTime.Colspan = 7;
        //            cellDateTime.FixedHeight = 15.0f;
        //            cellDateTime.HorizontalAlignment = 1;
        //            cellDateTime.HorizontalAlignment = Element.ALIGN_CENTER;
        //            cellDateTime.VerticalAlignment = Element.ALIGN_TOP;
        //            cellDateTime.Border = PdfPCell.NO_BORDER;
        //            //   cellDateTime.Colspan = dtGrid.Columns.Count;

        //            tableDate.AddCell(cellDateTime);
        //            tableDate.WidthPercentage = 30;
        //            tableDate.HorizontalAlignment = Element.ALIGN_RIGHT;

        //            document.Add(tableDate);
        //            #endregion

        //            #region[DRAWLINE]

        //            PdfContentByte cb = writer.DirectContent;
        //            cb.SetLineWidth(0.5f);   // Make a bit thicker than 1.0 default
        //            cb.MoveTo(0, document.Top - 70f);
        //            cb.LineTo(1000, document.Top - 70f);
        //            cb.Stroke();

        //            #endregion

        //            #region [Report Title]

        //            PdfPTable tableTitle = new PdfPTable(1);
        //            PdfPCell cellTitle = new PdfPCell(new Phrase("List Of Receipts Details", font16));
        //            cellTitle.Colspan = 7;
        //            cellTitle.FixedHeight = 30.0f;
        //            cellTitle.HorizontalAlignment = 1;
        //            cellTitle.HorizontalAlignment = Element.ALIGN_CENTER;
        //            cellTitle.VerticalAlignment = Element.ALIGN_TOP;
        //            cellTitle.Border = PdfPCell.NO_BORDER;
        //            cellTitle.Colspan = dtGrid.Columns.Count;

        //            tableTitle.AddCell(cellTitle);
        //            document.Add(tableTitle);

        //            #endregion

        //            #region[DATE]
        //            PdfPTable table;
        //            float[] widths;

        //            if (dtGridTemp.Columns.Count == 14)
        //            {
        //                widths = new float[] { 2f, 5f, 5f, 6f, 4f, 4f, 4f, 4f, 4f, 3f, 3f };
        //                table = new PdfPTable(dtGridTemp.Columns.Count);
        //            }
        //            else
        //            {

        //                table = new PdfPTable(dtGridTemp.Columns.Count);
        //                widths = new float[dtGridTemp.Columns.Count];
        //                for (int i = 0; i < dtGridTemp.Columns.Count; i++)
        //                {
        //                    if (i == 0)
        //                    {
        //                        widths[i] = 2f;
        //                    }

        //                    else if (dtGridTemp.Columns[i].ColumnName == "SrNo" || dtGridTemp.Columns[i].ColumnName == "DraweeBank" 
        //                            || dtGridTemp.Columns[i].ColumnName == "Project"
        //                            || dtGridTemp.Columns[i].ColumnName == "CustomerName")
        //                    {
        //                        widths[i] = 5f;
        //                    }
        //                    else if (dtGridTemp.Columns[i].ColumnName == "FlatNo" || dtGridTemp.Columns[i].ColumnName == "FlatType" || dtGridTemp.Columns[i].ColumnName == "Building"
        //                             || dtGridTemp.Columns[i].ColumnName == "ReceiptNo" || dtGridTemp.Columns[i].ColumnName == "PaymentMode")
        //                    {
        //                        widths[i] = 5f;
        //                    }
        //                    else if (dtGridTemp.Columns[i].ColumnName == "ReceiptDate" || dtGridTemp.Columns[i].ColumnName == "Cheque/DDNo"
        //                        || dtGridTemp.Columns[i].ColumnName == "Cheque/DDDate"
        //                        || dtGridTemp.Columns[i].ColumnName == "NetAmount" || dtGridTemp.Columns[i].ColumnName == "RTGSTransactionNo")
        //                    {
        //                        widths[i] = 6f;
        //                    }
        //                    //else if (dtGridTemp.Columns[i].ColumnName == "CustomerName" || dtGridTemp.Columns[i].ColumnName == "AgreementValue")
        //                    //{
        //                    //    widths[i] = 7f;
        //                    //}
        //                }

        //            }


        //            PdfPTable tableExtra = new PdfPTable(2);

        //            float[] widthsextra = new float[] { 4f, 4f };

        //            table.SetWidths(widths);
        //            table.WidthPercentage = 100;
        //            tableExtra.SetWidths(widthsextra);
        //            tableExtra.WidthPercentage = 30;
        //            tableExtra.HorizontalAlignment = Element.ALIGN_RIGHT;

        //            PdfPCell celldate = new PdfPCell(new Phrase("Date", font14));
        //            celldate.Colspan = 10;
        //            celldate.FixedHeight = 30.0f;
        //            celldate.HorizontalAlignment = 2;
        //            celldate.HorizontalAlignment = Element.ALIGN_CENTER;
        //            celldate.VerticalAlignment = Element.ALIGN_MIDDLE;
        //            celldate.Border = PdfPCell.NO_BORDER;

        //            PdfPCell cell = new PdfPCell(new Phrase("List Of Receipts Details", font14));
        //            cell.Colspan = 10;
        //            cell.FixedHeight = 30.0f;
        //            cell.HorizontalAlignment = 1;
        //            cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
        //            cell.Border = PdfPCell.NO_BORDER;
        //            cell.Colspan = dtGrid.Columns.Count;

        //            tableExtra.AddCell(celldate);

        //            PdfPCell lblBookingdate1 = new PdfPCell(new Phrase("From Receipt Date", font6));
        //            PdfPCell DTPBookingDate1 = new PdfPCell(new Phrase(txtFromDate.Text, font5));
        //            PdfPCell lblCheckIndate1 = new PdfPCell(new Phrase("To Receipt Date", font6));
        //            PdfPCell DTPCheckInDate1 = new PdfPCell(new Phrase(txtToDate.Text, font5));


        //            PdfPCell WithoutCheck = new PdfPCell(new Phrase(DateTime.Now.ToString("dd/MMM/yyyy"), font5));
        //            tableExtra.AddCell(lblBookingdate1);

        //            if (ChkFrmDate.Checked)
        //            {
        //                tableExtra.AddCell(DTPBookingDate1);
        //            }
        //            else
        //            {
        //                tableExtra.AddCell("-");
        //            }

        //            tableExtra.AddCell(lblCheckIndate1);

        //            if (ChkFrmDate.Checked)
        //            {
        //                tableExtra.AddCell(DTPCheckInDate1);
        //            }
        //            else
        //            {
        //                tableExtra.AddCell("-");
        //            }

        //            document.Add(tableExtra);

        //            #endregion

        //            #region[FOR FILTERS]

        //            PdfPTable maintableFilters = new PdfPTable(2);
        //            float[] widthmain = new float[] { 4f, 4f };

        //            PdfPTable tableFilters = new PdfPTable(2);
        //            float[] widthFilters = new float[] { 4f, 4f };

        //            PdfPCell cellFilters = new PdfPCell(new Phrase("Filters", font14));
        //            cellFilters.Colspan = 4;
        //            cellFilters.FixedHeight = 30.0f;
        //            cellFilters.HorizontalAlignment = 1;
        //            cellFilters.HorizontalAlignment = Element.ALIGN_CENTER;
        //            cellFilters.VerticalAlignment = Element.ALIGN_MIDDLE;
        //            cellFilters.Border = PdfPCell.NO_BORDER;

        //            tableFilters.SetWidths(widthFilters);
        //            tableFilters.WidthPercentage = 30;
        //            tableFilters.HorizontalAlignment = Element.ALIGN_RIGHT;

        //            tableFilters.AddCell(cellFilters);

        //            if (Convert.ToInt32(ddlProject.SelectedIndex) <= 0)
        //            {
        //                PdfPCell lblParty1 = new PdfPCell(new Phrase("Project Name", font6));
        //                PdfPCell cmbParty1 = new PdfPCell(new Phrase("-", font5));
        //                tableFilters.AddCell(lblParty1);
        //                tableFilters.AddCell(cmbParty1);
        //            }
        //            else
        //            {
        //                string sValue = ddlProject.SelectedItem.Text;

        //                PdfPCell lblParty1 = new PdfPCell(new Phrase("Project Name", font6));
        //                PdfPCell cmbParty1 = new PdfPCell(new Phrase(sValue, font5));
        //                tableFilters.AddCell(lblParty1);
        //                tableFilters.AddCell(cmbParty1);
        //            }
        //            if (long.Parse(ddlTower.SelectedIndex.ToString()) <= 0)
        //            {
        //                PdfPCell lblParty1 = new PdfPCell(new Phrase("Building Name", font6));
        //                PdfPCell cmbParty1 = new PdfPCell(new Phrase("-", font5));
        //                tableFilters.AddCell(lblParty1);
        //                tableFilters.AddCell(cmbParty1);
        //            }
        //            else
        //            {
        //                string sValue = ddlTower.SelectedItem.Text;

        //                PdfPCell lblParty1 = new PdfPCell(new Phrase("Building Name", font6));
        //                PdfPCell cmbParty1 = new PdfPCell(new Phrase(sValue, font5));
        //                tableFilters.AddCell(lblParty1);
        //                tableFilters.AddCell(cmbParty1);
        //            }
                    
        //            if (long.Parse(ddlFlatNo.SelectedIndex.ToString()) <= 0)
        //            {
        //                PdfPCell lblPrinciple1 = new PdfPCell(new Phrase("Flat No", font6));
        //                PdfPCell cmbPrinciple1 = new PdfPCell(new Phrase("-", font5));
        //                tableFilters.AddCell(lblPrinciple1);
        //                tableFilters.AddCell(cmbPrinciple1);
        //            }
        //            else
        //            {
        //                string sValue = ddlFlatNo.SelectedItem.Text;

        //                PdfPCell lblPrinciple1 = new PdfPCell(new Phrase("Flat No", font6));
        //                PdfPCell cmbPrinciple1 = new PdfPCell(new Phrase(sValue, font5));
        //                tableFilters.AddCell(lblPrinciple1);
        //                tableFilters.AddCell(cmbPrinciple1);
        //            }
        //            //if (long.Parse(ddlFlatType.SelectedIndex.ToString()) <= 0)
        //            //{
        //            //    PdfPCell lblPrinciple1 = new PdfPCell(new Phrase("Flat Type", font6));
        //            //    PdfPCell cmbPrinciple1 = new PdfPCell(new Phrase("-", font5));
        //            //    tableFilters.AddCell(lblPrinciple1);
        //            //    tableFilters.AddCell(cmbPrinciple1);
        //            //}
        //            //else
        //            //{
        //            //    string sValue = ddlFlatType.SelectedItem.Text;

        //            //    PdfPCell lblPrinciple1 = new PdfPCell(new Phrase("Flat Type", font6));
        //            //    PdfPCell cmbPrinciple1 = new PdfPCell(new Phrase(sValue, font5));
        //            //    tableFilters.AddCell(lblPrinciple1);
        //            //    tableFilters.AddCell(cmbPrinciple1);
        //            //}
        //            if (string.IsNullOrEmpty(txtCustomer.Text))
        //            {
        //                PdfPCell lblPrinciple1 = new PdfPCell(new Phrase("Customer Name", font6));
        //                PdfPCell cmbPrinciple1 = new PdfPCell(new Phrase("-", font5));
        //                tableFilters.AddCell(lblPrinciple1);
        //                tableFilters.AddCell(cmbPrinciple1);
        //            }
        //            else
        //            {
        //                string sValue = txtCustomer.Text;

        //                PdfPCell lblPrinciple1 = new PdfPCell(new Phrase("Customer Name", font6));
        //                PdfPCell cmbPrinciple1 = new PdfPCell(new Phrase(sValue, font5));
        //                tableFilters.AddCell(lblPrinciple1);
        //                tableFilters.AddCell(cmbPrinciple1);
        //            }

        //            document.Add(tableFilters);

        //            #endregion
        //            table.AddCell(cell);
        //            foreach (DataColumn c in dtGridTemp.Columns)
        //            {

        //                PdfPCell cell2 = null;
        //                cell2 = new PdfPCell(new Phrase(c.ColumnName, font6));

        //                table.AddCell(cell2);
        //            }
        //            int Count = 0;

        //            DataRow dr1;

        //            for (int i = 0; i < dtGridTemp.Rows.Count; i++)
        //            {
        //                NetAmount += Convert.ToDecimal(dtGridTemp.Rows[i]["NetAmount"]);
        //            }
        //            dr1 = dtGridTemp.NewRow();


        //            //add values to each rows
        //            dr1["Cheque/DDDate"] = "Total";
        //            dr1["NetAmount"] = NetAmount;

        //            dtGridTemp.Rows.Add(dr1);

                    
        //            foreach (DataRow r in dtGridTemp.Rows)
        //            {
        //                Count++;
        //                if (dtGridTemp.Rows.Count > 0)
        //                {
        //                    PdfPCell cell2 = null;
        //                    for (int i = 0; i < dtGridTemp.Columns.Count; i++)
        //                    {
        //                        cell2 = new PdfPCell(new Phrase(r[i].ToString(), font5));

        //                        table.AddCell(cell2);
        //                    }
        //                }
        //            }

        //            document.Add(table);
        //            document.Close();
        //            memoryStream.Close();
        //            Response.Clear();
        //            Response.ContentType = "application/pdf";
        //            Response.AddHeader("Content-Disposition", "attachment; filename=ListOfReceipts.pdf");
        //            Response.ContentType = "application/pdf";
        //            Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //            Response.BinaryWrite((byte[])memoryStream.ToArray());
        //            Response.End();
        //            Response.Close();
        //        }

        //    }
        //}
        //catch (Exception ex)
        //{
        //    string str = ex.Message;
        //}
    }

    protected void ImgBtnExport_Click(object sender, ImageClickEventArgs e)
    {
        if (ViewState["Summary"] != null)
        {
            DataTable DtGrd = (DataTable)ViewState["Summary"];
            string PURINVNO = string.Empty;
            if (DtGrd.Rows.Count > 0)
            {
                GridView GridExp = new GridView();
                GridExp.DataSource = DtGrd;
                GridExp.DataBind();
                Obj_Comm.Export("ListOfReceipts.xls", GridExp);
            }
            else
            {
                Obj_Comm.ShowPopUpMsg("No Data Found To Export..!", this.Page);
                GridReceiptList.DataSource = null;
                GridReceiptList.DataBind();
            }
        }
        else
        {
            Obj_Comm.ShowPopUpMsg("No Data Found To Export..!", this.Page);
            SetInitialRow();
        }
            
    
    }

    public void GeneratePDF(string Imagepath, string fileName, string HeaderName, GridView GridReport, Page oPage)
    {
        //var document = new Document(PageSize.A4, 50, 50, 25, 25);
        //document.SetMargins(3, 3, 3, 3);
        //try
        //{
        //    // oPage.Response.Clear();
        //    PdfWriter.GetInstance(document, oPage.Response.OutputStream);
        //    // generates the grid first
        //    StringBuilder strB = new StringBuilder();
        //    StringBuilder strB1 = new StringBuilder();
        //    string str = string.Empty;
        //    str = " <table width='100%' ><tr><td align='center'><b>" + HeaderName + "</b></td></tr></table><br><br>";
        //    strB.Append(str);
        //    document.Open();
        //    using (StringWriter sWriter = new StringWriter(strB))
        //    {
        //        using (HtmlTextWriter htWriter = new HtmlTextWriter(sWriter))
        //        {
        //            GridReport.RenderControl(htWriter);
        //        }
        //    }

        //    // now read the Grid html one by one and add into the document object
        //    using (TextReader sReader = new StringReader(strB.ToString()))
        //    {
        //        //iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance(Imagepath);
        //        //document.Add(gif);
        //        List<IElement> list = HTMLWorker.ParseToList(sReader, new StyleSheet());
        //        foreach (IElement elm in list)
        //        {
        //            document.Add(elm);

        //        }
        //    }
        //    //oPage.Response.ContentType = "application/pdf";
        //    //oPage.Response.AddHeader("content-disposition", "attachment; filename=" + fileName);
        //    //oPage.Response.Flush();
        //    //oPage.Response.End();
        //}
        //catch (Exception ex)
        //{
        //    // throw new Exception(ex.Message);
        //}
        //finally
        //{
        //    document.Close();
        //}
    }

    protected void GridEnquiry_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //try
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        NetAmount += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NetAmount"));
        //        DataTable dt = new DataTable();
        //        if (ViewState["Summary"] != null)
        //        {
        //            dt = (DataTable)ViewState["Summary"];
        //        }
        //        //if (dt.Rows[0]["BookingId"].ToString() == "")
        //        //{
        //        //    GridEnquiry.Columns[0].Visible = false;
        //        //}
        //        //else
        //        //{
        //        //    GridEnquiry.Columns[0].Visible = true;
        //        //}
        //    }
        //    if (e.Row.RowType == DataControlRowType.Footer)
        //    {
        //        e.Row.Cells[10].Text = "Total";
        //        e.Row.Cells[11].Text = (Math.Round(NetAmount)).ToString("0,0.00", CultureInfo.CreateSpecificCulture("hi-IN"));

        //        NetAmount = 0;
        //    }
            
        //}
        //catch (Exception ex)
        //{
        //    throw new Exception(ex.Message);
        //}
    }

    protected void GridEnquiry_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //GridEnquiry.PageIndex = e.NewPageIndex;
        //ReportGrid();
    }

    protected void ddlParty_SelectedIndexChanged(object sender, EventArgs e)
    {
        //try
        //{
        //    DataSet Ds1 = new DataSet();
        //    Ds1 = Obj_Receipt.GetFlats(ddlTower.SelectedItem.Text, Convert.ToInt32(ddlProject.SelectedValue), Convert.ToInt32(Session["EmpID"]), out StrError);
        //    if (Ds1.Tables.Count > 0)
        //    {
        //        if (Ds1.Tables[0].Rows.Count > 0)
        //        {
        //            ddlFlatNo.DataSource = Ds1.Tables[0];
        //            ddlFlatNo.DataTextField = "FlatNo";
        //            ddlFlatNo.DataValueField = "PCDetailId";
        //            ddlFlatNo.DataBind();
        //        }
        //        if (Ds1.Tables[1].Rows.Count > 0)
        //        {
        //           HttpContext.Current.Cache["DirAllCustomer"] = Ds1.Tables[1];
        //            //ddlCustomer.DataSource = Ds1.Tables[1];
        //            //ddlCustomer.DataTextField = "Customer";
        //            //ddlCustomer.DataValueField = "CustId";
        //            //ddlCustomer.DataBind();
        //        }
        //        if (Ds1.Tables[2].Rows.Count > 0)
        //        {
        //            ddlFlatType.DataSource = Ds1.Tables[2];
        //            ddlFlatType.DataTextField = "FlatType";
        //            ddlFlatType.DataValueField = "FlatTypeId";
        //            ddlFlatType.DataBind();
        //        }
        //    }
        //}
        //catch (Exception ex)
        //{
        //    throw new Exception(ex.Message);
        //}
    }

    protected void ddlFlatNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        //try
        //{
        //    DataSet Ds1 = new DataSet();
        //    Ds1 = Obj_Receipt.GetCustomer(Convert.ToInt32(ddlFlatNo.SelectedValue), out StrError);
        //    if (Ds1.Tables.Count > 0)
        //    {
        //        if (Ds1.Tables[0].Rows.Count > 0)
        //        {
        //            HttpContext.Current.Cache["DirAllCustomer"] = Ds1.Tables[0];
        //            //ddlCustomer.DataSource = Ds1.Tables[0];
        //            //ddlCustomer.DataTextField = "Customer";
        //            //ddlCustomer.DataValueField = "CustId";
        //            //ddlCustomer.DataBind();
        //        }
        //    }
        //}
        //catch (Exception ex)
        //{
        //    throw new Exception(ex.Message);
        //}
    }


    protected void GridReceiptList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (GridReceiptList.Rows.Count > 1)
        //{
        //    for (int i = 0; i < GridReceiptList.Rows.Count; i++)
        //    {
        //        GridReceiptList.Rows[i].Cells[1].Text = Convert.ToDateTime(GridReceiptList.Rows[i].Cells[1].Text).ToShortDateString();
        //    }
        //}
    }
}
