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
    public class DMPropertyMaintenance : Utility.Setting
    {
        public DataSet FillCombo(out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);

                pAction.Value = 1;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_PropertyMaintenance", pAction);

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

        public DMPropertyMaintenance()
        {

        }

        public DataSet GetPMNo(out string StrError)
        {
            StrError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);
                MAction.Value = 2;

                Open(Setting.CONNECTION_STRING);

                Ds = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_PropertyMaintenance", MAction);

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

        public int InsertPM(ref PropertyMaintenance Entity_PM, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(PropertyMaintenance._Action, SqlDbType.BigInt);
                SqlParameter pPMNo = new SqlParameter(PropertyMaintenance._PMNo, SqlDbType.NVarChar);
                SqlParameter pPMDate = new SqlParameter(PropertyMaintenance._PMDate, SqlDbType.DateTime);
                SqlParameter pPropertyId = new SqlParameter(PropertyMaintenance._PropertyId, SqlDbType.BigInt);
                SqlParameter pPartyId = new SqlParameter(PropertyMaintenance._PartyId, SqlDbType.BigInt);
                SqlParameter pComplitFlag = new SqlParameter(PropertyMaintenance._ComplitFlag, SqlDbType.NVarChar);
                SqlParameter pMaintenaceType = new SqlParameter(PropertyMaintenance._MaintenaceType, SqlDbType.NVarChar);
                SqlParameter pCreatedBy = new SqlParameter(PropertyMaintenance._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(PropertyMaintenance._LoginDate, SqlDbType.DateTime);

                pAction.Value = 3;
                pPMNo.Value = Entity_PM.PMNo;
                pPMDate.Value = Entity_PM.PMDate;
                pPropertyId.Value = Entity_PM.PropertyId;
                pPartyId.Value = Entity_PM.PartyId;
                pComplitFlag.Value = Entity_PM.ComplitFlag;
                pMaintenaceType.Value = Entity_PM.MaintenaceType;
                pCreatedBy.Value = Entity_PM.UserId;
                pCreatedDate.Value = Entity_PM.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pPMNo, pPMDate, pPropertyId, pPartyId, pComplitFlag, pMaintenaceType, pCreatedBy, pCreatedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteScalar(_Connection, _Transaction, CommandType.StoredProcedure, "SP_PropertyMaintenance", param);

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

        public int InsertPMDetail(ref PropertyMaintenance Entity_PM, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(PropertyMaintenance._Action, SqlDbType.BigInt);
                SqlParameter pPropertyMaintenaceId = new SqlParameter(PropertyMaintenance._PropertyMaintenaceId, SqlDbType.BigInt);
                SqlParameter pFlagCheck = new SqlParameter(PropertyMaintenance._FlagCheck, SqlDbType.Bit);
                SqlParameter pUnitNo = new SqlParameter(PropertyMaintenance._UnitNo, SqlDbType.BigInt);
                SqlParameter pExpenseHdId = new SqlParameter(PropertyMaintenance._ExpenseHdId, SqlDbType.BigInt);
                SqlParameter pAmount = new SqlParameter(PropertyMaintenance._Amount, SqlDbType.Decimal);
               
                

                pAction.Value = 10;
                pPropertyMaintenaceId.Value = Entity_PM.PropertyMaintenaceId;
                pFlagCheck.Value = Entity_PM.FlagCheck;
                pUnitNo.Value = Entity_PM.UnitNo;
                pExpenseHdId.Value = Entity_PM.ExpenseHdId;
                pAmount.Value = Entity_PM.Amount;


                SqlParameter[] param = new SqlParameter[] { pAction, pPropertyMaintenaceId, pFlagCheck, pUnitNo, pExpenseHdId, pAmount };

                Open(CONNECTION_STRING);
                BeginTransaction();

                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, PropertyMaintenance.SP_PropertyMaintenance, param);

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
                SqlParameter pAction = new SqlParameter(PropertyMaintenance._Action, SqlDbType.BigInt);
                SqlParameter pRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

                pAction.Value = 7;
                pRepCondition.Value = RepCondition;

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, PropertyMaintenance.SP_PropertyMaintenance, pAction, pRepCondition);
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

        public DataSet GetPropertyToEdit(int Id, out string StrError)
        {
            StrError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter MAction = new SqlParameter(PropertyMaintenance._Action, SqlDbType.BigInt);
                MAction.Value = 8;
                SqlParameter MContractorID = new SqlParameter(PropertyMaintenance._PropertyMaintenaceId, SqlDbType.BigInt);
                MContractorID.Value = Id;

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, PropertyMaintenance.SP_PropertyMaintenance, MAction, MContractorID);
            }
            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally { Close(); }

            return Ds;
        }

        public int DeleteProjectMdetails(ref PropertyMaintenance Entity_PM, out string StrError)
        {
            StrError = string.Empty;
            int insertrow = 0;
            try
            {
                SqlParameter pAction = new SqlParameter(PropertyMaintenance._Action, SqlDbType.BigInt);
                pAction.Value = 6;

                SqlParameter pPropertyMaintenaceId = new SqlParameter(PropertyMaintenance._PropertyMaintenaceId, SqlDbType.BigInt);
                pPropertyMaintenaceId.Value = Entity_PM.PropertyMaintenaceId;

                SqlParameter pCreatedby = new SqlParameter(PropertyMaintenance._UserId, SqlDbType.BigInt);
                pCreatedby.Value = Entity_PM.UserId;

                SqlParameter pCreatedDate = new SqlParameter(PropertyMaintenance._LoginDate, SqlDbType.DateTime);
                pCreatedDate.Value = Entity_PM.LoginDate;

                SqlParameter[] ParamArray = new SqlParameter[] { pAction, pPropertyMaintenaceId, pCreatedby, pCreatedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();

                insertrow = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, PropertyMaintenance.SP_PropertyMaintenance, ParamArray);

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

        public int UpdatetPropertyMaintenance(ref PropertyMaintenance Entity_PM, out string StrError)
        {
            StrError = string.Empty;
            int insertrow = 0;
            try
            {
                SqlParameter pAction = new SqlParameter(PropertyMaintenance._Action, SqlDbType.BigInt);
                SqlParameter pPropertyMaintenaceId = new SqlParameter(PropertyMaintenance._PropertyMaintenaceId, SqlDbType.BigInt);
                SqlParameter pPMNo = new SqlParameter(PropertyMaintenance._PMNo, SqlDbType.NVarChar);
                SqlParameter pPMDate = new SqlParameter(PropertyMaintenance._PMDate, SqlDbType.DateTime);
                SqlParameter pPropertyId = new SqlParameter(PropertyMaintenance._PropertyId, SqlDbType.BigInt);
                SqlParameter pPartyId = new SqlParameter(PropertyMaintenance._PartyId, SqlDbType.BigInt);
                SqlParameter pComplitFlag = new SqlParameter(PropertyMaintenance._ComplitFlag, SqlDbType.NVarChar);
                SqlParameter pMaintenaceType = new SqlParameter(PropertyMaintenance._MaintenaceType, SqlDbType.NVarChar);
                SqlParameter pCreatedby = new SqlParameter(PropertyMaintenance._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(PropertyMaintenance._LoginDate, SqlDbType.DateTime);

                pAction.Value = 5;
                pPMNo.Value = Entity_PM.PMNo;
                pPropertyMaintenaceId.Value = Entity_PM.PropertyMaintenaceId;
                pPMDate.Value = Entity_PM.PMDate;
                pPropertyId.Value = Entity_PM.PropertyId;
                pPartyId.Value = Entity_PM.PartyId;
                pComplitFlag.Value = Entity_PM.ComplitFlag;
                pMaintenaceType.Value = Entity_PM.MaintenaceType;
                pCreatedby.Value = Entity_PM.UserId;
                pCreatedDate.Value = Entity_PM.LoginDate;

                SqlParameter[] ParamArray = new SqlParameter[] { pAction, pPMNo, pPropertyMaintenaceId, pPMDate, pPropertyId, pPartyId, pComplitFlag, pMaintenaceType, pCreatedby, pCreatedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();
                insertrow = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, PropertyMaintenance.SP_PropertyMaintenance, ParamArray);

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
                SqlParameter pAction = new SqlParameter(PropertyMaintenance._Action, SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

                pAction.Value = 7;
                PrepCondition.Value = preFixText;

                SqlParameter[] oparamcol = new SqlParameter[] { pAction, PrepCondition };

                Open(CONNECTION_STRING);
                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, PropertyMaintenance.SP_PropertyMaintenance, oparamcol);

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

        public DataSet GetDataOnProject(int Id, out string StrError)
        {
            StrError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter MAction = new SqlParameter(PropertyMaintenance._Action, SqlDbType.BigInt);
                MAction.Value = 9;
                SqlParameter MPropertyId = new SqlParameter(PropertyMaintenance._PropertyId, SqlDbType.BigInt);
                MPropertyId.Value = Id;

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, PropertyMaintenance.SP_PropertyMaintenance, MAction, MPropertyId);
            }
            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally { Close(); }

            return Ds;
        }

        public DataSet ChkDuplicate(int ProjectId, int PartyId,out string StrError)
        {
            StrError = string.Empty;

            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(PropertyMaintenance._Action, SqlDbType.BigInt);
                SqlParameter pPropertyId = new SqlParameter(PropertyMaintenance._PropertyId, SqlDbType.BigInt);
                SqlParameter pPartyId = new SqlParameter(PropertyMaintenance._PartyId, SqlDbType.BigInt);
               

                pAction.Value = 11;
                pPropertyId.Value = ProjectId;
                pPartyId.Value = PartyId;
           
                SqlParameter[] ParamArray = new SqlParameter[] { pAction, pPropertyId, pPartyId };

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, PropertyMaintenance.SP_PropertyMaintenance, ParamArray);
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