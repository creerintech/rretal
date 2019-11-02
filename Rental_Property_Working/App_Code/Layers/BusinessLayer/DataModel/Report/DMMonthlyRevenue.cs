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

namespace Build.DataModel
{
    public class DMMonthlyRevenue : Utility.Setting
    {
        public DataSet GetSalescompReport(string Fromdate, string Todate, string RepCondition, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter MRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);
                SqlParameter Mstart = new SqlParameter("@start", SqlDbType.DateTime);
                SqlParameter Mend = new SqlParameter("@end", SqlDbType.DateTime);

                MAction.Value = 1;
                MRepCondition.Value = RepCondition;
                Mstart.Value = Fromdate;
                Mend.Value = Todate;

                SqlParameter[] param = new SqlParameter[] { MAction, MRepCondition, Mstart, Mend };

                Open(Setting.CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_MonthlyRevenue", param);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

        public DataSet FillCombo(int EmpID, out string StrError)
        {
            DataSet DS = new DataSet();
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pEmpID = new SqlParameter("@EmpID", SqlDbType.BigInt);
                pAction.Value = 2;
                pEmpID.Value = EmpID;
                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_MonthlyRevenue", pAction, pEmpID);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return DS;
        }

        public DataSet FillTower(int PCId, out string StrError)
        {
            DataSet DS = new DataSet();
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pPCId = new SqlParameter("@PCId", SqlDbType.BigInt);
                pAction.Value = 3;
                pPCId.Value = PCId;
                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_MonthlyRevenue", pAction, pPCId);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return DS;
        }
        public DataSet FillCustomer(int PCId,string TowerName, out string StrError)
        {
            DataSet DS = new DataSet();
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pPCId = new SqlParameter("@PCId", SqlDbType.BigInt);
                SqlParameter pTowerName = new SqlParameter("@TowerName", SqlDbType.NVarChar);

                pAction.Value = 4;
                pPCId.Value = PCId;
                pTowerName.Value = TowerName;

                Open(CONNECTION_STRING);
                SqlParameter[] param = new SqlParameter[] { pAction,pPCId,pTowerName };
                DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_MonthlyRevenue",param);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return DS;
        }
        public DMMonthlyRevenue()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
