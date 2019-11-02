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
    public class DMExpenceHeadMaster : Utility.Setting
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

                DS = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ExpenceHeadMaster", pAction);

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

                Ds = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ExpenceHeadMaster", MAction);

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

        public int InsertExpenceHead(ref ExpencesHeadMaster Entity_EH, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(ExpencesHeadMaster._Action, SqlDbType.BigInt);
                SqlParameter pExpenceNo = new SqlParameter(ExpencesHeadMaster._ExpenceNo, SqlDbType.NVarChar);
                SqlParameter pExpenceDate = new SqlParameter(ExpencesHeadMaster._ExpenceDate, SqlDbType.DateTime);
                SqlParameter pPropertyId = new SqlParameter(ExpencesHeadMaster._PropertyId, SqlDbType.BigInt);              
                SqlParameter pCreatedBy = new SqlParameter(ExpencesHeadMaster._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(ExpencesHeadMaster._LoginDate, SqlDbType.DateTime);

                pAction.Value =1;
                pExpenceNo.Value = Entity_EH.ExpenceNo;
                pExpenceDate.Value = Entity_EH.ExpenceDate;
                pPropertyId.Value = Entity_EH.PropertyId;             
                pCreatedBy.Value = Entity_EH.UserId;
                pCreatedDate.Value = Entity_EH.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pExpenceNo, pExpenceDate, pPropertyId, pCreatedBy, pCreatedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteScalar(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ExpenceHeadMaster", param);

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

        public int InsertExpenceHeadDetail(ref ExpencesHeadMaster Entity_EH, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(ExpencesHeadMaster._Action, SqlDbType.BigInt);
                SqlParameter pExpenceId = new SqlParameter(ExpencesHeadMaster._ExpenceId, SqlDbType.BigInt);
                SqlParameter pPerticulars = new SqlParameter(ExpencesHeadMaster._Perticulars, SqlDbType.NVarChar);              
                SqlParameter pRate = new SqlParameter(ExpencesHeadMaster._Rate, SqlDbType.Decimal);
                SqlParameter pQty = new SqlParameter(ExpencesHeadMaster._Qty, SqlDbType.Decimal);               
                SqlParameter pAmount = new SqlParameter(ExpencesHeadMaster._Amount, SqlDbType.Decimal);
                SqlParameter pRemark = new SqlParameter(ExpencesHeadMaster._Remark, SqlDbType.NVarChar);
                
                pAction.Value = 4;
                pExpenceId.Value = Entity_EH.ExpenceId;
                pPerticulars.Value = Entity_EH.Perticulars;               
                pRate.Value = Entity_EH.Rate;
                pQty.Value = Entity_EH.Qty;
                pAmount.Value = Entity_EH.Amount;               
                pRemark.Value = Entity_EH.Remark;


                SqlParameter[] param = new SqlParameter[] { pAction, pExpenceId, pPerticulars, pRate, pQty, pAmount, pRemark };

                Open(CONNECTION_STRING);
                BeginTransaction();

                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, ExpencesHeadMaster.SP_ExpenceHeadMaster, param);

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
                SqlParameter pAction = new SqlParameter(ExpencesHeadMaster._Action, SqlDbType.BigInt);
                SqlParameter pRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

                pAction.Value = 5;
                pRepCondition.Value = RepCondition;

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, ExpencesHeadMaster.SP_ExpenceHeadMaster, pAction, pRepCondition);
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
                SqlParameter MAction = new SqlParameter(ExpencesHeadMaster._Action, SqlDbType.BigInt);
                MAction.Value = 6;
                SqlParameter MExpenceId = new SqlParameter(ExpencesHeadMaster._ExpenceId, SqlDbType.BigInt);
                MExpenceId.Value = Id;

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, ExpencesHeadMaster.SP_ExpenceHeadMaster, MAction, MExpenceId);
            }
            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally { Close(); }

            return Ds;
        }

        public int DeleteExpenceHead(ref ExpencesHeadMaster Entity_PM, out string StrError)
        {
            StrError = string.Empty;
            int insertrow = 0;
            try
            {
                SqlParameter pAction = new SqlParameter(ExpencesHeadMaster._Action, SqlDbType.BigInt);
                pAction.Value = 6;

                SqlParameter pExpenceId = new SqlParameter(ExpencesHeadMaster._ExpenceId, SqlDbType.BigInt);
                pExpenceId.Value = Entity_PM.ExpenceId;

                SqlParameter pCreatedby = new SqlParameter(ExpencesHeadMaster._UserId, SqlDbType.BigInt);
                pCreatedby.Value = Entity_PM.UserId;

                SqlParameter pCreatedDate = new SqlParameter(ExpencesHeadMaster._LoginDate, SqlDbType.DateTime);
                pCreatedDate.Value = Entity_PM.LoginDate;

                SqlParameter[] ParamArray = new SqlParameter[] { pAction, pExpenceId, pCreatedby, pCreatedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();

                insertrow = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, ExpencesHeadMaster.SP_ExpenceHeadMaster, ParamArray);

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

        public int UpdatetExpenceHead(ref ExpencesHeadMaster Entity_EM, out string StrError)
        {
            StrError = string.Empty;
            int insertrow = 0;
            try
            {
                SqlParameter pAction = new SqlParameter(ExpencesHeadMaster._Action, SqlDbType.BigInt);
                SqlParameter pExpenceId = new SqlParameter(ExpencesHeadMaster._ExpenceId, SqlDbType.BigInt);
                SqlParameter pExpenceNo = new SqlParameter(ExpencesHeadMaster._ExpenceNo, SqlDbType.NVarChar);
                SqlParameter pExpenceDate = new SqlParameter(ExpencesHeadMaster._ExpenceDate, SqlDbType.DateTime);
                SqlParameter pPropertyId = new SqlParameter(ExpencesHeadMaster._PropertyId, SqlDbType.BigInt);
                SqlParameter pCreatedby = new SqlParameter(ExpencesHeadMaster._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(ExpencesHeadMaster._LoginDate, SqlDbType.DateTime);

                pAction.Value = 2;
                pExpenceNo.Value = Entity_EM.ExpenceNo;
                pExpenceId.Value = Entity_EM.ExpenceId;
                pExpenceDate.Value = Entity_EM.ExpenceDate;
                pPropertyId.Value = Entity_EM.PropertyId;               
                pCreatedby.Value = Entity_EM.UserId;
                pCreatedDate.Value = Entity_EM.LoginDate;

                SqlParameter[] ParamArray = new SqlParameter[] { pAction, pExpenceNo, pExpenceId, pExpenceDate, pPropertyId, pCreatedby, pCreatedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();
                insertrow = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, ExpencesHeadMaster.SP_ExpenceHeadMaster, ParamArray);

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
                SqlParameter pAction = new SqlParameter(ExpencesHeadMaster._Action, SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

                pAction.Value = 5;
                PrepCondition.Value = preFixText;

                SqlParameter[] oparamcol = new SqlParameter[] { pAction, PrepCondition };

                Open(CONNECTION_STRING);
                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, ExpencesHeadMaster.SP_ExpenceHeadMaster, oparamcol);

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

        public DMExpenceHeadMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
