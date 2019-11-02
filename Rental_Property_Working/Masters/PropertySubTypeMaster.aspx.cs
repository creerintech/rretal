﻿using System;
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

public partial class Masters_PropertySubTypeMaster : System.Web.UI.Page
{
    #region[Private variables]
    DMPropertySubTypeMaster Obj_PR = new DMPropertySubTypeMaster();
    PropertySubTypeMaster Entity_PR = new PropertySubTypeMaster();
    CommanFunction obj_Comm = new CommanFunction();
    DataSet DS = new DataSet();
    private string StrCondition = string.Empty;
    private string StrError = string.Empty;
    private static bool FlagAdd, FlagDel, FlagEdit = false;
    #endregion

    #region[UserDefine Function]
    private void MakeEmptyForm()
    {
        TxtPropertySubType.Focus();
        if (!FlagAdd)
            BtnSave.Visible = true;
        BtnUpdate.Visible = false;
        BtnDelete.Visible = false;
        ddlPropertyType.SelectedValue = "0";
        TxtPropertySubType.Text = string.Empty;
        TxtSearch.Text = string.Empty;
        BindCombo();
        ReportGrid(StrCondition);
    }

    public void BindCombo()
    {
        try
        {
            DS = Obj_PR.BindCombo(out StrError);
            {
                if (DS.Tables.Count > 0)
                { 
                if(DS.Tables[0].Rows.Count > 0)
                {
                    ddlPropertyType.DataSource = DS.Tables[0];
                    ddlPropertyType.DataTextField = "PropertyTypeDesc";
                    ddlPropertyType.DataValueField = "PropertyTypeId";
                    ddlPropertyType.DataBind();
                }
                }
            }
        }
        catch(Exception ex)
        {
            obj_Comm.ShowPopUpMsg(ex.Message,this.Page);
        }
    
    }

    public void ReportGrid(string RepCondition)
    {
        try
        {
            DS = Obj_PR.GetPropertySubType(RepCondition, out StrError);

            if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
            {
                GrdReport.DataSource = DS.Tables[0];
                GrdReport.DataBind();
            }
            else
            {
                GrdReport.DataSource = null;
                GrdReport.DataBind();
            }
            Obj_PR = null;
            DS = null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    private void GetEditRecord()
    {
        if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
        {
            TxtPropertySubType.Text = DS.Tables[0].Rows[0]["PropertySubTypeDesc"].ToString();
            ddlPropertyType.SelectedValue = DS.Tables[0].Rows[0]["PropertyTypeId"].ToString();
        }
        else
        {
            MakeEmptyForm();
        }
        DS = null;
        Obj_PR = null;
        if (!FlagEdit)
            BtnUpdate.Visible = true;
        BtnSave.Visible = false;
        if (!FlagDel)
            BtnDelete.Visible = true;
        TxtPropertySubType.Focus();
    }

   
    #endregion

    #region[Web Services]
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        DMPropertySubTypeMaster Obj_P = new DMPropertySubTypeMaster();
        string[] SearchList = Obj_P.GetSuggestRecord(prefixText);
        return SearchList;
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
       
            MakeEmptyForm();
        }
    }

   
    
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        int UpdateRow = 0;
        try
        {
            if (ViewState["EditID"] != null)
            {
                Entity_PR.PropertySubTypeId = Convert.ToInt32(ViewState["EditID"]);
            }
            Entity_PR.PropertySubTypeDesc= TxtPropertySubType.Text.Trim();

            if (Convert.ToInt32(ddlPropertyType.SelectedValue) > 0)
            {
                Entity_PR.PropertyTypeId = Convert.ToInt32(ddlPropertyType.SelectedValue);
            }
            else
            {
                obj_Comm.ShowPopUpMsg("Select ProprtyType First",this.Page);
                ddlPropertyType.Focus();
                return;            
            }
            Entity_PR.LoginId = Convert.ToInt32(Session["UserId"]);
            Entity_PR.LoginDate = DateTime.Now;
            UpdateRow = Obj_PR.UpdateRecord(ref Entity_PR, out StrError);
            if (UpdateRow != 0)
            {
                obj_Comm.ShowPopUpMsg("Record Updated Successfully", this.Page);
                MakeEmptyForm();
                Entity_PR = null;
                obj_Comm = null;
            }
        }

        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        int InsertRow = 0;
        try
        {
            DS = Obj_PR.ChkDuplicate(TxtPropertySubType.Text.Trim(), out StrError);
            if (DS.Tables[0].Rows.Count > 0)
            {
                obj_Comm.ShowPopUpMsg("PropertySubType Name Already Exist..!", this.Page);
                TxtPropertySubType.Focus();
            }
            else
            {
                Entity_PR.PropertySubTypeDesc= TxtPropertySubType.Text.Trim();

                if (Convert.ToInt32(ddlPropertyType.SelectedValue) > 0)
                {
                    Entity_PR.PropertyTypeId = Convert.ToInt32(ddlPropertyType.SelectedValue);
                }
                else
                {
                    obj_Comm.ShowPopUpMsg("Select PropertyType First..!",this.Page);
                    ddlPropertyType.Focus();
                    return;
                }
                Entity_PR.LoginId = Convert.ToInt32(Session["UserId"]);
                Entity_PR.LoginDate = DateTime.Now;
                InsertRow = Obj_PR.InsertRecord(ref Entity_PR, out StrError);

                if (InsertRow != 0)
                {
                    obj_Comm.ShowPopUpMsg("Record Saved Successfully", this.Page);
                    MakeEmptyForm();
                    Entity_PR = null;
                    obj_Comm = null;
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
            int DeleteId = 0;
            if (ViewState["EditID"] != null)
            {
                DeleteId = Convert.ToInt32(ViewState["EditID"]);
            }
            if (DeleteId != 0)
            {
                Entity_PR.PropertySubTypeId = DeleteId;
                Entity_PR.LoginId = Convert.ToInt32(Session["UserID"]);
                Entity_PR.LoginDate = DateTime.Now;
                int iDelete = Obj_PR.DeleteRecord(ref Entity_PR, out StrError);
                if (iDelete != 0)
                {
                    obj_Comm.ShowPopUpMsg("Record Deleted Successfully..!", this.Page);
                    MakeEmptyForm();
                }

            }
            Entity_PR = null;
            obj_Comm = null;
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
                            DS = Obj_PR.GetPropertySubTypeForEdit(Convert.ToInt32(e.CommandArgument), out StrError);
                            if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
                            {
                                TxtPropertySubType.Text = DS.Tables[0].Rows[0]["PropertySubTypeDesc"].ToString();
                                ddlPropertyType.SelectedValue = DS.Tables[0].Rows[0]["PropertyTypeId"].ToString();
                            }
                            else
                            {
                                MakeEmptyForm();
                            }
                            DS = null;
                            Obj_PR = null;
                            if (!FlagEdit)
                                BtnUpdate.Visible = true;
                            BtnSave.Visible = false;
                            if (!FlagDel)
                                BtnDelete.Visible = true;
                            TxtPropertySubType.Focus();
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

    protected void hdnValue_ValueChanged(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToInt32(((HiddenField)sender).Value) != 0)
            {
                ViewState["EditID"] = Convert.ToInt32(((HiddenField)sender).Value);
                DS = Obj_PR.GetPropertySubTypeForEdit(Convert.ToInt32(((HiddenField)sender).Value), out StrError);
                GetEditRecord();
            }
        }
        catch (Exception ex)
        {
            obj_Comm.ShowPopUpMsg(ex.Message, this.Page);
        }


        ///populate the form based on retrieved data
    }
}
