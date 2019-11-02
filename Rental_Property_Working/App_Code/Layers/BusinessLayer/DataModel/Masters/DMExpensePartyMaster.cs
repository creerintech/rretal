using System;
using System.Data;
using System.Configuration;
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
using Build.DALSQLHelper;
using Build.DB;
using Build.EntityClass;
using Build.Utility;
using System.Collections.Generic;


namespace Build.DataModel
{
    public class DMExpensePartyMaster : Utility.Setting
    {
        public DataSet FillCombo(out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                pAction.Value = 7;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ExpensePartyMaster", pAction);

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

        public DataSet GetExpenceHeadNo(out string StrError)
        {
            StrError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);
                MAction.Value = 11;

                Open(Setting.CONNECTION_STRING);

                Ds = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ExpensePartyMaster", MAction);

            }
            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return Ds;
        }

        public int InsertExpenceHead(ref ExpensePartyMaster Entity_EH, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(ExpensePartyMaster._Action, SqlDbType.BigInt);
                SqlParameter pExpenseParty = new SqlParameter(ExpensePartyMaster._ExpenseParty, SqlDbType.NVarChar);
                SqlParameter pExpenseHdId = new SqlParameter(ExpensePartyMaster._ExpenseHdId, SqlDbType.BigInt);
                SqlParameter pNarration = new SqlParameter(ExpensePartyMaster._Narration, SqlDbType.NVarChar);
                SqlParameter pCreatedBy = new SqlParameter(ExpensePartyMaster._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(ExpensePartyMaster._LoginDate, SqlDbType.DateTime);

                pAction.Value = 1;
                pExpenseParty.Value = Entity_EH.ExpenseParty;
                pExpenseHdId.Value = Entity_EH.ExpenseHdId;
                pNarration.Value = Entity_EH.Narration;
                pCreatedBy.Value = Entity_EH.UserId;
                pCreatedDate.Value = Entity_EH.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pExpenseParty, pExpenseHdId, pNarration, pCreatedBy, pCreatedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteScalar(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ExpensePartyMaster", param);

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

        public DataSet GetExpensePartyList(string RepCondition, out string StrError)
        {

            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(ExpensePartyMaster._Action, SqlDbType.BigInt);
                SqlParameter pRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

                pAction.Value = 5;
                pRepCondition.Value = RepCondition;

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ExpensePartyMaster", pAction, pRepCondition);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Close();
            }
            return DS;
        }

        public DataSet GetExpenceHeadToEdit(int Id, out string StrError)
        {
            StrError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter MAction = new SqlParameter(ExpensePartyMaster._Action, SqlDbType.BigInt);
                MAction.Value = 4;
                SqlParameter MExpenceId = new SqlParameter(ExpensePartyMaster._ExpensePartyId, SqlDbType.BigInt);
                MExpenceId.Value = Id;

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, ExpensePartyMaster.SP_ExpensePartyMaster, MAction, MExpenceId);
            }
            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally { Close(); }

            return Ds;
        }

        public int DeleteExpenceHead(ref ExpensePartyMaster Entity_PM, out string StrError)
        {
            StrError = string.Empty;
            int insertrow = 0;
            try
            {
                SqlParameter pAction = new SqlParameter(ExpensePartyMaster._Action, SqlDbType.BigInt);
                pAction.Value = 6;

                SqlParameter pExpenceId = new SqlParameter(ExpensePartyMaster._ExpensePartyId, SqlDbType.BigInt);
                pExpenceId.Value = Entity_PM.ExpensePartyId;

                SqlParameter pCreatedby = new SqlParameter(ExpensePartyMaster._UserId, SqlDbType.BigInt);
                pCreatedby.Value = Entity_PM.UserId;

                SqlParameter pCreatedDate = new SqlParameter(ExpensePartyMaster._LoginDate, SqlDbType.DateTime);
                pCreatedDate.Value = Entity_PM.LoginDate;

                SqlParameter[] ParamArray = new SqlParameter[] { pAction, pExpenceId, pCreatedby, pCreatedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();

                insertrow = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, ExpensePartyMaster.SP_ExpensePartyMaster, ParamArray);

                if (insertrow > 0)
                    CommitTransaction();
                else
                    RollBackTransaction();
            }
            catch (Exception ex)
            {
                StrError = ex.Message;
                RollBackTransaction();

            }
            finally
            {
                Close();
            }
            return insertrow;
        }

        public int UpdateExpenseParty(ref ExpensePartyMaster Entity_EM, out string StrError)
        {
            StrError = string.Empty;
            int insertrow = 0;
            try
            {
                SqlParameter pAction = new SqlParameter(ExpensePartyMaster._Action, SqlDbType.BigInt);
                SqlParameter pExpensePartyId = new SqlParameter(ExpensePartyMaster._ExpensePartyId, SqlDbType.BigInt);
                SqlParameter pExpenseParty = new SqlParameter(ExpensePartyMaster._ExpenseParty, SqlDbType.NVarChar);
                SqlParameter pExpenseHdId = new SqlParameter(ExpensePartyMaster._ExpenseHdId, SqlDbType.BigInt);
                SqlParameter pNarration = new SqlParameter(ExpensePartyMaster._Narration, SqlDbType.BigInt);
                SqlParameter pCreatedby = new SqlParameter(ExpensePartyMaster._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(ExpensePartyMaster._LoginDate, SqlDbType.DateTime);

                pAction.Value = 2;
                pExpensePartyId.Value = Entity_EM.ExpensePartyId;
                pExpenseParty.Value = Entity_EM.ExpenseParty;
                pExpenseHdId.Value = Entity_EM.ExpenseHdId;
                pNarration.Value = Entity_EM.Narration;
                pCreatedby.Value = Entity_EM.UserId;
                pCreatedDate.Value = Entity_EM.LoginDate;

                SqlParameter[] ParamArray = new SqlParameter[] { pAction, pExpensePartyId, pExpenseParty, pExpenseHdId, pNarration, pCreatedby, pCreatedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();
                insertrow = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, ExpensePartyMaster.SP_ExpensePartyMaster, ParamArray);

                if (insertrow > 0)
                    CommitTransaction();
                else
                    RollBackTransaction();
            }
            catch (Exception ex)
            {
                StrError = ex.Message;
                RollBackTransaction();
            }
            finally
            {
                Close();
            }
            return insertrow;
        }

        public string[] GetSuggestRecord(string preFixText)
        {
            List<string> SearchList = new List<string>();
            string ListItem = string.Empty;

            try
            {
                SqlParameter pAction = new SqlParameter(ExpensePartyMaster._Action, SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

                pAction.Value = 5;
                PrepCondition.Value = preFixText;

                SqlParameter[] oparamcol = new SqlParameter[] { pAction, PrepCondition };

                Open(CONNECTION_STRING);
                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, ExpensePartyMaster.SP_ExpensePartyMaster, oparamcol);

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

        public DMExpensePartyMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public DataSet ChkDuplicate(string Name, out string StrError)
        {
            StrError = string.Empty;

            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(ExpenseNewMaster._Action, SqlDbType.BigInt);

                SqlParameter pRepCondition = new SqlParameter(ExpenseNewMaster._StrCondition, SqlDbType.NVarChar);

                pAction.Value = 6;

                pRepCondition.Value = Name;

                Open(CONNECTION_STRING);
                SqlParameter[] param = { pAction, pRepCondition };
                DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, ExpensePartyMaster.SP_ExpensePartyMaster, param);

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
    }   
}
