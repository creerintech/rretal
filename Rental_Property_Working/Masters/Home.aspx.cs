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
public partial class Masters_Home : System.Web.UI.Page
{


    #region Private Variable
    DMHome obj_Home = new DMHome();
    DataSet DS = new DataSet();
    DMDashboard Obj_Call = new DMDashboard();
   
    private string StrCondition = string.Empty;
    string StrError = string.Empty;
    decimal SoldAV = 0, RecdAV = 0, BalAV = 0, DLW = 0, DTW = 0, TotalDue = 0, TotalRecd = 0, Balance = 0;
  
    #endregion

    #region UserDefined Function

    private void ReportGrid()
    {


        //DataSet ds = obj_Home.BindHoldFlats(out StrError);

        //if (ds.Tables.Count > 0)
        //{
        //    ViewState["ReportData"] = ds.Tables[0];
        //    GridReport.DataSource = ds.Tables[0];
        //    GridReport.DataBind();

        //}
    }
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        int UserId =Convert.ToInt32(Session["UserID"]);
        
        if (!Page.IsPostBack)
        {
            if (UserId == 0)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                //ReportGrid();
            }
           // DashBoardReportGrid(StrCondition);
        }
    }


    

   


    
}
