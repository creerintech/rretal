using Build.DALSQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Build.DataModel
{
    public class DMMISOutStandingProjectWise:Utility.Setting
    {

        public DataSet FillCombo(out string StrError)
        {
            DataSet DS = new DataSet();
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);

                pAction.Value = 1;

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_OutStandingProjectWise", pAction);

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
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_OutStandingProjectWise", pAction, pId);

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
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_OutStandingProjectWise", param);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

        public DataSet GetRport(string StrCond, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pstrCond = new SqlParameter("@strCond", SqlDbType.NVarChar);

                pAction.Value = 5;
                pstrCond.Value = StrCond;
                SqlParameter[] param = new SqlParameter[] { pAction, pstrCond };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_OutStandingProjectWise", param);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }


        public DataSet GetDataForUnitHolderPrint(string regind ,int pcid, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter PCId = new SqlParameter("@PCId", SqlDbType.BigInt);
                SqlParameter pInd = new SqlParameter("@RegInd", SqlDbType.NVarChar);

                pAction.Value = 4;
                PCId.Value = pcid;
                pInd.Value = regind;

                SqlParameter[] param = new SqlParameter[] { pAction, PCId ,pInd};

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_OutStandingProjectWise", param);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public DataSet GetReportDataNew(string regind, int pcid, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter PCId = new SqlParameter("@PCId", SqlDbType.BigInt);
                SqlParameter pInd = new SqlParameter("@RegInd", SqlDbType.NVarChar);

                pAction.Value = 8;
                PCId.Value = pcid;
                pInd.Value = regind;

                SqlParameter[] param = new SqlParameter[] { pAction, PCId, pInd };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_OutStandingProjectWise", param);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public DataSet GetReportDataNewAllProjects(string regind, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                //SqlParameter PCId = new SqlParameter("@PCId", SqlDbType.BigInt);
                SqlParameter pInd = new SqlParameter("@RegInd", SqlDbType.NVarChar);

                pAction.Value = 9;
                //PCId.Value = pcid;
                pInd.Value = regind;

                SqlParameter[] param = new SqlParameter[] { pAction, pInd };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_OutStandingProjectWise", param);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public DataSet GetReportDataNew_MultipleProjects(string regind, string pcids, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pPCIds = new SqlParameter("@Pcids", SqlDbType.NVarChar);
                SqlParameter pInd = new SqlParameter("@RegInd", SqlDbType.NVarChar);

                pAction.Value = 10;
                pPCIds.Value = pcids;
                pInd.Value = regind;

                SqlParameter[] param = new SqlParameter[] { pAction, pPCIds, pInd };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_OutStandingProjectWise", param);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public DataSet GetDataForUnitHolderPrint_ForAllProjects(string regind,out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pInd = new SqlParameter("@RegInd", SqlDbType.NVarChar);

                pAction.Value = 4;
                pInd.Value = regind;

                SqlParameter[] param = new SqlParameter[] { pAction, pInd };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_OutStandingProjectWise", param);
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
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_OutStandingProjectWise", param);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public DataSet GetTotalCost(string StrCond,out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                //SqlParameter pbookingId = new SqlParameter("@BookingId", SqlDbType.BigInt);
             //   SqlParameter pPrjId = new SqlParameter("@PCId", SqlDbType.BigInt);
                SqlParameter pstrCond = new SqlParameter("@strCond", SqlDbType.NVarChar);

                pAction.Value = 6;
                //pPrjId.Value = pcID;
                // pbookingId.Value = bookingId;
                pstrCond.Value = StrCond;
               // pPrjId.Value = pcid;
                SqlParameter[] param = new SqlParameter[] { pAction, pstrCond };          //, pPrjId };// pPrjId, pbookingId };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_OutStandingProjectWise", param);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public DataSet GetProjectSummary(string regind,int PCId,string building, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);

                SqlParameter pPCId = new SqlParameter("@PCId", SqlDbType.BigInt);
                SqlParameter pInd = new SqlParameter("@RegInd", SqlDbType.NVarChar);
                SqlParameter pBuilding = new SqlParameter("@Building", SqlDbType.NVarChar);

                pAction.Value = 7;
                pPCId.Value = PCId;
                pInd.Value = regind;
                pBuilding.Value = building;
                SqlParameter[] param = new SqlParameter[] { pAction, pPCId,pInd,pBuilding };
                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_OutStandingProjectWise", param);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

        public DataSet GetSummaryForAllProject(string ind,out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pInd = new SqlParameter("@RegInd", SqlDbType.NVarChar);
           
                pAction.Value = 7;
                pInd.Value = ind;
           


                SqlParameter[] param = new SqlParameter[] { pAction, pInd };
                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_OutStandingProjectWise", param);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

        public DataSet GetProject(string ind, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pInd = new SqlParameter("@RegInd", SqlDbType.NVarChar);

                pAction.Value = 16;
                pInd.Value = ind;



                SqlParameter[] param = new SqlParameter[] { pAction, pInd };
                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_OutStandingProjectWise", param);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }


        public DMMISOutStandingProjectWise()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}