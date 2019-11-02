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
using Build.Utility;
using Build.EntityClass;
using Build.DB;
using Build.DataModel;
using Build.DALSQLHelper;

public partial class Transactions_PropertyMaintance : System.Web.UI.Page
{

    #region[Private Variables]

    DMPropertyMaintenance Obj_PM = new DMPropertyMaintenance();
    PropertyMaintenance Entity_PM= new PropertyMaintenance();
    CommanFunction Obj_Comm = new CommanFunction();
    DataSet DS = new DataSet();
    DataSet Dsa = new DataSet();
    private bool Flag = true;
    private string StrError = string.Empty;
    private string StrCondition = string.Empty;
    private static bool FlagAdd = false, FlagDel = false, FlagEdit = false;
    #endregion

    private void MakeEmptyForm()
    {
        txtFromDate.Focus();
        ddlProjectName.SelectedValue = "0";
        txtPCNo.Text = string.Empty;
        txtFromDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
        if (!FlagAdd)
        BtnSave.Visible = true;
        BtnUpdate.Visible = false;
        BtnDelete.Visible = false;
        BtnCancel.Visible = true;
        GetCode();
        TxtSearch.Text = string.Empty;
        FillCombo();
       // txtMaintenanceType.Text = string.Empty;
        SetInitialRowTower();
        SetInitialRowReportGrid();
        
        ReportGrid(StrCondition);
    }

    private void FillCombo()
    {
        Dsa = Obj_PM.FillCombo(out StrError);
        if (Dsa.Tables.Count > 0)
        {

            if (Dsa.Tables[0].Rows.Count > 0)
            {
                ddlProjectName.DataSource = Dsa.Tables[0];
                ddlProjectName.DataTextField = "Property";
                ddlProjectName.DataValueField = "PropertyId";
                ddlProjectName.DataBind();
            }
            if (Dsa.Tables[1].Rows.Count > 0)
            {
                ViewState["Expense"] = Dsa.Tables[1];
            }
            else
            {
                ViewState["Expense"] = null;

            }
        }
    }

    public void SetInitialRowTower()
    {
        try
        {
            DataTable dtTable = new DataTable();
            DataRow dr;
            dtTable.Columns.Add("#", typeof(int));
            dtTable.Columns.Add("CHK", typeof(bool));           
            dtTable.Columns.Add("Status", typeof(String));
            dtTable.Columns.Add("UnitNo", typeof(String));
            dtTable.Columns.Add("ExpenseHdId", typeof(string));
            dtTable.Columns.Add("Amount", typeof(String));

            dr = dtTable.NewRow();

            dr["#"] = 0;
            dr["CHK"] = 0;           
            dr["Status"] = string.Empty;
            dr["UnitNo"] = string.Empty;
            dr["ExpenseHdId"] ="";
            dr["Amount"] =0.00;

            dtTable.Rows.Add(dr);
            ViewState["CurrentTable"] = dtTable;
            GrdRateDtls.DataSource = dtTable;
            GrdRateDtls.DataBind();
        }
        catch (Exception ex) { throw new Exception(ex.Message); }

    }

    private void GetCode()
    {
        DS = Obj_PM.GetPMNo(out StrError);
        if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
        {
            txtPCNo.Text = DS.Tables[0].Rows[0]["PMNo"].ToString();
        }
    }

    public void ReportGrid(string RepCondition)
    {
        string StrError = "";
        try
        {
            DS = Obj_PM.GetProject(RepCondition, out StrError);

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
            Obj_PM = null;
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
            dt.Columns.Add(new DataColumn("PMNo", typeof(string)));
            dt.Columns.Add(new DataColumn("Property", typeof(string)));
            dt.Columns.Add(new DataColumn("PMDate", typeof(string)));
          
            dr = dt.NewRow();
            dr["#"] = "";
            dr["PMNo"] = "";
            dr["Property"] = "";
            dr["PMDate"] = "";
            
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

              if (!string.IsNullOrEmpty(Request.QueryString["PropertyMaintenaceId"]))
              {
                  FillCombo();

                  int ProMaintId = Convert.ToInt32(Request.QueryString["PropertyMaintenaceId"]);
                  {
                      DST = Obj_PM.GetPropertyToEdit(ProMaintId, out StrError);

                      if (DST.Tables.Count > 0 && DST.Tables[0].Rows.Count > 0)
                      {
                          txtPCNo.Text = DST.Tables[0].Rows[0]["PMNo"].ToString();
                          txtFromDate.Text = DST.Tables[0].Rows[0]["PMDate"].ToString();
                          ddlProjectName.SelectedValue = DST.Tables[0].Rows[0]["PropertyId"].ToString();
                          ddlProjectName_SelectedIndexChanged(sender, e);
                          ddlPartyName.SelectedValue = DST.Tables[0].Rows[0]["PartyId"].ToString();
                          // txtMaintenanceType.Text = DS.Tables[0].Rows[0]["MaintenaceType"].ToString();  
                          if (DST.Tables.Count > 0 && DST.Tables[1].Rows.Count > 0)
                          {
                              GrdRateDtls.DataSource = DST.Tables[1];
                              GrdRateDtls.DataBind();
                              ViewState["CurrentTable"] = DST.Tables[1];
                          }
                          else
                          {
                              SetInitialRowTower();
                          }
                          if (!FlagEdit)
                              BtnUpdate.Visible = true;
                          BtnSave.Visible = false;

                      }
                      else
                      {
                          // Make
                      }
                  }
              }
              else
              {
                  MakeEmptyForm();
              }
        }
    }

    protected void ImgAddRrow_Click(object sender, ImageClickEventArgs e)
    {       
        int rowIndex = 0;
        if (Convert.ToInt32(ddlProjectName.SelectedValue)>0)
        {
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataTable DTTEMP = dtCurrentTable.Clone();
                DataRow dtTableRow = null;
                #region

                if (GrdRateDtls.Rows[0].Cells[1].Text.Equals("&nbsp;") || string.IsNullOrEmpty(GrdRateDtls.Rows[0].Cells[1].Text))
                {
                    dtCurrentTable.Rows.RemoveAt(0);
                }

                for (int i = 0; i < GrdRateDtls.Rows.Count; i++)
                {
                    CheckBox checkAll = (CheckBox)GrdRateDtls.Rows[i].Cells[1].FindControl("ChkAllocate");
                    TextBox txtUnitNo = (TextBox)GrdRateDtls.Rows[i].Cells[3].FindControl("txtUnitNo");
                    DropDownList GrdddlExpense = (DropDownList)GrdRateDtls.Rows[i].Cells[4].FindControl("GrdddlExpense");
                    TextBox txtAmount = (TextBox)GrdRateDtls.Rows[i].Cells[5].FindControl("txtAmount");
                  
                                        
                    dtTableRow = DTTEMP.NewRow();
                  
                    dtTableRow["CHK"] = checkAll.Checked;
                    //dtTableRow["#"] = LblEntryId.Text;
                    dtTableRow["UnitNo"] = txtUnitNo.Text;
                    dtTableRow["ExpenseHdId"] = Convert.ToInt32(GrdddlExpense.SelectedValue);
                    dtTableRow["Amount"] = txtAmount.Text;
                 
                    rowIndex++;
                    DTTEMP.Rows.Add(dtTableRow);
                   
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

                    dtTableRow["#"] = 0;
                    dtTableRow["CHK"] = false;
                    dtTableRow["UnitNo"] =0;
                    dtTableRow["ExpenseHdId"] = 0;
                    dtTableRow["Amount"] = 0;
                    
                    dtCurrentTable.Rows.Add(dtTableRow);
                    ViewState["CurrentTable"] = dtCurrentTable;
                    GrdRateDtls.DataSource = dtCurrentTable;
                    GrdRateDtls.DataBind();

                    // Makecontrolempty();


                }
            }
        }
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        int irow = 0, idetrow = 0;
        try
        {
            DataSet DSC = new DataSet();
            DataTable dtInsert = new DataTable();
            dtInsert = (DataTable)ViewState["CurrentTable"];

            DSC = Obj_PM.ChkDuplicate(Convert.ToInt32(ddlProjectName.SelectedValue), Convert.ToInt32(ddlPartyName.SelectedValue), out StrError);
             if (DSC.Tables[0].Rows.Count > 0)
             {
                 Obj_Comm.ShowPopUpMsg("Record is Already Present..", this.Page);
                 ddlProjectName.Focus();
             }
             else
             {
                 Entity_PM.PMNo = txtPCNo.Text;
                 Entity_PM.PMDate = Convert.ToDateTime(txtFromDate.Text);
                 Entity_PM.PropertyId = Convert.ToInt32(ddlProjectName.SelectedValue);
                 Entity_PM.PartyId = Convert.ToInt32(ddlPartyName.SelectedValue);
                 Entity_PM.UserId = 1;
                 Entity_PM.LoginDate = DateTime.Now;

                 irow = Obj_PM.InsertPM(ref Entity_PM, out StrError);

                 if (irow > 0)
                 {
                     if (ViewState["CurrentTable"] != null)
                     {
                         #region
                         for (int i = 0; i < dtInsert.Rows.Count; i++)
                         {

                             Entity_PM.PropertyMaintenaceId = irow;

                             CheckBox ChkAllocate = (CheckBox)GrdRateDtls.Rows[i].Cells[2].FindControl("ChkAllocate");
                             Entity_PM.FlagCheck = ChkAllocate.Checked;

                             if (ChkAllocate.Checked == true)
                             {
                                 Entity_PM.Status = "Complete";
                             }
                             else
                             {
                                 Entity_PM.Status = "Uncompleted";
                             }

                             TextBox txtUnitNo = (TextBox)GrdRateDtls.Rows[i].Cells[3].FindControl("txtUnitNo");
                             Entity_PM.UnitNo = Convert.ToInt32(txtUnitNo.Text);

                             //TextBox txtExpence = (TextBox)GrdRateDtls.Rows[i].Cells[4].FindControl("txtExpence");
                             //Entity_PM.Expences = txtExpence.Text;

                             DropDownList GrdddlExpense = (DropDownList)GrdRateDtls.Rows[i].Cells[4].FindControl("GrdddlExpense");
                             Entity_PM.ExpenseHdId = Convert.ToInt32(GrdddlExpense.SelectedValue);

                             TextBox txtAmount = (TextBox)GrdRateDtls.Rows[i].Cells[5].FindControl("txtAmount");
                             Entity_PM.Amount = Convert.ToDecimal(txtAmount.Text);

                             idetrow = Obj_PM.InsertPMDetail(ref Entity_PM, out StrError);

                         }
                         #endregion
                     }
                 }

                 if (idetrow > 0 && irow > 0)
                 {
                     Obj_Comm.ShowPopUpMsg("Record Saved Successfully..!", this.Page);

                 }
                 MakeEmptyForm();
             }
        }
        catch (Exception)
        {
            //Obj_Comm.ErrorLog("DepartmentActivityRegister.aspx", " BtnSave_Click", "Exception", "ex.so", "", 1);
        }
    }

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        int irow = 0, idetrow = 0;
        DataSet DSC = new DataSet();
        try
        {
            DataTable dtInsert = new DataTable();
            dtInsert = (DataTable)ViewState["CurrentTable"];
            Entity_PM.PropertyMaintenaceId = Convert.ToInt32(ViewState["EditID"]);
            Entity_PM.PMNo = txtPCNo.Text;
            Entity_PM.PMDate = Convert.ToDateTime(txtFromDate.Text);
            Entity_PM.PropertyId = Convert.ToInt32(ddlProjectName.SelectedValue);
            Entity_PM.PartyId = Convert.ToInt32(ddlPartyName.SelectedValue);

            if (chkCompletbill.Checked)
            {
                Entity_PM.ComplitFlag = "Complete";
            }
            else
            {
                Entity_PM.ComplitFlag = "Generated";
            }
         
            Entity_PM.UserId = 1;
            Entity_PM.LoginDate = DateTime.Now;

            irow = Obj_PM.UpdatetPropertyMaintenance(ref Entity_PM, out StrError);
            if (irow > 0)
            {
                if (ViewState["CurrentTable"] != null)
                {
                    for (int i = 0; i < dtInsert.Rows.Count; i++)
                    {                       
                        Entity_PM.PropertyMaintenaceId = Convert.ToInt32(ViewState["EditID"]);

                        CheckBox ChkAllocate = (CheckBox)GrdRateDtls.Rows[i].Cells[2].FindControl("ChkAllocate");
                        Entity_PM.FlagCheck = ChkAllocate.Checked;

                        if (ChkAllocate.Checked == true)
                        {
                            Entity_PM.Status = "Complete";
                        }
                        else
                        {
                            Entity_PM.Status = "Uncompleted";
                        }

                        TextBox txtUnitNo = (TextBox)GrdRateDtls.Rows[i].Cells[3].FindControl("txtUnitNo");
                        Entity_PM.UnitNo = Convert.ToInt32(txtUnitNo.Text);

                        DropDownList GrdddlExpense = (DropDownList)GrdRateDtls.Rows[i].Cells[4].FindControl("GrdddlExpense");
                        Entity_PM.ExpenseHdId = Convert.ToInt32(GrdddlExpense.SelectedValue);


                        TextBox txtAmount = (TextBox)GrdRateDtls.Rows[i].Cells[5].FindControl("txtAmount");
                        Entity_PM.Amount = Convert.ToDecimal(txtAmount.Text);

                        idetrow = Obj_PM.InsertPMDetail(ref Entity_PM, out StrError);
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

    protected void GrdReport_RowCommand(object sender, GridViewCommandEventArgs e)
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
                            DS = Obj_PM.GetPropertyToEdit(Convert.ToInt32(e.CommandArgument), out StrError);

                            if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
                            {
                                txtPCNo.Text = DS.Tables[0].Rows[0]["PMNo"].ToString();
                                txtFromDate.Text = DS.Tables[0].Rows[0]["PMDate"].ToString();
                                ddlProjectName.SelectedValue = DS.Tables[0].Rows[0]["PropertyId"].ToString();
                                ddlProjectName_SelectedIndexChanged(sender, e);
                                ddlPartyName.SelectedValue = DS.Tables[0].Rows[0]["PartyId"].ToString();
                                // txtMaintenanceType.Text = DS.Tables[0].Rows[0]["MaintenaceType"].ToString();  
                                if (DS.Tables.Count > 0 && DS.Tables[1].Rows.Count > 0)
                                {
                                    GrdRateDtls.DataSource = DS.Tables[1];
                                    GrdRateDtls.DataBind();
                                    ViewState["CurrentTable"] = DS.Tables[1];
                                }
                                else
                                {
                                    SetInitialRowTower();
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
                Entity_PM.PropertyMaintenaceId = DeleteId;
                Entity_PM.UserId = Convert.ToInt32(Session["UserID"]);
                Entity_PM.LoginDate = DateTime.Now;

                int iDelete = Obj_PM.DeleteProjectMdetails(ref Entity_PM, out StrError);
                if (iDelete != 0)
                {
                    Obj_Comm.ShowPopUpMsg("Record Deleted Successfully..!", this.Page);
                    MakeEmptyForm();
                }
            }
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        MakeEmptyForm();
    }

    protected void ImgAddRrowButton_Click(object sender, ImageClickEventArgs e)
    {
        bool DupFlag = false;
        int k = 0, chkcount = 0;
        int rowIndex = 0;
        if (Convert.ToInt32(ddlProjectName.SelectedValue)>0)
        {
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataTable DTTEMP = dtCurrentTable.Clone();
                DataRow dtTableRow = null;
                #region

                if (GrdRateDtls.Rows[0].Cells[1].Text.Equals("&nbsp;") || string.IsNullOrEmpty(GrdRateDtls.Rows[0].Cells[1].Text))
                {
                    dtCurrentTable.Rows.RemoveAt(0);
                }

                for (int i = 0; i < GrdRateDtls.Rows.Count; i++)
                {
                    TextBox txtTaskType = (TextBox)GrdRateDtls.Rows[i].Cells[2].FindControl("txtTaskType");
                    TextBox txtTaskDtls = (TextBox)GrdRateDtls.Rows[i].Cells[3].FindControl("txtTaskDtls");
                    TextBox txtRate = (TextBox)GrdRateDtls.Rows[i].Cells[4].FindControl("txtRate");
                    TextBox txtTotalAreaQty = (TextBox)GrdRateDtls.Rows[i].Cells[5].FindControl("txtTotalAreaQty");
                    TextBox txtAssignTotalAreaQty = (TextBox)GrdRateDtls.Rows[i].Cells[6].FindControl("txtAssignTotalAreaQty");
                    TextBox txtAllotAmt = (TextBox)GrdRateDtls.Rows[i].Cells[7].FindControl("txtAllotAmt");
                    TextBox txtRemark = (TextBox)GrdRateDtls.Rows[i].Cells[8].FindControl("txtRemark");
                                        
                    dtTableRow = DTTEMP.NewRow();
                    //dtTableRow["#"] = LblEntryId.Text;
                    dtTableRow["TaskType"] = txtTaskType.Text;
                    dtTableRow["TaskDetails"] = txtTaskDtls.Text;
                    dtTableRow["Rate"] = txtRate.Text;
                    dtTableRow["TotalAreaQty"] = txtTotalAreaQty.Text;
                    dtTableRow["AssignTotalAreaQty"] = txtAssignTotalAreaQty.Text;
                    dtTableRow["AllotedAmt"] = txtAllotAmt.Text;
                    dtTableRow["Remark"] = txtRemark.Text;
                    rowIndex++;
                    DTTEMP.Rows.Add(dtTableRow);
                   
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

                    dtTableRow["#"] = 0;

                    dtTableRow["TaskType"] ="";
                    dtTableRow["TaskDetails"] = "";
                    dtTableRow["Rate"] = 0;
                    dtTableRow["TotalAreaQty"] =0;
                    dtTableRow["AssignTotalAreaQty"] = 0;
                    dtTableRow["AllotedAmt"] = 0;
                    dtTableRow["Remark"] = "";                   

                    dtCurrentTable.Rows.Add(dtTableRow);
                    ViewState["CurrentTable"] = dtCurrentTable;
                    GrdRateDtls.DataSource = dtCurrentTable;
                    GrdRateDtls.DataBind();

                    // Makecontrolempty();
                }
            }
        }
    }
    

    #region[WebService]

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {        
        DMPropertyMaintenance Obj_Con = new DMPropertyMaintenance();
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

    protected void GrdRateDtls_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            if (ViewState["CurrentTable"] != null)
            {
                int id = e.RowIndex;
                DataTable dt = (DataTable)ViewState["CurrentTable"];

                dt.Rows.RemoveAt(id);

                if (dt.Rows.Count > 0)
                {
                    GrdRateDtls.DataSource = dt;
                    ViewState["CurrentTable"] = dt;
                    GrdRateDtls.DataBind();
                }
                else
                {
                    SetInitialRowTower();
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
            Ds = Obj_PM.GetDataOnProject(Convert.ToInt32(ddlProjectName.SelectedValue), out StrError);

            if (Ds.Tables[0].Rows.Count > 0)
            {
                ddlPartyName.DataSource = Ds.Tables[0];
                ddlPartyName.DataTextField = "PartyName";
                ddlPartyName.DataValueField = "PartyId";
                ddlPartyName.DataBind();
            }

            ddlPartyName.Focus();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }


    protected void GrdRateDtls_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            GridViewRow gvr = e.Row;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = ViewState["Expense"] as DataTable;

                if (dt.Rows.Count > 0)
                {
                    ((DropDownList)e.Row.FindControl("GrdddlExpense")).DataSource = dt;
                    ((DropDownList)e.Row.FindControl("GrdddlExpense")).DataTextField = "Expense";
                    ((DropDownList)e.Row.FindControl("GrdddlExpense")).DataValueField = "ExpenseHdId";
                    ((DropDownList)e.Row.FindControl("GrdddlExpense")).DataBind();
                    ((DropDownList)e.Row.FindControl("GrdddlExpense")).SelectedValue = ((Label)e.Row.FindControl("LblGrdddlExpense")).Text;
                }
                else
                {
                    ((DropDownList)e.Row.FindControl("GrdddlExpense")).DataSource = null;
                    ((DropDownList)e.Row.FindControl("GrdddlExpense")).DataBind();
                }              
            }
        }
        catch (Exception)
        {

            throw;
        }
    }

}
