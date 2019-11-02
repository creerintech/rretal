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

namespace Build.DataModel
{
    public class DMGetTodayDeatils : Utility.Setting
    {
        public DataSet FillCombo(out string StrError)
        {
            DataSet DS = new DataSet();
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(BookingMaster._Action, SqlDbType.BigInt);              

                pAction.Value = 2;
                

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "GetTodayDetails", pAction);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return DS;
        }

        public DataSet BindTodayList(int EmpID, out string StrError)
        {
            DataSet ds = new DataSet();
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pEmpID = new SqlParameter("@EmpID", SqlDbType.BigInt);

                pAction.Value = 1;
                pEmpID.Value = EmpID;

                Open(CONNECTION_STRING);
                ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "GetTodayDetails", pAction, pEmpID);
            }
            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return ds;
        }

        public DataSet BindList(out string StrError)
        {
            DataSet ds = new DataSet();
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
           

                pAction.Value = 3;
               
                Open(CONNECTION_STRING);
                ds = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "GetTodayDetails", pAction);
            }
            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return ds;
        }
        public DMGetTodayDeatils()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }

}
