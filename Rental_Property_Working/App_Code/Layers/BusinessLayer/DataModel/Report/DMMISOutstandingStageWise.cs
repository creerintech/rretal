using System;
using System.Data;
using System.Collections.Generic;
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

    public class DMMISOutstandingStageWise : Utility.Setting
    {
        public DataSet FillCombo(int EmpID, out string StrError)
        {
            DataSet DS = new DataSet();
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(BookingMaster._Action, SqlDbType.BigInt);
               // SqlParameter pEmpID = new SqlParameter(BookingMaster._EmpID, SqlDbType.BigInt);

                pAction.Value = 1;
                //pEmpID.Value = EmpID;

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_OutStandingStageWise", pAction);

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
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_OutStandingStageWise", pAction, pId);

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

                pAction.Value = 3;
                pId.Value = str;
                pPCId.Value = PCId;

                SqlParameter[] param = new SqlParameter[] { pAction, pId, pPCId };
                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_OutStandingStageWise", param);

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

                pAction.Value = 444;
                pId.Value = str;
                pPCId.Value = PCId;
                pEmpID.Value = EmpID;

                SqlParameter[] param = new SqlParameter[] { pAction, pId, pPCId, pEmpID };
                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_BookingForm", param);

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

                pAction.Value = 7;
                pPCDetailId.Value = PCDetailsId;

                SqlParameter[] param = new SqlParameter[] { pAction, pPCDetailId };
                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_OutStandingStageWise", param);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }
        public DataSet GetOutStandigStageWiseReport(string RepCondition, int EmpID, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter MEmpID = new SqlParameter("@EmpID", SqlDbType.BigInt);
                SqlParameter MRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

                MAction.Value = 10;
                MEmpID.Value = EmpID;
                MRepCondition.Value = RepCondition;

                Open(Setting.CONNECTION_STRING);
                SqlParameter[] param = new SqlParameter[] { MAction, MEmpID, MRepCondition };
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_BookingForm", param);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }
        public DataSet GetReceiptData(string StrCond, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                //SqlParameter pbookingId = new SqlParameter("@BookingId", SqlDbType.BigInt);
                //SqlParameter pPrjId = new SqlParameter("@PCId", SqlDbType.BigInt);
                SqlParameter pstrCond = new SqlParameter("@strCond", SqlDbType.NVarChar);

                pAction.Value = 5;
                //pPrjId.Value = pcID;
               // pbookingId.Value = bookingId;
                pstrCond.Value = StrCond;
                SqlParameter[] param = new SqlParameter[] { pAction, pstrCond };// pPrjId, pbookingId };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_OutStandingStageWise", param);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }
        public DataSet GetBookingId(int  customerId)
        {
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pCustId = new SqlParameter("@CustId", SqlDbType.BigInt);

                pAction.Value = 8;
                pCustId.Value = customerId;
                SqlParameter[] param = new SqlParameter[] { pAction, pCustId };// pPrjId, pbookingId };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_OutStandingStageWise", param);
            }
            catch (Exception ex)
            {
                
            }
            finally { Close(); }
            return Ds;
        }
        public DataSet GetProjectBookingId(int PCId)
        {
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pPCId = new SqlParameter("@PCId", SqlDbType.BigInt);

                pAction.Value = 8;
                pPCId.Value = pPCId;
                SqlParameter[] param = new SqlParameter[] { pAction, pPCId };// pPrjId, pbookingId };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_OutStandingStageWise", param);
            }
            catch (Exception ex)
            {

            }
            finally { Close(); }
            return Ds;
        }
        public DataSet GetDataForUnitHolderPrint(int bookingId, int pcID,string StrCond ,out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
               // SqlParameter pbookingId = new SqlParameter("@BookingId", SqlDbType.BigInt);
               // SqlParameter pPrjId = new SqlParameter("@PCId", SqlDbType.BigInt);
                SqlParameter pstrCond = new SqlParameter("@strCond", SqlDbType.NVarChar);

                pAction.Value =4;
                //pPrjId.Value = pcID;
              //  pbookingId.Value = bookingId;
                pstrCond.Value = StrCond;
                SqlParameter[] param = new SqlParameter[] { pAction, pstrCond };//pPrjId, pbookingId, 

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_OutStandingStageWise", param);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public DataSet GetLatestTaxDetails(int pcID, int BookingId,string applicableDate, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pApplDate = new SqlParameter("@ApplicableDate", SqlDbType.NVarChar);
                SqlParameter pPrjId = new SqlParameter("@PCId", SqlDbType.BigInt);
                SqlParameter pBookingId = new SqlParameter("@BookingId", SqlDbType.BigInt);
                pAction.Value = 2;
                pPrjId.Value = pcID;
                pApplDate.Value = applicableDate;
                pBookingId.Value = BookingId;
                SqlParameter[] param = new SqlParameter[] { pAction, pPrjId, pBookingId, pApplDate };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_UnitHolder_Print_I", param);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public DMMISOutstandingStageWise()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}