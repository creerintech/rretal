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
using Build.EntityClass;
using Build.DALSQLHelper;
using Build.DB;
using Build.Utility;
using System.Collections.Generic;

namespace Build.BussinessLayer
{
    public class DMUserMaster : Utility.Setting
    {
        #region[BusinessMethods]

            public int InsertUserDetails(ref  UserMaster obj_User, out string strError)
            {
            int InsertRow = 0;
            strError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(UserMaster._Action, SqlDbType.BigInt);
                SqlParameter pUserName = new SqlParameter(UserMaster._UserName, SqlDbType.NVarChar);
                SqlParameter pEmailId = new SqlParameter(UserMaster._EmailId, SqlDbType.NVarChar);
                SqlParameter PLoginName = new SqlParameter(UserMaster._LoginName, SqlDbType.NVarChar);
                SqlParameter pPassword = new SqlParameter(UserMaster._Password, SqlDbType.NVarChar);
                SqlParameter pUserType = new SqlParameter(UserMaster._UserType, SqlDbType.NVarChar);
                SqlParameter pIsAdmin = new SqlParameter(UserMaster._IsAdmin, SqlDbType.Bit);
                SqlParameter pEmpId = new SqlParameter(UserMaster._EmpID, SqlDbType.BigInt);

                SqlParameter pCreatedBy = new SqlParameter(UserMaster._LUserID, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(UserMaster._LoginDate, SqlDbType.DateTime);
         

                pAction.Value = 1;
                pUserName.Value = obj_User.UserName;
                pEmailId.Value = obj_User.EmailId;
                PLoginName.Value = obj_User.LoginName;
                pPassword.Value = obj_User.Password;
                pUserType.Value = obj_User.UserType;
                pIsAdmin.Value = obj_User.IsAdmin;
                pEmpId.Value = obj_User.EmpID;

                pCreatedBy.Value = obj_User.LUserID.Equals("") ? 0 : obj_User.LUserID;
                pCreatedDate.Value = obj_User.LoginDate;


                SqlParameter[] ParamArray = new SqlParameter[] { pAction, pUserName, pEmailId, PLoginName, pPassword, pUserType, pIsAdmin, pEmpId, pCreatedBy, pCreatedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();

                InsertRow = SQLHelper.ExecuteScalar(_Connection, _Transaction, CommandType.StoredProcedure, UserMaster.SP_USERMASTER, ParamArray);
                if (InsertRow != 0)
                {
                    CommitTransaction();
                }
                else
                {
                    RollBackTransaction();
                }
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                RollBackTransaction();
            }
            finally
            {
                Close();
            }
            return InsertRow;
        }

            public int UpdateUserDetails(ref  UserMaster obj_User, out string strError)
             {
            int UpdateRow = 0;
            strError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(UserMaster._Action, SqlDbType.BigInt);
                SqlParameter pUserID = new SqlParameter(UserMaster._UserId, SqlDbType.BigInt);
                SqlParameter pUserName = new SqlParameter(UserMaster._UserName, SqlDbType.NVarChar);
                SqlParameter pLoginName = new SqlParameter(UserMaster._LoginName, SqlDbType.NVarChar);
                SqlParameter pEmailId = new SqlParameter(UserMaster._EmailId, SqlDbType.NVarChar);
                SqlParameter pPassword = new SqlParameter(UserMaster._Password, SqlDbType.NVarChar);
                SqlParameter pUserType = new SqlParameter(UserMaster._UserType, SqlDbType.NVarChar);
                SqlParameter pIsAdmin = new SqlParameter(UserMaster._IsAdmin, SqlDbType.Bit);
                SqlParameter pEmpId = new SqlParameter(UserMaster._EmpID, SqlDbType.BigInt);

                SqlParameter pUpdatedBy = new SqlParameter(UserMaster._UpdatedBy, SqlDbType.BigInt);
                SqlParameter pUpdatedDate = new SqlParameter(UserMaster._UpdatedDate, SqlDbType.DateTime);
              
                pAction.Value = 2;
                pUserID.Value = obj_User.UserID;
                pUserName.Value = obj_User.UserName;
                pLoginName.Value = obj_User.LoginName;
                pEmailId.Value = obj_User.EmailId;
                pPassword.Value = obj_User.Password;
                pUserType.Value = obj_User.UserType;
                pIsAdmin.Value = obj_User.IsAdmin;
                pEmpId.Value = obj_User.EmpID;

                pUpdatedBy.Value = obj_User.UpdatedBy;
                pUpdatedDate.Value = Convert.ToDateTime(DateTime.Today.ToString());

                SqlParameter[] ParamArray = new SqlParameter[] { pAction, pUserID,pUserName,pLoginName, pEmailId, pPassword, pUserType, 
                    pIsAdmin, pEmpId,pUpdatedBy, pUpdatedDate};

                Open(CONNECTION_STRING);
                BeginTransaction();

                UpdateRow = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, UserMaster.SP_USERMASTER, ParamArray);
                if (UpdateRow != 0)
                {
                    CommitTransaction();
                }
                else
                {
                    RollBackTransaction();
                }
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                RollBackTransaction();
            }
            finally
            {
                Close();
            }
            return UpdateRow;
        }

            public int InsertUserAuthDetails(ref  UserMaster obj_User, out string strError)
            {
                int InsertRow = 0;
                strError = string.Empty;
                try
                {
                    SqlParameter MAction = new SqlParameter(UserMaster._Action, SqlDbType.BigInt);
                    SqlParameter MUserID = new SqlParameter(UserMaster._FkUserId, SqlDbType.BigInt);
                    SqlParameter MFormCaption = new SqlParameter(UserMaster._FormName, SqlDbType.NVarChar);
                    SqlParameter MViewAuth = new SqlParameter(UserMaster._ViewAuth, SqlDbType.Bit);
                    SqlParameter MAddAuth = new SqlParameter(UserMaster._AddAuth, SqlDbType.Bit);
                    SqlParameter MDelAuth = new SqlParameter(UserMaster._DelAuth, SqlDbType.Bit);
                    SqlParameter MEditAuth = new SqlParameter(UserMaster._EditAuth, SqlDbType.Bit);
                    SqlParameter MPrintAuth = new SqlParameter(UserMaster._PrintAuth, SqlDbType.Bit);

                    MAction.Value = 9;
                    MUserID.Value = obj_User.FkUserId;
                    MFormCaption.Value = obj_User.FormName;
                    MViewAuth.Value = obj_User.ViewAuth;
                    MAddAuth.Value = obj_User.AddAuth;
                    MDelAuth.Value = obj_User.DelAuth;
                    MEditAuth.Value = obj_User.EditAuth;
                    MPrintAuth.Value = obj_User.PrintAuth;

                    SqlParameter[] ParamArray = new SqlParameter[] {MAction ,MUserID, MFormCaption, MViewAuth, MAddAuth,
                    MDelAuth, MEditAuth,MPrintAuth };

                    Open(CONNECTION_STRING);
                    BeginTransaction();

                    InsertRow = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, UserMaster.SP_USERMASTER, ParamArray);
                    if (InsertRow != 0)
                    {
                        CommitTransaction();
                    }
                    else
                    {
                        RollBackTransaction();
                    }
                }
                catch (Exception ex)
                {
                    strError = ex.Message;
                    RollBackTransaction();
                }
                finally
                {
                    Close();
                }
                return InsertRow;
            }

            public int InsertUserSiteDetail(ref  UserMaster obj_User, out string strError)
            {
                int InsertRow = 0;
                strError = string.Empty;
                try
                {
                    SqlParameter MAction = new SqlParameter(UserMaster._Action, SqlDbType.BigInt);
                    SqlParameter MUserID = new SqlParameter(UserMaster._FkUserId, SqlDbType.BigInt);
                    SqlParameter MCafeId = new SqlParameter(UserMaster._PCId, SqlDbType.BigInt);
                    SqlParameter MChecked = new SqlParameter(UserMaster._Cheked, SqlDbType.Bit);

                    MAction.Value = 11;
                    MUserID.Value = obj_User.FkUserId;
                    MCafeId.Value = obj_User.PCId;
                    MChecked.Value = obj_User.Cheked;


                    SqlParameter[] ParamArray = new SqlParameter[] { MAction, MUserID, MCafeId, MChecked };
                    Open(CONNECTION_STRING);
                    BeginTransaction();
                    InsertRow = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, UserMaster.SP_USERMASTER, ParamArray);

                    if (InsertRow != 0)
                    {
                        CommitTransaction();
                    }
                    else
                    {
                        RollBackTransaction();
                    }
                }
                catch (Exception ex)
                {
                    strError = ex.Message;
                    RollBackTransaction();
                }
                finally
                {
                    Close();
                }
                return InsertRow;

            }

            public int DeleteUserDetails(ref  UserMaster obj_User_Master, out string strError)
            {
                int DeleteRow = 0;
                strError = string.Empty;
                try
                {
                    SqlParameter MAction = new SqlParameter(UserMaster._Action, SqlDbType.BigInt);
                    SqlParameter MUserID = new SqlParameter(UserMaster._UserId, SqlDbType.BigInt);
                    SqlParameter MDeletedBy = new SqlParameter(UserMaster._DeletedBy, SqlDbType.BigInt);
                    SqlParameter MDeletedDate = new SqlParameter(UserMaster._DeletedDate, SqlDbType.DateTime);

                    MAction.Value = 3;
                    MUserID.Value = obj_User_Master.UserID;
                    MDeletedBy.Value = obj_User_Master.DeletedBy;
                    MDeletedDate.Value = Convert.ToDateTime(DateTime.Today.ToString());

                    SqlParameter[] ParamArray = new SqlParameter[] { MAction, MUserID, MDeletedBy, MDeletedDate };

                    Open(CONNECTION_STRING);
                    BeginTransaction();

                    DeleteRow = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, UserMaster.SP_USERMASTER, ParamArray);
                    if (DeleteRow != 0)
                    {
                        CommitTransaction();
                    }
                    else
                    {
                        RollBackTransaction();
                    }
                }
                catch (Exception ex)
                {
                    strError = ex.Message;
                    RollBackTransaction();
                }
                finally
                {
                    Close();
                }
                return DeleteRow;
            }

            public DataSet GetUserDetails(string RepCondition, out string strError)
            {
                strError = string.Empty;
                DataSet Ds = new DataSet();
                try
                {
                    SqlParameter MAction = new SqlParameter(UserMaster._Action, SqlDbType.BigInt);
                    SqlParameter MRepCondition = new SqlParameter(UserMaster._RepCondition,SqlDbType.NVarChar);

                    MAction.Value = 5;
                    MRepCondition.Value = RepCondition;

                    Open(CONNECTION_STRING);
                    Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, UserMaster.SP_USERMASTER, MAction, MRepCondition);
                }
                catch (Exception ex)
                {
                    strError = ex.Message;
                }
                finally { 
                 Close(); 
                }
                return Ds;
            }

            public DataSet GetUserDetailsForEdit(int ID, out string strError)
            {
                strError = string.Empty;
                DataSet Ds = new DataSet();
                try
                {
                    SqlParameter MAction = new SqlParameter(UserMaster._Action, SqlDbType.BigInt);
                    SqlParameter MUserID = new SqlParameter(UserMaster._UserID, SqlDbType.BigInt);
                    MAction.Value =4;
                    MUserID.Value = ID;

                    Open(CONNECTION_STRING);
                    Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, UserMaster.SP_USERMASTER, MAction, MUserID);
                }
                catch (Exception ex)
                {
                    strError = ex.Message;
                }
                finally { Close(); }
                return Ds;

            }

            public string[] GetSuggestedRecord(string prefixText)
            {
                List<string> SearchList = new List<string>();
                string ListItem = string.Empty;
                try
                {                    
                    SqlParameter MAction = new SqlParameter(UserMaster._Action, SqlDbType.VarChar);
                    SqlParameter MRepCondition = new SqlParameter(UserMaster._RepCondition, SqlDbType.NVarChar);

                    MAction.Value = 5;
                    MRepCondition.Value = prefixText;

                    SqlParameter[] oParmCol = new SqlParameter[] { MAction, MRepCondition };
                    Open(CONNECTION_STRING);

                    SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, UserMaster.SP_USERMASTER, oParmCol);

                    if (dr != null && dr.HasRows == true)
                    {
                        while (dr.Read())
                        {
                            ListItem = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(dr[0].ToString(), dr[1].ToString());
                            SearchList.Add(ListItem);
                        }
                    }
                    dr.Close();
                }

                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    Close();
                }
                return SearchList.ToArray();
            }

            public DataSet GetUserRightTable(out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter MAction = new SqlParameter(UserMaster._Action, SqlDbType.BigInt);
                MAction.Value = 7;

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, UserMaster.SP_USERMASTER, MAction);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

            public DataSet ChkDuplicate(int EmpID,long UserId, out string strError)
            {
                strError = string.Empty;
                DataSet DS = new DataSet();

                try
                {
                    SqlParameter pAction = new SqlParameter(UserMaster._Action, SqlDbType.BigInt);
                    SqlParameter pEmpId = new SqlParameter(UserMaster._EmpID, SqlDbType.NVarChar);
                    SqlParameter pUserId = new SqlParameter(UserMaster._UserId, SqlDbType.NVarChar);

                    pAction.Value = 6;
                    pEmpId.Value = EmpID;
                    pUserId.Value = UserId;

                    SqlParameter[] param = new SqlParameter[] { pAction, pEmpId, pUserId };

                    Open(CONNECTION_STRING);

                    DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure,UserMaster.SP_USERMASTER,param);
                }
                catch (Exception ex)
                {
                    strError = ex.Message;
                }
                finally
                {
                    Close();
                }
                return DS;
            }

            public DataSet BindCombo( out string strError)
            {
                strError = string.Empty;
                DataSet Ds = new DataSet();
                try
                {
                    SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);
                    MAction.Value = 10;

                    Open(CONNECTION_STRING);
                    Ds = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_USERMASTER", MAction);

                }
                catch (Exception ex)
                {
                    strError = ex.Message;
                }
                finally { Close(); }
                return Ds;

            }

       
        #endregion

        public DMUserMaster()
        {           
        }
    }
}
