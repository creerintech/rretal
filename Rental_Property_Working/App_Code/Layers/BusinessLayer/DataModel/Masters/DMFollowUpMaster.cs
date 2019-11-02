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
    public class DMFollowUpMaster : Utility.Setting
    {
        public int InsertRecord(ref FollowUpMaster Entity_Call, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(FollowUpMaster._Action, SqlDbType.BigInt);
                SqlParameter pFollowupType = new SqlParameter(FollowUpMaster._FollowUpType, SqlDbType.BigInt);
                SqlParameter pReason = new SqlParameter(FollowUpMaster._Reason, SqlDbType.NVarChar);              
                SqlParameter pCreatedBy = new SqlParameter(FollowUpMaster._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(FollowUpMaster._LoginDate, SqlDbType.DateTime);

                pAction.Value = 1;
                pFollowupType.Value = Entity_Call.FollowUpType;
                pReason.Value = Entity_Call.Reason;
                pCreatedBy.Value = Entity_Call.UserId;
                pCreatedDate.Value = Entity_Call.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pFollowupType, pReason, pCreatedBy, pCreatedDate };
                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, FollowUpMaster.SP_FollowUpMaster, param);

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

        public int UpdateRecord(ref FollowUpMaster Entity_Call, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(FollowUpMaster._Action, SqlDbType.BigInt);
                SqlParameter pFolloupId = new SqlParameter(FollowUpMaster._FollowUpId, SqlDbType.BigInt);
                SqlParameter pFollowupType = new SqlParameter(FollowUpMaster._FollowUpType, SqlDbType.BigInt);
                SqlParameter pReason = new SqlParameter(FollowUpMaster._Reason, SqlDbType.NVarChar);

                SqlParameter pCreatedBy = new SqlParameter(FollowUpMaster._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(FollowUpMaster._LoginDate, SqlDbType.DateTime);

                pAction.Value = 2;
                pFolloupId.Value = Entity_Call.FollowUpId;
                pFollowupType.Value = Entity_Call.FollowUpType;
                pReason.Value = Entity_Call.Reason;
                pCreatedBy.Value = Entity_Call.UserId;
                pCreatedDate.Value = Entity_Call.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pFolloupId,pFollowupType, pReason, pCreatedBy, pCreatedDate };
                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, FollowUpMaster.SP_FollowUpMaster, param);

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

        public int DeleteRecord(ref FollowUpMaster Entity_Call, out string StrError)
        {
            int iDelete = 0;
            StrError = string.Empty;

            try
            {
                SqlParameter pAction = new SqlParameter(FollowUpMaster._Action, SqlDbType.BigInt);
                SqlParameter pFollowupId = new SqlParameter(FollowUpMaster._FollowUpId, SqlDbType.BigInt);
                SqlParameter pDeletedBy = new SqlParameter(FollowUpMaster._UserId, SqlDbType.BigInt);
                SqlParameter pDeletedDate = new SqlParameter(FollowUpMaster._LoginDate, SqlDbType.DateTime);

                pAction.Value = 3;
                pFollowupId.Value = Entity_Call.FollowUpId;
                pDeletedBy.Value = Entity_Call.UserId;
                pDeletedDate.Value = Entity_Call.LoginDate;
                // pIsDeleted.Value = Entity_Country.IsDeleted;

                SqlParameter[] param = new SqlParameter[] { pAction, pFollowupId, pDeletedBy, pDeletedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();

                iDelete = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, FollowUpMaster.SP_FollowUpMaster, param);

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

        public DataSet GetRecordForEdit(int ID, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();

            try
            {
                SqlParameter pAction = new SqlParameter(FollowUpMaster._Action, SqlDbType.BigInt);
                SqlParameter pFollowUpId = new SqlParameter(FollowUpMaster._FollowUpId, SqlDbType.BigInt);

                pAction.Value = 4;
                pFollowUpId.Value = ID;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, FollowUpMaster.SP_FollowUpMaster, pAction, pFollowUpId);

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

        public DataSet GetList(string RepCondition, out string StrError)
        {
            StrError = string.Empty;

            DataSet DS = new DataSet();

            try
            {
                SqlParameter pAction = new SqlParameter(FollowUpMaster._Action, SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter(FollowUpMaster._StrCondition, SqlDbType.NVarChar);

                pAction.Value = 5;
                PrepCondition.Value = RepCondition;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, FollowUpMaster.SP_FollowUpMaster, pAction, PrepCondition);


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

        public DataSet ChkDuplicate(string Name, out string StrError)
        {
            StrError = string.Empty;

            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(BudgetMaster._Action, SqlDbType.BigInt);
                SqlParameter pRepCondition = new SqlParameter(BudgetMaster._StrCondition, SqlDbType.NVarChar);

                pAction.Value = 6;
                pRepCondition.Value = Name;

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, BudgetMaster.SP_BudgetMaster, pAction, pRepCondition);

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
                SqlParameter pAction = new SqlParameter(FollowUpMaster._Action, SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter(FollowUpMaster._StrCondition, SqlDbType.NVarChar);

                pAction.Value = 5;
                PrepCondition.Value = preFixText;

                SqlParameter[] oparamcol = new SqlParameter[] { pAction, PrepCondition };

                Open(CONNECTION_STRING);
                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, FollowUpMaster.SP_FollowUpMaster, oparamcol);

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


        public DMFollowUpMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
