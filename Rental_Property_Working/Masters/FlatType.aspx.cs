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

public partial class Masters_FlatType : System.Web.UI.Page
{
    #region[Private Variables]
    DMFlatTypeMaster Obj_FlatType = new DMFlatTypeMaster();
    FlatTypeMaster Entity_FlatType = new FlatTypeMaster();
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
        BindCMB();
        txtFlatType.Focus();
        if (!FlagAdd)
            BtnSave.Visible = true;
        BtnUpdate.Visible = false;
        BtnDelete.Visible = false;
        BtnCancel.Visible = true;
        txtFlatType.Text = string.Empty;
        TxtSearch.Text = string.Empty;
        ReportGrid(StrCondition);
    }

    private void ReportGrid(string RepCondition)
    {
        try
        {
            DS = Obj_FlatType.GetFlatTypeList(RepCondition, out StrError);

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
            Obj_FlatType = null;
            DS = null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }

    private void BindCMB()
    {
        DataSet DSC = new DataSet();
        DSC = Obj_FlatType.GetProjectType(out StrError);

        if (DSC.Tables.Count > 0)
        {
            if (DSC.Tables[0].Rows.Count > 0)
            {
                //ddlProjectType.DataSource = DSC.Tables[0];
                //ddlProjectType.DataTextField = "ProjectType";
                //ddlProjectType.DataValueField = "ProjectTypeId";
                //ddlProjectType.DataBind();
            }
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
            DS = Obj_FlatType.ChkDuplicate(txtFlatType.Text.Trim().ToUpper(), out StrError);
            if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
            {
                Obj_Comm.ShowPopUpMsg("This Unit Type Already Exist For ", this.Page);
                txtFlatType.Focus();
            }
            else
            {
                Entity_FlatType.FlatType = txtFlatType.Text.Trim();
                

                Entity_FlatType.UserId = Convert.ToInt32(Session["UserId"]);
                Entity_FlatType.LoginDate = DateTime.Now;

                InsertRow = Obj_FlatType.InsertFlatType(ref Entity_FlatType, out StrError);

                if (InsertRow > 0)
                {
                    Obj_Comm.ShowPopUpMsg("Record Saved Successfully", this.Page);
                    MakeEmptyForm();
                    
                    Entity_FlatType = null;
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
                    Entity_FlatType.FlatTypeId = Convert.ToInt32(ViewState["EditID"]);
                }
                Entity_FlatType.FlatType = txtFlatType.Text.Trim();
                
                Entity_FlatType.UserId = Convert.ToInt32(Session["UserId"]);
                Entity_FlatType.LoginDate = DateTime.Now;
                UpdateRow = Obj_FlatType.UpdateFlatType(ref Entity_FlatType, out StrError);
                if (UpdateRow != 0)
                {
                    Obj_Comm.ShowPopUpMsg("Record Updated Successfully", this.Page);
                    MakeEmptyForm();
                    
                    Entity_FlatType = null;
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
                            DS = Obj_FlatType.GetFlatTypeForEdit(Convert.ToInt32(e.CommandArgument), out StrError);
                            if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
                            {
                                txtFlatType.Text = DS.Tables[0].Rows[0]["FlatType"].ToString();
                               
                            }
                            else
                            {
                                MakeEmptyForm();
                            }
                            DS = null;
                            Obj_FlatType = null;                          
                            BtnSave.Visible = false;
                            if (!FlagEdit)
                                BtnUpdate.Visible = true;
                            if (!FlagDel)
                                BtnDelete.Visible = true;
                            txtFlatType.Focus();
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
        int i = Convert.ToInt32(hiddenbox.Value);
        if (i == 0)
        {
            try
            {
                int DeleteId = 0;
                if (ViewState["EditID"] != null)
                {
                    if (long.Parse(hdnFldUsedCnt.Value.ToString()) > 0)
                    {
                        Obj_Comm.ShowPopUpMsg("Unit type is in use. Cannot Delete Record...", this.Page);
                        return;
                    }

                    DeleteId = Convert.ToInt32(ViewState["EditID"]);
                }
                if (DeleteId != 0)
                {
                    Entity_FlatType.FlatTypeId = DeleteId;
                    Entity_FlatType.UserId = Convert.ToInt32(Session["UserId"]);
                    Entity_FlatType.LoginDate = DateTime.Now;
                    int iDelete = Obj_FlatType.DeleteFlatType(ref Entity_FlatType, out StrError);
                    if (iDelete != 0)
                    {
                        Obj_Comm.ShowPopUpMsg("Record Deleted Successfully..!", this.Page);
                        MakeEmptyForm();
                    }

                }
                Entity_FlatType = null;
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
        
    }

    protected void TxtSearch_TextChanged(object sender, EventArgs e)
    {
        StrCondition = TxtSearch.Text.Trim();
        ReportGrid(StrCondition);
    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        DMFlatTypeMaster Obj_FlatType = new DMFlatTypeMaster();
        string[] SearchList = Obj_FlatType.GetSuggestRecord(prefixText);
        return SearchList;
    }
}
