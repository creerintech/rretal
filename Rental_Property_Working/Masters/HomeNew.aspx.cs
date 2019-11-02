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

public partial class Masters_HomeNew : System.Web.UI.Page
{
    DMGetTodayDeatils obj_Contra = new DMGetTodayDeatils();
    DMDashboard Obj_Call = new DMDashboard();

    DataSet DS = new DataSet();
    private string StrCondition = string.Empty;

    string StrError = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Convert.ToString(Session["UserRole"]) == "Administrator")
            {
                ddlEmp.Visible = true;
                Tr1.Visible = true;
                FillCombo();
                ReportGrid();
            }
            else
            {
                Tr1.Visible = false;
                ddlEmp.Visible = false;               
                ReportGrid();
            }
            DashBoardReportGrid(StrCondition);
        }
    }

    private void ReportGrid()
    {
        try
        {
            if (Session["UserRole"] == "Administrator")
            {
                DS = obj_Contra.BindList(out StrError);
            }
            else
            {
                DS = obj_Contra.BindTodayList(Convert.ToInt32(Session["EmpID"]), out StrError);                
            }

            if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
            {
                LstToday.DataSource = DS;
                LstToday.DataBind();
            }
            else
            {
                LstToday.DataSource = null;
                LstToday.DataBind();
            }
            //obj_PurchInv = null;
            //DS = null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }

    private void FillCombo()
    {
        DS = obj_Contra.FillCombo(out StrError);
        if (DS.Tables.Count > 0)
        {
            if (DS.Tables[0].Rows.Count > 0)
            {
                ddlEmp.DataSource = DS.Tables[0];
                ddlEmp.DataTextField = "Employee";
                ddlEmp.DataValueField = "EmpID";
                ddlEmp.DataBind();
            }
        }
    }
    protected void ddlEmp_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToInt32(ddlEmp.SelectedValue) > 0)
            {
                DS = obj_Contra.BindTodayList(Convert.ToInt32(ddlEmp.SelectedValue), out StrError);
                if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
                {
                    LstToday.DataSource = DS;
                    LstToday.DataBind();
                }
                else
                {
                    LstToday.DataSource = null;
                    LstToday.DataBind();
                }
            }
            else
            {
                DS = obj_Contra.BindList(out StrError);
                if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
                {
                    LstToday.DataSource = DS;
                    LstToday.DataBind();
                }
                else
                {
                    LstToday.DataSource = null;
                    LstToday.DataBind();
                }
            }
            
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
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
                if (DS.Tables[2].Rows.Count > 0)
                {
                    GridReport2.DataSource = DS.Tables[2];
                    GridReport2.DataBind();
                }
            }

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }
}
