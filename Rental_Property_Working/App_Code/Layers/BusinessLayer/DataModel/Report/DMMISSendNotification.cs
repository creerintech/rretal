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
using Build.DALSQLHelper;
using Build.DB;
using Build.EntityClass;
using Build.Utility;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DMMISSendNotification
/// </summary>
namespace Build.DataModel
{
    public class DMMISSendNotification : Utility.Setting
    {

        public DataSet GetBookingStageBalancesDetails(long bookingId ,long pcid, string strDate, string ind, long userId, out string StrError)
        {
            DataSet DS = new DataSet();
            StrError = string.Empty;
            try
            {
               // SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pBkId= new SqlParameter("@BookingId", SqlDbType.BigInt);
                SqlParameter pPCId = new SqlParameter("@PCid", SqlDbType.BigInt);
                SqlParameter pdate = new SqlParameter("@Date", SqlDbType.VarChar);
                SqlParameter pUserId = new SqlParameter("@UserId", SqlDbType.BigInt);
                SqlParameter pInd = new SqlParameter("@DataInd", SqlDbType.NVarChar);

               // pAction.Value = 1;
                pPCId.Value = pcid;
                pdate.Value = strDate;
                pUserId.Value = userId;
                pInd.Value = "A";
                pBkId.Value = bookingId;
                SqlParameter[] param = new SqlParameter[] {pPCId,pdate,pUserId,pInd,pBkId };
                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_StageWise_Balances", param);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return DS;
        }

        public DataSet GetBookings(long pcid,out string StrError)
        {
            DataSet DS = new DataSet();
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pPCId = new SqlParameter("@PCid", SqlDbType.BigInt);
                pAction.Value = 1;
                pPCId.Value = pcid;
                
                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_SendNotification", pAction, pPCId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return DS;
        }

        public DataSet GetBuyerDetails(long pcid, out string StrError)
        {
            DataSet DS = new DataSet();
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pPCId = new SqlParameter("@PCid", SqlDbType.BigInt);
                pAction.Value = 2;
                pPCId.Value = pcid;

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_SendNotification", pAction, pPCId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return DS;
        }
        public DMMISSendNotification()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
