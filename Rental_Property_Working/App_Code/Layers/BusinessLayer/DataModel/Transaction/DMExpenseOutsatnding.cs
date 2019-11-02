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
    public class DMExpenseOutsatnding : Utility.Setting
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

                DS = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ExpenceOutstandingReg", pAction);

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

                Ds = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ExpenceOutstandingReg", MAction);

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

        public int InsertExpenceHead(ref ExpenseOutstanding Entity_EO, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(ExpenseOutstanding._Action, SqlDbType.BigInt);
                SqlParameter pExpRegNo = new SqlParameter(ExpenseOutstanding._ExpRegNo, SqlDbType.NVarChar);
                SqlParameter pPropertyId = new SqlParameter(ExpenseOutstanding._PropertyId, SqlDbType.BigInt);
                SqlParameter pPartyId = new SqlParameter(ExpenseOutstanding._PartyId, SqlDbType.BigInt);
                SqlParameter pUnitNo = new SqlParameter(ExpenseOutstanding._UnitNo, SqlDbType.NVarChar);
                SqlParameter pExpenceRegDate = new SqlParameter(ExpenseOutstanding._ExpenceRegDate, SqlDbType.DateTime);

                SqlParameter pCreatedBy = new SqlParameter(ExpenseOutstanding._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(ExpenseOutstanding._LoginDate, SqlDbType.DateTime);

                pAction.Value = 1;
                pExpRegNo.Value = Entity_EO.ExpRegNo;
                pExpenceRegDate.Value = Entity_EO.ExpenceRegDate;
                pPropertyId.Value = Entity_EO.PropertyId;
                pPartyId.Value = Entity_EO.PartyId;
                pUnitNo.Value = Entity_EO.UnitNo;
                pCreatedBy.Value = Entity_EO.UserId;
                pCreatedDate.Value = Entity_EO.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pExpRegNo, pExpenceRegDate, pPropertyId, pPartyId, pUnitNo, pCreatedBy, pCreatedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteScalar(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ExpenceOutstandingReg", param);

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

        public int InsertExpenceHeadDetail(ref ExpenseOutstanding Entity_EO, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(ExpenseOutstanding._Action, SqlDbType.BigInt);
                SqlParameter pExpregOutId = new SqlParameter(ExpenseOutstanding._ExpregOutId, SqlDbType.BigInt);
                SqlParameter pExpenseHdId = new SqlParameter(ExpenseOutstanding._ExpenseHdId, SqlDbType.BigInt);
                SqlParameter pAmount = new SqlParameter(ExpenseOutstanding._Amount, SqlDbType.Decimal);
                SqlParameter pRemark = new SqlParameter(ExpenseOutstanding._Remark, SqlDbType.NVarChar);

                pAction.Value = 4;
                pExpregOutId.Value = Entity_EO.ExpregOutId;
                pExpenseHdId.Value = Entity_EO.ExpenseHdId;
                pAmount.Value = Entity_EO.Amount;
                pRemark.Value = Entity_EO.Remark;


                SqlParameter[] param = new SqlParameter[] { pAction, pExpregOutId, pExpenseHdId, pAmount, pRemark };

                Open(CONNECTION_STRING);
                BeginTransaction();

                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, ExpenseOutstanding.SP_ExpenceOutstandingReg, param);

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
                SqlParameter pAction = new SqlParameter(ExpenseOutstanding._Action, SqlDbType.BigInt);
                SqlParameter pRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

                pAction.Value = 5;
                pRepCondition.Value = RepCondition;

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, ExpenseOutstanding.SP_ExpenceOutstandingReg, pAction, pRepCondition);
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
                SqlParameter MAction = new SqlParameter(ExpenseOutstanding._Action, SqlDbType.BigInt);
                MAction.Value = 6;
                SqlParameter MExpregOutId = new SqlParameter(ExpenseOutstanding._ExpregOutId, SqlDbType.BigInt);
                MExpregOutId.Value = Id;

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, ExpenseOutstanding.SP_ExpenceOutstandingReg, MAction, MExpregOutId);
            }
            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally { Close(); }

            return Ds;
        }

        public int DeleteExpenceHead(ref ExpenseOutstanding Entity_PM, out string StrError)
        {
            StrError = string.Empty;
            int insertrow = 0;
            try
            {
                SqlParameter pAction = new SqlParameter(ExpenseOutstanding._Action, SqlDbType.BigInt);
                pAction.Value = 3;

                SqlParameter pExpregOutId = new SqlParameter(ExpenseOutstanding._ExpregOutId, SqlDbType.BigInt);
                pExpregOutId.Value = Entity_PM.ExpregOutId;

                SqlParameter pCreatedby = new SqlParameter(ExpenseOutstanding._UserId, SqlDbType.BigInt);
                pCreatedby.Value = Entity_PM.UserId;

                SqlParameter pCreatedDate = new SqlParameter(ExpenseOutstanding._LoginDate, SqlDbType.DateTime);
                pCreatedDate.Value = Entity_PM.LoginDate;

                SqlParameter[] ParamArray = new SqlParameter[] { pAction, pExpregOutId, pCreatedby, pCreatedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();

                insertrow = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, ExpenseOutstanding.SP_ExpenceOutstandingReg, ParamArray);

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

        public int UpdatetExpenceHead(ref ExpenseOutstanding Entity_EM, out string StrError)
        {
            StrError = string.Empty;
            int insertrow = 0;
            try
            {
                SqlParameter pAction = new SqlParameter(ExpenseOutstanding._Action, SqlDbType.BigInt);
                SqlParameter pExpregOutId = new SqlParameter(ExpenseOutstanding._ExpregOutId, SqlDbType.BigInt);
                SqlParameter pExpRegNo = new SqlParameter(ExpenseOutstanding._ExpRegNo, SqlDbType.NVarChar);
                SqlParameter pExpenceRegDate = new SqlParameter(ExpenseOutstanding._ExpenceRegDate, SqlDbType.DateTime);
                SqlParameter pPropertyId = new SqlParameter(ExpenseOutstanding._PropertyId, SqlDbType.BigInt);
                SqlParameter pPartyId = new SqlParameter(ExpenseOutstanding._PartyId, SqlDbType.BigInt);
                SqlParameter pUnitNo = new SqlParameter(ExpenseOutstanding._UnitNo, SqlDbType.NVarChar);
                SqlParameter pExpenseHdId = new SqlParameter(ExpenseOutstanding._ExpenseHdId, SqlDbType.BigInt);
                SqlParameter pCreatedby = new SqlParameter(ExpenseOutstanding._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(ExpenseOutstanding._LoginDate, SqlDbType.DateTime);

                pAction.Value = 2;
                pExpRegNo.Value = Entity_EM.ExpRegNo;
                pExpregOutId.Value = Entity_EM.ExpregOutId;
                pExpenceRegDate.Value = Entity_EM.ExpenceRegDate;
                pPropertyId.Value = Entity_EM.PropertyId;
                pPartyId.Value = Entity_EM.PartyId;
                pUnitNo.Value = Entity_EM.UnitNo;
                pExpenseHdId.Value = Entity_EM.ExpenseHdId;
                pCreatedby.Value = Entity_EM.UserId;
                pCreatedDate.Value = Entity_EM.LoginDate;

                SqlParameter[] ParamArray = new SqlParameter[] { pAction, pExpRegNo, pExpregOutId, pExpenceRegDate, pPropertyId, pPartyId, pUnitNo, pExpenseHdId, pCreatedby, pCreatedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();
                insertrow = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, ExpenseOutstanding.SP_ExpenceOutstandingReg, ParamArray);

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
                SqlParameter pAction = new SqlParameter(ExpenseOutstanding._Action, SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

                pAction.Value = 5;
                PrepCondition.Value = preFixText;

                SqlParameter[] oparamcol = new SqlParameter[] { pAction, PrepCondition };

                Open(CONNECTION_STRING);
                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, ExpenseOutstanding.SP_ExpenceOutstandingReg, oparamcol);

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

                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ExpenceOutstandingReg", oParmCol);

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

        public DMExpenseOutsatnding()
        {

        }

        public DataSet GetDataOnProject(int Id, out string StrError)
        {
            StrError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter MAction = new SqlParameter(ExpenseOutstanding._Action, SqlDbType.BigInt);
                MAction.Value = 9;
                SqlParameter MPropertyId = new SqlParameter(ExpenseOutstanding._PropertyId, SqlDbType.BigInt);
                MPropertyId.Value = Id;

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, ExpenseOutstanding.SP_ExpenceOutstandingReg, MAction, MPropertyId);
            }
            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally { Close(); }

            return Ds;
        }

    }
}