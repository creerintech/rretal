using System;
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
using System.Data;
using System.Data.SqlClient;
using Build.DALSQLHelper;
using Build.DB;
using Build.EntityClass;
using Build.Utility;

namespace Build.DataModel
{

    public class DMMISDuePayment : Utility.Setting
    {

        public DataSet GetData(string StrCond, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pstrCond = new SqlParameter("@strCond", SqlDbType.NVarChar);

                pAction.Value = 1;
                pstrCond.Value = StrCond;
                SqlParameter[] param = new SqlParameter[] { pAction, pstrCond };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_DuePayments", param);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }
        public DataSet GetReceiptData(string strCond,out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pId = new SqlParameter("@strCond", SqlDbType.NVarChar);

                pAction.Value =2;

                pId.Value = strCond;
                SqlParameter[] param = new SqlParameter[] { pAction, pId };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_DuePayments", param);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }
        public DataSet FillCombo(out string StrError)
        {
            DataSet DS = new DataSet();
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(BookingMaster._Action, SqlDbType.BigInt);
                pAction.Value = 4;
                
                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_DuePayments", pAction);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return DS;
        }
        public DataSet FillTower(int PCId,out string StrError)
        {
            DataSet DS = new DataSet();
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(BookingMaster._Action, SqlDbType.BigInt);
                SqlParameter pPCId = new SqlParameter(BookingMaster._PCId, SqlDbType.BigInt);
                pAction.Value = 5;
                pPCId.Value = PCId;

                SqlParameter[] param = new SqlParameter[] { pAction, pPCId };
                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_DuePayments", param);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return DS;
        }
        public DataSet FillCust(int PCId,string Building, out string StrError)
        {
            DataSet DS = new DataSet();
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(BookingMaster._Action, SqlDbType.BigInt);
                SqlParameter pPCId = new SqlParameter(BookingMaster._PCId, SqlDbType.BigInt);
                SqlParameter pBuilding= new SqlParameter(BookingMaster._Building, SqlDbType.NVarChar);
                pAction.Value = 6;
                pPCId.Value = PCId;
                pBuilding.Value = Building;

                SqlParameter[] param = new SqlParameter[] { pAction, pBuilding, pPCId };
                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_DuePayments", param);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return DS;
        }
        public DataSet GetLatestTaxDetails(int pcID, string applicableDate, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pApplDate = new SqlParameter("@ApplicableDate", SqlDbType.NVarChar);
                SqlParameter pPrjId = new SqlParameter("@PCId", SqlDbType.BigInt);

                pAction.Value = 2;
                pPrjId.Value = pcID;
                pApplDate.Value = applicableDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pPrjId, pApplDate };

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
        public DataSet GetLatestTaxDetails(int pcID, int BookingId, string applicableDate, out string strError)
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
        public DataSet GetReceiptData1(string StrCond, out string strError)
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
        public DataSet GetDuePaymentRport(long pcid, string strBookingDueDate, long bookingid,string building ,out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pPCId = new SqlParameter("@PCId", SqlDbType.BigInt);
                SqlParameter pbookingId = new SqlParameter("@BookingId", SqlDbType.BigInt);
                SqlParameter pstrDueDate = new SqlParameter("@strBookingDueDate", SqlDbType.NVarChar);
                SqlParameter pBuilding = new SqlParameter("@Building", SqlDbType.NVarChar);
                pAction.Value = 3;
                pPCId.Value = pcid;
                pbookingId.Value = bookingid;
                pstrDueDate.Value = strBookingDueDate;
                pBuilding.Value = building;
                SqlParameter[] param = new SqlParameter[] { pAction, pPCId, pbookingId, pstrDueDate, pBuilding };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_DuePayments", param);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        
        }
        public DMMISDuePayment()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}