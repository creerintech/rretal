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
    public class DMMISRevenue :Utility.Setting
    {
        public DataSet FillCombo(int EmpID, out string StrError)
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
                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_Infrastructure", pAction, pEmpID);

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
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_Infrastructure", pAction, pId);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

        public DataSet GetFlats(string str, int PCId, int EmpID, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pId = new SqlParameter("@Building", SqlDbType.NVarChar);
                SqlParameter pPCId = new SqlParameter("@PCId", SqlDbType.BigInt);
                SqlParameter pEmpID = new SqlParameter(BookingMaster._EmpID, SqlDbType.BigInt);

                pAction.Value = 3;
                pId.Value = str;
                pPCId.Value = PCId;
                pEmpID.Value = EmpID;

                SqlParameter[] param = new SqlParameter[] { pAction, pId, pPCId,pEmpID};
                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_Infrastructure", param);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

        public DataSet GetFlatsWithoutEmp(string str, int PCId, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pId = new SqlParameter("@Building", SqlDbType.NVarChar);
                SqlParameter pPCId = new SqlParameter("@PCId", SqlDbType.BigInt);

                pAction.Value = 6;
                pId.Value = str;
                pPCId.Value = PCId;

                SqlParameter[] param = new SqlParameter[] { pAction, pId, pPCId };
                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_Infrastructure", param);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }


        public DataSet GetInfrastructureReport(string RepCondition, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter MRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);
                MAction.Value = 4;
                MRepCondition.Value = RepCondition;

                Open(Setting.CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_Infrastructure", MAction, MRepCondition);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

        public DataSet GetDetails(int ID, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pId = new SqlParameter("@BookingId", SqlDbType.BigInt);

                pAction.Value = 5;
                pId.Value = ID;

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_Infrastructure", pAction, pId);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }
        public DMMISRevenue()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
