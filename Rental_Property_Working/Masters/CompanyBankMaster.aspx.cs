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
using System.Threading;
using System.Data.SqlClient;

using Build.Utility;
using Build.EntityClass;
using Build.DB;
using Build.DataModel;
using Build.DALSQLHelper;
public partial class Masters_Aminity : System.Web.UI.Page
{
    #region Private Variable
    CommanFunction Obj_Comm = new CommanFunction();

    DataSet Ds = new DataSet();
    private string StrCondition = string.Empty;
    private string StrError = string.Empty;

    CompanyBankMaster Entity_Call = new CompanyBankMaster();
    DMCompanyBankMaster Obj_Call = new DMCompanyBankMaster();
    private static bool FlagAdd = false, FlagDel = false, FlagEdit = false;
    #endregion

    #region[UserDefinedFunction]

    //User Right Function===========
    public void CheckUserRight()
    {
        FlagAdd = FlagDel = FlagEdit = false;
        try
        {
            #region [USER RIGHT]
            //Checking Session Varialbels========
            if (Session["UserName"] != null && Session["UserRole"] != null)
            {
                //Checking User Role========
                //if (!Session["UserRole"].Equals("Administrator"))
                //{
                //Checking Right of users=======

                System.Data.DataSet dsChkUserRight = new System.Data.DataSet();
                System.Data.DataSet dsChkUserRight1 = new System.Data.DataSet();
                dsChkUserRight1 = (DataSet)Session["DataSet"];

                DataRow[] dtRow = dsChkUserRight1.Tables[1].Select("FormName ='Company Bank Details'");
                if (dtRow.Length > 0)
                {
                    DataTable dt = dtRow.CopyToDataTable();
                    dsChkUserRight.Tables.Add(dt);// = dt.Copy();
                }
                if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["ViewAuth"].ToString()) == false && Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["AddAuth"].ToString()) == false &&
                    Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["DelAuth"].ToString()) == false && Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["EditAuth"].ToString()) == false)
                {
                    Response.Redirect("~/Masters/NotAuthUser.aspx");
                }
                //Checking View Right ========                    
                if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["ViewAuth"].ToString()) == false)
                {
                    GrdReport.Visible = false;
                }
                //Checking Add Right ========                    
                if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["AddAuth"].ToString()) == false)
                {
                    BtnSave.Visible = false;
                    FlagAdd = true;

                }
                //Checking Print Right ========                    
                if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["PrintAuth"].ToString()) == false)
                {

                }
                //Edit /Delete Column Visible ========
                if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["DelAuth"].ToString()) == false && Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["EditAuth"].ToString()) == false)
                {
                    BtnDelete.Visible = false;
                    BtnUpdate.Visible = false;
                    FlagDel = true;
                    FlagEdit = true;
                }
                else
                {
                    //Checking Delete Right ========
                    if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["DelAuth"].ToString()) == false)
                    {
                        BtnDelete.Visible = false;
                        FlagDel = true;
                    }

                    //Checking Edit Right ========
                    if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["EditAuth"].ToString()) == false)
                    {
                        BtnUpdate.Visible = false;
                        FlagEdit = true;
                    }
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
    //User Right Function===========

    private void MakeEmptyForm()
    {
        ViewState["EditId"] = null;
        ViewState["GridIndex"] = null;
        ddlProject.Focus();
        ddlProject.SelectedValue = "0";
        if (!FlagAdd)
            BtnSave.Visible = true;
        BtnUpdate.Visible = false;
        BtnDelete.Visible = false;
        BtnCancel.Visible = true;
        ddlProject.SelectedValue = "0";
        TxtSearch.Text = string.Empty;
        FillCombo();
        SetInitialRow();     
        ReportGrid(StrCondition);
    }

    private void MakeControlEmpty()
    {
        ddlCompany.SelectedValue = "0";
        ddlType.SelectedValue = "0";
        txtBank.Text = string.Empty;
        txtBranch.Text = string.Empty;
        txtAcountNo.Text = string.Empty;
        txtRTGSNo.Text = string.Empty;
        txtCheque.Text = string.Empty;
        ViewState["GridIndex"] = null;
        ViewState["GridDetails"] = null;
        ImgAddCompany.ImageUrl = "~/Images/Icon/Gridadd.png";
        ImgAddCompany.ToolTip = "Add Grid";

    }

    private void FillCombo()
    {
        Ds = Obj_Call.FillCombo(Convert.ToInt32(Session["EmpID"]), out StrError);
        if (Ds.Tables.Count > 0)
        {
            if (Ds.Tables[0].Rows.Count > 0)
            {
                ddlProject.DataSource = Ds.Tables[0];
                ddlProject.DataTextField = "PCName";
                ddlProject.DataValueField = "PCId";
                ddlProject.DataBind();
            }         
        }
    }

    private void SetInitialRow()
    {
        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add("#", typeof(Int32));
        dt.Columns.Add("ProjectCompanyId", typeof(Int32));
        dt.Columns.Add("Company", typeof(string));
        dt.Columns.Add("BankTypeId", typeof(Int32));
        dt.Columns.Add("BankType", typeof(string));
        dt.Columns.Add("BankName", typeof(string));
        dt.Columns.Add("Branch", typeof(string));
        dt.Columns.Add("AccountNo", typeof(string));
        dt.Columns.Add("RTGSNo", typeof(string));
        dt.Columns.Add("ChequeDrawnAccName", typeof(string));
       
        dr = dt.NewRow();

        dr["#"] = 0;
        dr["ProjectCompanyId"] = 0;
        dr["Company"] = "";
        dr["BankTypeId"] = 0;
        dr["BankType"]="";
        dr["BankName"] = "";
        dr["Branch"] = "";
        dr["AccountNo"] = "";
        dr["RTGSNo"] = "";
        dr["ChequeDrawnAccName"] = "";
        
        dt.Rows.Add(dr);

        ViewState["CurrentTable"] = dt;
        GridDetails.DataSource = dt;
        GridDetails.DataBind();
    }

    private void ReportGrid(string RepCondition)
    {
        try
        {
            if (Session["Admin"].Equals("ADMIN"))
            {
                RepCondition = string.Empty;
            }
            else
            {
                RepCondition = RepCondition + " and S.CreatedBy=" + Convert.ToInt32(Session["UserID"]) + "";
            }
            Ds = Obj_Call.GetList(RepCondition, out StrError);
            if (Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
            {
                HttpContext.Current.Cache["Dir"] = Ds.Tables[0];
                GrdReport.DataSource = Ds.Tables[0];
                GrdReport.DataBind();
                // ViewState["CurrentTable"] = Ds.Tables[0];
            }
            else
            {
                GrdReport.DataSource = null;
                GrdReport.DataBind();
            }
            //Obj_Call = null;
            Ds = null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        
    }
    #endregion 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           // CheckUserRight();
            MakeEmptyForm();           
        }
    }   

    private bool ChkDetails()
    {
        bool flag = false;
        try
        {
            if (GridDetails.Rows.Count > 0 && !String.IsNullOrEmpty(GridDetails.Rows[0].Cells[2].Text) && !GridDetails.Rows[0].Cells[2].Text.Equals("&nbsp;"))
            {

                flag = true;
            }

        }
        catch (Exception ex) { throw new Exception(ex.Message); }

        return flag;
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        int InsertRow = 0, InsertRowDtls = 0;
        try
        {
            if (ChkDetails() == true)
            {
                Ds = Obj_Call.ChkDuplicate(ddlProject.SelectedValue, out StrError);
                if (Ds.Tables[0].Rows.Count > 0)
                {
                    Obj_Comm.ShowPopUpMsg("Record is Already Present..", this.Page);

                }
                else
                {
                    Entity_Call.PCId = Convert.ToInt32(ddlProject.SelectedValue);

                    Entity_Call.UserId = Convert.ToInt32(Session["UserID"]);
                    Entity_Call.LoginDate = DateTime.Now;
                    InsertRow = Obj_Call.InsertRecord(ref Entity_Call, out StrError);
                    if (InsertRow > 0)
                    {
                        if (ViewState["CurrentTable"] != null)
                        {
                            DataTable dtInsert = new DataTable();
                            dtInsert = (DataTable)ViewState["CurrentTable"];
                            for (int i = 0; i < dtInsert.Rows.Count; i++)
                            {
                                Entity_Call.CompanyBankId = InsertRow;
                                Entity_Call.ProjectCompanyId = Convert.ToInt32(dtInsert.Rows[i]["ProjectCompanyId"].ToString());
                                Entity_Call.BankTypeId = Convert.ToInt32(dtInsert.Rows[i]["BankTypeId"].ToString());
                                Entity_Call.BankName = dtInsert.Rows[i]["BankName"].ToString();
                                Entity_Call.Branch = dtInsert.Rows[i]["Branch"].ToString();
                                Entity_Call.AccountNo = dtInsert.Rows[i]["AccountNo"].ToString();
                                Entity_Call.RTGSNo =dtInsert.Rows[i]["RTGSNo"].ToString();
                                Entity_Call.ChequeDrawnAccName =dtInsert.Rows[i]["ChequeDrawnAccName"].ToString();

                                InsertRowDtls = Obj_Call.InsertDetailsRecord(ref Entity_Call, out StrError);
                            }
                        }
                        if (InsertRow > 0)
                        {
                            Obj_Comm.ShowPopUpMsg("Record Saved Successfully", this.Page);
                            //MakeControlEmpty();
                            MakeEmptyForm();
                            Entity_Call = null;
                            Obj_Call = null;
                        }
                    }
                }
            }


            else
            {
                Obj_Comm.ShowPopUpMsg("Please Enter Details ..!", this.Page);
            }
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        int UpdateRow = 0, UpdateRowDtls = 0;
        try
        {

            if (ViewState["EditID"] != null)
            {
                Entity_Call.CompanyBankId = Convert.ToInt32(ViewState["EditID"]);
            }
            Entity_Call.PCId = Convert.ToInt32(ddlProject.SelectedValue);

            Entity_Call.UserId = Convert.ToInt32(Session["UserId"]);
            Entity_Call.LoginDate = DateTime.Now;
            UpdateRow = Obj_Call.UpdateRecord(ref Entity_Call, out StrError);
            if (UpdateRow > 0)
            {
                if (ViewState["CurrentTable"] != null)
                {
                    DataTable dtInsert = new DataTable();
                    dtInsert = (DataTable)ViewState["CurrentTable"];
                    for (int i = 0; i < dtInsert.Rows.Count; i++)
                    {
                        Entity_Call.CompanyBankId = Convert.ToInt32(ViewState["EditID"]); ;
                        Entity_Call.ProjectCompanyId = Convert.ToInt32(dtInsert.Rows[i]["ProjectCompanyId"].ToString());
                        Entity_Call.BankTypeId = Convert.ToInt32(dtInsert.Rows[i]["BankTypeId"].ToString());
                        Entity_Call.BankName = dtInsert.Rows[i]["BankName"].ToString();
                        Entity_Call.Branch = dtInsert.Rows[i]["Branch"].ToString();
                        Entity_Call.AccountNo = dtInsert.Rows[i]["AccountNo"].ToString();
                        Entity_Call.RTGSNo = dtInsert.Rows[i]["RTGSNo"].ToString();
                        Entity_Call.ChequeDrawnAccName = dtInsert.Rows[i]["ChequeDrawnAccName"].ToString();
                        UpdateRowDtls = Obj_Call.InsertDetailsRecord(ref Entity_Call, out StrError);
                    }
                }
                if (UpdateRow > 0)
                {

                    Obj_Comm.ShowPopUpMsg("Record Updated Successfully", this.Page);
                    MakeControlEmpty();
                    MakeEmptyForm();

                    Entity_Call = null;
                    Obj_Call = null;
                }
            }
        }


        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    protected void BtnDelete_Click(object sender, EventArgs e)
    { 
   int i = Convert.ToInt32(hiddenbox.Value);
    if (i == 0)
    {
        try
        {
            int DeleteId = 0;
            if (ViewState["EditID"] != null)
            {
                DeleteId = Convert.ToInt32(ViewState["EditID"]);
            }
            if (DeleteId != 0)
            {
                Entity_Call.CompanyBankId = DeleteId;
                Entity_Call.UserId = Convert.ToInt32(Session["UserId"]);
                Entity_Call.LoginDate = DateTime.Now;
                int iDelete = Obj_Call.DeleteRecord(ref Entity_Call, out StrError);
                if (iDelete != 0)
                {
                    Obj_Comm.ShowPopUpMsg("Record Deleted Successfully..!", this.Page);
                    MakeEmptyForm();
                }

            }
            Entity_Call = null;
            Obj_Comm = null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        MakeEmptyForm();
        MakeControlEmpty();
    }

    protected void TxtSearch_TextChanged(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty((HttpContext.Current.Cache["Dir"]).ToString()))
        {
            DataTable DtNew = null;
        }
        else
        {
            DataTable DtNew = (DataTable)HttpContext.Current.Cache["Dir"];
            StrCondition = TxtSearch.Text.Trim();
            var query = from r in DtNew.AsEnumerable()
                        where (r.Field<string>("Name")).Contains(StrCondition)
                        select r;
            if (query != null && query.Count() > 0)
            {
                DataTable DTNEW = query.CopyToDataTable();

                GrdReport.DataSource = DTNEW;
                GrdReport.DataBind();
            }
            else
            {
                GrdReport.DataSource = null;
                GrdReport.DataBind();
            }
        }
    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        if (string.IsNullOrEmpty((HttpContext.Current.Cache["Dir"]).ToString()))
        {
            DataTable DtNew = null;
            return null;
        }
        else
        {
            DMCompanyBankMaster Obj_Call = new DMCompanyBankMaster();
            DataTable DtNew = (DataTable)HttpContext.Current.Cache["Dir"];
            var query = from r in DtNew.AsEnumerable()
                        where (r.Field<string>("Name").ToLower()).Contains(prefixText.ToLower())
                        select (r.Field<string>("Name"));
            string[] SearchList = query.ToArray();
            return SearchList;
        }
    }
    
    protected void GrdReport_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            switch (e.CommandName)
            {
                case ("Select"):
                    {
                        if (Convert.ToInt32(e.CommandArgument) != 0)
                        {
                            ViewState["EditID"] = Convert.ToInt32(e.CommandArgument);
                            Ds = Obj_Call.GetRecordForEdit(Convert.ToInt32(e.CommandArgument), out StrError);
                            if (Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                            {
                                ddlProject.SelectedValue = Ds.Tables[0].Rows[0]["PCId"].ToString();
                            }
                            else
                            {
                                MakeEmptyForm();
                            }

                            if (Ds.Tables.Count > 0 && Ds.Tables[1].Rows.Count > 0)
                            {
                                GridDetails.DataSource = Ds.Tables[1];
                                GridDetails.DataBind();
                                ViewState["CurrentTable"] = Ds.Tables[1];
                                        
                            }
                            else
                            {
                                //MakeEmptyForm();
                                SetInitialRow();
                            }
                            Ds = null;
                            Obj_Call = null;                           
                            BtnSave.Visible = false;
                            if (!FlagEdit)
                                BtnUpdate.Visible = true;
                            if (!FlagDel)
                                BtnDelete.Visible = true;
                            //TxtCountry.Focus();
                        }

                        break;
                    }
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    
    protected void ImgAddCompany_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (ViewState["CurrentTable"] != null)
            {

                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                bool DupFlag = false;
                int k = 0;
                DataRow dtTableRow = null;
                if (dtCurrentTable.Rows.Count >= 1)
                {

                    if (dtCurrentTable.Rows.Count >= 1 && dtCurrentTable.Rows[0]["ProjectCompanyId"].ToString().Equals("0"))
                    {
                        dtCurrentTable.Rows.RemoveAt(0);
                    }

                    if (ViewState["GridIndex"] != null)
                    {
                        for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                        {

                            if ((Convert.ToInt32(dtCurrentTable.Rows[i]["ProjectCompanyId"]) == Convert.ToInt32(ddlCompany.SelectedValue))
                                 && (Convert.ToInt32(dtCurrentTable.Rows[i]["BankTypeId"]) == Convert.ToInt32(ddlType.SelectedValue)))
                            {
                                DupFlag = true;
                                k = i;
                            }
                        }

                        if (DupFlag == true)
                        {
                            dtCurrentTable.Rows[k]["ProjectCompanyId"] = Convert.ToInt32(ddlCompany.SelectedValue);
                            dtCurrentTable.Rows[k]["Company"] = ddlCompany.SelectedItem;
                            dtCurrentTable.Rows[k]["BankTypeId"] = Convert.ToInt32(ddlType.SelectedValue);
                            dtCurrentTable.Rows[k]["BankType"] = ddlType.SelectedItem;
                            dtCurrentTable.Rows[k]["BankName"] = (!string.IsNullOrEmpty(txtBank.Text)) ? txtBank.Text : string.Empty;
                            dtCurrentTable.Rows[k]["Branch"] = (!string.IsNullOrEmpty(txtBranch.Text)) ? txtBank.Text : string.Empty;
                            dtCurrentTable.Rows[k]["AccountNo"] = (!string.IsNullOrEmpty(txtAcountNo.Text)) ? txtAcountNo.Text : string.Empty;
                            dtCurrentTable.Rows[k]["RTGSNo"] = (!string.IsNullOrEmpty(txtRTGSNo.Text)) ? txtRTGSNo.Text : string.Empty;
                            dtCurrentTable.Rows[k]["ChequeDrawnAccName"] = (!string.IsNullOrEmpty(txtCheque.Text)) ? txtCheque.Text : string.Empty;

                            ViewState["CurrentTable"] = dtCurrentTable;
                            GridDetails.DataSource = dtCurrentTable;
                            GridDetails.DataBind();
                            MakeControlEmpty();
                        }
                        else
                        {
                            dtTableRow = dtCurrentTable.NewRow();
                            int rowindex = Convert.ToInt32(ViewState["GridIndex"]);
                            dtTableRow = dtCurrentTable.NewRow();

                            dtTableRow["#"] = 0;
                            dtTableRow["ProjectCompanyId"] = Convert.ToInt32(ddlCompany.SelectedValue);
                            dtTableRow["Company"] = ddlCompany.SelectedItem;
                            dtTableRow["BankTypeId"] = Convert.ToInt32(ddlType.SelectedValue);
                            dtTableRow["BankType"] = ddlType.SelectedItem;
                            dtTableRow["BankName"] = (!string.IsNullOrEmpty(txtBank.Text)) ? txtBank.Text : string.Empty;
                            dtTableRow["Branch"] = (!string.IsNullOrEmpty(txtBranch.Text)) ? txtBank.Text : string.Empty;
                            dtTableRow["AccountNo"] = (!string.IsNullOrEmpty(txtAcountNo.Text)) ? txtAcountNo.Text : string.Empty;
                            dtTableRow["RTGSNo"]=(!string.IsNullOrEmpty(txtRTGSNo.Text)) ? txtRTGSNo.Text : string.Empty;
                            dtTableRow["ChequeDrawnAccName"] = (!string.IsNullOrEmpty(txtCheque.Text)) ? txtCheque.Text : string.Empty;

                            dtCurrentTable.Rows.Add(dtTableRow);
                            ViewState["CurrentTable"] = dtCurrentTable;
                            GridDetails.DataSource = dtCurrentTable;
                            GridDetails.DataBind();
                            MakeControlEmpty();
                        }


                    }
                    else
                    {
                        for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                        {

                            if ((Convert.ToInt32(dtCurrentTable.Rows[i]["ProjectCompanyId"]) == Convert.ToInt32(ddlCompany.SelectedValue))
                                  && (Convert.ToInt32(dtCurrentTable.Rows[i]["BankTypeId"]) == Convert.ToInt32(ddlType.SelectedValue)))
                            {
                                DupFlag = true;
                                k = i;
                            }
                        }

                        if (DupFlag == true)
                        {
                            dtCurrentTable.Rows[k]["ProjectCompanyId"] = Convert.ToInt32(ddlCompany.SelectedValue);
                            dtCurrentTable.Rows[k]["Company"] = ddlCompany.SelectedItem;
                            dtCurrentTable.Rows[k]["BankTypeId"] = Convert.ToInt32(ddlType.SelectedValue);
                            dtCurrentTable.Rows[k]["BankType"] = ddlType.SelectedItem;
                            dtCurrentTable.Rows[k]["BankName"] = (!string.IsNullOrEmpty(txtBank.Text)) ? txtBank.Text : string.Empty;
                            dtCurrentTable.Rows[k]["Branch"] = (!string.IsNullOrEmpty(txtBranch.Text)) ? txtBank.Text : string.Empty;
                            dtCurrentTable.Rows[k]["AccountNo"] = (!string.IsNullOrEmpty(txtAcountNo.Text)) ? txtAcountNo.Text : string.Empty;
                            dtCurrentTable.Rows[k]["RTGSNo"] = (!string.IsNullOrEmpty(txtRTGSNo.Text)) ? txtRTGSNo.Text : string.Empty;
                            dtCurrentTable.Rows[k]["ChequeDrawnAccName"] = (!string.IsNullOrEmpty(txtCheque.Text)) ? txtCheque.Text : string.Empty;


                            ViewState["CurrentTable"] = dtCurrentTable;
                            GridDetails.DataSource = dtCurrentTable;
                            GridDetails.DataBind();
                            MakeControlEmpty();

                        }
                        else
                        {

                            dtTableRow = dtCurrentTable.NewRow();
                            int rowindex = Convert.ToInt32(ViewState["GridIndex"]);
                            dtTableRow = dtCurrentTable.NewRow();

                            dtTableRow["#"] = 0;
                            dtTableRow["ProjectCompanyId"] = Convert.ToInt32(ddlCompany.SelectedValue);
                            dtTableRow["Company"] = ddlCompany.SelectedItem;
                            dtTableRow["BankTypeId"] = Convert.ToInt32(ddlType.SelectedValue);
                            dtTableRow["BankType"] = ddlType.SelectedItem;
                            dtTableRow["BankName"] = (!string.IsNullOrEmpty(txtBank.Text)) ? txtBank.Text : string.Empty;
                            dtTableRow["Branch"] = (!string.IsNullOrEmpty(txtBranch.Text)) ? txtBank.Text : string.Empty;
                            dtTableRow["AccountNo"] = (!string.IsNullOrEmpty(txtAcountNo.Text)) ? txtAcountNo.Text : string.Empty;
                            dtTableRow["RTGSNo"]=(!string.IsNullOrEmpty(txtRTGSNo.Text)) ? txtRTGSNo.Text : string.Empty;
                            dtTableRow["ChequeDrawnAccName"] = (!string.IsNullOrEmpty(txtCheque.Text)) ? txtCheque.Text : string.Empty;

                            dtCurrentTable.Rows.Add(dtTableRow);

                            ViewState["CurrentTable"] = dtCurrentTable;
                            GridDetails.DataSource = dtCurrentTable;
                            GridDetails.DataBind();
                            MakeControlEmpty();

                        }
                    }
                }
            }
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }

    protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        DataSet DsCompany = new DataSet();
        DsCompany = Obj_Call.GetCompany(Convert.ToInt32(ddlProject.SelectedValue), out StrError);
        if (DsCompany.Tables.Count > 0)
        {
            if (DsCompany.Tables[0].Rows.Count > 0)
            {
                ddlCompany.DataSource = DsCompany.Tables[0];
                ddlCompany.DataValueField = "ProjectCompanyId";
                ddlCompany.DataTextField = "Company";
                ddlCompany.DataBind();
            }
        }
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    protected void GridDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int Index;
            if (e.CommandName == "SelectGrid")
            {
                if ((!(string.IsNullOrEmpty(GridDetails.Rows[0].Cells[3].Text))) && (GridDetails.Rows[0].Cells[3].Text.Equals("&nbsp;")))
                {
                    Obj_Comm.ShowPopUpMsg("There Is No Record To Edit", this.Page);
                }
                else
                {
                    ImgAddCompany.ImageUrl = "~/Images/Icon/GridUpdate.png";
                    ImgAddCompany.ToolTip = "Update";

                    Index = Convert.ToInt32(e.CommandArgument);

                    ViewState["GridIndex"] = Index;
                    ddlProject_SelectedIndexChanged(sender, e);

                    ddlCompany.SelectedValue = GridDetails.Rows[Index].Cells[2].Text;
                    ddlType.SelectedValue = GridDetails.Rows[Index].Cells[4].Text;
                    txtBank.Text = GridDetails.Rows[Index].Cells[6].Text;
                    txtBranch.Text = GridDetails.Rows[Index].Cells[7].Text;
                    txtAcountNo.Text = GridDetails.Rows[Index].Cells[8].Text;
                    txtRTGSNo.Text = GridDetails.Rows[Index].Cells[9].Text;
                    txtCheque.Text = GridDetails.Rows[Index].Cells[10].Text;
                }
            }
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }

    protected void GridDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            if ((!(string.IsNullOrEmpty(GridDetails.Rows[0].Cells[3].Text))) && (GridDetails.Rows[0].Cells[3].Text.Equals("&nbsp;")))
            {
                Obj_Comm.ShowPopUpMsg("There Is No Record To Delete", this.Page);
            }
            else
            {
                if (ViewState["CurrentTable"] != null)
                {
                    int id = e.RowIndex;
                    DataTable dt = (DataTable)ViewState["CurrentTable"];

                    dt.Rows.RemoveAt(id);
                    if (dt.Rows.Count > 0)
                    {
                        GridDetails.DataSource = dt;
                        ViewState["CurrentTable"] = dt;
                        GridDetails.DataBind();
                    }
                    else
                    {
                        SetInitialRow();
                    }
                    MakeControlEmpty();
                }
            }
        }

        catch (Exception ex) { throw new Exception(ex.Message); }

    }
}
