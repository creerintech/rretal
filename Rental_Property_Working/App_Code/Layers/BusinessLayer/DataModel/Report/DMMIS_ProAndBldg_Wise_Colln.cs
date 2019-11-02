using Build.DALSQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Build.DataModel
{

    public class DMMIS_ProAndBldg_Wise_Colln : Utility.Setting
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
                DS = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_ProjectAndBuilding_Wise_Collection", pAction);

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
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_ProjectAndBuilding_Wise_Collection", pAction, pId);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

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
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_ProjectAndBuilding_Wise_Collection", param);
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
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_ProjectAndBuilding_Wise_Collection", param);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }


        public DataSet GetProjectAndBuildingSummary(int PCId, string building, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);

                SqlParameter pPCId = new SqlParameter("@PCId", SqlDbType.BigInt);
                
                SqlParameter pBuilding = new SqlParameter("@Building", SqlDbType.NVarChar);

                pAction.Value = 5;
                pPCId.Value = PCId;
               
                pBuilding.Value = building;
                SqlParameter[] param = new SqlParameter[] { pAction, pPCId, pBuilding };
                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_ProjectAndBuilding_Wise_Collection", param);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

        public DataSet GetProjectAndBuildingSummary_ForAll(out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);

               

                pAction.Value = 5;
               
                SqlParameter[] param = new SqlParameter[] { pAction };
                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_ProjectAndBuilding_Wise_Collection", param);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }


        public DMMIS_ProAndBldg_Wise_Colln()
        {

        }
    }
}