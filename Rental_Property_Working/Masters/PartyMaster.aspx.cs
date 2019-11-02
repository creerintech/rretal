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


public partial class Masters_PartyMaster : System.Web.UI.Page
{


    #region[Private Variables]
    DMPropertyPartyMaster Obj_PM = new DMPropertyPartyMaster();
    PropertyPartyMaster Entity_PM = new PropertyPartyMaster();
    CommanFunction Obj_Comm = new CommanFunction();
    DataSet DS = new DataSet();
    private bool Flag = true;
    private string StrError = string.Empty;
    private string StrCondition = string.Empty;
    private static bool FlagAdd = false, FlagDel = false, FlagEdit = false;
    #endregion

    #region[UserDefinedFunction]
    //User Right Function===========
    //public void CheckUserRight()
    //{
    //    FlagAdd = FlagDel = FlagEdit = false;
    //    try
    //    {
    //        #region [USER RIGHT]
    //        //Checking Session Varialbels========
    //        if (Session["UserName"] != null && Session["UserRole"] != null)
    //        {
    //            //Checking User Role========
    //            //if (!Session["UserRole"].Equals("Administrator"))
    //            //{
    //            //Checking Right of users=======

    //            System.Data.DataSet dsChkUserRight = new System.Data.DataSet();
    //            System.Data.DataSet dsChkUserRight1 = new System.Data.DataSet();
    //            dsChkUserRight1 = (DataSet)Session["DataSet"];

    //            DataRow[] dtRow = dsChkUserRight1.Tables[1].Select("FormName ='Party Master'");
    //            if (dtRow.Length > 0)
    //            {
    //                DataTable dt = dtRow.CopyToDataTable();
    //                dsChkUserRight.Tables.Add(dt);// = dt.Copy();
    //            }
    //            if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["ViewAuth"].ToString()) == false && Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["AddAuth"].ToString()) == false &&
    //                Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["DelAuth"].ToString()) == false && Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["EditAuth"].ToString()) == false)
    //            {
    //                Response.Redirect("~/Masters/NotAuthUser.aspx");
    //            }
    //            //Checking View Right ========                    
    //            if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["ViewAuth"].ToString()) == false)
    //            {
    //                GrdReport.Visible = false;
    //            }
    //            //Checking Add Right ========                    
    //            if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["AddAuth"].ToString()) == false)
    //            {
    //                BtnSave.Visible = false;
    //                FlagAdd = true;

    //            }
    //            //Checking Print Right ========                    
    //            if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["PrintAuth"].ToString()) == false)
    //            {

    //            }
    //            //Edit /Delete Column Visible ========
    //            if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["DelAuth"].ToString()) == false && Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["EditAuth"].ToString()) == false)
    //            {
    //                BtnDelete.Visible = false;
    //                BtnUpdate.Visible = false;
    //                FlagDel = true;
    //                FlagEdit = true;
    //            }
    //            else
    //            {
    //                //Checking Delete Right ========
    //                if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["DelAuth"].ToString()) == false)
    //                {
    //                    BtnDelete.Visible = false;
    //                    FlagDel = true;
    //                }

    //                //Checking Edit Right ========
    //                if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["EditAuth"].ToString()) == false)
    //                {
    //                    BtnUpdate.Visible = false;
    //                    FlagEdit = true;
    //                }
    //            }
    //            dsChkUserRight.Dispose();
    //            // }
    //        }
    //        else
    //        {
    //            Response.Redirect("~/Default.aspx");
    //        }
    //        #endregion
    //    }
    //    catch (ThreadAbortException)
    //    {
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception(ex.Message);
    //    }
    //}
    //User Right Function===========
    private void MakeEmptyForm()
    {
        TxtPartyName.Focus();

        if (!FlagAdd)
            BtnSave.Visible = true;
        BtnUpdate.Visible = false;
        BtnDelete.Visible = false;
        BtnCancel.Visible = true;
        
        TxtPartyName.Text = string.Empty;
        TxtAddress.Text = string.Empty;      
        TxtPhoneNo.Text = string.Empty;
        TxtEmail.Text = string.Empty;
        TxtSearch.Text = string.Empty;
        TxtWebsite.Text = string.Empty;
        TxtNoteC.Text = string.Empty;
        txtContPerName.Text = string.Empty;
        txtContPerAddress.Text = string.Empty;
        txtContPerEId.Text = string.Empty;
        txtContPerTelNo.Text = string.Empty;
        txtContPerMobNo.Text = string.Empty;
        TxtGSTINNo.Text = string.Empty;
        TxtPANNo.Text = string.Empty;
        TxtAdharNo.Text = string.Empty;
        txtMobileNo.Text = string.Empty;
        //SetInitialRow();
       ReportGrid(StrCondition);

    }
   
    private void ReportGrid(string RepCondition)
    {
        try
        {
            DS = Obj_PM.GetProjectTypeList(RepCondition, out StrError);

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
            //Obj_PM = null;
            DS = null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }

    private bool Check()
    {

        DataSet Ds = new DataSet();
        Flag = true;
        if (ViewState["EditID"] != null)
            Ds = Obj_PM.ChkDuplicate(TxtPartyName.Text.Trim(), long.Parse(ViewState["EditID"].ToString()), out StrError);
        else
            Ds = Obj_PM.ChkDuplicate(TxtPartyName.Text.Trim(), -1, out StrError);


        if (Ds.Tables.Count > 0)
        {
            if (Ds.Tables[0].Rows.Count > 0)
            {
                if (long.Parse(Ds.Tables[0].Rows[0][0].ToString()) > 0)
                {
                    Flag = false;
                    Obj_Comm.ShowPopUpMsg("This Party Already Exist....!", this.Page);
                    TxtPartyName.Focus();
                }
            }
        }
        return Flag;
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            MakeEmptyForm();
            TxtPartyName.Focus();
        }
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        int InsertRow = 0;
        try
        {                        
            if (Check() == true)
            {                    
                Entity_PM.PartyName = TxtPartyName.Text.Trim();
                Entity_PM.PartyAddress = TxtAddress.Text.Trim();
                Entity_PM.PEmailId = TxtEmail.Text.Trim();
                Entity_PM.PTelNo = TxtPhoneNo.Text.Trim();
                Entity_PM.PmobileNo = txtMobileNo.Text.Trim();
                Entity_PM.PWebsite= TxtWebsite.Text.Trim();
                Entity_PM.ContPerName=txtContPerName.Text.Trim();
                Entity_PM.ContPerAddress=txtContPerAddress.Text.Trim();
                Entity_PM.CEmailId=txtContPerEId.Text.Trim();
                Entity_PM.CMobileNo = txtContPerMobNo.Text.Trim();
                Entity_PM.CAdharCardNo=TxtAdharNo.Text.Trim();
                Entity_PM.CTelNo = txtContPerTelNo.Text.Trim();
                Entity_PM.PANNO=TxtPANNo.Text.Trim();
                Entity_PM.GSTNo = TxtGSTINNo.Text.Trim();
                Entity_PM.Note = TxtNoteC.Text.Trim();

                Entity_PM.UserId = Convert.ToInt32(Session["UserId"]);
                Entity_PM.LoginDate = DateTime.Now;

                InsertRow = Obj_PM.InsertPartyMaster(ref Entity_PM, out StrError);
               
                if (InsertRow > 0)
                {
                    Obj_Comm.ShowPopUpMsg("Record Saved Successfully", this.Page);
                    MakeEmptyForm();
                    Entity_PM = null;
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
          int UpdateRow = 0;
          try
          {
              if (Check() == true)
              {
                  if (ViewState["EditID"] != null)
                  {
                      Entity_PM.PartyId = Convert.ToInt32(ViewState["EditID"]);
                  }

                  Entity_PM.PartyName = TxtPartyName.Text.Trim();
                  Entity_PM.PartyAddress = TxtAddress.Text.Trim();
                  Entity_PM.PEmailId = TxtEmail.Text.Trim();
                  Entity_PM.PTelNo = TxtPhoneNo.Text.Trim();
                  Entity_PM.PmobileNo = txtMobileNo.Text.Trim();
                  Entity_PM.PWebsite = TxtWebsite.Text.Trim();
                  Entity_PM.ContPerName = txtContPerName.Text.Trim();
                  Entity_PM.ContPerAddress = txtContPerAddress.Text.Trim();
                  Entity_PM.CEmailId = txtContPerEId.Text.Trim();
                  Entity_PM.CMobileNo = txtContPerMobNo.Text.Trim();
                  Entity_PM.CAdharCardNo = TxtAdharNo.Text.Trim();
                  Entity_PM.CTelNo = txtContPerTelNo.Text.Trim();
                  Entity_PM.PANNO = TxtPANNo.Text.Trim();
                  Entity_PM.GSTNo = TxtGSTINNo.Text.Trim();
                  Entity_PM.Note = TxtNoteC.Text.Trim();
                
                  Entity_PM.UserId = Convert.ToInt32(Session["UserId"]);
                  Entity_PM.LoginDate = DateTime.Now;

                  UpdateRow = Obj_PM.UpdatePartyMaster(ref Entity_PM, out StrError);

                  if (UpdateRow != 0)
                  {
                      Obj_Comm.ShowPopUpMsg("Record Updated Successfully", this.Page);
                      MakeEmptyForm();
                      Entity_PM = null;
                      Obj_Comm = null;
                  }
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
                           

                            DS = Obj_PM.GetPartyMaster(Convert.ToInt32(e.CommandArgument), out StrError);

                            if (DS.Tables.Count > 0)
                            {
                                if (DS.Tables[0].Rows.Count > 0)
                                {

                                    TxtPartyName.Text = DS.Tables[0].Rows[0]["PartyName"].ToString();
                                    TxtAddress.Text = DS.Tables[0].Rows[0]["PartyAddress"].ToString();
                                    TxtEmail.Text = DS.Tables[0].Rows[0]["PEmailId"].ToString();
                                    txtMobileNo.Text = DS.Tables[0].Rows[0]["PmobileNo"].ToString();
                                    TxtPhoneNo.Text = DS.Tables[0].Rows[0]["PTelNo"].ToString();
                                    TxtWebsite.Text = DS.Tables[0].Rows[0]["PWebsite"].ToString();
                                    txtContPerName.Text = DS.Tables[0].Rows[0]["ContPerName"].ToString();
                                    txtContPerAddress.Text = DS.Tables[0].Rows[0]["ContPerAddress"].ToString();
                                    txtContPerEId.Text = DS.Tables[0].Rows[0]["CEmailId"].ToString();
                                    txtContPerMobNo.Text = DS.Tables[0].Rows[0]["CMobileNo"].ToString();
                                    txtContPerTelNo.Text = DS.Tables[0].Rows[0]["CTelNo"].ToString();
                                    TxtGSTINNo.Text = DS.Tables[0].Rows[0]["GSTNo"].ToString();
                                    TxtPANNo.Text = DS.Tables[0].Rows[0]["PANNO"].ToString();
                                    TxtAdharNo.Text = DS.Tables[0].Rows[0]["CAdharCardNo"].ToString();
                                    TxtNoteC.Text = DS.Tables[0].Rows[0]["Note"].ToString();

                                }
                                else
                                {
                                    MakeEmptyForm();
                                }
                                
                            }
                            DS = null;
                            Obj_PM = null;
                            BtnSave.Visible = false;
                            if (!FlagEdit)
                                BtnUpdate.Visible = true;
                            if (!FlagDel)
                                BtnDelete.Visible = true;
                            TxtPartyName.Focus();
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
                int DeleteId = 0;
                if (ViewState["EditID"] != null)
                {                    
                    DeleteId = Convert.ToInt32(ViewState["EditID"]);
                }
                if (DeleteId != 0)
                {
                    Entity_PM.PartyId = DeleteId;
                    Entity_PM.UserId = Convert.ToInt32(Session["UserId"]);
                    Entity_PM.LoginDate = DateTime.Now;
                    int iDelete = Obj_PM.DeletePartyMaster(ref Entity_PM, out StrError);
                    if (iDelete != 0)
                    {
                        Obj_Comm.ShowPopUpMsg("Record Deleted Successfully..!", this.Page);
                        MakeEmptyForm();
                    }

                }
                Entity_PM = null;
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
        StrCondition = StrCondition.Replace("[", @"\[");
        ReportGrid(StrCondition);
    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]

    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        DMPropertyPartyMaster Obj_PM = new DMPropertyPartyMaster();
        string[] SearchList = Obj_PM.GetSuggestRecord(prefixText);
        return SearchList;
    }
}
