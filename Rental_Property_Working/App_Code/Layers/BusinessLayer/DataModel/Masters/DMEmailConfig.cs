using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;

using System.Data.SqlClient;
using Build.DALSQLHelper;
using Build.DB;
using Build.EntityClass;
using Build.Utility;
using System.Data;

/// <summary>
/// Summary description for DMEmailConfig
/// </summary>
/// 
namespace Build.DataModel
{


    public class DMEmailConfig : Utility.Setting
    {

        public int InsertEmailConfig(ref EmailConfiguration Entity_EmailConfig, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(EmailConfiguration._Action, SqlDbType.BigInt);
                SqlParameter pEmailId = new SqlParameter(EmailConfiguration._EmailId, SqlDbType.NVarChar);
                SqlParameter pProjectId = new SqlParameter(EmailConfiguration._ProjectId, SqlDbType.BigInt);
                SqlParameter pPassword = new SqlParameter(EmailConfiguration._Password, SqlDbType.NVarChar);
                SqlParameter pServerName = new SqlParameter(EmailConfiguration._ServerName, SqlDbType.NVarChar);

                SqlParameter pCreatedBy = new SqlParameter(EmailConfiguration._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(EmailConfiguration._LoginDate, SqlDbType.DateTime);

                pAction.Value = 1;
                pEmailId.Value = Entity_EmailConfig.EmailId;
                pProjectId.Value = Entity_EmailConfig.ProjectId;
                pPassword.Value = Entity_EmailConfig.Password;
                pServerName.Value = Entity_EmailConfig.ServerName;

                pCreatedBy.Value = Entity_EmailConfig.UserId;
                pCreatedDate.Value = Entity_EmailConfig.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pEmailId, pProjectId, pPassword,pServerName, pCreatedBy, pCreatedDate };
                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteScalar(_Connection, _Transaction, CommandType.StoredProcedure, EmailConfiguration.SP_EmailConfiguration, param);

                if (iInsert > 0)
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
                RollBackTransaction();
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return iInsert;
        }

        public int UpdateEmailConfig(ref EmailConfiguration Entity_EmailConfig, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {

                SqlParameter pAction = new SqlParameter(EmailConfiguration._Action, SqlDbType.BigInt);
                SqlParameter pEmailConfigId = new SqlParameter(EmailConfiguration._EmailConfigId, SqlDbType.BigInt);
                SqlParameter pEmailId = new SqlParameter(EmailConfiguration._EmailId, SqlDbType.NVarChar);
                SqlParameter pProjectId = new SqlParameter(EmailConfiguration._ProjectId, SqlDbType.BigInt);
                SqlParameter pPassword = new SqlParameter(EmailConfiguration._Password, SqlDbType.NVarChar);
                SqlParameter pServerName = new SqlParameter(EmailConfiguration._ServerName, SqlDbType.NVarChar);

                SqlParameter pCreatedBy = new SqlParameter(EmailConfiguration._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(EmailConfiguration._LoginDate, SqlDbType.DateTime);

                pAction.Value = 2;
                pEmailConfigId.Value = Entity_EmailConfig.EmailConfigId;
                pEmailId.Value = Entity_EmailConfig.EmailId;
                pProjectId.Value = Entity_EmailConfig.ProjectId;
                pPassword.Value = Entity_EmailConfig.Password;
                pServerName.Value = Entity_EmailConfig.ServerName;


                pCreatedBy.Value = Entity_EmailConfig.UserId;
                pCreatedDate.Value = Entity_EmailConfig.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pEmailConfigId, pEmailId,pPassword, pProjectId,pServerName, pCreatedBy, pCreatedDate };
                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, EmailConfiguration.SP_EmailConfiguration, param);

                if (iInsert > 0)
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
                RollBackTransaction();
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return iInsert;
        }

        public int DeleteEmailConfig(ref EmailConfiguration Entity_Bank, out string StrError)
        {
            int iDelete = 0;
            StrError = string.Empty;

            try
            {
                SqlParameter pAction = new SqlParameter(EmailConfiguration._Action, SqlDbType.BigInt);
                SqlParameter pEmailConfigId = new SqlParameter(EmailConfiguration._EmailConfigId, SqlDbType.BigInt);
                SqlParameter pDeletedBy = new SqlParameter(EmailConfiguration._UserId, SqlDbType.BigInt);
                SqlParameter pDeletedDate = new SqlParameter(EmailConfiguration._LoginDate, SqlDbType.DateTime);

                pAction.Value = 3;
                pEmailConfigId.Value = Entity_Bank.EmailConfigId;
                pDeletedBy.Value = Entity_Bank.UserId;
                pDeletedDate.Value = Entity_Bank.LoginDate;
                // pIsDeleted.Value = Entity_Country.IsDeleted;

                SqlParameter[] param = new SqlParameter[] { pAction, pEmailConfigId, pDeletedBy, pDeletedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();

                iDelete = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, EmailConfiguration.SP_EmailConfiguration, param);

                if (iDelete > 0)
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
                RollBackTransaction();
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return iDelete;
        }

        public DataSet GetEmailConfigForEdit(int ID, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();

            try
            {
                SqlParameter pAction = new SqlParameter(EmailConfiguration._Action, SqlDbType.BigInt);
                SqlParameter pEmailConfigId = new SqlParameter(EmailConfiguration._EmailConfigId, SqlDbType.BigInt);

                pAction.Value = 4;
                pEmailConfigId.Value = ID;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, EmailConfiguration.SP_EmailConfiguration, pAction, pEmailConfigId);

            }

            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return DS;
        }

        public DataSet GetEmailConfigList(string RepCondition, out string StrError)
        {
            StrError = string.Empty;

            DataSet DS = new DataSet();

            try
            {
                SqlParameter pAction = new SqlParameter(EmailConfiguration._Action, SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter(EmailConfiguration._StrCondition, SqlDbType.NVarChar);

                pAction.Value = 5;
                PrepCondition.Value = RepCondition;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, EmailConfiguration.SP_EmailConfiguration, pAction, PrepCondition);


            }
            catch (Exception ex)
            {
                StrError = ex.Message;

            }
            finally
            {
                Close();
            }
            return DS;
        }

        public DataSet ChkDuplicate(int ProjectId, out string StrError)
        {
            StrError = string.Empty;

            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(EmailConfiguration._Action, SqlDbType.BigInt);
                SqlParameter pRepCondition = new SqlParameter(EmailConfiguration._StrCondition, SqlDbType.NVarChar);
                SqlParameter pProjectId = new SqlParameter(EmailConfiguration._ProjectId, SqlDbType.BigInt);

                pAction.Value = 6;

                pProjectId.Value = ProjectId;
                Open(CONNECTION_STRING);

                SqlParameter[] param = new SqlParameter[] { pAction, pRepCondition, pProjectId };
                DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, EmailConfiguration.SP_EmailConfiguration, param);

            }
            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return DS;
        }

        public string[] GetSuggestRecord(string preFixText)
        {
            List<string> SearchList = new List<string>();
            string ListItem = string.Empty;

            try
            {
                SqlParameter pAction = new SqlParameter(EmailConfiguration._Action, SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter(EmailConfiguration._StrCondition, SqlDbType.NVarChar);

                pAction.Value = 5;
                PrepCondition.Value = preFixText;

                SqlParameter[] oparamcol = new SqlParameter[] { pAction, PrepCondition };

                Open(CONNECTION_STRING);
                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, EmailConfiguration.SP_EmailConfiguration, oparamcol);

                if (dr != null && dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        ListItem = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(dr[0].ToString(),
                            dr[1].ToString());

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

        public DataSet FillCombo(int EmpId,out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(DueDateForPayment._Action, SqlDbType.BigInt);
                 SqlParameter pEmpId = new SqlParameter("@EmpId", SqlDbType.BigInt);

                pAction.Value = 7;
                pEmpId.Value = EmpId;

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, EmailConfiguration.SP_EmailConfiguration, pAction,pEmpId);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }



        public DMEmailConfig()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}