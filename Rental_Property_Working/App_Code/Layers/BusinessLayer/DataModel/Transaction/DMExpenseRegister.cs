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
    public class DMExpenseRegister : Utility.Setting
    {

        public DataSet FillCombo(out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                pAction.Value = 10;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ExpenceRegisterMaster", pAction);

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

                Ds = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ExpenceRegisterMaster", MAction);

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

        public int InsertExpenceHead(ref ExpenseRegister Entity_EH, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(ExpenseRegister._Action, SqlDbType.BigInt);
                SqlParameter pExpRegNo = new SqlParameter(ExpenseRegister._ExpRegNo, SqlDbType.NVarChar);
                SqlParameter pPropertyId = new SqlParameter(ExpenseRegister._PropertyId, SqlDbType.BigInt);

                SqlParameter pUnitNo = new SqlParameter(ExpenseRegister._UnitNo, SqlDbType.NVarChar);
                SqlParameter pExpenceRegDate = new SqlParameter(ExpenseRegister._ExpenceRegDate, SqlDbType.DateTime);

                SqlParameter pCreatedBy = new SqlParameter(ExpenseRegister._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(ExpenseRegister._LoginDate, SqlDbType.DateTime);

                pAction.Value = 1;
                pExpRegNo.Value = Entity_EH.ExpRegNo;
                pExpenceRegDate.Value = Entity_EH.ExpenceRegDate;
                pPropertyId.Value = Entity_EH.PropertyId;
                pUnitNo.Value = Entity_EH.UnitNo;
                pCreatedBy.Value = Entity_EH.UserId;
                pCreatedDate.Value = Entity_EH.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pExpRegNo, pExpenceRegDate, pPropertyId, pUnitNo, pCreatedBy, pCreatedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteScalar(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ExpenceRegisterMaster", param);

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

        public int InsertExpenceHeadDetail(ref ExpenseRegister Entity_EH, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(ExpenseRegister._Action, SqlDbType.BigInt);
                SqlParameter pExpregId = new SqlParameter(ExpenseRegister._ExpregId, SqlDbType.BigInt);
                SqlParameter pExpenseHdId = new SqlParameter(ExpenseRegister._ExpenseHdId, SqlDbType.BigInt);
                SqlParameter pAmount = new SqlParameter(ExpenseRegister._Amount, SqlDbType.Decimal);
                SqlParameter pRemark = new SqlParameter(ExpenseRegister._Remark, SqlDbType.NVarChar);

                pAction.Value = 4;
                pExpregId.Value = Entity_EH.ExpregId;
                pExpenseHdId.Value = Entity_EH.ExpenseHdId;                
                pAmount.Value = Entity_EH.Amount;
                pRemark.Value = Entity_EH.Remark;


                SqlParameter[] param = new SqlParameter[] { pAction, pExpregId, pExpenseHdId, pAmount, pRemark };

                Open(CONNECTION_STRING);
                BeginTransaction();

                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, ExpenseRegister.SP_ExpenceRegisterMaster, param);

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

        public DataSet GetProject(string RepCondition, out string StrError)
        {

            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(ExpenseRegister._Action, SqlDbType.BigInt);
                SqlParameter pRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

                pAction.Value = 5;
                pRepCondition.Value = RepCondition;

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, ExpenseRegister.SP_ExpenceRegisterMaster, pAction, pRepCondition);
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
                SqlParameter MAction = new SqlParameter(ExpenseRegister._Action, SqlDbType.BigInt);
                MAction.Value = 6;
                SqlParameter MExpregId = new SqlParameter(ExpenseRegister._ExpregId, SqlDbType.BigInt);
                MExpregId.Value = Id;

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, ExpenseRegister.SP_ExpenceRegisterMaster, MAction, MExpregId);
            }
            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally { Close(); }

            return Ds;
        }

        public int DeleteExpenceHead(ref ExpenseRegister Entity_PM, out string StrError)
        {
            StrError = string.Empty;
            int insertrow = 0;
            try
            {
                SqlParameter pAction = new SqlParameter(ExpenseRegister._Action, SqlDbType.BigInt);
                pAction.Value = 3;

                SqlParameter pExpregId = new SqlParameter(ExpenseRegister._ExpregId, SqlDbType.BigInt);
                pExpregId.Value = Entity_PM.ExpregId;

                SqlParameter pCreatedby = new SqlParameter(ExpenseRegister._UserId, SqlDbType.BigInt);
                pCreatedby.Value = Entity_PM.UserId;

                SqlParameter pCreatedDate = new SqlParameter(ExpenseRegister._LoginDate, SqlDbType.DateTime);
                pCreatedDate.Value = Entity_PM.LoginDate;

                SqlParameter[] ParamArray = new SqlParameter[] { pAction, pExpregId, pCreatedby, pCreatedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();

                insertrow = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, ExpenseRegister.SP_ExpenceRegisterMaster, ParamArray);

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

        public int UpdatetExpenceHead(ref ExpenseRegister Entity_EM, out string StrError)
        {
            StrError = string.Empty;
            int insertrow = 0;
            try
            {
                SqlParameter pAction = new SqlParameter(ExpenseRegister._Action, SqlDbType.BigInt);
                SqlParameter pExpregId = new SqlParameter(ExpenseRegister._ExpregId, SqlDbType.BigInt);
                SqlParameter pExpRegNo = new SqlParameter(ExpenseRegister._ExpRegNo, SqlDbType.NVarChar);
                SqlParameter pExpenceRegDate = new SqlParameter(ExpenseRegister._ExpenceRegDate, SqlDbType.DateTime);
                SqlParameter pPropertyId = new SqlParameter(ExpenseRegister._PropertyId, SqlDbType.BigInt);

                SqlParameter pUnitNo = new SqlParameter(ExpenseRegister._UnitNo, SqlDbType.NVarChar);
                SqlParameter pExpenseHdId = new SqlParameter(ExpenseRegister._ExpenseHdId, SqlDbType.BigInt);
                SqlParameter pCreatedby = new SqlParameter(ExpenseRegister._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(ExpenseRegister._LoginDate, SqlDbType.DateTime);

                pAction.Value = 2;
                pExpRegNo.Value = Entity_EM.ExpRegNo;
                pExpregId.Value = Entity_EM.ExpregId;
                pExpenceRegDate.Value = Entity_EM.ExpenceRegDate;
                pPropertyId.Value = Entity_EM.PropertyId;
                pUnitNo.Value = Entity_EM.UnitNo;
                pExpenseHdId.Value = Entity_EM.ExpenseHdId;
                pCreatedby.Value = Entity_EM.UserId;
                pCreatedDate.Value = Entity_EM.LoginDate;

                SqlParameter[] ParamArray = new SqlParameter[] { pAction, pExpRegNo, pExpregId, pExpenceRegDate, pPropertyId, pUnitNo, pExpenseHdId, pCreatedby, pCreatedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();
                insertrow = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, ExpenseRegister.SP_ExpenceRegisterMaster, ParamArray);

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
                SqlParameter pAction = new SqlParameter(ExpenseRegister._Action, SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

                pAction.Value = 5;
                PrepCondition.Value = preFixText;

                SqlParameter[] oparamcol = new SqlParameter[] { pAction, PrepCondition };

                Open(CONNECTION_STRING);
                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, ExpenseRegister.SP_ExpenceRegisterMaster, oparamcol);

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



        public DMExpenseRegister()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public string[] GetSuggestedRecordForUnit(string prefixText)
        {
            List<string> SearchList = new List<string>();
            string ListItem = string.Empty;
            try
            {

                // -- For Checking OF Execution of Procedure=========
                SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter MRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);


                MAction.Value = 12;
                MRepCondition.Value = prefixText;

                SqlParameter[] oParmCol = new SqlParameter[] { MAction, MRepCondition };
                Open(CONNECTION_STRING);

                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ExpenceRegisterMaster", oParmCol);

                if (dr != null && dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        ListItem = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(dr[1].ToString(), dr[0].ToString());
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
    }
}
