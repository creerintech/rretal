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
using Build.Utility;
using Build.EntityClass;
using Build.DB;
using Build.DataModel;
using Build.DALSQLHelper;

namespace Build.DataModel
{
    public class DMPropertySubTypeMaster:Utility.Setting
    {
        public int InsertRecord(ref PropertySubTypeMaster Entity_call, out string strError)
        {
            int iInsert = 0;
            strError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(PropertySubTypeMaster._Action, SqlDbType.BigInt);
                SqlParameter pPropertySubTypeDesc= new SqlParameter(PropertySubTypeMaster._PropertySubTypeDesc, SqlDbType.NVarChar);
                SqlParameter pProjectTypeId = new SqlParameter(PropertySubTypeMaster._PropertyTypeId, SqlDbType.BigInt);
                SqlParameter pCreatedBy = new SqlParameter(PropertySubTypeMaster._LoginId, SqlDbType.BigInt);
                SqlParameter PCreatedDate = new SqlParameter(PropertySubTypeMaster._LoginDate, SqlDbType.DateTime);

                pAction.Value = 1;
                pPropertySubTypeDesc.Value = Entity_call.PropertySubTypeDesc;
                pProjectTypeId.Value = Entity_call.PropertyTypeId;
                pCreatedBy.Value = Entity_call.LoginId;
                PCreatedDate.Value = Entity_call.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pPropertySubTypeDesc, pProjectTypeId, pCreatedBy, PCreatedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();

                iInsert = SQLHelper.ExecuteScalar(_Connection, _Transaction, CommandType.StoredProcedure, PropertySubTypeMaster.SP_PropertySubTypeMaster, param);

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
                strError = ex.Message;
            }

            finally
            {
                Close();
            }
            return iInsert;
        }

        public int UpdateRecord(ref PropertySubTypeMaster Entity_Call, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(PropertySubTypeMaster._Action, SqlDbType.BigInt);
                SqlParameter pStateId = new SqlParameter(PropertySubTypeMaster._PropertySubTypeId, SqlDbType.BigInt);
                SqlParameter pStateName = new SqlParameter(PropertySubTypeMaster._PropertySubTypeDesc, SqlDbType.NVarChar);
                SqlParameter pZoneId = new SqlParameter(PropertySubTypeMaster._PropertyTypeId, SqlDbType.BigInt);
                SqlParameter pCreatedBy = new SqlParameter(PropertySubTypeMaster._LoginId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(PropertySubTypeMaster._LoginDate, SqlDbType.DateTime);

                pAction.Value = 2;
                pStateId.Value = Entity_Call.PropertySubTypeId;
                pStateName.Value = Entity_Call.PropertySubTypeDesc;
                pZoneId.Value = Entity_Call.PropertyTypeId;               
                pCreatedBy.Value = Entity_Call.LoginId;
                pCreatedDate.Value = Entity_Call.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pStateId, pStateName, pZoneId, pCreatedBy, pCreatedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();

                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, PropertySubTypeMaster.SP_PropertySubTypeMaster, param);
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

        public int DeleteRecord(ref PropertySubTypeMaster EntityCall, out string StrError)
        {
            int iDelete = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(PropertySubTypeMaster._Action, SqlDbType.BigInt);
                SqlParameter PStateId = new SqlParameter(PropertySubTypeMaster._PropertySubTypeId, SqlDbType.BigInt);
                SqlParameter pDeletedBy = new SqlParameter(PropertySubTypeMaster._LoginId, SqlDbType.BigInt);
                SqlParameter pDeletedDate = new SqlParameter(PropertySubTypeMaster._LoginDate, SqlDbType.DateTime);
                pAction.Value = 3;
                PStateId.Value = EntityCall.PropertySubTypeId;
                pDeletedBy.Value = EntityCall.LoginId;
                pDeletedDate.Value = EntityCall.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, PStateId, pDeletedBy, pDeletedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();

                iDelete = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, PropertySubTypeMaster.SP_PropertySubTypeMaster, param);

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

        public DataSet GetPropertySubTypeForEdit(int ID, out string strError)
        {
            strError = string.Empty;
            DataSet DS = new DataSet();

            try
            {
                SqlParameter pAction = new SqlParameter(PropertySubTypeMaster._Action, SqlDbType.BigInt);
                SqlParameter PStateId = new SqlParameter(PropertySubTypeMaster._PropertySubTypeId, SqlDbType.BigInt);

                pAction.Value = 4;
                PStateId.Value = ID;

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, PropertySubTypeMaster.SP_PropertySubTypeMaster, pAction, PStateId);

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

        public DataSet GetPropertySubType(string RepCondition, out string StrError)
        {
            StrError = string.Empty;

            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(PropertySubTypeMaster._Action, SqlDbType.BigInt);
                SqlParameter pRepCondition = new SqlParameter(PropertySubTypeMaster._StrCondition, SqlDbType.NVarChar);


                pAction.Value = 5;
                pRepCondition.Value = RepCondition;

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, PropertySubTypeMaster.SP_PropertySubTypeMaster, pAction, pRepCondition);


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
                SqlParameter pAction = new SqlParameter(PropertySubTypeMaster._Action, SqlDbType.BigInt);
                SqlParameter PRepCondition = new SqlParameter(PropertySubTypeMaster._StrCondition, SqlDbType.NVarChar);
                pAction.Value = 6;
                PRepCondition.Value = Name;
                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, PropertySubTypeMaster.SP_PropertySubTypeMaster,
                    pAction, PRepCondition);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

            }
            return DS;
        }

        public string[] GetSuggestRecord(string prefixText)
        {
            List<string> SearchList = new List<string>();
            string ListItem = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(PropertySubTypeMaster._Action, SqlDbType.BigInt);
                SqlParameter pRepCondition = new SqlParameter(PropertySubTypeMaster._StrCondition, SqlDbType.NVarChar);

                pAction.Value = 5;
                pRepCondition.Value = prefixText;

                SqlParameter[] oparamcol = new SqlParameter[] { pAction, pRepCondition };
                Open(CONNECTION_STRING);

                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, PropertySubTypeMaster.SP_PropertySubTypeMaster, oparamcol);
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

        public DataSet BindCombo(out string StrError)
        {
            DataSet ds = new DataSet();
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                
                pAction.Value = 7;
                

                Open(CONNECTION_STRING);

                ds = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_PropertySubTypeMaster", pAction);
            }
            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return ds;
        }


        public DMPropertySubTypeMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }

}