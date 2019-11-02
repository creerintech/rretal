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
using System.Globalization;

public partial class Masters_DashboardSetting : System.Web.UI.Page
{
    #region[Private Variables]
    DMDashboard Obj_Call = new DMDashboard();
    FlatLayout Entity_Call = new FlatLayout();
    CommanFunction Obj_Comm = new CommanFunction();

    DataSet DS = new DataSet();
    private string StrError = string.Empty;
    private string StrCondition = string.Empty;
    private static bool FlagAdd = false, FlagDel = false, FlagEdit = false, FlagPrint = false;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {            
            MakeEmptyForm();
        }
    }

    private void MakeEmptyForm()
    {                    
        FillCombo();    
        ReportGrid(StrCondition);
        BtnSave.Visible = true;
       
    }


    private void FillCombo()
    {
        DS = Obj_Call.FillCombo(Convert.ToInt32(Session["EmpID"]), out StrError);
        if (DS.Tables.Count > 0)
        {
            if (DS.Tables[0].Rows.Count > 0)
            {
                ddlProject.DataSource = DS.Tables[0];
                ddlProject.DataTextField = "ProjectName";
                ddlProject.DataValueField = "PCId";
                ddlProject.DataBind();
            }
        }
    }


    protected void BtnSave_Click(object sender, EventArgs e)
    {
        int InsertRow = 0, DeleteRow=0;
        bool Flag = false;
        if (ddlProject.Items.Count == 0)
        {
            Obj_Comm.ShowPopUpMsg("Please Select Minimum One Project", this.Page);
            ddlProject.Focus();
            return;
        }
        else
        {
            for (int i = 0; i < ddlProject.Items.Count; i++)
            {
                if (ddlProject.Items[i].Selected)
                {
                    Flag = true;
                }
            }
            if (!Flag)
            {
                Obj_Comm.ShowPopUpMsg("Please Select Minimum One Project", this.Page);
                ddlProject.Focus();
                return;
            }
        }
        if (ViewState["Details"] != null)
        {
            DataTable Dt = (DataTable)ViewState["Details"] ;
            if (Dt.Rows.Count > 0)
            {
                DeleteRow = Obj_Call.DeleteRecord();
            }
         
        }
        foreach (System.Web.UI.WebControls.ListItem item in ddlProject.Items)
        {
            if (item.Selected)
            {
                Entity_Call.PCId = Convert.ToInt32(item.Value);
                Entity_Call.UserId = Convert.ToInt32(Session["UserId"]);
                Entity_Call.LoginDate = DateTime.Now;

                InsertRow = Obj_Call.InsertRecord(ref Entity_Call, out StrError);
            }
        }
        if (InsertRow > 0)
        {
            Obj_Comm.ShowPopUpMsg("Record Saved Successfully", this.Page);
            MakeEmptyForm();
            Entity_Call = null;
            Obj_Comm = null;
        }
    }

    private void ReportGrid(string RepCondition)
    {
        try
        {
            DS = Obj_Call.GetList(RepCondition, out StrError);
            ViewState["Details"] = DS.Tables[0];
            if (DS.Tables.Count > 0)
            {
                if (DS.Tables[0].Rows.Count > 0)
                {
                    for (int j = 0; j < ddlProject.Items.Count; j++)
                    {
                        for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                        {
                            if (ddlProject.Items[j].Value == DS.Tables[0].Rows[i]["PCId"].ToString())
                            {
                                ddlProject.Items[j].Selected = true;
                            }
                        }
                    }
                }
            
            }

            //Obj_Booking = null;
            DS = null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }
}
