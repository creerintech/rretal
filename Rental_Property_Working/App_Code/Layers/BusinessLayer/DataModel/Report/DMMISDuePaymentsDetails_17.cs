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
using System.Data.SqlClient;

using Build.Utility;
using Build.EntityClass;
using Build.DB;
using Build.DataModel;
using Build.DALSQLHelper;

/// <summary>
/// Summary description for DMMISDuePaymentsDetails_17
/// </summary>
/// 
namespace Build.DataModel
{
    public class DMMISDuePaymentsDetails_17 : Utility.Setting
    {
        public DataSet getBookindId(string RepCondition, out string StrError)
        {
            DataSet DS = new DataSet();
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(BookingMaster._Action, SqlDbType.BigInt);
                SqlParameter MRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

                pAction.Value = 1;
                MRepCondition.Value = RepCondition;

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_DuePaymentsDetails_17", pAction, MRepCondition);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return DS;
        }

        public DataSet FillCombo(out string StrError)
        {
            DataSet DS = new DataSet();
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);

                pAction.Value = 2;

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_DuePaymentsDetails_17", pAction);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return DS;
        }

        public DataSet GetCustPCwise(int ID, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pId = new SqlParameter("@PCId", SqlDbType.BigInt);

                pAction.Value = 3;
                pId.Value = ID;

                SqlParameter[] param = new SqlParameter[] { pAction, pId };
                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_DuePaymentsDetails_17", param);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

        public DataSet getDataValues(long ID, long PCId, DateTime TodayDate,out string StrError)
        {
            DataSet DS = new DataSet();
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(BookingMaster._Action, SqlDbType.BigInt);
                SqlParameter MBookingId = new SqlParameter("@BookingId", SqlDbType.BigInt);
                SqlParameter MPCId = new SqlParameter("@PCId", SqlDbType.BigInt);
                SqlParameter MDate = new SqlParameter("@Date",SqlDbType.DateTime);

                pAction.Value = 5;
                MBookingId.Value = ID;
                MPCId.Value = PCId;
                MDate.Value = TodayDate;

                SqlParameter[] param = new SqlParameter[] { pAction, MBookingId, MPCId ,MDate};
                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_DuePaymentsDetails_I_17", param);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return DS;
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

                pAction.Value = 103;
                pId.Value = str;
                pPCId.Value = PCId;

                SqlParameter[] param = new SqlParameter[] { pAction, pId, pPCId };
                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_DuePaymentsDetails_I_17", param);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public DataSet GetCustomer(int PCDetailsId, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pPCDetailId = new SqlParameter("@PCDetailId", SqlDbType.BigInt);

                pAction.Value = 106;
                pPCDetailId.Value = PCDetailsId;

                SqlParameter[] param = new SqlParameter[] { pAction, pPCDetailId };
                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_DuePaymentsDetails_I_17", param);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

        public DataSet GetBuilding(int ID, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pId = new SqlParameter("@PCId", SqlDbType.BigInt);

                pAction.Value = 102;
                pId.Value = ID;

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_DuePaymentsDetails_I_17", pAction, pId);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }
        
        public DMMISDuePaymentsDetails_17()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}