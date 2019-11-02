using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;

using System.Data.SqlClient;
using Build.DALSQLHelper;
using Build.DB;
using Build.EntityClass;
using Build.Utility;

public class DMMISProjectWiseRevenue: Build.Utility.Setting
{
    public DataSet FillCombo(int EmpID, out string StrError)
    {
        DataSet DS = new DataSet();
        StrError = string.Empty;
        try
        {
            SqlParameter pAction = new SqlParameter(BookingMaster._Action, SqlDbType.BigInt);
            SqlParameter pEmpID = new SqlParameter(BookingMaster._EmpID, SqlDbType.BigInt);

            pAction.Value = 2;
            pEmpID.Value = EmpID;

            Open(CONNECTION_STRING);
            DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_ProjectWiseRevenue", pAction, pEmpID);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return DS;
    }

    public DataSet GetProjectWiseRevenueReport(string RepCondition,int PCId, out string strError)
    {
        strError = string.Empty;
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);
            SqlParameter MRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);
            SqlParameter MPCId = new SqlParameter("@PCId", SqlDbType.NVarChar);
            MAction.Value = 1;
            MRepCondition.Value = RepCondition;
            MPCId.Value = PCId;
            SqlParameter[] param = { MAction, MRepCondition, MPCId };
            Open(Setting.CONNECTION_STRING);
            Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_ProjectWiseRevenue", param);

        }
        catch (Exception ex)
        {
            strError = ex.Message;
        }
        finally { Close(); }
        return Ds;

    }

    public DataSet DemandFillCombo(int EmpID, out string StrError)
    {
        DataSet DS = new DataSet();
        StrError = string.Empty;
        try
        {
            SqlParameter pAction = new SqlParameter(BookingMaster._Action, SqlDbType.BigInt);
            SqlParameter pEmpID = new SqlParameter(BookingMaster._EmpID, SqlDbType.BigInt);

            pAction.Value = 1;
            pEmpID.Value = EmpID;

            Open(CONNECTION_STRING);
            DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_ProjectWiseDemand", pAction, pEmpID);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return DS;
    }

    public DataSet GetBuilding(int ID, out string strError)
    {
        strError = string.Empty;
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
            SqlParameter pId = new SqlParameter("@PCId", SqlDbType.BigInt);

            pAction.Value = 2;
            pId.Value = ID;

            Open(CONNECTION_STRING);
            Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_ProjectWiseDemand", pAction, pId);

        }
        catch (Exception ex)
        {
            strError = ex.Message;
        }
        finally { Close(); }
        return Ds;

    }

    public DataSet GetFlats(int PCId, string str, out string strError)
    {
        strError = string.Empty;
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);            
            SqlParameter pPCId = new SqlParameter("@PCId", SqlDbType.BigInt);
            SqlParameter pId = new SqlParameter("@Building", SqlDbType.NVarChar);

            pAction.Value = 3;
            pPCId.Value = PCId;
            pId.Value = str;           

            SqlParameter[] param = new SqlParameter[] { pAction,pPCId, pId };
            Open(CONNECTION_STRING);
            Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_ProjectWiseDemand", param);

        }
        catch (Exception ex)
        {
            strError = ex.Message;
        }
        finally { Close(); }
        return Ds;

    }

    public DataSet GetProjectWiseDemeandReport(string RepCondition, string RepCondition1, string RepCondition2, out string strError)
    {
        strError = string.Empty;
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);
            SqlParameter MRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);
            SqlParameter MRepCondition1 = new SqlParameter("@strCond1", SqlDbType.NVarChar);
            SqlParameter MRepCondition2 = new SqlParameter("@strCond2", SqlDbType.NVarChar);

            MAction.Value =4;
            MRepCondition.Value = RepCondition;
            MRepCondition1.Value = RepCondition1;
            MRepCondition2.Value = RepCondition2;

            SqlParameter[] param = { MAction, MRepCondition, MRepCondition1, MRepCondition2 };
            Open(Setting.CONNECTION_STRING);
            Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_ProjectWiseDemand", param);

        }
        catch (Exception ex)
        {
            strError = ex.Message;
        }
        finally { Close(); }
        return Ds;

    }

    public DataSet MonthWiseRevenueReport(string RepCondition, out string strError)
    {
        strError = string.Empty;
        DataSet Ds = new DataSet();
        try
        {
            SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);
            SqlParameter MRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

            MAction.Value = 2;
            MRepCondition.Value = RepCondition;

            SqlParameter[] param = { MAction, MRepCondition };
            Open(Setting.CONNECTION_STRING);
            Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_MonthWiseRevenueCollection", param);

        }
        catch (Exception ex)
        {
            strError = ex.Message;
        }
        finally { Close(); }
        return Ds;

    }
     

	public DMMISProjectWiseRevenue()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
