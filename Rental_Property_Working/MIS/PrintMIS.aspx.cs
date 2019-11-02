using System;
using System.Collections;
using System.Collections.Generic;
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

using Build.BussinessLayer;
using Build.EntityClass;
using Build.Utility;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using Build.DataModel;

using CrystalDecisions.Web;
using System.IO;

public partial class Reports_PrintMIS : System.Web.UI.Page
{
    #region [Private Variable]
    DMProperty Obj_Property = new DMProperty();
    PropertyMaster Entity_PM = new PropertyMaster();
    DataSet DS = new DataSet();
    ReportDocument CRpt = new ReportDocument();      
    string Flag = string.Empty;
    string strError = string.Empty;
    string CheckCondition = "";
    string CheckConditionFilter = "";
    string FlagCheckCondition="";
    string InvFromDate = "";
    string PurToDate = "";
    string showallcust = "";
    #endregion

   
    protected void Page_Init(object sender, EventArgs e)
    {
        PrintMIS();
    }

    private void PrintMIS()
    {
        try
        {

            Flag = Convert.ToString(Request.QueryString["Flag"]).Trim();

            if (Flag.Contains("PropertyDetails"))
            {
            
                Flag = "PropertyDetails";
            }

            CheckCondition = Convert.ToString(Request.QueryString["Cond"]);

            int Cnds = Convert.ToInt32(Request.QueryString["Cond"]);

            switch (Flag)
            {
                case "PropertyDetails":
                    {
                        this.Page.Title = "Property Details";

                        showallcust = Convert.ToString(Request.QueryString["ShowAll"]).Trim();

                        if (showallcust == "1")
                        {
                            DS = Obj_Property.FillCheckReportGridForProperty(Cnds, out strError);
                        }
                        else
                        {
                            DS = Obj_Property.FillReportInGrid1(out strError);
                        }

                        if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
                        {
                           
                            DataColumn column = new DataColumn("FilterCondition");
                            column.DataType = typeof(string);
                            DS.Tables[0].Columns.Add("FilterCondition");
                         
                            DataColumn columnR = new DataColumn("RowCount");
                            columnR.DataType = typeof(string);
                            DS.Tables[0].Columns.Add("RowCount");
                         
                            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                            {
                                DS.Tables[0].Rows[i]["FilterCondition"] = CheckConditionFilter.ToString();
                                DS.Tables[0].Rows[i]["RowCount"] = DS.Tables[0].Rows.Count + " Record(s) Found!!";
                            }
                            if (showallcust == "1")
                            {
                                DS.Tables[0].TableName = "PropertyDtls";
                                CRpt.Load(Server.MapPath("~/MIS/CryPropertyDtls.rpt"));
                            }
                            else
                            {
                                DS.Tables[0].TableName = "PropertyDtls";
                                CRpt.Load(Server.MapPath("~/MIS/CryProperty.rpt"));
                            }

                            CRpt.SetDataSource(DS);
                            CRPrint.ReportSource = CRpt;
                            CRPrint.DataBind();
                            CRPrint.DisplayToolbar = true;
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
}
