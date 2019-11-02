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

using Build.EntityClass;
using Build.DALSQLHelper;
using Build.DB;
using Build.Utility;
using Build.BussinessLayer;

public partial class Masters_UserMaster : System.Web.UI.Page
{
    #region[Variables]
    CommanFunction obj_Comman = new CommanFunction();
    DataSet Ds = new DataSet();
    private string StrCondition = string.Empty;
    private string StrError = string.Empty;
    private bool Flag = true;
    public int EditID = 0;
    DMUserMaster obj_DMUserMaster = new DMUserMaster();
    UserMaster Entity_UserMaster = new UserMaster();
    private static bool FlagAdd = false, FlagDel = false, FlagEdit = false;
    #endregion

    #region User Defined Function

    public void FillCombo()
    {
        try
        {
            Ds = obj_DMUserMaster.BindCombo(out StrError);
            if (Ds.Tables.Count > 0)
            {
                if (Ds.Tables[0].Rows.Count > 0)
                {
                    //ddlEmployee.DataSource = Ds.Tables[0];
                    //ddlEmployee.DataTextField = "Employee";
                    //ddlEmployee.DataValueField = "EmpID";                
                    //ddlEmployee.DataBind();
                    
                }
                if (Ds.Tables[1].Rows.Count > 0)
                {
                   //// ChkProject.DataSource = Ds.Tables[1];
                   //// ChkProject.DataValueField = "PCId";
                   //// ChkProject.DataTextField = "Project";
                   //// ChkProject.DataBind();
                   ////// ViewState["IsCentral"] = DS.Tables[1];
                }
            }          
        }

        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void MakeEmptyform()
    {
        ViewState["EditID"] = null;
        if (!FlagAdd)
            BtnSave.Visible = true;
        BtnUpdate.Visible = false;
        BtnDelete.Visible = false;
        TxtSearch.Text = string.Empty;
        //TxtUserName.Text = string.Empty;             
        txtUser.Text = string.Empty;
        TxtEmailid.Text = string.Empty;
        txtpassword.Attributes["value"] = "";
        txtConfirmpassword.Attributes["value"] = "";
        FillCombo();
        FillGrid();
        ReportGrid(StrCondition);
        RadioIsAdmin.Enabled = true;
        RadioIsAdmin.SelectedValue = "F";
        //for (int i = 0; i < ChkProject.Items.Count; i++)
        //{
        //    ChkProject.Items[i].Selected = false;
        //}
        DisableCheckbox();
       // TxtUserName.Focus();
    }

    public void DisableCheckbox()
    {
        for (int i = 0; i < GridUserRight.Rows.Count; i++)
        {
            CheckBox GrdEditRight = (CheckBox)GridUserRight.Rows[i].Cells[7].FindControl("GrdEditRight");
            CheckBox GrdViewRight = (CheckBox)GridUserRight.Rows[i].Cells[6].FindControl("GrdViewRight");
            CheckBox GrdDelRight = (CheckBox)GridUserRight.Rows[i].Cells[8].FindControl("GrdDelRight");
            CheckBox GrdPrintRight = (CheckBox)GridUserRight.Rows[i].Cells[9].FindControl("GrdPrintRight");
            if (GrdViewRight.Checked)
            {
                GrdEditRight.Enabled = true;
                GrdDelRight.Enabled = true;
                GrdPrintRight.Enabled = true;
            }
            else
            {
                GrdEditRight.Enabled = false;
                GrdDelRight.Enabled = false;
                GrdPrintRight.Enabled = false;
            }
        }
    }

    public void FillGrid()
    {
        try
        {
            Ds = obj_DMUserMaster.GetUserRightTable(out StrError);
            if (Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
            {
                GridUserRight.DataSource = Ds.Tables[0];
                GridUserRight.DataBind();
            }
            else
            {
                GridUserRight.DataSource = null;
                GridUserRight.DataBind();
            }          
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }

    public void ReportGrid(string RepCondition)
    {
        try
        {
            Ds = obj_DMUserMaster.GetUserDetails(RepCondition, out StrError);
            if (Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
            {
                GrdReport.DataSource = Ds.Tables[0];
                GrdReport.DataBind();
            }
            else
            {
                GrdReport.DataSource = null;
                GrdReport.DataBind();
            }
            Ds = null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
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

                DataRow[] dtRow = dsChkUserRight1.Tables[1].Select("FormName ='User Master'");
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
        txtpassword.Attributes["value"] = txtpassword.Text;
        txtConfirmpassword.Attributes["value"] = txtConfirmpassword.Text;
        if (!Page.IsPostBack)
        {
           CheckUserRight();
            MakeEmptyform();
        }
    }
   
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        int InsertRow = 0, InsertDetail = 0, InsertChkDetail = 0;
        try
        {
            if (Check() == true)
            {

                //DS = Obj_UserMaster.ChkDuplicate(TxtUserName.Text.Trim(), out StrError);
                //if (DS.Tables[0].Rows.Count > 0)
                //{
                //    Obj_Comm.ShowPopUpMsg("Please Enter Another Name !!!", this.Page);
                //    TxtUserName.Focus();
                //}
                //else
                //{
                Entity_UserMaster.UserName = TxtUserName.Text;           
                Entity_UserMaster.LoginName = txtUser.Text;
                Entity_UserMaster.EmailId = TxtEmailid.Text;
                Entity_UserMaster.Password = txtpassword.Text;

                if (RadioIsAdmin.Text.Equals("T"))
                {
                    Entity_UserMaster.IsAdmin = true;
                    Entity_UserMaster.UserType = "Admin";
                }
                if (RadioIsAdmin.Text.Equals("F"))
                {
                    Entity_UserMaster.IsAdmin = false;
                    Entity_UserMaster.UserType = "User";
                }
                Entity_UserMaster.LUserID = Convert.ToInt32(Session["UserID"]);
                Entity_UserMaster.LoginDate = DateTime.Today;
                Entity_UserMaster.IsDeleted = false;

                InsertRow = obj_DMUserMaster.InsertUserDetails(ref Entity_UserMaster, out StrError);

                if (InsertRow > 0)
                {
                    int ID = InsertRow;
                    for (int i = 0; i < GridUserRight.Rows.Count; i++)
                    {
                        Label LblFromName = (Label)GridUserRight.Rows[i].Cells[3].FindControl("LblFormName");
                        CheckBox GrdAddRight = (CheckBox)GridUserRight.Rows[i].Cells[4].FindControl("GrdAddRight");
                        CheckBox GrdViewRight = (CheckBox)GridUserRight.Rows[i].Cells[5].FindControl("GrdViewRight");
                        CheckBox GrdEditRight = (CheckBox)GridUserRight.Rows[i].Cells[6].FindControl("GrdEditRight");
                        CheckBox GrdDelRight = (CheckBox)GridUserRight.Rows[i].Cells[7].FindControl("GrdDelRight");
                        CheckBox GrdPrintRight = (CheckBox)GridUserRight.Rows[i].Cells[8].FindControl("GrdPrintRight");

                        Entity_UserMaster.FkUserId = ID;
                        Entity_UserMaster.FormName = LblFromName.Text.Trim();
                        Entity_UserMaster.ViewAuth = GrdViewRight.Checked == true ? Convert.ToBoolean(1) : Convert.ToBoolean(0);
                        Entity_UserMaster.AddAuth = GrdAddRight.Checked == true ? Convert.ToBoolean(1) : Convert.ToBoolean(0);
                        Entity_UserMaster.EditAuth = GrdEditRight.Checked == true ? Convert.ToBoolean(1) : Convert.ToBoolean(0);
                        Entity_UserMaster.DelAuth = GrdDelRight.Checked == true ? Convert.ToBoolean(1) : Convert.ToBoolean(0);
                        Entity_UserMaster.PrintAuth = GrdPrintRight.Checked == true ? Convert.ToBoolean(1) : Convert.ToBoolean(0);

                        InsertDetail = obj_DMUserMaster.InsertUserAuthDetails(ref Entity_UserMaster, out StrError);
                    }
                  
                    if (InsertRow > 0)
                    {
                        obj_Comman.ShowPopUpMsg("Record Saved Successfully..!", this.Page);
                        MakeEmptyform();
                        Entity_UserMaster = null;
                        obj_Comman = null;
                    }
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
        int UpdateRow = 0, InsertDetail = 0, InsertChkDetail = 0;
        try
        {
            if (Check() == true)
            {
                if (ViewState["EditID"] != null)
                {
                    Entity_UserMaster.UserID = Convert.ToInt32(ViewState["EditID"]);
                }
                 Entity_UserMaster.UserName = TxtUserName.Text.Trim();
                // Entity_UserMaster.EmpID = Convert.ToInt32(ddlEmployee.SelectedValue);
                 Entity_UserMaster.LoginName = txtUser.Text.Trim();
                 Entity_UserMaster.EmailId = TxtEmailid.Text.Trim();
                 Entity_UserMaster.Password = txtpassword.Text.Trim();

                if (RadioIsAdmin.Text.Equals("T"))
                {
                    Entity_UserMaster.IsAdmin = true;
                    Entity_UserMaster.UserType = "Admin";
                }
                if (RadioIsAdmin.Text.Equals("F"))
                {
                    Entity_UserMaster.IsAdmin = false;
                    Entity_UserMaster.UserType = "User";
                }
                Entity_UserMaster.UpdatedBy = Convert.ToInt32(Session["UserID"]);
                Entity_UserMaster.UpdatedDate = Convert.ToDateTime(DateTime.Today.ToString());

                UpdateRow = obj_DMUserMaster.UpdateUserDetails(ref Entity_UserMaster, out StrError);

                if (UpdateRow > 0)
                {
                    for (int i = 0; i < GridUserRight.Rows.Count; i++)
                    {
                        Label LblFormName = (Label)GridUserRight.Rows[i].Cells[3].FindControl("LblFormName");
                        CheckBox GrdAddRight = (CheckBox)GridUserRight.Rows[i].Cells[4].FindControl("GrdAddRight");
                        CheckBox GrdViewRight = (CheckBox)GridUserRight.Rows[i].Cells[5].FindControl("GrdViewRight");
                        CheckBox GrdEditRight = (CheckBox)GridUserRight.Rows[i].Cells[6].FindControl("GrdEditRight");
                        CheckBox GrdDelRight = (CheckBox)GridUserRight.Rows[i].Cells[7].FindControl("GrdDelRight");
                        CheckBox GrdPrintRight = (CheckBox)GridUserRight.Rows[i].Cells[8].FindControl("GrdPrintRight");

                        Entity_UserMaster.FkUserId = Convert.ToInt32(ViewState["EditID"]);
                        Entity_UserMaster.FormName = LblFormName.Text;
                        Entity_UserMaster.AddAuth = GrdAddRight.Checked == true ? Convert.ToBoolean(1) : Convert.ToBoolean(0);
                        Entity_UserMaster.ViewAuth = GrdViewRight.Checked == true ? Convert.ToBoolean(1) : Convert.ToBoolean(0);
                        Entity_UserMaster.EditAuth = GrdEditRight.Checked == true ? Convert.ToBoolean(1) : Convert.ToBoolean(0);
                        Entity_UserMaster.DelAuth = GrdDelRight.Checked == true ? Convert.ToBoolean(1) : Convert.ToBoolean(0);
                        Entity_UserMaster.PrintAuth = GrdPrintRight.Checked == true ? Convert.ToBoolean(1) : Convert.ToBoolean(0);

                        InsertDetail = obj_DMUserMaster.InsertUserAuthDetails(ref Entity_UserMaster, out StrError);
                    }
                
                    if (UpdateRow > 0)
                    {
                        obj_Comman.ShowPopUpMsg("Record Updated Successfully..!", this.Page);
                        MakeEmptyform();
                        Entity_UserMaster = null;
                        obj_Comman = null;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        MakeEmptyform();
        
    }

    protected void TxtSearch_TextChanged(object sender, EventArgs e)
    {        
            StrCondition = TxtSearch.Text.Trim();
            ReportGrid(StrCondition);       
    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetSuggestedRecord(string prefixText, int count, string contextKey)
    {
        DMUserMaster obj_DMUserMaster = new DMUserMaster();
        String[] SearchList = obj_DMUserMaster.GetSuggestedRecord(prefixText);
        return SearchList;
    }
   
    protected void GridUserRight_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //=========For Merge the Row In to Single Section=================
        for (int rowIndex = GridUserRight.Rows.Count - 2;
                                    rowIndex >= 0; rowIndex--)
        {
            GridViewRow gvRow = GridUserRight.Rows[rowIndex];
            GridViewRow gvPreviousRow = GridUserRight.Rows[rowIndex + 1];
            // for (int cellCount = 0; cellCount < gvRow.Cells.Count;cellCount++)
            //{
            if (gvRow.Cells[3].Text ==
                                   gvPreviousRow.Cells[3].Text)
            {
                if (gvPreviousRow.Cells[3].RowSpan < 2)
                {
                    gvRow.Cells[3].RowSpan = 2;
                }
                else
                {
                    gvRow.Cells[3].RowSpan =
                        gvPreviousRow.Cells[3].RowSpan + 1;
                }
                gvPreviousRow.Cells[3].Visible = false;
            }
            //}
        }
        //=========For Merge the Row In to Single Section=================

    }

    protected void GridUserRight_DataBound(object sender, EventArgs e)
    {
        ////=========For Merge the Row In to Single Section=================
        //for (int rowIndex = GridUserRight.Rows.Count - 2;
        //                            rowIndex >= 0; rowIndex--)
        //{
        //    GridViewRow gvRow = GridUserRight.Rows[rowIndex];
        //    GridViewRow gvPreviousRow = GridUserRight.Rows[rowIndex + 1];
        //    // for (int cellCount = 0; cellCount < gvRow.Cells.Count;cellCount++)
        //    //{
        //    if (gvRow.Cells[3].Text ==
        //                           gvPreviousRow.Cells[3].Text)
        //    {
        //        if (gvPreviousRow.Cells[3].RowSpan < 2)
        //        {
        //            gvRow.Cells[3].RowSpan = 2;
        //        }
        //        else
        //        {
        //            gvRow.Cells[3].RowSpan =
        //                gvPreviousRow.Cells[3].RowSpan + 1;
        //        }
        //        gvPreviousRow.Cells[3].Visible = false;
        //    }
        //    //}
        //}
        ////=========For Merge the Row In to Single Section=================

    }

    protected void GrdSelectAllHeader_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox GrdSelectAllHeader = ((CheckBox)GridUserRight.HeaderRow.FindControl("GrdSelectAllHeader"));
        if (GrdSelectAllHeader.Checked == true)
        {
            for (int i = 0; i < GridUserRight.Rows.Count; i++)
            {
                ((CheckBox)GridUserRight.Rows[i].Cells[0].FindControl("GrdSelectAll")).Checked = true;
                ((CheckBox)GridUserRight.Rows[i].Cells[4].FindControl("GrdAddRight")).Checked = true;
                ((CheckBox)GridUserRight.Rows[i].Cells[5].FindControl("GrdViewRight")).Checked = true;
                ((CheckBox)GridUserRight.Rows[i].Cells[6].FindControl("GrdEditRight")).Checked = true;
                ((CheckBox)GridUserRight.Rows[i].Cells[7].FindControl("GrdDelRight")).Checked = true;
                ((CheckBox)GridUserRight.Rows[i].Cells[8].FindControl("GrdPrintRight")).Checked = true;
                // GridUserRight.Rows[i].BackColor = System.Drawing.Color.LightGray;
                GridUserRight.Rows[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#F2FFF8");
            }
        }
        else
        {
            for (int i = 0; i < GridUserRight.Rows.Count; i++)
            {
                ((CheckBox)GridUserRight.Rows[i].Cells[0].FindControl("GrdSelectAll")).Checked = false;
                ((CheckBox)GridUserRight.Rows[i].Cells[4].FindControl("GrdAddRight")).Checked = false;
                ((CheckBox)GridUserRight.Rows[i].Cells[5].FindControl("GrdViewRight")).Checked = false;
                ((CheckBox)GridUserRight.Rows[i].Cells[6].FindControl("GrdEditRight")).Checked = false;
                ((CheckBox)GridUserRight.Rows[i].Cells[7].FindControl("GrdDelRight")).Checked = false;
                ((CheckBox)GridUserRight.Rows[i].Cells[8].FindControl("GrdPrintRight")).Checked = false;
                GridUserRight.Rows[i].BackColor = System.Drawing.Color.White;
            }
        }

    }

    protected void GrdSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkSelectAll = (CheckBox)sender;
        GridViewRow dr = (GridViewRow)chkSelectAll.Parent.Parent;
        if (chkSelectAll.Checked == true)
        {
            ((CheckBox)dr.FindControl("GrdViewRight")).Checked = true;
            ((CheckBox)dr.FindControl("GrdAddRight")).Checked = true;
            ((CheckBox)dr.FindControl("GrdDelRight")).Checked = true;
            ((CheckBox)dr.FindControl("GrdEditRight")).Checked = true;
            ((CheckBox)dr.FindControl("GrdPrintRight")).Checked = true;
            //dr.BackColor = System.Drawing.Color.LightGray;
            dr.BackColor = System.Drawing.ColorTranslator.FromHtml("#F2FFF8");
            ((CheckBox)dr.FindControl("GrdDelRight")).Enabled = true;
            ((CheckBox)dr.FindControl("GrdEditRight")).Enabled = true;
            ((CheckBox)dr.FindControl("GrdPrintRight")).Enabled = true;
            chkSelectAll.Focus();
        }
        else
        {
            ((CheckBox)dr.FindControl("GrdViewRight")).Checked = false;
            ((CheckBox)dr.FindControl("GrdAddRight")).Checked = false;
            ((CheckBox)dr.FindControl("GrdDelRight")).Checked = false;
            ((CheckBox)dr.FindControl("GrdEditRight")).Checked = false;
            ((CheckBox)dr.FindControl("GrdPrintRight")).Checked = false;
            dr.BackColor = System.Drawing.Color.White;
            ((CheckBox)dr.FindControl("GrdDelRight")).Enabled = false;
            ((CheckBox)dr.FindControl("GrdEditRight")).Enabled = false;
            ((CheckBox)dr.FindControl("GrdPrintRight")).Enabled = false;
            //chkSelectAll.Focus();
        }
    }

    protected void GrdViewRight_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkViewRight = (CheckBox)sender;
        GridViewRow dr = (GridViewRow)chkViewRight.Parent.Parent;
        dr.Focus();
        if (chkViewRight.Checked == false)
        {
            ((CheckBox)dr.FindControl("GrdDelRight")).Checked = false;
            ((CheckBox)dr.FindControl("GrdEditRight")).Checked = false;
            ((CheckBox)dr.FindControl("GrdPrintRight")).Checked = false;
            ((CheckBox)dr.FindControl("GrdDelRight")).Enabled = false;
            ((CheckBox)dr.FindControl("GrdEditRight")).Enabled = false;
            ((CheckBox)dr.FindControl("GrdPrintRight")).Enabled = false;
        }
        else
        {
            ((CheckBox)dr.FindControl("GrdDelRight")).Enabled = true;
            ((CheckBox)dr.FindControl("GrdEditRight")).Enabled = true;
            ((CheckBox)dr.FindControl("GrdPrintRight")).Enabled = true;
        }
    }

    protected void RadioIsAdmin_SelectedIndexChanged(object sender, EventArgs e)
    {
        CheckBox GrdSelectAllHeader = ((CheckBox)GridUserRight.HeaderRow.FindControl("GrdSelectAllHeader"));
        try
        {
            if (RadioIsAdmin.Items[0].Selected)
            {
                GrdSelectAllHeader.Checked = true;
                for (int i = 0; i < GridUserRight.Rows.Count; i++)
                {
                    ((CheckBox)GridUserRight.Rows[i].Cells[0].FindControl("GrdSelectAll")).Checked = true;
                    ((CheckBox)GridUserRight.Rows[i].Cells[4].FindControl("GrdAddRight")).Checked = true;
                    ((CheckBox)GridUserRight.Rows[i].Cells[5].FindControl("GrdViewRight")).Checked = true;
                    ((CheckBox)GridUserRight.Rows[i].Cells[6].FindControl("GrdEditRight")).Checked = true;
                    ((CheckBox)GridUserRight.Rows[i].Cells[7].FindControl("GrdDelRight")).Checked = true;
                    ((CheckBox)GridUserRight.Rows[i].Cells[8].FindControl("GrdPrintRight")).Checked = true;
                    GridUserRight.Rows[i].BackColor = System.Drawing.Color.LightGray;
                    GridUserRight.Rows[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#F2FFF8");
                }
                PnlUserRight.Enabled = false;
                RadioIsAdmin.Enabled = true;
                RadioIsAdmin.Text = "T";
            }
            else
            {
                GrdSelectAllHeader.Checked = false;

                for (int i = 0; i < GridUserRight.Rows.Count; i++)
                {
                    ((CheckBox)GridUserRight.Rows[i].Cells[0].FindControl("GrdSelectAll")).Checked = false;
                    ((CheckBox)GridUserRight.Rows[i].Cells[4].FindControl("GrdAddRight")).Checked = false;
                    ((CheckBox)GridUserRight.Rows[i].Cells[5].FindControl("GrdViewRight")).Checked = false;
                    ((CheckBox)GridUserRight.Rows[i].Cells[6].FindControl("GrdEditRight")).Checked = false;
                    ((CheckBox)GridUserRight.Rows[i].Cells[7].FindControl("GrdDelRight")).Checked = false;
                    ((CheckBox)GridUserRight.Rows[i].Cells[8].FindControl("GrdPrintRight")).Checked = false;
                    GridUserRight.Rows[i].BackColor = System.Drawing.Color.White;
                }
                PnlUserRight.Enabled = true;
                RadioIsAdmin.Text = "F";
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
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
                            Ds = obj_DMUserMaster.GetUserDetailsForEdit(Convert.ToInt32(e.CommandArgument), out StrError);

                            if (Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                            {
                                txtUser.Text = Ds.Tables[0].Rows[0]["LoginName"].ToString();
                                TxtEmailid.Text = Ds.Tables[0].Rows[0]["EmailId"].ToString();
                              TxtUserName.Text = Ds.Tables[0].Rows[0]["UserName"].ToString();
                                txtpassword.Attributes["value"] = Ds.Tables[0].Rows[0]["Password"].ToString();
                                txtConfirmpassword.Attributes["value"] = Ds.Tables[0].Rows[0]["Password"].ToString();
                                //ddlEmployee.SelectedValue = Ds.Tables[0].Rows[0]["EmpID"].ToString();
                                string str;
                                str = Ds.Tables[0].Rows[0]["IsAdmin"].ToString();
                                if (str.Equals("True"))
                                {
                                    RadioIsAdmin.Text = "T";
                                    PnlUserRight.Enabled = false;
                                }
                                else
                                {
                                    RadioIsAdmin.Text = "F";
                                    PnlUserRight.Enabled = true;
                                }
                            }
                            if (Ds.Tables[1].Rows.Count > 0)
                            {
                                GridUserRight.DataSource = Ds.Tables[1];
                                GridUserRight.DataBind();
                                DisableCheckbox();
                            }
                            else
                            {
                                MakeEmptyform();
                            }
                            if (Ds.Tables[2].Rows.Count > 0)
                            {
                                //ChkProject.DataSource = Ds.Tables[2];
                                //ChkProject.DataValueField = "PCId";
                                //ChkProject.DataTextField = "Project";
                                //ChkProject.DataBind();
                                ViewState["IsCentral"] = Ds.Tables[2];

                                //for (int i = 0; i < ChkProject.Items.Count; i++)
                                //{
                                //    if (Convert.ToBoolean(Ds.Tables[2].Rows[i]["Cheked"]) == false)
                                //    {
                                //        ChkProject.Items[i].Selected = false;
                                //    }
                                //    else
                                //    {
                                //        ChkProject.Items[i].Selected = true;
                                //    }
                                //}
                            }
                            Ds = null;
                            obj_DMUserMaster = null;

                            if (!FlagEdit)
                                BtnUpdate.Visible = true;
                            if (!FlagDel)
                                BtnDelete.Visible = true;
                            BtnSave.Visible = false;
                            //TxtUserName.Focus();
                        }
                    }
                    break;
            }
        }
        catch (Exception ex)
        {
            StrError = ex.Message;
        }
       
    }

    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            int iDeleted = 0;
            if (ViewState["EditID"] != null)
            {
                iDeleted = Convert.ToInt32(ViewState["EditID"]);
            }
            if (iDeleted != 0)
            {
                Entity_UserMaster.UserID = iDeleted;
                Entity_UserMaster.DeletedBy = Convert.ToInt32(Session["UserID"]);
                Entity_UserMaster.DeletedDate = Convert.ToDateTime(DateTime.Today.ToString());

                iDeleted = obj_DMUserMaster.DeleteUserDetails(ref Entity_UserMaster, out StrError);
                if (iDeleted > 0)
                {
                    obj_Comman.ShowPopUpMsg("Record Deleted Successfully..!", this.Page);
                    MakeEmptyform();
                }
                else
                {
                    obj_Comman.ShowPopUpMsg("Entries present for this user.Cannot Delete Record..!", this.Page);
                }
            }
        }
        catch (Exception ex)
        {
            StrError = ex.Message;
        }
    }

    private bool Check()
    {

        DataSet DsChkDup = new DataSet();
        Flag = true;
        //if (ViewState["EditID"] != null)
        //    DsChkDup = obj_DMUserMaster.ChkDuplicate(Convert.ToInt32(ddlEmployee.SelectedValue), long.Parse(ViewState["EditID"].ToString()), out StrError);
        //else
        //    DsChkDup = obj_DMUserMaster.ChkDuplicate(Convert.ToInt32(ddlEmployee.SelectedValue), -1, out StrError);


        //if (DsChkDup.Tables.Count > 0)
        //{
        //    if (DsChkDup.Tables[0].Rows.Count > 0)
        //    {
        //        if (long.Parse(DsChkDup.Tables[0].Rows[0][0].ToString()) > 0)
        //        {
        //            Flag = false;
        //            obj_Comman.ShowPopUpMsg("User rights for "+ ddlEmployee.SelectedItem.Text + " already present", this.Page);
        //            ddlEmployee.SelectedValue = "0";
        //            txtUser.Text =TxtEmailid.Text= string.Empty;
        //            txtpassword.Attributes["value"] = "";
        //            txtConfirmpassword.Attributes["value"] = "";
        //            for (int i = 0; i < ChkProject.Items.Count; i++)
        //            {
        //                ChkProject.Items[i].Selected = false;
        //            }
        //        }


        //    }
        //}
        return Flag;
    }

    
}