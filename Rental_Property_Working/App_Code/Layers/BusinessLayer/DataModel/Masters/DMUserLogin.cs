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

using System.Data.SqlClient;
using Build.Utility;
using Build.DataModel;
using Build.EntityClass;
using Build.DALSQLHelper;
using Build.DB;


namespace Build.DataModel
{
    public class DMUserLogin :Utility.Setting
    {
        public DataSet GetLoginInfo(ref UserLogin Entity_login, out string strError)
        {           
            DataSet ds = new DataSet();
            strError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(UserLogin._Action, SqlDbType.BigInt);
                SqlParameter pUsername = new SqlParameter(UserLogin._userName, SqlDbType.NVarChar);
                SqlParameter pPassword = new SqlParameter(UserLogin._Password, SqlDbType.NVarChar);
                pAction.Value = 2;
                pUsername.Value = Entity_login.UserName;
                pPassword.Value = Entity_login.Password;
                SqlParameter[] oParmCol = new SqlParameter[] { pAction, pUsername, pPassword };
                Open(CONNECTION_STRING);
                ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, UserLogin.SP_UserLogin, oParmCol);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally
            {
                Close();
            }
            return ds;
        }

        public DataSet GetCafe(out string strError)
        {
            DataSet ds = new DataSet();
            strError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(UserLogin._Action, SqlDbType.BigInt);
                pAction.Value = 3;
                SqlParameter[] oParmCol = new SqlParameter[] { pAction };
                Open(CONNECTION_STRING);
                ds = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, UserLogin.SP_UserLogin,pAction);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally
            {
                Close();
            }
            return ds;
        }


	    public DMUserLogin()
	    {
    		
	    }
    }

}