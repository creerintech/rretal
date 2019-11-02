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

/// <summary>
/// Summary description for DMPropertyType
/// </summary>
namespace Build.DataModel
{
    public class DMPropertyType : Utility.Setting
    {
        public int InsertRecord(ref PropertyType Entity_call, out string strError)
        {
            int iInsert = 0;
            strError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(PropertyType._Action, SqlDbType.BigInt);
                SqlParameter pPropertyType = new SqlParameter(PropertyType._PropertyTypeDesc, SqlDbType.NVarChar);
                SqlParameter pCreatedBy = new SqlParameter(PropertyType._LoginId, SqlDbType.BigInt);
                SqlParameter PCreatedDate = new SqlParameter(PropertyType._LoginDate, SqlDbType.DateTime);

                pAction.Value = 1;
                pPropertyType.Value = Entity_call.PropertyTypeDesc;
                pCreatedBy.Value = Entity_call.LoginId;
                PCreatedDate.Value = Entity_call.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pPropertyType, pCreatedBy, PCreatedDate};

                Open(CONNECTION_STRING);
                BeginTransaction();

                iInsert = SQLHelper.ExecuteScalar(_Connection, _Transaction, CommandType.StoredProcedure, PropertyType.SP_PropertyTypeMaster, param);

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

        public int UpdateRecord(ref PropertyType Entity_Call, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(PropertyType._Action, SqlDbType.BigInt);
                SqlParameter pPropertyTypeId = new SqlParameter(PropertyType._PropertyTypeId, SqlDbType.BigInt);
                SqlParameter pPropertyType = new SqlParameter(PropertyType._PropertyTypeDesc, SqlDbType.NVarChar);
                SqlParameter pCreatedBy = new SqlParameter(PropertyType._LoginId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(PropertyType._LoginDate, SqlDbType.DateTime);

                pAction.Value = 2;
                pPropertyTypeId.Value = Entity_Call.PropertyTypeId;
                pPropertyType.Value = Entity_Call.PropertyTypeDesc;
                pCreatedBy.Value = Entity_Call.LoginId;
                pCreatedDate.Value = Entity_Call.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pPropertyTypeId, pPropertyType, pCreatedBy, pCreatedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();

                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, PropertyType.SP_PropertyTypeMaster, param);
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

        public int DeleteRecord(ref PropertyType EntityCall, out string StrError)
        {
            int iDelete = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(PropertyType._Action, SqlDbType.BigInt);
                SqlParameter pPropertyTypeId = new SqlParameter(PropertyType._PropertyTypeId, SqlDbType.BigInt);
                SqlParameter pDeletedBy = new SqlParameter(PropertyType._LoginId, SqlDbType.BigInt);
                SqlParameter pDeletedDate = new SqlParameter(PropertyType._LoginDate, SqlDbType.DateTime);
                pAction.Value = 3;
                pPropertyTypeId.Value = EntityCall.PropertyTypeId;
                pDeletedBy.Value = EntityCall.LoginId;
                pDeletedDate.Value = EntityCall.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pPropertyTypeId, pDeletedBy, pDeletedDate};

                Open(CONNECTION_STRING);
                BeginTransaction();

                iDelete = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, PropertyType.SP_PropertyTypeMaster, param);

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

        public DataSet GetPropertyTypeForEdit(int ID, out string strError)
        {
            strError = string.Empty;
            DataSet DS = new DataSet();

            try
            {
                SqlParameter pAction = new SqlParameter(PropertyType._Action, SqlDbType.BigInt);
                SqlParameter pPropertyTypeId = new SqlParameter(PropertyType._PropertyTypeId, SqlDbType.BigInt);

                pAction.Value = 4;
                pPropertyTypeId.Value = ID;

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, PropertyType.SP_PropertyTypeMaster, pAction, pPropertyTypeId);

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

        public DataSet GetPropertyType(string RepCondition, out string StrError)
        {
            StrError = string.Empty;

            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(PropertyType._Action, SqlDbType.BigInt);
                SqlParameter pRepCondition = new SqlParameter(PropertyType._StrCondition, SqlDbType.NVarChar);


                pAction.Value = 5;
                pRepCondition.Value = RepCondition;

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, PropertyType.SP_PropertyTypeMaster, pAction, pRepCondition);


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
                SqlParameter pAction = new SqlParameter(PropertyType._Action, SqlDbType.BigInt);
                SqlParameter PRepCondition = new SqlParameter(PropertyType._StrCondition, SqlDbType.NVarChar);
                pAction.Value = 6;
                PRepCondition.Value = Name;
                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, PropertyType.SP_PropertyTypeMaster,
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
                SqlParameter pAction = new SqlParameter(PropertyType._Action, SqlDbType.BigInt);
                SqlParameter pRepCondition = new SqlParameter(PropertyType._StrCondition, SqlDbType.NVarChar);
             
                pAction.Value = 5;
                pRepCondition.Value = prefixText;
                
                SqlParameter[] oparamcol = new SqlParameter[] { pAction, pRepCondition };
                Open(CONNECTION_STRING);
                
                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, PropertyType.SP_PropertyTypeMaster, oparamcol);
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

        public DMPropertyType()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
