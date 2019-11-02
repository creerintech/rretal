using Build.DALSQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Build.DataModel
{
    
    public class DMMISSalesVsPayments:Utility.Setting
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
                DS = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_SalesVsPayments", pAction);

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
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_SalesVsPayments", pAction, pId);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

        public DataSet GetReport(string RepCondition, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);

                SqlParameter MRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

                MAction.Value = 4;

                MRepCondition.Value = RepCondition;

                Open(CONNECTION_STRING);
                SqlParameter[] param = new SqlParameter[] { MAction, MRepCondition };
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_SalesVsPayments", param);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

        //public DataSet GetDataForUnitHolderPrint(string regind,string str2, int pcid, out string strError)
        //{
        //    strError = string.Empty;
        //    DataSet Ds = new DataSet();
        //    try
        //    {
        //        SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
        //        SqlParameter PCId = new SqlParameter("@PCId", SqlDbType.BigInt);
        //        SqlParameter pInd = new SqlParameter("@RegInd", SqlDbType.NVarChar);
        //        SqlParameter pstr = new SqlParameter("@StrCondition2", SqlDbType.NVarChar);

        //        pAction.Value = 4;
        //        PCId.Value = pcid;
        //        pInd.Value = regind;
        //        pstr.Value = str2;
        //        SqlParameter[] param = new SqlParameter[] { pAction, PCId, pInd, pstr };

        //        Open(CONNECTION_STRING);
        //        Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_SalesVsPayments", param);
        //    }
        //    catch (Exception ex)
        //    {
        //        strError = ex.Message;
        //    }
        //    finally { Close(); }
        //    return Ds;
        //}


        //public DataSet GetDataForUnitHolderPrint_ForAllProjects(string str2, string regind, out string strError)
        //{
        //    strError = string.Empty;
        //    DataSet Ds = new DataSet();
        //    try
        //    {
        //        SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
        //        SqlParameter pInd = new SqlParameter("@strCond", SqlDbType.NVarChar);
        //        SqlParameter pstr = new SqlParameter("@StrCondition2", SqlDbType.NVarChar);

        //        pAction.Value = 7;
        //        pstr.Value = str2;
        //        pInd.Value = regind;

        //        SqlParameter[] param = new SqlParameter[] { pAction, pstr, pInd };

        //        Open(CONNECTION_STRING);
        //        Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_SalesVsPayments", param);
        //    }
        //    catch (Exception ex)
        //    {
        //        strError = ex.Message;
        //    }
        //    finally { Close(); }
        //    return Ds;
        //}



        public DataSet GetDataForUnitHolderPrint(int pcid, out string strError)  //New
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter PCId = new SqlParameter("@PCId", SqlDbType.BigInt);
              //  SqlParameter pInd = new SqlParameter("@RegInd", SqlDbType.NVarChar);

                pAction.Value = 4;
                PCId.Value = pcid;
             //   pInd.Value = regind;

                SqlParameter[] param = new SqlParameter[] { pAction, PCId };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_SalesVsPayments", param);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }


        public DataSet GetDataForUnitHolderPrint_ForAllProjects(out string strError)     //New
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
              //  SqlParameter pInd = new SqlParameter("@RegInd", SqlDbType.NVarChar);

                pAction.Value = 4;
              //  pInd.Value = regind;

                SqlParameter[] param = new SqlParameter[] { pAction };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_SalesVsPayments", param);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }



        public DataSet GetProjectSummary(string RepCondition, string StrCondition2, out string strError)//, string PCId, string building, 
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);

                //SqlParameter pPCId = new SqlParameter("@PCId", SqlDbType.BigInt);
                SqlParameter pRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);
                SqlParameter pStrCondition2 = new SqlParameter("@StrCondition2", SqlDbType.NVarChar);
               // SqlParameter pBuilding = new SqlParameter("@Building", SqlDbType.NVarChar);

                pAction.Value = 5;
              //  pPCId.Value = PCId;
             //   pInd.Value = regind;
                pRepCondition.Value = RepCondition;
                pStrCondition2.Value = StrCondition2;
              //  pBuilding.Value = building;
                SqlParameter[] param = new SqlParameter[] { pAction,  pRepCondition, pStrCondition2};
                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_SalesVsPayments", param);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }




        public DMMISSalesVsPayments()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}