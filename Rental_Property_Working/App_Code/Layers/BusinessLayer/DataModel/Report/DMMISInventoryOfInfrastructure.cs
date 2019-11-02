using Build.DALSQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace Build.DataModel
{

    public class DMMISInventoryOfInfrastructure:Utility.Setting
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
                DS = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_InventoryOfInfrastructure", pAction);

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
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_InventoryOfInfrastructure", pAction, pId);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

        public DataSet GetReport(string RepCondition, string RepCondition1, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);

                SqlParameter MRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);
                SqlParameter MRepCondition1 = new SqlParameter("@strCond1", SqlDbType.NVarChar);
                MAction.Value = 15;

                MRepCondition.Value = RepCondition;
                MRepCondition1.Value = RepCondition1;

                Open(CONNECTION_STRING);
                SqlParameter[] param = new SqlParameter[] { MAction, MRepCondition, MRepCondition1};
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_InventoryOfInfrastructure", param);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

       

        public DMMISInventoryOfInfrastructure()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}