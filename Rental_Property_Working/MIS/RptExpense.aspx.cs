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

public partial class MIS_RptExpense : System.Web.UI.Page
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

        ddlExpense.SelectedIndex = 0;
        
        txtFromDate.Enabled = txtToDate.Enabled = true;

        ImgBtnPrint.Visible = false;
        ImgBtnExport.Visible = false;
        ImgPDF.Visible = false;

        HttpContext.Current.Cache["DirAllCustomer"] = "";
       
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
                if (DS.Tables[3].Rows.Count > 0)
                {
                    ddlExpense.DataSource = DS.Tables[3];
                    ddlExpense.DataTextField = "Expense";
                    ddlExpense.DataValueField = "ExpenseHdId";
                    ddlExpense.DataBind();
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
            dt.Columns.Add(new DataColumn("ExpRegNo", typeof(string)));
            dt.Columns.Add(new DataColumn("ExpenceRegDate", typeof(string)));
            dt.Columns.Add(new DataColumn("Expense", typeof(string)));
            dt.Columns.Add(new DataColumn("Amount", typeof(decimal)));
            dt.Columns.Add(new DataColumn("Remark", typeof(string)));           
            dt.Columns.Add(new DataColumn("#", typeof(int)));
         
            dr = dt.NewRow();

            dr["#"] = 0;
            dr["ExpRegNo"] = "";
            dr["ExpenceRegDate"] = "";
            dr["Expense"] = "";
            dr["Amount"] = 0;
            dr["Remark"] = "";            
            dt.Rows.Add(dr);
            ViewState["Summary"] = dt;
            GridExpenseList.DataSource = dt;
            GridExpenseList.DataBind();
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
            GridExpenseList.Focus();
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
                StrCondition = StrCondition + " and ER.ExpenceRegDate between '" + Convert.ToDateTime(txtFromDate.Text).ToString("MM-dd-yyyy") + "' AND '" + Convert.ToDateTime(txtToDate.Text).ToString("MM-dd-yyyy") + "' ";
            }
            if (Convert.ToInt32(ddlExpense.SelectedValue) > 0)
            {
                StrCondition = StrCondition + " and ED.ExpenseHdId='" + (ddlExpense.SelectedValue) + "' ";
            }
           
            DS = Obj_Receipt.GetExpenseList(StrCondition, out StrError);
            if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
            {
                ViewState["Summary"] = DS.Tables[0];
                GridExpenseList.DataSource = DS.Tables[0];
                GridExpenseList.DataBind();

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
                GridExpenseList.DataSource = null;
                GridExpenseList.DataBind();
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
                GridExpenseList.DataSource = null;
                GridExpenseList.DataBind();
            }
        }
        else
        {
            Obj_Comm.ShowPopUpMsg("No Data Found To Export..!", this.Page);
            SetInitialRow();
        }


    }

 


 

    
  
}
