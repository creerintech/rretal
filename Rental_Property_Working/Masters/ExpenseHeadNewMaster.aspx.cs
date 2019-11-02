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
using Build.Utility;
using Build.EntityClass;
using Build.DB;
using Build.DataModel;
using Build.DALSQLHelper;
using System.Threading;

public partial class Masters_ExpenseHeadNewMaster : System.Web.UI.Page
{
    #region[Private Variables]
    DMExpenseNewMaster Obj_Expense = new DMExpenseNewMaster();
    ExpenseNewMaster Entity_Expense = new ExpenseNewMaster();
    CommanFunction Obj_Comm = new CommanFunction();
    DataSet DS = new DataSet();

    private string StrError = string.Empty;
    private string StrCondition = string.Empty;
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

                DataRow[] dtRow = dsChkUserRight1.Tables[1].Select("FormName ='Unit Type Master'");
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
        txtExpense.Focus();
        if (!FlagAdd)
            BtnSave.Visible = true;
        BtnUpdate.Visible = false;
        BtnDelete.Visible = false;
        BtnCancel.Visible = true;
        txtExpense.Text = string.Empty;
        TxtSearch.Text = string.Empty;
        ReportGrid(StrCondition);
    }

    private void ReportGrid(string RepCondition)
    {
        try
        {
            DS = Obj_Expense.GetExpenseList(RepCondition, out StrError);

            if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
            {
                GrdReport.DataSource = DS;
                GrdReport.DataBind();
            }
            else
            {
                GrdReport.DataSource = null;
                GrdReport.DataBind();
            }
            Obj_Expense = null;
            DS = null;
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
            CheckUserRight();
            MakeEmptyForm();
        }
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        int InsertRow = 0;
        try
        {
            DS = Obj_Expense.ChkDuplicate(txtExpense.Text.Trim().ToUpper(), out StrError);
            if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
            {
                Obj_Comm.ShowPopUpMsg("This Expense  Already Exist For ", this.Page);
                txtExpense.Focus();
            }
            else
            {
                Entity_Expense.Expense = txtExpense.Text.Trim();


                Entity_Expense.UserId = Convert.ToInt32(Session["UserId"]);
                Entity_Expense.LoginDate = DateTime.Now;

                InsertRow = Obj_Expense.InsertExpense(ref Entity_Expense, out StrError);

                if (InsertRow > 0)
                {
                    Obj_Comm.ShowPopUpMsg("Record Saved Successfully", this.Page);
                    MakeEmptyForm();

                    Entity_Expense = null;
                    Obj_Comm = null;
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        int i = Convert.ToInt32(hiddenbox.Value);
        if (i == 0)
        {
            int UpdateRow = 0;
            try
            {
                if (ViewState["EditID"] != null)
                {
                    Entity_Expense.ExpenseHdId = Convert.ToInt32(ViewState["EditID"]);
                }
                Entity_Expense.Expense = txtExpense.Text.Trim();

                Entity_Expense.UserId = Convert.ToInt32(Session["UserId"]);
                Entity_Expense.LoginDate = DateTime.Now;
                UpdateRow = Obj_Expense.UpdateExpense(ref Entity_Expense, out StrError);
                if (UpdateRow != 0)
                {
                    Obj_Comm.ShowPopUpMsg("Record Updated Successfully", this.Page);
                    MakeEmptyForm();

                    Entity_Expense = null;
                    Obj_Comm = null;
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
                            LinkButton lnk = (LinkButton)e.Item.FindControl("lbtn_List");
                            Label lbl = (Label)e.Item.FindControl("lblUsedCnt");
                            if (lnk != null)
                            {
                                hdnFldUsedCnt.Value = lbl.Text;
                            }
                            DS = Obj_Expense.GetExpenseForEdit(Convert.ToInt32(e.CommandArgument), out StrError);
                            if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
                            {
                                txtExpense.Text = DS.Tables[0].Rows[0]["Expense"].ToString();

                            }
                            else
                            {
                                MakeEmptyForm();
                            }
                            DS = null;
                            Obj_Expense = null;
                            BtnSave.Visible = false;
                            if (!FlagEdit)
                                BtnUpdate.Visible = true;
                            if (!FlagDel)
                                BtnDelete.Visible = true;
                            txtExpense.Focus();
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

    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        //int i = Convert.ToInt32(hiddenbox.Value);
        //if (i == 0)
        //{
        //    try
        //    {
        //        int DeleteId = 0;
        //        if (ViewState["EditID"] != null)
        //        {
        //            if (long.Parse(hdnFldUsedCnt.Value.ToString()) > 0)
        //            {
        //                Obj_Comm.ShowPopUpMsg("Expense Head is in use. Cannot Delete Record...", this.Page);
        //                return;
        //            }

        //            DeleteId = Convert.ToInt32(ViewState["EditID"]);
        //        }
        //        if (DeleteId != 0)
        //        {
        //            Entity_Expense.ExpenseHdId = DeleteId;
        //            Entity_Expense.UserId = Convert.ToInt32(Session["UserId"]);
        //            Entity_Expense.LoginDate = DateTime.Now;

        //            int iDelete = Obj_Expense.DeleteExpense(ref Entity_Expense, out StrError);
        //            if (iDelete != 0)
        //            {
        //                Obj_Comm.ShowPopUpMsg("Record Deleted Successfully..!", this.Page);
        //                MakeEmptyForm();
        //            }

        //        }
        //        Entity_Expense = null;
        //        Obj_Comm = null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        int DeleteId = 0;
        try
        {
            if (ViewState["EditID"] != null)
            {
                DeleteId = Convert.ToInt32(ViewState["EditID"]);
            }
            if (DeleteId != 0)
            {
                Entity_Expense.ExpenseHdId = DeleteId;
                Entity_Expense.UserId = Convert.ToInt32(Session["UserId"]);
                Entity_Expense.LoginDate = DateTime.Now;

               int iDelete = Obj_Expense.DeleteExpense(ref Entity_Expense, out StrError);
               if (iDelete != 0)
               {
                   Obj_Comm.ShowPopUpMsg("Record Deleted Successfully..!", this.Page);
                   MakeEmptyForm();
               }

            }
            Entity_Expense = null;
            Obj_Comm = null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        MakeEmptyForm();

    }

    protected void TxtSearch_TextChanged(object sender, EventArgs e)
    {
        StrCondition = TxtSearch.Text.Trim();
        ReportGrid(StrCondition);
    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        DMExpenseNewMaster Obj_Expense = new DMExpenseNewMaster();
        string[] SearchList = Obj_Expense.GetSuggestRecord(prefixText);
        return SearchList;
    }
}
