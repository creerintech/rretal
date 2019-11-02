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

public partial class Masters_DashBoard : System.Web.UI.Page
{

    DMDashboard Obj_Call = new DMDashboard();
    DataSet DS = new DataSet();
    private string StrCondition = string.Empty;
    string StrError = string.Empty;   
    CommanFunction obj_Comman = new CommanFunction(); 

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DashBoardReportGrid(StrCondition);
        }
    }

    private void DashBoardReportGrid(string RepCondition)
    {
        try
        {
            DS = Obj_Call.GetDashBoard(RepCondition, out StrError);

            if (DS.Tables.Count > 0)
            {
                if (DS.Tables[0].Rows.Count > 0)
                {
                    GridReport.DataSource = DS.Tables[0];
                    GridReport.DataBind();
                }
                if (DS.Tables[1].Rows.Count > 0)
                {
                    GridReport1.DataSource = DS.Tables[1];
                    GridReport1.DataBind();
                }
                //if (DS.Tables[2].Rows.Count > 0)
                //{
                //    GridReport2.DataSource = DS.Tables[2];
                //    GridReport2.DataBind();
                //}
            }

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }
    
    protected void DownloadFile(object sender, EventArgs e)
    {
        try
        {
            LinkButton LB = (LinkButton)sender;
            int RowIndex = Convert.ToInt32(LB.CommandArgument);

            Response.Redirect("~/Transactions/PropertyMaintance.aspx?PropertyMaintenaceId=" + RowIndex + " ");
            Response.End();
        }
        catch (Exception ex)
        {
            obj_Comman.ShowPopUpMsg(ex.Message, this.Page);
        }
    }

    protected void DownloadFileProperty(object sender, EventArgs e)
    {
        try
        {
            LinkButton LB = (LinkButton)sender;
            int RowIndex = Convert.ToInt32(LB.CommandArgument);

            Response.Redirect("~/Masters/Property.aspx?PropertyId=" + RowIndex + " ");
            Response.End();
        }
        catch (Exception ex)
        {
            obj_Comman.ShowPopUpMsg(ex.Message, this.Page);
        }
    }

    protected void DownloadFileRent(object sender, EventArgs e)
    {
        try
        {
            LinkButton LB = (LinkButton)sender;
            int RowIndex = Convert.ToInt32(LB.CommandArgument);

            Response.Redirect("~/Masters/ProjectConfigurator1.aspx?PropertyRentCardId=" + RowIndex + " ");
            Response.End();
        }
        catch (Exception ex)
        {
            obj_Comman.ShowPopUpMsg(ex.Message, this.Page);
        }
    }

    protected void TxtSearch_TextChanged(object sender, EventArgs e)
    {
    //    StrCondition = TxtSearch.Text.Trim();
    //    StrCondition = StrCondition.Replace("[", @"\[");
    //    DashBoardReportGrid(StrCondition);
    }


    #region["Web Services"]
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionListParty(string prefixText, int count, string contextKey)
    {
        DMDashboard obj_PartyMaster = new DMDashboard();
        String[] SearchList = obj_PartyMaster.GetSuggestedRecordForProperty(prefixText);
        return SearchList;
    }
    #endregion
}
