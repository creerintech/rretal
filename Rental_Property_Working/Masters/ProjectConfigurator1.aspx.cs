using  System;
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

#region Pdf
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Text;
#endregion

#region Crystal Report
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using System.Globalization;
#endregion

public partial class Masters_ProjectConfigurator1 : System.Web.UI.Page
{
    #region[Private Variables]
    DMPropertyRentCard Obj_PC = new DMPropertyRentCard();
    PropertyRentCard Entity_PC = new PropertyRentCard();
    CommanFunction Obj_Comm = new CommanFunction();
    DataSet DS = new DataSet();
    DataSet DS1 = new DataSet();
  
    private string StrError = string.Empty;
    private string StrCondition = string.Empty;
    private static bool FlagAdd = false, FlagDel = false, FlagEdit = false, FlagPrint = false;
    //DateTime now = DateTime.Now;
    //DateTime StartDate = new DateTime(now.Year, now.Month, 1);
    //DateTime endDate = StartDate.AddMonths(1).AddDays(-1);
    #endregion

    protected void SetInitialRow()
    {
        try
        {
            DataTable dt = new DataTable();
            DataRow dr = null;

            dt.Columns.Add(new DataColumn("#", typeof(string)));
            dt.Columns.Add(new DataColumn("CHK", typeof(bool)));
            dt.Columns.Add(new DataColumn("FromDate", typeof(string)));
            dt.Columns.Add(new DataColumn("ToDate", typeof(string)));
            dt.Columns.Add(new DataColumn("CompanyId", typeof(string)));
            dt.Columns.Add(new DataColumn("RentalAmt", typeof(string)));
            dt.Columns.Add(new DataColumn("PropertyTaxAmt", typeof(string)));
            dt.Columns.Add(new DataColumn("SocietyMaintenaceAmt", typeof(string)));
            dt.Columns.Add(new DataColumn("DepositAmt", typeof(string)));
            dt.Columns.Add(new DataColumn("CollectedDate", typeof(string)));
            dt.Columns.Add(new DataColumn("Remark", typeof(string)));
            dt.Columns.Add(new DataColumn("Status", typeof(String)));
            dt.Columns.Add(new DataColumn("ProRentDtlsId", typeof(Int32)));
            dt.Columns.Add(new DataColumn("GSTPerDetails", typeof(decimal)));
           dt.Columns.Add(new DataColumn("FlagReceiptType", typeof(bool)));
           dt.Columns.Add(new DataColumn("GSTAmt", typeof(decimal)));
            dt.Columns.Add(new DataColumn("Amount", typeof(decimal)));
            dt.Columns.Add(new DataColumn("TaxTemplateID", typeof(Int32)));
 
            dr = dt.NewRow();

            dr["#"] = "";
            dr["CHK"] = 0;
            dr["FromDate"] = "";
            dr["ToDate"] = "";
            dr["CompanyId"] = 0;
            dr["RentalAmt"] = "";
            dr["DepositAmt"] = "";
            dr["PropertyTaxAmt"] = "";
            dr["SocietyMaintenaceAmt"] = "";
            dr["CollectedDate"] = "";
            dr["Remark"] ="";
            dr["Status"] = string.Empty;
            dr["ProRentDtlsId"] = 0;
            dr["GSTPerDetails"] = 0.00;
            dr["GSTAmt"] = 0.00;
            dr["FlagReceiptType"] = 0;
            dr["Amount"] = 0.00;
            dr["TaxTemplateID"] = 0;
            dt.Rows.Add(dr);

            //Store the DataTable in ViewState
          
            GridDetails.DataSource = dt;
            GridDetails.DataBind();
            ViewState["GridDetail"] = dt;

            dt = null;
            dr = null;
        }
        catch (Exception ex)
        {
            //Obj_Comm.ErrorLog("DepartmentActivityRegister.aspx", " SetInitialRow", ex.Message, ex.StackTrace, ex.Source, 1);
            //Obj_Comm.ShowPopUpMsg("Please try after Some Time..!", this.Page);
        }
    }

    private void MakeEmptyForm()
    {
        FillCombo();
        ViewState["EditID"] = null;
        SetInitialRow();
        
        GetCode();
        SetInitialRowReportGrid();
        ReportGrid(StrCondition);

        if (!FlagAdd)
            BtnSave.Visible = true;
        BtnUpdate.Visible = false;
        BtnDelete.Visible = false;
        //BtnPrint.Visible = false;
        
        ddlUnit.SelectedValue = "0";
              
       // txtProjectName.Text = string.Empty;
        ddlProjectName.SelectedValue = "0";
        txtUintArea.Text = string.Empty;
        txtUnitNo.Text = string.Empty;
        txtRent.Text = string.Empty;
        txtAddress.Text =string.Empty;
    }

    public void FillCombo()
    {
        try
        {
            DS = Obj_PC.FillCombo(out StrError);
            if (DS.Tables.Count > 0)
            {

                if (DS.Tables[0].Rows.Count > 0)
                {
                    ddlUnit.DataSource = DS.Tables[0];
                    ddlUnit.DataTextField = "FlatType";
                    ddlUnit.DataValueField = "FlatTypeId";
                    ddlUnit.DataBind();
                }
                else
                {
                    ddlUnit.DataSource = null;
                    ddlUnit.DataBind();
                }

                if (DS.Tables[1].Rows.Count > 0)
                {
                    ViewState["Company"] = DS.Tables[1];
                }
                else
                {
                    ViewState["Company"] = null;

                }

                if (DS.Tables[2].Rows.Count > 0)
                {
                    ddlProjectName.DataSource = DS.Tables[2];
                    ddlProjectName.DataTextField = "Property";
                    ddlProjectName.DataValueField = "PropertyId";
                    ddlProjectName.DataBind();
                }

                if (DS.Tables[3].Rows.Count > 0)
                {
                    ddlPartyName.DataSource = DS.Tables[3];
                    ddlPartyName.DataTextField = "PartyName";
                    ddlPartyName.DataValueField = "PartyId";
                    ddlPartyName.DataBind();
                }

                if (DS.Tables[4].Rows.Count > 0)
                {
                    ViewState["Tax"] = DS.Tables[4];
                }
                else
                {
                    ViewState["Tax"] = null;

                }
                
            }
        }
        catch (Exception)
        {
            
            throw;
        }
    }

    private void GetCode()
    {
        DS = Obj_PC.GetPCNo(out StrError);
        if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
        {
            txtPCNo.Text = DS.Tables[0].Rows[0]["PCNo"].ToString();
        }
    }

    //public void FillGST()
    //{
    //    DMProjectConfigurator obj_Order1 = new DMProjectConfigurator();
    //    DS = obj_Order1.GetTaxAmt(DateTime.Now, out StrError);
    //    if (DS.Tables.Count > 0)
    //    {
    //        for (int i = 0; i < GridDetails.Rows.Count; i++)
    //        {
    //            TextBox GSTPer = (TextBox)GridDetails.Rows[i].Cells[17].FindControl("GSTPerDetails");                               
    //            Decimal GST = Convert.ToDecimal(DS.Tables[0].Rows[0]["GST"]);
    //            GSTPer = GST.ToString("0.00");
     //((TextBox)e.Row.FindControl("GSTPerDetails")).Text = DS.Tables[1].Rows[0]["GST"].ToString();
    //        }

           
    //    }
        

    //}

    public void ReportGrid(string RepCondition)
    {
        string StrError = "";
        try
        {
            DS = Obj_PC.GetProject(RepCondition, out StrError);

            if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
            {
                ViewState["CurrentProject"] = DS.Tables[0];
                GrdReport.DataSource = DS.Tables[0];
                GrdReport.DataBind();
                HttpContext.Current.Cache["Dir"] = DS.Tables[0];
            }
            else
            {
                GrdReport.DataSource = null;
                GrdReport.DataBind();
            }
            Obj_PC = null;
            DS = null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    protected void SetInitialRowReportGrid()
    {
        try
        {
            DataTable dt = new DataTable();
            DataRow dr = null;

            dt.Columns.Add(new DataColumn("#", typeof(string)));
            dt.Columns.Add(new DataColumn("PCNo", typeof(string)));
            dt.Columns.Add(new DataColumn("PropertyName", typeof(string)));
            dt.Columns.Add(new DataColumn("FlatType", typeof(string)));
            dt.Columns.Add(new DataColumn("UnitNo", typeof(string)));
            dt.Columns.Add(new DataColumn("Rent", typeof(string)));
         
            dr = dt.NewRow();
            dr["#"] = "";
            dr["PCNo"] = "";
            dr["PropertyName"] = "";
            dr["FlatType"] = "";
            dr["UnitNo"] = "";
            dr["Rent"] = "";
           
            dt.Rows.Add(dr);
         
            ViewState["GrdReport"] = dt;
            GrdReport.DataSource = dt;
            GrdReport.DataBind();

            dt = null;
            dr = null;
        }
        catch (Exception)
        {
            throw;
        }
    }
 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            DataSet DST = new DataSet();

            if (!string.IsNullOrEmpty(Request.QueryString["PropertyRentCardId"]))
            {
                FillCombo();

                int PropertyRentCardId = Convert.ToInt32(Request.QueryString["PropertyRentCardId"]);
                {
                    DST = Obj_PC.GetPropertyToEdit(PropertyRentCardId, out StrError);

                    if (DST.Tables.Count > 0 && DST.Tables[0].Rows.Count > 0)
                    {
                        txtPCNo.Text = DST.Tables[0].Rows[0]["PCNo"].ToString();
                        ddlProjectName.SelectedValue = DST.Tables[0].Rows[0]["PropertyId"].ToString();
                        ddlProjectName_SelectedIndexChanged(sender, e);
                        ddlPartyName.SelectedValue = DST.Tables[0].Rows[0]["PartyId"].ToString();
                        txtUnitNo.Text = DST.Tables[0].Rows[0]["UnitNo"].ToString();
                        ddlUnit.SelectedValue = DST.Tables[0].Rows[0]["FlatTypeId"].ToString();
                        txtUintArea.Text = DST.Tables[0].Rows[0]["SqFt"].ToString();
                        txtRent.Text = DST.Tables[0].Rows[0]["Rent"].ToString();
                        txtAddress.Text = DST.Tables[0].Rows[0]["PropertyAddress"].ToString();

                        if (DST.Tables.Count > 0 && DST.Tables[1].Rows.Count > 0)
                        {
                            GridDetails.DataSource = DST.Tables[1];
                            GridDetails.DataBind();
                            ViewState["GridDetail"] = DST.Tables[1];
                        }
                        else
                        {
                            SetInitialRow();
                        }
                        if (!FlagEdit)
                            BtnUpdate.Visible = true;
                        BtnSave.Visible = false;

                    }
                }
            }
            else
            {
                MakeEmptyForm();
               // FillGST();
            }
        }
        
    }

    protected void GridDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            GridViewRow gvr = e.Row;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = ViewState["CompanyName"] as DataTable;

                if (dt.Rows.Count > 0)
                {
                    ((DropDownList)e.Row.FindControl("GrdddlCompany")).DataSource = dt;
                    ((DropDownList)e.Row.FindControl("GrdddlCompany")).DataTextField = "CompanyName";
                    ((DropDownList)e.Row.FindControl("GrdddlCompany")).DataValueField = "CompanyId";
                    ((DropDownList)e.Row.FindControl("GrdddlCompany")).DataBind();
                    ((DropDownList)e.Row.FindControl("GrdddlCompany")).SelectedValue = ((Label)e.Row.FindControl("LblGrdddlCompany")).Text;
                }
                else
                {
                    ((DropDownList)e.Row.FindControl("GrdddlCompany")).DataSource = null;
                    ((DropDownList)e.Row.FindControl("GrdddlCompany")).DataBind();
                }


                DataTable DTTax = ViewState["Tax"] as DataTable;
                if (DTTax.Rows.Count > 0)
                {
                    ((DropDownList)e.Row.FindControl("GrdddlGSTPer")).DataSource = DTTax;
                    ((DropDownList)e.Row.FindControl("GrdddlGSTPer")).DataTextField = "TaxName";
                    ((DropDownList)e.Row.FindControl("GrdddlGSTPer")).DataValueField = "TaxTemplateID";
                    ((DropDownList)e.Row.FindControl("GrdddlGSTPer")).DataBind();
                    ((DropDownList)e.Row.FindControl("GrdddlGSTPer")).SelectedValue = ((Label)e.Row.FindControl("LblGrdddlGSTPer")).Text;
                }
                else
                {
                    ((DropDownList)e.Row.FindControl("GrdddlCompany")).DataSource = null;
                    ((DropDownList)e.Row.FindControl("GrdddlCompany")).DataBind();
                }

                //DMProjectConfigurator obj_Order1 = new DMProjectConfigurator();
                //DS = obj_Order1.GetTaxAmt(DateTime.Now, out StrError);
                //if (DS.Tables.Count > 0)
                //{
                //    //for (int i = 0; i < GridDetails.Rows.Count; i++)
                //    //{
                //        //TextBox GSTPer = (TextBox)GridDetails.Rows[i].Cells[17].FindControl("GSTPerDetails");
                //        ((TextBox)e.Row.FindControl("GSTPerDetails")).Text = DS.Tables[1].Rows[0]["GST"].ToString();
                //   // }


                //}


                if (e.Row.DataItemIndex != 0)
                {
                    foreach (GridViewRow row in GridDetails.Rows)
                    {
                        if (((Label)e.Row.FindControl("LblGrdddlCompany")).Text == row.Cells[13].Text)
                        {
                            TextBox FDate = (TextBox)e.Row.FindControl("txtFromDate");
                            TextBox TDate = (TextBox)e.Row.FindControl("txtToDate");
                            string Fromdate = FDate.Text;//This will be desired one
                            string Todate = TDate.Text;

                            TextBox textbox = row.FindControl("txtFromDate") as TextBox;
                            string a = textbox.Text;
                            TextBox textboxTo = row.FindControl("txtToDate") as TextBox;
                            string b = textboxTo.Text;
                            
                            if (Fromdate == a && Todate == b)
                            {
                                Obj_Comm.ShowPopUpMsg("You have already enter the same Date", this.Page);
                                gvr.Parent.Controls.RemoveAt(gvr.RowIndex);

                                break;
                            }                           
                        }
                    }
                }
           }            
        }
        catch (Exception)
        {

            throw;
        }
    }

    protected void ImgAddRrow_Click(object sender, ImageClickEventArgs e)
    {
        bool DupFlag = false;
        int k = 0, chkcount = 0;
        int rowIndex = 0;
        if (Convert.ToInt32(ddlProjectName.SelectedValue) > 0)
        {
            if (ViewState["GridDetail"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["GridDetail"];
                DataTable DTTEMP = dtCurrentTable.Clone();
                DataRow dtTableRow = null;
                #region

                if (GridDetails.Rows[0].Cells[1].Text.Equals("&nbsp;") || string.IsNullOrEmpty(GridDetails.Rows[0].Cells[1].Text))
                {
                    dtCurrentTable.Rows.RemoveAt(0);
                }

                for (int i = 0; i < GridDetails.Rows.Count; i++)
                {
                    CheckBox checkAll = (CheckBox)GridDetails.Rows[i].Cells[1].FindControl("ChkAllocate");
                    TextBox txtFromDate = (TextBox)GridDetails.Rows[i].Cells[4].FindControl("txtFromDate");
                    TextBox txtToDate = (TextBox)GridDetails.Rows[i].Cells[5].FindControl("txtToDate");
                    TextBox txtRentalAmt = (TextBox)GridDetails.Rows[i].Cells[7].FindControl("txtRentalAmt");
                    TextBox txtCollectedDate = (TextBox)GridDetails.Rows[i].Cells[8].FindControl("txtCollectedDate");
                    TextBox txtRemark = (TextBox)GridDetails.Rows[i].Cells[12].FindControl("txtRemark");

                    TextBox txtPropertyTaxAmt = (TextBox)GridDetails.Rows[i].Cells[10].FindControl("txtPropertyTaxAmt");
                    TextBox txtSocietyMaintenaceAmt = (TextBox)GridDetails.Rows[i].Cells[11].FindControl("txtSocietyMaintenaceAmt");
                    TextBox txtDepositAmt = (TextBox)GridDetails.Rows[i].Cells[9].FindControl("txtDepositAmt");
                    DropDownList GrdddlGSTPer = (DropDownList)GridDetails.Rows[i].Cells[17].FindControl("GrdddlGSTPer");
                    TextBox GSTPerDetails = (TextBox)GridDetails.Rows[i].Cells[18].FindControl("GSTPerDetails");
                    TextBox CGSTAmt = (TextBox)GridDetails.Rows[i].Cells[19].FindControl("CGSTAmt");
                    TextBox TotalAmount = (TextBox)GridDetails.Rows[i].Cells[20].FindControl("TotalAmount");

                    DropDownList GrdddlCompany = (DropDownList)GridDetails.Rows[i].Cells[6].FindControl("GrdddlCompany");
                    Label LblEntryId = (Label)GridDetails.Rows[i].Cells[0].FindControl("LblEntryId");

                    if (Convert.ToInt32(GrdddlCompany.SelectedValue.ToString()) > 0)
                    {
                        dtTableRow = DTTEMP.NewRow();
                        dtTableRow["#"] = LblEntryId.Text;
                        dtTableRow["CHK"] = checkAll.Checked;
                        dtTableRow["FromDate"] = txtFromDate.Text;
                        dtTableRow["ToDate"] = txtToDate.Text;
                        dtTableRow["CompanyId"] = Convert.ToInt32(GrdddlCompany.SelectedValue);
                        dtTableRow["PropertyTaxAmt"] = txtPropertyTaxAmt.Text;
                        dtTableRow["SocietyMaintenaceAmt"] = txtSocietyMaintenaceAmt.Text;
                        dtTableRow["RentalAmt"] = !string.IsNullOrEmpty(txtRentalAmt.Text) ? Convert.ToDecimal(txtRentalAmt.Text) : 0;
                        dtTableRow["CollectedDate"] = txtCollectedDate.Text;
                        dtTableRow["Remark"] = txtRemark.Text;
                        dtTableRow["DepositAmt"] = !string.IsNullOrEmpty(txtDepositAmt.Text) ? Convert.ToDecimal(txtDepositAmt.Text) : 0;   
                        dtTableRow["Status"] = Convert.ToString(GridDetails.Rows[i].Cells[12].Text);

                        if (!string.IsNullOrEmpty(GridDetails.Rows[i].Cells[15].Text))
                        {
                            dtTableRow["ProRentDtlsId"] = Convert.ToInt32(GridDetails.Rows[i].Cells[15].Text);
                        }
                        else
                        {
                            dtTableRow["ProRentDtlsId"] = 0;
                        }


                        if (GridDetails.Rows[i].Cells[16].Text.Equals("0") || string.IsNullOrEmpty(GridDetails.Rows[i].Cells[16].Text))
                        {
                        //if (string.IsNullOrEmpty(GridDetails.Rows[i].Cells[16].Text) || Convert.ToBoolean(GridDetails.Rows[i].Cells[16].Text) != false)
                        //{

                        //if (Convert.ToBoolean(GridDetails.Rows[i].Cells[16].Text) != false)
                        //{ 
                            dtTableRow["FlagReceiptType"] =1;
                        }
                        else
                        {
                            dtTableRow["FlagReceiptType"] = 0;
                        }
                       // dtTableRow["FlagReceiptType"] = Convert.ToBoolean(GridDetails.Rows[i].Cells[16].Text);
                        dtTableRow["TaxTemplateID"] = Convert.ToInt32(GrdddlGSTPer.SelectedValue);
                        dtTableRow["GSTPerDetails"] = !string.IsNullOrEmpty(GSTPerDetails.Text) ? Convert.ToDecimal(GSTPerDetails.Text) : 0;   
                        dtTableRow["GSTAmt"] = !string.IsNullOrEmpty(CGSTAmt.Text) ? Convert.ToDecimal(CGSTAmt.Text) : 0;
                        dtTableRow["Amount"] = !string.IsNullOrEmpty(TotalAmount.Text) ? Convert.ToDecimal(TotalAmount.Text) : 0;
                        rowIndex++;

                        DTTEMP.Rows.Add(dtTableRow);
                    }
                }              
                if (DTTEMP.Rows.Count > 0)
                {
                    dtCurrentTable = DTTEMP;
                }
                dtTableRow = null;
                #endregion

                if (dtCurrentTable.Rows.Count > 0)
                {
                    dtTableRow = dtCurrentTable.NewRow();

                    dtTableRow["#"] =0;
                    dtTableRow["CHK"] = false;
                   // dtTableRow["FromDate"] = DateTime.Now.ToString("dd/MMM/yyyy") ;
                    dtTableRow["ToDate"] = DateTime.Now.ToString("dd/MMM/yyyy");
                    dtTableRow["CompanyId"] = 0;
                    dtTableRow["RentalAmt"] = 0;
                    dtTableRow["ProRentDtlsId"] = 0;
                    for (int i = 0; i < GridDetails.Rows.Count; i++)
                    {
                        TextBox txtToDate = (TextBox)GridDetails.Rows[i].Cells[5].FindControl("txtToDate");
                        TextBox txtPropertyTaxAmt = (TextBox)GridDetails.Rows[i].Cells[9].FindControl("txtPropertyTaxAmt");
                        TextBox txtSocietyMaintenaceAmt = (TextBox)GridDetails.Rows[i].Cells[10].FindControl("txtSocietyMaintenaceAmt");
                        
                        dtTableRow["FromDate"] = txtToDate.Text;
                        dtTableRow["CollectedDate"] = txtToDate.Text; ;
                        dtTableRow["PropertyTaxAmt"] = !string.IsNullOrEmpty(txtPropertyTaxAmt.Text) ? Convert.ToDecimal(txtPropertyTaxAmt.Text) : 0; 
                        dtTableRow["SocietyMaintenaceAmt"] = !string.IsNullOrEmpty(txtSocietyMaintenaceAmt.Text) ? Convert.ToDecimal(txtSocietyMaintenaceAmt.Text) : 0; 
                    }
                  
                   // dtTableRow["CollectedDate"] = DateTime.Now.ToString("dd/MMM/yyyy");
                   
                    dtTableRow["Remark"] = "";
                    dtTableRow["Status"] = "Unpaid";
                    dtTableRow["DepositAmt"] =0.00;
                    dtTableRow["TaxTemplateID"] = 0;
                    dtTableRow["GSTPerDetails"] =0.00;
                    dtTableRow["GSTAmt"] = 0.00;                  
                    dtTableRow["Amount"] = 0.00;
                    dtTableRow["FlagReceiptType"] = 0;

                    dtCurrentTable.Rows.Add(dtTableRow);
                    ViewState["GridDetail"] = dtCurrentTable;
                    GridDetails.DataSource = dtCurrentTable;
                    GridDetails.DataBind();

                   // Makecontrolempty();

               
                }            
            }
        }
    }

    protected void ImgAddRrowButton_Click(object sender, ImageClickEventArgs e)
    {
        bool DupFlag = false;
        int k = 0, chkcount = 0;
        int rowIndex = 0;
        if (Convert.ToInt32(ddlProjectName.SelectedValue)>0)
        {
            if (ViewState["GridDetail"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["GridDetail"];
                DataTable DTTEMP = dtCurrentTable.Clone();
                DataRow dtTableRow = null;
                #region

                if (GridDetails.Rows[0].Cells[1].Text.Equals("&nbsp;") || string.IsNullOrEmpty(GridDetails.Rows[0].Cells[1].Text))
                {
                    dtCurrentTable.Rows.RemoveAt(0);
                }
                for (int i = 0; i < GridDetails.Rows.Count; i++)
                {

                    CheckBox checkAll = (CheckBox)GridDetails.Rows[i].Cells[1].FindControl("ChkAllocate");
                    TextBox txtFromDate = (TextBox)GridDetails.Rows[i].Cells[4].FindControl("txtFromDate");
                    TextBox txtToDate = (TextBox)GridDetails.Rows[i].Cells[5].FindControl("txtToDate");
                    TextBox txtRentalAmt = (TextBox)GridDetails.Rows[i].Cells[7].FindControl("txtRentalAmt");
                    TextBox txtCollectedDate = (TextBox)GridDetails.Rows[i].Cells[8].FindControl("txtCollectedDate");
                    TextBox txtRemark = (TextBox)GridDetails.Rows[i].Cells[12].FindControl("txtRemark");

                    TextBox txtPropertyTaxAmt = (TextBox)GridDetails.Rows[i].Cells[10].FindControl("txtPropertyTaxAmt");
                    TextBox txtSocietyMaintenaceAmt = (TextBox)GridDetails.Rows[i].Cells[11].FindControl("txtSocietyMaintenaceAmt");
                    TextBox txtDepositAmt = (TextBox)GridDetails.Rows[i].Cells[9].FindControl("txtDepositAmt");
                    TextBox GSTPerDetails = (TextBox)GridDetails.Rows[i].Cells[17].FindControl("GSTPerDetails");
                    TextBox CGSTAmt = (TextBox)GridDetails.Rows[i].Cells[18].FindControl("CGSTAmt");
                    TextBox TotalAmount = (TextBox)GridDetails.Rows[i].Cells[19].FindControl("TotalAmount");

                    DropDownList GrdddlCompany = (DropDownList)GridDetails.Rows[i].Cells[6].FindControl("GrdddlCompany");
                    Label LblEntryId = (Label)GridDetails.Rows[i].Cells[0].FindControl("LblEntryId");



                    //TextBox txtFromDate = (TextBox)GridDetails.Rows[i].Cells[2].FindControl("txtFromDate");
                    //TextBox txtToDate = (TextBox)GridDetails.Rows[i].Cells[3].FindControl("txtToDate");
                    //TextBox txtRentalAmt = (TextBox)GridDetails.Rows[i].Cells[5].FindControl("txtRentalAmt");
                    //TextBox txtCollectedDate = (TextBox)GridDetails.Rows[i].Cells[6].FindControl("txtCollectedDate");
                    //TextBox txtRemark = (TextBox)GridDetails.Rows[i].Cells[7].FindControl("txtRemark");
                    //DropDownList GrdddlCompany = (DropDownList)GridDetails.Rows[i].Cells[4].FindControl("GrdddlCompany");
                    //Label LblEntryId = (Label)GridDetails.Rows[i].Cells[0].FindControl("LblEntryId");
                    //CheckBox checkAll = (CheckBox)GridDetails.Rows[i].Cells[1].FindControl("ChkAllocate");

                    //TextBox txtDepositAmt = (TextBox)GridDetails.Rows[i].Cells[9].FindControl("txtDepositAmt");
                    //TextBox GSTPerDetails = (TextBox)GridDetails.Rows[i].Cells[17].FindControl("GSTPerDetails");
                    //TextBox CGSTAmt = (TextBox)GridDetails.Rows[i].Cells[18].FindControl("CGSTAmt");
                    //TextBox TotalAmount = (TextBox)GridDetails.Rows[i].Cells[19].FindControl("TotalAmount");

                    //TextBox txtPropertyTaxAmt = (TextBox)GridDetails.Rows[i].Cells[9].FindControl("txtPropertyTaxAmt");
                    //TextBox txtSocietyMaintenaceAmt = (TextBox)GridDetails.Rows[i].Cells[10].FindControl("txtSocietyMaintenaceAmt");

                    if (Convert.ToInt32(GrdddlCompany.SelectedValue.ToString()) > 0)
                    {
                        dtTableRow = DTTEMP.NewRow();
                        dtTableRow["#"] = LblEntryId.Text;
                        dtTableRow["FromDate"] = txtFromDate.Text;
                        dtTableRow["CHK"] = checkAll.Checked;
                        dtTableRow["ToDate"] = txtToDate.Text;
                        dtTableRow["CompanyId"] = Convert.ToInt32(GrdddlCompany.SelectedValue);
                        dtTableRow["PropertyTaxAmt"] = txtPropertyTaxAmt.Text;
                        dtTableRow["SocietyMaintenaceAmt"] = txtSocietyMaintenaceAmt.Text;
                        dtTableRow["RentalAmt"] = !string.IsNullOrEmpty(txtRentalAmt.Text) ? Convert.ToDecimal(txtRentalAmt.Text) : 0;
                        dtTableRow["CollectedDate"] = txtCollectedDate.Text;
                        dtTableRow["Remark"] = txtRemark.Text;
                        dtTableRow["DepositAmt"] = !string.IsNullOrEmpty(txtDepositAmt.Text) ? Convert.ToDecimal(txtDepositAmt.Text) : 0;
                        dtTableRow["Status"] = Convert.ToString(GridDetails.Rows[i].Cells[12].Text);
                        dtTableRow["ProRentDtlsId"] = Convert.ToInt32(GridDetails.Rows[i].Cells[15].Text);

                        if (Convert.ToInt32(GridDetails.Rows[i].Cells[16].Text) > 0)
                        {
                            dtTableRow["FlagReceiptType"] = 1;
                        }
                        else
                        {
                            dtTableRow["FlagReceiptType"] = 0;
                        }
                        // dtTableRow["FlagReceiptType"] = Convert.ToBoolean(GridDetails.Rows[i].Cells[16].Text);
                        dtTableRow["GSTPerDetails"] = !string.IsNullOrEmpty(GSTPerDetails.Text) ? Convert.ToDecimal(GSTPerDetails.Text) : 0;
                        dtTableRow["GSTAmt"] = !string.IsNullOrEmpty(CGSTAmt.Text) ? Convert.ToDecimal(CGSTAmt.Text) : 0;
                        dtTableRow["Amount"] = !string.IsNullOrEmpty(TotalAmount.Text) ? Convert.ToDecimal(TotalAmount.Text) : 0;
                      
                        rowIndex++;
                        DTTEMP.Rows.Add(dtTableRow);
                    }
                }   
           
                if (DTTEMP.Rows.Count > 0)
                {
                    dtCurrentTable = DTTEMP;
                }

                dtTableRow = null;
                #endregion

                if (dtCurrentTable.Rows.Count > 0)
                {
                    dtTableRow = dtCurrentTable.NewRow();

                    dtTableRow["#"] =0;
                   
                    dtTableRow["ToDate"] = "";
                    dtTableRow["CHK"] = false;
                    dtTableRow["CompanyId"] = 0;
                    dtTableRow["RentalAmt"] = 0;
                   
                    dtTableRow["Remark"] = "";

                    for (int i = 0; i < GridDetails.Rows.Count; i++)
                    {
                        TextBox txtToDate = (TextBox)GridDetails.Rows[i].Cells[5].FindControl("txtToDate");
                        TextBox txtPropertyTaxAmt = (TextBox)GridDetails.Rows[i].Cells[9].FindControl("txtPropertyTaxAmt");
                        TextBox txtSocietyMaintenaceAmt = (TextBox)GridDetails.Rows[i].Cells[10].FindControl("txtSocietyMaintenaceAmt");
                      

                        dtTableRow["FromDate"] = txtToDate.Text;
                        dtTableRow["CollectedDate"] = txtToDate.Text;
                        dtTableRow["PropertyTaxAmt"] = !string.IsNullOrEmpty(txtPropertyTaxAmt.Text) ? Convert.ToDecimal(txtPropertyTaxAmt.Text) : 0;
                        dtTableRow["SocietyMaintenaceAmt"] = !string.IsNullOrEmpty(txtSocietyMaintenaceAmt.Text) ? Convert.ToDecimal(txtSocietyMaintenaceAmt.Text) : 0; 
                    }

                    dtTableRow["DepositAmt"] = 0.00;
                    dtTableRow["GSTPerDetails"] = 0.0;
                    dtTableRow["GSTAmt"] = 0.00;
                    dtTableRow["Amount"] = 0.00;
                    dtCurrentTable.Rows.Add(dtTableRow);
                    ViewState["GridDetail"] = dtCurrentTable;
                    GridDetails.DataSource = dtCurrentTable;
                    GridDetails.DataBind();

                  // Makecontrolempty();               
                }
            
            }
        }
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        int irow = 0, idetrow = 0, idetrowMonth=0;
        try
        {
            DataSet DSC = new DataSet();
            DataTable dtInsert = new DataTable();
            dtInsert = (DataTable)ViewState["GridDetail"];
            string str = txtUnitNo.Text;
            string[] s = str.Split('-');

            DSC = Obj_PC.ChkDuplicate(Convert.ToInt32(ddlProjectName.SelectedValue), Convert.ToInt32(ddlPartyName.SelectedValue),s[0], out StrError);
            if (DSC.Tables[0].Rows.Count > 0)
             {
                 Obj_Comm.ShowPopUpMsg("Record is Already Present..", this.Page);
                 ddlProjectName.Focus();
             }
             else
             {
                 Entity_PC.PCNo = txtPCNo.Text;

                 //Entity_PC.PropertyName = txtProjectName.Text;
                 Entity_PC.PropertyId = Convert.ToInt32(ddlProjectName.SelectedValue);
                 Entity_PC.FlatTypeId = Convert.ToInt32(ddlUnit.SelectedValue);

                 string str1 = Convert.ToString(txtUnitNo.Text);
                 string[] s1 = str1.Split('-');

                 Entity_PC.UnitArea = Convert.ToDecimal(txtUintArea.Text);
                 Entity_PC.UnitNo = s1[0];

                 Entity_PC.SqFt = Convert.ToDecimal(txtUintArea.Text);
                 Entity_PC.PartyId = Convert.ToInt32(ddlPartyName.SelectedValue);

                 Entity_PC.UserId = 1;//Convert.ToInt32(Session["UserId"]);
                 Entity_PC.LoginDate = DateTime.Now;

                 irow = Obj_PC.InsertPC(ref Entity_PC, out StrError);

                 if (irow > 0)
                 {
                     if (ViewState["GridDetail"] != null)
                     {
                         #region
                         for (int i = 0; i < dtInsert.Rows.Count; i++)
                         {

                             Entity_PC.PropertyRentCardId = irow;


                             CheckBox ChkAllocate = (CheckBox)GridDetails.Rows[i].Cells[1].FindControl("ChkAllocate");
                             Entity_PC.FlagCheck = ChkAllocate.Checked;

                             //if (ChkAllocate.Checked == true)
                             //{
                             //    Entity_PC.Status = "Paid";
                             //}
                             //else
                             //{
                                 Entity_PC.Status = "Unpaid";
                           //  }

                             TextBox txtFromDate = (TextBox)GridDetails.Rows[i].Cells[4].FindControl("txtFromDate");
                             Entity_PC.FromDate = Convert.ToDateTime(txtFromDate.Text);

                             TextBox txtToDate = (TextBox)GridDetails.Rows[i].Cells[5].FindControl("txtToDate");
                             Entity_PC.ToDate = Convert.ToDateTime(txtToDate.Text);

                             DropDownList GrdddlCompany = (DropDownList)GridDetails.Rows[i].Cells[6].FindControl("GrdddlCompany");
                             Entity_PC.CompanyId = Convert.ToInt32(GrdddlCompany.SelectedValue);

                             TextBox txtRentalAmt = (TextBox)GridDetails.Rows[i].Cells[7].FindControl("txtRentalAmt");
                             Entity_PC.RentalAmt = Convert.ToDecimal(txtRentalAmt.Text);

                             TextBox txtPropertyTaxAmt = (TextBox)GridDetails.Rows[i].Cells[10].FindControl("txtPropertyTaxAmt");
                             Entity_PC.PropertyTaxAmt = Convert.ToDecimal(txtPropertyTaxAmt.Text);

                             TextBox txtSocietyMaintenaceAmt = (TextBox)GridDetails.Rows[i].Cells[11].FindControl("txtSocietyMaintenaceAmt");
                             Entity_PC.SocietyMaintenaceAmt = Convert.ToDecimal(txtSocietyMaintenaceAmt.Text);

                             TextBox txtCollectedDate = (TextBox)GridDetails.Rows[i].Cells[8].FindControl("txtCollectedDate");
                             Entity_PC.CollectedDate = Convert.ToDateTime(txtCollectedDate.Text);

                             TextBox txtDepositAmt = (TextBox)GridDetails.Rows[i].Cells[9].FindControl("txtDepositAmt");
                             Entity_PC.DepositAmt = Convert.ToDecimal(txtDepositAmt.Text);


                             DropDownList GrdddlGSTPer = (DropDownList)GridDetails.Rows[i].Cells[17].FindControl("GrdddlGSTPer");
                             Entity_PC.TaxTemplateID = Convert.ToInt32(GrdddlGSTPer.SelectedValue);

                             TextBox txtGSTPer = (TextBox)GridDetails.Rows[i].Cells[18].FindControl("GSTPerDetails");
                             Entity_PC.GSTPerDetails = Convert.ToDecimal(txtGSTPer.Text);

                             TextBox txtGstAmt = (TextBox)GridDetails.Rows[i].Cells[19].FindControl("CGSTAmt");
                             Entity_PC.GSTAmt = Convert.ToDecimal(txtGstAmt.Text);

                             TextBox txtRentAmt = (TextBox)GridDetails.Rows[i].Cells[20].FindControl("TotalAmount");
                             Entity_PC.Amount = Convert.ToDecimal(txtRentAmt.Text);

                             TextBox txtRemark = (TextBox)GridDetails.Rows[i].Cells[12].FindControl("txtRemark");
                             Entity_PC.Remark = txtRemark.Text;

                             Entity_PC.FlagReceiptType =false;

                             idetrow = Obj_PC.InsertPCDetail(ref Entity_PC, out StrError);


                             if (idetrow > 0)
                             {
                                 for (int j = 0; j < dtInsert.Rows.Count; j++)
                                 {
                                     TextBox txtFromDate1 = (TextBox)GridDetails.Rows[j].Cells[4].FindControl("txtFromDate");
                                     Entity_PC.FromDate = Convert.ToDateTime(txtFromDate.Text);

                                     TextBox txtToDate2 = (TextBox)GridDetails.Rows[j].Cells[5].FindControl("txtToDate");
                                     Entity_PC.ToDate = Convert.ToDateTime(txtToDate.Text);


                                     DataSet DSR = new DataSet();
                                     DataSet DSD = new DataSet();

                                     DSR = Obj_PC.GetMonthfromNTodate(ref Entity_PC, out StrError);

                                     if (DSR.Tables[0].Rows.Count > 0)
                                     {
                                         for (int k = 0; k < DSR.Tables[0].Rows.Count; k++)
                                         {

                                             string MonthName = DSR.Tables[0].Rows[k]["MonthYear"].ToString();
                                             Entity_PC.FortheMonthYear = DSR.Tables[0].Rows[k]["MonthYear"].ToString();

                                             DSD = Obj_PC.ChkDuplicateMonth(Convert.ToInt32(ddlProjectName.SelectedValue), Convert.ToInt32(ddlPartyName.SelectedValue), MonthName, out StrError);

                                             if (DSD.Tables[0].Rows.Count > 0)
                                             {
                                                 //Obj_Comm.ShowPopUpMsg("Record is Already Present..", this.Page);
                                                 //ddlProjectName.Focus();
                                             }
                                             else
                                             {
                                                 Entity_PC.ReceiptVoucherId = 0;
                                                 Entity_PC.IsGenerated = false;

                                                 TextBox txtRentAmt1 = (TextBox)GridDetails.Rows[i].Cells[20].FindControl("TotalAmount");
                                                 Entity_PC.RentalAmount = Convert.ToDecimal(txtRentAmt1.Text);
                                                 Entity_PC.PropertyRentCardId = irow;
                                                 Entity_PC.ProRentDtlsId = idetrow;
                                                 Entity_PC.RemaingAmount = Convert.ToDecimal(txtRentAmt1.Text);
                                                 idetrowMonth = Obj_PC.InsertProjectMonth(ref Entity_PC, out StrError);
                                             }
                                         }
                                     }
                                 }
                             }
                         }
                         #endregion
                     }
                 }

                 if (idetrow > 0 && irow > 0)
                 {
                     Obj_Comm.ShowPopUpMsg("Record Saved Successfully..!", this.Page);
                     MakeEmptyForm();
                 }
             }
           
        }
        catch (Exception)
        {
            //Obj_Comm.ErrorLog("DepartmentActivityRegister.aspx", " BtnSave_Click", "Exception", "ex.so", "", 1);
        }
    }

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        int irow = 0, idetrow = 0, idetrowMonth=0;
        DataSet DSC = new DataSet();
        try
        {
            DataTable dtInsert = new DataTable();
            dtInsert = (DataTable)ViewState["GridDetail"];
            Entity_PC.PropertyRentCardId = Convert.ToInt32(ViewState["EditID"]);
            Entity_PC.PCNo = txtPCNo.Text;
            //Entity_PC.PropertyName = txtProjectName.Text;
            Entity_PC.PropertyId = Convert.ToInt32(ddlProjectName.SelectedValue);
            Entity_PC.FlatTypeId = Convert.ToInt32(ddlUnit.SelectedValue);
            string str1 = Convert.ToString(txtUnitNo.Text);
            string[] s1 = str1.Split('-');

            Entity_PC.UnitArea = Convert.ToDecimal(txtUintArea.Text);
            Entity_PC.UnitNo = s1[0];
            Entity_PC.SqFt = Convert.ToDecimal(txtUintArea.Text);
            Entity_PC.Rent = Convert.ToDecimal(txtRent.Text);
            Entity_PC.PropertyAddress = txtAddress.Text;
            Entity_PC.PartyId = Convert.ToInt32(ddlPartyName.SelectedValue);
            Entity_PC.UserId = 1;
            Entity_PC.LoginDate = DateTime.Now;

            irow = Obj_PC.UpdatetPropertyRentCard(ref Entity_PC, out StrError);
            if (irow > 0)
            {
                if (ViewState["GridDetail"] != null)
                {
                    for (int i = 0; i < dtInsert.Rows.Count; i++)
                    {
                        Entity_PC.PropertyRentCardId = Convert.ToInt32(ViewState["EditID"]);

                        CheckBox ChkAllocate = (CheckBox)GridDetails.Rows[i].Cells[1].FindControl("ChkAllocate");
                        Entity_PC.FlagCheck = ChkAllocate.Checked;

                        //if (ChkAllocate.Checked == true)
                        //{
                        //    Entity_PC.Status = "Paid";
                        //}
                        //else
                        //{
                            Entity_PC.Status = "Unpaid";
                        //}

                        TextBox txtFromDate = (TextBox)GridDetails.Rows[i].Cells[4].FindControl("txtFromDate");
                        Entity_PC.FromDate = Convert.ToDateTime(txtFromDate.Text);

                        TextBox txtToDate = (TextBox)GridDetails.Rows[i].Cells[5].FindControl("txtToDate");
                        Entity_PC.ToDate = Convert.ToDateTime(txtToDate.Text);

                        DropDownList GrdddlCompany = (DropDownList)GridDetails.Rows[i].Cells[6].FindControl("GrdddlCompany");
                        Entity_PC.CompanyId = Convert.ToInt32(GrdddlCompany.SelectedValue);

                        TextBox txtRentalAmt = (TextBox)GridDetails.Rows[i].Cells[7].FindControl("txtRentalAmt");
                        Entity_PC.RentalAmt = Convert.ToDecimal(txtRentalAmt.Text);

                        TextBox txtPropertyTaxAmt = (TextBox)GridDetails.Rows[i].Cells[10].FindControl("txtPropertyTaxAmt");
                        Entity_PC.PropertyTaxAmt = Convert.ToDecimal(txtPropertyTaxAmt.Text);

                        TextBox txtSocietyMaintenaceAmt = (TextBox)GridDetails.Rows[i].Cells[11].FindControl("txtSocietyMaintenaceAmt");
                        Entity_PC.SocietyMaintenaceAmt = Convert.ToDecimal(txtSocietyMaintenaceAmt.Text);

                        TextBox txtCollectedDate = (TextBox)GridDetails.Rows[i].Cells[8].FindControl("txtCollectedDate");
                        Entity_PC.CollectedDate = Convert.ToDateTime(txtCollectedDate.Text);

                        TextBox txtDepositAmt = (TextBox)GridDetails.Rows[i].Cells[9].FindControl("txtDepositAmt");
                        Entity_PC.DepositAmt = Convert.ToDecimal(txtDepositAmt.Text);

                        DropDownList GrdddlGSTPer = (DropDownList)GridDetails.Rows[i].Cells[17].FindControl("GrdddlGSTPer");
                        Entity_PC.TaxTemplateID = Convert.ToInt32(GrdddlGSTPer.SelectedValue);

                        TextBox txtGSTPer = (TextBox)GridDetails.Rows[i].Cells[18].FindControl("GSTPerDetails");
                        Entity_PC.GSTPerDetails = Convert.ToDecimal(txtGSTPer.Text);

                        TextBox txtGstAmt = (TextBox)GridDetails.Rows[i].Cells[19].FindControl("CGSTAmt");
                        Entity_PC.GSTAmt = Convert.ToDecimal(txtGstAmt.Text);

                        TextBox txtRentAmt = (TextBox)GridDetails.Rows[i].Cells[20].FindControl("TotalAmount");
                        Entity_PC.Amount = Convert.ToDecimal(txtRentAmt.Text);

                        TextBox txtRemark = (TextBox)GridDetails.Rows[i].Cells[12].FindControl("txtRemark");
                        Entity_PC.Remark = txtRemark.Text;


                        Entity_PC.FlagReceiptType = Convert.ToBoolean(GridDetails.Rows[i].Cells[16].Text);

                        if (Convert.ToInt32(GridDetails.Rows[i].Cells[15].Text) == 0)
                        {
                            idetrow = Obj_PC.InsertPCDetail(ref Entity_PC, out StrError);
                        }
                        else
                        {
                            Entity_PC.ProRentDtlsId = Convert.ToInt32(GridDetails.Rows[i].Cells[15].Text);

                            idetrow = Obj_PC.UpdatePropertyRentDtls(ref Entity_PC, out StrError);
                        }

                        if (idetrow > 0)
                        {
                            for (int j = 0; j < dtInsert.Rows.Count; j++)
                            {
                                TextBox txtFromDate1 = (TextBox)GridDetails.Rows[j].Cells[4].FindControl("txtFromDate");
                                Entity_PC.FromDate = Convert.ToDateTime(txtFromDate.Text);

                                TextBox txtToDate2 = (TextBox)GridDetails.Rows[j].Cells[5].FindControl("txtToDate");
                                Entity_PC.ToDate = Convert.ToDateTime(txtToDate.Text);


                                DataSet DSR = new DataSet();
                                DataSet DSD = new DataSet();

                                DSR = Obj_PC.GetMonthfromNTodate(ref Entity_PC, out StrError);

                                if (DSR.Tables[0].Rows.Count > 0)
                                {
                                    for (int k = 0; k < DSR.Tables[0].Rows.Count; k++)
                                    {

                                        string MonthName = DSR.Tables[0].Rows[k]["MonthYear"].ToString();
                                        Entity_PC.FortheMonthYear = DSR.Tables[0].Rows[k]["MonthYear"].ToString();

                                        DSD = Obj_PC.ChkDuplicateMonth(Convert.ToInt32(ddlProjectName.SelectedValue), Convert.ToInt32(ddlPartyName.SelectedValue), MonthName, out StrError);

                                        if (DSD.Tables[0].Rows.Count > 0)
                                        {
                                            //Obj_Comm.ShowPopUpMsg("Record is Already Present..", this.Page);
                                            //ddlProjectName.Focus();
                                        }
                                        else
                                        {
                                            Entity_PC.ReceiptVoucherId = 0;
                                            Entity_PC.IsGenerated = false;

                                            TextBox txtRentAmt1 = (TextBox)GridDetails.Rows[i].Cells[20].FindControl("TotalAmount");
                                            Entity_PC.RentalAmount = Convert.ToDecimal(txtRentAmt1.Text);
                                            Entity_PC.RemaingAmount = Convert.ToDecimal(txtRentAmt1.Text);
                                            Entity_PC.PropertyRentCardId = Convert.ToInt32(ViewState["EditID"]); 

                                            if (Convert.ToInt32(GridDetails.Rows[i].Cells[15].Text) == 0)
                                            {
                                                Entity_PC.ProRentDtlsId = idetrow;
                                            }
                                            else
                                            {
                                                Entity_PC.ProRentDtlsId = Convert.ToInt32(GridDetails.Rows[i].Cells[15].Text);
                                            }

                                            idetrowMonth = Obj_PC.InsertProjectMonth(ref Entity_PC, out StrError);
                                        }

                                    }
                                }
                            }
                        }
                    }
                }                
            }            
            if (idetrow > 0 && irow > 0)
            {
                Obj_Comm.ShowPopUpMsg("Record Update Successfully..!", this.Page);
            }
            MakeEmptyForm();
        }
        catch (Exception ex)
        {           
            Obj_Comm.ShowPopUpMsg("Please try after Some Time..!", this.Page);
        }
    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        MakeEmptyForm();
    
    }

    protected void GrdReport_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            DataSet DSA = new DataSet();
            switch (e.CommandName)
            {
                case ("Select"):
                    {
                        if (Convert.ToInt32(e.CommandArgument) != 0)
                        {
                            ViewState["EditID"] = Convert.ToInt32(e.CommandArgument);
                            DSA = Obj_PC.GetPropertyToEdit(Convert.ToInt32(e.CommandArgument), out StrError);

                            if (DSA.Tables.Count > 0 && DSA.Tables[0].Rows.Count > 0)
                            {
                                txtPCNo.Text = DSA.Tables[0].Rows[0]["PCNo"].ToString();
                                ddlProjectName.SelectedValue = DSA.Tables[0].Rows[0]["PropertyId"].ToString();
                                ddlProjectName_SelectedIndexChanged(Convert.ToInt32(ddlProjectName.SelectedValue), e);
                                ddlPartyName.SelectedValue = DSA.Tables[0].Rows[0]["PartyId"].ToString();
                                txtUnitNo.Text = DSA.Tables[0].Rows[0]["UnitNo"].ToString();
                                ddlUnit.SelectedValue = DSA.Tables[0].Rows[0]["FlatTypeId"].ToString();
                                txtUintArea.Text = DSA.Tables[0].Rows[0]["SqFt"].ToString();
                                txtRent.Text = DSA.Tables[0].Rows[0]["Rent"].ToString();
                                txtAddress.Text = DSA.Tables[0].Rows[0]["PropertyAddress"].ToString();

                                if (DSA.Tables.Count > 0 && DSA.Tables[1].Rows.Count > 0)
                                {
                                    GridDetails.DataSource = DSA.Tables[1];
                                    GridDetails.DataBind();
                                    ViewState["GridDetail"] = DSA.Tables[1];
                                }
                                else
                                {
                                    SetInitialRow();
                                }
                                if (!FlagEdit)
                                    BtnUpdate.Visible = true;
                                BtnSave.Visible = false;

                            }
                            else
                            {
                                // Makefromempty();
                            }
                        }

                        break;
                    }
            }
        }
        catch (Exception ex)
        {            
            Obj_Comm.ShowPopUpMsg("Please try after Some Time..!", this.Page);
        }
    }

    protected void GrdReport_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataSet usecount = new DataSet();
        try
        {
            int DeleteId = Convert.ToInt32(((ImageButton)GrdReport.Rows[e.RowIndex].Cells[0].FindControl("ImgBtnDelete")).CommandArgument.ToString());

            if (DeleteId != 0)
            {
                Entity_PC.PropertyRentCardId = DeleteId;
                Entity_PC.UserId = Convert.ToInt32(Session["UserID"]);
                Entity_PC.LoginDate = DateTime.Now;

                int iDelete = Obj_PC.DeleteProjectRent(ref Entity_PC, out StrError);
                if (iDelete != 0)
                {
                    Obj_Comm.ShowPopUpMsg("Record Deleted Successfully..!", this.Page);
                    MakeEmptyForm();
                }
            }            
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }

    #region[WebService]

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        DMPropertyRentCard Obj_Con = new DMPropertyRentCard();
        String[] SearchList = Obj_Con.GetSuggestRecord(prefixText);
        return SearchList;
    }
    #endregion

    protected void TxtSearch_TextChanged(object sender, EventArgs e)
    {
        try
        {
            StrCondition = TxtSearch.Text;
            ReportGrid(StrCondition);
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }

    protected void GridDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            if (ViewState["GridDetail"] != null)
            {
                int id = e.RowIndex;
                DataTable dt = (DataTable)ViewState["GridDetail"];

                if (id != 0)
                {
                    Entity_PC.ProRentDtlsId = id;
             

                    int iDelete = Obj_PC.DeletePropertyMonth(ref Entity_PC, out StrError);

                    //if (iDelete != 0)
                    //{
                    //    Obj_Comm.ShowPopUpMsg("Record Deleted Successfully..!", this.Page);
                    //    MakeEmptyForm();
                    //}
                }  

                dt.Rows.RemoveAt(id);

                if (dt.Rows.Count > 0)
                {
                    GridDetails.DataSource = dt;
                    ViewState["GridDetail"] = dt;
                    GridDetails.DataBind();
                }
                else
                {
                    SetInitialRow();
                }

            }
        }
        catch (Exception)
        {

            throw;
        }
    }

    protected void ddlProjectName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataSet Ds = new DataSet();
            Ds = Obj_PC.GetDataOnProperty(Convert.ToInt32(ddlProjectName.SelectedValue), out StrError);
            if (Ds.Tables.Count > 0)
            {
                if (Ds.Tables[0].Rows.Count > 0)
                {
                    ddlUnit.DataSource = Ds.Tables[0];
                    ddlUnit.DataValueField = "FlatTypeId";
                    ddlUnit.DataTextField = "FlatType";
                    ddlUnit.DataBind();
                }

                if (Ds.Tables[1].Rows.Count > 0)
                {
                    ViewState["CompanyName"] = Ds.Tables[1];
                }
                else
                {
                   
                }
                SetInitialRow();
               
                //if (Ds.Tables[2].Rows.Count > 0)
                //{
                //    GridDetails.DataSource = Ds.Tables[2];
                //    GridDetails.DataBind();
                //}
                //else
                //{
                //    GridDetails.DataSource =null;
                //    GridDetails.DataBind();
                //}
                
            }
            ddlUnit.Focus();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    #region["Web Services"]
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionListUnitNo(string prefixText, int count, string contextKey)
    {
        DMPropertyRentCard obj_PropertyMaster = new DMPropertyRentCard();
        String[] SearchList = obj_PropertyMaster.GetSuggestedRecordForUnit(prefixText);
        return SearchList;
    }
    #endregion

    protected void txtUnitNo_TextChanged(object sender, EventArgs e)
    {
        try
        {
            DataSet DSA = new DataSet();
            int ProjectId = 0;
            String unit = txtUnitNo.Text.Split('-')[0];

            string ProjectName = txtUnitNo.Text.Split('-')[2];

            DSA = Obj_PC.GetProjectId(ProjectName, out StrError);
            {
                if (DSA.Tables[0].Rows.Count > 0)
                {
                     ProjectId = Convert.ToInt32(DSA.Tables[0].Rows[0]["PropertyId"].ToString());                
                }
            }

            if (ProjectId > 0)
            {

                DSA = Obj_PC.GetDataOnUnitNo(unit,ProjectId,out StrError);

                if (DSA.Tables[0].Rows.Count > 0)
                {
                    ddlProjectName.SelectedValue = DSA.Tables[0].Rows[0]["PropertyId"].ToString();

                    ddlProjectName_SelectedIndexChanged(sender, e);

                    ddlUnit.SelectedValue = DSA.Tables[0].Rows[0]["FlatTypeId"].ToString();
                    txtUintArea.Text = DSA.Tables[0].Rows[0]["UnitArea"].ToString();
                    
                    GridDetails.DataSource = DSA.Tables[0];
                    GridDetails.DataBind();
                }
                
            }
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }

    protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //int ProjectId = 0;
            //DataSet Ds = new DataSet();
            //Ds = Obj_PC.GetDataOnUnit(Convert.ToInt32(ddlProjectName.SelectedValue), Convert.ToInt32(ddlUnit.SelectedValue), out StrError);

            //if (Ds.Tables[0].Rows.Count > 0)
            //{
            //    ddlProjectName_SelectedIndexChanged(sender, e);
            //    ddlUnit.SelectedValue = Ds.Tables[0].Rows[0]["FlatTypeId"].ToString();
            //    txtUintArea.Text = Ds.Tables[0].Rows[0]["UnitArea"].ToString();
            //    txtUnitNo.Text = Ds.Tables[0].Rows[0]["UnitNo"].ToString();

            //    GridDetails.DataSource = Ds.Tables[0];
            //    GridDetails.DataBind();
            //}
           
            ddlUnit.Focus();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    protected void GrdddlCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddl1 = (DropDownList)sender;
        GridViewRow row = (GridViewRow)ddl1.NamingContainer;
        int idx = row.RowIndex;

        try
        {
            ////////for (int i = 0; i < GridDetails.Rows.Count; i++)
            ////////{
            ////////    TextBox txtFromDate = (TextBox)GridDetails.Rows[i].Cells[4].FindControl("txtFromDate");
            ////////    TextBox txtToDate = (TextBox)GridDetails.Rows[i].Cells[5].FindControl("txtToDate");
              
            ////////    string Fdate = txtFromDate.Text;
            ////////    string Tdate = txtToDate.Text;
            ////////}

            //////TextBox txtECustCode = (TextBox)row.Cells[idx].FindControl("txtFromDate");
            //////string _text1 = txtECustCode.Text;


            //////foreach (GridViewRow row1 in GridDetails.Rows)
            //////{
            //////    //for templated control
            //////    TextBox tb = row1.FindControl("txtFromDate") as TextBox;
            //////    //for bound field
            //////    string str = tb.Text;

            //////    if (_text1 == str)
            //////    {
            //////    }
            //////}
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    protected void GrdReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        StrCondition = TxtSearch.Text;
        GrdReport.PageIndex = e.NewPageIndex;
        ReportGrid(StrCondition);
    }


    protected void GrdddlGSTPer_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddl1 = (DropDownList)sender;
        GridViewRow row = (GridViewRow)ddl1.NamingContainer;
        int idx = row.RowIndex;

        try
        {


            DMProjectConfigurator obj_Order1 = new DMProjectConfigurator();

            DropDownList ddlGSTPer = ((DropDownList)row.FindControl("GrdddlGSTPer"));
            Int32 TaxId=Convert.ToInt32(ddlGSTPer.SelectedValue);

           DS = obj_Order1.GetTaxAmt(DateTime.Now, TaxId, out StrError);


            if (DS.Tables.Count > 0)
            {
                //for (int i = 0; i < GridDetails.Rows.Count; i++)
                //{
              //  TextBox GSTPer = (TextBox)row.FindControl("GSTPerDetails");
                ((TextBox)row.FindControl("GSTPerDetails")).Text = DS.Tables[1].Rows[0]["GST"].ToString();
                //}


            }
            TextBox txtRentalAmt = ((TextBox)row.FindControl("txtRentalAmt"));
            if (!string.IsNullOrEmpty(txtRentalAmt.Text))
            {
                decimal TaxPer = Convert.ToDecimal(((TextBox)row.FindControl("GSTPerDetails")).Text);
                decimal Rate = Convert.ToDecimal(((TextBox)row.FindControl("txtRentalAmt")).Text);
               decimal TaxAmount = (Rate * TaxPer) / 100;
               ((TextBox)row.FindControl("CGSTAmt")).Text = TaxAmount.ToString();
               ((TextBox)row.FindControl("TotalAmount")).Text = (Rate + TaxAmount).ToString();

            }
           
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
