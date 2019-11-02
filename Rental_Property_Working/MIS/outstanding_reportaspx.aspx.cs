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

using Build.DataModel;
using Build.EntityClass;
using Build.Utility;
using System;
using System.Threading;
using System.Globalization;

public partial class MIS_outstanding_reportaspx : System.Web.UI.Page
{

    #region[Private Variables]

    DMReport Obj_ProptyRent = new DMReport();
    PropertyMaster Entity_PM = new PropertyMaster();
    CommanFunction Obj_Comm = new CommanFunction();
    DataSet DS = new DataSet();
    DataSet Dsa = new DataSet();
    private bool Flag = true;
    private string StrError = string.Empty;

    private string StrCondition = string.Empty;
    private string StrConditionFilters = string.Empty;
    private static bool FlagAdd = false, FlagDel = false, FlagEdit = false;
    private int FileId = 0;
    decimal FooterAmount = 0;
    #endregion

    #region["Web Services"]
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetAllProjectName(string prefixText, int count, string contextKey)
    {
        DMProperty obj_PM = new DMProperty();
        String[] SearchList = obj_PM.GetSuggestedAllProjectName(prefixText);
        return SearchList;
    }
    #endregion

    #region["Web Services"]
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetAllPartyName(string prefixText, int count, string contextKey)
    {
        DMReport obj_PM = new DMReport();
        String[] SearchList = obj_PM.GetSuggestedAllPartyName(prefixText);
        return SearchList;
    }
    #endregion
    database db = new database();
    string newString = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            MakeEmptyForm();
            chkmonth.Checked = true;
        }
    }





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

                DataRow[] dtRow = dsChkUserRight1.Tables[1].Select("FormName ='CheckAllDocumnentStatus'");
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
                    GrdProjectReport.Visible = false;
                    GrdProjectReport.Visible = false;
                }
                //Checking Add Right ========                    
                //if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["AddAuth"].ToString()) == false)
                //{
                //    BtnSave.Visible = false;
                //    FlagAdd = true;

                //}
                ////Checking Print Right ========                    
                //if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["PrintAuth"].ToString()) == false)
                //{

                //}
                ////Edit /Delete Column Visible ========
                //if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["DelAuth"].ToString()) == false && Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["EditAuth"].ToString()) == false)
                //{
                //    BtnDelete.Visible = false;
                //    BtnUpdate.Visible = false;
                //    FlagDel = true;
                //    FlagEdit = true;
                //}
                //else
                //{
                //    //Checking Delete Right ========
                //    if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["DelAuth"].ToString()) == false)
                //    {
                //        BtnDelete.Visible = false;
                //        FlagDel = true;
                //    }

                //    //Checking Edit Right ========
                //    if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["EditAuth"].ToString()) == false)
                //    {
                //        BtnUpdate.Visible = false;
                //        FlagEdit = true;
                //    }
                //}
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

        txtProperty.Text = string.Empty;
        TxtParty.Text = string.Empty;
        txtformonth.Text = DateTime.Now.ToString("MM/dd/yyy");


        
        ViewState["Summary"] = null;
    

    }













    void select_qry()
    {
        try
        {
            int flag = 0;



            
            string qry = "Select   SrNo = ROW_NUMBER() OVER (ORDER BY PM.Property )  , PM.Property  +' '+ UnitNo as 'Property Name' ,PMM.PartyName as 'Party Name' ,case when IsGenerated=0 then 'UnPaid' end as Status ,PRD.Amount as Rent,Convert(nvarchar,PRD.FromDate,106) as 'Rental From',Convert(Nvarchar,PRD.ToDate,106) as 'Rental Up To',PMP.FortheMonthYear,PMP.RentalAmount  from  Property_RentCard PR	inner join   PropertyRentDetails PRD	On PR.PropertyRentCardId=PRD.PropertyRentCardId	inner join PropertyMonthMapping PMP	on PMP.ProRentDtlsId=PRD.ProRentDtlsId	inner join PropertyMaster PM	on PR.PropertyId=PM.PropertyId	inner join PartyMaster PMM	on PMM.PartyId=PR.PartyId		Where PR.Isdeleted=0 and PMP.IsGenerated=0    and   ";
            if (chkmonth.Checked == true)
            {


               
                qry += "Convert(datetime,'01/' + FortheMonthYear,103) <='"+ txtformonth.Text + "' ";
                flag++;
            }

            if (TxtParty.Text!="")
            {

                if (flag != 0)
                    qry += "and ";
                int PartyId = Convert.ToInt32(hdvSerchParty.Value);
                qry += " (PMM.PartyId='" + PartyId + "')";
                flag++;
            }

            if (txtProperty.Text!= "")
            {
                if (flag != 0)
                    qry += "and ";
                int propId = Convert.ToInt32(hdvSerchProj.Value);
             
                qry += " (PR.PropertyId='"+ propId + "' )";
                //qry += " date ='" + txttodate.Text + "'";
                flag++;
            }

            if (flag == 0)
                qry = "Select   SrNo = ROW_NUMBER() OVER (ORDER BY PM.Property )  , PM.Property  +' '+ UnitNo as 'Property Name' ,PMM.PartyName as 'Party Name' ,case when IsGenerated=0 then 'UnPaid' end as Status ,PRD.Amount as Rent,Convert(nvarchar,PRD.FromDate,106) as 'Rental From',Convert(Nvarchar,PRD.ToDate,106) as 'Rental Up To',PMP.FortheMonthYear,PMP.RemaingAmount  from  Property_RentCard PR	inner join   PropertyRentDetails PRD	On PR.PropertyRentCardId=PRD.PropertyRentCardId	inner join PropertyMonthMapping PMP	on PMP.ProRentDtlsId=PRD.ProRentDtlsId	inner join PropertyMaster PM	on PR.PropertyId=PM.PropertyId	inner join PartyMaster PMM	on PMM.PartyId=PR.PartyId	inner join FlatTypeMaster FTM	on FTM.FlatTypeId=PR.FlatTypeId	Where PR.Isdeleted=0 and PMP.IsGenerated=0   ";

            GrdProjectReport.DataSource = db.Displaygrid(qry);
            GrdProjectReport.DataBind();
            ViewState["Summary"]= db.Displaygrid(qry);
        }
        catch (Exception ex)
        {
        }
    }


























    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {


            select_qry();


        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg(ex.Message, this.Page);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        MakeEmptyForm();
    }

    protected void BtnExportDetail_Click(object sender, EventArgs e)
    {
        if (ViewState["Summary"] != null)
        {
            DataTable DtGrd = (DataTable)ViewState["Summary"];
            string PURINVNO = string.Empty;
            if (DtGrd.Rows.Count > 0)
            {
                GridView GridExp = new GridView();
                GridExp.DataSource = DtGrd;
                GridExp.DataBind();
                Obj_Comm.Export("Outstanding_Receivable.xls", GridExp);
            }
            else
            {
                Obj_Comm.ShowPopUpMsg("No Data Found To Export..!", this.Page);
                GrdProjectReport.DataSource = null;
                GrdProjectReport.DataBind();
            }
        }
        else
        {
            Obj_Comm.ShowPopUpMsg("No Data Found To Export..!", this.Page);
        
        }
    }


    protected void GrdProjectReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
    }

    protected void chkmonth_CheckedChanged(object sender, EventArgs e)
    {

    }
}