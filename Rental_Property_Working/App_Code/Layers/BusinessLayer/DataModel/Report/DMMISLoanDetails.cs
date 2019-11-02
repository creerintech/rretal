using Build.DALSQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Build.DataModel
{

    public class DMMISLoanDetails:Utility.Setting
    {

        public DataSet FillCombo(out string StrError)
        {
            DataSet DS = new DataSet();
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(LoanDetails._Action, SqlDbType.BigInt);
              //  SqlParameter pEmpID = new SqlParameter(LoanDetails._EmpID, SqlDbType.BigInt);

                pAction.Value = 1;
              //  pEmpID.Value = EmpID;

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_LoanDetails", pAction);

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
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_LoanDetails", pAction, pId);

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
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_LoanDetails", param);

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

                pAction.Value = 5;
                pPCDetailId.Value = PCDetailsId;

                SqlParameter[] param = new SqlParameter[] { pAction, pPCDetailId };
                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_LoanDetails", param);

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

                Open(CONNECTION_STRING);
                SqlParameter[] param = new SqlParameter[] { MAction, MRepCondition };
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_LoanDetails", param);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }


        public DMMISLoanDetails()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}