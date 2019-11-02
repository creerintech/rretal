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
/// Summary description for DMProjectWiseDetails
/// </summary>
namespace Build.DataModel
{
    public class DMProjectWiseDetails: Utility.Setting
    {
        public DataSet FillCombo(int EmpID, out string StrError)
        {
            DataSet DS = new DataSet();
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(ProjectWiseDetails._Action, SqlDbType.BigInt);
                SqlParameter pEmpID = new SqlParameter(ProjectWiseDetails._EmpID, SqlDbType.BigInt);

                pAction.Value = 1;
                pEmpID.Value = EmpID;
                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, ProjectWiseDetails.Pro_ProjectWiseDetails, pAction, pEmpID);

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
                SqlParameter pAction = new SqlParameter(ProjectWiseDetails._Action, SqlDbType.BigInt);
                SqlParameter pId = new SqlParameter("@PCId", SqlDbType.BigInt);

                pAction.Value = 2;
                pId.Value = ID;

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, ProjectWiseDetails.Pro_ProjectWiseDetails, pAction, pId);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

        public DataSet GetArea(int ID,string Building, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(ProjectWiseDetails._Action, SqlDbType.BigInt);
                SqlParameter pId = new SqlParameter("@PCId", SqlDbType.BigInt);
                SqlParameter pBuilding = new SqlParameter("@Building", SqlDbType.NVarChar);

                pAction.Value = 11;
                pId.Value = ID;
                pBuilding.Value = Building;
                SqlParameter[] param = new SqlParameter[] { pAction, pId, pBuilding };
                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, ProjectWiseDetails.Pro_ProjectWiseDetails, param);

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
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, ProjectWiseDetails.Pro_ProjectWiseDetails, param);

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

                pAction.Value = 4;
                pPCDetailId.Value = PCDetailsId;

                SqlParameter[] param = new SqlParameter[] { pAction, pPCDetailId };
                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure,ProjectWiseDetails.Pro_ProjectWiseDetails, param);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

        public DataSet GetDetailDataforProject(int pcid,long bookingid, out string strError)  //New
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                 SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter PCId = new SqlParameter("@PCId", SqlDbType.BigInt);
                SqlParameter BookingId = new SqlParameter("@BookingId", SqlDbType.BigInt);
               

                pAction.Value = 5;
                PCId.Value = pcid;
                BookingId.Value = bookingid;
              
            

                SqlParameter[] param = new SqlParameter[] { pAction, PCId,BookingId};

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure,"Pro_ProjectWiseDetails", param);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public DataSet GetDetailDataExcessAmt(int pcid, long bookingid, out string strError)  //New
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter PCId = new SqlParameter("@PCId", SqlDbType.BigInt);
                SqlParameter BookingId = new SqlParameter("@BookingId", SqlDbType.BigInt);


                pAction.Value = 10;
                PCId.Value = pcid;
                BookingId.Value = bookingid;



                SqlParameter[] param = new SqlParameter[] { pAction, PCId, BookingId };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "Pro_ProjectWiseDetails", param);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }
        public DataSet GetDetailDataforProject1(int pcid, out string strError)  //New
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter PCId = new SqlParameter("@PCId", SqlDbType.BigInt);
                


                pAction.Value = 9;
                PCId.Value = pcid;
          



                SqlParameter[] param = new SqlParameter[] { pAction, PCId };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "Pro_ProjectWiseDetails", param);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public DataSet GetDetailDataforAreawise(int Bookingid, out string strError)
        {
        strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pbookingId = new SqlParameter("@BookingId", SqlDbType.BigInt);
               

                pAction.Value = 8;
              
                pbookingId.Value = Bookingid;

                SqlParameter[] param = new SqlParameter[] { pAction, pbookingId };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure,ProjectWiseDetails.Pro_ProjectWiseDetails, param);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        
        }
        
              public DataSet GetDataForUnitHolderPrint(int bookingId, int pcID, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pbookingId = new SqlParameter("@BookingId", SqlDbType.BigInt);
                SqlParameter pPrjId = new SqlParameter("@PCId", SqlDbType.BigInt);

                pAction.Value = 6;
                pPrjId.Value = pcID;
                pbookingId.Value = bookingId;

                SqlParameter[] param = new SqlParameter[] { pAction, pPrjId, pbookingId };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure,ProjectWiseDetails.Pro_ProjectWiseDetails, param);
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

                pAction.Value = 7;
                pPrjId.Value = pcID;
                pBookingId.Value = BookingId;
                pApplDate.Value = applicableDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pPrjId, pBookingId, pApplDate };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, ProjectWiseDetails.Pro_ProjectWiseDetails, param);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public DataSet GetUnitHolderDetailsForPrint(int ID, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pID = new SqlParameter("@BookingId", SqlDbType.BigInt);

                pAction.Value = 8;
                pID.Value = ID;

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, ProjectWiseDetails.Pro_ProjectWiseDetails, pAction, pID);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }
        public DMProjectWiseDetails()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
