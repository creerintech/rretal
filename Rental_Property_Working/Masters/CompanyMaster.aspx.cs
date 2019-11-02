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
using Build.DALSQLHelper;
using Build.DataModel;


public partial class Masters_CompanyMaster : System.Web.UI.Page
{
    #region[Variables]
    DMCompanyMaster Obj_CM = new DMCompanyMaster();
    CompanyMaster Entity_CM = new CompanyMaster();
    CommanFunction obj_Comm = new CommanFunction();
    DataSet DS = new DataSet();
    private string StrCondition = string.Empty;
    private string StrError = string.Empty;
    private static bool FlagAdd, FlagDel, FlagEdit = false;
    #endregion

    #region[UserDefine Function]

    private void MakeEmptyForm()
    {
        TxtCompanyName.Focus();
        if (!FlagAdd)
            BtnSave.Visible = true;
        BtnUpdate.Visible = false;
        BtnDelete.Visible = false;
        TxtCompanyName.Text = string.Empty;
        Txtabbreviations.Text = string.Empty;
        TxtAddress.Text = string.Empty;
        TxtPhoneNo.Text = string.Empty;
        TxtEmail.Text = string.Empty;
        TxtWebsite.Text = string.Empty;
        TxtFaxNo.Text = string.Empty;
        TxtTinNo.Text = string.Empty;
        TxtVatNo.Text = string.Empty;
        TxtServiceTaxNo.Text = string.Empty;
        TxtNoteC.Text = string.Empty;

        TxtSearch.Text = string.Empty;


        ReportGrid(StrCondition);
    }






    public void ReportGrid(string RepCondition)
    {
        try
        {
            DS = Obj_CM.GetCompanyDtls(RepCondition, out StrError);
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
            Obj_CM = null;
            DS = null;
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }

    private bool ChkDetails()
    {
        bool flag = false;
        try
        {

            flag = true;
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
        return flag;
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //CheckUserRight();

            MakeEmptyForm();
        }
    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        DMCompanyMaster Obj_CM = new DMCompanyMaster();
        String[] SearchList = Obj_CM.GetSuggestRecord(prefixText);
        return SearchList;
    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {

        MakeEmptyForm();
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        int InsertRow = 0, InsertRowDtls = 0;
        try
        {
            if (ChkDetails() == true)
            {
                DS = Obj_CM.ChkDuplicate(TxtCompanyName.Text.Trim(), out StrError);
                if (DS.Tables[0].Rows.Count > 0)
                {
                    obj_Comm.ShowPopUpMsg("Record is Already Present..", this.Page);
                    TxtCompanyName.Focus();
                }
                else
                {
                    Entity_CM.CompanyName = TxtCompanyName.Text;
                    Entity_CM.abbreviation = Txtabbreviations.Text;
                    Entity_CM.CAddress = TxtAddress.Text;

                    Entity_CM.PhoneNo = TxtPhoneNo.Text.Trim();
                    Entity_CM.EmailId = TxtEmail.Text.Trim();
                    Entity_CM.Website = TxtWebsite.Text.Trim();
                    Entity_CM.FaxNo = TxtFaxNo.Text.Trim();
                    Entity_CM.TinNo = TxtTinNo.Text.Trim();
                    Entity_CM.VatNo = TxtVatNo.Text.Trim();
                    Entity_CM.ServiceTaxNo = TxtServiceTaxNo.Text.Trim();
                    Entity_CM.Note = TxtNoteC.Text.Trim();

                    Entity_CM.UserId = Convert.ToInt32(Session["UserId"]);
                    Entity_CM.LoginDate = DateTime.Now;

                    InsertRow = Obj_CM.InsertRecord(ref Entity_CM, out StrError);

                    if (InsertRow > 0)
                    {

                        obj_Comm.ShowPopUpMsg("Record Saved Successfully", this.Page);

                        MakeEmptyForm();
                        Entity_CM = null;
                        Obj_CM = null;

                    }
                }
            }
            else
            {
                obj_Comm.ShowPopUpMsg("Please Enter Details ..!", this.Page);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {

        int UpdateRow = 0, InsertRowDtls = 0;
        try
        {
            if (ChkDetails() == true)
            {

                if (ViewState["EditID"] != null)
                {
                    Entity_CM.CompanyId = Convert.ToInt32(ViewState["EditID"]);
                }
                Entity_CM.CompanyName = TxtCompanyName.Text;
                Entity_CM.abbreviation = Txtabbreviations.Text;
                Entity_CM.CAddress = TxtAddress.Text;

                Entity_CM.PhoneNo = TxtPhoneNo.Text.Trim();
                Entity_CM.EmailId = TxtEmail.Text.Trim();
                Entity_CM.Website = TxtWebsite.Text.Trim();
                Entity_CM.FaxNo = TxtFaxNo.Text.Trim();
                Entity_CM.TinNo = TxtTinNo.Text.Trim();
                Entity_CM.VatNo = TxtVatNo.Text.Trim();
                Entity_CM.ServiceTaxNo = TxtServiceTaxNo.Text.Trim();

                Entity_CM.Note = TxtNoteC.Text.Trim();
                Entity_CM.UserId = Convert.ToInt32(Session["UserId"]);
                Entity_CM.LoginDate = DateTime.Now;

                UpdateRow = Obj_CM.UpdateRecord(ref Entity_CM, out StrError);

                if (UpdateRow > 0)
                {

                    obj_Comm.ShowPopUpMsg("Record Updated Successfully", this.Page);

                    MakeEmptyForm();
                    Entity_CM = null;
                    Obj_CM = null;
                }


            }
            else
            {
                obj_Comm.ShowPopUpMsg("Please Enter Details ..!", this.Page);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    protected void TxtSearch_TextChanged(object sender, EventArgs e)
    {
        StrCondition = TxtSearch.Text.Trim();
        ReportGrid(StrCondition);
    }



    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        int DeleteId = 0;
        try
        {
            if (ViewState["EditID"] != null)
            {
                DeleteId = Convert.ToInt32(ViewState["EditID"]);
            }
            if (DeleteId != 0)
            {
                Entity_CM.CompanyId = DeleteId;
                Entity_CM.UserId = Convert.ToInt32(Session["UserID"]);
                Entity_CM.LoginDate = DateTime.Now;

                int iDelete = Obj_CM.DeleteRecord(ref Entity_CM, out StrError);
                if (iDelete != 0)
                {
                    obj_Comm.ShowPopUpMsg("Record Deleted Successfully..!", this.Page);
                    MakeEmptyForm();
                }
            }
            Entity_CM = null;
            Obj_CM = null;
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
            try
            {
                switch (e.CommandName)
                {
                    case ("Select"):
                        {
                            if (Convert.ToInt32(e.CommandArgument) != 0)
                            {
                                ViewState["EditID"] = Convert.ToInt32(e.CommandArgument);
                                DS = Obj_CM.GetCompanyForEdit(Convert.ToInt32(e.CommandArgument), out StrError);
                                if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
                                {
                                    TxtCompanyName.Text = DS.Tables[0].Rows[0]["CompanyName"].ToString();
                                    Txtabbreviations.Text = DS.Tables[0].Rows[0]["abbreviation"].ToString();
                                    TxtAddress.Text = DS.Tables[0].Rows[0]["CAddress"].ToString();

                                    TxtPhoneNo.Text = DS.Tables[0].Rows[0]["PhoneNo"].ToString();
                                    TxtEmail.Text = DS.Tables[0].Rows[0]["EmailId"].ToString();
                                    TxtWebsite.Text = DS.Tables[0].Rows[0]["Website"].ToString();
                                    TxtFaxNo.Text = DS.Tables[0].Rows[0]["FaxNo"].ToString();
                                    TxtTinNo.Text = DS.Tables[0].Rows[0]["TinNo"].ToString();
                                    TxtVatNo.Text = DS.Tables[0].Rows[0]["VatNo"].ToString();
                                    TxtServiceTaxNo.Text = DS.Tables[0].Rows[0]["ServiceTaxNo"].ToString();
                                    TxtNoteC.Text = DS.Tables[0].Rows[0]["Note"].ToString();
                                }
                                else
                                {
                                    MakeEmptyForm();
                                }

                                DS = null;
                                Obj_CM = null;
                                if (!FlagEdit)
                                    BtnUpdate.Visible = true;
                                BtnSave.Visible = false;
                                if (!FlagDel)
                                    BtnDelete.Visible = true;
                                TxtCompanyName.Focus();

                            }
                            break;
                        }
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

   
}
