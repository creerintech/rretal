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

/// <summary>
/// Summary description for DMExpenseNewMaster
/// </summary>
/// 
namespace Build.DataModel
{
    public class DMExpenseNewMaster : Utility.Setting
    {

        public int InsertExpense(ref ExpenseNewMaster Entity_Expense, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(ExpenseNewMaster._Action, SqlDbType.BigInt);
                SqlParameter pExpense = new SqlParameter(ExpenseNewMaster._Expense, SqlDbType.NVarChar);
              

                SqlParameter pCreatedBy = new SqlParameter(ExpenseNewMaster._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(ExpenseNewMaster._LoginDate, SqlDbType.DateTime);

                pAction.Value = 1;
                pExpense.Value = Entity_Expense.Expense;
                
                pCreatedBy.Value = Entity_Expense.UserId;
                pCreatedDate.Value = Entity_Expense.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pExpense, pCreatedBy, pCreatedDate };
                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, ExpenseNewMaster.SP_ExpenseHeadNewMaster, param);

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

        public int UpdateExpense(ref ExpenseNewMaster Entity_Expense, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(ExpenseNewMaster._Action, SqlDbType.BigInt);
                SqlParameter pExpenseHdId = new SqlParameter(ExpenseNewMaster._ExpenseHdId, SqlDbType.BigInt);
                SqlParameter pExpense = new SqlParameter(ExpenseNewMaster._Expense, SqlDbType.NVarChar);
               
                SqlParameter pCreatedBy = new SqlParameter(ExpenseNewMaster._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(ExpenseNewMaster._LoginDate, SqlDbType.DateTime);

                pAction.Value = 2;
                pExpenseHdId.Value = Entity_Expense.ExpenseHdId;
                pExpense.Value = Entity_Expense.Expense;
               
                pCreatedBy.Value = Entity_Expense.UserId;
                pCreatedDate.Value = Entity_Expense.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pExpenseHdId, pExpense, pCreatedBy, pCreatedDate };
                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, ExpenseNewMaster.SP_ExpenseHeadNewMaster, param);

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

        public int DeleteExpense(ref ExpenseNewMaster Entity_Expense, out string StrError)
        {
            int iDelete = 0;
            StrError = string.Empty;

            try
            {
                SqlParameter pAction = new SqlParameter(ExpenseNewMaster._Action, SqlDbType.BigInt);
                SqlParameter pExpenseHdId = new SqlParameter(ExpenseNewMaster._ExpenseHdId, SqlDbType.BigInt);
                SqlParameter pDeletedBy = new SqlParameter(ExpenseNewMaster._UserId, SqlDbType.BigInt);
                SqlParameter pDeletedDate = new SqlParameter(ExpenseNewMaster._LoginDate, SqlDbType.DateTime);

                pAction.Value = 3;
                pExpenseHdId.Value = Entity_Expense.ExpenseHdId;
                pDeletedBy.Value = Entity_Expense.UserId;
                pDeletedDate.Value = Entity_Expense.LoginDate;
                // pIsDeleted.Value = Entity_Country.IsDeleted;

                SqlParameter[] param = new SqlParameter[] { pAction, pExpenseHdId, pDeletedBy, pDeletedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();

                iDelete = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, ExpenseNewMaster.SP_ExpenseHeadNewMaster, param);

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

        public DataSet GetExpenseForEdit(int ID, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();

            try
            {
                SqlParameter pAction = new SqlParameter(ExpenseNewMaster._Action, SqlDbType.BigInt);
                SqlParameter pExpenseHdId = new SqlParameter(ExpenseNewMaster._ExpenseHdId, SqlDbType.BigInt);

                pAction.Value = 4;
                pExpenseHdId.Value = ID;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, ExpenseNewMaster.SP_ExpenseHeadNewMaster, pAction, pExpenseHdId);

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

        public DataSet GetExpenseList(string RepCondition, out string StrError)
        {
            StrError = string.Empty;

            DataSet DS = new DataSet();

            try
            {
                SqlParameter pAction = new SqlParameter(ExpenseNewMaster._Action, SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter(ExpenseNewMaster._StrCondition, SqlDbType.NVarChar);

                pAction.Value = 5;
                PrepCondition.Value = RepCondition;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, ExpenseNewMaster.SP_ExpenseHeadNewMaster, pAction, PrepCondition);


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
                SqlParameter pAction = new SqlParameter(ExpenseNewMaster._Action, SqlDbType.BigInt);

                SqlParameter pRepCondition = new SqlParameter(ExpenseNewMaster._StrCondition, SqlDbType.NVarChar);

                pAction.Value = 6;

                pRepCondition.Value = Name;

                Open(CONNECTION_STRING);
                SqlParameter[] param = { pAction, pRepCondition };
                DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, ExpenseNewMaster.SP_ExpenseHeadNewMaster, param);

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
                SqlParameter pAction = new SqlParameter(ExpenseNewMaster._Action, SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter(ExpenseNewMaster._StrCondition, SqlDbType.NVarChar);

                pAction.Value = 5;
                PrepCondition.Value = preFixText;

                SqlParameter[] oparamcol = new SqlParameter[] { pAction, PrepCondition };

                Open(CONNECTION_STRING);
                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, ExpenseNewMaster.SP_ExpenseHeadNewMaster, oparamcol);

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

        public DataSet GetProjectType(out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(ExpenseNewMaster._Action, SqlDbType.BigInt);

                pAction.Value = 7;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, ExpenseNewMaster.SP_ExpenseHeadNewMaster, pAction);

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

        public DMExpenseNewMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }

}