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

public partial class MIS_RptListOfProperty : System.Web.UI.Page
{
    #region[Private Variables]

    DMProperty Obj_Property = new DMProperty();
    PropertyMaster Entity_PM = new PropertyMaster();
    CommanFunction Obj_Comm = new CommanFunction();
    DataSet DS = new DataSet();
    DataSet Dsa = new DataSet();
    private bool Flag = true;
    private string StrError = string.Empty;
    
    private string StrCondition = string.Empty;
    public string StrCondition1 = string.Empty;
    private static bool FlagAdd = false, FlagDel = false, FlagEdit = false, FlagPrint=false;
    private int FileId = 0;
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

        ViewState["Summary"] = null;
        SetInitialRow();
      
        BtnPrint.Visible = false;
        BtnExportDetail.Visible = false;
       
    }

    public void ReportGridForProperty(int PropID)
    {
        try
        {
            GrdProjectDtls.Visible = true;
          
            DS = Obj_Property.FillCheckReportGridForProperty(PropID, out StrError);

            if (DS.Tables.Count > 0)
            {
                if (DS.Tables[0].Rows.Count > 0)
                {
                    GrdProjectDtls.DataSource = DS.Tables[0];
                    GrdProjectDtls.DataBind();
                    ViewState["Summary"] = DS.Tables[0];
                    if (!FlagPrint)
                    {
                        BtnPrint.Visible = true;
                        BtnExportDetail.Visible = true;
                    }
                }
                else
                {
                    GrdProjectDtls.DataSource = null;
                    GrdProjectDtls.DataBind();
                    ViewState["Summary"] = null;
                }
            }
            GrdProjectReport.Visible = false;
        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg(ex.Message, this.Page);
        }
    }

    public void ReportGrid1()
    {
        GrdProjectReport.Visible = true;
        try
        {
            DS = Obj_Property.FillReportInGrid1(out StrError);
           
            //--------------------Inword Grid Bind--------------------------------
            if (DS.Tables.Count > 0)
            {
                if (DS.Tables[0].Rows.Count > 0)
                {
                    GrdProjectReport.DataSource = DS.Tables[0];
                    GrdProjectReport.DataBind();
                    ViewState["Summary"] = DS.Tables[0];
                    if (!FlagPrint)
                    {
                        BtnPrint.Visible = true;
                        BtnExportDetail.Visible = true;
                    }
                }
            }
            else
            {
               
                GrdProjectReport.DataSource = null;
                GrdProjectReport.DataBind();
                ViewState["Summary"] = null;
            }
            GrdProjectDtls.Visible = false;
        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg(ex.Message, this.Page);
        }
    }

    private void SetInitialRow()
    {
        try
        {
            DataTable dt = new DataTable();

            DataRow dr = null;
            dt.Columns.Add("#", typeof(int));
            dt.Columns.Add("Property", typeof(string));
            dt.Columns.Add("PropertyId", typeof(Int32));
            dt.Columns.Add("PropertyAddress", typeof(string));
            dr = dt.NewRow();

            dr["#"] = 0;
            dr["Property"] = "";
            dr["PropertyId"] = 0;
            dr["PropertyAddress"] = "";

            dt.Rows.Add(dr);
            ViewState["CurrentTable"] = dt;
            GrdProjectReport.DataSource = dt;
            GrdProjectReport.DataBind();

        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg(ex.Message, this.Page);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            MakeEmptyForm();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
       if (Convert.ToString(txtProperty.Text) != "")
        {
            
            int propId = Convert.ToInt32(hdvSerchProj.Value);
           
            ReportGridForProperty(propId);
        }
        else
        {
           hdvSerchProj.Value = "0";

            ReportGrid1();
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
                Obj_Comm.Export("ListOfProperty.xls", GridExp);
            }
            else
            {
                Obj_Comm.ShowPopUpMsg("No Data Found To Export..!", this.Page);
                GrdProjectDtls.DataSource = null;
                GrdProjectDtls.DataBind();
                GrdProjectReport.DataSource = null;
                GrdProjectReport.DataBind();
            }
        }
        else
        {
            Obj_Comm.ShowPopUpMsg("No Data Found To Export..!", this.Page);
            SetInitialRow();
        }
    }

    protected void BtnPrint_Click(object sender, EventArgs e)
    {
        int propId = 0;
       
        string str = "PropertyDetails";
        string showAll = string.Empty;

        if (!string.IsNullOrEmpty(hdvSerchProj.Value))
        {
            propId = Convert.ToInt32(hdvSerchProj.Value);
        }

        else
        {
            propId = 0;
        }
        if (propId > 0)
            showAll = "1";
        else
            showAll = "0";
   
           Response.Redirect("PrintMIS.aspx?Cond=" + propId + " &Flag=" + str + " &ShowAll=" + showAll);

        Response.End();
    }

    protected void GrdProjectReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //StrCondition = TxtSearch.Text;
        GrdProjectReport.PageIndex = e.NewPageIndex;
        ReportGrid1();
    }
}
