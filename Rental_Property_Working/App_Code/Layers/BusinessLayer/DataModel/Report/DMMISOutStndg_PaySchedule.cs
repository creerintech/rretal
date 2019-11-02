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

/// <summary>
/// Summary description for DMMISOutStndg_PaySchedule
/// </summary>
namespace Build.DataModel
{
    public class DMMISOutStndg_PaySchedule : Utility.Setting
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
                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_OutStndg_PaySchedule", pAction, pEmpID);

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
                //SqlParameter pPCId = new SqlParameter("@PCId", SqlDbType.BigInt);

                pAction.Value = 2;
                pId.Value = ID;
               // pPCId.Value = PCId;

                SqlParameter[] param = new SqlParameter[] { pAction, pId};
                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_OutStndg_PaySchedule", param);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

        public DataSet GetFlatsWithoutEmp(int PCId, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                //SqlParameter pId = new SqlParameter("@Building", SqlDbType.NVarChar);
                SqlParameter pPCId = new SqlParameter("@PCId", SqlDbType.BigInt);

                pAction.Value = 3;
              //  pId.Value = str;
                pPCId.Value = PCId;

                SqlParameter[] param = new SqlParameter[] { pAction, pPCId };
                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_OutStndg_PaySchedule", param);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

        public DataSet GetBookingReport(string RepCondition, out string strError)
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
                SqlParameter[] param = new SqlParameter[] { MAction,MRepCondition };
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_OutStndg_PaySchedule", param);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

        public DataSet GetRptrGrid(long BookingId,out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);
                //SqlParameter MRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);
                SqlParameter MBookingId = new SqlParameter("@BookingId", SqlDbType.BigInt);
                //SqlParameter MShedule = new SqlParameter("@schedule", SqlDbType.BigInt);
                //SqlParameter MPCDId = new SqlParameter("@PCId", SqlDbType.BigInt);
                //SqlParameter MBuilding = new SqlParameter("@Building", SqlDbType.NVarChar);

                MAction.Value =9;
                //MRepCondition.Value = RepCondition;
                MBookingId.Value = BookingId;
                //MShedule.Value = schedule;
                //MPCDId.Value = pcid;
                //MBuilding.Value = building;

                Open(Setting.CONNECTION_STRING);
                SqlParameter[] param = new SqlParameter[] { MAction,MBookingId};
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_OutStndg_PaySchedule", param);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public DataSet GetScheduleBookingId(string RepCondition, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter MRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

                MAction.Value = 6;
                MRepCondition.Value = RepCondition;

                Open(Setting.CONNECTION_STRING);
                SqlParameter[] param = new SqlParameter[] { MAction, MRepCondition };
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_OutStndg_PaySchedule", param);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public DataSet GetUnsolds(long PCId, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);
                //SqlParameter MBuilding = new SqlParameter("@Building", SqlDbType.NVarChar);
                SqlParameter MPCId = new SqlParameter("@PCId", SqlDbType.BigInt);

                MAction.Value = 10;
                //MBuilding.Value = Building;
                MPCId.Value = PCId;

                Open(Setting.CONNECTION_STRING);
                SqlParameter[] param = new SqlParameter[] { MAction, MPCId };
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_OutStndg_PaySchedule", param);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public DataSet GetRptrGridShedulewise(long BookingId,long schedule, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);
                //SqlParameter MRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);
                SqlParameter MBookingId = new SqlParameter("@BookingId", SqlDbType.BigInt);
                SqlParameter MShedule = new SqlParameter("@schedule", SqlDbType.BigInt);
                //SqlParameter MPCDId = new SqlParameter("@PCId", SqlDbType.BigInt);
                //SqlParameter MBuilding = new SqlParameter("@Building", SqlDbType.NVarChar);

                MAction.Value = 11;
                //MRepCondition.Value = RepCondition;
                MBookingId.Value = BookingId;
                MShedule.Value = schedule;
                //MPCDId.Value = pcid;
                //MBuilding.Value = building;

                Open(Setting.CONNECTION_STRING);
                SqlParameter[] param = new SqlParameter[] { MAction, MBookingId ,MShedule};
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_OutStndg_PaySchedule", param);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public DataSet GetScedulewiseBookingId(string Building, long PCId, long schedule, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter MBuilding = new SqlParameter("@Building", SqlDbType.NVarChar);
                SqlParameter MPCId = new SqlParameter("@PCId", SqlDbType.BigInt);
                SqlParameter MShedule = new SqlParameter("@schedule", SqlDbType.BigInt);

                MAction.Value = 12;
                MBuilding.Value = Building;
                MPCId.Value = PCId;
                MShedule.Value = schedule;

                Open(Setting.CONNECTION_STRING);
                SqlParameter[] param = new SqlParameter[] { MAction, MBuilding, MPCId ,MShedule};
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_OutStndg_PaySchedule", param);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public DataSet GetDatewise(string RepCondition, long schedule, string Building, long PCId, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);
                //SqlParameter MToDate = new SqlParameter("@ToDate", SqlDbType.DateTime);
                //SqlParameter MFromDate = new SqlParameter("@FromDate", SqlDbType.DateTime);
                //SqlParameter MShedule = new SqlParameter("@schedule", SqlDbType.BigInt);
                //SqlParameter MBuilding = new SqlParameter("@Building", SqlDbType.NVarChar);
                //SqlParameter MPCId = new SqlParameter("@PCId", SqlDbType.BigInt);
                SqlParameter MRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

                MAction.Value = 13;
                //MToDate.Value = ToDate;
                //MFromDate.Value = FromDate;
                //MShedule.Value = schedule;
                //MBuilding.Value = Building;
                //MPCId.Value = PCId;
                MRepCondition.Value = RepCondition;

                Open(Setting.CONNECTION_STRING);
                SqlParameter[] param = new SqlParameter[] { MAction, MRepCondition };
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_OutStndg_PaySchedule", param);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public DataSet GetPaySchedule(string RepCondition, out string StrError)
        {
            DataSet DS = new DataSet();
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(BookingMaster._Action, SqlDbType.BigInt);
                SqlParameter MRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

                pAction.Value = 14;
                MRepCondition.Value = RepCondition;

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_OutStndg_PaySchedule", pAction, MRepCondition);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return DS;
        }

        public DataSet GetDataBookingIdwise(long BookingId, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);
                //SqlParameter MRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);
                SqlParameter MBookingId = new SqlParameter("@BookingId", SqlDbType.BigInt);
                //SqlParameter MShedule = new SqlParameter("@schedule", SqlDbType.BigInt);
                //SqlParameter MPCDId = new SqlParameter("@PCId", SqlDbType.BigInt);
                //SqlParameter MBuilding = new SqlParameter("@Building", SqlDbType.NVarChar);

                MAction.Value = 15;
                //MRepCondition.Value = RepCondition;
                MBookingId.Value = BookingId;
                //MShedule.Value = schedule;
                //MPCDId.Value = pcid;
                //MBuilding.Value = building;

                Open(Setting.CONNECTION_STRING);
                SqlParameter[] param = new SqlParameter[] { MAction, MBookingId };
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_OutStndg_PaySchedule", param);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public DMMISOutStndg_PaySchedule()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}