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

public partial class Transactions_ExpenseRegister : System.Web.UI.Page
{
    #region[Private Variables]

    DMExpenseRegister Obj_EH = new DMExpenseRegister();
    ExpenseRegister Entity_EH = new ExpenseRegister();
    CommanFunction Obj_Comm = new CommanFunction();
    DataSet DS = new DataSet();
    DataSet Dsa = new DataSet();
    private bool Flag = true;
    public static decimal TotalQty = 0;
    private string StrError = string.Empty;
    private string StrCondition = string.Empty;
    private static bool FlagAdd = false, FlagDel = false, FlagEdit = false;
    string UnitNum = string.Empty;
    #endregion

    protected void SetInitialRowExpDtls()
    {
        try
        {
            DataTable dt = new DataTable();
            DataRow dr = null;

            dt.Columns.Add(new DataColumn("#", typeof(string)));
            dt.Columns.Add(new DataColumn("ExpenseHdId", typeof(Int32)));
            dt.Columns.Add(new DataColumn("Expense", typeof(string)));
            dt.Columns.Add(new DataColumn("Amount", typeof(decimal)));
            dt.Columns.Add(new DataColumn("Remark", typeof(string)));

            dr = dt.NewRow();
            dr["#"] = "";
            dr["ExpenseHdId"] = 0;
            dr["Expense"] = "";
            dr["Amount"] = 0;
            dr["Remark"] = "";
            dt.Rows.Add(dr);

            ViewState["GrdExpDtls"] = dt;
            GrdExpDtls.DataSource = dt;
            GrdExpDtls.DataBind();

            dt = null;
            dr = null;
        }
        catch (Exception)
        {
            throw;
        }
    }

    private void MakeEmptyForm()
    {
        txtFromDate.Focus();
        ddlExpenseName.SelectedValue = "0";
        txtFromDate.Focus();
        txtExpenseNo.Text = string.Empty;
        txtFromDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
        if (!FlagAdd)
            BtnSave.Visible = true;
        BtnUpdate.Visible = false;
        BtnDelete.Visible = false;
        BtnCancel.Visible = true;
        GetCode();
        FillCombo();
        ReportGrid(StrCondition);
    }

    private void MakeControlEmpty()
    {
        ddlExpenseName.SelectedValue = "0";

        txtExpAmount.Text = string.Empty;
        txtRemark.Text = string.Empty;
       

        ViewState["GridIndex"] = null;


        ViewState["GrdExpDtls"] = null;
        ViewState["GridIndexNew"] = null;
        ImgAddRrow.ImageUrl = "~/Images/Icon/Gridadd.png";
        ImgAddRrow.ToolTip = "Add Grid";


    }

    private void FillCombo()
    {
        Dsa = Obj_EH.FillCombo(out StrError);
        if (Dsa.Tables.Count > 0)
        {
            if (Dsa.Tables[0].Rows.Count > 0)
            {
                ddlExpenseName.DataSource = Dsa.Tables[0];
                ddlExpenseName.DataTextField = "Expense";
                ddlExpenseName.DataValueField = "ExpenseHdId";
                ddlExpenseName.DataBind();
            }
            if (Dsa.Tables[1].Rows.Count > 0)
            {
                ddlPropertyName.DataSource = Dsa.Tables[1];
                ddlPropertyName.DataTextField = "Property";
                ddlPropertyName.DataValueField = "PropertyId";
                ddlPropertyName.DataBind();
            }

        }
    }

    private void GetCode()
    {
        DS = Obj_EH.GetExpenceHeadNo(out StrError);

        if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
        {
            txtExpenseNo.Text = DS.Tables[0].Rows[0]["ExpRegNo"].ToString();
        }
    }
   
    public void ReportGrid(string RepCondition)
    {
        string StrError = "";
        try
        {
            DS = Obj_EH.GetProject(RepCondition, out StrError);

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
            Obj_EH = null;
            DS = null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SetInitialRowExpDtls();
            MakeEmptyForm();
        }
    }

    protected void ImgAddRrow_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if ( ViewState["GrdExpDtls"] != null)
            {
                DataTable dtCurrentTable = (DataTable) ViewState["GrdExpDtls"];
                DataRow dtTableRow = null;
                bool DupFlag = false;
                int k = 0;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    if (dtCurrentTable.Rows.Count == 1 && string.IsNullOrEmpty(dtCurrentTable.Rows[0]["Expense"].ToString()))
                    {
                        dtCurrentTable.Rows.RemoveAt(0);
                    }
                    if (ViewState["GridIndexNew"] != null)
                    {
                        k = Convert.ToInt32(ViewState["GridIndexNew"]);
                        dtCurrentTable.Rows[k]["#"] = Convert.ToInt32(ddlExpenseName.SelectedValue);
                        dtCurrentTable.Rows[k]["Expense"] = ddlExpenseName.SelectedItem;
                        dtCurrentTable.Rows[k]["ExpenseHdId"] = Convert.ToInt32(ddlExpenseName.SelectedValue);
                        dtCurrentTable.Rows[k]["Amount"] = Convert.ToDecimal(txtExpAmount.Text);
                        dtCurrentTable.Rows[k]["Remark"] = txtRemark.Text;
                    

                         ViewState["GrdExpDtls"] = dtCurrentTable;
                        GrdExpDtls.DataSource = dtCurrentTable;
                        GrdExpDtls.DataBind();
                        //MakeControlEmpty();

                    }

                    else
                    {

                        dtTableRow = dtCurrentTable.NewRow();
                        int rowindex = Convert.ToInt32(ViewState["GridIndexNew"]);
                        dtTableRow["Expense"] = ddlExpenseName.SelectedItem;
                        dtTableRow["ExpenseHdId"] = Convert.ToInt32(ddlExpenseName.SelectedValue);
                        dtTableRow["#"] = Convert.ToInt32(ddlExpenseName.SelectedValue);
                        dtTableRow["Amount"] = Convert.ToDecimal(txtExpAmount.Text);
                        dtTableRow["Remark"] = txtRemark.Text;
                      
                        dtCurrentTable.Rows.Add(dtTableRow);

                         ViewState["GrdExpDtls"] = dtCurrentTable;
                         GrdExpDtls.DataSource = dtCurrentTable;
                         GrdExpDtls.DataBind();
                        //MakeControlEmpty();
                    }

                }
            }
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
      
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

                            DS = Obj_EH.GetExpenceHeadToEdit(Convert.ToInt32(e.CommandArgument), out StrError);

                            if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
                            {
                                txtExpenseNo.Text = DS.Tables[0].Rows[0]["ExpRegNo"].ToString();
                                txtFromDate.Text = DS.Tables[0].Rows[0]["ExpenceRegDate"].ToString();
                                ddlPropertyName.SelectedValue = DS.Tables[0].Rows[0]["PropertyId"].ToString();
                                txtUnitNo.Text=DS.Tables[0].Rows[0]["UnitNo"].ToString();

                                if (DS.Tables.Count > 0 && DS.Tables[1].Rows.Count > 0)
                                {
                                    GrdExpDtls.DataSource = DS.Tables[1];
                                    GrdExpDtls.DataBind();
                                    ViewState["GrdExpDtls"] = DS.Tables[1];
                                }
                                else
                                {
                                    SetInitialRowExpDtls();
                                }
                                if (!FlagEdit)
                                    BtnUpdate.Visible = true;
                                BtnSave.Visible = false;
                            }
                            else
                            {
                                 MakeEmptyForm();
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
                Entity_EH.ExpregId = DeleteId;
                Entity_EH.UserId = Convert.ToInt32(Session["UserID"]);
                Entity_EH.LoginDate = DateTime.Now;

                int iDelete = Obj_EH.DeleteExpenceHead(ref Entity_EH, out StrError);
                if (iDelete != 0)
                {
                    Obj_Comm.ShowPopUpMsg("Record Deleted Successfully..!", this.Page);
                    MakeEmptyForm();
                }
            }
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        int irow = 0, idetrow = 0;
        try
        {
            DataSet DSC = new DataSet();

            DataTable dtInsert = new DataTable();
            dtInsert = (DataTable)ViewState["GrdExpDtls"];

            Entity_EH.ExpRegNo = txtExpenseNo.Text;
            Entity_EH.ExpenceRegDate = Convert.ToDateTime(txtFromDate.Text);
            Entity_EH.PropertyId = Convert.ToInt32(ddlPropertyName.SelectedValue);

            if(!string.IsNullOrEmpty(txtUnitNo.Text))
            {              
                string test= txtUnitNo.Text.ToString();
                string[] unit = test.Split('-');
                UnitNum = unit[0];
            }

            Entity_EH.UnitNo = UnitNum;
            Entity_EH.UserId = 1;//Convert.ToInt32(Session["UserId"]);
            Entity_EH.LoginDate = DateTime.Now;

            irow = Obj_EH.InsertExpenceHead(ref Entity_EH, out StrError);

            if (irow > 0)
            {
                if (ViewState["GrdExpDtls"] != null)
                {
                    #region
                    for (int i = 0; i < dtInsert.Rows.Count; i++)
                    {
                        Entity_EH.ExpregId = irow;
                        Entity_EH.ExpenseHdId = Convert.ToInt32(dtInsert.Rows[i]["ExpenseHdId"].ToString());
                        Entity_EH.Amount = Convert.ToDecimal(dtInsert.Rows[i]["Amount"].ToString());
                        Entity_EH.Remark = dtInsert.Rows[i]["Remark"].ToString();

                        idetrow = Obj_EH.InsertExpenceHeadDetail(ref Entity_EH, out StrError);
                    }
                    #endregion
                }
            }

            if (irow > 0 && idetrow > 0)
            {
                Obj_Comm.ShowPopUpMsg("Record Saved Successfully..!", this.Page);

            }
            MakeEmptyForm();
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
            dtInsert = (DataTable)ViewState["GrdExpDtls"];

            Entity_EH.ExpregId = Convert.ToInt32(ViewState["EditID"]);
            Entity_EH.ExpRegNo = txtExpenseNo.Text;
            Entity_EH.ExpenceRegDate = Convert.ToDateTime(txtFromDate.Text);
            Entity_EH.PropertyId = Convert.ToInt32(ddlPropertyName.SelectedValue);

            if (!string.IsNullOrEmpty(txtUnitNo.Text))
            {
                string test = txtUnitNo.Text.ToString();
                string[] unit = test.Split('-');
                UnitNum = unit[0];
            }

            Entity_EH.UserId = 1;
            Entity_EH.LoginDate = DateTime.Now;

            irow = Obj_EH.UpdatetExpenceHead(ref Entity_EH, out StrError);

            if (irow > 0)
            {
                if (ViewState["GrdExpDtls"] != null)
                {
                    #region
                    for (int i = 0; i < dtInsert.Rows.Count; i++)
                    {
                        Entity_EH.ExpregId = Convert.ToInt32(ViewState["EditID"]);
                        Entity_EH.ExpenseHdId = Convert.ToInt32(dtInsert.Rows[i]["ExpenseHdId"].ToString());
                        Entity_EH.Amount = Convert.ToDecimal(dtInsert.Rows[i]["Amount"].ToString());
                        Entity_EH.Remark = dtInsert.Rows[i]["Remark"].ToString();

                        idetrow = Obj_EH.InsertExpenceHeadDetail(ref Entity_EH, out StrError);
                    }
                    #endregion
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

    #region[WebService]

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        DMExpenceHeadMaster Obj_Con = new DMExpenceHeadMaster();
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

    #region["Web Services"]
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionListUnitNo(string prefixText, int count, string contextKey)
    {
        DMExpenseRegister obj_PropertyMaster = new DMExpenseRegister();
        String[] SearchList = obj_PropertyMaster.GetSuggestedRecordForUnit(prefixText);
        return SearchList;
    }
    #endregion
   
    protected void GrdExpDtls_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int Index=0;
            if (e.CommandName == "SelectDtls")
            {
                ImgAddRrow.ToolTip = "Update";

                Index = Convert.ToInt32(e.CommandArgument);

                if (ViewState["GrdExpDtls"] != null)
                {
                    DataTable dtCurrentTable = (DataTable)ViewState["GrdExpDtls"];

                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        ViewState["GridIndexNew"] = Index;
                        ddlExpenseName.SelectedValue = Convert.ToInt32(dtCurrentTable.Rows[Index]["ExpenseHdId"]).ToString();
                        txtExpAmount.Text = dtCurrentTable.Rows[Index]["Amount"].ToString();
                        txtRemark.Text = dtCurrentTable.Rows[Index]["Remark"].ToString();
                    }
                }
            }
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }

    protected void GrdExpDtls_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            if ( ViewState["GrdExpDtls"] != null)
            {
                int id = e.RowIndex;
                DataTable dt = (DataTable) ViewState["GrdExpDtls"];

                dt.Rows.RemoveAt(id);

                if (dt.Rows.Count > 0)
                {
                    GrdExpDtls.DataSource = dt;
                     ViewState["GrdExpDtls"] = dt;
                    GrdExpDtls.DataBind();
                }
                else
                {
                    SetInitialRowExpDtls();
                }
            }
        }
        catch (Exception)
        {

            throw;
        }
    }

}
