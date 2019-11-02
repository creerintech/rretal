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

using Build.Utility;
using Build.EntityClass;
using Build.DB;
using Build.DataModel;
using Build.DALSQLHelper;
using System.Threading;

public partial class Masters_EmployeeMaster : System.Web.UI.Page
{
    #region [Private Variable]

    CommanFunction obj_Comman = new CommanFunction();
    DataSet Ds = new DataSet();
    private string StrCondition = string.Empty;
    private string StrError = string.Empty;
    DMEmployeeMaster obj_Emp = new DMEmployeeMaster();
    EmployeeMaster Entity_Emp = new EmployeeMaster();
    string BookingNum = string.Empty;
    private static bool FlagAdd = false, FlagDel = false, FlagEdit = false; 
    //public static int countPage = 0;
    //int str = 0;
    #endregion

    #region [User Defined Function]

    public void MakeEmptyForm()
    {
        txtEmpCode.Enabled = false;
        txtEmpName.Text = string.Empty;
        TxtAddress.Text = string.Empty;
        TxtTel1.Text = string.Empty;
        TxtTel2.Text = string.Empty;
        TxtMobile.Text = string.Empty;
        TxtEmail.Text = string.Empty;
        TxtCity.Text = string.Empty;
        TxtState.Text = string.Empty;
        TxtPinCode.Text = string.Empty;
        TxtNotes.Text = string.Empty;
        TxtSearch.Text = string.Empty;
        txtEmpName.Focus();
        //txtDOB.Text = DateTime.Now.ToString("dd MMM yyyy");
        //txtDOJ.Text = DateTime.Now.ToString("dd MMM yyyy");
        txtDOB.Text = string.Empty;
        txtDOJ.Text = string.Empty;
        EmpCode();
        ReportGrid(StrCondition);
        BtnUpdate.Visible = false;
        BtnDelete.Visible = false;
        if (!FlagAdd)
            BtnSave.Visible = true;
    }

    public void ReportGrid(string RepCondition)
    {
        try
        {
            Ds = new DataSet();
            DMEmployeeMaster obj_DMCustomerMaster = new DMEmployeeMaster();
            Ds = obj_Emp.GetEmployee(RepCondition, out StrError);
            if (Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
            {
                ViewState["CurrentTable1"] = Ds.Tables[0];
                GrdReport.DataSource = Ds.Tables[0];
                GrdReport.DataBind();
                if (Ds.Tables[1].Rows.Count > 0)
                {
                    ViewState["EmpCode"] = Ds.Tables[1].Rows[0][0].ToString();
                    txtEmpCode.Text = ViewState["EmpCode"].ToString();
                }

                //rptPages.Visible = false;

            }
            else
            {
                GrdReport.DataSource = null;
                GrdReport.DataBind();
            }
            // obj_DMCustomerMaster = null;
            Ds = null;
        }
        catch (Exception ex)
        {
            obj_Comman.ShowPopUpMsg(ex.Message, this.Page);
        }
    }

    public void EmpCode()
    {
        try
        {
            DataSet DsCode = new DataSet();
            DsCode = obj_Emp.GetEmpCode(out StrError);
            if (DsCode.Tables[0].Rows.Count > 0)
            {
                BookingNum = DsCode.Tables[0].Rows[0]["EmpCode"].ToString();
            }
            txtEmpCode.Text = BookingNum;
        }
        catch (Exception ex)
        {
            obj_Comman.ShowPopUpMsg(ex.Message, this.Page);
        }
    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        DMEmployeeMaster obj_Emp = new DMEmployeeMaster();
        String[] SearchList = obj_Emp.GetSuggestedRecord(prefixText);
        return SearchList;
    }

    private void GetEditRecord()
    {
        if (Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        {
            txtEmpCode.Text = Ds.Tables[0].Rows[0]["EmpCode"].ToString();
            txtEmpName.Text = Ds.Tables[0].Rows[0]["Empname"].ToString();
            TxtAddress.Text = Ds.Tables[0].Rows[0]["EmpAddress"].ToString();
            TxtTel1.Text = Ds.Tables[0].Rows[0]["tel1"].ToString();
            TxtTel2.Text = Ds.Tables[0].Rows[0]["tel2"].ToString();
            TxtMobile.Text = Ds.Tables[0].Rows[0]["mobile"].ToString();
            txtDOB.Text = Ds.Tables[0].Rows[0]["dob"].ToString();
            txtDOJ.Text = Ds.Tables[0].Rows[0]["Employedon"].ToString();
            TxtEmail.Text = Ds.Tables[0].Rows[0]["Email"].ToString();
            TxtCity.Text = Ds.Tables[0].Rows[0]["city"].ToString();
            TxtState.Text = Ds.Tables[0].Rows[0]["state"].ToString();
            TxtPinCode.Text = Ds.Tables[0].Rows[0]["pin"].ToString();
            TxtNotes.Text = Ds.Tables[0].Rows[0]["Notes"].ToString();
        }
        else
        {
            MakeEmptyForm();
        }
        if (!FlagEdit)
            BtnUpdate.Visible = true;
        if (!FlagDel)
            BtnDelete.Visible = true;
        BtnSave.Visible = false;
        txtEmpName.Focus();
    }

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

                DataRow[] dtRow = dsChkUserRight1.Tables[1].Select("FormName ='Employee Master'");
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

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CheckUserRight();
            MakeEmptyForm();
        }
    }

    protected void TxtSearch_TextChanged(object sender, EventArgs e)
    {
        StrCondition = TxtSearch.Text.Trim();
        StrCondition = StrCondition.Replace("[", @"\[");
        ReportGrid(StrCondition);
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        int InsertRow = 0;
        try
        {
            Ds = obj_Emp.ChkDuplicate(txtEmpName.Text.Trim(), out StrError);

            if (Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
            {
                obj_Comman.ShowPopUpMsg("This Employee Already Exist....!", this.Page);
                txtEmpName.Focus();
            }
            else
            {
                Entity_Emp.EmpCode = txtEmpCode.Text;
                Entity_Emp.Empname = txtEmpName.Text;
                Entity_Emp.EmpAddress = TxtAddress.Text;
                Entity_Emp.Tel1 = TxtTel1.Text;
                Entity_Emp.Tel2 = TxtTel2.Text;
                Entity_Emp.Mobile = TxtMobile.Text;
                Entity_Emp.Dob = (!string.IsNullOrEmpty(txtDOB.Text)) ? Convert.ToDateTime(txtDOB.Text.Trim()) : Convert.ToDateTime("1-Jan-1753");
                Entity_Emp.Email = TxtEmail.Text;
                Entity_Emp.City = TxtCity.Text;
                Entity_Emp.State = TxtState.Text;
                Entity_Emp.Pin = TxtPinCode.Text;
                Entity_Emp.Employedon = (!string.IsNullOrEmpty(txtDOJ.Text)) ? Convert.ToDateTime(txtDOJ.Text.Trim()) : Convert.ToDateTime("1-Jan-1753");
                Entity_Emp.Notes = TxtNotes.Text;
                Entity_Emp.LoginID = Convert.ToInt32(Session["UserID"]);
                Entity_Emp.LoginDate = DateTime.Now;

                InsertRow = obj_Emp.InsertEmployee(ref Entity_Emp, out StrError);

                if (InsertRow != 0)
                {
                    obj_Comman.ShowPopUpMsg("Record Saved Successfully", this.Page);

                    MakeEmptyForm();
                }
            }
        }
        catch (Exception ex)
        {
            obj_Comman.ShowPopUpMsg(ex.Message, this.Page);
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
                    Entity_Emp.EmpID = Convert.ToInt32(ViewState["EditID"]);
                }
                Entity_Emp.EmpCode = txtEmpCode.Text;
                Entity_Emp.Empname = txtEmpName.Text;
                Entity_Emp.EmpAddress = TxtAddress.Text;
                Entity_Emp.Tel1 = TxtTel1.Text;
                Entity_Emp.Tel2 = TxtTel2.Text;
                Entity_Emp.Mobile = TxtMobile.Text;
                Entity_Emp.Dob = (!string.IsNullOrEmpty(txtDOB.Text)) ? Convert.ToDateTime(txtDOB.Text.Trim()) : Convert.ToDateTime("1-Jan-1753");
                Entity_Emp.Email = TxtEmail.Text;
                Entity_Emp.City = TxtCity.Text;
                Entity_Emp.State = TxtState.Text;
                Entity_Emp.Pin = TxtPinCode.Text;
                Entity_Emp.Employedon = (!string.IsNullOrEmpty(txtDOJ.Text)) ? Convert.ToDateTime(txtDOJ.Text.Trim()) : Convert.ToDateTime("1-Jan-1753");
                Entity_Emp.Notes = TxtNotes.Text;
                Entity_Emp.LoginID = Convert.ToInt32(Session["UserID"]);
                Entity_Emp.LoginDate = DateTime.Now;

                UpdateRow = obj_Emp.UpdateEmployee(ref Entity_Emp, out StrError);

                if (UpdateRow != 0)
                {
                    obj_Comman.ShowPopUpMsg("Record Updated Successfully", this.Page);
                    MakeEmptyForm();
                }
            }
            catch (Exception ex)
            {
                obj_Comman.ShowPopUpMsg(ex.Message, this.Page);
            }
        }
    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        MakeEmptyForm();
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
                            Ds = obj_Emp.GetEmployeeForEdit(Convert.ToInt32(e.CommandArgument), out StrError);
                            if (Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                            {
                                txtEmpCode.Text = Ds.Tables[0].Rows[0]["EmpCode"].ToString();
                                txtEmpName.Text = Ds.Tables[0].Rows[0]["Empname"].ToString();
                                TxtAddress.Text = Ds.Tables[0].Rows[0]["EmpAddress"].ToString();
                                TxtTel1.Text = Ds.Tables[0].Rows[0]["tel1"].ToString();
                                TxtTel2.Text = Ds.Tables[0].Rows[0]["tel2"].ToString();
                                TxtMobile.Text = Ds.Tables[0].Rows[0]["mobile"].ToString();
                                txtDOB.Text = Ds.Tables[0].Rows[0]["dob"].ToString();
                                txtDOJ.Text = Ds.Tables[0].Rows[0]["Employedon"].ToString();
                                TxtEmail.Text = Ds.Tables[0].Rows[0]["Email"].ToString();
                                TxtCity.Text = Ds.Tables[0].Rows[0]["city"].ToString();
                                TxtState.Text = Ds.Tables[0].Rows[0]["state"].ToString();
                                TxtPinCode.Text = Ds.Tables[0].Rows[0]["pin"].ToString();
                                TxtNotes.Text = Ds.Tables[0].Rows[0]["Notes"].ToString();
                                hdnFldUsedCnt.Value = Ds.Tables[0].Rows[0]["UsedCount"].ToString();

                            }
                            else
                            {
                                MakeEmptyForm();
                            }
                            Ds = null;
                            obj_Emp = null;                         
                            BtnSave.Visible = false;
                            if (!FlagEdit)
                                BtnUpdate.Visible = true;
                            if (!FlagDel)
                                BtnDelete.Visible = true;
                        
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
        try
        {
            //===========Get The Grid View RowIndex See ImgBtnDeleteNew commnad Argumnet for syntax CommandArgument='<%# Eval("#")+ ","+((GridViewRow)Container).RowIndex %>'             
            if (ViewState["EditID"] != null)
            {
                if (long.Parse(hdnFldUsedCnt.Value.ToString()) > 0)
                {
                    obj_Comman.ShowPopUpMsg("Employee is in use. Cannot Delete Record...", this.Page);
                    return;
                }
                Entity_Emp.EmpID = Convert.ToInt32(ViewState["EditID"]);
                Entity_Emp.LoginID = Convert.ToInt32(Session["UserID"]);
                Entity_Emp.LoginDate = DateTime.Now;

                int iDelete = obj_Emp.DeleteEmployee(ref Entity_Emp, out StrError);
                if (iDelete != 0)
                {
                    obj_Comman.ShowPopUpMsg("Record Deleted Successfully..!", this.Page);
                    MakeEmptyForm();
                }
            }
        }
        catch (Exception ex)
        {
            obj_Comman.ShowPopUpMsg(ex.Message, this.Page);
        }
    }
}
